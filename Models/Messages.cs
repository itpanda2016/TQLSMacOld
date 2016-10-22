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
    /// 构造直接发送图文素材消息模板
    /// </summary>
    public class MPNewsSend {
        public string touser { get; set; }
        public string toparty { get; set; }
        public string totag { get; set; }
        public string msgtype { get; set; }
        public int agentid { get; set; }
        public Media_ID mpnews { get; set; }
        public int safe { get; set; }
    }
    /// <summary>
    /// 直接发送图文素材模板子类1
    /// </summary>
    public class Media_ID {
        public Article[] articles { get; set; }
    }
    /// <summary>
    /// 直接发送图文素材模板子类2
    /// </summary>
    public class Article {
        public string title { get; set; }
        public string thumb_media_id { get; set; }
        public string author { get; set; }
        public string content_source_url { get; set; }
        public string content { get; set; }
        public string digest { get; set; }
        public string show_cover_pic { get; set; }
    }
    /// <summary>
    /// 发送时使用永久图文素材ID
    /// </summary>
    public class MPNewsSendByMediaID {
        public MPNewsSendByMediaID(int agentID = 0) {
            this.msgtype = "mpnews";
            this.agentid = agentID;
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
        public string totag { set; get; }
        /// <summary>
        /// 【是】消息类型，此时固定为：mpnews （不支持主页型应用）
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 【是】企业应用的id，整型。可在应用的设置页面查看
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 【是】素材资源标识ID，通过上传永久图文素材接口获得。注：必须是在该agent下创建的。
        /// </summary>
        public MPNewsMediaID mpnews { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        public int safe { get; set; }
    }
    /// <summary>
    /// 素材资源标识ID，通过上传永久图文素材接口获得。注：必须是在该agent下创建的。
    /// </summary>
    public class MPNewsMediaID {
        /// <summary>
        /// 素材资源标识ID，通过上传永久图文素材接口获得。注：必须是在该agent下创建的。
        /// </summary>
        public string media_id { get; set; }
    }

}
