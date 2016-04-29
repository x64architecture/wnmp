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
using System.Windows.Forms;

namespace Wnmp.UI
{
    public partial class HttpHeaders : Form
    {
        public HttpHeaders()
        {
            InitializeComponent();
        }

        private void getHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HTTPHeaderslistView.Items.Clear();
            try {
                var request = (HttpWebRequest)WebRequest.Create(urlTextBox.Text);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                using (var response = request.GetResponse()) {
                    foreach (var str in response.Headers.AllKeys) {
                        var item = new ListViewItem {
                            Text = str
                        };
                        item.SubItems.Add(response.Headers[str]);
                        HTTPHeaderslistView.Items.Add(item);
                    }
                }
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }
    }
}
