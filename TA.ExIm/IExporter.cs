using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;
using TA.RatingSystem;

namespace TA.ExIm
{
    interface IExporter
    {
        /// <summary>
        /// Формирует заголовок файла
        /// </summary>
        /// <param name="date">Дата формирования</param>
        /// <param name="appGuid">Guid приложения, сформировавшего файл</param>
        /// <returns>true, в случае успешного завершения</returns>
        bool SetHeaderInfo(DateTime date, string appGuid);
        /// <summary>
        /// Добавление списка игроков
        /// </summary>
        /// <param name="players">Массив данных игроков</param>
        /// <returns>true, в случае успешного завершения</returns>
        bool AddPlayers(PlayerInfo[] players);
        /// <summary>
        /// Добавление рейтингового листа
        /// </summary>
        /// <param name="rating">Массив данных о рейтинге</param>
        /// <returns>true, в случае успешного завершения</returns>
        bool AddRatingList(TypeOfSport game, PlayerRating[] ratings);        
        /// <summary>
        /// Добавление турнира и его соревнований
        /// </summary>
        /// <param name="tourInfo">Информация о турнире</param>
        /// <param name="competitions">Массив полных данных о соревнованиях</param>
        /// <returns>true, в случае успешного завершения</returns>
        bool AddTournament(TournamentInfo tourInfo, Competition[] competitions);        
        /// <summary>
        /// Экспортирование данных в файл
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>true, в случае успешного завершения</returns>
        bool ExportToFile(string filename);
    }
}
