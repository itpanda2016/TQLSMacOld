using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.QYH {
    public enum MediaType {
        /// <summary>
        /// 图文
        /// </summary>
        mpnews = 0,
        /// <summary>
        /// image
        /// </summary>
        image = 1,
        /// <summary>
        /// 音频
        /// </summary>
        voice,
        /// <summary>
        /// 视频
        /// </summary>
        video,
        /// <summary>
        /// 文件
        /// </summary>
        file
    }
    /// <summary>
    /// 获取当前管理组的素材总数以及每种类型素材的数目。
    /// </summary>
    public class MaterialCount {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        /// <summary>
        /// 应用素材总数目
        /// </summary>
        public int total_count { get; set; }
        /// <summary>
        /// 图片素材总数目
        /// </summary>
        public int image_count { get; set; }
        /// <summary>
        /// 图片素材总数目
        /// </summary>
        public int voice_count { get; set; }
        /// <summary>
        /// 视频素材总数目
        /// </summary>
        public int video_count { get; set; }
        /// <summary>
        /// 文件素材总数目
        /// </summary>
        public int file_count { get; set; }
        /// <summary>
        /// 图文素材总数目
        /// </summary>
        public int mpnews_count { get; set; }
    }

    /// <summary>
    /// 获取当前管理组指定类型的素材列表。
    /// </summary>
    public class MaterialGetSetting {
        /// <summary>
        /// 素材类型，可以为图文(mpnews)、图片（image）、音频（voice）、视频（video）、文件（file）
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 从该类型素材的该偏移位置开始返回，0表示从第一个素材 返回
        /// </summary>
        public int offset { get; set; }
        /// <summary>
        /// 返回素材的数量，取值在1到50之间
        /// </summary>
        public int count { get; set; }
    }
    /// <summary>
    /// 若为图片，文件，视频，音频则返回json格式如下
    /// </summary>
    public class MaterialListPermanent {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string type { get; set; }
        public FileItemList[] itemlist { get; set; }
    }
    public class FileItemList {
        public string media_id { get; set; }
        public string filename { get; set; }
        public int update_time { get; set; }
    }
    /// <summary>
    /// 图文素材列表
    /// </summary>
    public class MPNews {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string type { get; set; }
        public MPNewsItemlist[] itemlist { get; set; }
    }

    public class MPNewsItemlist {
        public string media_id { get; set; }
        public MPNewsContent content { get; set; }
        public int update_time { get; set; }
    }

    public class MPNewsContent {
        public MPNewsArticle[] articles { get; set; }
    }

    public class MPNewsArticle {
        public string thumb_media_id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string digest { get; set; }
        public string content_source_url { get; set; }
        public int show_cover_pic { get; set; }
    }

}
