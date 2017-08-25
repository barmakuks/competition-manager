using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Localizator;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public partial class fSwingMatchEdit : Form, ILocalizableForm
    {
        public fSwingMatchEdit()
        {
            InitializeComponent();
            LocalizeComponents();
        }

        public static bool Edit(MatchInfo aMatch, bool readOnly, int max_points)
        {
            if (aMatch.PlayerA.Id <= 0 || aMatch.PlayerB.Id <= 0)
                return false;
            fSwingMatchEdit form = new fSwingMatchEdit();
            max_points = Math.Min(max_points, Math.Min(aMatch.PlayerA.Tag, aMatch.PlayerB.Tag));
            form.divPoints.Init(aMatch.PlayerA.Tag, aMatch.PlayerB.Tag, aMatch.PlayerA.Points, aMatch.PlayerB.Points, max_points);
            form.lblPlayerA.Text = aMatch.PlayerA.Name;
            form.lblPlayerB.Text = aMatch.PlayerB.Name;
            form.btnOk.Enabled = !readOnly;
            form.lblBetRate.Text = Localizator.Dictionary.GetString("BET_RATE", " : ") + max_points;
            if (form.ShowDialog() == DialogResult.OK)
            {
                aMatch.Winner = MatchLabel.PlayerLetters.Unknown;
                aMatch.PlayerA.Points = form.divPoints.LeftValue;
                aMatch.PlayerB.Points = form.divPoints.RightValue;
                if(aMatch.PlayerA.Points > aMatch.PlayerB.Points)
                    aMatch.Winner = MatchLabel.PlayerLetters.A;
                if (aMatch.PlayerA.Points < aMatch.PlayerB.Points)
                    aMatch.Winner = MatchLabel.PlayerLetters.B;
                return true;
            }
            return false;
        }


        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.Text = Localizator.Dictionary.GetString("MATCH_RESULT");
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
