using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;
using TA.RatingSystem;

namespace TA.ExIm
{
    interface IImporter
    {
        /// <summary>
        /// Извлекает данные из файла
        /// </summary>
        /// <param name="pathToFile">Имя файла</param>
        /// <returns>True, если данные извлечены успешно</returns>
        bool Open(string pathToFile);
        /// <summary>
        /// Возвращает дату формирования файла обмена
        /// </summary>
        /// <returns></returns>
        DateTime GetDate();
        /// <summary>
        /// Возвращает GUID приложения, сформировавшего файл обмена
        /// </summary>
        /// <returns></returns>
        Guid GetAppGuid();

        /// <summary>
        /// Возвращает список игроков
        /// </summary>
        /// <returns></returns>
        PlayerInfo[] GetPlayers();

        /// <summary>
        /// Возвращает перечень рейтинговых листов
        /// </summary>
        /// <returns></returns>
        TypeOfSport[] GetTypesOfSport();
        /// <summary>
        /// Возвращает рейтинговый лист
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        PlayerRating[] GetPlayersRatings(TypeOfSport game);

        /// <summary>
        /// Возвращает список турниров
        /// </summary>
        /// <returns></returns>
        Tournament[] GetTournaments();

    }
}
