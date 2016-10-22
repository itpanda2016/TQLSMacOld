using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BirthdayLunarWeb.Admin {
    public partial class SiteConfig : System.Web.UI.Page {
        public int sendhour;
        protected void Page_Load(object sender, EventArgs e) {
            sendhour = Bll.SiteConfig.GetSendTime();
        }
    }
}