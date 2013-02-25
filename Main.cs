 // Licensed under the GNU GENERAL PUBLIC LICENSE V3 Unless otherwise noted
// Created by Kurt Cancemi
// Donations are appreciated no matter if big or small  
// via PayPal kurt@x64Architecture.com
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
using System.Security.Cryptography;

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
        protected string GetMD5Hash(string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private static void killps(string processName)
        {
            Process[] process = Process.GetProcessesByName(processName);
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
            System.Diagnostics.Process.Start("https://code.google.com/p/windows-nginx-mysql-php/");
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=P7LAQRRNF6AVE");
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
            if ((GetMD5Hash("wnmp/start_all.bat") == "a54767b15a45d03a4113a044207c94f3"))
            {
            System.Diagnostics.Process start = new System.Diagnostics.Process();
            start.StartInfo.FileName = "wnmp/start_all.bat";
            start.StartInfo.RedirectStandardError = true;
            start.StartInfo.RedirectStandardOutput = true;
            start.StartInfo.UseShellExecute = false;
            start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            start.Start();
            System.Diagnostics.Process startphp = new System.Diagnostics.Process();
            startphp.StartInfo.FileName = "php/php-cgi.exe";
            startphp.StartInfo.Arguments = "-b localhost:9000";
            startphp.StartInfo.CreateNoWindow = true;
            startphp.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startphp.StartInfo.RedirectStandardError = true;
            startphp.StartInfo.RedirectStandardOutput = true;
            startphp.StartInfo.UseShellExecute = false;
            startphp.Start();
            }
            else
            {
                MessageBox.Show("'wnmp/start_all.bat' has been tampered with to continue reinstall Wnmp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if ((GetMD5Hash("wnmp/stop_all.bat") == "9457f44d9915e52d8343abc86bba97a9"))
            {
                System.Diagnostics.Process stop = new System.Diagnostics.Process();
                stop.StartInfo.FileName = "wnmp/stop_all.bat";
                stop.StartInfo.RedirectStandardError = true;
                stop.StartInfo.RedirectStandardOutput = true;
                stop.StartInfo.UseShellExecute = false;
                stop.Start();
            }
            else
            {
                MessageBox.Show("'wnmp/stop_all.bat' has been tampered with to continue reinstall Wnmp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////Nginx/////////////////////////////////////////////////////////////////////

        private void nginxreload_Click(object sender, EventArgs e)
        {
            if ((GetMD5Hash("wnmp/nginx_reload.bat") == "041f470d085ce0baf56d642004535bfa"))
            {
            System.Diagnostics.Process reload = new System.Diagnostics.Process();
            reload.StartInfo.FileName = "wnmp/nginx_reload.bat";
            reload.StartInfo.RedirectStandardError = true;
            reload.StartInfo.RedirectStandardOutput = true;
            reload.StartInfo.UseShellExecute = false;
            reload.Start();
            }
            else
            {
                MessageBox.Show("'wnmp/nginx_reload.bat' has been tampered with to continue reinstall Wnmp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nginxstop_Click(object sender, EventArgs e)
        {
            if ((GetMD5Hash("wnmp/nginx_stop.bat") == "eab8b0486d1e85253796a5c5ed92aad0"))
            {
            System.Diagnostics.Process stop = new System.Diagnostics.Process();
            stop.StartInfo.FileName = "wnmp/nginx_stop.bat";
            stop.StartInfo.RedirectStandardError = true;
            stop.StartInfo.RedirectStandardOutput = true;
            stop.StartInfo.UseShellExecute = false;
            stop.Start();
            }
            else
            {
                MessageBox.Show("'wnmp/nginx_stop.bat' has been tampered with to continue reinstall Wnmp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nginxstart_Click(object sender, EventArgs e)
        {
            if ((GetMD5Hash("wnmp/nginx_start.bat") == "d051e492c815d06d60ad6bb3f7bd3e01"))
            {
                System.Diagnostics.Process start = new System.Diagnostics.Process();
                start.StartInfo.FileName = "wnmp/nginx_start.bat";
                start.StartInfo.RedirectStandardError = true;
                start.StartInfo.RedirectStandardOutput = true;
                start.StartInfo.UseShellExecute = false;
                start.Start();
            }
            else 
            {
                MessageBox.Show("'wnmp/nginx_start.bat' has been tampered with to continue reinstall Wnmp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            System.Diagnostics.Process start = new System.Diagnostics.Process();
            start.StartInfo.FileName = "php/php-cgi.exe";
            start.StartInfo.Arguments = "-b localhost:9000";
            start.StartInfo.RedirectStandardError = true;
            start.StartInfo.RedirectStandardOutput = true;
            start.StartInfo.UseShellExecute = false;
            start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            start.Start();
            start.CloseMainWindow();
        }

        private void phpstop_Click(object sender, EventArgs e)
        {
            if ((GetMD5Hash("wnmp/php_stop.bat") == "9f20868f493fa2c2c48ea405675a0c24"))
            {
                System.Diagnostics.Process stop = new System.Diagnostics.Process();
                stop.StartInfo.FileName = "wnmp/php_stop.bat";
                stop.StartInfo.RedirectStandardError = true;
                stop.StartInfo.RedirectStandardOutput = true;
                stop.StartInfo.UseShellExecute = false;
                stop.Start();
            }
            else
            {
                MessageBox.Show("'wnmp/php_stop.bat' has been tampered with to continue reinstall Wnmp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if ((GetMD5Hash("wnmp/mysql_start.bat") == "adca00cabaa2b5bcfa39d18474214e7b"))
            {
                System.Diagnostics.Process start = new System.Diagnostics.Process();
                start.StartInfo.FileName = "wnmp/mysql_start.bat";
                start.StartInfo.RedirectStandardError = true;
                start.StartInfo.RedirectStandardOutput = true;
                start.StartInfo.UseShellExecute = false;
                start.Start();
            }
            else
            {
                MessageBox.Show("'wnmp/mysql_start.bat' has been tampered with to continue reinstall Wnmp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mysqlstop_Click(object sender, EventArgs e)
        {
            if ((GetMD5Hash("wnmp/mysql_stop.bat") == "04f022158623b3d2d12eddc0b0925df5"))
            {
                System.Diagnostics.Process start = new System.Diagnostics.Process();
                start.StartInfo.FileName = "wnmp/mysql_stop.bat";
                start.StartInfo.RedirectStandardError = true;
                start.StartInfo.RedirectStandardOutput = true;
                start.StartInfo.UseShellExecute = false;
                start.Start();
            }
            else
            {
                MessageBox.Show("'wnmp/mysql_stop.bat' has been tampered with to continue reinstall Wnmp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
///////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
