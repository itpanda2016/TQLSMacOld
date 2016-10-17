using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ZhaoPin {
    public partial class Message : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Page.Title = "铁骑力士集团 - 招聘";
            if (Request["msgtitle"] == null)
                msgTitle.InnerText = "提示信息";
            else
                msgTitle.InnerText = Request["msgtitle"];
            if (Request["msgurl"] == null)
                msgHref.HRef = "javascript:history.go(-1);";
            else
                msgHref.HRef = Request["msgurl"];
            //msgHref.InnerText = "";   //直接HTML固定
            msgContent.InnerText = Request["msgcontent"];
        }
    }
    /// <summary>
    /// 消息集中处理
    /// </summary>
    public partial class Message {
        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="content">消息内容</param>
        /// <param name="url">跳转URL，可为空</param>
        public static void Dialog(string content, string url = null) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Message.aspx?");
            sb.AppendFormat("msgcontent={0}", content);
            if (url != null)
                sb.AppendFormat("&msgurl={0}", url);
            HttpContext.Current.Response.Redirect(sb.ToString());
        }
    }
}