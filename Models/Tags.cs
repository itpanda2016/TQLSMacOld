using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.QYH {
    /// <summary>
    /// 标签列表
    /// </summary>
    public class TagList {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public TaglistChild[] taglist { get; set; }
    }
    /// <summary>
    /// 标签列表（子类）
    /// </summary>
    public class TaglistChild {
        public int tagid { get; set; }
        public string tagname { get; set; }
    }

    /// <summary>
    /// 获取标签成员
    /// </summary>
    public class TagUserList {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        /// <summary>
        /// 成员列表
        /// </summary>
        public ListChild[] userlist { get; set; }
        /// <summary>
        /// 部门列表
        /// </summary>
        public int[] partylist { get; set; }
    }

    /// <summary>
    /// TagUserList的子类
    /// </summary>
    public class ListChild {
        /// <summary>
        /// 	成员UserID
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 	成员姓名
        /// </summary>
        public string name { get; set; }
    }

}
