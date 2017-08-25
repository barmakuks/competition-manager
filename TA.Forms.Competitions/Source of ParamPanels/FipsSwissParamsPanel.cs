using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public partial class FipsSwissParamsPanel : CompetitionParamsPanel
    {
        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.label1.Text = Localizator.Dictionary.GetString("START_POINTS");
            this.cbxAllowRebuy.Text = Localizator.Dictionary.GetString("ALLOW_REBUY");
            this.label2.Text = Localizator.Dictionary.GetString("LATE_ENTRY_PTS");
            this.cbxAutosetStartPoints.Text = Localizator.Dictionary.GetString("SET_AUTO");
            this.btnSetStartPoints.Text = Localizator.Dictionary.GetString("SET_MANUALLY");
            this.lblPts.Text = Localizator.Dictionary.GetString("POINTS1");

        }
        public FipsSwissParamsPanel()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public FipsSwissParamsPanel(TA.Corel.Competition aCompetition) : base(aCompetition)
        {
            InitializeComponent();
            LocalizeComponents();
            ReadParameters();

        }
        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                if (Competition.Info.Status == CompetitionInfo.CompetitionState.RegistrationAndSeeding)
                {
                    txtStartPoints.ReadOnly = value;
                    txtLateStartPoints.ReadOnly = value;
                    cbxAllowRebuy.Enabled = !value;
                    cbxAutosetStartPoints.Enabled = !value;
                    txtStartPoints.Enabled = !value && cbxAutosetStartPoints.Checked; ;
                    btnSetStartPoints.Enabled = !value && !cbxAutosetStartPoints.Checked;
                }
                else { 
                    txtStartPoints.ReadOnly = true;
                    txtLateStartPoints.ReadOnly = true;
                    cbxAllowRebuy.Enabled = false;
                    cbxAutosetStartPoints.Enabled = false;
                    btnSetStartPoints.Enabled = false;
                }
                base.ReadOnly = value;
            }
        }
        public override bool WriteParameters()
        {
            (Competition as FppSwiss).StartPoints = Convert.ToInt32(txtStartPoints.Text.Trim());
            (Competition as FppSwiss).LateStartPoints = Convert.ToInt32(txtLateStartPoints.Text.Trim());
            (Competition as FppSwiss).AllowRebuy = cbxAllowRebuy.Checked;
            (Competition as FppSwiss).AutoSetStartPoints = cbxAutosetStartPoints.Checked;

            return base.WriteParameters();
        }
        public override void ReadParameters()
        {
            if (txtStartPoints == null)
                return;
            txtStartPoints.Text = (Competition as FppSwiss).StartPoints.ToString();
            txtLateStartPoints.Text = (Competition as FppSwiss).LateStartPoints.ToString();
            cbxAllowRebuy.Checked = (Competition as FppSwiss).AllowRebuy;
            cbxAutosetStartPoints.Checked = (Competition as FppSwiss).AutoSetStartPoints;
            txtLateStartPoints.Enabled = cbxAllowRebuy.Checked;

            btnSetStartPoints.Enabled = !cbxAutosetStartPoints.Checked;
            txtStartPoints.Enabled = cbxAutosetStartPoints.Checked;
        }

        private void cbxAllowRebuy_CheckedChanged(object sender, EventArgs e)
        {
            txtLateStartPoints.Enabled = cbxAllowRebuy.Checked;
        }

        private void cbxSetStartPoints_CheckedChanged(object sender, EventArgs e)
        {
            btnSetStartPoints.Enabled = !cbxAutosetStartPoints.Checked;
            txtStartPoints.Enabled = cbxAutosetStartPoints.Checked;
        }

        private void btnSetStartPoints_Click(object sender, EventArgs e)
        {            
            fPlayersStartPoints.EditStartPoints(Competition);
        }

    }
}
