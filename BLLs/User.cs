using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace BLL.QYH {
    /// <summary>
    /// 企业号：用户接口
    /// </summary>
    public class User {
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetUserId(string access_token, string code) {
            string tUserIdUrl = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}"
                , access_token, code);
            return Utility.CurlByDotNet(tUserIdUrl, CurlMethod.GET);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string GetUser(string access_token, string userid) {
            string tUserUrl = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}"
                , access_token, userid);
            return Utility.CurlByDotNet(tUserUrl, CurlMethod.GET);
        }
        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="departmentId">部门ID</param>
        /// <param name="fetchChild">是否递规子部门</param>
        /// <param name="status">状态：0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加,未填写则默认为4</param>
        /// <returns></returns>
        public static string GetUserList(string access_token, int departmentId, int fetchChild = 1, int status = 1) {
            string tUrl = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/list?access_token={0}&department_id={1}&fetch_child={2}&status={3}",
                access_token, departmentId, fetchChild, status);
            return Utility.CurlByDotNet(tUrl, CurlMethod.GET);
        }
        /// <summary>
        /// 获取标签ID的用户列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid">指定标签ID</param>
        /// <returns></returns>
        public static string GetUserListByTag(string access_token, int tagid) {
            string tUrl = string.Format("https://qyapi.weixin.qq.com/cgi-bin/tag/get?access_token={0}&tagid={1}",
                access_token, tagid);
            return Utility.CurlByDotNet(tUrl, CurlMethod.GET);
        }
    }
}
