using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace EasyClipboard
{
    public partial class OpenLink : Form
    {
        public string LinkString { get; set; }

        public OpenLink()
        {
            InitializeComponent();
        }

        private void OpenLink_Load(object sender, EventArgs e)
        {
        }

        private void IELink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("iexplore.exe", LinkString);
            this.Dispose();
        }

        private void ChromeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("chrome.exe", LinkString);
            this.Dispose();
        }

        private void FFLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("firefox.exe", LinkString);
            this.Dispose();
        }

        private void CopyLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(LinkString);
            this.Dispose();
        }

        private void OpenLink_Shown(object sender, EventArgs e)
        {
            TitleLabel.Text = "<" + LinkString + "> ?"; 
        }
    }
}
