using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace RSystem
{
    /// <summary>
    /// Класс, описывающий результат участия игрока в турнире 
    /// и изменения его рейтинга
    /// </summary>
    public class CompetitionResult
    {
        /// <summary>
        /// Идентификатор игрока в БД
        /// </summary>
        public int PlayerId = -1;
        /// <summary>
        /// Кол-во набранных в турнире очков
        /// </summary>
        public int Points = 0;
        /// <summary>
        /// Кол-во соперников в турнире
        /// </summary>
        public int OpponentsCount = 0;
        /// <summary>
        /// Рейтинг на начало турнира с учетом штрафа
        /// </summary>
        public int RatingBegin = 0;
        /// <summary>
        /// Изменение рейтинга по результатам турнира
        /// </summary>
        public int Delta = 0;
        /// <summary>
        /// Штраф за пропуски турниров со времени предыдущего турнира,
        /// в котором игрок принимал участие
        /// </summary>
        public int Penalty = 0;
        public override string ToString()
        {
            return String.Format("Id:{0} Pts:{1} Opp:{2} RB:{3} D:{4}", PlayerId, Points, OpponentsCount, RatingBegin, Delta);
        }
    }

    /// <summary>
    /// Класс. Список результатов проведения турнира
    /// </summary>
    public class CompetitionResults : Dictionary<int, CompetitionResult>
    {
        public void Add(int playerId, int points, int oppCount)
        {
            CompetitionResult res = new CompetitionResult();
            res.PlayerId = playerId;
            res.Points = points;
            res.OpponentsCount = oppCount;
            Add(playerId, res);
        }
        public int AvgRating 
        {
            get {
                if(Count == 0)
                    return 0;
                int avg = 0;
                foreach (CompetitionResult res in base.Values) 
                {
                    avg += res.RatingBegin;
                }
                return avg / Count;
            }
        }
    }

    /// <summary>
    /// Класс. Описание турнира с его результатами.
    /// </summary>
    public class Competition 
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
        /// Результаты проведения турнира
        /// </summary>
        public CompetitionResults Results = new CompetitionResults();
        public override string ToString()
        {
            return String.Format("Id:{0} Dt:{1} Pl:{2}", Id, Date.ToString("dd.MM.yyyy"), Results.Count);
        }
    }

    public class Competitions : ArrayList
    {
        public int Add(Competition value)
        {
            return base.Add(value);
        }
        public new Competition this[int index] 
        {
            get {
                return base[index] as Competition;
            }
        }
    }
}
