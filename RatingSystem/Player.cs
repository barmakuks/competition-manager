using System;
using System.Collections.Generic;
using System.Text;

namespace RSystem
{
    /// <summary>
    /// �����, ����������� ������ � ����������� �������
    /// </summary>
    public class Player
    {
        /// <summary>
        /// ������������� ������ � ��
        /// </summary>
        public int Id = -1;

        /// <summary>
        /// ������ ��� ������
        /// </summary>
        public string Name = "";

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
    public class Players : Dictionary<int, Player>
    {
        /// <summary>
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
            player.Rating = ratingBegin;
            Add(id, player);
        }
        public new Player this[int key] 
        {
            get {
                return base[key] as Player;
            }
            set {
                base[key] = value;
            }
        }
    }

}
