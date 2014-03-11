using System;

namespace WeiBoAnalyser.WeiBoAPI
{
    public class Topic
    {
        public enum TopicType
        {
            /// <summary>
            /// 原创发表
            /// </summary>
            Original = 1,
            /// <summary>
            /// 转载
            /// </summary>
            Reprint,
            /// <summary>
            /// 私信
            /// </summary>
            PrivateMessage,
            /// <summary>
            /// 回复
            /// </summary>
            Reply,
            /// <summary>
            /// 空回
            /// </summary>
            Empty,
            /// <summary>
            /// 提及
            /// </summary>
            Mention,
            /// <summary>
            /// 评论
            /// </summary>
            Comment
        };

        public enum TopicStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 0,
            /// <summary>
            /// 系统删除
            /// </summary>
            DelBySystem,
            /// <summary>
            /// 审核中
            /// </summary>
            Audit,
            /// <summary>
            /// 用户删除
            /// </summary>
            DelByUser,
            /// <summary>
            /// 根删除（根节点被系统审核删除）
            /// </summary>
            DelByAudit
        };

        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// 微博内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 原始内容
        /// </summary>
        public string OrigText { get; set; }

        /// <summary>
        /// 微博被转次数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 点评次数
        /// </summary>
        public int MCount { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 来源url
        /// </summary>
        public string FromUrl { get; set; }

        /// <summary>
        /// 微博唯一id
        /// </summary>
        public string WeiBoId { get; set; }

        /// <summary>
        ///  图片url列表
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 发表人帐户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户唯一id
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 发表人昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 是否自已发的的微博
        /// </summary>
        public bool IsSelf { get; set; }

        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        ///  微博类型
        /// </summary>
        public TopicType TopicType { get; set; }

        /// <summary>
        /// 发表者头像url
        /// </summary>
        public string Head { get; set; }

        /// <summary>
        /// 发表者所在地
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 国家码
        /// </summary>
        public int Country { get; set; }

        /// <summary>
        /// 省份码
        /// </summary>
        public int Province { get; set; }

        /// <summary>
        /// 城市码
        /// </summary>
        public int City { get; set; }

        /// <summary>
        /// 是否微博认证用户
        /// </summary>
        public bool IsVip { get; set; }

        /// <summary>
        /// 发表者地理信息
        /// </summary>
        public string Geo { get; set; }

        /// <summary>
        /// 微博状态
        /// </summary>
        public TopicStatus TopicStatus { get; set; }

        /// <summary>
        ///  心情图片url
        /// </summary>
        public string EmotionUrl { get; set; }

        /// <summary>
        /// 心情类型
        /// </summary>
        public int EmotionType { get; set; }

        /// <summary>
        /// 当type=2时，source即为源tweet
        /// </summary>
        public string Source { get; set; }
    }
}
