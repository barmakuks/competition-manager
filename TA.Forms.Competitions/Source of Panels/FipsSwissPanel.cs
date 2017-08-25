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
    public partial class FipsSwissPanel : SwissPanel
    {
        public FipsSwissPanel()
        {
            InitializeComponent();
            LocalizeComponents();
            #region ObjectListView reinitialization
            #region Column RebuyPoints
            WindowSkin.ObjectListViewColumn col = new WindowSkin.ObjectListViewColumn();
            col.FormatString = "";
            col.Name = "RebuyPoints";
            col.Text = Localizator.Dictionary.GetString("ADD_PTS");
            col.TextAlignment = System.Drawing.StringAlignment.Center;
            col.Width = 40;
            col.Sortable = false;
            lvResults.Columns.Insert(3, col);
            #endregion
            #region Column AvailablePoints
            col = new WindowSkin.ObjectListViewColumn();
            col.FormatString = "";
            col.Name = "AvailablePoints";
            col.Text = Localizator.Dictionary.GetString("TOTAL");
            col.TextAlignment = System.Drawing.StringAlignment.Center;
            col.Width = 40;
            lvResults.Columns.Insert(4, col);
            #endregion
            lvResults.Width = lvResults.BestWidth;
            #endregion

            lvResults.Columns["TotalPoints"].ConvertValueString = false;
            lvResults.Columns["Tag"].ConvertValueString = false;
            lblPrizeCount.Visible = false;
            ibxPrizeCount.Visible = false;
        }
        private void SetRebuyColumnsVisibility(bool visible) 
        {
            lvResults.Columns["RebuyPoints"].Visible = visible;
            lvResults.Columns["AvailablePoints"].Visible = visible;
            lvResults.Width = lvResults.BestWidth;
            pictMain.Left = lvResults.Width;
            pictMain.Width = Width - lvResults.Width;
        }
        public override void OpenCompetition(TA.Corel.Competition competition)
        {
            if (competition.Players.Count > 1)
                competition.Info.Properties["PRIZE_COUNT"] = (competition.Players.Count).ToString();
            else
                competition.Info.Properties["PRIZE_COUNT"] = "1";
            base.OpenCompetition(competition);
            SetRebuyColumnsVisibility((Competition as FppSwiss).AllowRebuy);
        }
        protected override bool EditMatch(TA.Corel.MatchInfo match, bool readOnly)
        {
            return fFipsMatchEdit.Edit(match, readOnly);
        }
        protected override MatchPainter GetMatchPainter()
        {
            return new FipsSwissMatchPainter();
        }
        public override void UpdateButtonsActivity()
        {
            base.UpdateButtonsActivity();
            btnRebuy.Enabled = btnNextRound.Enabled && Competition.Info.Properties.GetBooleanValue("AllowRebuy", false);
        }
        private void CompetitionFipsSwissPanel_OnAfterMatchPictureUpdate(object sender, EventArgs e)
        {
            UpdateButtonsActivity();
        }

        private void btnRebuy_Click(object sender, EventArgs e)
        {
            if (fPlayersStartPoints.Edit(Competition, (Competition as FppSwiss).LateStartPoints)) 
            {
                UpdateCurrentResults();
            }
        }
        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.btnRebuy.Text = Localizator.Dictionary.GetString("REBUY");
        }
    }
}
