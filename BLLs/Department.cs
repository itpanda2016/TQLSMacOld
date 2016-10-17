using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace BLL.QYH {
    /// <summary>
    /// 企业号：部门接口
    /// </summary>
    class Department {
        /// <summary>
        /// 获取部门列表，需要企业号对应授权
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="dpId">父级部门ID，根部门为1</param>
        /// <returns></returns>
        public static string GetDepartmentList(string access_token, int dpId = 1) {
            string tDepartmentUrl = string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}&id={1}"
                , access_token, dpId);
            return Utility.CurlByDotNet(tDepartmentUrl, CurlMethod.GET);
        }
    }
}
