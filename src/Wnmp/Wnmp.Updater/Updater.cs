/*
 * Copyright (c) 2012 - 2021, Kurt Cancemi (kurt@x64architecture.com)
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
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

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
        private HttpClient httpClient;
        private Action updateDownloaded;
        private Action updateCanceled;
        private Action<int> updateProgressChanged;

        /// <summary>
        /// Checks for update
        /// 
        /// Sets UpdateAvailable to true if an update was found and
        /// Sets UpdateAvailable to false if an update was not found
        /// </summary>
        public async Task CheckForUpdate()
        {
            if (!await ReadUpdateXML())
            {
                Log.Error(Language.Resource.COULDNT_READ_UPDATE_INFORMATION);
                return;
            }

            UpdateAvailable = CurrentVersion.CompareTo(NewVersion) < 0;
        }

        /// <summary>
        /// Downloads Update
        /// </summary>
        public async Task UpdateAsync(Action UpdateCanceled, Action UpdateDownloaded, Action<int> UpdateProgressChanged, CancellationToken CancelToken)
        {
            updateDownloaded = UpdateDownloaded;
            updateCanceled = UpdateCanceled;
            updateProgressChanged = UpdateProgressChanged;

            httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(updateDownloadURL, HttpCompletionOption.ResponseHeadersRead, CancelToken);
            long? contentLen = response.Content.Headers.ContentLength;
            using var file = new FileStream(SaveFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            using var download = await response.Content.ReadAsStreamAsync(CancelToken);
            if (!contentLen.HasValue)
            {
                await download.CopyToAsync(file, CancelToken);
            }
            else
            {
                var buffer = new byte[8192];
                long totalBytesRead = 0;
                int bytesRead;
                while ((bytesRead = await download.ReadAsync(buffer.AsMemory(), CancelToken)) != 0)
                {
                    await file.WriteAsync(buffer.AsMemory(0, bytesRead), CancelToken);
                    totalBytesRead += bytesRead;
                    updateProgressChanged((int)((totalBytesRead / (float)contentLen.Value) * 100f));
                    if (CancelToken.IsCancellationRequested)
                    {
                        httpClient.CancelPendingRequests();
                        httpClient.Dispose();
                        updateCanceled();
                        break;
                    }
                }
                file.Close();

                if (totalBytesRead == contentLen.Value)
                {
                    updateDownloaded();
                }

            }
        }

        private async Task<bool> ReadUpdateXML()
        {
            XmlReaderSettings settings = new();
            settings.Async = true;

            string elementName = "";

            try {
                using XmlReader reader = XmlReader.Create(UpdateInfoURL.OriginalString, settings);
                reader.MoveToContent();

                if ((reader.NodeType != XmlNodeType.Element) && (reader.Name != "appinfo"))
                    return false;

                while (await reader.ReadAsync()) {
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