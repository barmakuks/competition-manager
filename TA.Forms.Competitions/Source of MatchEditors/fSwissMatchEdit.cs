using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public partial class fSwissMatchEdit : Form, Localizator.ILocalizableForm
    {
        public fSwissMatchEdit()
        {
            InitializeComponent();
            LocalizeComponents();
        }

        public static bool Edit(MatchInfo aMatch, bool readOnly)
        {
            if (aMatch.PlayerA.Id <= 0 || aMatch.PlayerB.Id <= 0)
                return false;
            fSwissMatchEdit form = new fSwissMatchEdit();
            form.rbtnWinnerA.Text += aMatch.PlayerA.Name;
            form.rbtnWinnerB.Text += aMatch.PlayerB.Name;
            switch (aMatch.Winner)
            {
                case MatchLabel.PlayerLetters.A:
                    form.rbtnWinnerA.Checked = true;
                    break;
                case MatchLabel.PlayerLetters.B:
                    form.rbtnWinnerB.Checked = true;
                    break;
                case MatchLabel.PlayerLetters.Draw:
                    form.rbtnDraw.Checked = true;
                    break;
                case MatchLabel.PlayerLetters.Unknown:
                    form.rbtnNoResult.Checked = true;
                    break;
            }
            form.btnOk.Enabled = !readOnly;
            if (form.ShowDialog() == DialogResult.OK)
            {
                aMatch.PlayerA.Points = 0;
                aMatch.PlayerB.Points = 0;
                aMatch.Winner = MatchLabel.PlayerLetters.Unknown;

                if (form.rbtnDraw.Checked)
                {
                    aMatch.PlayerA.Points = 1;
                    aMatch.PlayerB.Points = 1;
                    aMatch.Winner = MatchLabel.PlayerLetters.Draw;
                }
                if (form.rbtnWinnerA.Checked)
                {
                    aMatch.PlayerA.Points = 2;
                    aMatch.PlayerB.Points = 0;
                    aMatch.Winner = MatchLabel.PlayerLetters.A;
                }
                if (form.rbtnWinnerB.Checked)
                {
                    aMatch.PlayerA.Points = 0;
                    aMatch.PlayerB.Points = 2;
                    aMatch.Winner = MatchLabel.PlayerLetters.B;
                }
                return true;
            }
            return false;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnOk.Text = Localizator.Dictionary.GetString( "OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.rbtnNoResult.Text = Localizator.Dictionary.GetString("MATCH_NOT_FINISHED");
            this.rbtnWinnerA.Text = Localizator.Dictionary.GetString("WINNER_IS");
            this.rbtnDraw.Text = Localizator.Dictionary.GetString("MATCH_DRAW");
            this.rbtnWinnerB.Text = Localizator.Dictionary.GetString("WINNER_IS");
            this.Text = Localizator.Dictionary.GetString("MATCH_RESULT");
        }

        #endregion
    }
}
