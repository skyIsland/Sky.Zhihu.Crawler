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
            "z_c0=Mi4xb0JRNkF3QUFBQUFBa0FLSmJiVWhDeGNBQUFCaEFsVk55NF8yV2dEWjdWMkVhWEpZYk9fRkJ6RnBQTlk2a1FxN3Nn|1510556107|357a8067a96f9da7d9562e67a3d4f05051f50ece";

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

        ///// <summary>
        ///// 问题题目
        ///// </summary>
        //public string QuestionTitle { get; set; } = "长得好看，但没有男朋友是怎样的体验？";
    }
}
