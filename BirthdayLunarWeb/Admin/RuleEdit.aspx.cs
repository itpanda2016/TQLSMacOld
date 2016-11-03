using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using qyhModel = Model.QYH;
using qyhBLL = BLL.QYH;
using System.Configuration;
using Newtonsoft.Json;

namespace BirthdayLunarWeb.Admin {
    public partial class RuleEdit : System.Web.UI.Page {
        public string act = "";
        public Model.Rule rule = new Model.Rule();
        public int rankFW = 10;
        public qyhModel.MaterialGetSetting mgs = new qyhModel.MaterialGetSetting();
        public qyhModel.MaterialListPermanent mList = new qyhModel.MaterialListPermanent();
        public qyhModel.Auths.Error err = new qyhModel.Auths.Error();
        public qyhModel.TagList tagList = new qyhModel.TagList();
        public qyhModel.MaterialCount mCount = new qyhModel.MaterialCount();
        public qyhModel.MPNews mpnewsList = new qyhModel.MPNews();
        public Dictionary<string, object> item = new Dictionary<string, object>();
        
        protected void Page_Load(object sender, EventArgs e) {
            mgs.type = "video";
            mgs.offset = 0;
            mgs.count = 50;
            string corpId = ConfigurationManager.AppSettings["qyhCorpId"];
            string secret = ConfigurationManager.AppSettings["qyhSecret"];
            
            qyhModel.Auths.Access_Token qyh = qyhBLL.Require.GetAccessToken(corpId,secret,ref err);
            if(err.errcode == 0) {
                string mcRet = qyhBLL.Material.GetMaterialCount(qyh.access_token);
                mCount = JsonConvert.DeserializeObject<qyhModel.MaterialCount>(mcRet);
                //获取视频
                string strRet = qyhBLL.Material.GetMaterialListPermanent(qyh.access_token, mgs);
                mList = JsonConvert.DeserializeObject<qyhModel.MaterialListPermanent>(strRet);
                item.Add("video", mList);
                //获取图文
                mgs.type = "mpnews";
                string mpnewsRet = qyhBLL.Material.GetMaterialListPermanent(qyh.access_token,mgs);
                mpnewsList = JsonConvert.DeserializeObject<qyhModel.MPNews>(mpnewsRet);
                item.Add("mpnews", mpnewsList);

                strRet = qyhBLL.Tag.GetTagList(qyh.access_token);
                tagList = JsonConvert.DeserializeObject<qyhModel.TagList>(strRet);
            }

            if (Request["act"] == null) {
                act = "add";
                return;
            }
            act = Request["act"];
            if (act == "edit") {
                if (Request["id"] == null) {
                    act = "add";
                    return;
                }
                else {
                    int id = Convert.ToInt32(Request["id"]);
                    rule = Bll.Rule.GetRuleById(id);
                }
            }
        }
    }
}