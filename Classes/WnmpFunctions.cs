/*
Copyright (C) Kurt Cancemi

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
        #region checkforupdates
        internal static void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string downloadUrl = "";
            Version newVersion = null;
            string aboutUpdate = "";
            string xmlUrl = "https://windows-nginx-mysql-php.googlecode.com/git-history/master/update.xml";
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(xmlUrl);
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "appinfo"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                                switch (elementName)
                                {
                                    case "version":
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        downloadUrl = reader.Value;
                                        break;
                                    case "about":
                                        aboutUpdate = reader.Value;
                                        break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == ("The remote name could not be resolved: 'windows-nginx-mysql-php.googlecode.com'"))
                {
                    MessageBox.Show("Couldn't connect to the update server");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (applicationVersion.CompareTo(newVersion) < 0)
            {
                string str = String.Format("New version found!\nYour version: {0}.\nNewest version: {1}. \nAdded in this version: {2}. ", applicationVersion, newVersion, aboutUpdate);
                if (DialogResult.No != MessageBox.Show(str + "\nWould you like to download this update?", "Check for updates", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        Process.Start(downloadUrl);
                    }
                    catch { }
                    return;
                }
                else
                {
                    ;
                }
            }
            else
            {
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Your version: " + applicationVersion + "  is up to date.");
            }
        }
        #endregion checkforupdates

        #region checkforapps
        internal static void checkforapps()
        {
            if (File.Exists(@Application.StartupPath + "/nginx.exe") == false)
            {
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [nginx]" + "                  Error: Nginx Not Found");
                string searchText = "Nginx";
                int pos = 0;
                pos = Program.formInstance.output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
                while (pos != -1)
                {
                    if (Program.formInstance.output.SelectedText == searchText && Program.formInstance.output.SelectedText != "")
                    {
                        Program.formInstance.output.SelectionLength = searchText.Length;
                        Program.formInstance.output.SelectionFont = new Font("arial", 10);
                        Program.formInstance.output.SelectionColor = Color.Red;
                    }
                    pos = Program.formInstance.output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
                }
            }
            if (Directory.Exists(@Application.StartupPath + @"/mariadb") == false)
            {
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [mariadb]" + "             Error: MariaDB Not Found");
                string searchText = "MariaDB";
                int pos = 0;
                pos = Program.formInstance.output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
                while (pos != -1)
                {
                    if (Program.formInstance.output.SelectedText == searchText && Program.formInstance.output.SelectedText != "")
                    {
                        Program.formInstance.output.SelectionLength = searchText.Length;
                        Program.formInstance.output.SelectionFont = new Font("arial", 10);
                        Program.formInstance.output.SelectionColor = Color.Red;
                    }
                    pos = Program.formInstance.output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
                }
            }
            if (Directory.Exists(@Application.StartupPath + @"/php") == false)
            {
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [php]" + "                     Error: PHP Not Found");
                string searchText = "php";
                int pos = 0;
                pos = Program.formInstance.output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
                while (pos != -1)
                {
                    if (Program.formInstance.output.SelectedText == searchText && Program.formInstance.output.SelectedText != "")
                    {
                        Program.formInstance.output.SelectionLength = searchText.Length;
                        Program.formInstance.output.SelectionFont = new Font("arial", 10);
                        Program.formInstance.output.SelectionColor = Color.Red;
                    }
                    pos = Program.formInstance.output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
                }
            }
        }
        #endregion checkforapps

        internal static void startup()
        {
            string OSI = OSInfo.OSVersionInfo.Name + " " + OSInfo.OSVersionInfo.Edition + " ";
            Program.formInstance.output.AppendText(DateTime.Now.ToString() + " [Wnmp Main]" + "     Initializing Control Panel");
            Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Wnmp Version: " + Program.formInstance.ProductVersion);
            Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     " + "Windows Version: " + OSI);
            if (OSInfo.OSVersionInfo.ServicePack != string.Empty)
            {
                Program.formInstance.output.AppendText(String.Format(OSInfo.OSVersionInfo.ServicePack));
            }
            else
            {
                Program.formInstance.output.AppendText("");
            }
            Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Wnmp Directory: " + @Application.StartupPath);
            Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Checking for applications");
            checkforapps();
            Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Wnmp Ready to go!");
            Program.formInstance.output.ScrollToCaret();
        }

        #region Context
        internal static void ngxconfig_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            Program.formInstance.contextMenuStrip1.Show(ptLowerLeft);
        }
        static void contextMenuStrip12_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/conf/" + Args.ClickedItem.Text);
        }

        internal static void MariaDBCFG_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            Program.formInstance.contextMenuStrip2.Show(ptLowerLeft);
        }
        static void contextMenuStrip13_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/mariadb/data/" + Args.ClickedItem.Text);
        }

        internal static void PHPCFG_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            Program.formInstance.contextMenuStrip3.Show(ptLowerLeft);
        }
        static void contextMenuStrip14_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/php/" + Args.ClickedItem.Text);
        }
        internal static void nginxlogs_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            Program.formInstance.contextMenuStrip4.Show(ptLowerLeft);
        }
        static void contextMenuStrip15_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/logs/" + Args.ClickedItem.Text);
        }
        internal static void mariadblogs_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            Program.formInstance.contextMenuStrip5.Show(ptLowerLeft);
        }
        static void contextMenuStrip16_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/php/logs/" + Args.ClickedItem.Text);
        }
        internal static void phplogs_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            Program.formInstance.contextMenuStrip6.Show(ptLowerLeft);
        }
        static void contextMenuStrip17_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"/mariadb/data/" + Args.ClickedItem.Text);
        }
        #endregion Context

        #region ContextMenus
        internal static void ContextMenus()
        {
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@Application.StartupPath + @"/conf");
                FileInfo[] Files = dinfo.GetFiles("*");
                foreach (FileInfo file in Files)
                {
                    Program.formInstance.contextMenuStrip1.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@Application.StartupPath + @"/mariadb/data");
                FileInfo[] Files = dinfo.GetFiles("*.ini");
                foreach (FileInfo file in Files)
                {
                    Program.formInstance.contextMenuStrip2.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@Application.StartupPath + @"/php");
                FileInfo[] Files = dinfo.GetFiles("php.ini");
                foreach (FileInfo file in Files)
                {
                    Program.formInstance.contextMenuStrip3.Items.Add("php.ini");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@Application.StartupPath + @"/logs");
                FileInfo[] Files = dinfo.GetFiles("*.log");
                foreach (FileInfo file in Files)
                {
                    Program.formInstance.contextMenuStrip4.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@Application.StartupPath + @"/php/logs");
                FileInfo[] Files = dinfo.GetFiles("*.log");
                foreach (FileInfo file in Files)
                {
                    Program.formInstance.contextMenuStrip6.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@Application.StartupPath + @"/mariadb/data");
                FileInfo[] Files = dinfo.GetFiles("*.log");
                foreach (FileInfo file in Files)
                {
                    Program.formInstance.contextMenuStrip5.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Program.formInstance.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip12_ItemClicked);
            Program.formInstance.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip13_ItemClicked);
            Program.formInstance.contextMenuStrip3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip14_ItemClicked);
            Program.formInstance.contextMenuStrip4.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip15_ItemClicked);
            Program.formInstance.contextMenuStrip5.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip16_ItemClicked);
            Program.formInstance.contextMenuStrip6.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip17_ItemClicked);
        }
        #endregion ContextMenus

        internal static void timer1_Tick(object sender, EventArgs e)
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
    }
}
