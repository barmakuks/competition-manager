using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;

namespace TA.DB
{
    public interface RatingInterface
    {
        PlayerRatingInfo GetPlayerBeginRating(int gameType, int playerId);
        bool PlayerBeginRatingUpdate(PlayerRatingInfo info);

        bool ReadPlayerRatingList(int GameTypeId, TA.RatingSystem.PlayersRatingList Players);
        bool ReadRatingCompetitionList(int GameTypeId, TA.RatingSystem.CompetitionsList Competitions);
        bool ReadRatingCompetitionList(int GameTypeId, TA.RatingSystem.CompetitionsList Competitions, DateTime date);
    }
}
