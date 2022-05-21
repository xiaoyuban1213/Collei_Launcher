
namespace Bambi5_Launcher
{
    partial class Main_Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Loading···",
            "loading···",
            "loading",
            "loading",
            "N/A",
            "Loading···"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.Main_tabControl = new System.Windows.Forms.TabControl();
            this.Home_tabPage = new System.Windows.Forms.TabPage();
            this.Notice_label = new System.Windows.Forms.Label();
            this.Servers_List_tabPage = new System.Windows.Forms.TabPage();
            this.Servers_listView = new System.Windows.Forms.ListView();
            this.Title_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dispatch_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Game_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Content_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Settings_tabPage = new System.Windows.Forms.TabPage();
            this.Open_Check_button = new System.Windows.Forms.Button();
            this.Save_proxy_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Choice_Game_Path_button = new System.Windows.Forms.Button();
            this.Game_Path_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Auto_close_proxy_checkBox = new System.Windows.Forms.CheckBox();
            this.Show_Public_Server_checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Proxy_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Main_statusStrip = new System.Windows.Forms.StatusStrip();
            this.Proxy_status_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Bambi5_linkLabel = new System.Windows.Forms.LinkLabel();
            this.Servers_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Count_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status_timer = new System.Windows.Forms.Timer(this.components);
            this.Main_tabControl.SuspendLayout();
            this.Home_tabPage.SuspendLayout();
            this.Servers_List_tabPage.SuspendLayout();
            this.Settings_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Proxy_port_numericUpDown)).BeginInit();
            this.Main_statusStrip.SuspendLayout();
            this.Servers_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_tabControl
            // 
            this.Main_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_tabControl.Controls.Add(this.Home_tabPage);
            this.Main_tabControl.Controls.Add(this.Servers_List_tabPage);
            this.Main_tabControl.Controls.Add(this.Settings_tabPage);
            this.Main_tabControl.Location = new System.Drawing.Point(12, 12);
            this.Main_tabControl.Name = "Main_tabControl";
            this.Main_tabControl.SelectedIndex = 0;
            this.Main_tabControl.Size = new System.Drawing.Size(608, 429);
            this.Main_tabControl.TabIndex = 1;
            // 
            // Home_tabPage
            // 
            this.Home_tabPage.Controls.Add(this.Notice_label);
            this.Home_tabPage.Location = new System.Drawing.Point(4, 32);
            this.Home_tabPage.Name = "Home_tabPage";
            this.Home_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Home_tabPage.Size = new System.Drawing.Size(600, 393);
            this.Home_tabPage.TabIndex = 1;
            this.Home_tabPage.Text = "主页";
            this.Home_tabPage.UseVisualStyleBackColor = true;
            this.Home_tabPage.Enter += new System.EventHandler(this.Home_tabPage_Enter);
            // 
            // Notice_label
            // 
            this.Notice_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Notice_label.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.Notice_label.Location = new System.Drawing.Point(3, 3);
            this.Notice_label.Name = "Notice_label";
            this.Notice_label.Size = new System.Drawing.Size(594, 387);
            this.Notice_label.TabIndex = 0;
            this.Notice_label.Text = "正在加载公告···";
            this.Notice_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Servers_List_tabPage
            // 
            this.Servers_List_tabPage.Controls.Add(this.Servers_listView);
            this.Servers_List_tabPage.Location = new System.Drawing.Point(4, 32);
            this.Servers_List_tabPage.Name = "Servers_List_tabPage";
            this.Servers_List_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Servers_List_tabPage.Size = new System.Drawing.Size(600, 393);
            this.Servers_List_tabPage.TabIndex = 2;
            this.Servers_List_tabPage.Text = "服务器列表";
            this.Servers_List_tabPage.UseVisualStyleBackColor = true;
            this.Servers_List_tabPage.Enter += new System.EventHandler(this.Servers_List_tabPage_Enter);
            // 
            // Servers_listView
            // 
            this.Servers_listView.AllowDrop = true;
            this.Servers_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title_columnHeader,
            this.Date_columnHeader,
            this.Dispatch_columnHeader,
            this.Game_columnHeader,
            this.Count_columnHeader,
            this.Content_columnHeader});
            this.Servers_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Servers_listView.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Servers_listView.FullRowSelect = true;
            this.Servers_listView.GridLines = true;
            this.Servers_listView.HideSelection = false;
            this.Servers_listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.Servers_listView.Location = new System.Drawing.Point(3, 3);
            this.Servers_listView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Servers_listView.MultiSelect = false;
            this.Servers_listView.Name = "Servers_listView";
            this.Servers_listView.ShowGroups = false;
            this.Servers_listView.Size = new System.Drawing.Size(594, 387);
            this.Servers_listView.TabIndex = 9;
            this.Servers_listView.UseCompatibleStateImageBehavior = false;
            this.Servers_listView.View = System.Windows.Forms.View.Details;
            this.Servers_listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Servers_listView_MouseDoubleClick);
            this.Servers_listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Servers_listView_MouseDown);
            // 
            // Title_columnHeader
            // 
            this.Title_columnHeader.Text = "标题";
            this.Title_columnHeader.Width = 100;
            // 
            // Date_columnHeader
            // 
            this.Date_columnHeader.Text = "地址";
            this.Date_columnHeader.Width = 150;
            // 
            // Dispatch_columnHeader
            // 
            this.Dispatch_columnHeader.Text = "Dispatch端口";
            this.Dispatch_columnHeader.Width = 100;
            // 
            // Game_columnHeader
            // 
            this.Game_columnHeader.Text = "Game端口";
            this.Game_columnHeader.Width = 100;
            // 
            // Content_columnHeader
            // 
            this.Content_columnHeader.Text = "介绍";
            this.Content_columnHeader.Width = 200;
            // 
            // Settings_tabPage
            // 
            this.Settings_tabPage.Controls.Add(this.Open_Check_button);
            this.Settings_tabPage.Controls.Add(this.Save_proxy_button);
            this.Settings_tabPage.Controls.Add(this.label3);
            this.Settings_tabPage.Controls.Add(this.Choice_Game_Path_button);
            this.Settings_tabPage.Controls.Add(this.Game_Path_textBox);
            this.Settings_tabPage.Controls.Add(this.label2);
            this.Settings_tabPage.Controls.Add(this.Auto_close_proxy_checkBox);
            this.Settings_tabPage.Controls.Add(this.Show_Public_Server_checkBox);
            this.Settings_tabPage.Controls.Add(this.label1);
            this.Settings_tabPage.Controls.Add(this.Proxy_port_numericUpDown);
            this.Settings_tabPage.Location = new System.Drawing.Point(4, 32);
            this.Settings_tabPage.Name = "Settings_tabPage";
            this.Settings_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Settings_tabPage.Size = new System.Drawing.Size(600, 393);
            this.Settings_tabPage.TabIndex = 0;
            this.Settings_tabPage.Text = "设置";
            this.Settings_tabPage.UseVisualStyleBackColor = true;
            // 
            // Open_Check_button
            // 
            this.Open_Check_button.Location = new System.Drawing.Point(6, 337);
            this.Open_Check_button.Name = "Open_Check_button";
            this.Open_Check_button.Size = new System.Drawing.Size(200, 50);
            this.Open_Check_button.TabIndex = 13;
            this.Open_Check_button.Text = "打开服务器检查工具";
            this.Open_Check_button.UseVisualStyleBackColor = true;
            this.Open_Check_button.Click += new System.EventHandler(this.Open_Check_button_Click);
            // 
            // Save_proxy_button
            // 
            this.Save_proxy_button.Location = new System.Drawing.Point(223, 6);
            this.Save_proxy_button.Name = "Save_proxy_button";
            this.Save_proxy_button.Size = new System.Drawing.Size(100, 50);
            this.Save_proxy_button.TabIndex = 7;
            this.Save_proxy_button.Text = "保存端口";
            this.Save_proxy_button.UseVisualStyleBackColor = true;
            this.Save_proxy_button.Click += new System.EventHandler(this.Save_proxy_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(497, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "如：‪E:\\Genshin Impact\\Genshin Impact Game\\YuanShen.exe";
            // 
            // Choice_Game_Path_button
            // 
            this.Choice_Game_Path_button.Location = new System.Drawing.Point(497, 112);
            this.Choice_Game_Path_button.Name = "Choice_Game_Path_button";
            this.Choice_Game_Path_button.Size = new System.Drawing.Size(100, 50);
            this.Choice_Game_Path_button.TabIndex = 11;
            this.Choice_Game_Path_button.Text = "选择文件";
            this.Choice_Game_Path_button.UseVisualStyleBackColor = true;
            this.Choice_Game_Path_button.Click += new System.EventHandler(this.Choice_Game_Path_button_Click);
            // 
            // Game_Path_textBox
            // 
            this.Game_Path_textBox.Location = new System.Drawing.Point(97, 123);
            this.Game_Path_textBox.Name = "Game_Path_textBox";
            this.Game_Path_textBox.ReadOnly = true;
            this.Game_Path_textBox.Size = new System.Drawing.Size(394, 29);
            this.Game_Path_textBox.TabIndex = 10;
            this.Game_Path_textBox.TextChanged += new System.EventHandler(this.Game_Path_textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "游戏文件:";
            // 
            // Auto_close_proxy_checkBox
            // 
            this.Auto_close_proxy_checkBox.AutoSize = true;
            this.Auto_close_proxy_checkBox.Checked = true;
            this.Auto_close_proxy_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Auto_close_proxy_checkBox.Location = new System.Drawing.Point(13, 86);
            this.Auto_close_proxy_checkBox.Name = "Auto_close_proxy_checkBox";
            this.Auto_close_proxy_checkBox.Size = new System.Drawing.Size(270, 27);
            this.Auto_close_proxy_checkBox.TabIndex = 9;
            this.Auto_close_proxy_checkBox.Text = "在关闭软件时自动关闭系统代理";
            this.Auto_close_proxy_checkBox.UseVisualStyleBackColor = true;
            this.Auto_close_proxy_checkBox.CheckedChanged += new System.EventHandler(this.Auto_close_proxy_checkBox_CheckedChanged);
            // 
            // Show_Public_Server_checkBox
            // 
            this.Show_Public_Server_checkBox.AutoSize = true;
            this.Show_Public_Server_checkBox.Checked = true;
            this.Show_Public_Server_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Show_Public_Server_checkBox.Location = new System.Drawing.Point(13, 53);
            this.Show_Public_Server_checkBox.Name = "Show_Public_Server_checkBox";
            this.Show_Public_Server_checkBox.Size = new System.Drawing.Size(151, 27);
            this.Show_Public_Server_checkBox.TabIndex = 8;
            this.Show_Public_Server_checkBox.Text = "显示公共服务器";
            this.Show_Public_Server_checkBox.UseVisualStyleBackColor = true;
            this.Show_Public_Server_checkBox.CheckedChanged += new System.EventHandler(this.Show_Public_Server_checkBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "代理端口:";
            // 
            // Proxy_port_numericUpDown
            // 
            this.Proxy_port_numericUpDown.Location = new System.Drawing.Point(97, 18);
            this.Proxy_port_numericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Proxy_port_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Proxy_port_numericUpDown.Name = "Proxy_port_numericUpDown";
            this.Proxy_port_numericUpDown.Size = new System.Drawing.Size(120, 29);
            this.Proxy_port_numericUpDown.TabIndex = 6;
            this.Proxy_port_numericUpDown.Value = new decimal(new int[] {
            8520,
            0,
            0,
            0});
            // 
            // Main_statusStrip
            // 
            this.Main_statusStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Main_statusStrip.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Main_statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Main_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Proxy_status_toolStripStatusLabel});
            this.Main_statusStrip.Location = new System.Drawing.Point(0, 449);
            this.Main_statusStrip.Name = "Main_statusStrip";
            this.Main_statusStrip.Size = new System.Drawing.Size(632, 29);
            this.Main_statusStrip.TabIndex = 2;
            this.Main_statusStrip.Text = "Status";
            // 
            // Proxy_status_toolStripStatusLabel
            // 
            this.Proxy_status_toolStripStatusLabel.IsLink = true;
            this.Proxy_status_toolStripStatusLabel.Name = "Proxy_status_toolStripStatusLabel";
            this.Proxy_status_toolStripStatusLabel.Size = new System.Drawing.Size(146, 23);
            this.Proxy_status_toolStripStatusLabel.Text = "查看当前代理配置";
            this.Proxy_status_toolStripStatusLabel.Click += new System.EventHandler(this.Proxy_status_toolStripStatusLabel_Click);
            // 
            // Bambi5_linkLabel
            // 
            this.Bambi5_linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bambi5_linkLabel.AutoSize = true;
            this.Bambi5_linkLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Bambi5_linkLabel.Location = new System.Drawing.Point(523, 455);
            this.Bambi5_linkLabel.Name = "Bambi5_linkLabel";
            this.Bambi5_linkLabel.Size = new System.Drawing.Size(97, 23);
            this.Bambi5_linkLabel.TabIndex = 3;
            this.Bambi5_linkLabel.TabStop = true;
            this.Bambi5_linkLabel.Text = "By Bambi5";
            this.Bambi5_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Bambi5_linkLabel_LinkClicked);
            // 
            // Servers_contextMenuStrip
            // 
            this.Servers_contextMenuStrip.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.Servers_contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Servers_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.toolStripSeparator1,
            this.连接ToolStripMenuItem,
            this.检查连接ToolStripMenuItem,
            this.toolStripSeparator2,
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.Servers_contextMenuStrip.Name = "Servers_contextMenuStrip";
            this.Servers_contextMenuStrip.Size = new System.Drawing.Size(173, 176);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Image = global::Bambi5_Launcher.Properties.Resources.添加;
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(172, 32);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // 连接ToolStripMenuItem
            // 
            this.连接ToolStripMenuItem.Image = global::Bambi5_Launcher.Properties.Resources.启动;
            this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            this.连接ToolStripMenuItem.Size = new System.Drawing.Size(172, 32);
            this.连接ToolStripMenuItem.Text = "连接";
            this.连接ToolStripMenuItem.Click += new System.EventHandler(this.连接ToolStripMenuItem_Click);
            // 
            // 检查连接ToolStripMenuItem
            // 
            this.检查连接ToolStripMenuItem.Image = global::Bambi5_Launcher.Properties.Resources.搜索;
            this.检查连接ToolStripMenuItem.Name = "检查连接ToolStripMenuItem";
            this.检查连接ToolStripMenuItem.Size = new System.Drawing.Size(172, 32);
            this.检查连接ToolStripMenuItem.Text = "检查连接";
            this.检查连接ToolStripMenuItem.Click += new System.EventHandler(this.检查连接ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Image = global::Bambi5_Launcher.Properties.Resources.编辑;
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(172, 32);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Image = global::Bambi5_Launcher.Properties.Resources.删除;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(172, 32);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // Count_columnHeader
            // 
            this.Count_columnHeader.Text = "在线人数";
            this.Count_columnHeader.Width = 80;
            // 
            // Status_timer
            // 
            this.Status_timer.Enabled = true;
            this.Status_timer.Interval = 5000;
            this.Status_timer.Tick += new System.EventHandler(this.Status_timer_Tick);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(632, 478);
            this.Controls.Add(this.Bambi5_linkLabel);
            this.Controls.Add(this.Main_statusStrip);
            this.Controls.Add(this.Main_tabControl);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 525);
            this.Name = "Main_Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "割草机启动器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.Shown += new System.EventHandler(this.Main_Form_Shown);
            this.Main_tabControl.ResumeLayout(false);
            this.Home_tabPage.ResumeLayout(false);
            this.Servers_List_tabPage.ResumeLayout(false);
            this.Settings_tabPage.ResumeLayout(false);
            this.Settings_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Proxy_port_numericUpDown)).EndInit();
            this.Main_statusStrip.ResumeLayout(false);
            this.Main_statusStrip.PerformLayout();
            this.Servers_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TabControl Main_tabControl;
        public System.Windows.Forms.TabPage Settings_tabPage;
        public System.Windows.Forms.StatusStrip Main_statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel Proxy_status_toolStripStatusLabel;
        public System.Windows.Forms.TabPage Home_tabPage;
        public System.Windows.Forms.Label Notice_label;
        public System.Windows.Forms.ListView Servers_listView;
        public System.Windows.Forms.ColumnHeader Title_columnHeader;
        public System.Windows.Forms.ColumnHeader Date_columnHeader;
        public System.Windows.Forms.ColumnHeader Dispatch_columnHeader;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown Proxy_port_numericUpDown;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ContextMenuStrip Servers_contextMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        public System.Windows.Forms.TabPage Servers_List_tabPage;
        public System.Windows.Forms.LinkLabel Bambi5_linkLabel;
        public System.Windows.Forms.ColumnHeader Game_columnHeader;
        public System.Windows.Forms.ColumnHeader Content_columnHeader;
        public System.Windows.Forms.CheckBox Show_Public_Server_checkBox;
        public System.Windows.Forms.CheckBox Auto_close_proxy_checkBox;
        public System.Windows.Forms.TextBox Game_Path_textBox;
        public System.Windows.Forms.Button Choice_Game_Path_button;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button Save_proxy_button;
        public System.Windows.Forms.Button Open_Check_button;
        private System.Windows.Forms.ToolStripMenuItem 检查连接ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Count_columnHeader;
        private System.Windows.Forms.Timer Status_timer;
    }
}

