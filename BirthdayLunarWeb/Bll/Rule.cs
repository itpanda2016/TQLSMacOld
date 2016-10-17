using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace BirthdayLunarWeb.Bll {
    /// <summary>
    /// 规则相关业务方法
    /// 目前根据 过滤类型+过滤值 判断规则的唯一性
    /// </summary>
    public class Rule {
        /// <summary>
        /// 获取规则列表，按rank排序，asc
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRuleList() {
            StringBuilder sb = new StringBuilder();
            sb.Append("select id,rulename,ruletype,rulevalue,msgtype,msgvalue,rank,idtime,videotitle,videodescription");
            sb.Append(" from rules order by rank asc");
            DataTable dt = SqlDbHelper.ExecuteDataTable(sb.ToString());
            if (dt.Rows.Count > 0)
                return dt;
            else
                return null;
        }
        /// <summary>
        /// 判断规则是否存在，存在：返回true，不存在：返回false
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool CheckRule(Model.Rule rule) {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(*) from rules");
            sb.AppendFormat(" where ruletype='{0}' and rulevalue='{1}'", rule.RuleType, rule.RuleValue);
            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(sb.ToString()));
            if (n == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 添加一条新规则
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool Add(Model.Rule rule) {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into rules (rulename,ruletype,rulevalue,msgtype,msgvalue,rank,idtime,videotitle,videodescription)");
            sb.Append(" values (@rulename,@ruletype,@rulevalue,@msgtype,@msgvalue,@rank,@idtime,@videotitle,@videodescription)");
            SqlParameter[] paras = {
                new SqlParameter("@rulename",rule.RuleName),
                new SqlParameter("@ruletype",rule.RuleType),
                new SqlParameter("@rulevalue",rule.RuleValue),
                new SqlParameter("@msgtype",rule.MsgType),
                new SqlParameter("@msgvalue",rule.MsgValue),
                new SqlParameter("@rank",rule.Rank),
                new SqlParameter("@idtime",rule.IdTime),
                new SqlParameter("@videotitle",rule.VideoTitle),
                new SqlParameter("@videodescription",rule.VideoDescription)
            };
            int n = SqlDbHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, paras);
            if (n == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        public static bool Delete(int ruleId) {
            string sb = "delete rules where id = " + ruleId;
            int n = SqlDbHelper.ExecuteNonQuery(sb.ToString());
            if (n == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 根据ID获取规则详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Model.Rule GetRuleById(int id) {
            Model.Rule rule = new Model.Rule();
            StringBuilder sb = new StringBuilder();
            sb.Append("select id,rulename,msgtype,msgvalue,ruletype,rulevalue,rank,idtime,videotitle,videodescription from rules");
            sb.Append(" where id = " + id);
            SqlDataReader sdr = SqlDbHelper.ExecuteReader(sb.ToString());
            if (sdr.Read()) {
                rule.ID = id;
                rule.RuleName = sdr["rulename"].ToString();
                rule.MsgType = sdr["msgtype"].ToString();
                rule.MsgValue = sdr["msgvalue"].ToString();
                rule.RuleType = sdr["ruletype"].ToString();
                rule.RuleValue = sdr["rulevalue"].ToString();
                rule.Rank = Convert.ToInt32(sdr["rank"]);
                rule.IdTime = Convert.ToDateTime(sdr["idtime"]);
                rule.VideoTitle = sdr["videotitle"].ToString();
                rule.VideoDescription = sdr["videodescription"].ToString();
                return rule;
            }
            return null;
        }
        /// <summary>
        /// 更新规则
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool Update(Model.Rule rule) {
            StringBuilder sb = new StringBuilder();
            sb.Append("update rules set rulename=@rulename,");
            sb.Append("msgtype=@msgtype,msgvalue=@msgvalue,");
            sb.Append("ruletype=@ruletype,rulevalue=@rulevalue,");
            sb.Append("rank=@rank,idtime=@idtime,");
            sb.Append("videotitle=@videotitle,videodescription=@videodescription");
            sb.Append(" where id = " + rule.ID);
            SqlParameter[] paras = {
                new SqlParameter("@rulename",rule.RuleName),
                new SqlParameter("@msgtype",rule.MsgType),
                new SqlParameter("@msgvalue",rule.MsgValue),
                new SqlParameter("@ruletype",rule.RuleType),
                new SqlParameter("@rulevalue",rule.RuleValue),
                new SqlParameter("@rank",rule.Rank),
                new SqlParameter("@idtime",rule.IdTime),
                new SqlParameter("@videotitle",rule.VideoTitle),
                new SqlParameter("@videodescription",rule.VideoDescription)
            };
            int n = SqlDbHelper.ExecuteNonQuery(sb.ToString(),CommandType.Text,paras);
            if (n == 0)
                return false;
            else
                return true;
        }
    }
}