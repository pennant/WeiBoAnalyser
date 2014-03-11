using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoAnalyser.WeiBoAPI
{
    public class StatusesAPI
    {
        private AccountDetail m_accountDetail;

        public StatusesAPI(AccountDetail accountDetail)
        {
            m_accountDetail = accountDetail;
        }

        /// <summary>
        /// 获取某话题的最新微博
        /// </summary>
        /// <param name="reqNum">每次请求记录的条数（1-100条）</param>
        /// <param name="tweetId">微博帖子ID（详细用法见pageflag）</param>
        /// <param name="time">微博帖子生成时间（详细用法见pageflag）</param>
        /// <param name="pageFlag">
        /// 翻页标识(第一次务必填零)
        /// pageflag=1表示向下翻页：tweetid和time是上一页的最后一个帖子ID和时间； 
        /// pageflag=2表示向上翻页：tweetid和time是下一页的第一个帖子ID和时间；
        /// </param>
        /// <param name="flag">是否拉取认证用户，用作筛选。0-拉取所有用户，0x01-拉取认证用户</param>
        /// <param name="type">1-原创发表，2-转载</param>
        /// <param name="contentType">
        /// 正文类型（按位使用）。1-带文本(这一位一定有)，2-带链接，4-带图片，8-带视频，0x10-带音频
        /// 建议不使用contenttype为1的类型，如果要拉取只有文本的微博，建议使用0x80
        /// 
        /// </param>
        public void Ht_TimeLine_Ext(int reqNum, int tweetId, int time,
            int pageFlag, int flag, int type, int contentType)
        {

        }
    }
}
