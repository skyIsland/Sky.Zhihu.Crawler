using Sky.ZhiHu.Crawler.Events;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace Sky.ZhiHu.Crawler
{
    public class Helper
    {
        /// <summary>
        /// 获取网页源代码
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="cookies">cookie</param>
        /// <param name="getOrPost">请求方式</param>
        /// <param name="postData">post数据</param>
        /// <param name="proxy">代理Ip</param>
        /// <param name="port">代理端口</param>
        /// <returns></returns>
        public  ActionResults GetPageSource(string url, string cookies, bool isPost, string postData = null, string proxy=null,int port=0)
        {
            var msg=new ActionResults();
            string pageSource=string.Empty;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                //请求标头
                request.Accept = "*/*";
                //加快载入速度
                request.ServicePoint.Expect100Continue = false;
                //禁止Nagle算法加快载入速度
                request.ServicePoint.UseNagleAlgorithm = false;
                //写入Cookie
                request.Headers.Add(HttpRequestHeader.Cookie, cookies);
                //定义Gzip压缩页面支持
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip/deflate");
                //定义文档类型及编码
                request.ContentType = "application/x-www-form-urlencoded";
                //禁止自动跳转
                request.AllowAutoRedirect = false;
                //设置User-Agent，伪装成Google Chrome浏览器
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
                //定义请求超时时间为5秒
                request.Timeout = 5000;
                //启用长连接
                request.KeepAlive = true;
                //定义请求方式为GET
                request.Method = isPost? "POST" : "GET";

                //设置代理服务器IP，伪装请求地址
                if (proxy != null) request.Proxy = port == 0 ? new WebProxy(proxy) : new WebProxy(proxy,port);                    
                //定义最大连接数
                request.ServicePoint.ConnectionLimit = int.MaxValue;
                //附加Cookie容器
                //request.CookieContainer = this.CookiesContainer;
                if (isPost)
                {
                    if (postData != null)
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(postData);
                        request.ContentLength = buffer.Length;
                        request.GetRequestStream().Write(buffer, 0, buffer.Length);
                    }
                }

                //获取响应
              
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    //将Cookie加入容器，保存登录状态
                    //foreach (Cookie cookie in response.Cookies) this.CookiesContainer.Add(cookie);
                    //解压
                    if (response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                pageSource = reader.ReadToEnd();
                            }
                        }
                    }
                    //解压
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))
                    {
                        using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                pageSource = reader.ReadToEnd();
                            }
                        }
                    }
                    //原始
                    else
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                        {
                            pageSource = reader.ReadToEnd();
                        }
                    }
                    //停止请求
                    request.Abort();
                    //watch.Stop();
                    //var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;//获取当前任务线程ID
                    //var milliseconds = watch.ElapsedMilliseconds;//获取请求执行时间
                    //this.OnCompleted?.Invoke(this, new OnCompletedEventArgs(url, threadId, milliseconds, pageSource));
                }
               
            }
            catch (Exception ex)
            {
                msg.Result = false;
                msg.Msg = ex.Message;
                return msg;
            }
            msg.Result = true;
            msg.Data = pageSource;          
            return msg;
        }
        public class ActionResults
        {
            public bool Result { get; set; }
            public string Data { get; set; }
            public string Msg { get; set; }

            public ActionResults() { }
            public ActionResults(bool result, string data,string msg)
            {
                this.Result = result;
                this.Data = data;
                this.Msg = msg;
            }
        }
    }
}
