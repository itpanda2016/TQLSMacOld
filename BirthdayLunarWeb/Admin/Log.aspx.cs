using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BirthdayLunarWeb.Admin {
    public partial class Log : System.Web.UI.Page {
        public DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e) {
            dt = Bll.Log.GetLogList();
            if(dt != null) {
                dt.DefaultView.Sort = " sendtime desc";
                rptLogs.DataSource = dt;
                rptLogs.DataBind();
            }
        }
    }
}