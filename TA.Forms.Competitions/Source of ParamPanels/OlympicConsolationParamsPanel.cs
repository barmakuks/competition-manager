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
    public partial class OlympicConsolationParamsPanel : OlympicParamsPanel
    {
        public OlympicConsolationParamsPanel()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.label1.Text = Localizator.Dictionary.GetString("NUMBER_OF_PRIZE");
            this.label2.Text = Localizator.Dictionary.GetString("IN_CONSOLATION");
            this.label3.Text = Localizator.Dictionary.GetString("IN_MAIN");
        }
        public OlympicConsolationParamsPanel(Competition aCompetition)
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
                    intMainPrize.Enabled = !value;
                    intConsolationPrize.Enabled = !value;
                }
                else
                {
                    intMainPrize.Enabled = false;
                    intConsolationPrize.Enabled = false;
                }
                base.ReadOnly = value;

            }
        }

        public override void ReadParameters()
        {
            if (intMainPrize == null) return;
            intMainPrize.Value = Competition.Info.Properties.GetInt32Value("MainPrizePlaces", 4);
            intConsolationPrize.Value = Competition.Info.Properties.GetInt32Value("ConsolationPrizePlaces", 2);
        }
        public override bool WriteParameters()
        {
            Competition.Info.Properties["MainPrizePlaces"] = intMainPrize.Value.ToString();
            Competition.Info.Properties["ConsolationPrizePlaces"] = intConsolationPrize.Value.ToString();
            return base.WriteParameters();
        }     

        private int intMainPrize_HowToChangeValue(object sender, int prevValue, int nextValue)
        {
            if (prevValue < nextValue)
                return prevValue * 2;
            if (prevValue > nextValue)
                return prevValue / 2;
            return default(int);
        }


    }
}
