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
        private string Wnmp_Upgrade_URL = "";
        private string WNMP_INSTALLER_URL = "";
        private Version NEW_WNMP_VERSION = null;
        private string ABOUT_WNMP_UPDATE = "";
        private Version NEW_CP_VERSION = null;
        private string CP_UPDATE_URL = "";
        private string CP_UPDATER_URL = "";
        private string ABOUT_CP_UPDATE = "";
        private Version WNMP_VER = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        public Updater(string xmlUrl, Version CurCPVer)
        {
            bool FoundWnmpUpdate = false; // Since were checking for two updates we have to check if it found the main one.
            bool Failed;
            ReadUpdateXML(xmlUrl, out Failed);

            if (Failed != true)
            {
                if (WNMP_VER.CompareTo(NEW_WNMP_VERSION) < 0) // If it returns less than 0 than theres a new version
                {
                    ChangelogViewer CV = new ChangelogViewer();
                    CV.StartPosition = FormStartPosition.CenterScreen;
                    CV.cversion.Text = WNMP_VER.ToString();
                    CV.newversion.Text = NEW_WNMP_VERSION.ToString();
                    CV.changelog.Text = ABOUT_WNMP_UPDATE.Trim();
                     if (CV.ShowDialog() == DialogResult.Yes)
                     {
                         DownloadWnmpUpdate();
                         FoundWnmpUpdate = true;
                     }
                }
                else
                {
                    Log.wnmp_log_notice("Your version: " + WNMP_VER + " is up to date.", Log.LogSection.WNMP_MAIN);
                }

                if (FoundWnmpUpdate != true)
                {
                    if (CurCPVer.CompareTo(NEW_CP_VERSION) < 0)
                    {
                        ChangelogViewer CV = new ChangelogViewer();
                        CV.StartPosition = FormStartPosition.CenterScreen;
                        CV.cversion.Text = CurCPVer.ToString();
                        CV.newversion.Text = NEW_CP_VERSION.ToString();
                        CV.changelog.Text = ABOUT_CP_UPDATE.Trim();

                        if (CV.ShowDialog() == DialogResult.Yes)
                        {
                            Download_CP_Update();
                        }
                    }
                    else
                    {
                        Log.wnmp_log_notice("Your control panel version: " + CurCPVer + " is up to date.", Log.LogSection.WNMP_MAIN);
                    }
                }
            }

        }

        #region ReadUpdateXML
        private void ReadUpdateXML(string xmlUrl, out bool Failed)
        {
            try
            {
                int returnvalue;
                if (NativeMethods.InternetGetConnectedState(out returnvalue, 0))
                {
                    Failed = false;
                    XmlTextReader reader;

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
                                            NEW_WNMP_VERSION = new Version(reader.Value);
                                            break;
                                        case "url":
                                            WNMP_INSTALLER_URL = reader.Value;
                                            break;
                                        case "upgradeurl":
                                            Wnmp_Upgrade_URL = reader.Value;
                                            break;
                                        case "about":
                                            ABOUT_WNMP_UPDATE = reader.Value;
                                            break;
                                        case "cpversion":
                                            NEW_CP_VERSION = new Version(reader.Value);
                                            break;
                                        case "cpupdateurl":
                                            CP_UPDATE_URL = reader.Value;
                                            break;
                                        case "cpupdaterurl":
                                            CP_UPDATER_URL = reader.Value;
                                            break;
                                        case "cpabout":
                                            ABOUT_CP_UPDATE = reader.Value;
                                            break;
                                    }
                            }
                        }
                    }
                }
                else
                {
                    Failed = true;
                }
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
                Failed = true;
            }
        }
        #endregion

        #region MainWnmpUpdate
        private void DownloadWnmpUpdate()
        {
            string UpdateExe = @Application.StartupPath + "/Wnmp-Upgrade-Installer.exe";

            dlUpdateProgress frm = new dlUpdateProgress();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.Focus();

            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri(Wnmp_Upgrade_URL), UpdateExe);

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
                    Process.Start(UpdateExe);
                    KillProcesses();
                    DoBackUp();
                    Application.Exit();
                    Process.GetCurrentProcess().Kill();
                }
                catch { }
            };

            frm.FormClosed += (s, e) =>
            {
                webClient.CancelAsync(); // Cancel update when form is closed
            };
        }
        #endregion

        #region CP_Update
        private void Download_CP_Update()
        {
            string WNMP_NEW = @Application.StartupPath + "/Wnmp_new.exe";
            string UPDATER = @Application.StartupPath + "/updater.exe";
            dlUpdateProgress frm = new dlUpdateProgress();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.Focus();
            WebClient webClient = new WebClient();
            WebClient webClient2 = new WebClient();
            webClient.DownloadFileAsync(new Uri(CP_UPDATE_URL), WNMP_NEW);
            System.Threading.Thread.Sleep(500);
            webClient2.DownloadFileAsync(new Uri(CP_UPDATER_URL), UPDATER);

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
                    KillProcesses();
                    Application.Exit();
                    Process.GetCurrentProcess().Kill();
                }
                catch { }
            };
            frm.FormClosed += (s, e) =>
            {
                webClient.CancelAsync(); // Cancel update when form is closed
            };
        }
        #endregion

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

        #region AutoCheckForUpdates
        public static bool IsSet(string s)
        {
            if (s != "")
                return true;
            else
                return false;
        }
        private static void DoDateEclasped(double days)
        {
            if (IsSet(Wnmp.Properties.Settings.Default.lastcheckforupdate))
            {
                DateTime LastCheckForUpdate = DateTime.Parse(Wnmp.Properties.Settings.Default.lastcheckforupdate);
                DateTime expiryDate = LastCheckForUpdate.AddDays(days);
                if (DateTime.Now > expiryDate)
                {
                    const string xmlUrl = Main.UpdateXMLURL;
                    Updater _Updater = new Updater(xmlUrl, Program.formInstance.CPVER);
                }
            }
            else
            {
                Wnmp.Properties.Settings.Default.lastcheckforupdate = DateTime.Now.ToString();
                Wnmp.Properties.Settings.Default.Save();
            }
        }
        public static void DoAutoCheckForUpdate()
        {
            if (Wnmp.Properties.Settings.Default.autocheckforupdates == true)
            {
                switch (Wnmp.Properties.Settings.Default.cfuevery)
                {
                    case "day":
                        DoDateEclasped(1);
                        break;
                    case "week":
                        DoDateEclasped(7);
                        break;
                    case "month":
                        DoDateEclasped(30);
                        break;
                    default:
                        DoDateEclasped(7); /* Default: To check for updates every week. */
                        break;
                }
            }
        }
        #endregion

        private void KillProcesses()
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
        } //
    }
}