using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace RSystem
{
    /// <summary>
    /// �����, ����������� ��������� ������� ������ � ������� 
    /// � ��������� ��� ��������
    /// </summary>
    public class CompetitionResult
    {
        /// <summary>
        /// ������������� ������ � ��
        /// </summary>
        public int PlayerId = -1;
        /// <summary>
        /// ���-�� ��������� � ������� �����
        /// </summary>
        public int Points = 0;
        /// <summary>
        /// ���-�� ���������� � �������
        /// </summary>
        public int OpponentsCount = 0;
        /// <summary>
        /// ������� �� ������ ������� � ������ ������
        /// </summary>
        public int RatingBegin = 0;
        /// <summary>
        /// ��������� �������� �� ����������� �������
        /// </summary>
        public int Delta = 0;
        /// <summary>
        /// ����� �� �������� �������� �� ������� ����������� �������,
        /// � ������� ����� �������� �������
        /// </summary>
        public int Penalty = 0;
        public override string ToString()
        {
            return String.Format("Id:{0} Pts:{1} Opp:{2} RB:{3} D:{4}", PlayerId, Points, OpponentsCount, RatingBegin, Delta);
        }
    }

    /// <summary>
    /// �����. ������ ����������� ���������� �������
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
    /// �����. �������� ������� � ��� ������������.
    /// </summary>
    public class Competition 
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
        /// ���������� ���������� �������
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
