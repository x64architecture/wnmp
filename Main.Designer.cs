namespace Wnmp
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mysqlpass = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nginxstart = new System.Windows.Forms.Button();
            this.nginxstop = new System.Windows.Forms.Button();
            this.nginxreload = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.phpstart = new System.Windows.Forms.Button();
            this.phpstop = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.mysqlhelp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.mysqlstop = new System.Windows.Forms.Button();
            this.mysqlstart = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(51, 33);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(116, 59);
            this.start.TabIndex = 0;
            this.start.Text = "Start all";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            this.start.MouseHover += new System.EventHandler(this.start_MouseHover);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(290, 33);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(116, 59);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop all";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            this.stop.MouseHover += new System.EventHandler(this.stop_MouseHover);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(471, 191);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.mysqlpass);
            this.tabPage1.Controls.Add(this.start);
            this.tabPage1.Controls.Add(this.stop);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(463, 165);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Only needed when stopping MySQL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter MySQL Password:";
            // 
            // mysqlpass
            // 
            this.mysqlpass.Location = new System.Drawing.Point(290, 123);
            this.mysqlpass.Name = "mysqlpass";
            this.mysqlpass.PasswordChar = '*';
            this.mysqlpass.Size = new System.Drawing.Size(116, 20);
            this.mysqlpass.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nginxstart);
            this.tabPage2.Controls.Add(this.nginxstop);
            this.tabPage2.Controls.Add(this.nginxreload);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(463, 165);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nginx";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nginxstart
            // 
            this.nginxstart.Location = new System.Drawing.Point(175, 33);
            this.nginxstart.Name = "nginxstart";
            this.nginxstart.Size = new System.Drawing.Size(116, 59);
            this.nginxstart.TabIndex = 2;
            this.nginxstart.Text = "Start";
            this.nginxstart.UseVisualStyleBackColor = true;
            this.nginxstart.Click += new System.EventHandler(this.nginxstart_Click);
            this.nginxstart.MouseHover += new System.EventHandler(this.nginxstart_MouseHover);
            // 
            // nginxstop
            // 
            this.nginxstop.Location = new System.Drawing.Point(321, 33);
            this.nginxstop.Name = "nginxstop";
            this.nginxstop.Size = new System.Drawing.Size(116, 59);
            this.nginxstop.TabIndex = 1;
            this.nginxstop.Text = "Stop";
            this.nginxstop.UseVisualStyleBackColor = true;
            this.nginxstop.Click += new System.EventHandler(this.nginxstop_Click);
            this.nginxstop.MouseHover += new System.EventHandler(this.nginxstop_MouseHover);
            // 
            // nginxreload
            // 
            this.nginxreload.Location = new System.Drawing.Point(18, 33);
            this.nginxreload.Name = "nginxreload";
            this.nginxreload.Size = new System.Drawing.Size(116, 59);
            this.nginxreload.TabIndex = 0;
            this.nginxreload.Text = "Reload";
            this.nginxreload.UseVisualStyleBackColor = true;
            this.nginxreload.Click += new System.EventHandler(this.nginxreload_Click);
            this.nginxreload.MouseHover += new System.EventHandler(this.nginxreload_MouseHover);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.phpstart);
            this.tabPage3.Controls.Add(this.phpstop);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(463, 165);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PHP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // phpstart
            // 
            this.phpstart.Location = new System.Drawing.Point(51, 33);
            this.phpstart.Name = "phpstart";
            this.phpstart.Size = new System.Drawing.Size(116, 59);
            this.phpstart.TabIndex = 1;
            this.phpstart.Text = "Start";
            this.phpstart.UseVisualStyleBackColor = true;
            this.phpstart.Click += new System.EventHandler(this.phpstart_Click);
            this.phpstart.MouseHover += new System.EventHandler(this.phpstart_MouseHover);
            // 
            // phpstop
            // 
            this.phpstop.Location = new System.Drawing.Point(290, 33);
            this.phpstop.Name = "phpstop";
            this.phpstop.Size = new System.Drawing.Size(116, 59);
            this.phpstop.TabIndex = 0;
            this.phpstop.Text = "Stop";
            this.phpstop.UseVisualStyleBackColor = true;
            this.phpstop.Click += new System.EventHandler(this.phpstop_Click);
            this.phpstop.MouseHover += new System.EventHandler(this.phpstop_MouseHover);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.mysqlhelp);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.textBox3);
            this.tabPage4.Controls.Add(this.mysqlstop);
            this.tabPage4.Controls.Add(this.mysqlstart);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(463, 165);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "MySQL";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // mysqlhelp
            // 
            this.mysqlhelp.Location = new System.Drawing.Point(435, 6);
            this.mysqlhelp.Name = "mysqlhelp";
            this.mysqlhelp.Size = new System.Drawing.Size(22, 23);
            this.mysqlhelp.TabIndex = 10;
            this.mysqlhelp.Text = "?";
            this.mysqlhelp.UseVisualStyleBackColor = true;
            this.mysqlhelp.Click += new System.EventHandler(this.mysqlhelp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "* Only needed when stopping MySQL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Enter MySQL Password:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(290, 111);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(116, 20);
            this.textBox3.TabIndex = 7;
            // 
            // mysqlstop
            // 
            this.mysqlstop.Location = new System.Drawing.Point(290, 33);
            this.mysqlstop.Name = "mysqlstop";
            this.mysqlstop.Size = new System.Drawing.Size(116, 59);
            this.mysqlstop.TabIndex = 1;
            this.mysqlstop.Text = "Stop";
            this.mysqlstop.UseVisualStyleBackColor = true;
            this.mysqlstop.Click += new System.EventHandler(this.mysqlstop_Click);
            this.mysqlstop.MouseHover += new System.EventHandler(this.mysqlstop_MouseHover);
            // 
            // mysqlstart
            // 
            this.mysqlstart.Location = new System.Drawing.Point(51, 33);
            this.mysqlstart.Name = "mysqlstart";
            this.mysqlstart.Size = new System.Drawing.Size(116, 59);
            this.mysqlstart.TabIndex = 0;
            this.mysqlstart.Text = "Start";
            this.mysqlstart.UseVisualStyleBackColor = true;
            this.mysqlstart.Click += new System.EventHandler(this.mysqlstart_Click);
            this.mysqlstart.MouseHover += new System.EventHandler(this.mysqlstart_MouseHover);
            // 
            // icon
            // 
            this.icon.Icon = ((System.Drawing.Icon)(resources.GetObject("icon.Icon")));
            this.icon.Text = "Wnmp";
            this.icon.Visible = true;
            this.icon.Click += new System.EventHandler(this.icon_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(471, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.websiteToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 215);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(487, 253);
            this.MinimumSize = new System.Drawing.Size(487, 253);
            this.Name = "Main";
            this.Text = "Wnmp";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.Button nginxreload;
        private System.Windows.Forms.Button nginxstop;
        private System.Windows.Forms.Button nginxstart;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button phpstop;
        private System.Windows.Forms.Button phpstart;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.Button mysqlstop;
        private System.Windows.Forms.Button mysqlstart;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mysqlpass;
        private System.Windows.Forms.Button mysqlhelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;

    }
}

