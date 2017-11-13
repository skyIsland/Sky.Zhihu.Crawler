namespace Sky.ZhiHuImage.Crawler.Models
{
    /// <summary>
    /// 结果信息类
    /// </summary>
    public class ResultInfo
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public bool Result { get; set; } = false;
        /// <summary>
        /// 返回数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
    }
}
