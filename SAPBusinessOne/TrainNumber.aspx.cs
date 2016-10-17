using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace SAPBusinessOne {
    public partial class TrainNumber : System.Web.UI.Page ,IRequiresSessionState{
        protected void Page_Load(object sender, EventArgs e) {
            string tCodeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx811b855e73c9b606&redirect_uri=http://weixin.tqlsgroup.com/sap/&response_type=code&scope=snsapi_base&state=TrainNumber#wechat_redirect";
            if (Session["loginid"] == null) {
                Response.Redirect(tCodeUrl);
                return;
            }

        }
    }
}