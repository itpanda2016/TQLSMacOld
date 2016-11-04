using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FROST.Utility;

namespace BirthdayLunarWeb.Bll {
    /// <summary>
    /// BirthdayLunarWeb.Bll.Log
    /// </summary>
    public class Log {
        /// <summary>
        /// 获取发送记录列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int,DateTime> GetLogList() {
            StringBuilder sb = new StringBuilder();
            sb.Append("select id,sendtime rom logs");
            DataTable dt = MsSQLHelper.ExecuteDataTable(sb.ToString());
            Dictionary<int, DateTime> dict = new Dictionary<int, DateTime>();
            if (dt.Rows.Count > 0) {
                foreach (DataRow item in dt.Rows) {
                    dict.Add(Convert.ToInt32(item["id"]), Convert.ToDateTime(item["sendtime"]));
                }
                return dict;
            }
            return null;
        }
        /// <summary>
        /// 判断是否有发送记录
        /// </summary>
        /// <param name="dt">农历日期</param>
        /// <returns>True:有，false：无</returns>
        public static bool CheckHasSend(DateTime dt) {
            string d = dt.Year + "/" +string.Format("{0:00}",dt.Month) + "/" + string.Format("{0:00}",dt.Day);
            string sb = "select count(*) from logs where CONVERT(VARCHAR(32),sendtime,111) like '" + d + "%'";
            int n = Convert.ToInt32(MsSQLHelper.ExecuteScalar(sb));
            if (n > 0)
                return true;
            return false;
        }
        /// <summary>
        /// 添加发送日志到数据库
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static bool Add() {
            Model.Log log = new Model.Log();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into logs (sendtime) values (@sendtime)");
            SqlParameter[] paras = {
                new SqlParameter("@sendtime",log.SendTime)
            };
            int n = MsSQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, paras);
            if (n == 1)
                return true;
            return false;
        }
    }
}