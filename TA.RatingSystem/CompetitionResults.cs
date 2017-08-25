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
    /// �����, ����������� ��������� ������� ������ � ������� 
    /// � ��������� ��� ��������
    /// </summary>
    public class PlayersCompetitionResult
    {
        /// <summary>
        /// ������ ���������� �� �������
        /// </summary>
        private IntArray FOpponents = new IntArray();
        public IntArray Opponents 
        {
            get {
                return FOpponents;
            }
        }
        /// <summary>
        /// ������������� ������ � ��
        /// </summary>
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        /// <summary>
        /// ���-�� ��������� � ������� �����
        /// </summary>
        public double Points { get; set; }
        /// <summary>
        /// ���-�� ���������� � �������
        /// </summary>
        public int OpponentsCount
        {
            get {
                return Opponents.Count;
            }
        }
        /// <summary>
        /// ������� �� ������ ������� � ������ ������
        /// </summary>
        public int RatingBegin { get; set; }
        /// <summary>
        /// ��������� �������� �� ����������� �������
        /// </summary>
        public int Delta { get; set; }
        /// <summary>
        /// ������� �� ����������� �������
        /// </summary>
        public int RatingEnd { 
            get {
                return RatingBegin + Delta;
            } 
        }

        /// <summary>
        /// ����� �� �������� �������� �� ������� ����������� �������,
        /// � ������� ����� �������� �������
        /// </summary>
        public int Penalty { get; set; }
        /// <summary>
        /// ������� ������� ����������, � �������� ����� ���������� � �������
        /// </summary>
        /// <param name="results">������ ����������� �������</param>
        /// <returns>������� ������� ����������</returns>
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
    /// �����. ������ ����������� ���������� �������
    /// </summary>
    public class CompetitionResults : Dictionary<int, PlayersCompetitionResult>
    {
        /// <summary>
        /// ��������� ����� ��������� � ������ �����������,
        /// ���� ��� ����������, �� ��������� ����������
        /// </summary>
        /// <param name="playerId">Id ������</param>
        /// <param name="opponentId">Id ���������</param>
        /// <param name="points">���������� ���������� ����� � ����� � ����������</param>
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
    /// �����. �������� ������� � ��� ������������.
    /// </summary>
    public class CompetitionInfo 
    {
        /// <summary>
        /// ������������� ������������ � ��
        /// </summary>
        public int Id;
        /// <summary>
        /// ���� ���������� ������������
        /// </summary>
        public DateTime Date = DateTime.MinValue;
        /// <summary>
        /// True, ���� ������������ �����������
        /// </summary>
        public bool IsRating { get; set; }

        /// <summary>
        /// ���������� ���������� �������
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
