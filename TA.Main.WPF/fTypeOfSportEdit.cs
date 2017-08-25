using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.DB.Manager;

namespace TA.Main
{
    public partial class fTypeOfSportEdit : Form, Localizator.ILocalizableForm
    {
        private fTypeOfSportEdit()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        private TypeOfSportList FList;        
        private TypeOfSport Sport 
        {
            get { 
                return new TypeOfSport(ibxId.Value, txtName.Text); 
            }
            set {
                ibxId.Value = value.Id;
                txtName.Text = value.Name;
            }
        }
        public static bool Edit(TypeOfSport sport, TypeOfSportList list) 
        {
            fTypeOfSportEdit form = new fTypeOfSportEdit();
            form.ibxId.Enabled = false;
            form.Sport = sport;            
            form.FList = list;
            if (form.ShowDialog() == DialogResult.OK) 
            {
                sport.Name = form.Sport.Name;
                list[sport.Id].Name = sport.Name;
                DatabaseManager.CurrentDb.SaveTypeOfSport(sport);
                return true;
            }
            return false;
        }
        public static bool New(out TypeOfSport sport, TypeOfSportList list) 
        {
            sport = new TypeOfSport();
            fTypeOfSportEdit form = new fTypeOfSportEdit();
            int new_id = 1;
            foreach (TypeOfSport sp in list.Values)
            {
                if (new_id == sp.Id)
                    new_id++;
            }
            sport.Id = new_id;
            form.FList = list;
            form.ibxId.Value = new_id;
            form.ibxId.Enabled = true;
            form.btnOk.Enabled = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                sport = form.Sport;
                DatabaseManager.CurrentDb.SaveTypeOfSport(sport);
                list.Add(sport.Id, sport);
                return true;
            }
            return false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ibxId.Enabled) 
            {
                foreach (TypeOfSport sport in FList.Values) 
                {
                    if (ibxId.Value == sport.Id) 
                    {
                        WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("RATING_EXISTS"));
                        return;
                    }
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = txtName.Text.Trim() != "";
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.label1.Text = Localizator.Dictionary.GetString("RATING_LIST_ID");
            this.label2.Text = Localizator.Dictionary.GetString("TITLE");
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.Text = Localizator.Dictionary.GetString("RATING_LIST");
        }

        #endregion
    }
}
