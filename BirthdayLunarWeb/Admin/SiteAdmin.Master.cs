using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Text;

namespace BirthdayLunarWeb.Admin {
    public partial class SiteAdmin : System.Web.UI.MasterPage,IRequiresSessionState {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["loginid"] == null)
                Response.Redirect("Login.aspx");
        }
    }
    
}