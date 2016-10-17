using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.QYH {
    public class Auths {
        /// <summary>
        /// 正常情况下AccessToken有效期为7200秒，有效期内重复获取返回相同结果。
        /// access_token至少保留512字节的存储空间。
        /// </summary>
        public class Access_Token {
            /// <summary>
            /// 获取到的凭证。长度为64至512个字节
            /// </summary>
            public string access_token { get; set; }
            /// <summary>
            /// 凭证的有效时间（秒）
            /// </summary>
            public int expires_in { get; set; }
        }

        /// <summary>
        /// 微信公众平台通用错误返回实体
        /// </summary>
        public class Error {
            /// <summary>
            /// 错误代码，大于0则获取失败
            /// </summary>
            public int errcode { get; set; }
            /// <summary>
            /// 错误消息
            /// </summary>
            public string errmsg { get; set; }
        }

    }
}
