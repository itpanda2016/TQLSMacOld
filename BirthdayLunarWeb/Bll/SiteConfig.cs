using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Common;
using System.Text;
using System.Data;

namespace BirthdayLunarWeb.Bll {
    public class SiteConfig {
        /// <summary>
        /// 更新发送时间
        /// </summary>
        /// <param name="sendtime"></param>
        /// <returns></returns>
        public static bool SaveSendTime(int sendtime) {
            string sb = "update siteconfig set sendhour = " + sendtime;
            int n = SqlDbHelper.ExecuteNonQuery(sb);
            if (n == 1)
                return true;
            return false;
        }
        /// <summary>
        /// 获取发送时间
        /// </summary>
        /// <returns>-1：无效</returns>
        public static int GetSendTime() {
            string sb = "select sendhour from siteconfig";
            SqlDataReader sdr = SqlDbHelper.ExecuteReader(sb);
            if (sdr.Read())
                return Convert.ToInt32(sdr["sendhour"]);
            return -1;
        }
        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static bool Login(string strPassword) {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(*) from siteconfig where userpassword=@userpassword");
            SqlParameter[] paras = {
                new SqlParameter("@userpassword",strPassword)
            };
            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(sb.ToString(),CommandType.Text,paras));
            if (n == 1)
                return true;
            return false;
        }
    }
}