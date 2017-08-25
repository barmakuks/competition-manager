using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicalSeeding
{
    
    class MatchItem
    {
        public int Index = 0;
        public SeedItem PlayerA = new SeedItem();
        public SeedItem PlayerB = new SeedItem();
        public MatchItem(int index, int seedA, int seedB) 
        {
            Index = index;
            PlayerA.SeedNo = seedA;
            PlayerB.SeedNo = seedB;
        }

        public virtual void Draw(Graphics gr, Point location)
        {
            //-------------------------------------------------            
            const int DIFF = 4;
            Point loc = location;
            PlayerA.Draw(gr, loc);
            loc.Offset(SeedItem.Size.Width + DIFF,0);
            PlayerB.Draw(gr, loc);
            int y = location.Y + SeedItem.Size.Height / 2;
            int lx = location.X + SeedItem.Size.Width;
            int rx = location.X + SeedItem.Size.Width + DIFF;
            gr.DrawLine(new Pen(Color.Black, 2), lx, y, rx, y);
        }
    }
}
