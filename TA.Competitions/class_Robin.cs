using System;
using System.Collections.Generic;
using System.Text;
using TA.Corel;

namespace TA.Competitions
{
    /// <summary>
    /// Текущие результаты игрока в круговом турнире
    /// </summary>
    public class PlayerRobinResults : PlayerResults
    {
        /// <summary>
        /// Коеффициенты Бергера
        /// </summary>
        public int[] BergerKoefs = null;
        /// <summary>
        /// Расчитывает коеффициент Бергера
        /// </summary>
        /// <returns></returns>
        public int GetKB()
        {
            int bk = 0;
            if (BergerKoefs!= null)
                foreach (int k in BergerKoefs)
                {
                    bk += k;
                }
            return bk;
        }
        
        public override string ToString()
        {
            return String.Format("{0} - Pts {1} KB{2}", PlayerId, Points, GetKB());
        }
        public override int ComparePlayerResults(PlayerResults other)
        {
            PlayerRobinResults other_res = other as PlayerRobinResults;
            if(other_res == null)
                throw new Exception("Invalid player Result Comparation");
            if (PlayerId == other_res.PlayerId)
                return 0;
            if (Points == other_res.Points)
            {
                // Продолжаем сравнение по коефициентам Бергера
                return other_res.GetKB().CompareTo(GetKB());
            }
            return other.Points.CompareTo(Points);
        }
    }
    /// <summary>
    /// Система подсчета мест занятых игроками в турнире
    /// </summary>
    public class RobinResultsBuilder : CompetitionResultsBuilder
    {
        public RobinResultsBuilder(CompetitionPlayerList players, MatchList matches)
            : base(players, matches)
        {
        }
        private void UpdateBergerKoef()
        {
            // Расчитываем коефициенты Бергера
            foreach (PlayerRobinResults player in this.Values)
            {
                (this[player.PlayerId] as PlayerRobinResults).BergerKoefs = GetBergerKoefitients(player.PlayerId);
            }
        }
        private int[] GetBergerKoefitients(int playerId)
        {
            List<int> koefs = new List<int>();
            foreach (int oppId in this[playerId].Matches.Keys)
            {
                if (oppId != 0)
                {
                    if(this[playerId].Matches[oppId][0].WinnerId == playerId)
                    { // Если игрок победил, то берем все коеффициенты соперника
                        foreach (int id in this[oppId].Matches.Keys)
                        {
                            if (id != 0)
                                koefs.Add(this[oppId].Matches[id][0].GetPlayerPoints(oppId) * 2);
                        }
                    }
                    else
                    {
                        if(this[playerId].Matches[oppId][0].Winner == MatchLabel.PlayerLetters.Draw)
                        { // Если сыграли вничью, то берем только половину коеффициента
                            foreach (int id in this[oppId].Matches.Keys)
                            {
                                if (id != 0)
                                    koefs.Add(this[oppId].Matches[id][0].GetPlayerPoints(oppId));
                            }
                        }
                    }
                }                
            }
            koefs.Sort();
            return koefs.ToArray();
        }
        public override List<PlayerResults> GetPlayersOrderedByResult()
        {
            UpdateBergerKoef();
            return base.GetPlayersOrderedByResult();
        }
        public override PlayerResults CreatePlayerResult()
        {
            return new PlayerRobinResults();
        }
    }

    public class Robin : TableCompetition
    {
        public Robin() : base() 
        {
            Info.CompetitionType = CompetitionType.Robin;
        }
        public override CompetitionResultsBuilder CreateResultBuilder()
        {
            return new RobinResultsBuilder(Players, Matches);
        }
        public override void UpdatePlayerInfo(CompetitionPlayerInfo player_info, PlayerResults player_results, int place)
        {
            player_info.Points = player_results.Points;
            player_info.Tag = (player_results as PlayerRobinResults).GetKB();
            player_info.Place = place.ToString("D2");
            player_info.CurrentPlace = place;
        }
        public override bool CanFinishRegistration
        {
            get
            {
                return Info.Status == CompetitionInfo.CompetitionState.RegistrationAndSeeding && Players.Count >= 4;
            }
        }
        public override int[] GetSeedOrder()
        {
            int[] sortition = new int[Players.Count];
            for (int i = 0; i < Players.Count; i++)
                sortition[i] = i + 1;
            return sortition;
        }
        public override bool NeedsPlayersDrawing
        {
            get
            {
                return false;
            }
        }
    }
}
