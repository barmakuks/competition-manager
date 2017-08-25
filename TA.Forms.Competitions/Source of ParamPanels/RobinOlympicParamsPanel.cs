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
    public partial class RobinOlympicParamsPanel : CompetitionParamsPanel
    {
        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.label1.Text = Localizator.Dictionary.GetString("NUMBER_OF_GROUP");
            this.label2.Text = Localizator.Dictionary.GetString("PLAYOFF_PLAYER_NUMBER");
            this.cbxThirdPlaceMatch.Text = Localizator.Dictionary.GetString("CREATE_3RD_PLACE");
        }
        public RobinOlympicParamsPanel() 
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public RobinOlympicParamsPanel(RobinOlympic aCompetition) : base(aCompetition)
        {
            InitializeComponent();
            LocalizeComponents();
            ReadParameters();
        }
        public override void ReadParameters()
        {
            if (ibxGroupCount == null)
                return;
            ibxGroupCount.InitValue((Competition as RobinOlympic).GroupCount);
            ibxKnockoutPlayersCount.InitValue((Competition as RobinOlympic).KOPlayerCount);
            ibxKnockoutPlayersCount.MinimumValue = ibxGroupCount.Value;
            cbxThirdPlaceMatch.Checked = (Competition as RobinOlympic).PlayThirdPlaceMatch;
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
                    ibxGroupCount.Enabled = !value;
                    ibxKnockoutPlayersCount.Enabled = !value;
                    cbxThirdPlaceMatch.Enabled = !value;
                }
                else
                {
                    ibxGroupCount.Enabled = false;
                    ibxKnockoutPlayersCount.Enabled = false;
                    cbxThirdPlaceMatch.Enabled = false;
                }
                base.ReadOnly = value;
            }
        }
        public override bool WriteParameters()
        {
            (Competition as RobinOlympic).GroupCount = ibxGroupCount.Value;
            (Competition as RobinOlympic).KOPlayerCount = ibxKnockoutPlayersCount.Value;
            (Competition as RobinOlympic).PlayThirdPlaceMatch = cbxThirdPlaceMatch.Checked;
            return base.WriteParameters();
        }

        private int ibxGroupCount_HowToChangeValue(object sender, int prevValue, int nextValue)
        {
            if (prevValue < nextValue)
                return prevValue * 2;
            if (prevValue > nextValue)
                return prevValue / 2;
            return nextValue;
        }

        private void ibxGroupCount_ValueChanged(object sender, EventArgs e)
        {
            ibxKnockoutPlayersCount.MinimumValue = ibxGroupCount.Value;
        }

    }
}
