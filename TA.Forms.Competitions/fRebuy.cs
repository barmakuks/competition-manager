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
    public partial class fRebuy : Form, Localizator.ILocalizableForm
    {
        public fRebuy()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        private void SetEnabled(bool setStartPoints) 
        {
            txtStartPoints.ReadOnly = !setStartPoints;
            txtAddPoints.ReadOnly = setStartPoints;

            this.ActiveControl = setStartPoints ? txtStartPoints : txtAddPoints;
        }
        public static int Edit(CompetitionPlayerInfo info, bool setStartPoints) 
        {
            fRebuy form = new fRebuy();
            form.txtFullName.Text = info.FullName;
            form.txtStartPoints.Text = info.StartPoints.ToString();
            form.txtPoints.Text = info.Points.ToString();
            form.txtRebuyPoints.Text = info.RebuyPoints.ToString();
            form.txtAvailablePoints.Text = info.AvailablePoints.ToString();
            form.txtNowAvailable.Text = info.AvailablePoints.ToString();
            form.txtAddPoints.Text = "0";
            form.SetEnabled(setStartPoints);
            if (form.ShowDialog() == DialogResult.OK) 
            {
                if (setStartPoints)
                {
                    if (form.txtStartPoints.Text == "")
                        form.txtStartPoints.Text = "0";
                    return Convert.ToInt32(form.txtStartPoints.Text);
                }
                else 
                {
                    if (form.txtAddPoints.Text == "")
                        form.txtAddPoints.Text = "0";
                    return Convert.ToInt32(form.txtAddPoints.Text);
                }
            }
            return 0;
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.label1.Text = Localizator.Dictionary.GetString("PLAYER");
            this.label2.Text = Localizator.Dictionary.GetString("AVAIL_PTS");
            this.label4.Text = Localizator.Dictionary.GetString("START");
            this.label3.Text = Localizator.Dictionary.GetString("EARNED");
            this.label5.Text = Localizator.Dictionary.GetString("REBUY_PTS");
            this.label6.Text = Localizator.Dictionary.GetString("TOTAL");
            this.label7.Text = Localizator.Dictionary.GetString("ADD_REMOVE");
            this.label8.Text = Localizator.Dictionary.GetString("AVAIL_PTS");
            this.Text = Localizator.Dictionary.GetString("ADD_REMOVE_PTS");
        }

        #endregion
    }
}
