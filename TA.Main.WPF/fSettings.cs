using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TA.Main
{
    public partial class fSettings : Form, Localizator.ILocalizableForm
    {
        public fSettings()
        {
            InitializeComponent();
            LocalizeComponents();
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            label1.Text = Localizator.Dictionary.GetString("INTERFACE_LANG");
            btnOk.Text = Localizator.Dictionary.GetString("OK");
            btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.Text = Localizator.Dictionary.GetString("SETTINGS");
        }

        #endregion

        internal static bool Edit()
        {
            fSettings form = new fSettings();
            form.cbxLanguage.Items.AddRange(Localizator.Dictionary.GetLangauges());
            string lang = Settings.Language;

            foreach (Localizator.Language language in form.cbxLanguage.Items) 
            {
                if (language.Id == lang)
                    form.cbxLanguage.SelectedItem = language;
            }

            if (form.ShowDialog() == DialogResult.OK) 
            {
                string id = (form.cbxLanguage.SelectedItem as Localizator.Language).Id;
                if (lang != id) 
                {
                    Settings.Language = id;
                    return true;
                }
            }
            return false;            
        }
    }
}
