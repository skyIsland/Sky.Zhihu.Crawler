using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.ZhiHu.Crawler.Events
{
    /// <summary>
    /// 爬虫完成事件
    /// </summary>
    public class OnCompletedEventArgs
    {
        /// <summary>
        /// 爬虫Url地址
        /// </summary>
        public Uri Uri { get; private set; }

        public int ThreadId { get; private set; }
        public string PagerSource { get; private set; }
        public long MilliSeconds { get; private set; }

        public OnCompletedEventArgs(Uri uri, int threadId, long milliSeconds, string pageSource)
        {
            this.Uri = uri;
            this.ThreadId = threadId;
            this.PagerSource = pageSource;
            this.MilliSeconds = milliSeconds;
        }
    }
}
