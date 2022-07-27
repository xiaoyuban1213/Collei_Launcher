using Fiddler;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collei_Launcher
{
    public partial class Index_Form : Form
    {
        public Index_Form()
        {
            Main_Form.form.Status_timer.Enabled = false;
            indexf = this;
            pm = new Proxy_Mgr(this);
            InitializeComponent();
            if (no_gamepath())
            {
                Turn_button.Enabled = false;
                Turn_button.Text = "未设置游戏路径";
            }
        }
        public static Index_Form indexf;
        public ServersItem_List server;
        public Proxy_Mgr pm;
        public bool cg = true;

        public void On_BeforeRequest(Session oS)
        {
            if (oS.host.EndsWith(".yuanshen.com") || oS.host.EndsWith(".hoyoverse.com") || oS.host.EndsWith(".mihoyo.com"))
            {
                string ohost = oS.host + ":" + oS.port;
                oS.host = Index_Form.indexf.server.host;
                if (oS.port == 443 || oS.port == 80)
                {
                    oS.port = Index_Form.indexf.server.dispatch;
                }
                Index_Form.indexf.Print_log(ohost + " -> " + oS.host);
            }
            if (oS.port == 22102)
            {
                oS.port = Index_Form.indexf.server.game;
            }
        }
        public bool no_gamepath()
        {
            return Main_Form.form.lc.config.Game_Path == null || Main_Form.form.lc.config.Game_Path == "";
        }
        private void Private_Open_Index(ServersItem_List ser)
        {
            server = ser;
            this.Text = ser.title;
            Title_textBox.Text = ser.title;
            Host_textBox.Text = ser.host;
            Dispatch_port_numericUpDown.Value = ser.dispatch;
            Game_port_numericUpDown.Value = ser.game;
            Content_textBox.Text = ser.content;
            Update_Status();
            this.ShowDialog();
        }
        public static void Open_Index(ServersItem_List ser)
        {
            Index_Form index = new Index_Form();
            index.Private_Open_Index(ser);
            index.Dispose();
        }
        private void Turn_button_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                Set_Proxy(true);
            }
            else
            {
                Stop_Proxy(true);
            }
        }
        public void Print_log(string log)
        {
            Log_richTextBox.AppendText(log + "\n");
            Log_richTextBox.Focus();
            Log_richTextBox.Select(Log_richTextBox.TextLength, 0);
            Log_richTextBox.ScrollToCaret();
        }
        public Task Set_Proxy(bool Change_game)
        {
            return Task.Run(() =>
              {

              Start:
                  cg = Change_game;

                  if (Change_game)
                  {
                      Turn_button.Enabled = false;
                      Turn_button.Text = "正在连接";
                      if (no_gamepath())
                      {
                          Turn_button.Enabled = false;
                          Turn_button.Text = "未设置游戏路径";
                      }
                  }
                  else
                  {
                      Turn_button.Enabled = false;
                      Turn_button.Text = "没有启动游戏";
                      if (no_gamepath())
                      {
                          Turn_button.Enabled = false;
                          Turn_button.Text = "未设置游戏路径";
                      }
                  }
                  Turn_Proxy_button.Enabled = false;
                  Turn_Proxy_button.Text = "正在启动";
                  Print_log("正在配置代理···");
                  Main_Form.form.Clear_Proxy();
                  Debug.Print(server.host);
                  pm.Run_Fiddler().Wait();
                  Main_Form.form.Set_Proxy("127.0.0.1:" + Main_Form.form.lc.config.ProxyPort);
                  Connected = true;
                  Print_log("正在检查服务器是否正常···");
                  Thread.Sleep(1000);
                  if (!Check_Server())
                  {
                      Print_log("请求失败！");
                      DialogResult dialog = MessageBox.Show("此服务器的Dispatch似乎无法正常连接,建议尝试检查服务器，或联系服务器管理员检查服务器状态\n当前系统代理配置:" + Main_Form.form.Get_Proxy_Text() + "" + "\n点击“终止”：取消此连接\n点击“重试”：再次检查连接状态\n点击“忽略”：继续连接到此服务器", "服务器连接异常", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                      if (dialog == DialogResult.Abort)
                      {
                          Stop_Proxy(Change_game).Wait();
                          return;
                      }
                      else if (dialog == DialogResult.Retry)
                      {
                          Stop_Proxy(Change_game).Wait();
                          goto Start;
                      }
                      Print_log("已忽略异常。");
                  }
                  else
                  {
                      Print_log("OK！");
                  }
                  if (Change_game)
                  {
                      Print_log("正在启动游戏···");
                      Game_Process = Process.Start(Main_Form.form.lc.config.Game_Path);
                      Thread.Sleep(3000);
                  }
                  Print_log("已完成启动");
                  if (Change_game)
                  {
                      Turn_button.Enabled = true;
                      Turn_button.Text = "取消代理并关闭游戏";
                  }
                  Turn_Proxy_button.Enabled = true;
                  Turn_Proxy_button.Text = "仅关闭代理";
              });
        }

        public Task Stop_Proxy(bool Change_game)
        {
            return Task.Run(() =>
             {
                 Turn_button.Enabled = false;
                 Turn_button.Text = "正在关闭";
                 if (no_gamepath())
                 {
                     Turn_button.Enabled = false;
                     Turn_button.Text = "未设置游戏路径";
                 }
                 Turn_Proxy_button.Enabled = false;
                 Turn_Proxy_button.Text = "正在关闭";
                 if (Change_game && Game_Process != null && !Game_Process.HasExited)
                 {
                     Print_log("正在关闭游戏···");
                     Game_Process.Kill();
                 }
                 Print_log("正在关闭代理···");
                 pm.Stop().Wait();
                 Main_Form.form.Clear_Proxy();
                 Turn_button.Enabled = true;
                 Turn_button.Text = "开启代理并打开游戏";
                 if (no_gamepath())
                 {
                     Turn_button.Enabled = false;
                     Turn_button.Text = "未设置游戏路径";
                 }
                 Turn_Proxy_button.Enabled = true;
                 Turn_Proxy_button.Text = "仅启动代理";
                 Print_log("已关闭");
                 Connected = false;
             });
        }

        public Process Game_Process = null;
        public bool Connected = false;
        private void Server_Status_timer_Tick(object sender, EventArgs e)
        {
            Update_Status();
        }
        public string Get_url(string path)
        {
            string url = "https://" + server.host + ":" + server.dispatch + path;
            Debug.WriteLine(url);
            return url;
        }
        public bool Uping_Status = false;
        public void Update_Status()
        {
            if (Uping_Status)
            {
                return;
            }
            Task.Run(() =>
            {
                Uping_Status = true;
                string display = "";
                bool error = false;
                Index_Get ig = Classes.Get_for_Index(Get_url("/status/server"));
                if (ig.Use_time >= 0)
                {
                    if (ig.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Def_status.Root df = JsonConvert.DeserializeObject<Def_status.Root>(ig.Result);
                        display += "当前服务器有" + df.status.playerCount + "人在线";
                    }
                    else
                    {
                        display += "获取服务器状态失败(" + ig.StatusCode.ToString() + ")";
                        error = true;
                    }
                }
                else
                {
                    display += "获取服务器状态失败(" + ig.Result + ")";
                    error = true;
                }
                try
                {
                    Ping ping = new Ping();
                start:
                    PingReply pr = ping.Send(server.host, 1000);
                    if (pr.RoundtripTime == 0)
                    {
                        goto start;
                    }
                    display += ",Ping:" + pr.RoundtripTime + "ms";
                }
                catch (Exception ex)
                {
                    display += ",Ping失败:" + ex.Message;
                    error = true;
                }
                this.Server_status_toolStripStatusLabel.Text = display;
                if (error)
                {
                    Server_status_toolStripStatusLabel.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Server_status_toolStripStatusLabel.ForeColor = System.Drawing.Color.Black;
                }

                Uping_Status = false;
            });

        }
        public bool Check_Server()
        {
            try
            {
                Index_Get ig = Classes.Get_for_Index(Get_url("/status/server"));
                if (ig.Use_time >= 0)
                {
                    if (ig.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Def_status.Root df = JsonConvert.DeserializeObject<Def_status.Root>(ig.Result);
                        return true;
                    }
                    else
                    {

                        Print_log("请求失败(" + ig.StatusCode.ToString() + ")");
                        return false;
                    }
                }
                else
                {
                    Print_log("请求失败(" + ig.Result + ")");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void Index_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Connected)
            {
                DialogResult dialog;
                if (cg)
                {
                    dialog = MessageBox.Show("是否关闭代理和游戏?\n点击“是”：关闭代理,游戏和此窗口\n点击“否”：只关闭代理\n点击“取消”：取消关闭窗口", "确定关闭窗口?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                }
                else
                {
                    dialog = MessageBox.Show("是否关闭代理?\n点击“确定”：关闭代理和此窗口\n点击“取消”：取消关闭窗口", "确定关闭窗口?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                if (dialog == DialogResult.Yes)
                {
                    Stop_Proxy(true).Wait();
                }
                else if (dialog == DialogResult.No || dialog == DialogResult.OK)
                {
                    Stop_Proxy(false).Wait();
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void Turn_Proxy_button_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                Set_Proxy(false);
            }
            else
            {
                Stop_Proxy(false);
            }
        }

        private void Check_button_Click(object sender, EventArgs e)
        {
            Check_Form.Open_Form(server);
        }

        private void Index_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Server_Status_timer.Stop();
            Main_Form.form.Clear_Proxy();
            Main_Form.form.Status_timer.Enabled = true;
            Main_Form.form.Load_Server_Status();
        }
    }
}
