using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bambi5_Launcher
{
    public partial class Index_Form : Form
    {
        public Index_Form()
        {
            indexf = this;
            InitializeComponent();
        }
        public static Index_Form indexf;
        public ServersItem_List server;
        public Proxy_Mgr pm = new Proxy_Mgr();
        public bool cg = true;
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
                  }
                  else
                  {
                      Turn_button.Enabled = false;
                      Turn_button.Text = "没有启动游戏";
                  }
                  Turn_Proxy_button.Enabled = false;
                  Turn_Proxy_button.Text = "正在启动";
                  Print_log("正在配置代理···");
                  Debug.Print(server.host);
                  pm.Run_Fiddler(Main_Form.form.lc.config.ProxyPort).Wait();
                  Connected = true;
                  Print_log("正在检查连接是否正常···");
            if (!Check_Server())
                  {
                      DialogResult dialog = MessageBox.Show("此服务器的Dispatch似乎无法正常连接或代理配置出现问题,建议尝试检查连接，或联系服务器管理员检查服务器状态\n点击“终止”：取消此连接\n点击“重试”：再次检查连接状态\n点击“忽略”：继续连接到此服务器", "服务器连接异常", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
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
                  }
                  Print_log("检查完成！");
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
                 Turn_Proxy_button.Enabled = false;
                 Turn_Proxy_button.Text = "正在关闭";
                 Print_log("正在关闭游戏···");
                 if (Change_game && Game_Process != null && !Game_Process.HasExited)
                 {
                     Game_Process.Kill();
                 }
                 Print_log("正在关闭代理···");
                 pm.Stop().Wait();
                 Turn_button.Enabled = true;
                 Turn_button.Text = "开启代理并打开游戏";
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
        public void Update_Status()
        {
            Task.Run(() =>
            {
                Index_Get ig = Classes.Get_for_Index(Get_url("/status/server"));
                if (ig.Use_time >= 0)
                {
                    if (ig.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Def_status.Root df = JsonConvert.DeserializeObject<Def_status.Root>(ig.Result);
                        Server_status_toolStripStatusLabel.Text = "当前服务器有" + df.status.playerCount + "人在线,请求用时:" + ig.Use_time+"ms";
                        Server_status_toolStripStatusLabel.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        this.Server_status_toolStripStatusLabel.ForeColor = System.Drawing.Color.Red;
                        Server_status_toolStripStatusLabel.Text = "获取服务器状态失败(" + ig.StatusCode.ToString() + ")";
                        return;
                    }
                }
                else
                {
                    this.Server_status_toolStripStatusLabel.ForeColor = System.Drawing.Color.Red;
                    Server_status_toolStripStatusLabel.Text = "获取服务器状态失败(" +ig.Result+")" ;
                    return;
                }
            });
        }
        public bool Check_Server()
        {
            try
            {
                string res = Classes.Get("https://account.mihoyo.com/status/server");
                if (res == null)
                {
                    return false;
                }
                Def_status.Root df = JsonConvert.DeserializeObject<Def_status.Root>(res);
                return true;
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
                else if (dialog == DialogResult.No||dialog == DialogResult.OK)
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
        }
    }
}
