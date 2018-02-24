using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net; 
using System.Collections.Specialized;
using System.IO;
using Newtonsoft.Json;


namespace mobpush.api.client
{
    public class Commons
    {
        /**
        * HTTP_STATUS_400: HTTP响应码400
        */
        public static int HTTP_STATUS_400 = 400;

        /**
         * HTTP_STATUS_200: HTTP响应码200
         */
        public static int HTTP_STATUS_200 = 200;

        /// <summary>
        /// MD5加签
        /// </summary>
        /// <param name="decodeData"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static string GetMD5String(string decodeData, string appSecret)
        {
            string text = null;
            if (string.IsNullOrEmpty(decodeData))
            {
                text = appSecret;
            }
            else
            {
                text = decodeData + appSecret;
            }
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2")); 
            return sBuilder.ToString();
        }

        /// <summary>
        /// HTTP POST 请求封装，未知异常则responseCode = 400，消息错误码 = -1 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MobResult WebClientPost(string url, string json)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ApiException(HTTP_STATUS_400, -1, "appkey or appSecret is null,Please go to MobPushConfig to set them");
            }
            HttpWebResponse webRespon = null;
            StreamReader streamReader = null;
            try
            {
                string sign = GetMD5String(json, MobPushConfig.appSecret); 
                WebHeaderCollection header = new WebHeaderCollection();
                header.Add("key", MobPushConfig.appkey);
                header.Add("sign", sign); 
                byte[] data = Encoding.UTF8.GetBytes(json); 
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json; charset=UTF-8";
                httpWebRequest.ContentLength = data.Length;
                httpWebRequest.Headers = header;
                Stream newStream = httpWebRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close(); 
                try
                {
                    webRespon = (HttpWebResponse)httpWebRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    webRespon = (HttpWebResponse)ex.Response;
                }
                Stream webStream = webRespon.GetResponseStream();
                if (webStream == null)
                {
                    throw new ApiException(HTTP_STATUS_400, -1, "Network error");
                }
                int statsCode = (int)webRespon.StatusCode;

                streamReader = new StreamReader(webStream, Encoding.UTF8);
                string responseContent = streamReader.ReadToEnd();
                MobResult r = JsonExtension.FromJSON<MobResult>(responseContent);
                if (HTTP_STATUS_200 != statsCode)
                { // 如果http请求响应非200，则异常 
                    throw new ApiException(statsCode, r.status, r.error);
                }
                return r;

            }
            catch (ApiException apiEx)
            {
                throw apiEx;
            }
            catch (Exception ex)
            {
                throw new ApiException(HTTP_STATUS_400, -1, ex.Message);
            }
            finally
            {
                if (webRespon != null)
                    webRespon.Close();
                if (streamReader != null)
                    streamReader.Close();
            }
              
        }
        
       /// <summary>
       /// HTTP GET 请求封装，未知异常则responseCode = 400，消息错误码 = -1 
       /// </summary>
       /// <param name="url"></param>
       /// <returns></returns>
        public static MobResult WebClientGet(string url)
        {
            if (string.IsNullOrEmpty(url)) {
                throw new ApiException(HTTP_STATUS_400, -1, "appkey or appSecret is null,Please go to MobPushConfig to set them");
            }
            HttpWebResponse webRespon = null;
            StreamReader streamReader = null;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.AllowWriteStreamBuffering = false;
                httpWebRequest.Timeout = 15000;
                httpWebRequest.ServicePoint.Expect100Continue = false;

                httpWebRequest.Headers.Add("key", MobPushConfig.appkey);
                string sign = GetMD5String(null, MobPushConfig.appSecret);
                httpWebRequest.Headers.Add("sign", sign); 
                try
                {
                    webRespon = (HttpWebResponse)httpWebRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    webRespon = (HttpWebResponse)ex.Response;
                }
                Stream webStream = webRespon.GetResponseStream();
                if (webStream == null)
                {
                    throw new ApiException(HTTP_STATUS_400, -1, "Network error");
                }
                int statsCode = (int)webRespon.StatusCode;

                streamReader = new StreamReader(webStream, Encoding.UTF8);
                string responseContent = streamReader.ReadToEnd();
                MobResult r = JsonExtension.FromJSON<MobResult>(responseContent);
                if (HTTP_STATUS_200 != statsCode)
                { // 如果http请求响应非200，则异常 
                    throw new ApiException(statsCode, r.status, r.error);
                }
                return r;
            }
            catch (ApiException apiEx)
            {
                throw apiEx;
            }
            catch (Exception ex)
            {
                throw new ApiException(HTTP_STATUS_400, -1, ex.Message);
            }
            finally {
                if (webRespon != null)
                    webRespon.Close();
                if (streamReader != null)
                    streamReader.Close();
            }
         }
    }

    /// <summary>
    /// HTTP 错误消息体
    /// </summary>
    public class MobResult {

        public int status { get; set; }

        public string error { get; set; }

        public object res { get; set; }
    
    }

    /// <summary>
    /// JSON 处理工具
    /// </summary>
    public static class JsonExtension
    { 
        /// <summary>
        /// 把对象转换为JSON字符串 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJSON(this object o)
        {
            if (o == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(o);
        }  

       /// <summary>
        /// 把Json文本转为实体
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="input"></param>
       /// <returns></returns>
        public static T FromJSON<T>(this string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
         
        /// <summary>
        /// 解析JSON数组生成对象实体集合 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }
    }
     
     
}
