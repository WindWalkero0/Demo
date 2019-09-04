using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HttpPostDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CookieContainer cookie = new CookieContainer();
            MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes("0120");
            string pwd =  BitConverter.ToString(cryptoServiceProvider.ComputeHash(bytes)).Replace("-", "");
            string postDataStr = string.Format(@"<Request ID='' Function='GetWorkOrderGNList' LoginName='{0}' Password='{1}' RequestTime='' Client=''><UpdateTime>{2}</UpdateTime></Request>",
                           "0120", pwd, Convert.ToDateTime("2018-11-13 14:05:24").AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://172.16.0.104:81/DataService.aspx");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            Console.WriteLine(retString);
            Console.ReadKey();
        }
    }
}
