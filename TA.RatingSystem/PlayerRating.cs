using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TA.RatingSystem
{
    /// <summary>
    /// �����, ����������� ������ � ����������� �������
    /// </summary>
    public class PlayerRating
    {
        /// <summary>
        /// ������������� ������ � ��
        /// </summary>
        public int Id = -1;
        /// <summary>
        /// ���������� ������������� ������
        /// </summary>
        public Guid Guid = Guid.Empty;
        /// <summary>
        /// ��� ������
        /// </summary>
        public string FName = "";
        /// <summary>
        /// ������� ������
        /// </summary>
        public string LName = "";
        /// <summary>
        /// ��������
        /// </summary>
        public string PName = "";
        /// <summary>
        /// ������ ��� ������
        /// </summary>
        public string Name = "";
        /// <summary>
        /// E-Mail
        /// </summary>
        public string EMail = "";
        /// <summary>
        /// ���������� �������
        /// </summary>
        public string Phone = "";
        /// <summary>
        /// ������
        /// </summary>
        public string Country = "";
        /// <summary>
        /// ����� ��� �������
        /// </summary>
        public string City = "";

        /// <summary>
        /// ��������� �������
        /// </summary>
        public int RatingBegin = 0;
        /// <summary>
        /// ������� ������� ������
        /// </summary>
        public int Rating = 0;
        /// <summary>
        /// ���� ���������� ������� � �������
        /// ���� MinValue, �� � �������� �� ����������
        /// </summary>
        public DateTime LastRatingDate = DateTime.MinValue;

        public override string ToString()
        {
            return String.Format("Id:{0} Rt:{1}", Id, Rating);
        }
    }

    /// <summary>
    /// ������ ������� � ����������� �������
    /// </summary>
    public class PlayersRatingList : Dictionary<int, PlayerRating>
    {
        private static IComparer FComparerByName = new NameComparer();
        private class NameComparer : IComparer
        {
            int Compare(PlayerRating x, PlayerRating y)
            {
                return ((new CaseInsensitiveComparer()).Compare(x.Name, y.Name));
            }
            public int Compare(object x, object y)
            {
                return Compare(x as PlayerRating, y as PlayerRating);
            }
        }
        public static IComparer ComparerByName 
        {
            get {
                return FComparerByName;
            }
        }

        private static IComparer FComparerByRating = new RatingComparer();
        private class RatingComparer : IComparer
        {
            int Compare(PlayerRating x, PlayerRating y)
            {
                return y.Rating - x.Rating;
            }
            public int Compare(object x, object y)
            {
                return Compare(x as PlayerRating, y as PlayerRating);
            }
        }
        public static IComparer ComparerByRating
        {
            get
            {
                return FComparerByRating;
            }
        }

       /* /// <summary>
        /// ��������� ������ � ������
        /// </summary>
        /// <param name="id">������������� �� ��</param>
        /// <param name="name">������ ��� ������</param>
        /// <param name="ratingBegin">��������� �������� ��������</param>
        public void Add(int id, string name, int ratingBegin) 
        {
            Player player = new Player();
            player.Id = id;
            player.Name = name;
            player.RatingBegin = ratingBegin;
            player.Rating = ratingBegin;
            Add(id, player);
        }*/
        public void Add(PlayerRating player) 
        {
            Add(player.Id, player);
        }
        public new PlayerRating this[int key] 
        {
            get {
                if (base.ContainsKey(key))
                    return base[key] as PlayerRating;
                else
                    return null;
            }
            set {
                base[key] = value;
            }
        }
    }

}
