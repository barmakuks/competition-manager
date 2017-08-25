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
    public partial class CompetitionSwissParamsPanel : CompetitionParamsPanel
    {
        public CompetitionSwissParamsPanel()
            : base()
        {
            InitializeComponent();
        }

        public CompetitionSwissParamsPanel(Competition aCompetition) : base(aCompetition)
        {
            InitializeComponent();
        }
    }
}
