using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wnmp.Forms
{
    public partial class dlUpdateProgress : Form
    {
        public dlUpdateProgress()
        {
            InitializeComponent();
        }

        private void Canceldl_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
