namespace Collei_Launcher
{
    partial class Edit_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_Form));
            this.label3 = new System.Windows.Forms.Label();
            this.Title_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Host_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Dispatch_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Game_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Content_textBox = new System.Windows.Forms.TextBox();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Update_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Game_port_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "服务器名称:";
            // 
            // Title_textBox
            // 
            this.Title_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title_textBox.Location = new System.Drawing.Point(227, 12);
            this.Title_textBox.Name = "Title_textBox";
            this.Title_textBox.Size = new System.Drawing.Size(259, 29);
            this.Title_textBox.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "服务器地址(域名或ip地址):";
            // 
            // Host_textBox
            // 
            this.Host_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Host_textBox.Location = new System.Drawing.Point(227, 47);
            this.Host_textBox.Name = "Host_textBox";
            this.Host_textBox.Size = new System.Drawing.Size(259, 29);
            this.Host_textBox.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 23);
            this.label5.TabIndex = 36;
            this.label5.Text = "Dispatch端口:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 37;
            this.label6.Text = "Game端口:";
            // 
            // Dispatch_port_numericUpDown
            // 
            this.Dispatch_port_numericUpDown.Location = new System.Drawing.Point(134, 82);
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
            this.Dispatch_port_numericUpDown.TabIndex = 38;
            this.Dispatch_port_numericUpDown.Value = new decimal(new int[] {
            443,
            0,
            0,
            0});
            // 
            // Game_port_numericUpDown
            // 
            this.Game_port_numericUpDown.Location = new System.Drawing.Point(362, 82);
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
            this.Game_port_numericUpDown.Size = new System.Drawing.Size(124, 29);
            this.Game_port_numericUpDown.TabIndex = 39;
            this.Game_port_numericUpDown.Value = new decimal(new int[] {
            22102,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 23);
            this.label7.TabIndex = 40;
            this.label7.Text = "服务器备注：";
            // 
            // Content_textBox
            // 
            this.Content_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Content_textBox.Location = new System.Drawing.Point(13, 140);
            this.Content_textBox.Multiline = true;
            this.Content_textBox.Name = "Content_textBox";
            this.Content_textBox.Size = new System.Drawing.Size(473, 194);
            this.Content_textBox.TabIndex = 41;
            this.Content_textBox.Tag = "Content";
            // 
            // Cancel_button
            // 
            this.Cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_button.Location = new System.Drawing.Point(386, 340);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(100, 50);
            this.Cancel_button.TabIndex = 43;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Update_button
            // 
            this.Update_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Update_button.Location = new System.Drawing.Point(13, 340);
            this.Update_button.Name = "Update_button";
            this.Update_button.Size = new System.Drawing.Size(150, 50);
            this.Update_button.TabIndex = 42;
            this.Update_button.Text = "确定";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // Edit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(498, 402);
            this.Controls.Add(this.Update_button);
            this.Controls.Add(this.Cancel_button);
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
            this.MinimumSize = new System.Drawing.Size(516, 449);
            this.Name = "Edit_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Edit_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Game_port_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Title_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Host_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown Dispatch_port_numericUpDown;
        public System.Windows.Forms.NumericUpDown Game_port_numericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Content_textBox;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button Update_button;
    }
}