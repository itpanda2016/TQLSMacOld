using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BirthdayLunarWeb.Admin {
    public partial class Profile : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(Request["act"] != null) {
                if(Request["act"] == "changepassword") {
                    List<string> listPass = new List<string>();
                    
                }
            }
        }
    }
}