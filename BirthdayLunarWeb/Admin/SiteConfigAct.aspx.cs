using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BirthdayLunarWeb.Admin {
    public partial class SiteConfigAct : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["act"] == null) {
                Response.Write("Access Denied.");
                return;
            }
            int tmpSendtime =Convert.ToInt32( Request["sendtime"]) ;
            if (Bll.SiteConfig.SaveSendTime(tmpSendtime)) {
                Message.Dialog("保存成功。", "SiteConfig.aspx");
            }
            else {
                Message.Dialog("保存失败，请重试。");
            }
        }
    }
}