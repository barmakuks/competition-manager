using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace TA.RatingSystem
{
    public class IntArray : ArrayList
    {
        public new int  this[int index]
        {
            get{
                return (int)(base[index]);
            }
            set{
                base[index] = value;
            }
        }
        public int Add(int value)
        {
            return base.Add(value);
        }
    }

    /// <summary>
    /// Класс, описывающий результат участия игрока в турнире 
    /// и изменения его рейтинга
    /// </summary>
    public class PlayersCompetitionResult
    {
        /// <summary>
        /// Список опоонентов по турниру
        /// </summary>
        private IntArray FOpponents = new IntArray();
        public IntArray Opponents 
        {
            get {
                return FOpponents;
            }
        }
        /// <summary>
        /// Идентификатор игрока в БД
        /// </summary>
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        /// <summary>
        /// Кол-во набранных в турнире очков
        /// </summary>
        public double Points { get; set; }
        /// <summary>
        /// Кол-во соперников в турнире
        /// </summary>
        public int OpponentsCount
        {
            get {
                return Opponents.Count;
            }
        }
        /// <summary>
        /// Рейтинг на начало турнира с учетом штрафа
        /// </summary>
        public int RatingBegin { get; set; }
        /// <summary>
        /// Изменение рейтинга по результатам турнира
        /// </summary>
        public int Delta { get; set; }
        /// <summary>
        /// рейтинг по результатам турнира
        /// </summary>
        public int RatingEnd { 
            get {
                return RatingBegin + Delta;
            } 
        }

        /// <summary>
        /// Штраф за пропуски турниров со времени предыдущего турнира,
        /// в котором игрок принимал участие
        /// </summary>
        public int Penalty { get; set; }
        /// <summary>
        /// Средний рейтинг оппонентов, с которыми игрок встречался в турнире
        /// </summary>
        /// <param name="results">Список результатов турнира</param>
        /// <returns>Средний рейтинг оппонентов</returns>
        public double AvgOppRating(CompetitionResults results) 
        {
            if (Opponents.Count == 0)
                return 0;
            double rating_sum = 0;
            foreach (int id in Opponents) 
            {
                rating_sum += results[id].RatingBegin;
            }
            return rating_sum / Opponents.Count;
        }
        public PlayersCompetitionResult() 
        {
            PlayerId = -1;
            Points = 0.0;
            RatingBegin = 0;
            Delta = 0;
            Penalty = 0;
        }
        public override string ToString()
        {
            return String.Format("Id:{0} Pts:{1} Opp:{2} RB:{3} D:{4}", PlayerId, Points, OpponentsCount, RatingBegin, Delta);
        }
    }

    /// <summary>
    /// Класс. Список результатов проведения турнира
    /// </summary>
    public class CompetitionResults : Dictionary<int, PlayersCompetitionResult>
    {
        /// <summary>
        /// Добавляет новый результат к списку результатов,
        /// если уже существует, то суммирует результаты
        /// </summary>
        /// <param name="playerId">Id игрока</param>
        /// <param name="opponentId">Id оппонента</param>
        /// <param name="points">Количество полученных очков в матче с оппонентом</param>
        public void Add(int playerId, int opponentId, double points)
        {
            PlayersCompetitionResult res = null;
            if (this.ContainsKey(playerId))
                res = this[playerId];
            else
                res = new PlayersCompetitionResult();

            res.PlayerId = playerId;
            res.Points += points;
            res.Opponents.Add(opponentId);
            if (!this.ContainsKey(playerId))
                Add(playerId, res);
        }
    }

    /// <summary>
    /// Класс. Описание турнира с его результатами.
    /// </summary>
    public class CompetitionInfo 
    {
        /// <summary>
        /// Идентификатор соревнования в БД
        /// </summary>
        public int Id;
        /// <summary>
        /// Дата проведения соревнования
        /// </summary>
        public DateTime Date = DateTime.MinValue;
        /// <summary>
        /// True, если соревнование рейтинговое
        /// </summary>
        public bool IsRating { get; set; }

        /// <summary>
        /// Результаты проведения турнира
        /// </summary>
        public CompetitionResults Results = new CompetitionResults();
        public override string ToString()
        {
            return String.Format("Id:{0} Dt:{1} Pl:{2}", Id, Date.ToString("dd.MM.yyyy"), Results.Count);
        }
    }

    public class CompetitionsList : ArrayList
    {
        public int Add(CompetitionInfo value)
        {
            return base.Add(value);
        }
        public new CompetitionInfo this[int index] 
        {
            get {
                return base[index] as CompetitionInfo;
            }
        }
        public CompetitionInfo GetCompetitionById(int id) 
        {
            foreach(CompetitionInfo comp in this)
            {
                if (comp.Id == id)
                    return comp;
            }
            return null;
        }
    }
}
