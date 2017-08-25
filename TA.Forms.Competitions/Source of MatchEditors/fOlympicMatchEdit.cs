using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public partial class fOlympicMatchEdit : Form, Localizator.ILocalizableForm
    {
        public fOlympicMatchEdit()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public bool ReadOnly 
        {
            get {
                return !cbxPlayerA.Enabled;
            }
            set {
                cbxPlayerA.Enabled = !value;
                cbxPlayerB.Enabled = !value;
            }
        }
        public static bool Edit(MatchInfo aMatch, bool readOnly) 
        {
            if (aMatch.PlayerA.Id <= 0 || aMatch.PlayerB.Id <= 0)
                return false;
            fOlympicMatchEdit form = new fOlympicMatchEdit();
            form.ReadOnly = readOnly;
            if (aMatch.Looser_Match != null && aMatch.Looser_Match.WinnerId != -1 && aMatch.Looser_Match.PlayerA.Id * aMatch.Looser_Match.PlayerB.Id != 0)
                form.ReadOnly = true;
            if (aMatch.Winner_Match != null && aMatch.Winner_Match.WinnerId != -1 && aMatch.Winner_Match.PlayerA.Id * aMatch.Winner_Match.PlayerB.Id != 0)
                form.ReadOnly = true;
            

            form.ibxPointsA.Value = aMatch.PlayerA.Points;
            form.ibxPointsB.Value = aMatch.PlayerB.Points;
            form.cbxPlayerA.Text = aMatch.PlayerA.Name;
            form.cbxPlayerB.Text = aMatch.PlayerB.Name;
            switch (aMatch.Winner) 
            {
                case MatchLabel.PlayerLetters.A:
                    form.lblWinner.Text = aMatch.PlayerA.Label;
                    form.cbxPlayerA.Checked = true;
                    break;
                case MatchLabel.PlayerLetters.B:
                    form.lblWinner.Text = aMatch.PlayerB.Label;
                    form.cbxPlayerB.Checked = true;
                    break;
                case MatchLabel.PlayerLetters.Unknown:
                    form.lblWinner.Text = "";
                    break;
            }
            if (form.ShowDialog() == DialogResult.OK) 
            {
                aMatch.PlayerA.Points = Convert.ToInt32(form.ibxPointsA.Value);
                aMatch.PlayerB.Points = Convert.ToInt32(form.ibxPointsB.Value);
                if (form.cbxPlayerA.Checked)
                    aMatch.Winner = MatchLabel.PlayerLetters.A;
                else
                    if (form.cbxPlayerB.Checked)
                        aMatch.Winner = MatchLabel.PlayerLetters.B;                
                    else
                        aMatch.Winner = MatchLabel.PlayerLetters.Unknown;
                
                return true;
            }
            return false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (btnOk.Enabled) 
                DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cbxPlayerA_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPlayerA.Checked)
                cbxPlayerB.Checked = false;
            lblWinner.Text = cbxPlayerA.Checked ? cbxPlayerA.Text : "";
        }

        private void cbxPlayerB_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPlayerB.Checked)
                cbxPlayerA.Checked = false;
            lblWinner.Text = cbxPlayerB.Checked ? cbxPlayerB.Text : "";
        }

        private void cbxPlayerA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(btnOk.Enabled) 
                btnOk_Click(sender, EventArgs.Empty);
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.label1.Text = Localizator.Dictionary.GetString("WINNER_IS");
            this.label2.Text = Localizator.Dictionary.GetString("SCORE");
            this.Text = Localizator.Dictionary.GetString("MATCH_RESULT");
        }

        #endregion
    }
}