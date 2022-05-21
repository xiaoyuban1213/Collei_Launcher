namespace Bambi5_Launcher
{
    partial class Index_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index_Form));
            this.Turn_button = new System.Windows.Forms.Button();
            this.Content_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Game_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Dispatch_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Host_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Title_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Status_statusStrip = new System.Windows.Forms.StatusStrip();
            this.Server_status_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Server_Status_timer = new System.Windows.Forms.Timer(this.components);
            this.Check_button = new System.Windows.Forms.Button();
            this.Turn_Proxy_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Log_richTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Game_port_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).BeginInit();
            this.Status_statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Turn_button
            // 
            this.Turn_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Turn_button.Location = new System.Drawing.Point(12, 362);
            this.Turn_button.Name = "Turn_button";
            this.Turn_button.Size = new System.Drawing.Size(200, 50);
            this.Turn_button.TabIndex = 54;
            this.Turn_button.Text = "启动代理并打开游戏";
            this.Turn_button.UseVisualStyleBackColor = true;
            this.Turn_button.Click += new System.EventHandler(this.Turn_button_Click);
            // 
            // Content_textBox
            // 
            this.Content_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Content_textBox.Location = new System.Drawing.Point(15, 140);
            this.Content_textBox.Multiline = true;
            this.Content_textBox.Name = "Content_textBox";
            this.Content_textBox.ReadOnly = true;
            this.Content_textBox.Size = new System.Drawing.Size(235, 216);
            this.Content_textBox.TabIndex = 53;
            this.Content_textBox.Tag = "Content";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 23);
            this.label7.TabIndex = 52;
            this.label7.Text = "服务器备注：";
            // 
            // Game_port_numericUpDown
            // 
            this.Game_port_numericUpDown.Location = new System.Drawing.Point(364, 82);
            this.Game_port_numericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Game_port_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Game_port_numericUpDown.Name = "Game_port_numericUpDown";
            this.Game_port_numericUpDown.ReadOnly = true;
            this.Game_port_numericUpDown.Size = new System.Drawing.Size(124, 29);
            this.Game_port_numericUpDown.TabIndex = 51;
            this.Game_port_numericUpDown.Value = new decimal(new int[] {
            22102,
            0,
            0,
            0});
            // 
            // Dispatch_port_numericUpDown
            // 
            this.Dispatch_port_numericUpDown.Location = new System.Drawing.Point(136, 82);
            this.Dispatch_port_numericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Dispatch_port_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Dispatch_port_numericUpDown.Name = "Dispatch_port_numericUpDown";
            this.Dispatch_port_numericUpDown.ReadOnly = true;
            this.Dispatch_port_numericUpDown.Size = new System.Drawing.Size(124, 29);
            this.Dispatch_port_numericUpDown.TabIndex = 50;
            this.Dispatch_port_numericUpDown.Value = new decimal(new int[] {
            443,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 49;
            this.label6.Text = "Game端口:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 23);
            this.label5.TabIndex = 48;
            this.label5.Text = "Dispatch端口:";
            // 
            // Host_textBox
            // 
            this.Host_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Host_textBox.Location = new System.Drawing.Point(229, 47);
            this.Host_textBox.Name = "Host_textBox";
            this.Host_textBox.ReadOnly = true;
            this.Host_textBox.Size = new System.Drawing.Size(259, 29);
            this.Host_textBox.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 23);
            this.label4.TabIndex = 46;
            this.label4.Text = "服务器地址(域名或ip地址):";
            // 
            // Title_textBox
            // 
            this.Title_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title_textBox.Location = new System.Drawing.Point(229, 12);
            this.Title_textBox.Name = "Title_textBox";
            this.Title_textBox.ReadOnly = true;
            this.Title_textBox.Size = new System.Drawing.Size(259, 29);
            this.Title_textBox.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 44;
            this.label3.Text = "服务器名称:";
            // 
            // Status_statusStrip
            // 
            this.Status_statusStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Status_statusStrip.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Status_statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Status_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Server_status_toolStripStatusLabel});
            this.Status_statusStrip.Location = new System.Drawing.Point(0, 415);
            this.Status_statusStrip.Name = "Status_statusStrip";
            this.Status_statusStrip.Size = new System.Drawing.Size(498, 29);
            this.Status_statusStrip.TabIndex = 55;
            this.Status_statusStrip.Text = "Status";
            // 
            // Server_status_toolStripStatusLabel
            // 
            this.Server_status_toolStripStatusLabel.Name = "Server_status_toolStripStatusLabel";
            this.Server_status_toolStripStatusLabel.Size = new System.Drawing.Size(163, 23);
            this.Server_status_toolStripStatusLabel.Text = "正在获取服务器状态";
            // 
            // Server_Status_timer
            // 
            this.Server_Status_timer.Enabled = true;
            this.Server_Status_timer.Interval = 5000;
            this.Server_Status_timer.Tick += new System.EventHandler(this.Server_Status_timer_Tick);
            // 
            // Check_button
            // 
            this.Check_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Check_button.Location = new System.Drawing.Point(386, 362);
            this.Check_button.Name = "Check_button";
            this.Check_button.Size = new System.Drawing.Size(100, 50);
            this.Check_button.TabIndex = 56;
            this.Check_button.Text = "检查连接";
            this.Check_button.UseVisualStyleBackColor = true;
            this.Check_button.Click += new System.EventHandler(this.Check_button_Click);
            // 
            // Turn_Proxy_button
            // 
            this.Turn_Proxy_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Turn_Proxy_button.Location = new System.Drawing.Point(218, 362);
            this.Turn_Proxy_button.Name = "Turn_Proxy_button";
            this.Turn_Proxy_button.Size = new System.Drawing.Size(162, 50);
            this.Turn_Proxy_button.TabIndex = 57;
            this.Turn_Proxy_button.Text = "仅启动代理";
            this.Turn_Proxy_button.UseVisualStyleBackColor = true;
            this.Turn_Proxy_button.Click += new System.EventHandler(this.Turn_Proxy_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 59;
            this.label1.Text = "日志：";
            // 
            // Log_richTextBox
            // 
            this.Log_richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_richTextBox.Location = new System.Drawing.Point(256, 140);
            this.Log_richTextBox.Name = "Log_richTextBox";
            this.Log_richTextBox.ReadOnly = true;
            this.Log_richTextBox.Size = new System.Drawing.Size(235, 216);
            this.Log_richTextBox.TabIndex = 60;
            this.Log_richTextBox.Text = "";
            // 
            // Index_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(498, 444);
            this.Controls.Add(this.Log_richTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Turn_Proxy_button);
            this.Controls.Add(this.Check_button);
            this.Controls.Add(this.Status_statusStrip);
            this.Controls.Add(this.Turn_button);
            this.Controls.Add(this.Content_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Game_port_numericUpDown);
            this.Controls.Add(this.Dispatch_port_numericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Host_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Title_textBox);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(516, 491);
            this.Name = "Index_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Index_Form_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Index_Form_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Game_port_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).EndInit();
            this.Status_statusStrip.ResumeLayout(false);
            this.Status_statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Turn_button;
        private System.Windows.Forms.TextBox Content_textBox;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown Game_port_numericUpDown;
        public System.Windows.Forms.NumericUpDown Dispatch_port_numericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Host_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Title_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip Status_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel Server_status_toolStripStatusLabel;
        private System.Windows.Forms.Timer Server_Status_timer;
        private System.Windows.Forms.Button Check_button;
        private System.Windows.Forms.Button Turn_Proxy_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Log_richTextBox;
    }
}