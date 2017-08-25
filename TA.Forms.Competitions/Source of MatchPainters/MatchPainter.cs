using System;
using System.Drawing;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public delegate void OnMatchPainterEvent(MatchPainter match);
    public abstract class MatchPainter
    {
        protected MatchInfo FMatch = null;
        protected PointF LeftTop = new PointF(0.0f, 0.0f);
        protected Color BackColor;

        public static Size Size
        {
            get
            {
                return new Size(0, 0);
            }
        }

        public int Left
        {
            get
            {
                return Convert.ToInt32(LeftTop.X);
            }
            set
            {
                LeftTop.X = value;
            }
        }
        public double TopF
        {
            get { return LeftTop.Y; }
            set { LeftTop.Y = (float)value; }
        }
        public int Top
        {
            get
            {
                return Convert.ToInt32(TopF);
            }
        }
        public MatchInfo Match
        {
            get
            {
                return FMatch;
            }
            set
            {
                FMatch = value;
                UpdateChildren();
            }
        }
        public abstract Rectangle ClientRect 
        {
            get;
        }
        public virtual string PointsA
        {
            get
            {
                if (FMatch.PlayerA.Id < 0 || FMatch.PlayerB.Id < 0)
                {
                    return "";
                }
                return FMatch.PlayerA.Points.ToString();
            }
        }
        public virtual string PointsB
        {
            get
            {
                if (FMatch.PlayerA.Id < 0 || FMatch.PlayerB.Id < 0)
                {
                    return "";
                }
                return FMatch.PlayerB.Points.ToString();
            }
        }


        public abstract bool In(Point point);
        public abstract void UpdateChildren();
        public abstract bool Visible
        {
            get;
        }
        public abstract void Draw(Graphics gr);

        public OnMatchPainterEvent OnAfterEdit;

    }
}
