﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAPBusinessOne {
    public partial class Code : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string tCode = Request.QueryString["code"].ToString();
            if(tCode != "") {

            }
        }
    }
}