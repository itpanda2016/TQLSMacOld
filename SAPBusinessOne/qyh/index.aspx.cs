using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Common;
using System.Configuration;
using Newtonsoft.Json;
using System.Globalization;


namespace SAPBusinessOne.qyh {
    public partial class index : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            string a1= "{\"errcode\":333,\"errmsg\":\"cuo le\"}";
            Dictionary<string, object> test = JsonConvert.DeserializeObject<Dictionary<string,object>>(a1);
            foreach (KeyValuePair<string,object> item in test) {
                Response.Write(item.Key + "-" + item.Value);
            }
            //GetChineseDateTime(Convert.ToDateTime("2016-9-6"));
            write(Utility.LunarDate(Convert.ToDateTime("2016-9-6")).ToString());
        }
        public void GetChineseDateTime(DateTime datetime) {
            ChineseLunisolarCalendar ch = new ChineseLunisolarCalendar();
            write("判断日期：" + datetime.ToString());
            int year = ch.GetYear(datetime);
            int month = ch.GetMonth(datetime);
            int leapMonth = ch.GetLeapMonth(year);
            if(leapMonth > 0) {
                write("有闰月" + leapMonth);
            }
            else {
                write("无闰月" + leapMonth);
            }
            
            if (leapMonth > 0 && leapMonth <= month) {
                month--;
            }
            write("年" + year);
            write(string.Format("{0}年{1}月{2}日", year, month, ch.GetDayOfMonth(datetime)));
        }
        public void write(string str) {
            Response.Write(str + "<br />");
        }
    }
}