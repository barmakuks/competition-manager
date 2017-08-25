using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using TA.Corel;
using TA.Utils;

namespace TA.Competitions.Forms
{
    internal class GroupPainterSettings
    {
        internal class GroupColors
        {
            public static Color BackColor = WindowSkin.Palette.Colors[0];
            public static Color Title = WindowSkin.Palette.Colors[6];
            public static Color Caption = WindowSkin.Palette.Colors[5];
            public static Color Score = WindowSkin.Palette.Colors[1];
            public static Color Points = WindowSkin.Palette.Colors[2];
            public static Color BergerKoef = WindowSkin.Palette.Colors[2];
            public static Color Place = WindowSkin.Palette.Colors[3];
            public static Color ForeColor = WindowSkin.Palette.Colors[0];
        }
        public static Color ShadowColor = WindowSkin.Palette.Colors[2];
        public static int ShadowStep = 3;
        public static Color BorderColor = WindowSkin.Palette.Colors[10];

        public static float Scale = 1.0f;
        public static int Scaled(int value, int minValue, int maxValue)
        {
            return Math.Min(Scaled(Math.Max(value, minValue)), maxValue);
        }
        public static int Scaled(int value)
        {
            return Convert.ToInt32(value * Scale);
        }
        public static float FontSize
        {
            get
            {
                return 9.0f * Scale;
            }
        }

        public static Size SmallSize
        {
           get{return new Size(Scaled(30), Scaled(19));}
        }
    }

    internal class GroupPainter : MatchPainter
    {
        internal class GroupPlayerInfo : MatchPlayer
        {
            public int Index;
            public double BergerKoef;
            public int Place = 0;
            public GroupPlayerInfo(int id, string name) : base()
            {
                Id = id;
                Name = name;
            }
            public GroupPlayerInfo(MatchPlayer player)
                : base() 
            {
                this.Copy(player);
            }
            public class ComparerByPoints : Comparer<GroupPlayerInfo>
            {
                public override int Compare(GroupPlayerInfo x, GroupPlayerInfo y)
                {
                    if (x.Points == y.Points)
                    {
                        if (y.BergerKoef == x.BergerKoef)
                            return x.Name.CompareTo(y.Name);
                        else
                            return y.BergerKoef.CompareTo(x.BergerKoef);
                    }
                    else 
                        return y.Points.CompareTo(x.Points);
                }
            }
            public class ComparerByPlace : Comparer<GroupPlayerInfo> 
            {
                public override int Compare(GroupPlayerInfo x, GroupPlayerInfo y)
                {
                    return x.Place.CompareTo(y.Place);
                }
            }            
        }
        internal class GroupPlayersList : Dictionary<int, GroupPlayerInfo>
        {
            public new void Add(int key, GroupPlayerInfo player)
            {
                player.Index = this.Count;
                base.Add(key, player);
            }

        }
        private GroupPlayersList FPlayers = new GroupPlayersList();
        private Size small_size = new Size(GroupPainterSettings.SmallSize.Width, GroupPainterSettings.SmallSize.Height);
        private Size player_size = new Size(GroupPainterSettings.SmallSize.Width * 6, GroupPainterSettings.SmallSize.Height);

        private MatchList FMatches = new MatchList();
        private Font Font = new Font(FontFamily.GenericSansSerif, GroupPainterSettings.FontSize);
        private int FGroupNo = 0;
        public MatchPlayer[] Players {
            get { return FPlayers.Values.ToArray(); }
            set {
                FPlayers.Clear();
                foreach (MatchPlayer player in value) 
                {
                    if (player.Id > 0)
                        FPlayers.Add(player.Id, new GroupPlayerInfo(player));
                }
            }
        }
        internal GroupPlayersList GroupPlayers 
        {
            get {
                return FPlayers;
            }
        }
        public MatchList Matches 
        {
            get {
                return FMatches;
            }
            set {
                FMatches.Clear();
                foreach(MatchInfo match in value.Values)
                {
                    FGroupNo = match.Label.Division;
                    FMatches.Add(match.Id, match);
                }                
            }
        }

        public StringFormat StringFormat = new StringFormat();
        public GroupPainter() : base() 
        {
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
        }
        
        public override Rectangle ClientRect
        {
            get {
                return new Rectangle(new Point(Left, Convert.ToInt32(TopF)), Size);
            }
        }

        public override bool In(Point point)
        {
            return ClientRect.Contains(point);
        }

        public override void UpdateChildren()
        {
            throw new NotImplementedException();
        }

        public override bool Visible
        {
            get {
                return true;
            }
        }

        private void DrawRectText(Graphics gr, Rectangle rect, string text, Brush brush, Brush text_brush)
        {
            DrawRectText(gr, rect, text, brush, text_brush, StringAlignment.Center);
        }
        private void DrawRectText(Graphics gr, Rectangle rect, string text, Brush brush)
        {
            DrawRectText(gr, rect, text, brush, Brushes.Black, StringAlignment.Center);
        }
        private void DrawRectText(Graphics gr, Rectangle rect, string text, Brush brush, Brush text_brush, StringAlignment align) 
        {
            gr.FillRectangle(brush, rect);
            gr.DrawRectangle(Pens.Black, rect);
            StringFormat sf = new StringFormat(StringFormat);
            sf.Alignment = align;
            if (align == StringAlignment.Near)
                rect.Offset(3, 0);
            gr.DrawString(text, Font, text_brush, rect, sf);
        }
        private void DrawRectText(Graphics gr, Rectangle rect, string text, Brush brush, StringAlignment align) 
        {
            DrawRectText(gr, rect, text, brush, Brushes.Black, align);
        }

        public override void Draw(Graphics gr)
        {
            Brush caption_brush = new SolidBrush(GroupPainterSettings.GroupColors.Caption);
            Brush caption_pen = new SolidBrush(GroupPainterSettings.GroupColors.ForeColor);
            Brush title_brush = new SolidBrush(GroupPainterSettings.GroupColors.Title);

            RecalculatePoints();
            int top = Top;
            gr.FillRectangle(new SolidBrush(GroupPainterSettings.ShadowColor), new Rectangle(Left + GroupPainterSettings.ShadowStep,top + GroupPainterSettings.ShadowStep, Size.Width, Size.Height));

            #region Рисуем шапку таблицы
            Rectangle caption_rect = new Rectangle(Left, top, Size.Width, GroupPainterSettings.SmallSize.Height);
            string caption = String.Format(Localizator.Dictionary.GetString("GROUP_#"), FGroupNo);
            DrawRectText(gr, caption_rect, caption, title_brush, caption_pen);

            Rectangle small_rect = new Rectangle(new Point(Left, top + GroupPainterSettings.SmallSize.Height), small_size);
            Rectangle player_rect = new Rectangle(new Point(Left + small_rect.Width, top + GroupPainterSettings.SmallSize.Height), player_size);
            Point left_top = player_rect.Location; left_top.Offset(player_rect.Width, player_rect.Height);

            DrawRectText(gr, small_rect, "#", caption_brush, caption_pen);
            DrawRectText(gr, player_rect, Localizator.Dictionary.GetString("PLAYER"), caption_brush, caption_pen);
            small_rect.Offset(player_rect.Width + small_rect.Width * (GroupPlayers.Count + 1), 0);
            DrawRectText(gr, small_rect, Localizator.Dictionary.GetString("PTS"), caption_brush, caption_pen);
            small_rect.Offset(small_rect.Width, 0);
            DrawRectText(gr, small_rect, Localizator.Dictionary.GetString("KB"), caption_brush, caption_pen);
            small_rect.Offset(small_rect.Width, 0);
            DrawRectText(gr, small_rect, Localizator.Dictionary.GetString("PLC"), caption_brush, caption_pen);

            #endregion
            int index = 1;
            small_rect.Location = new Point(Left, top + GroupPainterSettings.SmallSize.Height);
            Brush back_brush = new SolidBrush(GroupPainterSettings.GroupColors.BackColor);
            Brush bergerk_brush = new SolidBrush(GroupPainterSettings.GroupColors.BergerKoef);
            Brush place_brush = new SolidBrush(GroupPainterSettings.GroupColors.Place);
            Brush points_brush = new SolidBrush(GroupPainterSettings.GroupColors.Points);
            Brush score_brush = new SolidBrush(GroupPainterSettings.GroupColors.Score);
            
            foreach (GroupPlayerInfo player in GroupPlayers.Values)
            {
                player_rect.Offset(0, player_rect.Height);
                small_rect.Offset(0, small_rect.Height);
                Rectangle top_player_rect = new Rectangle(new Point(left_top.X + (index - 1) * small_rect.Width, left_top.Y - small_rect.Height), small_rect.Size);

                DrawRectText(gr, player_rect, player.Name, back_brush,StringAlignment.Near);
                DrawRectText(gr, small_rect, index.ToString(), back_brush);
                DrawRectText(gr, top_player_rect, index.ToString(), caption_brush, caption_pen);

                Rectangle point_rect = new Rectangle(new Point(player_rect.Left + player_rect.Width + small_rect.Width * GroupPlayers.Count, player_rect.Y), small_rect.Size);
                DrawRectText(gr, point_rect, TA.Utils.Utils.GetHalfPointsString(player.Points), points_brush);

                point_rect.Offset(point_rect.Width, 0);
                DrawRectText(gr, point_rect, TA.Utils.Utils.GetPointsString(player.BergerKoef / 2.0), bergerk_brush);

                point_rect.Offset(point_rect.Width, 0);
                DrawRectText(gr, point_rect, RomanNumber.GetRomanString(player.Place), place_brush);

                int x = player.Index * small_rect.Width;
                int y = player.Index * small_rect.Height;
                Rectangle match_rect = new Rectangle(new Point(left_top.X + x, left_top.Y + y), small_rect.Size);
                DrawRectText(gr, match_rect, "", caption_brush);
                index++;
            }
            foreach (MatchInfo match in Matches.Values)
            {
                if (match.PlayerB.Id > 0 && match.PlayerA.Id > 0) 
                {
                    int x = GroupPlayers[match.PlayerB.Id].Index * small_rect.Width;
                    int y = GroupPlayers[match.PlayerA.Id].Index * small_rect.Height;
                    Rectangle match_rect = new Rectangle(new Point(left_top.X + x, left_top.Y + y), small_rect.Size);
                    if (match.IsOver)
                        DrawRectText(gr, match_rect, TA.Utils.Utils.GetHalfPointsString(match.PlayerA.Points), score_brush);
                    else
                        DrawRectText(gr, match_rect, "", score_brush);

                    x = GroupPlayers[match.PlayerA.Id].Index * small_rect.Width;
                    y = GroupPlayers[match.PlayerB.Id].Index * small_rect.Height;
                    match_rect = new Rectangle(new Point(left_top.X + x, left_top.Y + y), small_rect.Size);
                    if (match.IsOver)
                        DrawRectText(gr, match_rect, TA.Utils.Utils.GetHalfPointsString(match.PlayerB.Points), score_brush);
                    else
                        DrawRectText(gr, match_rect, "", score_brush);
                }
            }
            
        }

        #region IMPLEMENTATION
        public int GetPlayerPoints(int playerId)
        {
            int points = 0;
            foreach (MatchInfo match in Matches.Values)
            {
                if (match.PlayerA.Id == playerId)
                    points += match.PlayerA.Points;
                if (match.PlayerB.Id == playerId)
                    points += match.PlayerB.Points;
            }
            return points;
        }
        public double GetBergerKoef(int playerId)
        {
            double koef = 0.0;
            int oppId; int score = 0;
            foreach (MatchInfo match in Matches.Values)
            {
                oppId = 0;
                if (match.PlayerA.Id == playerId)
                {
                    oppId = match.PlayerB.Id;
                    score = match.PlayerA.Points;
                }
                if (match.PlayerB.Id == playerId)
                {
                    oppId = match.PlayerA.Id;
                    score = match.PlayerB.Points;
                }
                if (oppId != 0)
                {
                    if (score == 1)
                        koef += GetPlayerPoints(oppId) / 2.0;
                    if (score == 2)
                        koef += GetPlayerPoints(oppId);
                }
            }
            return koef;
        }
        public void RecalculatePoints()
        {
            foreach (GroupPlayerInfo player in Players)
            {
                player.Points = GetPlayerPoints(player.Id);
                player.BergerKoef = GetBergerKoef(player.Id);
            }

            bool all_matches_over = true;
            foreach (MatchInfo match in Matches.Values) 
            {
                all_matches_over = all_matches_over && match.IsOver;
            }
            List<GroupPlayerInfo> players = new List<GroupPlayerInfo>(GroupPlayers.Values.ToArray());
            players.Sort(new GroupPlayerInfo.ComparerByPoints());
            int index = 0;
            int points = -1; double kb = -1;
            foreach (GroupPlayerInfo player in players)
            {
                if (GroupPlayers[player.Id].Points != points || GroupPlayers[player.Id].BergerKoef != kb)
                {
                    index++;
                    kb = GroupPlayers[player.Id].BergerKoef;
                    points = GroupPlayers[player.Id].Points;
                }
                if (all_matches_over)
                    GroupPlayers[player.Id].Place = index;
                else
                    GroupPlayers[player.Id].Place = 0;
            }

            // Пересортировуем группу по очкам
            GroupPlayers.Clear();
            foreach (GroupPlayerInfo player in players) 
            {
                GroupPlayers.Add(player.Id, player);
            }
            
        }

        #endregion

        public new Size Size 
        {
            get {
                int width = player_size.Width + small_size.Width * (Players.Length + 4);
                int height = player_size.Height * (Players.Length + 2);
                return new Size(width, height);
            }
        }
    }
}
