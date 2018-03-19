using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WordSegment
{
    class Segment
    {
        /// <summary>
        /// 利用SCWS进行中文分词
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SegWords(string str)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                string s = string.Empty;
                System.Net.CookieContainer cookieContainer = new System.Net.CookieContainer();
                // 将提交的字符串数据转换成字节数组           
                byte[] postData = System.Text.Encoding.ASCII.GetBytes("data=" + System.Web.HttpUtility.UrlEncode(str) + "&respond=json&charset=utf8&ignore=yes&duality=no&traditional=no&multi=0");

                // 设置提交的相关参数
                System.Net.HttpWebRequest request = System.Net.WebRequest.Create("http://www.ftphp.com/scws/api.php") as System.Net.HttpWebRequest;
                request.Method = "POST";
                request.KeepAlive = false;
                request.ContentType = "application/x-www-form-urlencoded";
                request.CookieContainer = cookieContainer;
                request.ContentLength = postData.Length;

                // 提交请求数据
                System.IO.Stream outputStream = request.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();

                // 接收返回的页面
                System.Net.HttpWebResponse response = request.GetResponse() as System.Net.HttpWebResponse;
                System.IO.Stream responseStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                string val = reader.ReadToEnd();

                Newtonsoft.Json.Linq.JObject results = Newtonsoft.Json.Linq.JObject.Parse(val);
                foreach (var item in results["words"].Children())
                {
                    Newtonsoft.Json.Linq.JObject word = Newtonsoft.Json.Linq.JObject.Parse(item.ToString());
                    sb.Append(word["word"].ToString() + " ");
                }
            }
            catch
            {
            }

            return sb.ToString();
        }
    }
}
