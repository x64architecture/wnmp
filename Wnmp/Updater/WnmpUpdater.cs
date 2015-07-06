/*
 * Copyright (c) 2012 - 2015, Kurt Cancemi (kurt@x64architecture.com)
 *
 * This file is part of Wnmp.
 *
 *  Wnmp is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Wnmp is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.IO;

using Wnmp.Forms;

namespace Wnmp
{
    /// <summary>
    /// Updater for Wnmp
    /// </summary>
    class WnmpUpdater
    {
        public Main mainForm;
        private Updater updater = new Updater();

        /// <summary>
        /// Checks for updates
        /// </summary>
        public void CheckForUpdates()
        {
            updater.currentVersion = new Version(Application.ProductVersion);
            updater.updateInfoURL = new Uri(Constants.UpdateXMLUrl);
            updater.SaveName = Main.StartupPath + @"\Wnmp-Upgrade-Installer.exe";

            updater.CheckForUpdate();

            if (updater.UpdateAvailable) {
                UpdatePrompt updatePrompt = new UpdatePrompt();
                updatePrompt.StartPosition = FormStartPosition.CenterParent;
                updatePrompt.currentversion.Text = updater.currentVersion.ToString();
                updatePrompt.newversion.Text = updater.newVersion.ToString();
                if (updatePrompt.ShowDialog() == DialogResult.Yes) {
                    mainForm.Enabled = false;
                    updater.Update(UpdateCanceled, UpdateDownloaded);
                }
            } else {
                Log.wnmp_log_notice("Your version: " + updater.currentVersion + " is up to date.", Log.LogSection.WNMP_MAIN);
            }
        }

        private void UpdateCanceled()
        {
            mainForm.Enabled = true;
        }

        private void UpdateDownloaded()
        {
            KillProcesses();
            DoBackUp();
            Process.Start(updater.SaveName);
            Application.Exit();
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

                    if (tempProcess == processtokill[j]) {
                        processes[i].Kill();
                        break;
                    }
                }
            }
        }

        public void DoDateEclasped()
        {
            DateTime LastCheckForUpdate = Options.settings.Lastcheckforupdate;
            DateTime expiryDate = LastCheckForUpdate.AddDays(Options.settings.UpdateFrequency);

            if (LastCheckForUpdate != DateTime.MinValue) {
                if (DateTime.Now > expiryDate)
                    CheckForUpdates();
            }

            Options.settings.Lastcheckforupdate = DateTime.Now;
            Options.settings.UpdateSettings();
        }
    }
}