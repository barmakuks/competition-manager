using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace TA.Main
{
    public partial class fRegistationInfo : Form, Localizator.ILocalizableForm
    {
        public fRegistationInfo()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        internal static bool ShowRegistration()
        {
            fRegistationInfo form = new fRegistationInfo();           
            
            form.txtOrganization.Text = LicenseManager.Organization;
            form.txtName.Text = LicenseManager.UserName;
            form.txtEMail.Text = LicenseManager.EMail;
            form.ShowDialog();
            return LicenseManager.ConfirmLicenseDate();
        }

        private void txtKeyIn_TextChanged(object sender, EventArgs e)
        {
            btnMakeKeyOut.Enabled = txtActivationKey.Text != "";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtRegistrationKey.Text != "") 
            {
                if (LicenseManager.AddRegistrationKey(txtRegistrationKey.Text))
                {
                    string message = String.Format(Localizator.Dictionary.GetString("LICENSE_VALIDITY"), LicenseManager.LicenseExpireDateFormated);
                    WindowSkin.MessageBox.Show(message);
                    Close();
                }
                else 
                {
                    WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("ENTER_VALID_REG_KEY"));
                }
                    
            }
        }

        private void btnMakeKeyOut_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || txtEMail.Text.Trim() == "")
            {
                WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("FILL_NAME_EMAIL"));
                return;
            }
            LicenseManager.Organization = txtOrganization.Text;
            LicenseManager.EMail = txtEMail.Text;
            LicenseManager.UserName = txtName.Text;
            //LicenseManager.WriteUserInfoToRegistry();
            txtActivationKey.Text = LicenseManager.GetActivationKey();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //Clipboard.SetData(DataFormats.Text, txtActivationKey.Text);
            Set2Clipboard(txtActivationKey.Text);
        }
        void Set2Clipboard(string sentence)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    Clipboard.SetText(sentence, TextDataFormat.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Clipboard.SetText error", ex.Message);
                }
            });
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.label6.Text = Localizator.Dictionary.GetString("EMAIL", " *");
            this.label3.Text = Localizator.Dictionary.GetString("ORGANIZATION");
            this.label2.Text = Localizator.Dictionary.GetString("USERNAME"," *");
            this.btnRegister.Text = Localizator.Dictionary.GetString("ACTIVATE");
            this.btnMakeKeyOut.Text = Localizator.Dictionary.GetString("GENERATE_REG_CODE");
            this.label5.Text = Localizator.Dictionary.GetString("ACTIVATION_KEY");
            this.label4.Text = Localizator.Dictionary.GetString("REG_KEY");
            this.label1.Text = Localizator.Dictionary.GetString("ENTER_ACTIVATION_CODE");
            this.label7.Text = Localizator.Dictionary.GetString("LICENSE_RENEW_DESCRIPTION");
            this.label8.Text = Localizator.Dictionary.GetString("SEND_REG_CODE");
            this.btnCopy.Text = Localizator.Dictionary.GetString("COPY_CLIP");
            this.btnEmail.Text = Localizator.Dictionary.GetString("SEND_EMAIL");
            this.btnClose.Text = Localizator.Dictionary.GetString("CLOSE");
            this.Text = Localizator.Dictionary.GetString("SOFT_REG");
        }

        #endregion
    }
}