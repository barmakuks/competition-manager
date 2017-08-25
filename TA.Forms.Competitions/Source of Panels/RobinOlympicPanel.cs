using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.Competitions;

namespace TA.Competitions.Forms
{
    public partial class RobinOlympicPanel : CompetitionPanel
    {
        public RobinOlympicPanel(): base()
        {
            InitializeComponent();
            LocalizeComponents();
            OnMatchEdit += new OnMatchEdit(RobinOlympicPanel_OnMatchEdit);
        }

        GroupPaintersGroup FPainters = new GroupPaintersGroup();

        protected override MatchPainter GetMatchPainter()
        {
            return new OlympicMatchPainter();
        }
        
        public override Bitmap GetPicture(Brush backBrush) 
        {
            Bitmap bmp = new Bitmap(FBitmapSize.Width, FBitmapSize.Height);
            Graphics gr = Graphics.FromImage(bmp);
            if (backBrush != null)
            {
                gr.FillRectangle(backBrush, 0, 0, bmp.Width, bmp.Height);
            }
            foreach (MatchPainter painter in FPainters.MatchPainters.Values)
            {
                painter.Draw(gr);
            }
            foreach (GroupPainter painter in FPainters.GroupPainters.Values) 
            {
                painter.Draw(gr);
            }
            foreach (OlympicMatchPainter painter in FPainters.MatchPainters.Values)
            {
                painter.Draw(gr);
            }

            foreach (BrokenLine line in FPainters.BrokenLinePainters)
            {
                line.Draw(gr);
            }
            return bmp;
        }

        public override void CreateGrid() {
            GroupPainterSettings.Scale = Convert.ToSingle(ScalePicture);
            int DIFF = GroupPainterSettings.Scaled(20);
            FBitmapSize.Height = DIFF;
            FBitmapSize.Width = 0;

            RobinOlympic competition = FCompetition as RobinOlympic;
            int left = 20; int top = DIFF;
            FPainters.GroupPainters.Clear();

            foreach (GroupRobin group in competition.Groups.Values) 
            {
                if (FPainters.GroupPainters.Count < competition.GroupCount)
                {
                    GroupPainter painter = new GroupPainter();
                    painter.Left = left; painter.TopF = top;
                    painter.Players = group.Players.Values.ToArray();
                    painter.Matches = group.Matches;
                    FPainters.GroupPainters.Add(group.GroupNo, painter);
                    FBitmapSize.Width = Math.Max(FBitmapSize.Width, painter.Left + painter.Size.Width + DIFF);
                    FBitmapSize.Height += painter.Size.Height + DIFF;
                    top += painter.Size.Height + DIFF;
                }
                else 
                {                    
                    Size size;
                    Point location = new Point(FBitmapSize.Width + 30 , 0);
                    OlympicPanel.CreateOlympicGrid(group.Matches, FPainters, GroupPainterSettings.Scale, location, out size, AfterMatchEdit);
                    FBitmapSize.Width = Math.Max(FBitmapSize.Width, size.Width);
                    FBitmapSize.Height = Math.Max(FBitmapSize.Height, size.Height);
                }
            }

        }
        private void AfterMatchEdit(MatchPainter aMatchView)
        {
            MatchInfo aMatch = aMatchView.Match;
            MatchInfo winners_match = Competition.Matches.GetMatchByLabel(aMatch.Winners_MatchLabel);
            MatchInfo loosers_match = Competition.Matches.GetMatchByLabel(aMatch.Loosers_MatchLabel);

            MatchPlayer winner_place = null;
            if (winners_match != null)
            {
                switch (winners_match.Label.Letter)
                {
                    case MatchLabel.PlayerLetters.A:
                        winner_place = winners_match.PlayerA;
                        break;
                    case MatchLabel.PlayerLetters.B:
                        winner_place = winners_match.PlayerB;
                        break;
                }
            }
            MatchPlayer looser_place = null;
            if (loosers_match != null)
            {
                switch (loosers_match.Label.Letter)
                {
                    case MatchLabel.PlayerLetters.A:
                        looser_place = loosers_match.PlayerA;
                        break;
                    case MatchLabel.PlayerLetters.B:
                        looser_place = loosers_match.PlayerB;
                        break;
                }
            }

            MatchPlayer winner = aMatch.WinnerPlayer;
            MatchPlayer looser = aMatch.LooserPlayer;
            if (winner == null || looser == null)
            {
                if (winner_place != null)
                {
                    winner_place.Id = -1;
                    winner_place.Name = "Winner " + aMatch.Label.ToString();
                }
                if (looser_place != null)
                {
                    looser_place.Id = -1;
                    looser_place.Name = "Looser " + aMatch.Label.ToString();
                }
            }
            else
            {
                if (winner_place != null)
                {
                    winner_place.Id = winner.Id;
                    winner_place.Name = winner.Name;
                }
                if (looser_place != null)
                {
                    looser_place.Id = looser.Id;
                    looser_place.Name = looser.Name;
                }
            }
            if (winners_match != null)
                winners_match.Refresh();
            if (loosers_match != null)
                loosers_match.Refresh();

            TA.DB.Manager.DatabaseManager.CurrentDb.SetCompetitionPlayerPlace(Competition.Info.Id, aMatch.PlayerA.Id, "");
            TA.DB.Manager.DatabaseManager.CurrentDb.SetCompetitionPlayerPlace(Competition.Info.Id, aMatch.PlayerB.Id, "");
            Competition.Players[aMatch.PlayerA.Id].Place = "";
            Competition.Players[aMatch.PlayerB.Id].Place = "";

            if (aMatch.Winners_MatchLabel.Place != "" && aMatch.WinnerId != -1)
            {
                Competition.Players[winner.Id].Place = aMatch.Winners_MatchLabel.Place;
                TA.DB.Manager.DatabaseManager.CurrentDb.SetCompetitionPlayerPlace(Competition.Info.Id, aMatch.WinnerId, aMatch.Winners_MatchLabel.Place);
            }
            if (aMatch.Loosers_MatchLabel.Place != "" && aMatch.WinnerId != -1)
            {
                Competition.Players[looser.Id].Place = aMatch.Loosers_MatchLabel.Place;
                TA.DB.Manager.DatabaseManager.CurrentDb.SetCompetitionPlayerPlace(Competition.Info.Id, aMatch.LooserId, aMatch.Loosers_MatchLabel.Place);
            }
        }

        private void RobinOlympicPanel_OnMatchEdit(Point point)
        {
            bool first_round_complete = false;
            foreach (MatchPainter painter in FPainters.MatchPainters.Values)
            {
                first_round_complete = first_round_complete || painter.Match.PlayerA.Id > 0 || painter.Match.PlayerB.Id > 0;
                if (painter.In(point))
                {
                    if (painter.Match.PlayerA.Id == -1 || painter.Match.PlayerB.Id == -1)
                        return;
                    if (fOlympicMatchEdit.Edit(painter.Match, Competition.Info.Status == CompetitionInfo.CompetitionState.Finished))
                    {
                        Invalidate();
                        painter.UpdateChildren();
                        if (painter.OnAfterEdit != null)
                            painter.OnAfterEdit(painter);
                        UpdatePicture();
                        TA.DB.Manager.DatabaseManager.CurrentDb.WriteMatch(painter.Match, 1);
                    }
                    pictMain.Refresh();//
                }
            }
            foreach (GroupPainter painter in FPainters.GroupPainters.Values) 
            {
                if (painter.In(point))
                {
                    fGroupEditor.Edit(painter.Matches, Competition.Info.Status == CompetitionInfo.CompetitionState.Finished || first_round_complete);
                    pictMain.Picture = GetPicture(null);
                }
            }
            UpdateButtonsActivity();
        }
        private bool IsAllGroupMatchesOver 
        {
            get { 
                foreach (GroupPainter painter in FPainters.GroupPainters.Values) 
                {
                    foreach (MatchInfo match in painter.Matches.Values) 
                    {
                        if (!match.IsOver)
                            return false;
                    }
                }
                return true;
            }
        }
        private bool IsAnyKOMatchesExists 
        {
            get {
                foreach (MatchPainter painter in FPainters.MatchPainters.Values) 
                {
                    if (painter.Match.PlayerA.Id > 0 || painter.Match.PlayerB.Id > 0)
                        return true;
                }
                return false;
            }
        }
        public override void UpdateButtonsActivity()
        {
            base.UpdateButtonsActivity();
            if(Competition.Info.Status == CompetitionInfo.CompetitionState.Playing)
            {
                btnFinishGroupRound.Enabled = IsAllGroupMatchesOver && !IsAnyKOMatchesExists;
            }
            else
            {
                btnFinishGroupRound.Enabled = false;
            }
            
            
        }

        private void SeedPlayersForKO (CompetitionPlayerInfo[] playersForKO)
        {
            // Получаем список матчей для первого раунда плей-офф
            List<MatchInfo> ko_matches = new List<MatchInfo>();
            foreach (MatchPainter painter in FPainters.MatchPainters.Values) 
            {
                if (painter.Match.Label.Round == 1)
                    ko_matches.Add(painter.Match);
            }
            if ((Competition as RobinOlympic).KOPlayerCount != playersForKO.Length)
                throw new Exception(Localizator.Dictionary.GetString("WRONG_PLAYER_NUMBER"));
            int mc = ko_matches.Count;
            for (int i = 0; i < ko_matches.Count; i++) 
            {
                ko_matches[i].PlayerA.Id = playersForKO[i * 2].Id;
                ko_matches[i].PlayerB.Id = playersForKO[i * 2 + 1].Id;
            }
            foreach (MatchInfo match in ko_matches) 
            {
                TA.DB.Manager.DatabaseManager.CurrentDb.WriteMatch(match);
            }
            TA.DB.Manager.DatabaseManager.CurrentDb.ReadCompetitionMatchesList(Competition);
            CreateGrid();
            pictMain.Picture = GetPicture(null);
            UpdateButtonsActivity();
        }
        private void btnFinishGroupRound_Click(object sender, EventArgs e)
        {
            if (WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("ASK_FINISH_GROUP"), Localizator.Dictionary.GetString("FINISH_GROUP_ROUND_MATCHES"), MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                RobinOlympic competition = FCompetition as RobinOlympic;
                CompetitionPlayerInfo[] player_for_ko = fGroupWinnersSelect.SelectWinners(competition, FPainters.GroupPainters);
                if (player_for_ko != null)
                    SeedPlayersForKO(player_for_ko);
                else {
                    WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("PLAYOFF_NOT_FORMED"));
                }
            }
        }
        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.btnFinishGroupRound.Text = Localizator.Dictionary.GetString("FINISH_GROUP_ROUND");
        }
    }
}
