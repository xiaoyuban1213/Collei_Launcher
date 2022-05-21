namespace Bambi5_Launcher
{
    partial class Check_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Check_Form));
            this.Game_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Dispatch_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Host_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Game_Host_checkBox = new System.Windows.Forms.CheckBox();
            this.Game_Host_textBox = new System.Windows.Forms.TextBox();
            this.Log_richTextBox = new System.Windows.Forms.RichTextBox();
            this.Check_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Game_port_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Game_port_numericUpDown
            // 
            this.Game_port_numericUpDown.Location = new System.Drawing.Point(365, 51);
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
            this.Game_port_numericUpDown.Size = new System.Drawing.Size(125, 29);
            this.Game_port_numericUpDown.TabIndex = 57;
            this.Game_port_numericUpDown.Value = new decimal(new int[] {
            22102,
            0,
            0,
            0});
            // 
            // Dispatch_port_numericUpDown
            // 
            this.Dispatch_port_numericUpDown.Location = new System.Drawing.Point(137, 51);
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
            this.Dispatch_port_numericUpDown.Size = new System.Drawing.Size(124, 29);
            this.Dispatch_port_numericUpDown.TabIndex = 56;
            this.Dispatch_port_numericUpDown.Value = new decimal(new int[] {
            443,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 55;
            this.label6.Text = "Game端口:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 23);
            this.label5.TabIndex = 54;
            this.label5.Text = "Dispatch端口:";
            // 
            // Host_textBox
            // 
            this.Host_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Host_textBox.Location = new System.Drawing.Point(230, 16);
            this.Host_textBox.Name = "Host_textBox";
            this.Host_textBox.Size = new System.Drawing.Size(260, 29);
            this.Host_textBox.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 23);
            this.label4.TabIndex = 52;
            this.label4.Text = "服务器地址(域名或ip地址):";
            // 
            // Game_Host_checkBox
            // 
            this.Game_Host_checkBox.AutoSize = true;
            this.Game_Host_checkBox.Location = new System.Drawing.Point(16, 86);
            this.Game_Host_checkBox.Name = "Game_Host_checkBox";
            this.Game_Host_checkBox.Size = new System.Drawing.Size(203, 27);
            this.Game_Host_checkBox.TabIndex = 58;
            this.Game_Host_checkBox.Text = "单独指定Game服务器:";
            this.Game_Host_checkBox.UseVisualStyleBackColor = true;
            this.Game_Host_checkBox.CheckedChanged += new System.EventHandler(this.Game_Host_checkBox_CheckedChanged);
            // 
            // Game_Host_textBox
            // 
            this.Game_Host_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Game_Host_textBox.Location = new System.Drawing.Point(225, 86);
            this.Game_Host_textBox.Name = "Game_Host_textBox";
            this.Game_Host_textBox.Size = new System.Drawing.Size(265, 29);
            this.Game_Host_textBox.TabIndex = 59;
            // 
            // Log_richTextBox
            // 
            this.Log_richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_richTextBox.Location = new System.Drawing.Point(12, 121);
            this.Log_richTextBox.Name = "Log_richTextBox";
            this.Log_richTextBox.ReadOnly = true;
            this.Log_richTextBox.Size = new System.Drawing.Size(478, 189);
            this.Log_richTextBox.TabIndex = 60;
            this.Log_richTextBox.Text = "";
            // 
            // Check_button
            // 
            this.Check_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Check_button.Location = new System.Drawing.Point(12, 316);
            this.Check_button.Name = "Check_button";
            this.Check_button.Size = new System.Drawing.Size(150, 50);
            this.Check_button.TabIndex = 61;
            this.Check_button.Text = "开始检查";
            this.Check_button.UseVisualStyleBackColor = true;
            this.Check_button.Click += new System.EventHandler(this.Check_button_Click);
            // 
            // Check_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(502, 378);
            this.Controls.Add(this.Check_button);
            this.Controls.Add(this.Log_richTextBox);
            this.Controls.Add(this.Game_Host_textBox);
            this.Controls.Add(this.Game_Host_checkBox);
            this.Controls.Add(this.Game_port_numericUpDown);
            this.Controls.Add(this.Dispatch_port_numericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Host_textBox);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 425);
            this.Name = "Check_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查连接";
            ((System.ComponentModel.ISupportInitialize)(this.Game_port_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown Game_port_numericUpDown;
        public System.Windows.Forms.NumericUpDown Dispatch_port_numericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Host_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Game_Host_checkBox;
        private System.Windows.Forms.TextBox Game_Host_textBox;
        private System.Windows.Forms.RichTextBox Log_richTextBox;
        private System.Windows.Forms.Button Check_button;
    }
}