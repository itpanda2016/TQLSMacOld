using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BirthdayLunarWeb.Admin {
    public partial class Main : System.Web.UI.Page {
        public bool hasRule;
        public DataTable dtRulelist; 
        protected void Page_Load(object sender, EventArgs e) {
            dtRulelist = Bll.Rule.GetRuleList();
            if(dtRulelist != null) {
                rptRulelist.DataSource = dtRulelist;
                rptRulelist.DataBind();
            }
        }
    }
}