using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WebAPI
{
    public static class WebApi<T> where T : new()
    {
        public static Response<T> Post(Object postData)
        {
            StringBuilder strResult = new StringBuilder();

            //创建HttpWebRequest请求
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("Localhost/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //根据接口的要求序列化请求参数
            String strParams = JsonConvert.SerializeObject(postData);
            UTF8Encoding encoding = new UTF8Encoding();
            request.ContentLength = encoding.GetByteCount(strParams);
            request.Credentials = CredentialCache.DefaultCredentials;

            try
            {
                //创建字节流
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(encoding.GetBytes(strParams), 0, encoding.GetByteCount(strParams));
                }
                //获取回传信息
                using (WebResponse response = request.GetResponse())
                {
                    Stream streamResult = response.GetResponseStream();
                    using (StreamReader reader = new StreamReader(streamResult))
                    {
                        strResult.Append(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
            }

            Response<T> result = new Response<T>();
            try
            {
                result = JsonConvert.DeserializeObject<Response<T>>(strResult.ToString());
            }
            catch (Exception ex)
            {
            }

            if (result == null)
            {
                result = new Response<T>();
            }

            if (result.body == null)
            {
                result.body = new T();
            }

            return result;
        }
    }
}