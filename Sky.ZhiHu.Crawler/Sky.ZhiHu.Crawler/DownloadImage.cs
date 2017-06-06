using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sky.ZhiHu.Crawler
{
    public class DownloadImage
    {
        /// <summary>
        /// 下载成功次数
        /// </summary>
        public static int DownLoadCount { get; set; }
        /// <summary>
        /// 下载失败次数
        /// </summary>
        public static int ErrorCount { get; set; }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url">下载链接</param>
        /// <param name="filePath">存储路径</param>
        public static void DownLoadMain(string url, string filePath)
        {
            if (string.IsNullOrEmpty(url))
            {
                return;
            }
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            string fileName = Path.Combine(filePath, Path.GetFileName(url));
            DownLoadCount++;
            try
            {
                //var pro = Getproxy();
                //var rnd=new Random().Next(pro.Count);
                //var ip = pro[rnd].Split(':')[0];
                //var port = int.Parse(pro[rnd].Split(':')[1]);
                var request = (HttpWebRequest)WebRequest.Create(url);
                //request.Proxy=new WebProxy(ip,port);
                request.Timeout = 5000;               
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())

                        using (Stream fsStream = new FileStream(fileName, FileMode.Create))
                        {
                            stream.CopyTo(fsStream);
                            //DownLoadCount++;//下载成功次数++
                            Console.WriteLine("第{0}张图片下载成功!图片地址:{1}", DownLoadCount, url);
                        }
                    }
                    //停止请求
                    request.Abort();
                }
            }
            catch (Exception ex)
            {
                ErrorCount++;
                Console.WriteLine("第{0}张图片下载失败!图片地址:{1}", DownLoadCount, url+"原因："+ex.Message);
            }
        }

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <returns></returns>
        private static List<string> Getproxy()
        {
            var result = new List<string>();
            var wc = new WebClient();
            var res = wc.DownloadString("http://api.xicidaili.com/free2016.txt").Split(Environment.NewLine.ToCharArray());
            foreach (var item in res)
            {
                if (string.IsNullOrWhiteSpace(item)) continue;
                result.Add(item);
            }

            #region 检测代理

            foreach (var item in result)
            {
                var ip = item.Split(':')[0];
                var port = Convert.ToInt32(item.Split(':')[1]);
                var helper = new Helper();
                var getRes = helper.GetPageSource("http://www.whatismyip.com.tw", null, false, null, ip, port);
                if (!getRes.Result)
                {
                    result.Remove(item);
                }
            }
            #endregion
            return result;
        }
        //免费代理http://api.xicidaili.com/free2016.txt
    }
}
