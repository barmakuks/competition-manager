using System;
using System.Collections.Generic;
using System.Text;

namespace TA.Corel
{
    public class PlayerRatingInfo
    {
        public bool IsActive = true;
        public int PlayerId = -1;
        public int GameType = 0;
        public int RatingBegin = 0;
        public PlayerRatingInfo() 
        {
        }
        public PlayerRatingInfo(int gameTypeId, int playerId, int rating)
        {
            IsActive = false;
            PlayerId = playerId;
            GameType = gameTypeId;
            RatingBegin = rating;
        }
        public PlayerRatingInfo(int gameTypeId, int playerId, int rating, bool isActive)
        {
            IsActive = isActive;
            PlayerId = playerId;
            GameType = gameTypeId;
            RatingBegin = rating;
        }
        public PlayerRatingInfo(PlayerRatingInfo copy) 
        {
            IsActive = copy.IsActive;
            PlayerId = copy.PlayerId;
            GameType = copy.GameType;
            RatingBegin = copy.RatingBegin;
        }
    }
}
