using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BirthdayLunarWeb.Admin {
    public partial class RuleAct : System.Web.UI.Page {
        public Model.Rule rule = new Model.Rule();
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["act"] == null) {
                Response.Write("Access Denied.");
                return;
            }
            string act = Request["act"].ToString();
            if (act == "add" || act == "edit") {
                rule.MsgType = Request["msgtyle"];
                rule.RuleName = Request["rulename"];
                rule.Rank = Int32.Parse(Request["rank"]);
                rule.MsgValue = Request["msgvalue"];
                rule.RuleValue = Request["rulevalue"];
                rule.VideoTitle = Request["videotitle"] != null ? Request["videotitle"] : "";
                rule.VideoDescription = Request["videodescription"] != null ? Request["videodescription"] : "";
                rule.IdTime = DateTime.Now;
                if (act == "add") {
                    Response.Write(rule.ToString());
                    if (Bll.Rule.CheckRule(rule)) {
                        Message.Dialog("规则已存在。");
                    }
                    else {
                        if (Bll.Rule.Add(rule))
                            Message.Dialog("添加规则成功。", "Main.aspx");
                        else
                            Message.Dialog("添加失败。");
                    }
                }
                else if (act == "edit") {
                    rule.ID = Convert.ToInt32(Request["id"]);

                    if (Bll.Rule.Update(rule))
                        Message.Dialog("规则更新成功：" + rule.ID,"Main.aspx");
                    else {
                        Message.Dialog("更新失败。");
                    }
                }
            }
            else if (act == "delete") {
                int id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                if (id == 0) {
                    Response.Write("无效的ID");
                }
                else {
                    if (Bll.Rule.Delete(id)) {
                        Message.Dialog("删除成功。" + id,"Main.aspx");
                    }
                    else {
                        Message.Dialog("删除失败。");
                    }
                }
            }
        }
    }
}