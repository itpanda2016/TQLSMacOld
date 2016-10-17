using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.QYH {

    public class QYHUserInfo {
        public string UserId { set; get; }
        public string Name { set; get; }
        public List<int> Department { set; get; }
        public string Position { set; get; }
        public string Mobile { set; get; }
        public string Gender { set; get; }
        public string Email { set; get; }
        public string WeixinId { set; get; }
        public string Avatar { set; get; }
        public string Status { set; get; }
        public attr extattr { set; get; }
    }
    /// <summary>
    /// User扩展类extattr
    /// </summary>
    public class attr {
        public List<attrsExt> attrs { set; get; }
    }
    /// <summary>
    /// User扩展类extattr属性结构
    /// </summary>
    public class attrsExt {
        public string Name { set; get; }
        public string Value { set; get; }
    }
    /// <summary>
    /// User批量类（详细信息）
    /// </summary>
    public class QYHUserListMore {
        public QYHUserListMore() {
            this.userlist = new List<QYHUserInfo>();
        }
        public int errcode { set; get; }
        public string errmsg { set; get; }
        public List<QYHUserInfo> userlist { set; get; }
    }
}
