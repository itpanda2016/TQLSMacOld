using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 发送消息模板库
///     --可继续抽象成泛型类
/// </summary>
namespace Model.QYH {
    /// <summary>
    /// 消息发送后状态回传
    /// </summary>
    public class MessageReturn {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string invaliduser { get; set; }
        public string invalidparty { get; set; }
        public string invalidtag { get; set; }
    }

    /// <summary>
    /// 构造发送视频消息
    /// </summary>
    public class MessageVideo {
        public MessageVideo(int agentId = 0) {
            this.msgtype = "video";
            this.agentid = agentId;
        }
        /// <summary>
        /// 成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
        /// </summary>
        public string toparty { get; set; }
        /// <summary>
        /// 标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
        /// </summary>
        public string totag { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：video （不支持主页型应用）
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 企业应用的id，整型。可在应用的设置页面查看
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 语音文件id，可以调用上传临时素材或者永久素材接口获取
        /// </summary>
        public MessageVideoChild video { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        public int safe { get; set; }
    }
    /// <summary>
    /// 视频消息子实例
    /// </summary>
    public class MessageVideoChild {
        /// <summary>
        /// 视频媒体文件id，可以调用上传临时素材或者永久素材接口获取
        /// </summary>
        public string media_id { get; set; }
        /// <summary>
        /// 视频消息的标题，不超过128个字节，超过会自动截断
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 视频消息的描述，不超过512个字节，超过会自动截断
        /// </summary>
        public string description { get; set; }
    }

    /// <summary>
    /// 构造发送文本消息模板
    /// </summary>
    public class MessageText {
        public MessageText() {
            this.msgtype = "text";
        }
        /// <summary>
        /// 成员ID列表
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 部门ID列表
        /// </summary>
        public string toparty { get; set; }
        /// <summary>
        /// 标签ID列表
        /// </summary>
        public string totag { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：text 
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 企业应用的id，整型。可在应用的设置页面查看
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public MessageTextChild text { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        public int safe { get; set; }
    }
    /// <summary>
    /// 构造发送文本消息模板子类
    /// </summary>
    public class MessageTextChild {
        /// <summary>
        /// 消息内容，最长不超过2048个字节，注意：主页型应用推送的文本消息在微信端最多只显示20个字（包含中英文）
        /// </summary>
        public string content { get; set; }
    }

    /// <summary>
    /// 图片消息模板
    /// </summary>
    public class MessageImage {
        public MessageImage() {
            this.msgtype = "image";
        }
        public string touser { get; set; }
        public string toparty { get; set; }
        public string totag { get; set; }
        public string msgtype { get; set; }
        public int agentid { get; set; }
        public MessageImageChild image { get; set; }
        public int safe { get; set; }
    }
    /// <summary>
    /// 图片消息模板子类
    /// </summary>
    public class MessageImageChild {
        public string media_id { get; set; }
    }

    /// <summary>
    /// 图文素材模板
    /// </summary>
    public class MessageMPNews {
        public MessageMPNews() {
            this.type = "mpnews";
        }
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string type { get; set; }
        /// <summary>
        /// 	返回该类型素材列表
        /// </summary>
        public MPNewsItem[] itemlist { get; set; }
    }
    /// <summary>
    /// 图文素材的列表（有多少图文素材）
    /// </summary>
    public class MPNewsItem {
        /// <summary>
        /// 图文素材的媒体id
        /// </summary>
        public string media_id { get; set; }
        public MPContent content { get; set; }
        public int update_time { get; set; }
    }
    /// <summary>
    /// 每个图文素材的具体内容
    /// </summary>
    public class MPContent {
        /// <summary>
        /// 图文消息，一个图文消息支持1到10个图文
        /// </summary>
        public MPArticle[] articles { get; set; }
    }
    /// <summary>
    /// 图文的内容实体
    /// </summary>
    public class MPArticle {
        /// <summary>
        /// 图文消息缩略图的media_id, 可以在上传多媒体文件接口中获得。此处thumb_media_id即上传接口返回的media_id
        /// </summary>
        public string thumb_media_id { get; set; }
        /// <summary>
        /// 	图文消息的标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 图文消息的作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 图文消息的描述
        /// </summary>
        public string digest { get; set; }
        /// <summary>
        /// 图文消息点击“阅读原文”之后的页面链接
        /// </summary>
        public string content_source_url { get; set; }
        /// <summary>
        /// 是否显示封面，1为显示，0为不显示
        /// </summary>
        public int show_cover_pic { get; set; }
    }
}
