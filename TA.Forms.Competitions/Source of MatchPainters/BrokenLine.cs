using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace TA.Competitions.Forms
{

    public class BrokenLine 
    {
        private bool FVisible = true;
        public int Left;
        public int Top;
        public Size Size = new Size();
        public int Width 
        {
            get { return Size.Width; }
            set { Size.Width = value; }
        }
        public int Height
        {
            get { return Size.Height; }
            set { Size.Height = value; }
        }
        public enum Orientation
        {   None,
            Left_Right,
            LeftTop_RightBottom, 
            LeftBottom_RightTop, 
            RightTop_LeftBottom, RightBottom_LeftTop }
        private Orientation FOrientation = Orientation.None;
        private int FLineWidth = OlympicPainterSettings.Scaled(2,1,2);
        public BrokenLine()
        {
        }
        public Orientation Orient 
        {
            get 
            {
                return FOrientation;
            }
            set 
            {
                FOrientation = value;
            }
        }
        public int LineWidth 
        {
            get { 
                return FLineWidth; 
            }
            set { 
                FLineWidth = value; 
            }
        }

        public Color Color = Color.Black;
        public bool Visible         
        {
            get {
                return FVisible;
            }
            set {
                FVisible = value;
            }
        }
        public void Draw(Graphics gr) 
        {
            // Äëÿ LeftTop_RightBottom
            if (!Visible)
                return;
            if (Orient == Orientation.None || Width < 0)
                return;
            int Ax = 0;
            int Ay = 0;
            int AD = (Size.Width + LineWidth) / 2;
            int Bx = AD - LineWidth;
            int By = LineWidth;
            int BC = Size.Height - 2 * LineWidth;
            int Cx = Bx;
            int Cy = Size.Height - LineWidth;
            int CE = Size.Width - AD + LineWidth;
            if (Orient == Orientation.LeftBottom_RightTop)
            {
                Ay = Size.Height - LineWidth;
                By = LineWidth;
                Cy = 0;
            }
            if (Orient == Orientation.Left_Right)
            {
                AD = Size.Width;
                CE = 0;
                BC = 0;
            }

            Rectangle rect1 = new Rectangle(Left + Ax, Top + Ay, AD, LineWidth);
            Rectangle rect2 = new Rectangle(Left + Bx, Top + By, LineWidth, BC);
            Rectangle rect3 = new Rectangle(Left + Cx, Top + Cy, CE, LineWidth);
            Brush brush = new SolidBrush(OlympicPainterSettings.BorderColor);
            gr.FillRectangle(brush, rect1);
            gr.FillRectangle(brush, rect2);
            gr.FillRectangle(brush, rect3);
            
        }

        public static BrokenLine CreateLine(Point A, Point B) 
        {
            BrokenLine line = new BrokenLine();
            if (A.Y == B.Y)
            {
                line.Left = A.X;
                line.Top = A.Y;
                line.Width = B.X - A.X;
                line.Height = OlympicPainterSettings.Scaled(5);
                line.Orient = Orientation.Left_Right;
            }
            if (A.Y > B.Y) 
            {
                line.Left = A.X;
                line.Top = B.Y + OlympicPainterSettings.Scaled(6);
                line.Width = B.X - A.X;
                line.Height = A.Y - B.Y - OlympicPainterSettings.Scaled(4);
                line.Orient = Orientation.LeftBottom_RightTop;
            }
            if (A.Y < B.Y) 
            {
                line.Left = A.X;
                line.Top = A.Y;
                line.Width = B.X - A.X;
                line.Height = B.Y - A.Y - OlympicPainterSettings.Scaled(4);
                line.Orient = Orientation.LeftTop_RightBottom;
            }
            return line;
        }
    }
}
