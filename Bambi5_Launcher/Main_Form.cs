using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bambi5_Launcher
{
    public partial class Main_Form : Form
    {

        public bool loaded = false;
        public static Main_Form form;
        public bool Show_Public_Server = true;
        public bool is_loading_cc = false;
        public int VerCode;
        public Cloud_Config cc;
        public Local_Config lc;
        public bool Offine = true;
        public bool is_first_check = true;
        public string config_path = Application.StartupPath + @"\config.json";
        public List<ServersItem_List> servers = new List<ServersItem_List>();
        public int ci;

        public Main_Form()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            form = this;
            InitializeComponent();
            Classes.SetCertificatePolicy();
        }


        private void Main_Form_Shown(object sender, EventArgs e)
        {
            bool isdebug = Classes.DebugBuild(Assembly.GetExecutingAssembly());
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string ver = string.Format("(v{0}.{1}.{2})", version.Major, version.Minor, version.Build);
            VerCode = version.Revision;
            this.Text += ver;
            if (isdebug)
            {
                this.Text += " - Debug";
            }
            else
            {
                this.Text += " - Release";
            }
            Check_Proxy();
            Load_Local_Config();
        }

        public void Check_Proxy()
        {
            if (using_proxy().ProxyEnable)
            {
                string show = "检测到您当前开启了系统代理，这可能是上次启动器未正确关闭导致的,代理配置不正确会导致无法连接网络,当前的代理配置如下\n";
                show += Get_Proxy_Text();
                show += "\n若您想关闭代理,请点击“是”，若不想关闭代理，请点击“否”";
                if (MessageBox.Show(show, "要关闭代理吗?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Clear_Proxy();
                }
            }
        }
        public void Set_Proxy(string proxy)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true))
            {
                regkey.SetValue("ProxyEnable", 1);
                regkey.SetValue("ProxyServer", proxy);
            }
        }

        public void Clear_Proxy()
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true))
            {
                regkey.SetValue("ProxyEnable", 0);
            }
        }

        public Proxy_Config using_proxy()
        {
            Proxy_Config proxy = new Proxy_Config();
            try
            {
                using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings"))
                {
                    if (regkey.GetValue("ProxyEnable").ToString() == "1")
                    {
                        proxy.ProxyEnable = true;
                    }
                    object ps = regkey.GetValue("ProxyServer");
                    if (ps != null)
                    {
                        proxy.ProxyServer = ps.ToString();
                    }
                    else
                    {
                        ps = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return proxy;
        }

        private void Bambi5_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://amfeng.cn/");
        }

        public string Get_Proxy_Text()
        {
            string st = "代理";
            Proxy_Config pc = using_proxy();
            if (pc.ProxyEnable == true)
            {
                st += "已开启,代理服务器地址:";
                string[] servers = pc.ProxyServer.Split(';');
                for (int i = 0; i < servers.Length; i++)
                {
                    st += "\n" + servers[i];
                }
            }
            else
            {
                st += "未开启";
            }
            Debug.Print(st);
            return st;
        }
        private void Proxy_status_toolStripStatusLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Get_Proxy_Text(), "代理状态", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Home_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateAndNotice();
        }
        public void UpdateAndNotice()
        {
            Task.Run(() =>
            {
                try
                {
                    while (lc == null)
                    {
                        Debug.Print("等待lc加载");
                        Thread.Sleep(100);
                    }
                    is_loading_cc = true;
                    string ccs = Classes.Get("http://launcher.bambi5.top/Main?action=Get_Config&data=");
                    if (ccs == null)
                    {
                        is_loading_cc = false;
                        Load_Servers();
                        Notice_label.Text = "获取云配置文件失败";
                        Notice_label.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    cc = JsonConvert.DeserializeObject<Cloud_Config>(ccs);
                    Notice_label.Text = cc.config.Notice;
                    Notice_label.ForeColor = System.Drawing.Color.Black;
                    if (is_first_check && VerCode < cc.config.lastvercode)
                    {
                        string show = "发现有新版本，是否更新?";
                        show += "\n[当前版本]:" + VerCode;
                        show += "\n[最新版本]:" + cc.config.lastvercode;
                        show += "\n[更新内容]:" + cc.config.lastverstr;
                        show += "\n点击“是”，跳转到更新连接\n点击“否”，关闭此消息框";
                        if (MessageBox.Show(show, "版本更新提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://amfeng.cn/196.html");
                        }
                    }
                    is_first_check = false;
                    is_loading_cc = false;
                    Load_Servers();
                }
                catch (Exception ex)
                {
                    is_loading_cc = false;
                    Load_Servers();
                    Program.Application_Exception(ex);
                }
            });
        }
        private void Auto_close_proxy_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            lc.config.Auto_Close_Proxy = Auto_close_proxy_checkBox.Checked;
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save_Local_Config();
            if (lc.config.Auto_Close_Proxy)
            {
                Clear_Proxy();
            }
        }
        public void Load_Local_Config()
        {
            using (RegistryKey regkey = Registry.CurrentUser.CreateSubKey(@"Software\Bambi5\Launcher"))
            {
                Show_Public_Server = (string)regkey.GetValue("Show_Public_Server") != "False";
                Show_Public_Server_checkBox.Checked = Show_Public_Server;
            }
            Debug.Print(config_path);
            if (File.Exists(config_path))
            {
                Debug.Print("已找到config文件");
                string lcs = File.ReadAllText(config_path);
                try
                {
                    lc = JsonConvert.DeserializeObject<Local_Config>(lcs);
                }
                catch (Exception ex)
                {
                    Debug.Print("解析json时出现错误:" + ex.Message);
                    lc = new Local_Config();
                    File.WriteAllText(config_path, JsonConvert.SerializeObject(lc));
                }
            }
            else
            {
                Debug.Print("未找到config文件");
                lc = new Local_Config();
                File.WriteAllText(config_path, JsonConvert.SerializeObject(lc));
            }
            LoadSettingsToForm();
        }
        public void LoadSettingsToForm()
        {
            Proxy_port_numericUpDown.Value = lc.config.ProxyPort;
            Auto_close_proxy_checkBox.Checked = lc.config.Auto_Close_Proxy;
            if (lc != null && lc.config.Game_Path != null)
            {
                Game_Path_textBox.Text = lc.config.Game_Path;
            }
        }
        private void Show_Public_Server_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.CreateSubKey(@"Software\Bambi5\Launcher"))
            {
                Show_Public_Server = Show_Public_Server_checkBox.Checked;
                regkey.SetValue("Show_Public_Server", Show_Public_Server_checkBox.Checked);
            }
        }
        public void Load_Servers()
        {
            servers.Clear();
            if (Show_Public_Server && cc != null)
            {
                for (int i = 0; i < cc.servers.Count; i++)
                {
                    ServersItem_List ser = new ServersItem_List();
                    ser.title = cc.servers[i].title;
                    ser.host = cc.servers[i].host;
                    ser.dispatch = cc.servers[i].dispatch;
                    ser.game = cc.servers[i].game;
                    ser.content = cc.servers[i].content;
                    ser.is_cloud = true;
                    servers.Add(ser);
                }
            }
            for (int i = 0; i < lc.servers.Count; i++)
            {
                ServersItem_List ser = new ServersItem_List();
                ser.title = lc.servers[i].title;
                ser.host = lc.servers[i].host;
                ser.dispatch = lc.servers[i].dispatch;
                ser.game = lc.servers[i].game;
                ser.content = lc.servers[i].content;
                ser.is_cloud = false;
                servers.Add(ser);
            }
            Load_Server_List();
            loaded = true;
        }
        public void Load_Server_List()
        {
            Servers_listView.BeginUpdate();
            Servers_listView.Items.Clear();
            int local_index = 0;
            for (int i = 0; i < servers.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = servers[i].title;
                lvi.SubItems.Add(servers[i].host);
                lvi.SubItems.Add(servers[i].dispatch + "");
                lvi.SubItems.Add(servers[i].game + "");
                lvi.SubItems.Add("N/A");
                lvi.SubItems.Add(servers[i].content + "");
                if (servers[i].is_cloud)
                {
                    lvi.Tag = -1;
                }
                else
                {
                    lvi.Tag = local_index;
                    local_index++;
                }
                Servers_listView.Items.Add(lvi);
            }
            Servers_listView.EndUpdate();
            Load_Player_Count();
        }
        public void Save_Local_Config()
        {
            Debug.Print("正在保存config文件"); ;
            if (lc == null)
            {
                lc = new Local_Config();
            }
            File.WriteAllText(config_path, JsonConvert.SerializeObject(lc));
        }
        private void Save_proxy_button_Click(object sender, EventArgs e)
        {
            lc.config.ProxyPort = (ushort)Proxy_port_numericUpDown.Value;
        }
        public void Choice_Game_Path_button_Click(object sender, EventArgs e)
        {
            string path = Choice_Game_Path();
            if (path == null)
            {
                return;
            }
            lc.config.Game_Path = path;
            Game_Path_textBox.Text = lc.config.Game_Path;
            Save_Local_Config();
        }

        public string Choice_Game_Path()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Filter = "国服游戏文件|YuanShen.exe|国际服游戏文件|GenshinImpact.exe";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.Title = "选择游戏文件";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (openFileDialog1.FileName == "")
                {
                    MessageBox.Show("请选择一个文件！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return openFileDialog1.FileName;
            }
            return null;
        }
        private void Game_Path_textBox_TextChanged(object sender, EventArgs e)
        {
            lc.config.Game_Path = Game_Path_textBox.Text;
        }

        private void Servers_List_tabPage_Enter(object sender, EventArgs e)
        {
            if (!is_loading_cc)
                Load_Servers();
        }

        private void Servers_listView_MouseDown(object sender, MouseEventArgs e)
        {
            if (!loaded)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                var item = Servers_listView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    ci = item.Index;
                    if (servers[ci].is_cloud)
                    {
                        添加ToolStripMenuItem.Visible = true;
                        连接ToolStripMenuItem.Visible = true;
                        检查连接ToolStripMenuItem.Visible = true;
                        编辑ToolStripMenuItem.Visible = false;
                        删除ToolStripMenuItem.Visible = false;
                        toolStripSeparator1.Visible = true;
                        toolStripSeparator2.Visible = false;
                    }
                    else
                    {
                        添加ToolStripMenuItem.Visible = true;
                        连接ToolStripMenuItem.Visible = true;
                        检查连接ToolStripMenuItem.Visible = true;
                        编辑ToolStripMenuItem.Visible = true;
                        删除ToolStripMenuItem.Visible = true;
                        toolStripSeparator1.Visible = true;
                        toolStripSeparator2.Visible = true;
                    }
                    Servers_contextMenuStrip.Show(Servers_listView, e.Location);
                }
                else
                {
                    添加ToolStripMenuItem.Visible = true;
                    连接ToolStripMenuItem.Visible = false;
                    检查连接ToolStripMenuItem.Visible = false;
                    编辑ToolStripMenuItem.Visible = false;
                    删除ToolStripMenuItem.Visible = false;
                    toolStripSeparator1.Visible = false;
                    toolStripSeparator2.Visible = false;
                    Servers_contextMenuStrip.Show(Servers_listView, e.Location);
                }
            }
        }

        private void Servers_listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!loaded)
            {
                return;
            }
            var item = Servers_listView.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                return;
            }
            ci = item.Index;
            连接ToolStripMenuItem_Click(null, null);
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServersItem ser = Edit_Form.Edit_Server();
            if (ser != null)
            {
                lc.servers.Add(ser);
                Save_Local_Config();
                Load_Servers();
            }
        }

        private void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Main_Form.form.lc.config.Game_Path == null || Main_Form.form.lc.config.Game_Path == "")
            {
                MessageBox.Show("请选择游戏文件", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string path = Main_Form.form.Choice_Game_Path();
                if (path == null)
                {
                    return;
                }
                Main_Form.form.lc.config.Game_Path = path;
                Main_Form.form.Save_Local_Config();
            }
            if (cc != null&&cc.config.blacklist.Contains(servers[ci].host))
            {
                DialogResult dialog = MessageBox.Show("此服务器似乎是一个圈钱服务器，不建议连接，割草机是一个开源且免费的项目，推荐使用公共服务器体验游戏\n点击“是”：继续连接\n点击“否”：取消连接并查看割草机开源项目\n点击“取消”：取消连接到此服务器", "确定连接此服务器?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Index_Form.Open_Index(servers[ci]);
                }
                else if (dialog == DialogResult.No)
                {
                    Process.Start("https://github.com/Grasscutters/Grasscutter");
                }
                else if (dialog == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                Index_Form.Open_Index(servers[ci]);
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = (int)Servers_listView.Items[ci].Tag;
            ServersItem ser = Edit_Form.Edit_Server(lc.servers[index]);
            if (ser != null)
            {
                lc.servers[index] = ser;
                Save_Local_Config();
                Load_Servers();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lc.servers.RemoveAt((int)Servers_listView.Items[ci].Tag);
            Load_Servers();
        }

        private void Open_Check_button_Click(object sender, EventArgs e)
        {
            Check_Form.Open_Form();
        }

        private void 检查连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Check_Form.Open_Form(servers[ci]);
        }
        public Task Load_Player_Count()
        {
            return Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < servers.Count; i++)
                    {
                        string str = "https://" + servers[i].host + ":" + servers[i].dispatch + "/status/server";
                        Debug.Print(str);
                        Index_Get ig = Classes.Get_for_Index(str);
                        if (ig.Use_time >= 0 && ig.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Def_status.Root df = JsonConvert.DeserializeObject<Def_status.Root>(ig.Result);
                            Servers_listView.Items[i].SubItems[4].Text = df.status.playerCount + "";
                        }
                        else
                        {
                            Servers_listView.Items[i].SubItems[4].Text = "N/A";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            });
        }

        private void Status_timer_Tick(object sender, EventArgs e)
        {
            Load_Player_Count();
        }
    }
}
