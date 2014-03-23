using System;
using System.Windows.Forms;
using Wnmp.Internals;

namespace Wnmp.Forms
{
    /// <summary>
    /// Form to show the update progress.
    /// </summary>
    public partial class UpdateProgress : Form
    {
        public UpdateProgress()
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

        private void Canceldl_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
