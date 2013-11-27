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
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace Wnmp
{
    class Updater
    {
        public string updurl = "";
        public Updater(string xmlUrl, Version CurVer)
        {
            string downloadUrl = "";
            Version newVersion = null;
            string aboutUpdate = "";
            Version cpVersion = null;
            string cpUpdateUrl = "";
            string cpUpdaterUrl = "";
            string cpAbout = "";

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
                                    case "upgradeurl":
                                        updurl = reader.Value;
                                        break;
                                    case "about":
                                        aboutUpdate = reader.Value;
                                        break;
                                    case "cpversion":
                                        cpVersion = new Version(reader.Value);
                                        break;
                                    case "cpupdateurl":
                                        cpUpdateUrl = reader.Value;
                                        break;
                                    case "cpupdaterurl":
                                        cpUpdaterUrl = reader.Value;
                                        break;
                                    case "cpabout":
                                        cpAbout = reader.Value;
                                        break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                    Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (applicationVersion.CompareTo(newVersion) < 0)
            {
                ChangelogViewer CV = new ChangelogViewer();
                CV.cversion.Text = applicationVersion.ToString();
                CV.newversion.Text = newVersion.ToString();
                CV.changelog.Text = aboutUpdate.Trim();
                #region AShowDialog
                if (CV.ShowDialog() == DialogResult.Yes)
                {
                    dlUpdateProgress frm = new dlUpdateProgress();
                    frm.Show();
                    frm.Focus();
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileAsync(new Uri(updurl), @Application.StartupPath + "/Wnmp-Upgrade-" + newVersion + ".exe");
                    webClient.DownloadProgressChanged += (s, e) =>
                    {
                        frm.progressBar1.Value = e.ProgressPercentage;
                        frm.label2.Text = e.ProgressPercentage.ToString() + "%";
                    };
                    webClient.DownloadFileCompleted += (s, e) =>
                    {
                        try
                        {
                            frm.Close();
                            Process.Start(@Application.StartupPath + "/Wnmp-Upgrade-" + newVersion + ".exe");
                            cfa();
                            DoBackUp();
                            Application.Exit();
                            Process.GetCurrentProcess().Kill();
                        }
                        catch { }
                    };
                    frm.FormClosed += (s, e) =>
                    {
                        webClient.CancelAsync();
                    };
                }
                #endregion
            }
            else
            {
                Log.wnmp_log_notice("Your version: " + applicationVersion + " is up to date.", Log.LogSection.WNMP_MAIN);
            }
            if (CurVer.CompareTo(cpVersion) < 0)
            {
                ChangelogViewer CV = new ChangelogViewer();
                CV.cversion.Text = CurVer.ToString();
                CV.newversion.Text = cpVersion.ToString();
                CV.changelog.Text = cpAbout.Trim();
                #region AShowDialog
                if (CV.ShowDialog() == DialogResult.Yes)
                {
                    dlUpdateProgress frm = new dlUpdateProgress();
                    frm.Show();
                    frm.Focus();
                    WebClient webClient = new WebClient();
                    WebClient webClient2 = new WebClient();
                    webClient.DownloadFileAsync(new Uri(cpUpdateUrl), @Application.StartupPath + "/Wnmp_new.exe");
                    System.Threading.Thread.Sleep(500);
                    webClient2.DownloadFileAsync(new Uri(cpUpdaterUrl), @Application.StartupPath + "/updater.exe");
                    webClient.DownloadProgressChanged += (s, e) =>
                    {
                        frm.progressBar1.Value = e.ProgressPercentage;
                        frm.label2.Text = e.ProgressPercentage.ToString() + "%";
                    };
                    webClient.DownloadFileCompleted += (s, e) =>
                    {
                        try
                        {
                            frm.Close();
                            System.Threading.Thread.Sleep(200);
                            Process.Start(@Application.StartupPath + "/updater.exe");
                            cfa();
                            Application.Exit();
                            Process.GetCurrentProcess().Kill();
                        }
                        catch { }
                    };
                    frm.FormClosed += (s, e) =>
                    {
                        webClient.CancelAsync();
                    };
                }
                #endregion
            }
            else
            {
                Log.wnmp_log_notice("Your control panel version: " + CurVer + " is up to date.", Log.LogSection.WNMP_MAIN);
            }
            Wnmp.Properties.Settings.Default.lastcheckforupdate = DateTime.Now.ToString();
            Wnmp.Properties.Settings.Default.Save();
        }

        private void DoBackUp()
        {
            string wd = Main.getappsupath;
            string[] files = { wd + "/php/php.ini", wd + "/conf/nginx.conf" };
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    string dest = String.Format("{0}.old", file);
                    File.Copy(file, dest, true);
                    Log.wnmp_log_notice("Backed up " + file + " to " + dest, Log.LogSection.WNMP_MAIN);
                }
            }
        }
        private void cfa()
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