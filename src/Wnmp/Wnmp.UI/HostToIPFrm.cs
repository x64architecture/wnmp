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
using System.Windows.Forms;

namespace Wnmp.UI
{
    public partial class HostToIPFrm : Form
    {
        private void SetLanguage()
        {
            Text = Language.Resource.HOST_TO_IP;
            hostLabel.Text = Language.Resource.HOST_SC;
            ipLabel.Text = Language.Resource.IP_S;
            hostToIPButton.Text = Language.Resource.HOST_TO_IP;
            closeButton.Text = Language.Resource.CLOSE;
        }

        public HostToIPFrm()
        {
            InitializeComponent();
            SetLanguage();
        }

        private async void HostToIpButton_Click(object sender, EventArgs e)
        {
            ipAddressesListBox.Items.Clear();
            try {
                IPAddress[] IPs = await Dns.GetHostAddressesAsync(hostTextBox.Text);
                foreach (var IP in IPs)
                    ipAddressesListBox.Items.Add(IP.ToString());
            } catch (Exception ex) {
                Log.Error(ex.Message);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
