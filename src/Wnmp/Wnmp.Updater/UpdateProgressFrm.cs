﻿/*
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
using System.Threading;
using System.Windows.Forms;

namespace Wnmp.Updater
{
    public partial class UpdateProgressFrm : Form
    {
        private CancellationTokenSource cancelTokenSrc;

        private void SetLanguage()
        {
            Text = Language.Resource.DOWNLOADING_UPDATE;
            downloadLabel.Text = Language.Resource.DOWNLOAD_IN_PROGRESS_PLEASE_WAIT;
            cancelDownloadButton.Text = Language.Resource.CANCEL;
        }

        protected override CreateParams CreateParams
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x00040000; // Remove WS_THICKFRAME (Disables resizing)
                return cp;
            }
        }

        public UpdateProgressFrm(CancellationTokenSource CancelTokenSrc)
        {
            cancelTokenSrc = CancelTokenSrc;
            InitializeComponent();
            SetLanguage();
        }

        private void CancelDownloadButton_Click(object sender, EventArgs e)
        {
            cancelTokenSrc.Cancel();
            Close();
        }

        public void ProgressChanged(int ProgressPercentage)
        {
            updateProgressBar.Value = ProgressPercentage;
            progressLabel.Text = $"{ProgressPercentage}%";
        }
    }
}
