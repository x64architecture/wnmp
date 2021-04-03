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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Wnmp.Programs;

namespace Wnmp.Wnmp.UI
{
    partial class SetupMariaDB : Form
    {
        private readonly string dataDirectory = Program.StartupPath + "\\mariadb\\data";
        private readonly string installExe = Program.StartupPath + "\\mariadb\\bin\\mysql_install_db.exe";
        private readonly MariaDBProgram MariaDB;

        private void SetLanguage()
        {
            Text = Language.Resource.SETUP_MARIADB;
            rootPasswordLabel.Text = Language.Resource.ROOT_PASSWORD;
            allowRemoteRootAccessCheckbox.Text = Language.Resource.ALLOW_REMOTE_ROOT_ACCESS;
            visibleCheckbox.Text = Language.Resource.VISIBLE;
            setupButton.Text = Language.Resource.SETUP_MARIADB;
        }

        public SetupMariaDB(MariaDBProgram mariaDB)
        {
            MariaDB = mariaDB;
            InitializeComponent();
            SetLanguage();
        }

        private void setupButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rootPasswordTextBox.Text) || rootPasswordTextBox.Text.Any(char.IsWhiteSpace)) {
                MessageBox.Show(Language.Resource.PASSWORD_CREATE_INVALID,
                    Language.Resource.INVALID_PASSWORD_FORMAT,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            MariaDB.RemoveService();
            string args = $"--service={MariaDBProgram.ServiceName} --password={rootPasswordTextBox.Text}";
            if (allowRemoteRootAccessCheckbox.Checked) {
                args += " --allow-remote-root-access";
            }
            WnmpProgram.StartProcessAsAdmin(installExe, args, true);
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            rootPasswordTextBox.UseSystemPasswordChar = !rootPasswordTextBox.UseSystemPasswordChar;
        }

        private void SetupMariaDB_Shown(object sender, EventArgs e)
        {
            if (Directory.Exists(dataDirectory)) {
                DialogResult result = MessageBox.Show(
                    Language.Resource.MARIADB_DATA_DIR_EXISTS.Replace("{dataDirectory}", dataDirectory),
                    Language.Resource.MARIADB_SETUP,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );
                if (result == DialogResult.No) {
                    Close();
                    return;
                }
                else
                {
                    try {
                        Directory.Delete(dataDirectory, true);
                    } catch (Exception ex) {
                        Log.Error(ex.Message);
                    }
                }

            }
        }
    }
}
