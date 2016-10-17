using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.QYH;
using Newtonsoft.Json;
using Common;

namespace BLL.QYH {
    /// <summary>
    /// 企业号基础类，包括获取token/回调模式判断等功能
    /// </summary>
    public class Require {
        /// <summary>
        /// 正常情况下AccessToken有效期为7200秒，有效期内重复获取返回相同结果。
        /// access_token至少保留512字节的存储空间。
        /// </summary>
        /// <param name="corpId">企业Id</param>
        /// <param name="corpSecret">管理组的凭证密钥</param>
        /// <returns></returns>
        public static Auths.Access_Token GetAccessToken(string corpId,string corpSecret,ref Auths.Error err) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}",
                        corpId, corpSecret);
            string ret = Utility.CurlByDotNet(url, CurlMethod.GET);
            if(ret.IndexOf("errcode") >= 0) {
                err = JsonConvert.DeserializeObject<Auths.Error>(ret);
                return null;
            }
            return JsonConvert.DeserializeObject<Auths.Access_Token>(ret);
        }
    }
}
