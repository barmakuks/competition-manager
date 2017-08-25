using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.Competitions;
using TA.DB.Manager;

namespace TA.Main
{
    public partial class fCompetitionInfo : Form, Localizator.ILocalizableForm
    {
        private fCompetitionInfo()
        {
            InitializeComponent();
            LocalizeComponents();
            cbxGameType.BackColor = WindowSkin.Palette.TextBackColor;
            cbxGameType.ForeColor = WindowSkin.Palette.ForeColor;
            cbxCompetitionType.BackColor = WindowSkin.Palette.TextBackColor;
            cbxCompetitionType.ForeColor = WindowSkin.Palette.ForeColor;
        }
        public static bool Edit(CompetitionInfo info) 
        {
            fCompetitionInfo form = new fCompetitionInfo();
            form.cbxChangesRating.Checked = info.ChangesRating;
            form.txtCompetitionName.Text = info.Name;
            form.cbxGameType.Items.AddRange(Globals.Games.Values.ToArray());
            form.cbxGameType.SelectedItem = info.SportType;
            form.cbxCompetitionType.Items.Clear();
            form.cbxCompetitionType.Items.AddRange(CompetitionType.TypeList.Values.ToArray());
            form.cbxCompetitionType.SelectedItem = info.CompetitionType;

            if (form.ShowDialog() == DialogResult.OK) 
            {
                info.Name = form.txtCompetitionName.Text.Trim();
                info.SportType = (TypeOfSport)(form.cbxGameType.SelectedItem);
                info.CompetitionType = form.cbxCompetitionType.SelectedItem as CompetitionType;
                info.ChangesRating = form.cbxChangesRating.Checked && form.cbxChangesRating.Enabled;
                return true;
            }
            return false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(cbxGameType.SelectedIndex != -1 && txtCompetitionName.Text != "" && cbxCompetitionType.SelectedItem != null)
                DialogResult = DialogResult.OK;
        }

        private void cbxCompetitionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompetitionType type = cbxCompetitionType.SelectedItem as CompetitionType ;
            if (type != null)
            {
                cbxChangesRating.Enabled = type.CanChangeRating;
            }
            else
                cbxChangesRating.Enabled = false;
            btnOk.Enabled = cbxGameType.SelectedIndex != -1 && txtCompetitionName.Text != "" && cbxCompetitionType.SelectedItem != null;
        }



        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.cbxChangesRating.Text = Localizator.Dictionary.GetString("RATING_COMPETITION");
            this.label4.Text = Localizator.Dictionary.GetString("GAME");
            this.label2.Text = Localizator.Dictionary.GetString("COMPETITION_FORMAT");
            this.label1.Text = Localizator.Dictionary.GetString("COMPETITION_TITLE");
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.Text = Localizator.Dictionary.GetString("COMPETITION_INFO");
        }

        #endregion
    }
}
