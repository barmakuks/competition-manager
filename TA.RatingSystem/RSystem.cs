using System;
using System.Collections.Generic;
using System.Text;

namespace TA.RatingSystem
{
    public class RatingSystem
    {
        private static int [] exp_rating = {4,11,18,26,33,40,47,54,62,69,77,84,92,99,107,114,122,130,138,146,154,
                    163,171,180,189,198,207,216,226,236,246,257,268,279,291,303,316,329,345,358,375,
                    392,412,433,457,485,518,560,620,735};

        /// <summary>
        /// Расчитывает ожидаемый результат в зависимости от разницы рейтингов
        /// </summary>
        /// <param name="dif_rating">Разница рейтингов</param>
        /// <returns></returns>
        public static double Pexp(double dif_rating) 
        {
            double abs_rating = Math.Abs(dif_rating);
            int i = 0;
            while (i < exp_rating.Length && abs_rating >= exp_rating[i])
                i++;
            if(dif_rating > 0)
                return (50.0 + i) / 100.0;
            else
                return 1.0 - (50.0 + i) / 100.0;
        }
        /// <summary>
        /// Возвращает количество полных месяцев между двумя датами
        /// </summary>
        /// <param name="dateMin">Меньшая дата</param>
        /// <param name="dateMax">Большая дата</param>
        /// <returns></returns>
        public static int GetMonthCount(DateTime dateMin, DateTime dateMax) 
        {
            if (dateMin >= dateMax) 
            {
                return 0;
            }
            int month = 0;
            while (dateMin < dateMax) 
            {
                dateMin = dateMin.AddMonths(1);
                month++;
            }
            return month - 1;
        }
        /// <summary>
        /// Список игроковв рейтинговой системы
        /// </summary>
        private PlayersRatingList FPlayers = new PlayersRatingList();
        public PlayersRatingList Players 
        {
            get {
                return FPlayers;
            }
        }

        /// <summary>
        /// Результаты соревнований по данной рейтинговой системе
        /// </summary>
        private CompetitionsList FCompetitions = new CompetitionsList();
        public CompetitionsList Competitions 
        {
            get {
                return FCompetitions;
            }
        }
        /// <summary>
        /// Идентификатор типа игры рейтинговой системы
        /// </summary>
        public int GameTypeId = -1;
        public string GameTypeName = "";

        public RatingSystem(int gameTypeId, string gameTypeName) 
        {
            GameTypeId = gameTypeId;
            GameTypeName = gameTypeName;            
        }
        /// <summary>
        /// Возвращает рейтинг игрока на определенную дату.
        /// Участие в турнире влияет на рейтинг только на следующей день после турнира.
        /// Для игрока, которого нет в БД возвращается -1
        /// </summary>
        /// <param name="playerId">Id игрока из БД</param>
        /// <param name="date">дата, на которую рассчитывается рейтинг</param>
        /// <returns></returns>
        public int GetPlayerRating(int playerId, DateTime date) 
        {
            if (FPlayers.ContainsKey(playerId))
            {
                PlayerRating player = FPlayers[playerId];
        #if STANDARD
                return player.Rating;
        #endif
        #if  FEDITION
                if (date > player.LastRatingDate)
                {
                    return player.Rating - (GetMonthCount(player.LastRatingDate, date) / 3) * 25;
                }
                DateTime last_date = DateTime.MinValue;
                int rating = 0;
                foreach (CompetitionInfo comp in FCompetitions) 
                {
                    if(comp.Date < date && comp.Results.ContainsKey(playerId))
                    {
                        PlayersCompetitionResult res = comp.Results[playerId];
                        rating = res.RatingBegin + res.Penalty;
                        last_date = comp.Date;
                    }                    
                }
                if (last_date != DateTime.MinValue)
                    rating -= (GetMonthCount(last_date, date) / 3) * 25;
                return rating;
        #endif
            }
            else 
            {
                return -1;
            }
        }
    }
}
