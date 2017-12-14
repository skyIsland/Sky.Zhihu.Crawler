using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.ZhiHuImage.Crawler.Helper
{
    public static class Util
    {
        public static string GetFileMd5(string fileName)
        {
            var stream = new FileInfo(fileName).OpenRead();
            var buffer = new Byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(buffer);
            var sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 去掉文件名中的无效字符,如 \ / : * ? " < > | 
        /// </summary>
        /// <param name="filename">待处理的文件名</param>
        /// <returns>处理后的文件名</returns>
        public static string ReplaceBadCharOfFilename(string filename)
        {
            string str = filename;
            str = str.Replace("\\", string.Empty);
            str = str.Replace("/", string.Empty);
            str = str.Replace(":", string.Empty);
            str = str.Replace("*", string.Empty);
            str = str.Replace("?", string.Empty);
            str = str.Replace("\"", string.Empty);
            str = str.Replace("<", string.Empty);
            str = str.Replace(">", string.Empty);
            str = str.Replace("|", string.Empty);
            str = str.Replace(" ", string.Empty);    //前面的替换会产生空格,最后将其一并替换掉
            return str;
        }
    }
}
