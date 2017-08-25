using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Seeding
{
    class SeedItem : PlayerItem
    {
        private static int maxHintWidth = 0;
        private Rectangle Rect;
        public Point Location {
            get {
                return Rect.Location;
            }
        }
        public int Height {
            get {
                return Rect.Height;
            }
        }
        public int Width { get { return Rect.Width; } }
        public string Hint = "";

        public SeedItem(int seedNo, Point loc, string hint) : base(-1, "") 
        {
            SeedNo = seedNo;
            Hint = hint;
            Graphics gr = Graphics.FromImage(new Bitmap(20,20));
            maxHintWidth = Math.Max(maxHintWidth, gr.MeasureString(Hint, GraphicalSeeding.ItemFont).ToSize().Width + 5);
            Rect = new Rectangle(loc, Size);
        }
        public void DrawItem(Graphics gr, Point offset, bool over)
        {
            Point location = new Point(Rect.Left + offset.X, Rect.Top - offset.Y);
            Rectangle rect = new Rectangle(location.X, location.Y + 1, Size.Width, Size.Height - 2);
            Color backColor = GraphicalSeeding.BackColorNotEmpty;
            if(Id > -1)
                backColor = GraphicalSeeding.BackColorEmpty;
            if (over)
                backColor = GraphicalSeeding.BackColorOver;
            
            DrawRect(gr, rect, backColor);
            rect.Offset(5, 0); rect.Width -= 5;
            string str = String.Format("{0} : {1}", SeedNo, Name);
            while (gr.MeasureString(str, GraphicalSeeding.ItemFont).Width > rect.Width)
            {
                str = str.Substring(0, str.Length - 1);
            }
            Brush brush = new SolidBrush(GraphicalSeeding.TextColor);
            if(Id < 0)
                brush = new SolidBrush(GraphicalSeeding.EmptyTextColor);
            gr.DrawString(str, GraphicalSeeding.ItemFont, brush, rect, StrFormat);
            if (Hint != "") 
            {
                rect.Width = maxHintWidth; // gr.MeasureString(Hint, GraphicalSeeding.ItemFont).ToSize().Width + 5;
                rect.X = Rect.Left + offset.X - rect.Width;
                //DrawRect(gr, rect, GraphicalSeeding.BackColorEmpty);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;
                gr.DrawString(Hint, GraphicalSeeding.RatingFont, new SolidBrush(GraphicalSeeding.TextColor), rect, sf);
            }
        }
        public bool In(Point loc, int yOffset) 
        {
            return Rect.Contains(new Point(loc.X, loc.Y + yOffset));
        }
        internal override void Empty()
        {
            Id = -1;            
            //Index = -1;
            Name = "";            
        }
    }
}
