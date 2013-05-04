using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wnmp
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            if (Wnmp.Properties.Settings.Default.editor == "")
            {
                editorTB.Text = "notpad.exe";
            }
            else
            {
                editorTB.Text = Wnmp.Properties.Settings.Default.editor;
            }
        }

        private void selecteditor_Click(object sender, EventArgs e)
        {
             String input = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "excutable files (*.exe)|*.exe|All files (*.*)|*.*";
            dialog.Title = "Select an editor";
            if (dialog.ShowDialog() == DialogResult.OK)
                input = dialog.FileName;
            editorTB.Text = dialog.FileName;
            Wnmp.Properties.Settings.Default.editor = dialog.FileName;
            Wnmp.Properties.Settings.Default.Save();
            if (input == String.Empty)
            Wnmp.Properties.Settings.Default.editor = "notepad.exe";
            Wnmp.Properties.Settings.Default.Save();
            editorTB.Text = Wnmp.Properties.Settings.Default.editor;
                return;
        }
    }
}
