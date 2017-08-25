using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using TA.Corel;
using TA.Utils;

namespace TA.Competitions.Forms
{
    internal class SwissPainterSettings
    {
        internal class MatchLabelColors 
        {
            public static Color Finished = WindowSkin.Palette.Colors[1];
            public static Color Started = WindowSkin.Palette.Colors[0];
            public static Color Seeding = WindowSkin.Palette.Colors[0];
            public static Color Empty = WindowSkin.Palette.Colors[0];
            public static Color ForeColor = WindowSkin.Palette.Colors[10];
            public static Color BackColor = Color.White;
        }
        public static Color ShadowColor = WindowSkin.Palette.Colors[2];
        public static int ShadowStep = 2;
        public static Color BorderColor = WindowSkin.Palette.Colors[10];
        
        internal class RoundLabelColors 
        {
            public static Color BackColor = WindowSkin.Palette.Colors[7];
            public static Color ForeColor = Color.White;
        }

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
                return 9.25f * Scale;
            }
        }
        public static FontFamily FontFamily
        {
            get{
                return FontFamily.GenericSansSerif;
            }
        }
        public class MatchSize
        {
            public static int Width
            {
                get
                {
                    return PointsWidth * 3 + NameWidth * 2 + 4 * Distance;
                    //return Scaled(24*14);
                }
            }
            public static int Heihgt
            {
                get
                {
                    return Scaled(18);
                }
            }
        }
        public static int Distance { get { return 2; } }
        public static int PointsWidth { get { return Scaled(42); } }
        public static int NameWidth { get { return Scaled(168); } }
    }

    public class RoundLabelPainter : MatchPainter 
    {
        private string Label = "";
        public RoundLabelPainter(string label) 
        {
            Label = label;
        }
        public override bool In(Point point)
        {
            return false;
        }
        public override void Draw(Graphics gr)
        {
            SmoothingMode sm = gr.SmoothingMode;
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font font = new Font(SwissPainterSettings.FontFamily, SwissPainterSettings.FontSize * 1.2f, FontStyle.Bold);

            GraphicsPath shadowPath = RoundedRectangle.Create(Left + SwissPainterSettings.ShadowStep, Top + SwissPainterSettings.ShadowStep, Size.Width, Size.Height);
            gr.FillPath(new SolidBrush(SwissPainterSettings.ShadowColor), shadowPath);

            GraphicsPath boxPath = RoundedRectangle.Create(Left, Top, Size.Width, Size.Height);
            gr.FillPath(new SolidBrush(SwissPainterSettings.RoundLabelColors.BackColor), boxPath);
            gr.DrawPath(new Pen(SwissPainterSettings.BorderColor), boxPath);
            gr.DrawString(Label, font, new SolidBrush(SwissPainterSettings.RoundLabelColors.ForeColor), ClientRect, sf);
            gr.SmoothingMode = sm;
        }
        public new static Size Size
        {
            get
            {
                return new Size(SwissPainterSettings.MatchSize.Width, SwissPainterSettings.MatchSize.Heihgt);
            }
        }
        public override void UpdateChildren()
        {
            
        }
        public override bool Visible
        {
            get { return true; }
        }
        public override Rectangle ClientRect
        {
            get
            {
                return new Rectangle(new Point(Left, Top), Size);
            }
        }
    }
    public class SwissMatchPainter : MatchPainter
    {
        public override string PointsA
        {
            get
            {
                if (FMatch.PlayerA.Id <= 0 || FMatch.PlayerB.Id <= 0)
                {
                    return "";
                }
                return Utils.Utils.GetHalfPointsString(FMatch.PlayerA.Points);
            }
        }
        public override string PointsB
        {
            get
            {
                if (FMatch.PlayerA.Id <= 0 || FMatch.PlayerB.Id <= 0)
                {
                    return "";
                }
                return Utils.Utils.GetHalfPointsString(FMatch.PlayerB.Points);
            }
        }
        protected new Color BackColor = SwissPainterSettings.MatchLabelColors.BackColor;
        public new static Size Size
        {
            get
            {
                return new Size(SwissPainterSettings.MatchSize.Width, SwissPainterSettings.MatchSize.Heihgt);
            }
        }
        public override bool Visible
        {
            get
            {
                return FMatch != null;
            }
        }
        public override void Draw(Graphics gr)
        {
            string PlayerA = FMatch.PlayerA.Label;
            string PlayerB = FMatch.PlayerB.Label;

            Font FontA = null;
            Font FontB = null;
            FontStyle winner_style = FontStyle.Bold;
            FontStyle looser_style = FontStyle.Regular;
            FontStyle normal_style = FontStyle.Regular;
            Font winner_font = new Font(SwissPainterSettings.FontFamily, SwissPainterSettings.FontSize, winner_style);
            Font looser_font = new Font(SwissPainterSettings.FontFamily, SwissPainterSettings.FontSize, looser_style);
            Font normal_font = new Font(SwissPainterSettings.FontFamily, SwissPainterSettings.FontSize, normal_style);
            switch (FMatch.Winner)
            {
                case MatchLabel.PlayerLetters.A:
                    FontA = winner_font;
                    FontB = looser_font;
                    BackColor = SwissPainterSettings.MatchLabelColors.Finished;
                    break;
                case MatchLabel.PlayerLetters.B:
                    FontA = looser_font;
                    FontB = winner_font;
                    BackColor = SwissPainterSettings.MatchLabelColors.Finished;
                    break;
                case MatchLabel.PlayerLetters.Draw:
                    FontA = winner_font;
                    FontB = winner_font;
                    BackColor = SwissPainterSettings.MatchLabelColors.Finished;
                    break;
                case MatchLabel.PlayerLetters.Unknown:
                    FontA = normal_font;
                    FontB = normal_font;
                    BackColor = SwissPainterSettings.MatchLabelColors.Started;
                    break;
            }

            //int match_label_width = SwissPainterSettings.Scaled(30);

            //------------------------------------------------------------------------------------
            SmoothingMode sm = gr.SmoothingMode;
            gr.SmoothingMode = SmoothingMode.HighQuality;
            int x = Left; int y = Top;
            int small_width = SwissPainterSettings.PointsWidth;
            int large_width = SwissPainterSettings.NameWidth;
            int distance = SwissPainterSettings.Distance;
            int h = Size.Height;            
            int sStep = SwissPainterSettings.ShadowStep;

            GraphicsPath shadowPath = RoundedRectangle.Create(x + sStep, y + sStep, small_width, h);
            shadowPath.AddPath(RoundedRectangle.Create(x + (small_width + distance) + sStep, y + sStep, large_width, h), true);
            shadowPath.AddPath(RoundedRectangle.Create(x + (small_width + large_width + distance * 2) + sStep, y + sStep, small_width, h), true);
            shadowPath.AddPath(RoundedRectangle.Create(x + (small_width*2 + large_width + distance * 3) + sStep, y + sStep, small_width, h), true);
            shadowPath.AddPath(RoundedRectangle.Create(x + (small_width*3 + large_width + distance * 4) + sStep, y + sStep, large_width, h), true);
            gr.FillPath(new SolidBrush(SwissPainterSettings.ShadowColor), shadowPath);

            GraphicsPath boxPath = RoundedRectangle.Create(x, y, small_width, h);
            boxPath.AddPath(RoundedRectangle.Create(x + (small_width + distance), y, large_width, h), true);
            boxPath.AddPath(RoundedRectangle.Create(x + (small_width + large_width + distance * 2), y, small_width, h), true); 
            boxPath.AddPath(RoundedRectangle.Create(x + (small_width * 2 + large_width + distance * 3), y, small_width, h), true); 
            boxPath.AddPath(RoundedRectangle.Create(x + (small_width * 3 + large_width + distance * 4), y, large_width, h), true);
            gr.FillPath(new SolidBrush(BackColor), boxPath);
            gr.DrawPath(new Pen(SwissPainterSettings.BorderColor), boxPath);
            gr.SmoothingMode = sm;

            int textTop = SwissPainterSettings.Scaled(2) + Top;
            string match_label = Match.Label.MatchNo.ToString();
            Size ls = Size.Round(gr.MeasureString(match_label, normal_font));
            Brush text_brush = new SolidBrush(SwissPainterSettings.MatchLabelColors.ForeColor);
            gr.DrawString(match_label, normal_font, text_brush, new Point(x + (small_width - ls.Width) / 2, textTop));

            gr.DrawString(PlayerA, FontA, text_brush, new Point(x + small_width + distance + SwissPainterSettings.Scaled(3), textTop));

            SizeF playerBsize = gr.MeasureString(PlayerB, FontB);
            gr.DrawString(PlayerB, FontB, text_brush, new PointF(x + Size.Width - playerBsize.Width - SwissPainterSettings.Scaled(3), textTop));

            if (FMatch.Winner == MatchLabel.PlayerLetters.Unknown)
                return;

            SizeF pointsASize = gr.MeasureString(PointsA, FontA);
            gr.DrawString(PointsA, FontA, text_brush, new PointF(x + small_width + large_width + distance * 2 + (small_width - 3 - pointsASize.Width) / 2, textTop));

            SizeF pointsBSize = gr.MeasureString(PointsB, FontB);
            gr.DrawString(PointsB, FontB, text_brush, new PointF(x + small_width * 2 + large_width + distance * 3 + (small_width - 3 - pointsBSize.Width) / 2, textTop));
        }
        public override void UpdateChildren()
        {            
        }
        public override bool In(Point point)
        {
            return (Left <= point.X && Left + Size.Width >= point.X) && (Top <= point.Y && Top + Size.Height >= point.Y);
        }
        public override Rectangle ClientRect
        {
            get
            {
                return new Rectangle(new Point(Left, Top), Size);
            }
        }
    }
}
