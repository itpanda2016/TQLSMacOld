using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Tencent;
using System.IO;
using System.Xml;
using Common;
using System.Configuration;
//using wxQYH;

namespace SAPBusinessOne.qyh {
    /// <summary>
    /// HandlerVerify 的摘要说明
    /// </summary>
    public class HandlerVerify : IHttpHandler,System.Web.SessionState.IRequiresSessionState{
        //string tCorpID = "wx811b855e73c9b606";
        //string tSecret = "kZFU8EWY_5zOqR2IPnj31ocT-fu_zp15gll-MmsvyN1TKtCLO8N-I-eEYiJshcmF";
        string tCorpID = "wx811b855e73c9b606";
        string tToken = "sptiJwDkdkUrcKTFBvozaL7o";
        string tEncodingAESKey = "ne7u3wlaiSzIhgAQ2GUmkhE99cMPRqdgDJjAsfKalRf";
        public void ProcessRequest(HttpContext context) {
            LogTxtHelper logTxtHelper = new LogTxtHelper(context.Server.MapPath(ConfigurationManager.AppSettings["logPath"].ToString()));
            WXBizMsgCrypt qywx = new WXBizMsgCrypt(tToken, tEncodingAESKey, tCorpID);

            context.Response.ContentType = "text/plain";
            if (context.Request.HttpMethod.ToUpper() == "GET") {
                string tMsgSignature = context.Request.QueryString["msg_signature"].ToString();
                string tTimeStamp = context.Request.QueryString["timestamp"].ToString();
                string tNonce = context.Request.QueryString["nonce"].ToString();
                string tEchoStr = context.Request.QueryString["echostr"].ToString();
                string tRetEchoStr = "";
                int errcode = qywx.VerifyURL(tMsgSignature, tTimeStamp, tNonce, tEchoStr, ref tRetEchoStr);
                if (errcode != 0) {
                    File.WriteAllText(context.Server.MapPath("~/logs/") + "log.txt", "ErrCode:" + errcode + " - " + tRetEchoStr);
                }
                else {
                    File.WriteAllText(context.Server.MapPath("~/logs/") + "log.txt", DateTime.Now.ToString());
                    context.Response.Write(tRetEchoStr);
                }
            }
            else if (context.Request.HttpMethod.ToUpper() == "POST") {
                logTxtHelper.Info("=================开始" + DateTime.Now.ToString() + "=================");
                Stream stream = context.Request.InputStream;
                logTxtHelper.Info("传入流Stream长度：");
                logTxtHelper.Info(Convert.ToString(stream.Length));
                byte[] streams = new byte[stream.Length];
                stream.Read(streams, 0, (Int32)stream.Length);
                logTxtHelper.Info("读取stream到数组streams[]中");
                string sReqData = Encoding.Default.GetString(streams);
                logTxtHelper.Info("转换streams[]为string格式：");
                logTxtHelper.Info(sReqData);

                string sReqMsgSig = context.Request["msg_signature"];
                string sReqTimeStamp = context.Request["timestamp"];
                string sReqNonce = context.Request["nonce"];
                string sMsg = "";
                logTxtHelper.Info("相关POST参数如下：");
                logTxtHelper.Info("sReqMsgSig - " + sReqMsgSig);
                logTxtHelper.Info("sReqTimeStamp - " + sReqTimeStamp);
                logTxtHelper.Info("sReqNonce - " + sReqNonce);
                int ret = qywx.DecryptMsg(sReqMsgSig, sReqTimeStamp, sReqNonce, sReqData, ref sMsg);
                if (ret != 0) {
                    logTxtHelper.Info("ERR: Decrypt Fail, ret: " + ret);
                    return;
                }
                logTxtHelper.Info("解密后密文内容：");
                logTxtHelper.Info(sMsg);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sMsg);
                XmlNode root = doc.FirstChild;
                string fromUrl = root["EventKey"].InnerText;
                logTxtHelper.Info("来源URL：" + fromUrl);
                StringBuilder sb = new StringBuilder();
                sb.Append("https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx811b855e73c9b606&redirect_uri=http://weixin.tqlsgroup.com/sap/&response_type=code&scope=snsapi_base&state=test#wechat_redirect");
                logTxtHelper.Info(sb.ToString());
                logTxtHelper.Info("=================结束=================");
                //context.Response.Redirect(sb.ToString());
                //logTxtHelper.Info("跳转后");
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
       
    }
}