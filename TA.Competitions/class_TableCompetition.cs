using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;

namespace TA.Competitions
{
    /// <summary>
    /// Результаты игрока в турнире
    /// </summary>
    public abstract class PlayerResults : IComparable<PlayerResults>
    {
        /// <summary>
        /// Id игрока
        /// </summary>
        public int PlayerId;
        /// <summary>
        /// Количество стартовых очков
        /// </summary>
        public int StartPoints;
        /// <summary>
        /// Количество набранных игроком очков в турнире
        /// </summary>
        public int Points
        {
            get
            {
                int res = 0;
                foreach (List<MatchInfo> matches in Matches.Values)
                {
                    foreach (MatchInfo match in matches)
                    {
                        res += match.GetPlayerPoints(PlayerId);
                    }                    
                }
                return res;
            }
        }
        public int AvailablePoints { get { return StartPoints + Points; } }

        /// <summary>
        /// Все сыгранные игроком матчи в виде пары <Id оппонента, MatchInfo>
        /// </summary>
        public Dictionary<int, List<MatchInfo>> Matches = new Dictionary<int, List<MatchInfo>>();

        public abstract int ComparePlayerResults(PlayerResults other);

        public int CompareTo(PlayerResults other)
        {
            return ComparePlayerResults(other);
        }
    }
    
    /// <summary>
    /// Таблица результатов
    /// </summary>
    public abstract class CompetitionResultsBuilder : Dictionary<int, PlayerResults>
    {
        private int FRoundCount = 0;
        public int RoundCount
        {
            get
            {
                return FRoundCount;
            }
        }
        public abstract PlayerResults CreatePlayerResult();
        public CompetitionResultsBuilder(CompetitionPlayerList players, MatchList matches)
            : base()
        {
            // Добавляем всех игроков в список результатов
            foreach (CompetitionPlayerInfo player in players.Values)
            {
                PlayerResults res = CreatePlayerResult();
                res.PlayerId = player.Id;
                res.StartPoints = player.StartPoints;
                Add(res.PlayerId, res);
            }
            // Добавляем матчи
            foreach (MatchInfo match in matches.Values)
            {
                AddMatch(match.PlayerA.Id, match.PlayerB.Id, match);
                AddMatch(match.PlayerB.Id, match.PlayerA.Id, match);
                if (match.Label.Round > FRoundCount)
                    FRoundCount = match.Label.Round;
            }

        }
        protected  void AddMatch(int playerId, int opponentId, MatchInfo match)
        {
            if (playerId * opponentId > 0)
            {
                if (!this[playerId].Matches.ContainsKey(opponentId))
                    this[playerId].Matches.Add(opponentId, new List<MatchInfo>());
                this[playerId].Matches[opponentId].Add(match);
                if (match.Label.Round > FRoundCount)
                    FRoundCount = match.Label.Round;
            }
        }

        public virtual List<PlayerResults> GetPlayersOrderedByResult()
        {
            List<PlayerResults> list = new List<PlayerResults>();
            list.AddRange(this.Values);
            list.Sort();
            return list;
        }
    }

    /// <summary>
    /// Соревнование, результат которого представляется в виде таблицы
    /// </summary>
    public abstract class TableCompetition : Competition
    {
        protected int FRoundCount = 0;
        public int RoundCount
        {
            get
            {
                return FRoundCount;
            }
        }
        public override void InitializeMatches()
        {
            UpdatePlayerResults();
        }
        protected CompetitionResultsBuilder ResultCalculator = null;
        public CompetitionResultsBuilder CurrentResults
        {
            get
            {
                return ResultCalculator;
            }
        }
        public abstract CompetitionResultsBuilder CreateResultBuilder();
        public abstract void UpdatePlayerInfo(CompetitionPlayerInfo player_info, PlayerResults player_results, int place);

        protected List<CompetitionPlayerInfo> _results = new List<CompetitionPlayerInfo>();

        public void UpdatePlayerResults() 
        {
            try
            {
                _results = new List<CompetitionPlayerInfo>();
                //if (resultCalculator.Count == 0 && Players.Count != 0)
                ResultCalculator = CreateResultBuilder();
                FRoundCount = ResultCalculator.RoundCount;
                int place = 1;
                foreach (PlayerResults player_result in ResultCalculator.GetPlayersOrderedByResult())
                {
                    UpdatePlayerInfo(Players[player_result.PlayerId], player_result, place++);
                    _results.Add(Players[player_result.PlayerId]);
                }
            }
            catch (Exception)
            {
            }
        }

        public override List<CompetitionPlayerInfo> PlayersResults
        {
            get
            {
                UpdatePlayerResults();
                return _results;
            }
        }

    }
}
