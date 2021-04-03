namespace Wnmp.UI
{
    partial class HostToIPFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostToIPFrm));
            this.ipAddressesListBox = new System.Windows.Forms.ListBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.hostToIPButton = new System.Windows.Forms.Button();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ipAddressesListBox
            // 
            this.ipAddressesListBox.FormattingEnabled = true;
            this.ipAddressesListBox.ItemHeight = 15;
            this.ipAddressesListBox.Location = new System.Drawing.Point(52, 61);
            this.ipAddressesListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ipAddressesListBox.Name = "ipAddressesListBox";
            this.ipAddressesListBox.Size = new System.Drawing.Size(166, 79);
            this.ipAddressesListBox.TabIndex = 12;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(12, 61);
            this.ipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(33, 15);
            this.ipLabel.TabIndex = 11;
            this.ipLabel.Text = "IP(s):";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(12, 20);
            this.hostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(35, 15);
            this.hostLabel.TabIndex = 10;
            this.hostLabel.Text = "Host:";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(170, 196);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(88, 27);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // hostToIPButton
            // 
            this.hostToIPButton.Location = new System.Drawing.Point(90, 148);
            this.hostToIPButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hostToIPButton.Name = "hostToIPButton";
            this.hostToIPButton.Size = new System.Drawing.Size(88, 27);
            this.hostToIPButton.TabIndex = 8;
            this.hostToIPButton.Text = "Host To IP";
            this.hostToIPButton.UseVisualStyleBackColor = true;
            this.hostToIPButton.Click += new System.EventHandler(this.HostToIpButton_Click);
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(52, 16);
            this.hostTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(166, 23);
            this.hostTextBox.TabIndex = 7;
            // 
            // HostToIPFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 239);
            this.Controls.Add(this.ipAddressesListBox);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.hostToIPButton);
            this.Controls.Add(this.hostTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "HostToIPFrm";
            this.Text = "Host To IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ipAddressesListBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button hostToIPButton;
        private System.Windows.Forms.TextBox hostTextBox;
    }
}