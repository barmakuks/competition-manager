using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public partial class OlympicParamsPanel : CompetitionParamsPanel
    {
        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.cbxThirdPlaceMatch.Text = Localizator.Dictionary.GetString("CREATE_3RD_PLACE");
        }
        public OlympicParamsPanel()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public OlympicParamsPanel(TA.Corel.Competition aCompetition)
            : base(aCompetition)
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
                    cbxThirdPlaceMatch.Enabled = !value;
                }
                else
                {
                    cbxThirdPlaceMatch.Enabled = false;
                }
                base.ReadOnly = value;
            }
        }
        public override void ReadParameters()
        {
            if (cbxThirdPlaceMatch == null) return;
            cbxThirdPlaceMatch.Checked = Competition.Info.Properties.GetBooleanValue("ThirdPlaceMatch", false);
        }
        public override bool WriteParameters()
        {
            Competition.Info.Properties["ThirdPlaceMatch"] = cbxThirdPlaceMatch.Checked.ToString();
            return base.WriteParameters();
        }

    }
}
