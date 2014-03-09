using System;

namespace WeiBoAnalyser.WeiBoAPI
{
    public class Person
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public DateTime Birthday { get; set; }

        public int Experience { get; set; }

        /// <summary>
        /// 国家编号
        /// </summary>
        public int Country { get; set; }

        /// <summary>
        /// 省编号
        /// </summary>
        public int Province { get; set; }

        /// <summary>
        /// 市编号
        /// </summary>
        public int City { get; set; }

        /// <summary>
        /// 听众人数
        /// </summary>
        public int FansNum { get; set; }

        /// <summary>
        /// 收藏人数
        /// </summary>
        public int FavNum { get; set; }

        /// <summary>
        /// 收听人数
        /// </summary>
        public int IdolNum { get; set; }

        /// <summary>
        /// 行业编号
        /// </summary>
        public int Industry { get; set; }

        /// <summary>
        /// 个人介绍
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 是否企业机构
        /// </summary>
        public bool IsEnt { get; set; }

        /// <summary>
        /// 是否在当前用户的黑名单中
        /// </summary>
        public bool IsMyBlack { get; set; }

        /// <summary>
        /// 是否是当前用户的听众
        /// </summary>
        public bool IsMyFans { get; set; }

        /// <summary>
        /// 是否是当前用户的偶像
        /// </summary>
        public bool IsMyIdol { get; set; }

        /// <summary>
        /// 是否实名认证
        /// </summary>
        public bool IsRealName { get; set; }

        /// <summary>
        /// 是否认证用户
        /// </summary>
        public bool IsVip { get; set; }

        /// <summary>
        /// 互听好友数
        /// </summary>
        public int MutualFansNum { get; set; }

        /// <summary>
        /// 用户唯一编号
        /// </summary>
        //[SQLite.PrimaryKey]
        public string OpenId { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegTime { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 用户等级
        /// </summary>
        public int Level { get; set; }
    }
}
