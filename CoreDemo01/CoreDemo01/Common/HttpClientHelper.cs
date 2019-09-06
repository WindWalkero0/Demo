using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoreDemo01.Common
{
    /// <summary>
    /// HttpClient的帮助类
    /// </summary>
    public class HttpClientHelper
    {
        //提取默认的Http Heads UserAgen Author
        private static readonly string userAgen = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36";

        /// <summary>
        /// 根据Url地址Get请求返回数据
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="httpStatusCode">http状态码</param>
        /// <returns>返回字符串</returns>
        public static string GetResponse(string url, out string httpStatusCode)
        {
            httpStatusCode = string.Empty;
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = System.Net.DecompressionMethods.GZip });
            HttpResponseMessage response = null;
            try
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", userAgen);
                httpClient.CancelPendingRequests();
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> taskResponse = httpClient.GetAsync(url);
                taskResponse.Wait();
                response = taskResponse.Result;

                if(response.IsSuccessStatusCode)
                {
                    Task<System.IO.Stream> taskStream = response.Content.ReadAsStreamAsync();
                    taskStream.Wait();
                    //此处会抛出异常，不支持超时设置，对返回结果没有影响
                    System.IO.Stream dataStream = taskStream.Result;
                    System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
                    string result = reader.ReadToEnd();

                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                if(response != null)
                {
                    response.Dispose();
                }
                if(httpClient != null)
                {
                    httpClient.Dispose();
                }
            }
        }

        /// <summary>
        /// 根据Url地址Get请求返回数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResponse(string url)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = System.Net.DecompressionMethods.GZip});
            HttpResponseMessage response = null;
            try
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", userAgen);

                httpClient.CancelPendingRequests();
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> taskResponse = httpClient.GetAsync(url);
                taskResponse.Wait();
                response = taskResponse.Result;

                if(response.IsSuccessStatusCode)
                {
                    Task<Stream> taskStream = response.Content.ReadAsStreamAsync();
                    taskStream.Wait();
                    Stream dataStream = taskStream.Result;
                    StreamReader reader = new StreamReader(dataStream);
                    string result = reader.ReadToEnd();
                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                if(response != null)
                {
                    response.Dispose();
                }
                if(httpClient != null)
                {
                    httpClient.Dispose();
                }
            }
        }

        /// <summary>
        /// 根据Url地址Get请求返回实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetResponse<T>(string url)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = System.Net.DecompressionMethods.GZip});
            HttpResponseMessage response = null;
            try
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", userAgen);
                httpClient.CancelPendingRequests();
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> taskResponse = httpClient.GetAsync(url);
                taskResponse.Wait();
                T result = default(T);
                response = taskResponse.Result;

                if(response.IsSuccessStatusCode)
                {
                    Task<Stream> taskStream = response.Content.ReadAsStreamAsync();
                    taskStream.Wait();
                    Stream dataStream = taskStream.Result;
                    StreamReader reader = new StreamReader(dataStream);
                    string s = reader.ReadToEnd();

                    result = JsonConvert.DeserializeObject<T>(s);
                }
                return result;
            }
            catch(Exception e)
            {
                var resp = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(e.ToString()),
                    ReasonPhrase = "error"
                };
                return default(T);
            }
            finally
            {
                if(response != null)
                {
                    response.Dispose();
                }
                if(httpClient != null)
                {
                    httpClient.Dispose();
                }
            }
        }

        /// <summary>
        /// Post请求返回字符
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string PostResponse(string url, string postData)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = System.Net.DecompressionMethods.GZip });
            HttpResponseMessage response = null;
            try
            {
                httpClient.MaxResponseContentBufferSize = 256000;
                httpClient.DefaultRequestHeaders.Add("user-agent", userAgen);
                httpClient.CancelPendingRequests();
                httpClient.DefaultRequestHeaders.Clear();
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                Task<HttpResponseMessage> taskResponse = httpClient.PostAsync(url, httpContent);
                taskResponse.Wait();
                response = taskResponse.Result;
                if(response.IsSuccessStatusCode)
                {
                    Task<Stream> taskStream = response.Content.ReadAsStreamAsync();
                    taskStream.Wait();
                    Stream dataStream = taskStream.Result;
                    StreamReader reader = new StreamReader(dataStream);
                    string result = reader.ReadToEnd();
                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                if(response != null)
                {
                    response.Dispose();
                }
                if(httpClient != null)
                {
                    httpClient.Dispose();
                }
            }
        }

        public static T PostResponse<T>(string url, object obj)
        {

        }
    }
}
