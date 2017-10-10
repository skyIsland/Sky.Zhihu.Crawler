using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Zhihu.NewCrawler
{
    /// <summary>
    /// 下载配置参数
    /// </summary>
    public class DownParameter
    {
        /// <summary>
        /// cookie
        /// </summary>
        public string Cookie { get; set; } =
            "2|1:0|10:1507397674|4:z_c0|92:Mi4xb0JRNkF3QUFBQUFBZ01KMlRnMS1EQ2NBQUFDRUFsVk5LcDBBV2dDQkdlNUhua1JBWnRNc1hlSVg4b3JzRDQwZTln|f5cb8010983f51b0f843076cbe3fb4ac9d32e95a25fb2524dbd41b9c8fe9d715;";

        /// <summary>
        /// 问题ID
        /// </summary>
        public int QuestionId { get; set; } = 37709992;

        /// <summary>
        /// 保存路径
        /// </summary>
        public string SaveSrc { get; set; } = "E:\\Study\\知乎爬虫\\";

        /// <summary>
        /// 每个文件夹多少张图片
        /// </summary>
        public int SaveCount { get; set; } = 500;

        /// <summary>
        /// 问题题目
        /// </summary>
        public string QuestionTitle { get; set; } = "长得好看，但没有男朋友是怎样的体验？";
    }
}
