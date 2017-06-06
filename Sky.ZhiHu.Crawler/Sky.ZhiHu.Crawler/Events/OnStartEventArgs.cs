using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.ZhiHu.Crawler.Events
{
    /// <summary>
    /// 爬虫启动事件
    /// </summary>
    public class OnStartEventArgs
    {
        /// <summary>
        /// 爬虫Url地址
        /// </summary>
        public Uri Uri { get; set; }
        /// <summary>
        /// /问题ID
        /// </summary>
        public int QuestionId { get; set; }

        public OnStartEventArgs(Uri uri,int questionId)
        {
            this.Uri = uri;
            this.QuestionId = questionId;
        }
    }
}
