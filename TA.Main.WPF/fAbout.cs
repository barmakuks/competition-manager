using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TA.Corel;

namespace TA.Main
{
    public partial class fAbout : Form , Localizator.ILocalizableForm
    {
        public fAbout()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        private void ReadInfo() 
        {            
            lblEdition.Text = EditionManager.EditionString + EditionManager.Version;
            DateTime date = Utils.Utils.GetLastBuildDate();
            lblBuildDate.Text = String.Format(Localizator.Dictionary.GetString("BUILD_DATE"), date.ToString("dd.MM.yyyy HH:mm:ss"));            
            String str = "";
            if (LicenseManager.ConfirmLicenseDate())
            {                
                str = (Localizator.Dictionary.GetString("ORGANIZATION", " : ") + LicenseManager.Organization);
                str = str + '\n' + (Localizator.Dictionary.GetString("USERNAME", " : ") + LicenseManager.UserName);
                str = str + '\n' + (Localizator.Dictionary.GetString("EMAIL", " : ") + LicenseManager.EMail);
                str = str + '\n' + (Localizator.Dictionary.GetString("LICENSE_DATE", " : ") + LicenseManager.LicenseExpireDateFormated);
                btnRegister.Visible = false;
            }
            else
            {
                str = (Localizator.Dictionary.GetString("TRIAL_EXPIRE", " ") + LicenseManager.LicenseExpireDateFormated);
            }
            lblRegInfoBox.Text = str;
        }
        public static void ShowAbout()
        {
            fAbout form = new fAbout();
            form.ReadInfo();
            form.ShowDialog();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            fRegistationInfo.ShowRegistration();
            ReadInfo();
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            Text = Localizator.Dictionary.GetString("ABOUT");
            lblRegInfo.Text = Localizator.Dictionary.GetString("REG_INFO");
            btnRegister.Text = Localizator.Dictionary.GetString("REGISTER");
            btnOk.Text = Localizator.Dictionary.GetString("OK");
            lblBuildDate.Text = Localizator.Dictionary.GetString("BUILD_DATE");
        }

        #endregion

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http:\\" + lblCompetitionManagerCom.Text);
        }
    }
}