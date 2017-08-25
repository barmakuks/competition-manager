using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Seeding
{
    internal class PlayersList : Dictionary<int, PlayerItem>
    {
        public List<PlayerItem> Players = new List<PlayerItem>();
        public PlayersList() 
        {
        }
        private SortOrder FSortBy = SortOrder.NoOrder;
        public SortOrder SortBy 
        {
            get {
                return FSortBy;
            }
            set {
                FSortBy = value;
                Players.Clear();
                switch(value)
                {
                    case SortOrder.Name:
                        Players.AddRange(SortedArray(SortOrder.Name));
                        break;
                    case SortOrder.Rating:
                        Players.AddRange(SortedArray(SortOrder.Rating));
                        break;
                    case SortOrder.Random:
                        Players.AddRange(SortedArray(SortOrder.Random));
                        break;
                    case SortOrder.NoOrder:
                        Players.AddRange(Values);
                        break;
                }
            }
        }
        public PlayerItem[] SortedArray(SortOrder sortBy) 
        {
            PlayerItem[] retArray = new PlayerItem[Values.Count];
            Values.CopyTo(retArray, 0);
            switch (sortBy) 
            {
                case SortOrder.Random:
                    Random random = new Random();
                    for (int i = 0; i < Values.Count; i += 1)
                    {
                        int swapIndex = random.Next(i, Values.Count);
                        if (swapIndex != i)
                        {
                            PlayerItem temp = retArray[i];
                            retArray[i] = retArray[swapIndex];
                            retArray[swapIndex] = temp;
                        }
                    }
                    break;
                case SortOrder.Name:
                    Array.Sort(retArray, new PlayerItem.CompareByName());
                    break;
                case SortOrder.Rating:
                    Array.Sort(retArray, new PlayerItem.CompareByRating());
                    break;
            }
            return retArray;
        }

        public void Draw(Graphics gr, Point location, int from, int count, bool showRating) 
        {
            Point playerPoint = location;            
            int index = 0; int cnt = 0;
            foreach (PlayerItem player in Players) 
            {
                if (index >= from) 
                {
                    player.Draw(gr, playerPoint, showRating);
                    playerPoint.Offset(0, GraphicalSeeding.ItemSize.Height);
                    cnt++;
                    if (cnt >= count)
                        return;
                }
                index++;
            }
        }
    }
}
