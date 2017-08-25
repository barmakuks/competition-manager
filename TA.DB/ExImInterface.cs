using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TA.DB
{
    public interface ExImInterface
    {
        /// <summary>
        /// Экспорт полного списка игроков в XML
        /// </summary>
        /// <returns>XML-документ, содержит весь список игроков, с начальными рейтингами </returns>
        XmlDocument PlayersListToXml();
        /// <summary>
        /// Импортирует список игроков с начальными рейтингами
        /// </summary>
        /// <param name="xml_string">Входная XML-строка</param>
        /// <returns>TRUE, если импорт прошел успешно</returns>
        bool PlayersListFromXml(string xml_string);
    }
}
