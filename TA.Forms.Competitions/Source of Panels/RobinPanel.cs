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
    public partial class RobinPanel : SwissPanel
    {
        public RobinPanel() : base()
        {            
            InitializeComponent();
            pnlTools.Visible = false;
        }
        protected override bool CanEditMatch(MatchInfo match)
        {
            return Competition.Info.Status == CompetitionInfo.CompetitionState.Playing;
        }
    }
}
