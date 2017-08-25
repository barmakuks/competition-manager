using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.Utils;

namespace TA.Competitions.Forms
{
    public partial class SwissPanel : CompetitionPanel
    {
        protected Dictionary<int, MatchPainter> FMatchPainters = new Dictionary<int,MatchPainter>();
        private int RoundCount = 0;
        public SwissPanel()
            : base()
        {
            InitializeComponent();
            LocalizeComponents();
            lvResults.Width = lvResults.BestWidth;
            lvResults.BackColor = WindowSkin.Palette.TextBackColor;
        }
        public new void LocalizeComponents()
        {
            base.LocalizeComponents();
            this.btnCancelRound.Text = Localizator.Dictionary.GetString("CANCEL_ROUND");
            this.lblPrizeCount.Text = Localizator.Dictionary.GetString("NUMBER_OF_PRIZE");
            this.lblRoundCount.Text = Localizator.Dictionary.GetString("RECOMMENDED_ROUNDS");
            this.btnNextRound.Text = Localizator.Dictionary.GetString("NEXT_ROUND");

            this.lvResults.Columns["NickName"].Text = Localizator.Dictionary.GetString("PLAYER");
            this.lvResults.Columns["TotalPoints"].Text = Localizator.Dictionary.GetString("PTS");
            this.lvResults.Columns["Tag"].Text = Localizator.Dictionary.GetString("KB");

        }
        public override void OpenCompetition(TA.Corel.Competition competition)
        {
            base.OpenCompetition(competition);
            int player_count = competition.Players.Count;
            if (player_count < 2)
                player_count = 1;
            ibxPrizeCount.MaximumValue = player_count;
            //btnCancelRound.Visible = false;
            ibxPrizeCount.Value = Math.Min(Competition.Info.Properties.GetInt32Value("PRIZE_COUNT", 1), ibxPrizeCount.MaximumValue);
            int round_count = MaxRoundCount;
            if(round_count > 0)
                lblRoundCount.Text = String.Format(Localizator.Dictionary.GetString("RECOMMENDED_ROUNDS_INT"), round_count);
            else
                lblRoundCount.Text = String.Format(Localizator.Dictionary.GetString("RECOMMENDED_ROUNDS"));
        }
        public override Bitmap GetPicture(Brush backBrush)
        {       
            Bitmap bmp = null;
            if(FBitmapSize.Width * FBitmapSize.Height == 0)
                bmp = new Bitmap(1,1);
            else
                bmp = new Bitmap(FBitmapSize.Width, FBitmapSize.Height);
            Graphics gr = Graphics.FromImage(bmp);
            if (backBrush != null)
            {
                gr.FillRectangle(backBrush, 0, 0, bmp.Width, bmp.Height);
            }
            foreach (MatchPainter painter in FMatchPainters.Values)
            {
                painter.Draw(gr);
            }
            if (OnAfterMatchPictureUpdate != null)
                OnAfterMatchPictureUpdate(this, new EventArgs());
            return bmp;
        }
        public override void UpdateButtonsActivity()
        {
            bool enable_editing = Competition.Info.Status == CompetitionInfo.CompetitionState.Playing;
            bool next_round = true;
            foreach (MatchPainter painter in FMatchPainters.Values)
            {
                if (painter.Match != null && painter.Match.Winner == MatchLabel.PlayerLetters.Unknown)
                    next_round = false;
            }
            btnNextRound.Enabled = next_round && enable_editing;
            btnCancelRound.Enabled = enable_editing && Competition.Matches.Count > (Competition.Players.Count + 1) / 2;
            btnCancelRound.Text = Localizator.Dictionary.GetString("CANCEL_ROUND_#") + RoundCount.ToString();
        }
        public override void CreateGrid()
        {
            FBitmapSize.Height = 0;
            FBitmapSize.Width = 0;
            SwissPainterSettings.Scale = Convert.ToSingle(ScalePicture);

            int ROUND_OFFSET = Convert.ToInt32(20.0 * ScalePicture);
            int OFFSET = Convert.ToInt32(4.0 * ScalePicture); ;
            Point round_left_top = new Point(ROUND_OFFSET, 0);
            int match_top = 0;
            

            Size LABEL_SIZE = new Size(SwissMatchPainter.Size.Width, SwissMatchPainter.Size.Height);

            FMatchPainters.Clear();
            int current_round = 0;
            foreach (MatchInfo match in Competition.Matches.Values)
            {
                if(match.Label.Round != current_round)
                {
                    //if (match.Label.Round % 2 == 1)
                    {
                        round_left_top.X = ROUND_OFFSET;
                        int round_height = ((Competition.Players.Count + 1) / 2 + 1)  * (OFFSET + LABEL_SIZE.Height);
                        round_left_top.Y = ROUND_OFFSET + (round_height + ROUND_OFFSET) * (match.Label.Round - 1);
                    }
                    /*else 
                    {
                        round_left_top.X = round_left_top.X + LABEL_SIZE.Width + ROUND_OFFSET;
                    }*/
                    match_top = round_left_top.Y;
                    RoundLabelPainter label_painter = new RoundLabelPainter(String.Format(Localizator.Dictionary.GetString("ROUND_INT"), match.Label.Round));
                    label_painter.TopF = match_top;
                    label_painter.Left = round_left_top.X;
                    FBitmapSize.Width = Math.Max(FBitmapSize.Width, Convert.ToInt32(label_painter.Left) + LABEL_SIZE.Width + 50);
                    current_round = match.Label.Round;
                    FMatchPainters.Add(match.Id + 10000 + current_round, label_painter);
                }
                
                match_top += OFFSET + LABEL_SIZE.Height;
                SwissMatchPainter painter = (SwissMatchPainter)GetMatchPainter();
                painter.TopF = match_top;
                FBitmapSize.Height = Math.Max(FBitmapSize.Height, Convert.ToInt32(painter.TopF) + LABEL_SIZE.Height + 50);
                painter.Left = round_left_top.X;
                painter.Match = match;
                painter.OnAfterEdit += new OnMatchPainterEvent(AfterMatchEdit);
                FMatchPainters.Add(painter.Match.Id, painter);
            }
            RoundCount = current_round;
        }
        protected override MatchPainter GetMatchPainter() 
        {
            return new SwissMatchPainter();
        }
        /// <summary>
        /// Вызывает редактирование матча
        /// </summary>
        /// <param name="match"></param>
        /// <param name="readOnly"></param>
        /// <returns></returns>
        protected virtual bool EditMatch(MatchInfo match, bool readOnly)
        {
            return fSwissMatchEdit.Edit(match, readOnly);
        }
        protected override void UpdatePicture()
        {
            base.UpdatePicture();
            UpdateCurrentResults();
            //pictPlayers.Picture = GetPlayersPicture(null);
        }

        protected void UpdateCurrentResults()
        {
            lvResults.Clear();
            lvResults.AddRange(Competition.PlayersResults);
        }

        private void AfterMatchEdit(MatchPainter aMatchView)
        {
            UpdatePicture();
        }
        protected virtual bool CanEditMatch(MatchInfo match) 
        {
            if (Competition.Info.Status == CompetitionInfo.CompetitionState.Finished)
                return false;
            return match.Label.Round == (FCompetition as TA.Competitions.Swiss).RoundCount;
        }
        private void CompetitionSwissPanel_OnMatchEdit(Point point)
        {
            foreach (MatchPainter painter in FMatchPainters.Values)
            {
                if (painter.In(point))
                {
                    if (painter.Match.PlayerA.Id == -1 || painter.Match.PlayerB.Id == -1)
                        return;
                    bool read_only = !CanEditMatch(painter.Match);
                    if (EditMatch(painter.Match, read_only))
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

        /// <summary>
        /// Событие вызывается на нажатие кнопки Next Round
        /// </summary>
        public EventHandler OnNextRoundClick;
        
        /// <summary>
        /// Вызывается после того, как сформируется картинка с матчами
        /// </summary>
        [Browsable(true)]
        public event EventHandler OnAfterMatchPictureUpdate;

        private void btnNextRound_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnNextRoundClick != null)
                {
                    string msg = "";
                    if (lblRoundCount.Visible && RoundCount >= MaxRoundCount)
                    {
                        msg = Localizator.Dictionary.GetString("ASK_ONE_MORE_ROUND");
                    }
                    else
                    {
                        msg = Localizator.Dictionary.GetString("ASK_COMPLETE_ROUND");
                    }
                    if (WindowSkin.MessageBox.Show(msg, Localizator.Dictionary.GetString("NEXT_ROUND"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        OnNextRoundClick(sender, e);
                }
            }
            catch (Exception ex) 
            {
                WindowSkin.MessageBox.Show(ex.Message, Localizator.Dictionary.GetString("NEXT_ROUND"), MessageBoxButtons.OK);
            }
            //UpdateButtons();
        }
        private void txtPrizeCount_ValueChanged(object sender, EventArgs e)
        {            
            int prize_count = Competition.Info.Properties.GetInt32Value("PRIZE_COUNT", 1);
            if (ibxPrizeCount.Value != prize_count) 
            {
                Competition.Info.Properties["PRIZE_COUNT"] = ibxPrizeCount.Value.ToString();
                TA.DB.Manager.DatabaseManager.CurrentDb.SetParamValue(Competition.Info.Id, "PRIZE_COUNT", ibxPrizeCount.Value.ToString());
            }
            lblRoundCount.Text = String.Format(Localizator.Dictionary.GetString("RECOMMENDED_ROUNDS_INT"), MaxRoundCount);
            UpdatePicture();
        }
        private int MaxRoundCount 
        {
            get {
                int prize_count = Competition.Info.Properties.GetInt32Value("PRIZE_COUNT", 1);
                return (int)(Math.Round(Math.Log(Competition.Players.Count, 2)) + Math.Round(Math.Log(prize_count, 2)));
            }
        }

        private string lvResults_OnGetCellString(object obj, int columnIndex)
        {
            switch(columnIndex)
            {
                case 2:
                case 3:
                    return Utils.Utils.GetHalfPointsString(Convert.ToInt32(obj));
            }
            return obj.ToString();
        }

        private string lvResults_OnGetCellString_1(object obj, int columnIndex)
        {
            if (obj is int) 
            {
                return Utils.Utils.GetHalfPointsString(Convert.ToInt32(obj));
            }
            return "";
        }

        private void btnCancelRound_Click(object sender, EventArgs e)
        {
            string msg = Localizator.Dictionary.GetString("ASK_CANCEL_ROUND");
            if (WindowSkin.MessageBox.Show(msg, Localizator.Dictionary.GetString("CANCEL_ROUND"), MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                DeleteLastRound();
            }
        }
        /// <summary>
        ///  Удаляет матчи последнего тура 
        /// </summary>
        private void DeleteLastRound()
        {            
            foreach(MatchInfo match in this.Competition.Matches.Values)
            {
                if(match.Label.Round == RoundCount)
                    TA.DB.Manager.DatabaseManager.CurrentDb.DeleteMatch(match);
            }
            TA.DB.Manager.DatabaseManager.CurrentDb.ReadCompetitionMatchesList(Competition);
            OpenCompetition(Competition);

            /*btnCancelRound.Visible = Competition.Matches.Count > (Competition.Players.Count + 1) / 2;
            btnCancelRound.Text = "Отменить тур №" + RoundCount.ToString();*/
        }
    }
    
    public class DrawPlayerArgs 
    {
        public Graphics Graphics;
        public string Place;
        public string MatchCount;
        public string Player;
        public string Points;
        public string BK;
        public Point LeftTop;
        public Color BackColor;
        public Color ForeColor;
        public DrawPlayerArgs(Graphics gr, string place, string player, string points, string bk, Point leftTop, Color backColor, Color foreColor) 
        {
            Graphics = gr;
            Place = place;
            Player = player;             
            Points = points; 
            BK = bk;
            LeftTop = leftTop; 
            BackColor = backColor; 
            ForeColor = foreColor;
        }
        public DrawPlayerArgs(Graphics gr, string place, string player, string points, string bk, Point leftTop, Color backColor, Color foreColor, string matchCount) 
            :this(gr, place,player,points, bk,leftTop,backColor,foreColor )
        {
            MatchCount = matchCount;
        }
            
    }

}
