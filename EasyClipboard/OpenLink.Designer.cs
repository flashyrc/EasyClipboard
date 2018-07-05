namespace EasyClipboard
{
    partial class OpenLink
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
            this.IELink = new System.Windows.Forms.LinkLabel();
            this.ChromeLink = new System.Windows.Forms.LinkLabel();
            this.FFLink = new System.Windows.Forms.LinkLabel();
            this.CopyLink = new System.Windows.Forms.LinkLabel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IELink
            // 
            this.IELink.AutoSize = true;
            this.IELink.Location = new System.Drawing.Point(12, 27);
            this.IELink.Name = "IELink";
            this.IELink.Size = new System.Drawing.Size(57, 13);
            this.IELink.TabIndex = 0;
            this.IELink.TabStop = true;
            this.IELink.Text = "Open in IE";
            this.IELink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IELink_LinkClicked);
            // 
            // ChromeLink
            // 
            this.ChromeLink.AutoSize = true;
            this.ChromeLink.Location = new System.Drawing.Point(12, 51);
            this.ChromeLink.Name = "ChromeLink";
            this.ChromeLink.Size = new System.Drawing.Size(83, 13);
            this.ChromeLink.TabIndex = 1;
            this.ChromeLink.TabStop = true;
            this.ChromeLink.Text = "Open in Chrome";
            this.ChromeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChromeLink_LinkClicked);
            // 
            // FFLink
            // 
            this.FFLink.AutoSize = true;
            this.FFLink.Location = new System.Drawing.Point(12, 74);
            this.FFLink.Name = "FFLink";
            this.FFLink.Size = new System.Drawing.Size(59, 13);
            this.FFLink.TabIndex = 2;
            this.FFLink.TabStop = true;
            this.FFLink.Text = "Open in FF";
            this.FFLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FFLink_LinkClicked);
            // 
            // CopyLink
            // 
            this.CopyLink.AutoSize = true;
            this.CopyLink.Location = new System.Drawing.Point(12, 98);
            this.CopyLink.Name = "CopyLink";
            this.CopyLink.Size = new System.Drawing.Size(51, 13);
            this.CopyLink.TabIndex = 3;
            this.CopyLink.TabStop = true;
            this.CopyLink.Text = "Copy text";
            this.CopyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CopyLink_LinkClicked);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(12, 8);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "Title";
            // 
            // OpenLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 133);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.CopyLink);
            this.Controls.Add(this.FFLink);
            this.Controls.Add(this.ChromeLink);
            this.Controls.Add(this.IELink);
            this.Name = "OpenLink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Link";
            this.Load += new System.EventHandler(this.OpenLink_Load);
            this.Shown += new System.EventHandler(this.OpenLink_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel IELink;
        private System.Windows.Forms.LinkLabel ChromeLink;
        private System.Windows.Forms.LinkLabel FFLink;
        private System.Windows.Forms.LinkLabel CopyLink;
        private System.Windows.Forms.Label TitleLabel;
    }
}