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

using Wnmp.Internals;

namespace Wnmp.Helpers
{
    class Updater
    {
        private string Wnmp_Upgrade_URL = ""; // Wnmp upgrade installer url
        private string WNMP_INSTALLER_URL = ""; // Wnmp first installer url (useless to this application)
        private Version NEW_WNMP_VERSION = null; // Wnmp version in the XML
        private Version NEW_CP_VERSION = null; // Control panel version in the XML
        private string CP_UPDATE_URL = ""; // Control panel url (link to CP exe)
        private string CP_UPDATER_URL = ""; // Control panel updater url (program that replaces the control panel with the new version)
        private Version WNMP_VER = new Version(Application.ProductVersion); // Current program version

        /// <summary>
        /// Checks for updates
        /// </summary>
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

                if (Failed != true)
                {
                    if (FoundWnmpUpdate != true)
                    {
                        if (CurCPVer.CompareTo(NEW_CP_VERSION) < 0)
                        {
                            ChangelogViewer CV = new ChangelogViewer();
                            CV.StartPosition = FormStartPosition.CenterScreen;
                            CV.cversion.Text = CurCPVer.ToString();
                            CV.newversion.Text = NEW_CP_VERSION.ToString();

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
        }

        #region ReadUpdateXML
        /// <summary>
        /// Parses the update XML
        /// </summary>
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
                                            // No longer used
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
                                            // No longer used
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
        /// <summary>
        /// Downloads the update for Wnmp
        /// </summary>
        private void DownloadWnmpUpdate()
        {
            string UpdateExe = @Application.StartupPath + "/Wnmp-Upgrade-Installer.exe";

            UpdateProgress frm = new UpdateProgress();
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
        /// <summary>
        /// Downloads the update for the control panel
        /// </summary>
        private void Download_CP_Update()
        {
            string WNMP_NEW = @Application.StartupPath + "/Wnmp_new.exe";
            string UPDATER = @Application.StartupPath + "/updater.exe";
            UpdateProgress frm = new UpdateProgress();
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

        /// <summary>
        /// Backs up the configuration files for Nginx, MariaDB, and PHP
        /// </summary>
        private void DoBackUp()
        {
            string wd = Main.StartupPath;
            string[] files = { wd + "/php/php.ini", wd + "/conf/nginx.conf", wd + "/mariadb/my.ini" };
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
        /// <summary>
        /// Checks if a string is empty
        /// </summary>
        /// <param name="s"></param>
        /// <returns>True if the string isn't empty else it returns false</returns>
        public static bool IsSet(string s)
        {
            if (s != "")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the curent date if greater than the selected update freqency
        /// and excutes the updater if true.
        /// </summary>
        /// <param name="days"></param>
        private static void DoDateEclasped(double days)
        {
            if (IsSet(Wnmp.Properties.Settings.Default.lastcheckforupdate))
            {
                DateTime LastCheckForUpdate = DateTime.Parse(Wnmp.Properties.Settings.Default.lastcheckforupdate);
                DateTime expiryDate = LastCheckForUpdate.AddDays(days);
                if (DateTime.Now > expiryDate)
                {
                    const string xmlUrl = Main.UpdateXMLURL;
                    Updater _Updater = new Updater(xmlUrl, Program.formInstance.GetCPVER);
                }
            }
            else
            {
                Wnmp.Properties.Settings.Default.lastcheckforupdate = DateTime.Now.ToString();
                Wnmp.Properties.Settings.Default.Save();
            }
        }
        /// <summary>
        /// Tells the Updater the selected update frequency
        /// </summary>
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

        /// <summary>
        /// Kills Nginx, MariaDB, and PHP
        /// </summary>
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
        } // End of KillProcesses()
    }
}