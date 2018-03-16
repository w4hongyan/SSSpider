using Newtonsoft.Json;
using SSSpider.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            string url ="https://en.ishadowx.net/";
            string html = HttpHelper.DownLoadString(url);
            GetAll(html);
            Console.ReadKey();
        }
        private static void GetAll(string html)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            string[] ipnames = new string[] { "usa", "usb", "usc", "jpa", "jpb", "jpc", "sga", "sgb", "sgc" };
            SSConfig config = new SSConfig();
            List<ConfigsItem> configsItems = new List<ConfigsItem>();
            foreach(var ipname in ipnames)
            {
                var ipnode = htmlDoc.DocumentNode.SelectSingleNode("//span[@id='ip"+ ipname + "']");
                var portnode = htmlDoc.DocumentNode.SelectSingleNode("//span[@id='port" + ipname + "']");
                var pwnode = htmlDoc.DocumentNode.SelectSingleNode("//span[@id='pw" + ipname + "']");
                string ip = ipnode.InnerText.Trim();
                string port = portnode.InnerText.Trim();
                string pw = pwnode.InnerText.Trim();
                ConfigsItem item = new ConfigsItem();
                item.server = ip;
                item.server_port = int.Parse(port);
                item.password = pw;
                configsItems.Add(item);
            }
            config.configs = configsItems;
            string json= JsonConvert.SerializeObject(config);
            string newjson = ConvertJsonString(json);
            File.WriteAllText("F:\\Download\\ss-3.4.3\\gui-config.json", newjson);
        }
        private static string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 1,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
    }
}
