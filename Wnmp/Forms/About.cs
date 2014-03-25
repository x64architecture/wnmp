/*
Copyright (c) Kurt Cancemi 2012-2014

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
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

using Wnmp.Internals;

namespace Wnmp.Forms
{
    /// <summary>
    /// Form that shows info about Wnmp
    /// </summary>
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

        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start("http://getwnmp.org");
        }

        private void About_Load(object sender, EventArgs e)
        {
            label1.Text = "Wnmp Version: " + Application.ProductVersion;
            label2.Text = "Wnmp Control Panel Version: " + Main.GetCPVER;
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
