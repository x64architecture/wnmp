/*
Copyright (C) Kurt Cancemi

This file is part of Wnmp.

    Wnmp is free software: you can redistribute it and/or modify
    it under the terms of the GNU Wnmp Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Wnmp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Wnmp Public License for more details.

    You should have received a copy of the GNU Wnmp Public License
    along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;

namespace Wnmp
{
    class WnmpFunctions
    {
        #region checkforapps
        internal static void checkforapps()
        {
            Log.wnmp_log_notice("Checking for applications", Log.LogSection.WNMP_MAIN);
            if (!File.Exists(@Application.StartupPath + "/nginx.exe"))
                Log.wnmp_log_error("Error: Nginx Not Found", Log.LogSection.WNMP_NGINX);

            if (!Directory.Exists(@Application.StartupPath + @"/mariadb"))
                Log.wnmp_log_error("Error: MariaDB Not Found", Log.LogSection.WNMP_MARIADB);

            if (!Directory.Exists(@Application.StartupPath + @"/php"))
                Log.wnmp_log_error("Error: PHP Not Found", Log.LogSection.WNMP_PHP);
        }
        #endregion checkforapps

        internal static void startup()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Windows Version: " + OSVersionInfo.Name + " " + OSVersionInfo.Edition);
            if (OSVersionInfo.ServicePack != "")
                sb.Append(" " + OSVersionInfo.ServicePack);
            Log.wnmp_log_notice("Control Panel Version: " + Program.formInstance.CPVER, Log.LogSection.WNMP_MAIN);
            Log.wnmp_log_notice("Wnmp Version: " + Program.formInstance.ProductVersion, Log.LogSection.WNMP_MAIN);
            Log.wnmp_log_notice(sb.ToString(), Log.LogSection.WNMP_MAIN);
            Log.wnmp_log_notice("Wnmp Directory: " + Application.StartupPath, Log.LogSection.WNMP_MAIN);
            checkforapps();
            cifpsr();
            Log.wnmp_log_notice("Wnmp ready to go!", Log.LogSection.WNMP_MAIN);

            if (Wnmp.Properties.Settings.Default.startaprgssu == true)
            {
                General.start_Click(null, null);
            }
        }

        #region Context
        private static void ctx2button(object sender, EventArgs e, int button)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            switch (button)
            {
                case 0:
                    Program.formInstance.ngx_conf.Show(ptLowerLeft);
                    break;
                case 1:
                    Program.formInstance.mdb_conf.Show(ptLowerLeft);
                    break;
                case 2:
                    Program.formInstance.php_conf.Show(ptLowerLeft);
                    break;
                case 3:
                    Program.formInstance.logs.Show(ptLowerLeft);
                    break;
                case 4:
                    Program.formInstance.mdb_logs.Show(ptLowerLeft);
                    break;
                case 5:
                    Program.formInstance.php_logs.Show(ptLowerLeft);
                    break;
            }
        }
        internal static void ngx_config_Click(object sender, EventArgs e)
        {
            ctx2button(sender, e, 0);
        }
        static void ngx_conf_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/conf/" + Args.ClickedItem.Text);
        }

        internal static void mdb_cfg_Click(object sender, EventArgs e)
        {
            ctx2button(sender, e, 1);
        }
        static void mdb_conf_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/mariadb/" + Args.ClickedItem.Text);
        }

        internal static void php_cfg_Click(object sender, EventArgs e)
        {
            ctx2button(sender, e, 2);
        }
        static void php_conf_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/php/" + Args.ClickedItem.Text);
        }
        internal static void ngx_log_Click(object sender, EventArgs e)
        {
            ctx2button(sender, e, 3);
        }
        static void logs_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/logs/" + Args.ClickedItem.Text);
        }
        internal static void mdb_log_Click(object sender, EventArgs e)
        {
            ctx2button(sender, e, 4);
        }
        static void mdb_logs_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/mariadb/data/" + Args.ClickedItem.Text);
        }
        internal static void php_log_Click(object sender, EventArgs e)
        {
            ctx2button(sender, e, 5);
        }
        static void php_logs_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/php/logs/" + Args.ClickedItem.Text);
        }
        #endregion Context

        #region ContextMenus
        internal static void DirFiles(string path, string GetFiles, int ctxmenu)
        {
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@Application.StartupPath + path);
                FileInfo[] Files = dinfo.GetFiles(GetFiles);
                foreach (FileInfo file in Files)
                {
                    switch (ctxmenu)
                    {
                        case 0:
                            Program.formInstance.ngx_conf.Items.Add(file.Name);
                            break;
                        case 1:
                            Program.formInstance.mdb_conf.Items.Add(file.Name);
                            break;
                        case 2:
                            Program.formInstance.php_conf.Items.Add(file.Name);
                            break;
                        case 3:
                            Program.formInstance.logs.Items.Add(file.Name);
                            break;
                        case 4:
                            Program.formInstance.mdb_logs.Items.Add(file.Name);
                            break;
                        case 5:
                            Program.formInstance.php_logs.Items.Add(file.Name);
                            break;
                    }
                }
                Program.formInstance.ngx_conf.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(ngx_conf_ItemClicked);
                Program.formInstance.mdb_conf.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(mdb_conf_ItemClicked);
                Program.formInstance.php_conf.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(php_conf_ItemClicked);
                Program.formInstance.logs.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(logs_ItemClicked);
                Program.formInstance.mdb_logs.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(mdb_logs_ItemClicked);
                Program.formInstance.php_logs.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(php_logs_ItemClicked);
            }
            catch { }
        }

        #endregion ContextMenus

        internal static void timer1_Tick()
        {
            cifpsr();
        }
        internal static void cifpsr()
        {
            Process[] phps = Process.GetProcessesByName("php-cgi");
            if (phps.Length == 0)
            {
                Program.formInstance.phprunning.Text = "X";
                Program.formInstance.phprunning.ForeColor = Color.DarkRed;
            }
            else
            {
                Program.formInstance.phprunning.Text = "\u221A";
                Program.formInstance.phprunning.ForeColor = Color.Green;
            }
            Process[] nginxs = Process.GetProcessesByName("nginx");
            if (nginxs.Length == 0)
            {
                Program.formInstance.nginxrunning.Text = "X";
                Program.formInstance.nginxrunning.ForeColor = Color.DarkRed;
            }
            else
            {
                Program.formInstance.nginxrunning.Text = "\u221A";
                Program.formInstance.nginxrunning.ForeColor = Color.Green;
            }
            Process[] mariadbs = Process.GetProcessesByName("mysqld");
            if (mariadbs.Length == 0)
            {
                Program.formInstance.mariadbrunning.Text = "X";
                Program.formInstance.mariadbrunning.ForeColor = Color.DarkRed;
            }
            else
            {
                Program.formInstance.mariadbrunning.Text = "\u221A";
                Program.formInstance.mariadbrunning.ForeColor = Color.Green;
            }
        }
        internal static void cfa()
        {
            string[] processtokill = { "php-cgi", "nginx", "mysqld" };
            Process[] processes = Process.GetProcesses();

            for (int i = 0; i < processes.Length; i++)
            {
                for (int j = 0; j < processtokill.Length; j++)
                {
                    try
                    {
                        string tempProcess = processes[i].ProcessName;

                        if (tempProcess == processtokill[j]) // If the proccess is the proccess we want to kill
                        {
                            processes[i].Kill(); break; // Kill the proccess
                        }
                    }
                    catch { }
                }
            }
        }
    }
}