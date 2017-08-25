using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using TA.Corel;


namespace TA.Competitions
{

    /// <summary>
    /// Текущие результаты игрока в Swiss-турнире
    /// </summary>
    public class PlayerSwissResults : PlayerResults
    {
        /// <summary>
        /// Коеффициенты Бухгольца
        /// </summary>
        public int[] BuchholzK = null;
        public int GetBK()
        {
            int bk = 0;
            if (BuchholzK != null)
                foreach (int k in BuchholzK)
                {
                    bk += k;
                }
            return bk;
        }
        public override int ComparePlayerResults(PlayerResults other)
        {
            PlayerSwissResults other_swiss_res = other as PlayerSwissResults;
            if (other_swiss_res == null)
                throw new Exception("Invalid player Result Comparation");

            if (PlayerId == other_swiss_res.PlayerId)
                return 0;
            if (AvailablePoints == other_swiss_res.AvailablePoints)
            {
                // Продолжаем сравнение по коефициентам Бухгольца
                return other_swiss_res.GetBK().CompareTo(GetBK());
            }
            return other.AvailablePoints.CompareTo(AvailablePoints);
        } 
        public override string ToString()
        {
            return String.Format("{0} - Pts {1} BK{2}", PlayerId, Points, GetBK());
        }
    }
    
    /// <summary>
    /// Система подсчета мест занятых игроками в турнире
    /// </summary>
    public class SwissResultsBuilder : CompetitionResultsBuilder
    {
        public SwissResultsBuilder(CompetitionPlayerList players, MatchList matches)
            : base(players, matches)
        {
        }
        private void UpdateBuchholzK() 
        {
            // Расчитываем коефициенты Бухгольца
            foreach (PlayerSwissResults player in this.Values)
            {
                (this[player.PlayerId] as PlayerSwissResults).BuchholzK = GetBuchholzKoefitients(player.PlayerId);
            }
        }
        private int[] GetBuchholzKoefitients(int playerId)
        {
            List<int> koefs = new List<int>();
            foreach (int oppId in this[playerId].Matches.Keys)
            {
                if (oppId != 0 && this[playerId].Matches[oppId][0].Winner != MatchLabel.PlayerLetters.Unknown)
                    foreach (int id in this[oppId].Matches.Keys)
                    {
                        //if (id != playerId && id != 0) Исправлено 18.05.2011 коефициент считать учитывая матчем между соперниками
                            koefs.Add(this[oppId].Matches[id][0].GetPlayerPoints(oppId));
                    }
            }
            koefs.Sort();
            return koefs.ToArray();
        }
        public override PlayerResults CreatePlayerResult()
        {
            return new PlayerSwissResults();
        }
        public override List<PlayerResults> GetPlayersOrderedByResult()
        {
            UpdateBuchholzK();
            return base.GetPlayersOrderedByResult();
        }
    }

    public class Swiss : TableCompetition
    {
        protected List<CompetitionPlayerInfo> FResults = new List<CompetitionPlayerInfo>();
        public Swiss() : base() 
        {
            Info.CompetitionType = CompetitionType.Swiss;
        }
        public override CompetitionResultsBuilder CreateResultBuilder()
        {
            return new SwissResultsBuilder(Players, Matches);
        }
        public override void UpdatePlayerInfo(CompetitionPlayerInfo player_info, PlayerResults player_results, int place)
        {
            player_info.Points = player_results.Points;
            player_info.Tag = (player_results as PlayerSwissResults).GetBK();
            player_info.Place = place.ToString("D2");
            player_info.CurrentPlace = place;
        }
        public override bool CanFinishRegistration
        {
            get { 
                return Info.Status == CompetitionInfo.CompetitionState.RegistrationAndSeeding && Players.Count >= 4;
            }
        }
        public override int[] GetSeedOrder()
        {
            return Sortition.SortitionByRating.GetSwissSortitionOrder(Players.Count);
        }
    }
}
