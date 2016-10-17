using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FROST.Utility;

namespace ZhaoPin {
    /// <summary>
    /// HandlerAction 的摘要说明
    /// </summary>
    public class HandlerAction : IHttpHandler {
        public Resume resume = new Resume();
        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            if (context.Request["act"] != null && context.Request["act"] == "add") {
                resume.Name = context.Request["name"];
                resume.Mobile = context.Request["mobile"];
                resume.Email = context.Request["email"];
                resume.School = context.Request["school"];
                resume.Education = context.Request["education"];
                resume.WorkYear = context.Request["workyear"];
                resume.CompanyNow = context.Request["companynow"];
                resume.PositionNow = context.Request["positionnow"];
                resume.Area = context.Request["area"];
                resume.Position = context.Request["position"];
                resume.Summary = context.Request["summary"];
                resume.PostTime = DateTime.Now;
                if (AddResume(resume))
                    Message.Dialog("您好，" + resume.Name + "，简历已成功投递，请等待HR初审。");
                else
                    Message.Dialog("添加失败，请咨询系统管理员。");
            }
        }
        /// <summary>
        /// 添加简历
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public static bool AddResume(Resume resume) {
            if (resume == null)
                return false;
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into resume (name,mobile,email,school,education,workyear,companynow,positionnow,area,position,summary,posttime)");
            sb.Append(" values (@name,@mobile,@email,@school,@education,@workyear,@companynow,@positionnow,@area,@position,@summary,@posttime)");
            SqlParameter[] para = {
                new SqlParameter("@name",resume.Name),
                new SqlParameter("@mobile",resume.Mobile),
                new SqlParameter("@email",resume.Email),
                new SqlParameter("@school",resume.School),
                new SqlParameter("@education",resume.Education),
                new SqlParameter("@workyear",resume.WorkYear),
                new SqlParameter("@companynow",resume.CompanyNow),
                new SqlParameter("@positionnow",resume.PositionNow),
                new SqlParameter("@area",resume.Area),
                new SqlParameter("@position",resume.Position),
                new SqlParameter("@summary",resume.Summary),
                new SqlParameter("@posttime",resume.PostTime)
            };
            int n = MsSQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, para);
            if (n == 1)
                return true;
            return false;
        }
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}