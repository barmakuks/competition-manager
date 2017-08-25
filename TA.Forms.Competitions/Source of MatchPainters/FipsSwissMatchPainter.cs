using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using TA.Corel;
using TA.Utils;


namespace TA.Competitions.Forms
{
    class FipsSwissMatchPainter : SwissMatchPainter
    {
        public override string PointsA 
        {
            get {
                if (FMatch.PlayerA.Id <= 0 || FMatch.PlayerB.Id <= 0)
                {
                    return "";
                }
                if (FMatch.PlayerA.Points > 0)
                    return "+" + FMatch.PlayerA.Points.ToString();
                return FMatch.PlayerA.Points.ToString();
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
                if (FMatch.PlayerB.Points > 0)
                    return "+" + FMatch.PlayerB.Points.ToString();
                return FMatch.PlayerB.Points.ToString();
            }
        }
    }
}
