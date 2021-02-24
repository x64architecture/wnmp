namespace Wnmp.Wnmp.UI
{
    partial class SetupMariaDB
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupMariaDB));
            this.setupButton = new System.Windows.Forms.Button();
            this.rootPasswordTextBox = new System.Windows.Forms.TextBox();
            this.rootPasswordLabel = new System.Windows.Forms.Label();
            this.allowRemoteRootAccessCheckbox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(220, 85);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(75, 23);
            this.setupButton.TabIndex = 0;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
            // 
            // rootPasswordTextBox
            // 
            this.rootPasswordTextBox.Location = new System.Drawing.Point(100, 21);
            this.rootPasswordTextBox.Name = "rootPasswordTextBox";
            this.rootPasswordTextBox.Size = new System.Drawing.Size(144, 20);
            this.rootPasswordTextBox.TabIndex = 1;
            this.rootPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // rootPasswordLabel
            // 
            this.rootPasswordLabel.AutoSize = true;
            this.rootPasswordLabel.Location = new System.Drawing.Point(12, 24);
            this.rootPasswordLabel.Name = "rootPasswordLabel";
            this.rootPasswordLabel.Size = new System.Drawing.Size(82, 13);
            this.rootPasswordLabel.TabIndex = 3;
            this.rootPasswordLabel.Text = "Root Password:";
            // 
            // allowRemoteRootAccessCheckbox
            // 
            this.allowRemoteRootAccessCheckbox.AutoSize = true;
            this.allowRemoteRootAccessCheckbox.Checked = true;
            this.allowRemoteRootAccessCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowRemoteRootAccessCheckbox.Location = new System.Drawing.Point(100, 47);
            this.allowRemoteRootAccessCheckbox.Name = "allowRemoteRootAccessCheckbox";
            this.allowRemoteRootAccessCheckbox.Size = new System.Drawing.Size(144, 17);
            this.allowRemoteRootAccessCheckbox.TabIndex = 5;
            this.allowRemoteRootAccessCheckbox.Text = "Allow remote root access";
            this.toolTip.SetToolTip(this.allowRemoteRootAccessCheckbox, "Required to be able to login as root in the mysql shell and in phpMyAdmin");
            this.allowRemoteRootAccessCheckbox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(250, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Visible";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 15000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // SetupMariaDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 120);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.allowRemoteRootAccessCheckbox);
            this.Controls.Add(this.rootPasswordLabel);
            this.Controls.Add(this.rootPasswordTextBox);
            this.Controls.Add(this.setupButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupMariaDB";
            this.Text = "Setup MariaDB";
            this.Shown += new System.EventHandler(this.SetupMariaDB_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.TextBox rootPasswordTextBox;
        private System.Windows.Forms.Label rootPasswordLabel;
        private System.Windows.Forms.CheckBox allowRemoteRootAccessCheckbox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}