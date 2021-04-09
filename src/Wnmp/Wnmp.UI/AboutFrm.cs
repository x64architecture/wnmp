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
using System.Windows.Forms;
using Wnmp.UI;

namespace Wnmp.Wnmp.UI
{
    public partial class AboutFrm : Form
    {
        private void SetLanguage()
        {
            Text = Language.Resource.ABOUT;
            aboutTabCtrl.TabPages[0].Text = Language.Resource.VERSION;
            aboutTabCtrl.TabPages[1].Text = Language.Resource.LICENSE;

            wnmpDescription.Text = Language.Resource.WNMP_DESCRIPTION;

            versionLabel.Text = Language.Resource.WNMP_VERSION.Replace("{CURRENTVERSION}", Application.ProductVersion);

            copyrightLabel.Text = Language.Resource.COPYRIGHT_TEXT.Replace("{CURRENTYEAR}", DateTime.Now.Year.ToString());
            licenseRichTextBox.Text = licenseRichTextBox.Text.Replace("{CURRENTYEAR}", DateTime.Now.Year.ToString());
        }

        public AboutFrm()
        {
            InitializeComponent();
            SetLanguage();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void wnmpWebsiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Misc.OpenUrlInBrowser("https://wnmp.x64architecture.com");
        }
    }
}
