/*
 * Copyright (c) 2012 - 2017, Kurt Cancemi (kurt@x64architecture.com)
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
        public Version CurrentVersion { get; set; }
        public Uri UpdateInfoURL { get; set; }
        public string SaveFileName { get; set; }
        public bool UpdateAvailable { get; private set; }
        public Version NewVersion { get; private set; }

        private Uri updateDownloadURL;
        private UpdateProgressFrm updateProgress;
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
            try {
                Dns.GetHostAddresses("getwnmp.org");
            } catch (Exception) {
                Log.Error("Couldn't connect to update server.");
                return;
            }

            if (!ReadUpdateXML()) {
                Log.Error("Couldn't read update information.");
                return;
            }

            UpdateAvailable = CurrentVersion.CompareTo(NewVersion) < 0;
        }

        /// <summary>
        /// Downloads Update
        /// </summary>
        public void Update(Action UpdateCanceled, Action UpdateDownloaded)
        {
            updateDownloaded = UpdateDownloaded;
            updateCanceled = UpdateCanceled;

            updateProgress = new UpdateProgressFrm();
            updateProgress.FormClosed += UpdateProgress_FormClosed;

            updateProgress.StartPosition = FormStartPosition.CenterParent;
            updateProgress.Show();

            webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            webClient.DownloadFileAsync(updateDownloadURL, SaveFileName);
        }

        void UpdateProgress_FormClosed(object sender, FormClosedEventArgs e)
        {
            webClient.CancelAsync();
            updateCanceled();
        }

        void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            updateProgress.updateProgressBar.Value = e.ProgressPercentage;
            updateProgress.progressLabel.Text = e.ProgressPercentage.ToString() + "%";
        }

        void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
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
                var reader = new XmlTextReader(UpdateInfoURL.OriginalString);
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
                                NewVersion = new Version(reader.Value);
                                break;
                            case "upgradeurl":
                                updateDownloadURL = new Uri(reader.Value);
                                break;
                        }
                    }
                }

                return true;
            } catch (Exception ex) {
                Log.Error(ex.Message);
                return false;
            }
        }
    }
}