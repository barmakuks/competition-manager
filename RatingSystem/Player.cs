using System;
using System.Collections.Generic;
using System.Text;

namespace RSystem
{
    /// <summary>
    /// Класс, описывающий игрока в рейтинговой системе
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Идентификатор игрока в БД
        /// </summary>
        public int Id = -1;

        /// <summary>
        /// Полное имя игрока
        /// </summary>
        public string Name = "";

        /// <summary>
        /// Текущий рейтинг игрока
        /// </summary>
        public int Rating = 0;

        /// <summary>
        /// дата последнего участия в турнире
        /// если MinValue, то в турнирах не участвовал
        /// </summary>
        public DateTime LastRatingDate = DateTime.MinValue;

        public override string ToString()
        {
            return String.Format("Id:{0} Rt:{1}", Id, Rating);
        }
    }

    /// <summary>
    /// Список игроков в рейтинговой системе
    /// </summary>
    public class Players : Dictionary<int, Player>
    {
        /// <summary>
        /// Добавляет игрока в список
        /// </summary>
        /// <param name="id">Идентификатор из БД</param>
        /// <param name="name">Полное имя игрока</param>
        /// <param name="ratingBegin">Начальное значение рейтинга</param>
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
