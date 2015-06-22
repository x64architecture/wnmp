/*
Copyright (c) Kurt Cancemi 2012-2015

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

using Wnmp.Forms;
using Wnmp.Internals;
namespace Wnmp.Helpers
{
    /// <summary>
    /// Updater for Wnmp and the control panel
    /// </summary>
    class Updater
    {
        public Main form;
        private Uri Wnmp_Upgrade_URL; // Wnmp upgrade installer url
        private Version NEW_WNMP_VERSION; // Wnmp version in the XML
        private readonly Version WNMP_VER = new Version(Application.ProductVersion); // Current program version
        private readonly string UpdateExe = Main.StartupPath + "/Wnmp-Upgrade-Installer.exe";
        private readonly string WNMP_NEW = Main.StartupPath + "/Wnmp_new.exe";
        private readonly string UPDATER = Main.StartupPath + "/updater.exe";
        private WebClient webClient;
        private const string UpdateXMLURL = Constants.UpdateXMLUrl;

        #region ReadUpdateXML
        /// <summary>
        /// Fetches and reads the update xml
        /// </summary>
        /// <returns>True on sucess and False on failure</returns>
        private bool ReadUpdateXML()
        {
            const string xmlUrl = UpdateXMLURL;
            var elementName = "";

            int returnvalue;
            if (!NativeMethods.InternetGetConnectedState(out returnvalue, 0)) {
                MessageBox.Show("No active network connection detected", "Can't Check For Updates");
                return false;
            }

            var reader = new XmlTextReader(xmlUrl);
            reader.MoveToContent();

            if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "appinfo")) {
                do {
                    if (reader.NodeType == XmlNodeType.Element)
                        elementName = reader.Name;
                    else {
                        if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            switch (elementName) {
                                case "version":
                                    NEW_WNMP_VERSION = new Version(reader.Value);
                                    break;
                                case "upgradeurl":
                                    Wnmp_Upgrade_URL = new Uri(reader.Value);
                                    break;
                            }
                    }
                } while (reader.Read());
            }
            return true;
        }
        #endregion
        /// <summary>
        /// Downloads the update for Wnmp
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="path"></param>
        private void DownloadWnmpUpdate(Uri uri, string path)
        {
            var frm = new UpdateProgress();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            form.Enabled = false;

            webClient = new WebClient();

            frm.FormClosed += (s, e) => {
                form.Enabled = true;
                webClient.CancelAsync();
            };

            webClient.DownloadProgressChanged += (s, e) => {
                frm.progressBar1.Value = e.ProgressPercentage;
                frm.label2.Text = e.ProgressPercentage.ToString() + "%";
            };

            webClient.DownloadFileCompleted += (s, e) => {
                if (!e.Cancelled) {
                    webClient.Dispose();
                    frm.Close();
                    Process.Start(UpdateExe);
                    KillProcesses();
                    DoBackUp();
                    Application.Exit();
                    Process.GetCurrentProcess().Kill();
                } else
                    webClient.Dispose();
            };

            webClient.DownloadFileAsync(uri, path);

            webClient.Dispose();
        }

        /// <summary>
        /// Checks for updates
        /// </summary>
        public void CheckForUpdates(bool AutoUpdate)
        {
            if (!ReadUpdateXML())
                return;

            if (WNMP_VER.CompareTo(NEW_WNMP_VERSION) < 0) { // If it returns less than 0 than theres a new version
                var CV = new UpdatePrompt();
                CV.StartPosition = FormStartPosition.CenterScreen;
                CV.cversion.Text = WNMP_VER.ToString();
                CV.newversion.Text = NEW_WNMP_VERSION.ToString();
                if (CV.ShowDialog() == DialogResult.Yes)
                    DownloadWnmpUpdate(Wnmp_Upgrade_URL, UpdateExe);
            } else {
                Log.wnmp_log_notice("Your version: " + WNMP_VER + " is up to date.", Log.LogSection.WNMP_MAIN);
            }

            if (AutoUpdate) {
                Options.settings.Lastcheckforupdate = DateTime.Now;
                Options.settings.UpdateSettings();
            }
        }

        /// <summary>
        /// Backs up the configuration files for Nginx, MariaDB, and PHP
        /// </summary>
        private void DoBackUp()
        {
            string[] files = { Main.StartupPath + "/php/php.ini", Main.StartupPath + "/conf/nginx.conf", Main.StartupPath + "/mariadb/my.ini" };
            foreach (string file in files) {
                if (File.Exists(file)) {
                    var dest = String.Format("{0}.old", file);
                    File.Copy(file, dest, true);
                    Log.wnmp_log_notice("Backed up " + file + " to " + dest, Log.LogSection.WNMP_MAIN);
                }
            }
        }

        #region AutoCheckForUpdates
        /// <summary>
        /// Checks if the curent date if greater than the selected update freqency
        /// and excutes the updater if true.
        /// </summary>
        /// <param name="days"></param>
        public void DoDateEclasped()
        {
            if (Options.settings.Lastcheckforupdate != DateTime.MinValue) {
                var LastCheckForUpdate = Options.settings.Lastcheckforupdate;
                var expiryDate = LastCheckForUpdate.AddDays(Options.settings.Checkforupdatefrequency);
                if (DateTime.Now > expiryDate)
                    CheckForUpdates(true);
            } else {
                Options.settings.Lastcheckforupdate = DateTime.Now;
                Options.settings.UpdateSettings();
            }
        }
        #endregion

        /// <summary>
        /// Kills Nginx, MariaDB, and PHP
        /// </summary>
        private void KillProcesses()
        {
            string[] processtokill = { "php-cgi", "nginx", "mysqld" };
            var processes = Process.GetProcesses();

            for (var i = 0; i < processes.Length; i++) {
                for (var j = 0; j < processtokill.Length; j++) {
                    var tempProcess = processes[i].ProcessName;

                    if (tempProcess == processtokill[j]) { // If the proccess is the proccess we want to kill
                        processes[i].Kill(); // Kill the proccess
                        break;
                    }
                }
            }
        } // End of KillProcesses()
    }
}