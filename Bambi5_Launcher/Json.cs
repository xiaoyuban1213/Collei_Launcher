using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Collei_Launcher
{
    public class Index_Get
    {
        public string Result { get; set; }
        public long Use_time { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public class Def_status
    {
        public class Status
        {
            /// <summary>
            /// 
            /// </summary>
            public int playerCount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string version { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int retcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Status status { get; set; }
        }

    }
    public class Cloud_Config
    {
       
        public class Config
        {
            /// <summary>
            /// 
            /// </summary>
            public string lastverstr { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int lastvercode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> blacklist { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Notice { get; set; }
        }
        public List<ServersItem> servers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Config config { get; set; }
    }
    public class ServersItem
    {
        /// <summary>
        /// 服务器
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string host { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dispatch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int game { get; set; }
        /// <summary>
        /// 无
        /// </summary>
        public string content { get; set; }
    }
    public class ServersItem_List
    {
        /// <summary>
        /// 服务器
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string host { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dispatch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int game { get; set; }
        /// <summary>
        /// 无
        /// </summary>
        public string content { get; set; }
        public bool is_cloud { get; set; }

    }
    public class Local_Config
    {
        public class Config
        {
            /// <summary>
            /// 
            /// </summary>
            public string Game_Path = Classes.GameRegReader.GetGameExePath();

            public ushort ProxyPort = 8520;

            public bool Auto_Close_Proxy = true;

            public bool Show_Public_Server = true;

            public int lastvercode;
        }
        public List<ServersItem> servers = new List<ServersItem>();
        /// <summary>
        /// 
        /// </summary>
        public Config config =new Config();
    }
    public class Proxy_Config
    {
        public bool ProxyEnable = false;
        public string ProxyServer { get; set; }
}
}
