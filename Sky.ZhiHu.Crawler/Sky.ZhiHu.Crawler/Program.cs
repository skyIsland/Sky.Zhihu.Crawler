using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Ivony.Html;
using Ivony.Html.Parser;
using Newtonsoft.Json;
using System.Net;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Sky.ZhiHu.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
           // Console.Title = "线程数：" + Process.GetCurrentProcess().Threads.Count;
            #region 数据结构
            int questionId = 20902967;
            try
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("请输入要抓取的问题ID：");
                questionId = int.Parse(Console.ReadLine()??questionId.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var questionTitle = string.Empty;
            List<string> urls = new List<string>();
            #endregion
            #region 抓取问题答案中的图片链接 do while 发生解析错误，无法解决
            //var crawlerHelper = new Helper();
            //Stopwatch review = new Stopwatch();
            //review.Start();
            //Console.WriteLine("===============================================");
            //Console.WriteLine("开始分析，问题ID：" + questionId);
            //bool flag;
            //int index = 1;
            //var url = @"https://www.zhihu.com/api/v4/questions/" + questionId + "/answers?sort_by=default&include=data%5B%2A%5D.is_normal%2Cis_sticky%2Ccollapsed_by%2Csuggest_edit%2Ccomment_count%2Ccan_comment%2Ccontent%2Ceditable_content%2Cvoteup_count%2Creshipment_settings%2Ccomment_permission%2Cmark_infos%2Ccreated_time%2Cupdated_time%2Crelationship.is_authorized%2Cis_author%2Cvoting%2Cis_thanked%2Cis_nothelp%2Cupvoted_followees%3Bdata%5B%2A%5D.author.badge%5B%3F%28type%3Dbest_answerer%29%5D.topics&limit=20&offset=0";
            //try
            //{
            //    do
            //    {
            //        Console.WriteLine("*当前分析第" + index + "页");
            //        var res = crawlerHelper.GetPageSource(url, "z_c0=Mi4wQUZBQ3RaSUlvd3NBRUFMdXJCcEtDeGNBQUFCaEFsVk5vVllnV1FBeGhtYWFMb0pwZEF2N2ZpNjkzUTJ3SzJlNjZ3|1493608438|262c46a8c7e0b82f0ba1aba5567a95bf1d0530b8;", 1);
            //        if (!res.Result) throw new Exception(res.Data);
            //        var test = JsonConvert.DeserializeObject<Page.Rootobject>(res.Data);
            //        questionTitle = test.data[0].question.title;
            //        foreach (var item in test.data)
            //        {
            //            var document = new JumonyParser().Parse(item.content);
            //            var imgs = document.Find("img");
            //            foreach (var img in imgs)
            //            {
            //                //获取到下载链接
            //                var src = img.Attribute("data-original").Value();
            //                //判断下载链接是否已经存在
            //                if (!urls.Contains(src))
            //                {
            //                    urls.Add(src);
            //                }
            //            }
            //        }
            //        //更新循环标志
            //        flag = test.paging.is_end;
            //        //更新索引
            //        index++;
            //        //更新下载链接
            //        url = test.paging.next;
            //    } while (!flag);               
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("发生错误,原因："+e.Message);
            //}       
            //Console.WriteLine("===============================================");
            //Console.WriteLine("结束分析，问题ID:"+questionId+",共抓取到" + urls.Count + "个图片链接！共耗时：" + review.Elapsed);

            #endregion
            #region 抓取问题答案中的图片链接  for循环一万次第一页链接
            var crawlerHelper = new Helper();
            Stopwatch review = new Stopwatch();
            review.Start();
            Console.WriteLine("===============================================");
            Console.WriteLine("开始分析，问题ID：" + questionId);
            try
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine("*当前分析第" + (i + 1) + "页");
                    var res = crawlerHelper.GetPageSource(@"https://www.zhihu.com/api/v4/questions/" + questionId + "/answers?sort_by=default&include=data%5B%2A%5D.is_normal%2Cis_sticky%2Ccollapsed_by%2Csuggest_edit%2Ccomment_count%2Ccan_comment%2Ccontent%2Ceditable_content%2Cvoteup_count%2Creshipment_settings%2Ccomment_permission%2Cmark_infos%2Ccreated_time%2Cupdated_time%2Crelationship.is_authorized%2Cis_author%2Cvoting%2Cis_thanked%2Cis_nothelp%2Cupvoted_followees%3Bdata%5B%2A%5D.author.badge%5B%3F%28type%3Dbest_answerer%29%5D.topics&limit=20&offset=" + i * 20, "z_c0=2|1:0|10:1507397674|4:z_c0|92:Mi4xb0JRNkF3QUFBQUFBZ01KMlRnMS1EQ2NBQUFDRUFsVk5LcDBBV2dDQkdlNUhua1JBWnRNc1hlSVg4b3JzRDQwZTln|f5cb8010983f51b0f843076cbe3fb4ac9d32e95a25fb2524dbd41b9c8fe9d715;", false);
                    if (!res.Result) throw new Exception(res.Msg);
                    var test = JsonConvert.DeserializeObject<Page.Rootobject>(res.Data);
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
                tasks[i] = Task.Factory.StartNew(() => { DownLoadImgByUrl(questionTitle, data); });            
            }
            #endregion
            Task.WaitAll(tasks);         
            sw.Stop();
            Console.WriteLine("===============================================");
            Console.WriteLine("全部下载图片完成,问题题目：" + questionTitle + "\n共成功下载图片数量：" + (DownloadImage.DownLoadCount-DownloadImage.ErrorCount) + "\n共失败下载图片数量："+DownloadImage.ErrorCount+"\n耗时:" + sw.Elapsed);
            #endregion

          
          //  Console.ForegroundColor=ConsoleColor.Green;
            Console.ReadKey();
        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="questionTitle">知乎问题题目</param>
        /// <param name="urls">下载队列</param>
        private static void DownLoadImgByUrl(string questionTitle, List<string> urls)
        {
                    
            #region 开始下载图片   
            foreach (var item in urls)
            {
                #region 500张图片一个文件夹 判断文件夹图片数量和判断下载成功次数都无法保证文件夹刚好存放500张图片 原因：线程 暂时无法解决
                int flag = (DownloadImage.DownLoadCount-DownloadImage.ErrorCount) / 500 + 1;
                var direction = "E:\\Study\\知乎爬虫\\" + questionTitle.Replace("/", "").Replace("\\", "") + "\\" + flag;
                //var baseFileName = "E:\\Study\\知乎爬虫\\" + questionTitle.Replace("/", "").Replace("\\", "");//问题文件夹
                //var direction = string.Empty;
                //if (!Directory.Exists(baseFileName)) Directory.CreateDirectory(baseFileName);
                //var files = Directory.GetDirectories(baseFileName);//问题下的所有子文件夹
                //if (files.Length == 0)//还没有创建子文件夹
                //{
                //    direction = baseFileName +"\\"+ 1;
                //}
                //else if (files.Length > 0)//已经创建子文件夹
                //{
                //    //最后一个子文件夹的图片
                //    var imgFiles = Directory.GetFiles(baseFileName +"\\"+ files.Length);
                //    if (imgFiles.Length <= 500)//最后一个文件夹
                //    {
                //        direction = baseFileName + "\\" + files.Length;                           
                //    }
                //    else//图片数量大于500，则新建子文件夹
                //    {
                //        direction = baseFileName + "\\" + (files.Length + 1);
                //    }
                //}
                #endregion
                if (item != "//zhstatic.zhihu.com/assets/zhihu/ztext/whitedot.jpg") DownloadImage.DownLoadMain(item, direction);
                //Console.WriteLine("第{0}张图片下载成功!图片地址:{1}", DownloadImage.DownLoadCount, item);               
            }          
            #endregion

        }      
    }
}
