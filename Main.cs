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
using System.Security.Cryptography;

namespace Wnmp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }
        #region Wnmp Stuff
        private void wnmpdir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Environment.CurrentDirectory);
        }

        private void wnmpOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options form = new Options();
            form.ShowDialog();
            form.Focus();
        }
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

        public void checkforapps()
        {
            if (File.Exists(@Application.StartupPath + "/nginx.exe") == false)
            {
                output.AppendText("\n" + DateTime.Now.ToString() + " [nginx]" + "                  Error: Nginx Not Found");
                string searchText = "Nginx";
                int pos = 0;
                pos = output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
                while (pos != -1)
                {
                    if (output.SelectedText == searchText && output.SelectedText != "")
                    {
                        output.SelectionLength = searchText.Length;
                        output.SelectionFont = new Font("arial", 10);
                        output.SelectionColor = Color.Red;
                    }
                    pos = output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
                }
            }
            if (Directory.Exists(@Application.StartupPath + @"/mariadb") == false)
            {
                output.AppendText("\n" + DateTime.Now.ToString() + " [mariadb]" + "             Error: MariaDB Not Found");
                string searchText = "MariaDB";
                int pos = 0;
                pos = output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
                while (pos != -1)
                {
                    if (output.SelectedText == searchText && output.SelectedText != "")
                    {
                        output.SelectionLength = searchText.Length;
                        output.SelectionFont = new Font("arial", 10);
                        output.SelectionColor = Color.Red;
                    }
                    pos = output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
                }
            }
            if (Directory.Exists(@Application.StartupPath + @"/php") == false)
            {
                output.AppendText("\n" + DateTime.Now.ToString() + " [php]" + "                     Error: PHP Not Found");
                string searchText = "php";
                int pos = 0;
                pos = output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
                while (pos != -1)
                {
                    if (output.SelectedText == searchText && output.SelectedText != "")
                    {
                        output.SelectionLength = searchText.Length;
                        output.SelectionFont = new Font("arial", 10);
                        output.SelectionColor = Color.Red;
                    }
                    pos = output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
                }
            }
        }
        public void startup()
        {
            string OSI = OSInfo.OSVersionInfo.Name + " " + OSInfo.OSVersionInfo.Edition + " ";
            output.AppendText(DateTime.Now.ToString() + " [Wnmp Main]" + "     Initializing Control Panel");
            output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Wnmp Version: " + this.ProductVersion);
            output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     " + "Windows Version: " + OSI);
            if (OSInfo.OSVersionInfo.ServicePack != string.Empty)
            {
                output.AppendText(String.Format(OSInfo.OSVersionInfo.ServicePack));
            }
            else
            {
                output.AppendText("");
            }
            output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Wnmp Directory: " + @Application.StartupPath);
            output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Checking for applications");
            checkforapps();
            output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Wnmp Ready to go!");
            output.ScrollToCaret();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@Application.StartupPath + @"/conf");
                FileInfo[] Files = dinfo.GetFiles("*");
                foreach (FileInfo file in Files)
                {
                    contextMenuStrip1.Items.Add(file.Name);
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
                    contextMenuStrip2.Items.Add(file.Name);
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
                    contextMenuStrip3.Items.Add("php.ini");
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
                    contextMenuStrip4.Items.Add(file.Name);
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
                    contextMenuStrip6.Items.Add(file.Name);
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
                    contextMenuStrip5.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip12_ItemClicked);
            contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip13_ItemClicked);
            contextMenuStrip3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip14_ItemClicked);
            contextMenuStrip4.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip15_ItemClicked);
            contextMenuStrip5.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip16_ItemClicked);
            contextMenuStrip6.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip17_ItemClicked);
            startup();
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
            MessageBox.Show("Wnmp makes an easy Nginx, MySQL and PHP environment for Windows." + "\n" + "Created by Kurt Cancemi");
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wnmp.x64Architecture.com");
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=P7LAQRRNF6AVE");
        }
        #region checkforupdates
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
                output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Your version: " + applicationVersion + "  is up to date.");
            }
        }
        #endregion checkforupdates
        #endregion Wnmp Stuff
        #region general

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
            prgs[0] = @Application.StartupPath + @"/nginx.exe";
            prgs[1] = @Application.StartupPath + @"/php/php-cgi.exe";
            prgs[2] = @Application.StartupPath + @"/mariadb/bin/mysqld.exe";
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
                output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Starting all applications");
                nginxrunning.Text = "\u221A";
                nginxrunning.ForeColor = Color.Green;
                mariadbrunning.Text = "\u221A";
                mariadbrunning.ForeColor = Color.Green;
                phprunning.Text = "\u221A";
                phprunning.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            string[] prgs = new string[3];
            prgs[0] = @Application.StartupPath + @"/nginx.exe";
            prgs[1] = @Application.StartupPath + @"/php/php-cgi.exe";
            prgs[2] = @Application.StartupPath + @"/mariadb/bin/mysqladmin.exe";
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
                System.Threading.Thread.Sleep(100); //Wait
                //MariaDB
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysqladmin.exe";
                mariadb.StartInfo.Arguments = "-u root -p shutdown";
                mariadb.StartInfo.UseShellExecute = true;
                mariadb.StartInfo.RedirectStandardOutput = false; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.Start(); //Start the process
                nginxrunning.Text = "X";
                nginxrunning.ForeColor = Color.DarkRed;
                mariadbrunning.Text = "X";
                mariadbrunning.ForeColor = Color.DarkRed;
                phprunning.Text = "X";
                phprunning.ForeColor = Color.DarkRed;
                output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Stopping all applications");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion general
        #region nginx

        private void nginxreload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process nginx = new System.Diagnostics.Process(); //Create process
                nginx.StartInfo.FileName = @Application.StartupPath + "/nginx.exe";
                nginx.StartInfo.Arguments = "-s reload";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
                output.AppendText("\n" + DateTime.Now.ToString() + " [nginx]" + "                  Attempting to reload Nginx");
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
                nginx.StartInfo.FileName = @Application.StartupPath + "/nginx.exe";
                nginx.StartInfo.Arguments = "-s stop";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
                output.AppendText("\n" + DateTime.Now.ToString() + " [nginx]" + "                  Attempting to stop Nginx");
                nginxrunning.Text = "X";
                nginxrunning.ForeColor = Color.DarkRed;
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
                nginx.StartInfo.FileName = @Application.StartupPath + "/nginx.exe";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
                output.AppendText("\n" + DateTime.Now.ToString() + " [nginx]" + "                  Attempting to start Nginx");
                nginxrunning.Text = "\u221A";
                nginxrunning.ForeColor = Color.Green;
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
        #endregion nginx
        #region PHP
        private void phpstart_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process start = new System.Diagnostics.Process();
                start.StartInfo.FileName = @Application.StartupPath + @"/php/php-cgi.exe";
                start.StartInfo.Arguments = "-b localhost:9000";
                start.StartInfo.RedirectStandardError = true;
                start.StartInfo.RedirectStandardOutput = true;
                start.StartInfo.UseShellExecute = false;
                start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                start.StartInfo.CreateNoWindow = true;
                start.Start();
                start.CloseMainWindow();
                output.AppendText("\n" + DateTime.Now.ToString() + " [php]" + "                     Attempting to start PHP");
                phprunning.Text = "\u221A";
                phprunning.ForeColor = Color.Green;
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
            output.AppendText("\n" + DateTime.Now.ToString() + " [php]" + "                     Attempting to stop PHP");
            phprunning.Text = "X";
            phprunning.ForeColor = Color.DarkRed;
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
        #endregion PHP
        #region MariaDB

        private void mysqlstart_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysqld.exe";
                mariadb.StartInfo.UseShellExecute = false;
                mariadb.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.StartInfo.CreateNoWindow = true;
                mariadb.Start(); //Start the process
                output.AppendText("\n" + DateTime.Now.ToString() + " [mariadb]" + "            Attempting to start MariaDB");
                mariadbrunning.Text = "\u221A";
                mariadbrunning.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void mysqlstop_Click(object sender, EventArgs e)
        {
            try
            {
                //MariaDB
                output.AppendText("\n" + DateTime.Now.ToString() + " [mariadb]" + "            Attempting to stop MariaDB");
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysqladmin.exe";
                mariadb.StartInfo.Arguments = "-u root -p shutdown";
                mariadb.StartInfo.UseShellExecute = true;
                mariadb.StartInfo.RedirectStandardOutput = false; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.Start(); //Start the process
                mariadbrunning.Text = "X";
                mariadbrunning.ForeColor = Color.DarkRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void opnmysqlshell_Click(object sender, EventArgs e)
        {
            try
            {
                //MariaDB
                System.Diagnostics.Process mariadbs = new System.Diagnostics.Process(); //Create process
                mariadbs.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysqld.exe";
                mariadbs.StartInfo.UseShellExecute = false;
                mariadbs.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                mariadbs.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadbs.StartInfo.CreateNoWindow = true;
                mariadbs.Start(); //Start the process
                System.Threading.Thread.Sleep(100); //Wait
                //MariaDB Shell
                output.AppendText("\n" + DateTime.Now.ToString() + " [mariadb]" + "             Attempting to start MariaDB shell");
                System.Diagnostics.Process mariadbsh = new System.Diagnostics.Process(); //Create process
                mariadbsh.StartInfo.FileName = @Directory.GetCurrentDirectory() + @"/mariadb\bin\mysql.exe";
                mariadbsh.StartInfo.Arguments = "-u root -p";
                mariadbsh.StartInfo.UseShellExecute = true;
                mariadbsh.StartInfo.RedirectStandardOutput = false; //Set output of program to be written to process output stream
                mariadbsh.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadbsh.Start(); //Start the process
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
        private void opnmysqlshell_MouseHover(object sender, EventArgs e)
        {
            ToolTip mysql_opnshell_Tip = new ToolTip();
            mysql_opnshell_Tip.Show("Open MySQL Shell", opnmysqlshell);
        }
        private void mysqlhelp_Click(object sender, EventArgs e)
        {

            MessageBox.Show("The default login for MySQL/phpMyAdmin is:" + "\n" + "Username: root" + "\n" + "Password: password");
        }
        #endregion MariaDB
        #region contextmenus
        private void ngxconfig_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
        }
        void contextMenuStrip12_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"conf/" + Args.ClickedItem.Text);
        }

        private void MariaDBCFG_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip2.Show(ptLowerLeft);
        }
        void contextMenuStrip13_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"mariadb/data/" + Args.ClickedItem.Text);
        }

        private void PHPCFG_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip3.Show(ptLowerLeft);
        }
        void contextMenuStrip14_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"php/" + Args.ClickedItem.Text);
        }
        private void nginxlogs_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip4.Show(ptLowerLeft);
        }
        void contextMenuStrip15_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"logs/" + Args.ClickedItem.Text);
        }
        private void mariadblogs_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip5.Show(ptLowerLeft);
        }
        void contextMenuStrip16_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"php/logs/" + Args.ClickedItem.Text);
        }
        private void phplogs_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip6.Show(ptLowerLeft);
        }
        void contextMenuStrip17_ItemClicked(object Sender, System.Windows.Forms.ToolStripItemClickedEventArgs Args)
        {
            Process.Start(Wnmp.Properties.Settings.Default.editor, @Application.StartupPath + @"mariadb/data/" + Args.ClickedItem.Text);
        }
        #endregion contextmenus
        #region output
        private void output_TextChanged(object sender, EventArgs e)
        {
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
            string searchText = "Wnmp Main";
            int pos = 0;
            pos = output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
            while (pos != -1)
            {
                if (output.SelectedText == searchText && output.SelectedText != "")
                {
                    output.SelectionLength = searchText.Length;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos = output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
            }
            string searchText5 = "nginx";
            int pos5 = 0;
            pos5 = output.Find(searchText5, pos5, RichTextBoxFinds.MatchCase);
            while (pos5 != -1)
            {
                if (output.SelectedText == searchText5 && output.SelectedText != "")
                {
                    output.SelectionLength = 5;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos5 = output.Find(searchText5, pos5 + 1, RichTextBoxFinds.MatchCase);
            }
            string searchText6 = "php";
            int pos6 = 0;
            pos6 = output.Find(searchText6, pos6, RichTextBoxFinds.MatchCase);
            while (pos6 != -1)
            {
                if (output.SelectedText == searchText6 && output.SelectedText != "")
                {
                    output.SelectionLength = 3;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos6 = output.Find(searchText6, pos6 + 1, RichTextBoxFinds.MatchCase);
            }
            string searchText7 = "mariadb";
            int pos7 = 0;
            pos7 = output.Find(searchText7, pos7, RichTextBoxFinds.MatchCase);
            while (pos7 != -1)
            {
                if (output.SelectedText == searchText7 && output.SelectedText != "")
                {
                    output.SelectionLength = 7;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos7 = output.Find(searchText7, pos7 + 1, RichTextBoxFinds.MatchCase);
            }
        }
        #endregion output
        #region proccesscheck
        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] phps = Process.GetProcessesByName("php-cgi");
            if (phps.Length == 0)
            {
                phprunning.Text = "X";
                phprunning.ForeColor = Color.DarkRed;
            }
            else
            {
                phprunning.Text = "\u221A";
                phprunning.ForeColor = Color.Green;
            }
            Process[] nginxs = Process.GetProcessesByName("nginx");
            if (nginxs.Length == 0)
            {
                nginxrunning.Text = "X";
                nginxrunning.ForeColor = Color.DarkRed;
            }
            else
            {
                nginxrunning.Text = "\u221A";
                nginxrunning.ForeColor = Color.Green;
            }
            Process[] mariadbs = Process.GetProcessesByName("mysqld");
            if (mariadbs.Length == 0)
            {
                mariadbrunning.Text = "X";
                mariadbrunning.ForeColor = Color.DarkRed;
            }
            else
            {
                mariadbrunning.Text = "\u221A";
                mariadbrunning.ForeColor = Color.Green;
            }
        }
        #endregion proccesscheck
    }
}