using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSpider
{
    public class ConfigsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string server { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int server_port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string method { get; set; } = "aes-256-cfb";
        /// <summary>
        /// 
        /// </summary>
        public string remarks { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public bool auth { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public int timeout { get; set; } = 5;
    }

    public class LogViewer
    {
        /// <summary>
        /// 
        /// </summary>
        public bool topMost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool wrapText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool toolbarShown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Font { get; set; } = "Consolas, 8pt";
        /// <summary>
        /// 
        /// </summary>
        public string BackgroundColor { get; set; } = "Black";
        /// <summary>
        /// 
        /// </summary>
        public string TextColor { get; set; } = "White";
    }

    public class Proxy
    {
        /// <summary>
        /// 
        /// </summary>
        public bool useProxy { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public int proxyType { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public string proxyServer { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public int proxyPort { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public int proxyTimeout { get; set; } = 3;
    }

    public class Hotkey
    {
        /// <summary>
        /// 
        /// </summary>
        public string SwitchSystemProxy { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string SwitchSystemProxyMode { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string SwitchAllowLan { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ShowLogs { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ServerMoveUp { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ServerMoveDown { get; set; } = "";
    }

    public class SSConfig
    {
        public SSConfig()
        {
            logViewer = new LogViewer();
            proxy = new Proxy();
            hotkey = new Hotkey();
        }
        /// <summary>
        /// 
        /// </summary>
        public List<ConfigsItem> configs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string strategy { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        public bool global { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool enabled { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public bool shareOverLan { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool isDefault { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public int localPort { get; set; } = 1080;
        /// <summary>
        /// 
        /// </summary>
        public string pacUrl { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        public bool useOnlinePac { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool secureLocalPac { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public bool availabilityStatistics { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool autoCheckUpdate { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public bool checkPreRelease { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool isVerboseLogging { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public LogViewer logViewer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Proxy proxy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Hotkey hotkey { get; set; }
    }
}
