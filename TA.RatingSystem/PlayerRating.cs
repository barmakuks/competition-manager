using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TA.RatingSystem
{
    /// <summary>
    /// Класс, описывающий игрока в рейтинговой системе
    /// </summary>
    public class PlayerRating
    {
        /// <summary>
        /// Идентификатор игрока в БД
        /// </summary>
        public int Id = -1;
        /// <summary>
        /// Уникальный Идентификатор игрока
        /// </summary>
        public Guid Guid = Guid.Empty;
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string FName = "";
        /// <summary>
        /// Фамилия игрока
        /// </summary>
        public string LName = "";
        /// <summary>
        /// Отчество
        /// </summary>
        public string PName = "";
        /// <summary>
        /// Полное имя игрока
        /// </summary>
        public string Name = "";
        /// <summary>
        /// E-Mail
        /// </summary>
        public string EMail = "";
        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string Phone = "";
        /// <summary>
        /// Страна
        /// </summary>
        public string Country = "";
        /// <summary>
        /// Город или поселок
        /// </summary>
        public string City = "";

        /// <summary>
        /// Начальный рейтинг
        /// </summary>
        public int RatingBegin = 0;
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
