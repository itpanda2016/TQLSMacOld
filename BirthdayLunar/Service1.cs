using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Common;
using System.Timers;
using Model.QYH;
using bllQYH = BLL.QYH;
//using wxQYH;
using System.Configuration;
using Newtonsoft.Json;
using bll = BirthdayLunarWeb.Bll;

namespace BirthdayLunar {
    public partial class Service1 : ServiceBase {
        LogTxtHelper txtLog = new LogTxtHelper(@"C:\");
        private static System.Timers.Timer aTimer;
        public Service1() {
            InitializeComponent();
        }
        protected override void OnStart(string[] args) {
            //每隔50分钟检查一次
            int m = 50;
            SetTimer(m);
            //txtLog.Info("\nPress the Enter key to exit the application...\n");
            txtLog.Info(string.Format("The application started at {0:HH:mm:ss.fff}", DateTime.Now));
            txtLog.Info("下一次执行时间：" + DateTime.Now.AddMinutes(Convert.ToDouble(m)));
            //Console.ReadLine();
            //aTimer.Stop();
            //aTimer.Dispose();
            //txtLog.Info("Terminating the application...");
        }
        protected override void OnStop() {
            txtLog.Info(string.Format("服务停止：{0:hh:mm:ss.fff}", DateTime.Now));
        }
        /// <summary>
        /// 初始Timer控件
        /// </summary>
        /// <param name="m">分钟</param>
        private void SetTimer(Int32 minitue) {
            // Create a timer with a two second interval.
            double interval = minitue * 60 * 1000;
            aTimer = new System.Timers.Timer(interval);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        /// <summary>
        /// 执行的事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(Object source, ElapsedEventArgs e) {
            txtLog.Info(string.Format("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime));
            Auths.Access_Token qyh = new Auths.Access_Token();
            string CorpID = ConfigurationManager.AppSettings["qyhCorpId"];
            string Secret = ConfigurationManager.AppSettings["qyhSecret"];
            //判断当前时间是否为设置的发送时间范围bll.SiteConfig.GetSendTime();
            txtLog.Info("如果没设置，则默认为早上9点");
            int sendHour = bll.SiteConfig.GetSendTime();
            if (sendHour <= 0) sendHour = 9;
            if (sendHour != DateTime.Now.Hour) {
                txtLog.Info(sendHour + "不在消息发送的时间范围内：" + DateTime.Now.Hour);
                return;
            }
            txtLog.Info("判断当天（国历）是否已发送了");
            if (bll.Log.CheckHasSend(DateTime.Now)) {
                txtLog.Info("今天已发过了，不再发送。");
                return;
            }
            Auths.Error err = new Auths.Error();
            qyh = bllQYH.Require.GetAccessToken(CorpID, Secret,ref err);
            if(err.errcode != 0) {
                txtLog.Info("获取Access_token出错。");
                return;
            }
            txtLog.Info("获取Token:" + qyh.access_token);
            //获取，并判断生日
            string strUserList = bllQYH.User.GetUserList(qyh.access_token, 33);
            string lunarDate = Utility.LunarDate(DateTime.Now).ToString("yyyy-MM-dd");
            txtLog.Info("当天对应的农历日期：" + lunarDate);
            QYHUserListMore userlist = JsonConvert.DeserializeObject<QYHUserListMore>(strUserList);
            if (userlist.errcode > 0) {
                txtLog.Info(DateTime.Now.ToString());
                txtLog.Info("获取用户列表出错");
                txtLog.Info(userlist.errcode.ToString());
                txtLog.Info(userlist.errmsg);
                return;
            }
            txtLog.Info("用户数量：" + userlist.userlist.Count);
            List<string> listUserBirthdayLunar = new List<string>();   //当天农历生日的用户
            foreach (var item in userlist.userlist) {
                //txtLog.Info("开始判断扩展字段是否为空。");
                if (item.extattr != null) {
                    //txtLog.Info("不为空的用户才会继续判断生日字段：");
                    foreach (var item2 in item.extattr.attrs) {
                        //txtLog.Info("准备开始判断不为空的生日用户。");
                        if (item2.Name == "生日" && item2.Value != "") {
                            //txtLog.Info("如果生日字段存在并且不为空。");
                            //txtLog.Info("有生日用户：" + item.Name + "，生日：" + item2.Value);
                            //DateTime userBirthday = Convert.ToDateTime(item2.Value);
                            //txtLog.Info("对应日期格式值：" + userBirthday.ToString());
                            //if (userBirthday != null && lunarDate.Month == userBirthday.Month && lunarDate.Day == userBirthday.Day) {
                            if (lunarDate.Remove(0,5) == item2.Value.Remove(0, 5)) {
                                //txtLog.Info(lunarDate.Remove(0, 5) + "|" + item2.Value.Remove(0, 5));
                                //if(item2.Value.Remove(0,5))
                                txtLog.Info("当天生日用户：" + item.UserId);
                                listUserBirthdayLunar.Add(item.UserId);
                                continue;
                            }
                        }
                    }
                }
            }
            txtLog.Info("当天过生日用户数量：" + listUserBirthdayLunar.Count);
            if (listUserBirthdayLunar.Count == 0) {
                txtLog.Info("今天没有过生日的用户：" + Utility.LunarDate(DateTime.Now));
                bll.Log.Add();
                return;
            }
            try {
                //获取后台规则列表
                txtLog.Info("获取后台规则列表。");
                DataTable dt = bll.Rule.GetRuleList();
                //准备发送消息的字典
                txtLog.Info("准备发送消息的字典");
                Dictionary<int, MessageVideo> tmpSendList = new Dictionary<int, MessageVideo>();
                    //图文消息对象
                    //Dictionary<int, MPNewsSendByMediaID> tmpSendList = new Dictionary<int, MPNewsSendByMediaID>();
                if (dt.Rows.Count > 0) {
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        txtLog.Info("第" + i + "次循环数据库记录开始。");
                        //图文消息对象
                        //MPNewsSendByMediaID msgMPNews = new MPNewsSendByMediaID();
                        //msgMPNews.safe = 1;
                        //视频消息对象
                        MessageVideo tmpVideoMessage = new MessageVideo();
                        MessageVideoChild tmpVideoChild = new MessageVideoChild();
                        tmpVideoChild.media_id = dt.Rows[i]["msgvalue"].ToString();
                        tmpVideoChild.title = dt.Rows[i]["videotitle"].ToString();
                        tmpVideoChild.description = dt.Rows[i]["videodescription"].ToString();
                        tmpVideoMessage.video = tmpVideoChild;
                        tmpVideoMessage.safe = 1;
                        txtLog.Info("看看消息的类型是什么：" + tmpVideoMessage.msgtype);
                        txtLog.Info("判断是否有标签过滤。");
                        //如果规则中有标签过滤
                        if (Convert.ToInt32(dt.Rows[i]["rulevalue"]) > 0) {
                            txtLog.Info("有");
                            //获取该标签的用户列表
                            string tagUserlist = bllQYH.User.GetUserListByTag(qyh.access_token, Convert.ToInt32(dt.Rows[i]["rulevalue"]));
                            TagUserList userlistModel = JsonConvert.DeserializeObject<TagUserList>(tagUserlist);
                            if (userlistModel.errcode > 0) {
                                txtLog.Info(DateTime.Now.ToString());
                                txtLog.Info("获取指定标签的用户列表出错。");
                                return;
                            }
                            txtLog.Info(userlistModel.userlist.Length + "标签用户");
                            foreach (var item in userlistModel.userlist) {
                                for (int j = 0; j < listUserBirthdayLunar.Count; j++) {
                                    if (listUserBirthdayLunar[j] == "del")
                                        continue;
                                    if (listUserBirthdayLunar[j] == item.userid) {
                                        //在视频消息中添加用户
                                        tmpVideoMessage.touser += listUserBirthdayLunar[j] + "|";
                                        //在图文消息中添加用户
                                        //msgMPNews.touser += listUserBirthdayLunar[j] + "|";
                                        //listUserBirthdayLunar.RemoveAt(j);
                                        listUserBirthdayLunar[j] = "del";
                                        continue;
                                    }
                                }
                            }
                            //图文消息子对象ID处理，视频消息在第1层就配置了
                            //MPNewsMediaID mpnewsMediaID = new MPNewsMediaID();
                            //mpnewsMediaID.media_id = dt.Rows[i]["msgvalue"].ToString();
                            //msgMPNews.mpnews = mpnewsMediaID;
                            txtLog.Info("标签用户处理结束。");
                        }
                        //如果规则中无标签过滤
                        else {
                            txtLog.Info("无");
                            //foreach是只读的
                            //foreach (var item2 in listUserBirthdayLunar) {
                            //    tmpVideoMessage.touser += item2 + "|";
                            //    listUserBirthdayLunar.Remove(item2);
                            //}

                            for (int k = 0; k < listUserBirthdayLunar.Count; k++) {
                                if (listUserBirthdayLunar[k] == "del")
                                    continue;
                                txtLog.Info("【无标签】共有生日用户：" + listUserBirthdayLunar.Count + "，当前获取用户：" + listUserBirthdayLunar[k]);
                                //视频消息，用户处理
                                tmpVideoMessage.touser += listUserBirthdayLunar[k] + "|";
                                //图文消息，用户处理
                                //msgMPNews.touser += listUserBirthdayLunar[k] + "|";
                                listUserBirthdayLunar[k] = "del";
                            }
                            //图文消息子对象ID处理，视频消息在第1层就配置了
                            //MPNewsMediaID mpnewsMediaID = new MPNewsMediaID();
                            //mpnewsMediaID.media_id = dt.Rows[i]["msgvalue"].ToString();
                            //msgMPNews.mpnews = mpnewsMediaID;
                            txtLog.Info("无标签规则处理结束。，用户为：" + tmpVideoMessage.touser);
                        }
                        //如此当前规则没有区配到用户列表，则跳过不添加发送
                        if (tmpVideoMessage.touser == null | tmpVideoMessage.touser == "")
                            //if (msgMPNews.touser == null | msgMPNews.touser == "")
                            continue;
                        //txtLog.Info("第" + i + "次用户列表：");
                        //txtLog.Info(tmpVideoMessage.touser);
                        //txtLog.Info(msgMPNews.touser);
                        tmpVideoMessage.touser = tmpVideoMessage.touser.Remove(tmpVideoMessage.touser.Length - 1);
                        //msgMPNews.touser = msgMPNews.touser.Remove(msgMPNews.touser.Length - 1);
                        txtLog.Info("处理后：");
                        txtLog.Info(tmpVideoMessage.touser);
                        //测试时使用:熊林/李福
                        tmpVideoMessage.touser += "|15228363212";
                        txtLog.Info("测试后的发送用户：" + tmpVideoMessage.touser);
                        //txtLog.Info(msgMPNews.touser);
                        //将每次循环后的发送规则添加到字典中
                        tmpSendList.Add(i, tmpVideoMessage);
                        //tmpSendList.Add(i, msgMPNews);
                        //txtLog.Info("第" + i + "次循环数据库结束。");
                    }
                }
                else {
                    txtLog.Info("请登录后台配置规则。");
                }
                txtLog.Info("准备发送消息记录。");
                //准备发送消息的循环
                foreach (var item in tmpSendList) {
                    txtLog.Info("准备发送的消息：" + JsonConvert.SerializeObject(item.Value));
                    //txtLog.Info("Token：" + qyh.access_token);
                    string ret = bllQYH.Message.SendMessage(qyh.access_token, JsonConvert.SerializeObject(item.Value));
                    MessageReturn msgRet = JsonConvert.DeserializeObject<MessageReturn>(ret);
                    if (msgRet.errcode > 0) {
                        txtLog.Info("消息发送失败：");
                        txtLog.Info(ret);
                    }
                    else {
                        txtLog.Info(ret);
                        txtLog.Info("消息已发送至：" + item.Value.touser);
                    }
                }
                bll.Log.Add();
            }
            catch (Exception er) {
                txtLog.Info("出错：" + DateTime.Now.ToString());
                txtLog.Info(er.Message);
            }
        }
    }
}
