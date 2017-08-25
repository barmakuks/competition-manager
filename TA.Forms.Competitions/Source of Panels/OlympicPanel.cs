using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public partial class OlympicPanel : CompetitionPanel
    {
        private OlympicPaintersGroup AllPainters = new OlympicPaintersGroup();

        public OlympicPanel(): base()
        {
            InitializeComponent();
        }


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
            foreach (OlympicMatchPainter painter in AllPainters.MatchPainters.Values)
            {
                painter.Draw(gr);
            }
            foreach (BrokenLine line in AllPainters.BrokenLinePainters)
            {
                line.Draw(gr);
            }
            foreach (RoundLabel label in AllPainters.RoundLabels) 
            {
                label.Draw(gr);
            }
            return bmp;
        }

        internal static void CreateOlympicGrid(MatchList matches, OlympicPaintersGroup painters, float scale, Point location, out Size size, OnMatchPainterEvent AfterMatchEdit) 
        {
            OlympicPainterSettings.Scale = scale;
            Size bitmap_size = new Size(0,0);
            size = bitmap_size;            
            Point div_pos = location;
            int round_left = div_pos.X;
            const int DIFF = 4; const int OFFSET = 20;
            Size label_size = new Size(OlympicMatchPainter.Size.Width, (int)(OlympicMatchPainter.Size.Height * 1.5));
            double div_height = 0.0; double k = 0.0;
            painters.MatchPainters.Clear();
            painters.RoundLabels.Clear();
            int current_division = 1;
            int current_round = 1;
            double first = 0.0;
            List<MatchInfo> round_matches = new List<MatchInfo>();
            foreach (MatchInfo match in matches.Values)
            {
                if (match.Label.Division != current_division || match.Label.Round != current_round)
                {
                    // формируем матчи раунда
                    if (div_height == 0.0)
                    {
                        k = label_size.Height + DIFF;
                        div_height = round_matches.Count * k;
                    }
                    else
                    {
                        k = div_height / round_matches.Count;
                    }
                    first = div_pos.Y + k / 2.0;
                    for (int i = 0; i < round_matches.Count; i++)
                    {
                        //OlympicMatchPainter painter = (OlympicMatchPainter)GetMatchPainter();
                        OlympicMatchPainter painter = new OlympicMatchPainter();
                        painter.TopF = first + k * i + label_size.Height / 2.0;
                        bitmap_size.Height = Math.Max(bitmap_size.Height, Convert.ToInt32(painter.TopF) + label_size.Height + 50);

                        painter.Left = round_left;
                        painter.Match = round_matches[i];
                        painter.OnAfterEdit += new OnMatchPainterEvent(AfterMatchEdit);
                        painters.MatchPainters.Add(painter.Match.Id, painter);
                    }
                    round_left += label_size.Width + OFFSET;
                    bitmap_size.Width = Math.Max(bitmap_size.Width, round_left + label_size.Width + 50);
                    // Обнуляем список для следующего раунда
                    round_matches.Clear();
                    current_round = match.Label.Round;
                    round_matches.Add(match);
                    if (current_division != match.Label.Division)
                    {
                        // формируем новый дивизион                        
                        current_division = match.Label.Division;
                        div_pos.Y += Convert.ToInt32(div_height) + 50;
                        div_height = 0.0;
                        round_left = div_pos.X;
                    }
                }
                else
                {
                    round_matches.Add(match);
                }
            }
            //Добавляем последний матч
            if (div_height == 0.0)
            {
                k = label_size.Height + DIFF;
                div_height = round_matches.Count * k;
            }
            else
            {
                k = div_height / round_matches.Count;
            }
            first = div_pos.Y + k / 2.0;
            for (int i = 0; i < round_matches.Count; i++)
            {
                //OlympicMatchPainter painter = (OlympicMatchPainter)GetMatchPainter();
                OlympicMatchPainter painter = new OlympicMatchPainter();
                painter.TopF = first + k * i + label_size.Height / 2.0;
                bitmap_size.Height = Math.Max(bitmap_size.Height, Convert.ToInt32(painter.TopF) + label_size.Height + 50);

                painter.Left = round_left;
                painter.Match = round_matches[i];
                painter.OnAfterEdit += new OnMatchPainterEvent(AfterMatchEdit);
                painters.MatchPainters.Add(painter.Match.Id, painter);
            }
            if (current_division == 1) // Для олимпийской системы добавляем labels к матчам
            {
                int i = 1;
                while (current_round > 0)
                {
                    RoundLabel label = new RoundLabel();
                    label.Left = round_left;
                    label.Top = div_pos.Y + OlympicPainterSettings.MatchSize.Heihgt;
                    label.LabelText = TA.Utils.Utils.GetRoundsLabelText(i++);
                    painters.RoundLabels.Add(label);
                    round_left -= label_size.Width + OFFSET;
                    current_round--;
                }
            }
            bitmap_size.Width = Math.Max(bitmap_size.Width, round_left + label_size.Width + 50);
            CreateLines(painters);
            size = bitmap_size;
        }
        public override void CreateGrid() {
            FBitmapSize.Height = 0;
            FBitmapSize.Width = 0;
            OlympicPainterSettings.Scale = Convert.ToSingle(ScalePicture);
            Size size;
            CreateOlympicGrid(Competition.Matches, AllPainters, OlympicPainterSettings.Scale,new Point(20,20), out size, AfterMatchEdit);
            FBitmapSize.Height = size.Height;
            FBitmapSize.Width = size.Width;          
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
        internal static void CreateLines(OlympicPaintersGroup painters)
        {
            MatchPainter winner_view;
            painters.BrokenLinePainters.Clear();
            foreach (OlympicMatchPainter painter in painters.MatchPainters.Values)
            {
                if (painter.Match.Winner_Match != null)
                {
                    winner_view = painters.MatchPainters[painter.Match.Winner_Match.Id];
                    Point A = new Point(painter.Left + OlympicMatchPainter.Size.Width, painter.Top + OlympicMatchPainter.Size.Height / 2);
                    Point B = new Point(winner_view.Left, winner_view.Top + OlympicMatchPainter.Size.Height / 2);
                    BrokenLine line = BrokenLine.CreateLine(A, B);
                    line.Visible = painter.Visible;
                    painters.BrokenLinePainters.Add(line);
                }
            }
        }
        private void CompetitionOlympicPanel_OnMatchEdit(Point point)
        {
            foreach (OlympicMatchPainter painter in AllPainters.MatchPainters.Values)
            {
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
        }
        
    }
}
