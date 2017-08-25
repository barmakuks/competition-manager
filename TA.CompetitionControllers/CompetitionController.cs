using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.Competitions.Forms;

namespace TA.CompetitionControllers
{
    /// <summary>
    /// Интерфейс для управления всеми типами соревнований
    /// </summary>
    public interface CompetitionController
    {
        Competition Competition
        {
            get;
            set;
        }
        /// <summary>
        /// Сформировать сетку матчей
        /// </summary>
        /// <param name="aCompetitionId"></param>
        bool SeedPlayers();
        /// <summary>
        /// Получить Control, представляющий сетку данного типа соревнования
        /// </summary>
        /// <returns></returns>
        CompetitionPanel GetControl();
        /// <summary>
        /// Возвращает UserControl для редактирования специфических параметров соревнования
        /// </summary>
        /// <returns>CompetitionParamsPanel</returns>
        CompetitionParamsPanel GetParametersPanel();
        /// <summary>
        /// Возвращает массив с номерами посева.
        /// Пары игроков образуется так : i-й матч {M[i*2] против M[i*2 + 1]}
        /// </summary>
        /// <param name="playerCount">Количество игроков для посева</param>
        /// <returns></returns>
        int[] GetDrawOrder(int playerCount);
    }
}
