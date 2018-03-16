using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SSSpider.Common
{
    public class HttpHelper
    {
        /// <summary>
        /// 下载字符资源
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>字符资源</returns>
        public static string DownLoadString(string url)
        {
            string Source = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.108 Safari/537.36";
                request.Headers.Add("Cookie", "_ga=GA1.2.1364143128.1521161747; _gid=GA1.2.236784789.1521161747");
                request.Headers.Add("Upgrade-Insecure-Requests", "1");
                request.Headers.Add("Cache-Control", "no-cach");
                request.Headers.Add("authorization", "Bearer 2|1:0|10:1514875229|4:z_c0|80:MS4xOHNFTEFBQUFBQUFtQUFBQVlBSlZUVjEzT0ZzS01aeFB1d3ZqSnNPQ2wwNkh0Qm03SlgxdDRBPT0=|c3193706cc93e19352a16d9723d2ac1f99ef036bd7e4f91ffd243c3ae73bc166");
                request.Headers.Add("X-UDID", "APAgjxGx7wyPTrJoOrJtP_rJuwpaEz9yWH4=");
                request.Accept = "application/json, text/plain, */*";
                request.Method = "GET";
                request.Host = "en.ishadowx.net";
                request.KeepAlive = true;//启用长连接
                // request.Proxy = proxy;
                request.ProtocolVersion = HttpVersion.Version10;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    using (Stream dataStream = response.GetResponseStream())
                    {

                        if (response.ContentEncoding.ToLower().Contains("gzip"))//解压
                        {
                            using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    Source = reader.ReadToEnd();
                                }
                            }
                        }
                        else if (response.ContentEncoding.ToLower().Contains("deflate"))//解压
                        {
                            using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    Source = reader.ReadToEnd();
                                }

                            }
                        }
                        else
                        {
                            using (Stream stream = response.GetResponseStream())//原始
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {

                                    Source = reader.ReadToEnd();
                                }
                            }
                        }

                    }
                }
                request.Abort();

            }
            catch (Exception ex)
            {
                Console.WriteLine("出错了，请求的URL为{0}", url);

            }
            return Source;
        }
    }
}
