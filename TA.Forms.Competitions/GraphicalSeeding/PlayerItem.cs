using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using TA.Utils;

namespace Seeding
{
    class PlayerItem 
    {
        public static StringFormat StrFormat = new StringFormat();
        static PlayerItem() 
        {
            StrFormat.LineAlignment = StringAlignment.Center;
            StrFormat.Alignment = StringAlignment.Near;
        }
        public static Size Size {
            get {
                return GraphicalSeeding.ItemSize;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int SeedNo { get; set; }
        internal virtual void Empty() 
        {
            Id = -1;
            Name = "";
            Rating = 0;
            SeedNo = 0;
        }
        public PlayerItem() 
        {
            Empty();
        }
        public PlayerItem(int id, string name) 
        {
            Id = id; Name = name;
        }
        public virtual object Clone() 
        {
            PlayerItem item = new PlayerItem(Id, Name);
            item.Rating = Rating;
            item.SeedNo = SeedNo;
            return item;
        }
        protected void DrawRect(Graphics gr, Rectangle rect, Color backColor)
        {
            int shadow = 2;
            SmoothingMode sm = gr.SmoothingMode;
            gr.SmoothingMode = SmoothingMode.HighQuality;

            GraphicsPath shadowPath = RoundedRectangle.Create(rect.Left + shadow, rect.Top + shadow, rect.Width, rect.Height);
            gr.FillPath(Brushes.Gray, shadowPath);
            GraphicsPath boxPath = RoundedRectangle.Create(rect.Left, rect.Top, rect.Width, rect.Height);
            gr.FillPath(new SolidBrush(backColor), boxPath);
            gr.DrawPath(Pens.Black, boxPath);
            gr.SmoothingMode = sm;
        }

        public virtual void Draw(Graphics gr, Point location, bool showRating) 
        {
            Rectangle rect = new Rectangle(location.X, location.Y + 1, Size.Width, Size.Height - 2);
            Color backColor = GraphicalSeeding.BackColorEmpty;
            if (SeedNo != 0)
                backColor = GraphicalSeeding.BackColorNotEmpty;
            DrawRect(gr, rect, backColor);
            rect.Offset(5, 0); rect.Width -= 5;
            string text = Name;
            while (gr.MeasureString(text, GraphicalSeeding.ItemFont).Width > rect.Width) 
            {
                text = text.Substring(0, text.Length - 1);
            }
            Brush brush = new SolidBrush(GraphicalSeeding.TextColor);
            if(SeedNo != 0)
                brush = new SolidBrush(GraphicalSeeding.EmptyTextColor);
            gr.DrawString(text, GraphicalSeeding.ItemFont, brush, rect, StrFormat);
            if (showRating) 
            {
                Point ratingPoint = new Point(rect.Left + rect.Width + 2, rect.Top);
                gr.DrawString(Rating.ToString(), GraphicalSeeding.RatingFont, new SolidBrush(GraphicalSeeding.TextColor), ratingPoint);
            }
        }

        public class CompareByName : IComparer<PlayerItem> 
        {
            public int Compare(PlayerItem x, PlayerItem y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
        public class CompareByRating : IComparer<PlayerItem>
        {
            public int Compare(PlayerItem x, PlayerItem y)
            {
                return y.Rating.CompareTo(x.Rating);
            }
        }
    }
}
