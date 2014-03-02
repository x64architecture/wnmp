using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Wnmp.Internals;

namespace Wnmp.Forms
{
    public partial class HostToIPForm : Form
    {
        public HostToIPForm()
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

        private void HostToIP(string host, out IPAddress[] ip)
        {
            ip = Dns.GetHostAddresses(host);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Go_Click(object sender, EventArgs e)
        {
            IPAddresses.Items.Clear();
            if (host.Text != String.Empty)
            {
                try
                {
                    if (host.Text.Contains("http://") || host.Text.Contains("https://"))
                    { MessageBox.Show("Invalid Format"); }
                    else
                    {
                        IPAddress[] ips;
                        HostToIP(host.Text, out ips);

                        foreach (IPAddress ip in ips)
                        {
                            IPAddresses.Items.Add(ip.ToString());
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

    }
}
