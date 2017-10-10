using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Zhihu.NewCrawler
{
    /// <summary>
    /// 爬取类
    /// </summary>
    public class Spider
    {

        /// <summary>
        /// 整理图片链接
        /// </summary>
        /// <param name="questionTitle"></param>
        /// <param name="urls"></param>
        private  void ReviewUrls(string questionTitle, List<string> urls)
        {
            #region 开始下载图片
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(@"===============================================");
            Console.WriteLine("开始下载图片,问题题目:" + questionTitle + ",图片数量：" + urls.Count);
            int index = 1;
            foreach (var item in urls)
            {
                try
                {
                    #region 1000张图片一个文件夹

                    int flag = index / 1000 + 1;
                    var direction = "E:\\Study\\知乎爬虫\\" + questionTitle + "\\" + flag;

                    #endregion

                    if (item != "//zhstatic.zhihu.com/assets/zhihu/ztext/whitedot.jpg")
                        DownloadImage(item, direction);
                    Console.WriteLine("第{0}张图片下载成功!图片地址:{1}", index, item);
                    index++;
                }
                catch (Exception e)
                {
                    Console.WriteLine("发生错误：" + e.Message);
                }
            }
            sw.Stop();
            Console.WriteLine("===============================================");
            Console.WriteLine("图片下载完成,问题题目：" + questionTitle + ",共下载：" + index + "张图片,耗时:" + sw.Elapsed);

            #endregion
        }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filePath"></param>
        public async Task<ResultInfo> DownloadImage(string url, string filePath)
        {
            var result=new ResultInfo();
            var httpClient = new HttpClient();
            try
            {
                filePath = filePath.Replace("/", "").Replace("\\", "");
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                string fileName = Path.Combine(filePath, Path.GetFileName(url)??Guid.NewGuid().ToString());
                var response = await httpClient.GetStreamAsync(url);
                using (Stream stream = response)
                using (Stream fsStream = new FileStream(fileName, FileMode.Create))
                {
                    stream.CopyTo(fsStream);
                    result.Result = true;
                }
            }
            catch (Exception ex)
            {
                result.Message = "下载图片失败,原因:" + ex.Message;
            }
            return result;
        }
    }
}
