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
    public partial class SwingParamsPanel : FipsSwissParamsPanel
    {
        public SwingParamsPanel()
        {
            InitializeComponent();
            LocalizeComponents();
            
        }
        public SwingParamsPanel(TA.Corel.Competition aCompetition)
            : base(aCompetition)
        {
            InitializeComponent();
            LocalizeComponents();
            ReadParameters();
        }

        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.lblBetsSequence.Text = Localizator.Dictionary.GetString("BETS_SEQUENCE");
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
                    txtBetSequence.ReadOnly = value;
                }
                else
                {
                    txtBetSequence.ReadOnly = true;
                }
                base.ReadOnly = value;
            }
        }
        public override bool WriteParameters()
        {
            (Competition as Swing).BetSequence = txtBetSequence.Text.Trim();
            return base.WriteParameters();
        }
        public override void ReadParameters()
        {
            if (txtBetSequence == null)
                return;
            txtBetSequence.Text = (Competition as Swing).BetSequence.ToString();
            base.ReadParameters();
        }

    }
}
