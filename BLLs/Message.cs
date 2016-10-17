using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace BLL.QYH {
    /// <summary>
    /// 企业号：消息接口
    /// </summary>
    public class Message {
        /// <summary>
        /// 发送JSON格式消息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="msgData">消息体内容，JSON格式的字符串</param>
        /// <returns></returns>
        public static string SendMessage(string token, string msgData) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}",
                token);
            return Utility.CurlByDotNet(url, CurlMethod.POST, msgData);
        }
    }
}
