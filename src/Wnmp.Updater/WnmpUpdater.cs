/*
 * Copyright (c) 2012 - 2016, Kurt Cancemi (kurt@x64architecture.com)
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
using System.Diagnostics;
using System.IO;

using Wnmp.Configuration;
using Wnmp.UI;

namespace Wnmp.Updater
{
    /// <summary>
    /// Updater for Wnmp
    /// </summary>
    class WnmpUpdater
    {
        public Main mainForm;
        public Ini Settings;
        private readonly Updater updater = new Updater();

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
                var updatePrompt = new UpdatePrompt {
                    StartPosition = FormStartPosition.CenterParent,
                    currentversion = {
                        Text = updater.currentVersion.ToString()
                    },
                    newversion = {
                        Text = updater.newVersion.ToString()
                    }
                };
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
            mainForm.StopAll();
            DoBackUp();
            KillProcesses();
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
                    var dest = $"{file}.old";
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
            string[] processestokill = { "php-cgi", "nginx", "mysqld" };
            var processes = Process.GetProcesses();

            foreach (var process in processes) {
                foreach (var processToKill in processestokill) {
                    if (process.ProcessName == processToKill) {
                        process.Kill();
                        break;
                    }
                }
            }
        }

        public void DoDateEclasped()
        {
            DateTime LastCheckForUpdate = Settings.LastCheckForUpdate.Value;
            DateTime expiryDate = LastCheckForUpdate.AddDays(Settings.UpdateFrequency.Value);

            if (DateTime.Now < expiryDate)
                return;

            CheckForUpdates();

            Settings.LastCheckForUpdate.Value = DateTime.Now;
            Settings.UpdateSettings();
        }
    }
}