using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthdayLunarWeb.Model {
    /// <summary>
    /// 规则实体
    /// </summary>
    public class Rule {
        /// <summary>
        /// 初始化实体，默认消息类型：视频，过滤类型：标签
        /// </summary>
        /// <param name="ruleType">默认tag</param>
        /// <param name="msgType">默认video</param>
        public Rule(string ruleType = "tag",string msgType = "video") {
            this.RuleType = ruleType;
            this.MsgType = msgType;
        }
        /// <summary>
        /// 规则ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 规则标识名称
        /// </summary>
        public string RuleName { set; get; }
        /// <summary>
        /// 规则过滤类型，可为空
        /// </summary>
        public string RuleType { set; get; }
        /// <summary>
        /// 规则过滤值，可为空
        /// </summary>
        public string RuleValue { set; get; }
        /// <summary>
        /// 发送消息类型
        /// </summary>
        public string MsgType { set; get; }
        /// <summary>
        /// 发送消息值
        /// </summary>
        public string MsgValue { set; get; }
        /// <summary>
        /// 视频消息标题
        /// </summary>
        public string VideoTitle { set; get; }
        /// <summary>
        /// 视频消息描述
        /// </summary>
        public string VideoDescription { set; get; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int Rank { set; get; }
        /// <summary>
        /// 记录创建时间
        /// </summary>
        public DateTime IdTime { set; get; }
        /// <summary>
        /// Debug
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return ("ID："+ this.ID + "|Name：" + this.RuleName + "|RuleType：" + this.RuleType + "|RuleValue：" + RuleValue + "|MsgType：" + this.MsgType + "|MsgValue：" + this.MsgValue + "|Rank：" + this.Rank
                + "|IdTime：" + this.IdTime);
        }
    }
}