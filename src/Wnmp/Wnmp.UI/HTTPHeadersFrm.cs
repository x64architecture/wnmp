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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wnmp.UI
{
    public partial class HTTPHeadersFrm : Form
    {
        private void SetLanguage()
        {
            Text = Language.Resource.GET_HTTP_HEADERS;
            getHeadersToolStripMenuItem.Text = Language.Resource.GET_HEADERS;
            httpHeaderName.Text = Language.Resource.HEADER;
            httpHeaderValue.Text = Language.Resource.VALUE;
        }

        public HTTPHeadersFrm()
        {
            InitializeComponent();
            SetLanguage();
        }

        private async Task<HttpResponseHeaders> GetHeadersForUrl(string url)
        {
            using var httpClient = new HttpClient();
            var msg = await httpClient.GetAsync(urlTextBox.Text).ConfigureAwait(false);
            return msg.Headers;
        }

        private async void GetHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var headers = await GetHeadersForUrl(urlTextBox.Text);

                httpHeadersListView.Items.Clear();
                foreach (var header in headers)
                {
                    var item = new ListViewItem(header.Key);
                    foreach (var value in header.Value)
                    {
                        item.SubItems.Add(value);
                    }
                    httpHeadersListView.Items.Add(item);
                }
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return;
            }
        }
    }
}
