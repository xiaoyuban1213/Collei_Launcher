using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bambi5_Launcher
{
    public partial class Check_Form : Form
    {
        public Check_Form()
        {
            InitializeComponent();
        }

        private void Game_Host_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Game_Host_textBox.Enabled = Game_Host_checkBox.Checked;
        }
        private void Private_Open_Form(ServersItem_List ser = null)
        {
            if (ser == null)
            {
                this.ShowDialog();
                return;
            }
            Host_textBox.Text = ser.host;
            Dispatch_port_numericUpDown.Value = ser.dispatch;
            Game_port_numericUpDown.Value = ser.game;
            this.ShowDialog();
        }
        public static void Open_Form(ServersItem_List ser = null)
        {
            Check_Form cf = new Check_Form();
            cf.Private_Open_Form(ser);
        }
        private void Check_button_Click(object sender, EventArgs e)
        {
            if (Host_textBox.Text == "")
            {
                MessageBox.Show("服务器地址没有填写！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Game_Host_checkBox.Checked)
            {
                Check_Server(Host_textBox.Text, (int)Dispatch_port_numericUpDown.Value, (int)Game_port_numericUpDown.Value, Game_Host_textBox.Text);
            }
            else
            {
                Check_Server(Host_textBox.Text, (int)Dispatch_port_numericUpDown.Value, (int)Game_port_numericUpDown.Value);
            }
        }
        public void Log_Print(string log)
        {
            Log_richTextBox.AppendText(log + "\n");
            Log_richTextBox.Focus();
            Log_richTextBox.Select(Log_richTextBox.TextLength, 0);
            Log_richTextBox.ScrollToCaret();
        }
        public string Get_url(string path)
        {
            string url = "https://" + Host_textBox.Text + ":" + Dispatch_port_numericUpDown.Value + path;
            Debug.WriteLine(url);
            return url;
        }
        public Task Check_Server(string host, int dispatch, int game, string gamehost = null)
        {
            return Task.Run(() =>
            {
                if (gamehost == null)
                {
                    gamehost = host;
                }
                Log_richTextBox.Text = "";
                Check_button.Enabled = false;
                Check_button.Text = "正在检查";
                Log_Print("本机代理配置:" + Main_Form.form.Get_Proxy_Text());
                Log_Print("正在尝试获取服务器信息···");
                Index_Get ig = Classes.Get_for_Index(Get_url("/status/server"));
                if (ig.Use_time >= 0)
                {
                    if (ig.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Def_status.Root df = JsonConvert.DeserializeObject<Def_status.Root>(ig.Result);
                        Log_Print("当前服务器有" + df.status.playerCount + "人在线,请求用时:" + ig.Use_time + "ms");
                    }
                    else
                    {
                        Log_Print("获取服务器状态失败(" + ig.StatusCode.ToString() + ")");
                    }
                }
                else
                {
                    Log_Print("获取服务器状态失败(" + ig.Result + ")");
                }
                bool TimeOut = true;
                var tk = Task.Run(() =>
                {
                    DateTime sdt = DateTime.Now;
                    Log_Print("正在获取conv···");
                    IPHostEntry hostEntry = null;
                    try
                    {
                        hostEntry = Dns.GetHostEntry(gamehost);
                    }
                    catch
                    {
                        Log_Print("解析域名失败: " + gamehost);
                        Log_Print("服务器Game端口无法连接！");
                        TimeOut = false;
                        return;
                    }
                    if (hostEntry.AddressList.Length == 0)
                    {
                        Log_Print("解析域名失败: " + gamehost);
                        Log_Print("服务器Game端口无法连接！");
                        TimeOut = false;
                        return;
                    }
                    var endpoint = hostEntry.AddressList[0];
                    var ip = new IPEndPoint(endpoint, 22102);
                    var client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    byte[] data = Classes.ConvertHexStringToBytes("000000ff00000000000000000000000519419494");
                    client.SendTo(data, 0, data.Length, SocketFlags.None, ip);
                    EndPoint sender = ip;
                    data = new byte[20];
                    int recv = 0;
                    try
                    {
                        recv = client.ReceiveFrom(data, ref sender);
                        Console.WriteLine("Message received from {0}: ", sender.ToString());
                        Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));
                        string ret = "";
                        int c = 0;
                        for (int i = 0; i < data.Length; i++)
                        {
                            ret += data[i];
                            c++;
                        }
                        Console.WriteLine(ret + "," + c);

                        if (Classes.ConvertDateTimeToInt(DateTime.Now) - Classes.ConvertDateTimeToInt(sdt) < 2500)
                        {
                            TimeOut = false;
                            Log_Print("服务器返回conv:" + ret);
                            Log_Print("服务器Game端口正常！");
                        }
                    }
                    catch (ArgumentNullException e)
                    {
                        if (Classes.ConvertDateTimeToInt(DateTime.Now) - Classes.ConvertDateTimeToInt(sdt) < 2500)
                        {
                            TimeOut = false;
                            Log_Print("ArgumentNullException:" + e.Message);
                            Log_Print("服务器Game端口无法连接！");
                        }
                    }
                    catch (SocketException e)
                    {
                        if (Classes.ConvertDateTimeToInt(DateTime.Now) - Classes.ConvertDateTimeToInt(sdt) < 2500)
                        {
                            TimeOut = false;
                            Log_Print("SocketException:" + e.Message);
                            Log_Print("服务器Game端口无法连接！");
                        }
                    }
                    catch (Exception e)
                    {
                        if (Classes.ConvertDateTimeToInt(DateTime.Now) - Classes.ConvertDateTimeToInt(sdt) < 2500)
                        {
                            TimeOut = false;
                            Log_Print("Exception:" + e.Message);
                            Log_Print("服务器Game端口无法连接！");
                        }
                    }
                });
                tk.Wait(3000);
                if (TimeOut)
                {
                    Log_Print("服务器Game端口连接超时！");
                }
                Log_Print("检查完成");
                Check_button.Enabled = true;
                Check_button.Text = "开始检查";
            });
        }
    }
}
