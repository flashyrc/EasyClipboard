using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace EasyClipboard
{
    class CustomApplicationContext:ApplicationContext
    {
        #region Private Variables
        private IContainer components;

        //Icon component
        private NotifyIcon mynotifyicon;

        //Stores the items to be displayed in menu
        private XmlDocument items;

        //Stores the state of link opening feature
        private bool isLinkOpenHelper;
        #endregion

        #region Constants
        //Name of icon file
        const string ICO_NAME = "copyme.ico";

        //Name to appear when you hover over the icon
        const string CONTEXT_NAME = "Easy Clipboard";
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomApplicationContext()
        {
            //By default turn on link opening feature
            isLinkOpenHelper = true;

            //Load items from xml file
            LoadXML();

            //Build the task bar context
            InitializeContext();
        }

        /// <summary>
        /// Build task bar context
        /// </summary>
        private void InitializeContext()
        {
            this.components = new System.ComponentModel.Container();

            this.mynotifyicon = new System.Windows.Forms.NotifyIcon(this.components)
            {
                ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip()
                {
                    ShowImageMargin = false
                },
                Visible = true
            };
            this.mynotifyicon.Icon = new Icon(ICO_NAME);
            this.mynotifyicon.Text = CONTEXT_NAME;
            this.mynotifyicon.Visible = true;

            //Load items into menu
            LoadItems();
        }

        /// <summary>
        /// Handler for context menu opening event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        /// <summary>
        /// Creates tool strip menu item
        /// </summary>
        /// <param name="displayText">Text to be displayed for item</param>
        /// <param name="copyText">Text to be copied (link or other)</param>
        /// <param name="eventHandler">Event handler when item is clicked</param>
        /// <returns></returns>
        private ToolStripMenuItem ToolStripMenuItemWithHandler(string displayText, string copyText, EventHandler eventHandler)
        {
            var item = new ToolStripMenuItem(displayText);
            item.Tag = copyText;
            if (eventHandler != null) { item.Click += eventHandler; }
            return item;
        }

        /// <summary>
        /// Handler for plain text item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyItem_Click(object sender, EventArgs e) 
        {
            Clipboard.SetText(((ToolStripDropDownItem)sender).Tag.ToString());
        }

        /// <summary>
        /// Handler for URL item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openURL_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(((ToolStripDropDownItem)sender).Tag.ToString());
            OpenLink openLinkWin = new OpenLink();
            openLinkWin.Show();
            openLinkWin.LinkString = ((ToolStripDropDownItem)sender).Tag.ToString();
   
        }

        /// <summary>
        /// Handler for Exit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitItem_Click(object sender, EventArgs e)
        {
            mynotifyicon.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// Handler for Refresh item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshItem_Click(object sender, EventArgs e)
        {
            LoadXML();
            LoadItems();
        }

        /// <summary>
        /// Handler for toggle link open feature item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkOpenFeature_Click(object sender, EventArgs e)
        {
            if (isLinkOpenHelper)
            {
                isLinkOpenHelper = false;
            }
            else
            {
                isLinkOpenHelper = true;
            }
            LoadXML();
            LoadItems();
        }

        /// <summary>
        /// Loads items variable with physical XML file
        /// </summary>
        private void LoadXML()
        {
            items = new XmlDocument();
            items.Load("items.xml");
        }

        /// <summary>
        /// Load items into context menu
        /// </summary>
        private void LoadItems()
        {
            mynotifyicon.ContextMenuStrip.Items.Clear();
            foreach (XmlNode x in items.SelectNodes("items/item"))
            {
                ToolStripMenuItem t;

                if (x.SelectNodes("item").Count > 0)
                {
                    t = ToolStripMenuItemWithHandler(x.Attributes["itemname"].Value, "", null);
                    
                    foreach (XmlNode y in x.SelectNodes("item"))
                    {
                        if (Is_Valid_Url(y.Attributes["itemvalue"].Value) && isLinkOpenHelper)
                        {
                            t.DropDown.Items.Add(ToolStripMenuItemWithHandler(y.Attributes["itemname"].Value, y.Attributes["itemvalue"].Value, openURL_Click));
                        }
                        else
                        {
                            t.DropDown.Items.Add(ToolStripMenuItemWithHandler(y.Attributes["itemname"].Value, y.Attributes["itemvalue"].Value, copyItem_Click));
                        }
                    }
                }
                else
                {
                    if (Is_Valid_Url(x.Attributes["itemvalue"].Value) && isLinkOpenHelper)
                    {
                        t = ToolStripMenuItemWithHandler(x.Attributes["itemname"].Value, x.Attributes["itemvalue"].Value, openURL_Click);
                    }
                    else
                    {
                        t = ToolStripMenuItemWithHandler(x.Attributes["itemname"].Value, x.Attributes["itemvalue"].Value, copyItem_Click);
                    }
                }
                mynotifyicon.ContextMenuStrip.Items.Add(t);
            }
            mynotifyicon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            mynotifyicon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Refresh", "", refreshItem_Click));
            if (isLinkOpenHelper)
            {
                mynotifyicon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Turn off link opening", "", linkOpenFeature_Click));
            }
            else
            {
                mynotifyicon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Turn on link opening", "", linkOpenFeature_Click));
            }
            mynotifyicon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Exit", "", exitItem_Click));
        }

        /// <summary>
        /// Check if text is a URL
        /// </summary>
        /// <param name="WebUrl">Text to be checked</param>
        /// <returns>Boolean value indicating if text supplied is a link of not</returns>
        private bool Is_Valid_Url(string WebUrl)
        {
            return Regex.IsMatch(WebUrl, @"(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&amp;:/~+#-]*[\w@?^=%&amp;/~+#-])?", RegexOptions.Singleline);
        }
    }
}
