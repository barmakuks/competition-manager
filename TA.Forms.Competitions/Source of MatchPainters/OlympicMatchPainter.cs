//using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using TA.Corel;
using TA.Utils;


namespace TA.Competitions.Forms
{
    internal class OlympicPainterSettings 
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
        public static float FontSize {
            get {
                return 9.0f * Scale; 
            }
        }

        public class MatchSize 
        {
            public static int Width 
            {
                get {
                    return Scaled(150);
                }
            }
            public static int Heihgt 
            {
                get {
                    return Scaled(34);
                }
            }
        }
    }

    public class OlympicMatchPainter : MatchPainter
    {
        protected new Color BackColor = OlympicPainterSettings.MatchLabelColors.BackColor;
        public new static Size Size
        {
            get
            {
                return new Size(OlympicPainterSettings.MatchSize.Width, OlympicPainterSettings.MatchSize.Heihgt);
            }
        }
        public override bool Visible 
        {
            get {
                return FMatch != null && FMatch.PlayerA.Id != 0 && FMatch.PlayerB.Id != 0;
            }
        }
        public override void Draw(Graphics gr) 
        {
            if (!Visible)
                return;
            string PlayerA = FMatch.PlayerA.Label;
            string PlayerB = FMatch.PlayerB.Label;
            Font FontA = null;
            Font FontB = null;
            FontStyle winner_style = FontStyle.Bold;
            FontStyle looser_style = FontStyle.Regular;
            FontStyle normal_style = FontStyle.Regular;
            Font font_normal = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize, FontStyle.Regular);
            Font font_bold = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize, FontStyle.Bold);

            switch (FMatch.Winner) 
            {
                case MatchLabel.PlayerLetters.A:
                    FontA = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize, winner_style);
                    FontB = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize, looser_style);
                    BackColor = OlympicPainterSettings.MatchLabelColors.Finished;
                    break;
                case MatchLabel.PlayerLetters.B:
                    FontA = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize, looser_style);
                    FontB = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize, winner_style);
                    BackColor = OlympicPainterSettings.MatchLabelColors.Finished;
                    break;
                case MatchLabel.PlayerLetters.Unknown:
                    FontA = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize, normal_style);
                    FontB = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize, normal_style);
                    BackColor = OlympicPainterSettings.MatchLabelColors.Started;
                    break;
            }
            if (FMatch.PlayerA.Id == -1 || FMatch.PlayerB.Id == -1)
            {
                if (FMatch.PlayerA.Id == -1 && FMatch.PlayerB.Id == -1)
                    BackColor = OlympicPainterSettings.MatchLabelColors.Empty;
                else
                    BackColor = OlympicPainterSettings.MatchLabelColors.Seeding;
            }

            /*gr.FillRectangle(new SolidBrush(Color.LightGray), Left + 3, Top + 3, Size.Width, Size.Height);
            gr.FillRectangle(new SolidBrush(BackColor), Left, Top, Size.Width, Size.Height);
            gr.DrawRectangle(new Pen(Color.Black), Left, Top, Size.Width, Size.Height);*/

            //-----------------------------------------------------------------------------
            SmoothingMode sm = gr.SmoothingMode;
            gr.SmoothingMode = SmoothingMode.HighQuality;

            GraphicsPath shadowPath = RoundedRectangle.Create(Left + OlympicPainterSettings.ShadowStep, Top + OlympicPainterSettings.ShadowStep, Size.Width, Size.Height);
            gr.FillPath(new SolidBrush(OlympicPainterSettings.ShadowColor), shadowPath);

            GraphicsPath boxPath = RoundedRectangle.Create(Left, Top, Size.Width, Size.Height);
            gr.FillPath(new SolidBrush(BackColor), boxPath);
            gr.DrawPath(new Pen(OlympicPainterSettings.BorderColor), boxPath);
            gr.SmoothingMode = sm;
            //-----------------------------------------------------------------------------
            gr.DrawString(PlayerA, FontA, new SolidBrush(OlympicPainterSettings.MatchLabelColors.ForeColor), new Point(Left + 3, Top + 1));
            gr.DrawString(PlayerB, FontB, new SolidBrush(OlympicPainterSettings.MatchLabelColors.ForeColor), new Point(Left + 3, Top + OlympicPainterSettings.Scaled(17)));
            SizeF pointAsize = gr.MeasureString(PointsA, FontA);
            SizeF pointBsize = gr.MeasureString(PointsB, FontB);
            gr.DrawString(PointsA, font_normal, new SolidBrush(OlympicPainterSettings.MatchLabelColors.ForeColor), new PointF(Left + Size.Width - pointAsize.Width - OlympicPainterSettings.Scaled(5), Top + 1));
            gr.DrawString(PointsB, font_normal, new SolidBrush(OlympicPainterSettings.MatchLabelColors.ForeColor), new PointF(Left + Size.Width - pointBsize.Width - OlympicPainterSettings.Scaled(5), Top + OlympicPainterSettings.Scaled(17)));
            if (FMatch.Title != "") 
            {
                SizeF titleSize = gr.MeasureString(FMatch.Title , font_bold);
                gr.DrawString(FMatch.Title, font_bold, new SolidBrush(OlympicPainterSettings.MatchLabelColors.ForeColor), new PointF(Left + (Size.Width - titleSize.Width) / 2, Top - titleSize.Height));
            }

        }
        public override void UpdateChildren()
        {
            FMatch.UpdateNextMatches();
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
        //public string Label { get; set; }

    }
}
