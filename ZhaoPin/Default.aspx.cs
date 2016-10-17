using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FROST.Utility;

namespace ZhaoPin {
    public partial class Index : System.Web.UI.Page {
        public string act;
        /// <summary>
        /// 职位
        /// </summary>
        public string[] position = {
            "饲料事业部 - 销售总经理/经理",
            "饲料事业部 - 销售/项目经理",
            "饲料事业部 - 攻坚队员/项目成员",
            "饲料事业部 - 驻场场长/驻场技术专员",
            "饲料事业部 - 市场经理/市场专员",
            "饲料事业部 - 技术服务经理/服务专员",
            "饲料事业部 - 饲料厂厂长",
            "饲料事业部 - 内务副总经理",
            "饲料事业部 - 财务经理",
            "饲料事业部 - 行政/人事经理",
            "饲料事业部 - 招聘经理",
            "饲料事业部 - 培训经理",
            "饲料事业部 - 技术经理/配方研发师",
            "饲料事业部 - 水产研发配方师",
            "饲料事业部 - 生产经理",
            "饲料事业部 - 品控经理",
            "饲料事业部 - 储备生产经理",
            "饲料事业部 - 储备品控经理",
            "饲料事业部 - 阡检员/原料保管",
            "饲料事业部 - 检测中心主任/化验员",
            "饲料事业部 - 主办会计/会计主管",
            "饲料事业部 - 后备财务经理",
            "食品事业部 - 兽医师",
            "食品事业部 - 蛋鸡养殖场长",
            "食品事业部 - 种鸡孵化场长",
            "食品事业部 - 禽病技术服务经理/专员",
            "食品事业部 - 蛋鸡养殖技术员",
            "食品事业部 - 孵化技术员",
            "食品事业部 - 种鸡销售经理/代表",
            "食品事业部 - 市场推广专员",
            "食品事业部 - 冷鲜肉促销员",
            "牧业事业部 - 猪场养殖场长",
            "牧业事业部 - 猪事业部市场经理",
            "牧业事业部 - 种猪销售代表",
            "牧业事业部 - 种猪销售代表",
            "校园招聘 - 营销储备干部",
            "校园招聘 - 养殖场储备干部",
            "校园招聘 - 后备养殖场长",
            "校园招聘 - 后备技术配方师",
            "校园招聘 - 后备品控经理",
            "校园招聘 - 后备生产经理",
            "校园招聘 - 后备财务经理"
        };
        protected void Page_Load(object sender, EventArgs e) {
            
        }
    }

    /// <summary>
    /// 数据库实体对象
    /// </summary>
    public class Resume {
        public int ID { set; get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { set; get; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { set; get; }
        /// <summary>
        /// 毕业学校
        /// </summary>
        public string School { set; get; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education { set; get; }
        /// <summary>
        /// 工作年限
        /// </summary>
        public string WorkYear { set; get; }
        /// <summary>
        /// 当前就职公司
        /// </summary>
        public string CompanyNow { set; get; }
        /// <summary>
        /// 当前职位
        /// </summary>
        public string PositionNow { set; get; }
        /// <summary>
        /// 应聘区域
        /// </summary>
        public string Area { set; get; }
        /// <summary>
        /// 应聘职位
        /// </summary>
        public string Position { set; get; }
        /// <summary>
        /// 自我简介
        /// </summary>
        public string Summary { set; get; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime PostTime { set; get; }
    }
}