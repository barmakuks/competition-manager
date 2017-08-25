using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace TA.Main
{
    public partial class fCheckUpdate : Form, Localizator.ILocalizableForm
    {
        
        private fCheckUpdate()
        {
            InitializeComponent();
            LocalizeComponents();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        /*private void GoToDownload() 
        {
            System.Diagnostics.Process.Start(UrlToDownload);
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(delegate() { GoToDownload(); });
            t.Start();
            DialogResult = DialogResult.OK;
        }*/

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnOk.Text = Localizator.Dictionary.GetString("CLOSE");
            this.label1.Text = Localizator.Dictionary.GetString("NEW_VERSION_AVAILABLE");
            this.btnDownload.Text = Localizator.Dictionary.GetString("DOWNLOAD_NEW");
            this.Text = Localizator.Dictionary.GetString("CHECK_UPDATE");
        }

        #endregion
    }
}
