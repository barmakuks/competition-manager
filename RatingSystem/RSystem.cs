using System;
using System.Collections.Generic;
using System.Text;

namespace RSystem
{
    public class RatingSystem
    {
        private static int [] exp_rating = {4,11,18,26,33,40,47,54,62,69,77,84,92,99,107,114,122,130,138,146,154,
                    163,171,180,189,198,207,216,226,236,246,257,268,279,291,303,316,329,345,358,375,
                    392,412,433,457,485,518,560,620,735};

        /// <summary>
        /// ����������� ��������� ��������� � ����������� �� ������� ���������
        /// </summary>
        /// <param name="dif_rating">������� ���������</param>
        /// <returns></returns>
        public static double Pexp(int dif_rating) 
        {
            int abs_rating = Math.Abs(dif_rating);
            int i = 0;
            while (i < exp_rating.Length && abs_rating >= exp_rating[i])
                i++;
            if(dif_rating > 0)
                return (50.0 + i) / 100.0;
            else
                return 1.0 - (50.0 + i) / 100.0;
        }
        /// <summary>
        /// ���������� ���������� ������ ������� ����� ����� ������
        /// </summary>
        /// <param name="dateMin">������� ����</param>
        /// <param name="dateMax">������� ����</param>
        /// <returns></returns>
        private static int GetMonthCount(DateTime dateMin, DateTime dateMax) 
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
        /// ������ �������� ����������� �������
        /// </summary>
        private Players FPlayers = new Players();
        public Players Players 
        {
            get {
                return FPlayers;
            }
        }

        /// <summary>
        /// ���������� ������������ �� ������ ����������� �������
        /// </summary>
        private Competitions FCompetitions = new Competitions();
        public Competitions Competitions 
        {
            get {
                return FCompetitions;
            }
        }
        /// <summary>
        /// ������������� ���� ���� ����������� �������
        /// </summary>
        int GameTypeId = -1;

        public RatingSystem(int gameTypeId) 
        {
            GameTypeId = gameTypeId;
            BuildRatingSystem(gameTypeId, FPlayers, FCompetitions, DateTime.MaxValue);
        }
        /// <summary>
        /// ���������� ����������� ������� � ������ ��������
        /// </summary>
        private static void BuildRatingSystem(int gameTypeId, Players players, Competitions competitions, DateTime date) 
        {
            // ��������� ������ ������� � ��������� ���������
            Database.ReadPlayerList(gameTypeId, players);            
            // ��������� ���������� �� ������� ����������� ����
            Database.ReadCompetitionList(gameTypeId, competitions, date);

            // ����������� �������� ��� ������� ������� �� ���� ����������� ����
            foreach (Competition comp in competitions) 
            {
                int avg_rating = 0;
                foreach (CompetitionResult result in comp.Results.Values) 
                {      
                    Player player = players[result.PlayerId];
                    // 1 - ��������� ������ �� ������� � ����������� �� ���� ������� � ���� �� ������ �������
                    if (player.LastRatingDate != DateTime.MinValue)
                        result.Penalty = (GetMonthCount(player.LastRatingDate, comp.Date) / 3) * 25;
                    // 2 - ��������� ��������� ������� (������� �� ������ - �����)
                    result.RatingBegin = player.Rating - result.Penalty;
                    avg_rating += result.RatingBegin;
                }
                // 3 - ��c������ ������� ������� ������� 
                avg_rating = Convert.ToInt32(avg_rating / comp.Results.Count);
                foreach (CompetitionResult result in comp.Results.Values)
                {
                    Player player = players[result.PlayerId];
                    // 4 - ��������� ������ ��� ������ ������                    
                    result.Delta = Convert.ToInt32(Math.Round(10.0 * (result.Points - result.OpponentsCount * Pexp(result.RatingBegin - avg_rating))));
                    // 5 - �������� ������� � ���� � ������ ������� 
                    player.Rating = result.RatingBegin + result.Delta;
                    player.LastRatingDate = comp.Date;
                }
            }

        }

        /// <summary>
        /// ���������� ������� ������ �� ������������ ����.
        /// ������� � ������� ������ �� ������� ������ �� ��������� ���� ����� �������.
        /// ��� ������, �������� ��� � �� ������������ -1
        /// </summary>
        /// <param name="playerId">Id ������ �� ��</param>
        /// <param name="date">����, �� ������� �������������� �������</param>
        /// <returns></returns>
        public int GetPlayerRating(int playerId, DateTime date) 
        {
            if (FPlayers.ContainsKey(playerId))
            {
                Player player = FPlayers[playerId];
                if (date > player.LastRatingDate)
                {
                    return player.Rating - (GetMonthCount(player.LastRatingDate, date) / 3) * 25;
                }
                DateTime last_date = DateTime.MinValue;
                int rating = 0;
                foreach (Competition comp in FCompetitions) 
                {
                    if(comp.Date < date && comp.Results.ContainsKey(playerId))
                    {
                        CompetitionResult res = comp.Results[playerId];
                        rating = res.RatingBegin + res.Penalty;
                        last_date = comp.Date;
                    }                    
                }
                if (last_date != DateTime.MinValue)
                    rating -= (GetMonthCount(last_date, date) / 3) * 25;
                return rating;
            }
            else 
            {
                return -1;
            }
        }

        public static Players GetPlayersRating(int gameTypeId, DateTime date) 
        {
            Players players = new Players();
            Competitions competitions = new Competitions();
            BuildRatingSystem(gameTypeId, players, competitions, date);
            foreach (Player player in players.Values) 
            {
                if (player.LastRatingDate != DateTime.MinValue)
                    player.Rating -= (GetMonthCount(player.LastRatingDate, date) / 3) * 25;
            }
            return players;
        }

    }
}
