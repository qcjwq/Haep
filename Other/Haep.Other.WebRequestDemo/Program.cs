using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Haep.Other.WebRequestDemo
{
    class Program
    {
        const string sUserAgent =
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36";
        const string sContentType =
            "application/x-www-form-urlencoded";

        static void Main(string[] args)
        {
            Console.WriteLine(PostDataToUrl("test", "http://www.baidu.com"));

            Console.ReadKey();
        }

        private static string PostDataToUrl(string data, string url)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] bytesToPost = encoding.GetBytes(data);
            return PostDataToUrl(bytesToPost, url);
        }

        private static string PostDataToUrl(byte[] data, string url)
        {
            // 创建HttpWebRequest对象
            WebRequest webRequest = WebRequest.Create(url);
            HttpWebRequest httpRequest = webRequest as HttpWebRequest;
            if (httpRequest == null)
            {
                throw new ApplicationException($"Invalid url string:{url}");
            }

            //填充HttpWebRequest的基本对象
            httpRequest.UserAgent = sUserAgent;
            httpRequest.ContentType = sContentType;
            httpRequest.Method = "POST";

            //填充要POST的内容
            httpRequest.ContentLength = data.Length;
            Stream requestStream = httpRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            //发送POST请求到服务器
            Stream responseStream = null;
            string responseStr = String.Empty;
            try
            {
                responseStream = httpRequest.GetResponse().GetResponseStream();
                if (responseStream != null)
                {
                    using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"POST操作发生异常{e.Message}");
                throw;
            }
            finally
            {
                responseStream?.Close();
            }

            return responseStr;
        }
    }
}
