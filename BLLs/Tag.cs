using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace BLL.QYH {
    /// <summary>
    /// 企业号：标签接口
    /// </summary>
    public class Tag {
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static string GetTagList(string access_token) {
            string tUrl = string.Format("https://qyapi.weixin.qq.com/cgi-bin/tag/list?access_token={0}", access_token);
            return Utility.CurlByDotNet(tUrl, CurlMethod.GET);
        }
    }
}
