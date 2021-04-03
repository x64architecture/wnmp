namespace Wnmp.UI
{
    partial class HTTPHeadersFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTTPHeadersFrm));
            this.httpHeadersListView = new System.Windows.Forms.ListView();
            this.httpHeaderName = new System.Windows.Forms.ColumnHeader();
            this.httpHeaderValue = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.getHeadersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urlTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // httpHeadersListView
            // 
            this.httpHeadersListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.httpHeadersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.httpHeaderName,
            this.httpHeaderValue});
            this.httpHeadersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.httpHeadersListView.FullRowSelect = true;
            this.httpHeadersListView.HideSelection = false;
            this.httpHeadersListView.Location = new System.Drawing.Point(0, 27);
            this.httpHeadersListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.httpHeadersListView.Name = "httpHeadersListView";
            this.httpHeadersListView.Size = new System.Drawing.Size(380, 358);
            this.httpHeadersListView.TabIndex = 5;
            this.httpHeadersListView.UseCompatibleStateImageBehavior = false;
            this.httpHeadersListView.View = System.Windows.Forms.View.Details;
            // 
            // httpHeaderName
            // 
            this.httpHeaderName.Text = "Header";
            this.httpHeaderName.Width = 123;
            // 
            // httpHeaderValue
            // 
            this.httpHeaderValue.Text = "Value";
            this.httpHeaderValue.Width = 203;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getHeadersToolStripMenuItem,
            this.urlTextBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(380, 27);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // getHeadersToolStripMenuItem
            // 
            this.getHeadersToolStripMenuItem.Name = "getHeadersToolStripMenuItem";
            this.getHeadersToolStripMenuItem.Size = new System.Drawing.Size(83, 23);
            this.getHeadersToolStripMenuItem.Text = "Get Headers";
            this.getHeadersToolStripMenuItem.Click += new System.EventHandler(this.GetHeadersToolStripMenuItem_Click);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(233, 23);
            this.urlTextBox.Text = "http://";
            this.urlTextBox.ToolTipText = "URL";
            // 
            // HTTPHeadersFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 385);
            this.Controls.Add(this.httpHeadersListView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "HTTPHeadersFrm";
            this.Text = "Get HTTP Headers";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView httpHeadersListView;
        private System.Windows.Forms.ColumnHeader httpHeaderName;
        private System.Windows.Forms.ColumnHeader httpHeaderValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem getHeadersToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox urlTextBox;
    }
}