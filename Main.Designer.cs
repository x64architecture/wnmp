/*
This file is part of Wnmp.

    Wnmp is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Wnmp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
*/
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
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wnmpOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nginxreload = new System.Windows.Forms.Button();
            this.phplogs = new System.Windows.Forms.Button();
            this.mariadblogs = new System.Windows.Forms.Button();
            this.nginxlogs = new System.Windows.Forms.Button();
            this.PHPCFG = new System.Windows.Forms.Button();
            this.MariaDBCFG = new System.Windows.Forms.Button();
            this.ngxconfig = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.phprunning = new System.Windows.Forms.Label();
            this.mariadbrunning = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nginxrunning = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mysqlhelp = new System.Windows.Forms.Button();
            this.mysqlstop = new System.Windows.Forms.Button();
            this.mysqlstart = new System.Windows.Forms.Button();
            this.phpstart = new System.Windows.Forms.Button();
            this.phpstop = new System.Windows.Forms.Button();
            this.nginxstart = new System.Windows.Forms.Button();
            this.nginxstop = new System.Windows.Forms.Button();
            this.opnmysqlshell = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wnmpdir = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip6 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.websiteToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.wnmpOptionsToolStripMenuItem});
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
            // wnmpOptionsToolStripMenuItem
            // 
            this.wnmpOptionsToolStripMenuItem.Name = "wnmpOptionsToolStripMenuItem";
            this.wnmpOptionsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.wnmpOptionsToolStripMenuItem.Text = "Wnmp Options";
            this.wnmpOptionsToolStripMenuItem.Click += new System.EventHandler(this.wnmpOptionsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nginxreload);
            this.groupBox1.Controls.Add(this.phplogs);
            this.groupBox1.Controls.Add(this.mariadblogs);
            this.groupBox1.Controls.Add(this.nginxlogs);
            this.groupBox1.Controls.Add(this.PHPCFG);
            this.groupBox1.Controls.Add(this.MariaDBCFG);
            this.groupBox1.Controls.Add(this.ngxconfig);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.phprunning);
            this.groupBox1.Controls.Add(this.mariadbrunning);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nginxrunning);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mysqlhelp);
            this.groupBox1.Controls.Add(this.mysqlstop);
            this.groupBox1.Controls.Add(this.mysqlstart);
            this.groupBox1.Controls.Add(this.phpstart);
            this.groupBox1.Controls.Add(this.phpstop);
            this.groupBox1.Controls.Add(this.nginxstart);
            this.groupBox1.Controls.Add(this.nginxstop);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 175);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applications";
            // 
            // nginxreload
            // 
            this.nginxreload.Location = new System.Drawing.Point(276, 45);
            this.nginxreload.Name = "nginxreload";
            this.nginxreload.Size = new System.Drawing.Size(50, 28);
            this.nginxreload.TabIndex = 76;
            this.nginxreload.Text = "Reload";
            this.nginxreload.UseVisualStyleBackColor = true;
            this.nginxreload.Click += new System.EventHandler(this.nginxreload_Click);
            this.nginxreload.MouseHover += new System.EventHandler(this.nginxreload_MouseHover);
            // 
            // phplogs
            // 
            this.phplogs.Location = new System.Drawing.Point(388, 126);
            this.phplogs.Name = "phplogs";
            this.phplogs.Size = new System.Drawing.Size(50, 28);
            this.phplogs.TabIndex = 75;
            this.phplogs.Text = "Logs";
            this.phplogs.UseVisualStyleBackColor = true;
            this.phplogs.Click += new System.EventHandler(this.phplogs_Click);
            // 
            // mariadblogs
            // 
            this.mariadblogs.Location = new System.Drawing.Point(388, 83);
            this.mariadblogs.Name = "mariadblogs";
            this.mariadblogs.Size = new System.Drawing.Size(50, 28);
            this.mariadblogs.TabIndex = 74;
            this.mariadblogs.Text = "Logs";
            this.mariadblogs.UseVisualStyleBackColor = true;
            this.mariadblogs.Click += new System.EventHandler(this.mariadblogs_Click);
            // 
            // nginxlogs
            // 
            this.nginxlogs.Location = new System.Drawing.Point(388, 45);
            this.nginxlogs.Name = "nginxlogs";
            this.nginxlogs.Size = new System.Drawing.Size(50, 28);
            this.nginxlogs.TabIndex = 73;
            this.nginxlogs.Text = "Logs";
            this.nginxlogs.UseVisualStyleBackColor = true;
            this.nginxlogs.Click += new System.EventHandler(this.nginxlogs_Click);
            // 
            // PHPCFG
            // 
            this.PHPCFG.Location = new System.Drawing.Point(332, 126);
            this.PHPCFG.Name = "PHPCFG";
            this.PHPCFG.Size = new System.Drawing.Size(50, 28);
            this.PHPCFG.TabIndex = 72;
            this.PHPCFG.Text = "Config";
            this.PHPCFG.UseVisualStyleBackColor = true;
            this.PHPCFG.Click += new System.EventHandler(this.PHPCFG_Click);
            // 
            // MariaDBCFG
            // 
            this.MariaDBCFG.Location = new System.Drawing.Point(332, 83);
            this.MariaDBCFG.Name = "MariaDBCFG";
            this.MariaDBCFG.Size = new System.Drawing.Size(50, 28);
            this.MariaDBCFG.TabIndex = 71;
            this.MariaDBCFG.Text = "Config";
            this.MariaDBCFG.UseVisualStyleBackColor = true;
            this.MariaDBCFG.Click += new System.EventHandler(this.MariaDBCFG_Click);
            // 
            // ngxconfig
            // 
            this.ngxconfig.Location = new System.Drawing.Point(332, 45);
            this.ngxconfig.Name = "ngxconfig";
            this.ngxconfig.Size = new System.Drawing.Size(50, 28);
            this.ngxconfig.TabIndex = 70;
            this.ngxconfig.Text = "Config";
            this.ngxconfig.UseVisualStyleBackColor = true;
            this.ngxconfig.Click += new System.EventHandler(this.ngxconfig_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(79, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 69;
            this.label8.Text = "PHP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(79, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 68;
            this.label7.Text = "MariaDB";
            // 
            // phprunning
            // 
            this.phprunning.AutoSize = true;
            this.phprunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phprunning.ForeColor = System.Drawing.Color.DarkRed;
            this.phprunning.Location = new System.Drawing.Point(22, 135);
            this.phprunning.Name = "phprunning";
            this.phprunning.Size = new System.Drawing.Size(21, 20);
            this.phprunning.TabIndex = 67;
            this.phprunning.Text = "X";
            // 
            // mariadbrunning
            // 
            this.mariadbrunning.AutoSize = true;
            this.mariadbrunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mariadbrunning.ForeColor = System.Drawing.Color.DarkRed;
            this.mariadbrunning.Location = new System.Drawing.Point(22, 91);
            this.mariadbrunning.Name = "mariadbrunning";
            this.mariadbrunning.Size = new System.Drawing.Size(21, 20);
            this.mariadbrunning.TabIndex = 66;
            this.mariadbrunning.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(79, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 63;
            this.label4.Text = "Nginx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Application";
            // 
            // nginxrunning
            // 
            this.nginxrunning.AutoSize = true;
            this.nginxrunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nginxrunning.ForeColor = System.Drawing.Color.DarkRed;
            this.nginxrunning.Location = new System.Drawing.Point(22, 47);
            this.nginxrunning.Name = "nginxrunning";
            this.nginxrunning.Size = new System.Drawing.Size(21, 20);
            this.nginxrunning.TabIndex = 61;
            this.nginxrunning.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Running";
            // 
            // mysqlhelp
            // 
            this.mysqlhelp.Location = new System.Drawing.Point(276, 83);
            this.mysqlhelp.Name = "mysqlhelp";
            this.mysqlhelp.Size = new System.Drawing.Size(50, 28);
            this.mysqlhelp.TabIndex = 59;
            this.mysqlhelp.Text = "?";
            this.mysqlhelp.UseVisualStyleBackColor = true;
            this.mysqlhelp.Click += new System.EventHandler(this.mysqlhelp_Click);
            // 
            // mysqlstop
            // 
            this.mysqlstop.Location = new System.Drawing.Point(220, 82);
            this.mysqlstop.Name = "mysqlstop";
            this.mysqlstop.Size = new System.Drawing.Size(50, 28);
            this.mysqlstop.TabIndex = 57;
            this.mysqlstop.Text = "Stop";
            this.mysqlstop.UseVisualStyleBackColor = true;
            this.mysqlstop.Click += new System.EventHandler(this.mysqlstop_Click);
            this.mysqlstop.MouseHover += new System.EventHandler(this.mysqlstop_MouseHover);
            // 
            // mysqlstart
            // 
            this.mysqlstart.Location = new System.Drawing.Point(164, 82);
            this.mysqlstart.Name = "mysqlstart";
            this.mysqlstart.Size = new System.Drawing.Size(50, 28);
            this.mysqlstart.TabIndex = 56;
            this.mysqlstart.Text = "Start";
            this.mysqlstart.UseVisualStyleBackColor = true;
            this.mysqlstart.Click += new System.EventHandler(this.mysqlstart_Click);
            this.mysqlstart.MouseHover += new System.EventHandler(this.mysqlstart_MouseHover);
            // 
            // phpstart
            // 
            this.phpstart.Location = new System.Drawing.Point(164, 127);
            this.phpstart.Name = "phpstart";
            this.phpstart.Size = new System.Drawing.Size(50, 28);
            this.phpstart.TabIndex = 55;
            this.phpstart.Text = "Start";
            this.phpstart.UseVisualStyleBackColor = true;
            this.phpstart.Click += new System.EventHandler(this.phpstart_Click);
            this.phpstart.MouseHover += new System.EventHandler(this.phpstart_MouseHover);
            // 
            // phpstop
            // 
            this.phpstop.Location = new System.Drawing.Point(220, 127);
            this.phpstop.Name = "phpstop";
            this.phpstop.Size = new System.Drawing.Size(50, 28);
            this.phpstop.TabIndex = 54;
            this.phpstop.Text = "Stop";
            this.phpstop.UseVisualStyleBackColor = true;
            this.phpstop.Click += new System.EventHandler(this.phpstop_Click);
            this.phpstop.MouseHover += new System.EventHandler(this.phpstop_MouseHover);
            // 
            // nginxstart
            // 
            this.nginxstart.Location = new System.Drawing.Point(164, 45);
            this.nginxstart.Name = "nginxstart";
            this.nginxstart.Size = new System.Drawing.Size(50, 28);
            this.nginxstart.TabIndex = 53;
            this.nginxstart.Text = "Start";
            this.nginxstart.UseVisualStyleBackColor = true;
            this.nginxstart.Click += new System.EventHandler(this.nginxstart_Click);
            this.nginxstart.MouseHover += new System.EventHandler(this.nginxstart_MouseHover);
            // 
            // nginxstop
            // 
            this.nginxstop.Location = new System.Drawing.Point(220, 45);
            this.nginxstop.Name = "nginxstop";
            this.nginxstop.Size = new System.Drawing.Size(50, 28);
            this.nginxstop.TabIndex = 52;
            this.nginxstop.Text = "Stop";
            this.nginxstop.UseVisualStyleBackColor = true;
            this.nginxstop.Click += new System.EventHandler(this.nginxstop_Click);
            this.nginxstop.MouseHover += new System.EventHandler(this.nginxstop_MouseHover);
            // 
            // opnmysqlshell
            // 
            this.opnmysqlshell.Location = new System.Drawing.Point(576, 93);
            this.opnmysqlshell.Name = "opnmysqlshell";
            this.opnmysqlshell.Size = new System.Drawing.Size(63, 49);
            this.opnmysqlshell.TabIndex = 58;
            this.opnmysqlshell.Text = "Open MySQL Shell";
            this.opnmysqlshell.UseVisualStyleBackColor = true;
            this.opnmysqlshell.Click += new System.EventHandler(this.opnmysqlshell_Click);
            this.opnmysqlshell.MouseHover += new System.EventHandler(this.opnmysqlshell_MouseHover);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(576, 3);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(63, 36);
            this.start.TabIndex = 49;
            this.start.Text = "Start all";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            this.start.MouseHover += new System.EventHandler(this.start_MouseHover);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(576, 51);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(63, 36);
            this.stop.TabIndex = 50;
            this.stop.Text = "Stop all";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            this.stop.MouseHover += new System.EventHandler(this.stop_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wnmpdir);
            this.panel1.Controls.Add(this.output);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.start);
            this.panel1.Controls.Add(this.stop);
            this.panel1.Controls.Add(this.opnmysqlshell);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 340);
            this.panel1.TabIndex = 5;
            // 
            // wnmpdir
            // 
            this.wnmpdir.Location = new System.Drawing.Point(576, 148);
            this.wnmpdir.Name = "wnmpdir";
            this.wnmpdir.Size = new System.Drawing.Size(63, 40);
            this.wnmpdir.TabIndex = 59;
            this.wnmpdir.Text = "Wnmp Directory";
            this.wnmpdir.UseVisualStyleBackColor = true;
            this.wnmpdir.Click += new System.EventHandler(this.wnmpdir_Click);
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.Color.White;
            this.output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.Location = new System.Drawing.Point(0, 200);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(645, 139);
            this.output.TabIndex = 49;
            this.output.Text = "";
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip5
            // 
            this.contextMenuStrip5.Name = "contextMenuStrip5";
            this.contextMenuStrip5.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip6
            // 
            this.contextMenuStrip6.Name = "contextMenuStrip6";
            this.contextMenuStrip6.Size = new System.Drawing.Size(61, 4);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 364);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(664, 402);
            this.MinimumSize = new System.Drawing.Size(664, 402);
            this.Name = "Main";
            this.Text = "Wnmp";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nginxrunning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mysqlhelp;
        private System.Windows.Forms.Button opnmysqlshell;
        private System.Windows.Forms.Button mysqlstop;
        private System.Windows.Forms.Button mysqlstart;
        private System.Windows.Forms.Button phpstart;
        private System.Windows.Forms.Button phpstop;
        private System.Windows.Forms.Button nginxstart;
        private System.Windows.Forms.Button nginxstop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label phprunning;
        private System.Windows.Forms.Label mariadbrunning;
        private System.Windows.Forms.Button ngxconfig;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button PHPCFG;
        private System.Windows.Forms.Button MariaDBCFG;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem wnmpOptionsToolStripMenuItem;
        private System.Windows.Forms.Button phplogs;
        private System.Windows.Forms.Button mariadblogs;
        private System.Windows.Forms.Button nginxlogs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip6;
        private System.Windows.Forms.Button wnmpdir;
        private System.Windows.Forms.Button nginxreload;

    }
}

