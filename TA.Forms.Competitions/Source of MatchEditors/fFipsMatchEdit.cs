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
    public partial class fFipsMatchEdit : Form, Localizator.ILocalizableForm
    {
        private int startPointsA;
        private int startPointsB;
        private int PointsA {
            get {
                return Convert.ToInt32(txtPointsA.Text);
            }
            set {
                if (startPointsB < value) // нельзя отобрать больше чем есть
                    return;
                if (value + startPointsA < 0)
                    return;
                txtPointsA.Text = ToString(value);
                txtPointsB.Text = ToString(-1 * value);
            }
        }
        private int PointsB
        {
            get
            {
                return Convert.ToInt32(txtPointsB.Text);
            }
        }

        public fFipsMatchEdit()
        {
            InitializeComponent();
            LocalizeComponents();
            txtPointsA.MouseWheel += new MouseEventHandler(txtPointsA_MouseWheel);
            txtPointsB.MouseWheel += new MouseEventHandler(txtPointsB_MouseWheel); 
        }

        void txtPointsB_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) PointsA--;
            if (e.Delta < 0) PointsA++;
        }

        void txtPointsA_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) PointsA++;
            if (e.Delta < 0) PointsA--;
        }
        private string ToString(int points)         
        {
            if (points > 0)
                return "+" + points.ToString();
            else return points.ToString();
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (startPointsB + PointsB <= 0) // нельзя отобрать больше чем есть
                return;
            PointsA++;
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            PointsA--;
        }

        public static bool Edit(MatchInfo aMatch, bool readOnly)
        {
            if (aMatch.PlayerA.Id <= 0 || aMatch.PlayerB.Id <= 0)
                return false;
            fFipsMatchEdit form = new fFipsMatchEdit();
            if (aMatch.Winner == MatchLabel.PlayerLetters.Unknown)
            {
                form.pnlMatchResults.Enabled = false;
                form.rbtnNoResult.Checked = true;
            }
            else
            {
                form.rbtnMatchOver.Checked = true;
                form.pnlMatchResults.Enabled = true;
                form.startPointsA = aMatch.PlayerA.Points;
                form.startPointsB = aMatch.PlayerB.Points;
                form.txtPointsA.Text = aMatch.PlayerA.Points.ToString();
                form.txtPointsB.Text = aMatch.PlayerB.Points.ToString();
            }
                
            form.lblPlayerA.Text = aMatch.PlayerA.Name;
            form.lblPlayerB.Text = aMatch.PlayerB.Name;
            form.btnOk.Enabled = !readOnly;
            form.startPointsA = aMatch.PlayerA.Tag;
            form.startPointsB = aMatch.PlayerB.Tag;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.rbtnMatchOver.Checked)
                {
                    aMatch.PlayerA.Points = Convert.ToInt32(form.txtPointsA.Text);
                    aMatch.PlayerB.Points = Convert.ToInt32(form.txtPointsB.Text);
                    if (aMatch.PlayerA.Points == aMatch.PlayerB.Points)
                        aMatch.Winner = MatchLabel.PlayerLetters.Draw;
                    if (aMatch.PlayerA.Points > aMatch.PlayerB.Points)
                        aMatch.Winner = MatchLabel.PlayerLetters.A;
                    if (aMatch.PlayerA.Points < aMatch.PlayerB.Points)
                        aMatch.Winner = MatchLabel.PlayerLetters.B;
                }
                else 
                {
                    aMatch.PlayerA.Points = 0;
                    aMatch.PlayerB.Points = 0;
                }
                return true;
            }
            return false;
        }

        private void rbtnNoResult_CheckedChanged(object sender, EventArgs e)
        {
            pnlMatchResults.Enabled = rbtnMatchOver.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtPointsB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                PointsA++;
            if (e.KeyCode == Keys.Up)
                PointsA--;
        }

        private void txtPointsA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                PointsA--;
            if (e.KeyCode == Keys.Up)
                PointsA++;
        }




        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.rbtnNoResult.Text = Localizator.Dictionary.GetString("MATCH_NOT_FINISHED");
            this.rbtnMatchOver.Text = Localizator.Dictionary.GetString("MATCH_RESULT");
            this.Text = Localizator.Dictionary.GetString("MATCH_RESULT");
        }

        #endregion
    }
}
