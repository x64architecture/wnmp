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

        public SetupMariaDB(MariaDBProgram mariaDB)
        {
            MariaDB = mariaDB;
            InitializeComponent();
        }

        private void setupButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(rootPasswordTextBox.Text) || rootPasswordTextBox.Text.Any(Char.IsWhiteSpace)) {
                MessageBox.Show("Password may not be blank or contain spaces.", "Invalid Password Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DialogResult result = MessageBox.Show("The MariaDB data directory \'" + dataDirectory + "\' already exists, to continue with the setup it will be deleted. Is that OK? Please backup any data that you don't want lost in that directory before proceeding.", "MariaDB Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
