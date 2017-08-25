using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TA.Competitions.Forms;
using TA.Corel;
using TA.Competitions;
using TA.DB.Manager;
using Sortition;

namespace TA.CompetitionControllers
{
    public class OlympicDEController: OlympicController
    {
        private OlympicDE FCompetition = null;
        public override Competition Competition 
        {
            get { return FCompetition; }
            set {
                if (value is OlympicDE)
                    FCompetition = value as OlympicDE;
            }
        }
        internal OlympicDEController() : base()
        {
        }
    }
}
