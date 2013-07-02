using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Wnmp.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start("http://wnmp.x64architecture.com");
        }

        private void About_Load(object sender, EventArgs e)
        {
            label1.Text = "Wnmp Version: " + Application.ProductVersion;
            label2.Text = "Wnmp Control Panel Version: " + Program.formInstance.CPVER;
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
