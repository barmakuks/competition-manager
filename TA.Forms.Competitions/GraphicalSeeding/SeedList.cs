using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace Seeding
{
    internal class SeedList : Dictionary<int, SeedItem>
    {
        private int MaxHeight = 0;
        public SeedType Type = SeedType.Matches;
        public int PlayersInGroup = 4;
        public const int Distance = 20;
        public int SeedOver = -1;
        public void Draw(Graphics gr, Point location, int yOffset, int count)
        {
            Point left_point = location;
            int index = 0; int cnt = 0;
            foreach (SeedItem seedPlace in Values)
            {
                int offset = seedPlace.Location.Y - yOffset;
                if (offset > 0)
                {
                    left_point.Y = yOffset;
                    seedPlace.DrawItem(gr, left_point, SeedOver != -1 && seedPlace.SeedNo == SeedOver);
                    /*if (index % 2 == 0)
                    {
                        Rectangle rect = new Rectangle(left_point, new Size(20, GraphicalSeeding.ItemSize.Height));
                        rect.Offset(-rect.Width, 0);
                        StringFormat sf = (StringFormat)(SeedItem.StrFormat.Clone());
                        sf.Alignment = StringAlignment.Center;
                        gr.DrawString(((index / 2) + 1).ToString(), GraphicalSeeding.ItemFont, Brushes.Black, rect, sf);
                        rect.Location = left_point;
                        rect.Offset(GraphicalSeeding.ItemSize.Width + 1, 0);
                        gr.DrawString("vs.", GraphicalSeeding.ItemFont, Brushes.Black, rect, sf);
                    }
                    else
                    {
                        seedPlace.DrawItem(gr, right_point, SeedOver != -1 && seedPlace.SeedNo == SeedOver);
                        left_point.Offset(0, GraphicalSeeding.ItemSize.Height);
                        right_point.Offset(0, GraphicalSeeding.ItemSize.Height);
                    }*/
                    cnt++;
                    if (cnt >= count)
                        return;
                }
                else 
                {
                    left_point.Y = -seedPlace.Location.Y;
                }
                index++;
            }
        }


        private SeedItem CreateMatchItem(int seedNo) 
        {
            Point location = new Point(0, 1);
            int xOffset = Count % 2 * (SeedItem.Size.Width + 3);
            string hint = "";
            if (xOffset == 0)
                hint = (Count / 2 + 1).ToString();
            int pairCount = Count / 2;
            int height = SeedItem.Size.Height - 2;
            int yOffset = Count / 2 * height + (height / 4 * pairCount);
            location.Offset(xOffset, yOffset);
            return new SeedItem(seedNo, location, hint);
        }
        private SeedItem CreateOlympicItem(int seedNo) 
        {
            Point location = new Point(0, 1);
            int xOffset = 0;
            string hint = "";
            if (Count % 2 == 0)
                hint = (Count / 2 + 1).ToString();
            int pairCount = Count / 2;
            int height = SeedItem.Size.Height - 2;
            int yOffset = Count * height + (height / 4 * pairCount);
            location.Offset(xOffset, yOffset);
            return new SeedItem(seedNo, location, hint);
        }
        private SeedItem CreateGroupItem(int seedNo) 
        {            
            Point location = new Point(0, 1);
            int xOffset = 0;
            int groupBefore = Count / PlayersInGroup;
            string hint = "";
            if (Count % PlayersInGroup == 0)
                hint = (groupBefore + 1).ToString();

            int height = SeedItem.Size.Height - 2;
            int yOffset = Count * height + (height / 2 * groupBefore);
            location.Offset(xOffset, yOffset);
            return new SeedItem(seedNo, location, hint);
        }

        public SeedItem CreateSeedItem(int seedNo) 
        {
            switch (Type) 
            {
                case SeedType.Matches:
                    return CreateMatchItem(seedNo);
                case SeedType.Groups:
                    return CreateGroupItem(seedNo);
                case SeedType.Olympic:
                default:
                    return CreateOlympicItem(seedNo);
            }            
        }

        public int FullHeight 
        {
            get{                
                return MaxHeight;
            }
        }
        public int ViewCount(int windowHeight) 
        {
            int height = (SeedItem.Size.Height - 2);
            int pairHeight =  height * 2 + (height / 4);
            return windowHeight / pairHeight + 1;
        }

        public void AddSeed(int seedNo) 
        {
            SeedItem seed = CreateSeedItem(seedNo);
            Add(seedNo, seed);
            MaxHeight = Math.Max(MaxHeight, seed.Location.Y + seed.Height);
        }
        public void SetSeedOrder(SeedType type, int[] seedingOrder, int aParam)
        {
            Clear();
            MaxHeight = 0;
            Type = type;
            switch (Type) 
            {
                case SeedType.Groups:
                    PlayersInGroup = aParam;
                    break;
            }
            foreach (int seedNo in seedingOrder)
            {
                AddSeed(seedNo);
            }            
        }
    }
}
