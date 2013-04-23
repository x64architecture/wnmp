using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;

namespace Wnmp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
/////////////////////////Wnmp Stuff////////////////////////////////////////////////////////////////

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                icon.BalloonTipTitle = "Wnmp";
                icon.BalloonTipText = "Wnmp has been minimized to the taskbar.";
                icon.ShowBalloonTip(3000);
            }
        }

        private void icon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName("Wnmp");
            Process current = Process.GetCurrentProcess();
            foreach (Process p in process)
            {
                if (p.Id != current.Id)
                    p.Kill();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wnmp makes an easy Nginx, MySQL and PHP enviorment for Windows." + "\n" + "Created by Kurt Cancemi");
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wnmp.x64Architecture.com");
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=P7LAQRRNF6AVE");
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Cannot connect to the update server");
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
                MessageBox.Show("Your version: " + applicationVersion + "  is up to date.", "Check for Updates", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

///////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////General///////////////////////////////////////////////////////////////////

        private void start_MouseHover(object sender, EventArgs e)
        {
            ToolTip start_all_Tip = new ToolTip();
            start_all_Tip.Show("Starts Nginx, PHP-CGI & MySQL", start);
        }

        private void stop_MouseHover(object sender, EventArgs e)
        {
            ToolTip stop_all_Tip = new ToolTip();
            stop_all_Tip.Show("Stops Nginx, PHP-CGI & MySQL", stop);
        }

        private void start_Click(object sender, EventArgs e)
        {
            string[] prgs = new string[3];
            prgs[0] = @"nginx.exe";
            prgs[1] = @"php/php-cgi.exe";
            prgs[2] = @"mariadb/bin/mysqld.exe";
            try
            {
                //Create process
                System.Diagnostics.Process nginxs = new System.Diagnostics.Process();
                //arr4[0] is path and file name of command to run
                nginxs.StartInfo.FileName = prgs[0].ToString();
                nginxs.StartInfo.UseShellExecute = false;
                //Set output of program to be written to process output stream
                nginxs.StartInfo.RedirectStandardOutput = true;
                nginxs.StartInfo.WorkingDirectory = Application.StartupPath;
                nginxs.StartInfo.CreateNoWindow = true; //Excute with no window
                nginxs.Start(); //Start the process
                //PHP
                System.Threading.Thread.Sleep(100); //Wait
                System.Diagnostics.Process phps = new System.Diagnostics.Process(); //Create process
                phps.StartInfo.FileName = prgs[1].ToString(); //arr4[1] is path and file name of command to run
                phps.StartInfo.Arguments = "-b localhost:9000"; //Parameters to pass to program
                phps.StartInfo.UseShellExecute = false;
                phps.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                phps.StartInfo.WorkingDirectory = Application.StartupPath;
                phps.StartInfo.CreateNoWindow = true; //Excute with no window
                phps.Start(); //Start the process
                System.Threading.Thread.Sleep(100); //Wait
                //MariaDB
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = prgs[2].ToString();
                mariadb.StartInfo.UseShellExecute = false;
                mariadb.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.StartInfo.CreateNoWindow = true; //Excute with no window
                mariadb.Start(); //Start the process
                mysqlpass.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            string[] prgs = new string[3];
            prgs[0] = @"nginx.exe";
            prgs[1] = @"php/php-cgi.exe";
            prgs[2] = @"mariadb/bin/mysqladmin.exe";
            try
            {
                //Create process
                System.Diagnostics.Process nginxs = new System.Diagnostics.Process();
                //arr4[0] is path and file name of command to run
                nginxs.StartInfo.FileName = prgs[0].ToString();
                nginxs.StartInfo.Arguments = "-s stop";
                nginxs.StartInfo.UseShellExecute = false;
                //Set output of program to be written to process output stream
                nginxs.StartInfo.RedirectStandardOutput = true;
                nginxs.StartInfo.WorkingDirectory = Application.StartupPath;
                nginxs.StartInfo.CreateNoWindow = true; //Execute with no window
                nginxs.Start(); //Start the process
                //PHP
                try
                {
                    Process[] phps = System.Diagnostics.Process.GetProcessesByName("php-cgi");
                    foreach (Process currentProc in phps)
                    {
                        currentProc.Kill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                //MariaDB
                if (mysqlpass.Text == "")
                {
                    MessageBox.Show("Enter your MySQL password");
                }
                else
                {
                    System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                    mariadb.StartInfo.FileName = prgs[2].ToString();
                    mariadb.StartInfo.Arguments = "-u root -p " + mysqlpass.Text + "shutdown";
                    mariadb.StartInfo.UseShellExecute = false;
                    mariadb.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                    mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                    mariadb.StartInfo.CreateNoWindow = true;
                    mariadb.Start(); //Start the process
                    mysqlpass.ResetText();
                    mysqlpass.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////Nginx/////////////////////////////////////////////////////////////////////

        private void nginxreload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process nginx = new System.Diagnostics.Process(); //Create process
                nginx.StartInfo.FileName = "nginx.exe";
                nginx.StartInfo.Arguments = "-s reload";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void nginxstop_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process nginx = new System.Diagnostics.Process(); //Create process
                nginx.StartInfo.FileName = "nginx.exe";
                nginx.StartInfo.Arguments = "-s stop";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void nginxstart_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process nginx = new System.Diagnostics.Process(); //Create process
                nginx.StartInfo.FileName = "nginx.exe";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void nginxreload_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_reload_Tip = new ToolTip();
            nginx_reload_Tip.Show("Reloads Nginx configuration without restart", nginxreload);
        }

        private void nginxstop_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_stop_Tip = new ToolTip();
            nginx_stop_Tip.Show("Stop Nginx", nginxstop);
        }

        private void nginxstart_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_start_Tip = new ToolTip();
            nginx_start_Tip.Show("Start Nginx", nginxstart);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////PHP///////////////////////////////////////////////////////////////////////
        private void phpstart_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process start = new System.Diagnostics.Process();
                start.StartInfo.FileName = @"php/php-cgi.exe";
                start.StartInfo.Arguments = "-b localhost:9000";
                start.StartInfo.RedirectStandardError = true;
                start.StartInfo.RedirectStandardOutput = true;
                start.StartInfo.UseShellExecute = false;
                start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                start.Start();
                start.CloseMainWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void phpstop_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] phps = System.Diagnostics.Process.GetProcessesByName("php-cgi");
                foreach (Process currentProc in phps)
                {
                    currentProc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void phpstart_MouseHover(object sender, EventArgs e)
        {
            ToolTip mysql_start_Tip = new ToolTip();
            mysql_start_Tip.Show("Start PHP-CGI", phpstart);
        }

        private void phpstop_MouseHover(object sender, EventArgs e)
        {
            ToolTip mysql_stop_Tip = new ToolTip();
            mysql_stop_Tip.Show("Stop PHP-CGI", phpstop);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////MySQL/////////////////////////////////////////////////////////////////////

        private void mysqlstart_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = @"mariadb\bin\mysqld.exe";
                mariadb.StartInfo.UseShellExecute = false;
                mariadb.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.StartInfo.CreateNoWindow = true;
                mariadb.Start(); //Start the process
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void mysqlstop_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter your MySQL password");
            }
            else
            {
                try
                {
                    System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                    mariadb.StartInfo.FileName = @"mariadb/bin/mysqladmin.exe";
                    mariadb.StartInfo.Arguments = "-u root -p " + textBox3.Text + "shutdown";
                    mariadb.StartInfo.UseShellExecute = false;
                    mariadb.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                    mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                    mariadb.StartInfo.CreateNoWindow = true;
                    mariadb.Start(); //Start the process
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void mysqlstart_MouseHover(object sender, EventArgs e)
        {
            ToolTip mysql_start_Tip = new ToolTip();
            mysql_start_Tip.Show("Start MySQL", mysqlstart);
        }

        private void mysqlstop_MouseHover(object sender, EventArgs e)
        {
            ToolTip mysql_stop_Tip = new ToolTip();
            mysql_stop_Tip.Show("Stop MySQL", mysqlstop);
        }

        private void mysqlhelp_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("The default login for MySQL/phpMyAdmin is:" + "\n" + "Username: root" + "\n" + "Password: password");
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
