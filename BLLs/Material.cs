using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Newtonsoft.Json;
using Model.QYH;

namespace BLL.QYH {
    /// <summary>
    /// 企业号：素材管理接口
    /// 所有方法都应该加入 ref Err类的返回数据
    /// </summary>
    public class Material {
        /// <summary>
        /// 获取当前管理组指定类型的素材列表。（POST）
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="getCount"></param>
        /// <returns></returns>
        public static string GetMaterialListPermanent(string access_token, MaterialGetSetting getCount) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/material/batchget?access_token={0}",
                access_token);
            return Utility.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(getCount));
        }
        /// <summary>
        /// 获取当前管理组的素材总数以及每种类型素材的数目。
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static string GetMaterialCount(string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/material/get_count?access_token={0}",
                access_token);
            return Utility.CurlByDotNet(url, CurlMethod.GET);
        }
        /// <summary>
        /// 通过media_id获取上传的图文消息、图片、语音、文件、视频素材。
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="mediaId">素材ID：图文素材为JSON。其他类型素材，返回结果和普通的http下载相同</param>
        /// <returns></returns>
        public static string GetMaterialByMediaId(string access_token, string mediaId) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/material/get?access_token={0}&media_id={1}",
                access_token, mediaId);
            return Utility.CurlByDotNet(url, CurlMethod.GET);
        }
    }
}
