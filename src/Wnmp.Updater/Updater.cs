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
using System.Net;
using System.Net.NetworkInformation;
using System.Xml;
using System.Windows.Forms;

using Wnmp.UI;

namespace Wnmp.Updater
{
    class Updater
    {
        public Version currentVersion { get; set; }
        public Uri updateInfoURL { get; set; }
        public string SaveName { get; set; }
        public bool UpdateAvailable { get; private set; }
        public Version newVersion { get; private set; }

        private Uri UpdateDownloadURL;
        private UpdateProgress updateProgress;
        private WebClient webClient;
        private Action updateDownloaded;
        private Action updateCanceled;

        /// <summary>
        /// Checks for update
        /// 
        /// Sets UpdateAvailable to true if an update was found and
        /// Sets UpdateAvailable to false if an update was not found
        /// </summary>
        public void CheckForUpdate()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) {
                Log.wnmp_log_error("No active internet connection detected!", Log.LogSection.WNMP_MAIN);
                return;
            }

            if (!ReadUpdateXML()) {
                Log.wnmp_log_error("Couldn't read update information.", Log.LogSection.WNMP_MAIN);
                return;
            }

            UpdateAvailable = currentVersion.CompareTo(newVersion) < 0;
        }

        /// <summary>
        /// Downloads Update
        /// </summary>
        public void Update(Action UpdateCanceled, Action UpdateDownloaded)
        {
            updateDownloaded = UpdateDownloaded;
            updateCanceled = UpdateCanceled;

            updateProgress = new UpdateProgress();
            updateProgress.FormClosed += updateProgress_FormClosed;

            updateProgress.StartPosition = FormStartPosition.CenterParent;
            updateProgress.Show();

            webClient = new WebClient();
            webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;

            webClient.DownloadFileAsync(UpdateDownloadURL, SaveName);
        }

        void updateProgress_FormClosed(object sender, FormClosedEventArgs e)
        {
            webClient.CancelAsync();
            updateCanceled();
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            updateProgress.updatebarProgress.Value = e.ProgressPercentage;
            updateProgress.progressLabel.Text = e.ProgressPercentage.ToString() + "%";
        }

        void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled) {
                webClient.Dispose();
                return;
            }
            webClient.Dispose();
            updateProgress.Close();
            updateDownloaded();
        }

        private bool ReadUpdateXML()
        {
            string elementName = "";

            try {
                var reader = new XmlTextReader(updateInfoURL.OriginalString);
                reader.MoveToContent();

                if ((reader.NodeType != XmlNodeType.Element) && (reader.Name != "appinfo"))
                    return false;

                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        elementName = reader.Name;
                    } else {
                        if ((reader.NodeType != XmlNodeType.Text) || !reader.HasValue)
                            continue;
                        switch (elementName) {
                            case "version":
                                newVersion = new Version(reader.Value);
                                break;
                            case "upgradeurl":
                                UpdateDownloadURL = new Uri(reader.Value);
                                break;
                        }
                    }
                }

                return true;
            } catch (Exception ex) {
                if (ex.Message.Contains("The remote name could not be resolved")) {
                    Log.wnmp_log_error("No active internet connection detected!", Log.LogSection.WNMP_MAIN);
                } else {
                    Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
                }
                return false;
            }
        }
    }
}