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
    public partial class SwingPanel : FipsSwissPanel
    {
        public SwingPanel()
        {
            InitializeComponent();
            LocalizeComponents();
            lvResults.Columns["TotalPoints"].ConvertValueString = false;
            lvResults.Columns["Tag"].ConvertValueString = false;
            lblPrizeCount.Visible = false;
            ibxPrizeCount.Visible = false;
            lblRoundCount.Visible = false;
        }
        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.lvResults.Columns["Tag"].Text = Localizator.Dictionary.GetString("M");
        }
        
        protected override bool EditMatch(TA.Corel.MatchInfo match, bool readOnly)
        {
            bool result = fSwingMatchEdit.Edit(match, readOnly, (Competition as Swing).GetRoundMaxPoints(match.Label.Round));
            return result;
        }
        public override void UpdateButtonsActivity()
        {
            base.UpdateButtonsActivity();
            int pc = 0;
            List<CompetitionPlayerInfo> results = (Competition as Swing).PlayersResults;
            if (results != null) 
            {
                foreach (CompetitionPlayerInfo res in results)
                {
                    if (res.AvailablePoints > 0)
                        pc++;
                }
            }
            btnNextRound.Enabled = btnNextRound.Enabled && pc > 1;
        }
    }
}
