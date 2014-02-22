/*
This file is part of Wnmp.

    Wnmp is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Wnmp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Permissions;

using Wnmp.Helpers;
using Wnmp.Internals;

namespace Wnmp.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Declarations.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start("http://wnmp.x64architecture.com");
        }

        private void About_Load(object sender, EventArgs e)
        {
#if DEBUG
            label1.Text = "Wnmp Version: " + Application.ProductVersion + "-Dev";
            label2.Text = "Wnmp Control Panel Version: " + Program.formInstance.GetCPVER + "-Dev";
#else
            label1.Text = "Wnmp Version: " + Application.ProductVersion;
            label2.Text = "Wnmp Control Panel Version: " + Program.formInstance.CPVER;
#endif
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Blue;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }
    }
}
