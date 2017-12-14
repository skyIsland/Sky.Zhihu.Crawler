namespace Sky.ZhiHuImage.Crawler.Models
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
            "z_c0=2|1:0|10:1512834448|4:z_c0|92:Mi4xb0JRNkF3QUFBQUFBTUVLaEJCSFBEQ2NBQUFDRUFsVk5rSkpUV2dERU1Jd3BpSmdpWDJrU3FDdm1vT3diUDJwMjZ3|3ae3f5258016b017137e3e4e5fe2a2c7b1a649c06f644f1f096acc05ef574f71";

        /// <summary>
        /// 问题ID
        /// </summary>
        public int QuestionId { get; set; } = 46508954;

        /// <summary>
        /// 保存路径
        /// </summary>
        public string SaveSrc { get; set; } = "E:\\Study\\知乎爬虫";

        /// <summary>
        /// 每个文件夹多少张图片
        /// </summary>
        public int SaveCount { get; set; } = 500;

        ///// <summary>
        ///// 问题题目
        ///// </summary>
        //public string QuestionTitle { get; set; } = "长得好看，但没有男朋友是怎样的体验？";
    }
}
