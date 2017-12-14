using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ivony.Fluent;
using Ivony.Html;
using Ivony.Html.Parser;
using Sky.ZhiHuImage.Crawler.Helper;
using Sky.ZhiHuImage.Crawler.Models;

namespace Sky.ZhiHuImage.Crawler
{
    class Program
    {
        public static DownParameter Setting;
        /// <summary>
        /// 下载成功次数
        /// </summary>
        public static int SuccessCount { get; set; }
        /// <summary>
        /// 下载失败次数
        /// </summary>
        public static int ErrorCount { get; set; }
        static void Main(string[] args)
        {
            #region 配置
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*********初始化配置参数********");
            Setting = GetSetting("Setting.json");
            int questionId = Setting.QuestionId;           
            var questionTitle = string.Empty;
            List<string> urls = new List<string>();
            #endregion            
            #region 抓取问题答案中的图片链接  for循环一万次第一页链接        
            Stopwatch review = new Stopwatch();
            review.Start();
            Console.WriteLine("===============================================");
            Console.WriteLine("开始分析，问题ID：" + questionId);
            try
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine("*当前分析第" + (i + 1) + "页");
                    var res = HttpHelper.GetPageSource(@"https://www.zhihu.com/api/v4/questions/" + questionId + "/answers?sort_by=default&include=data%5B%2A%5D.is_normal%2Cis_sticky%2Ccollapsed_by%2Csuggest_edit%2Ccomment_count%2Ccan_comment%2Ccontent%2Ceditable_content%2Cvoteup_count%2Creshipment_settings%2Ccomment_permission%2Cmark_infos%2Ccreated_time%2Cupdated_time%2Crelationship.is_authorized%2Cis_author%2Cvoting%2Cis_thanked%2Cis_nothelp%2Cupvoted_followees%3Bdata%5B%2A%5D.author.badge%5B%3F%28type%3Dbest_answerer%29%5D.topics&limit=20&offset=" + i * 20, Setting.Cookie);
                    if (!res.Result) throw new Exception(res.Message);
                    var test = JsonHelper.Decode<ZhiHuPager.Rootobject>(res.Data);
                    questionTitle = test.data[0].question.title;
                    foreach (var item in test.data)
                    {
                        var document = new JumonyParser().Parse(item.content);
                        var imgs = document.Find("img");
                        foreach (var img in imgs)
                        {
                            var src = img.Attribute("data-original").Value();
                            if (!urls.Contains(src))
                            {
                                urls.Add(src);
                            }
                        }
                    }
                    //判断当前页是否为最后一页
                    if (test.paging.is_end)
                    {
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("发生错误，原因：" + e.Message);
            }
            review.Stop();
            Console.WriteLine("===============================================");
            Console.WriteLine("结束分析，问题ID:" + questionId + ",共抓取到" + urls.Count + "个图片链接！共耗时：" + review.Elapsed);

            #endregion
            #region 下载图片
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("===============================================");
            Console.WriteLine("开始下载图片,问题题目:" + questionTitle + ",预计下载图片数量：" + urls.Count);
            #region 开线程下载图片 100个链接开一个线程
            var threadCount = urls.Count % 2 == 0 ? urls.Count / 100 : urls.Count / 100 + 1;
            Task[] tasks = new Task[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                var data = urls.Skip(i * 100).Take(100).ToList();
                tasks[i] = Task.Factory.StartNew(() => { DownloadImgHandler(questionTitle, data,Setting.SaveSrc); });
            }
            #endregion
            Task.WaitAll(tasks);
            sw.Stop();
            Console.WriteLine("===============================================");
            Console.WriteLine("全部下载图片完成,问题题目：" + questionTitle + "\n共成功下载图片数量：" + SuccessCount + "\n共失败下载图片数量：" + ErrorCount + "\n耗时:" + sw.Elapsed);
            #endregion
            Console.ReadKey();
        }

        /// <summary>
        /// 下载图片处理
        /// </summary>
        /// <param name="questionTitle">知乎问题题目</param>
        /// <param name="urls">下载队列</param>
        /// <param name="filePath">保存路径</param>
        private static void DownloadImgHandler(string questionTitle, List<string> urls,string filePath)
        {
            filePath += "\\" + Util.ReplaceBadCharOfFilename(questionTitle);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            #region 开始下载图片   
            foreach (var item in urls)
            {
                #region 500张图片一个文件夹

                try
                {
                    var dirImageCount = Directory.GetDirectories(filePath);
                    if (dirImageCount.Length == 0)//子文件夹个数为0 创建第一个文件夹
                    {
                        Directory.CreateDirectory(filePath + "\\1");
                        dirImageCount = Directory.GetDirectories(filePath);
                    }
                    //最后一个文件夹的图片数量
                    var imageCount = Directory.GetFiles(filePath + "\\" + dirImageCount.Length);
                    if (imageCount.Length >= 500)//大于等于500时新建文件夹
                    {
                        Directory.CreateDirectory(filePath + "\\" + (dirImageCount.Length + 1));
                    }
                    //重新获取一下子文件夹数量
                    dirImageCount = Directory.GetDirectories(filePath);
                    if (!item.Equals("//zhstatic.zhihu.com/assets/zhihu/ztext/whitedot.jpg"))
                    {
                        DownloadImage(item, filePath + "\\" + dirImageCount.Length);
                    }
                    SuccessCount++;
                    Console.WriteLine("第{0}张图片下载成功!图片地址:{1}", SuccessCount, item);
                }
                catch (Exception ex)
                {
                    ErrorCount++;
                    Console.WriteLine("第{0}张图片下载失败!图片地址:{1}", ErrorCount, item + "原因：" + ex.Message);
                }
              
                #endregion
            }
            #endregion

        }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filePath"></param>
        private static void DownloadImage(string url,string filePath)
        {
            if (!url.IsNullOrEmpty())
            {
              
                var wc = new WebClient();
                var fileName = Path.Combine(filePath, Path.GetFileName(url));
                wc.DownloadFile(url, fileName);
                #region 检测图片是否已存在
                var md5 = Util.GetFileMd5(fileName);
                var oldData = FilesInfo.FindByInfoId(md5);
                if (oldData.Count > 0)
                {
                    File.Delete(fileName);
                    //throw new Exception("文件已存在,图片路径:" + oldData.FirstOrDefault().FilePath);
                }
                #endregion
                var model = new FilesInfo();
                model.FilePath = filePath;
                model.InfoID = md5;
                model.Name = Path.GetFileName(url);
                model.CreateTime = DateTime.Now;
                model.Save();
            }
         
        }
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="filePath">配置文件路径</param>
        /// <returns></returns>
        private static DownParameter GetSetting(string filePath)
        {
            string result;
            if (!File.Exists(filePath))
            {
                Console.WriteLine("配置文件不存在,自动生成....");
                var fs=File.Create(filePath);
                fs.Close();
                var obj = new DownParameter();
                var jsonStr = JsonHelper.Encode(obj);
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(jsonStr);
                }
                Console.WriteLine("自动生成配置文件完成...");
            }
            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {
                result = sr.ReadToEnd();
            }
            return JsonHelper.Decode<DownParameter>(result);
        }
        
    }
}
