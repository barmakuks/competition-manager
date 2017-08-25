using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace TA.RatingSystem.Builder
{
    public class RatingSystemBuilder
    {
        /// <summary>
        /// Может ли данный вид соревнований быть рейтинговым в данной рейтинговой системе
        /// </summary>
        /// <param name="competitionTypeId">Тип турнирной сетки</param>
        /// <returns>True, если данный тип соревнований может быть рейтинговым</returns>
        public static bool CanBeRating(int competitionTypeId) 
        {
            switch (competitionTypeId) 
            {
                case 0:
                case 1:
                case 2:
                    return true;
                default: return false;
            }
        }
#if FEDITION || STANDARD || FEDITION_PLUS || STANDARD_PLUS

        /// <summary>
        /// Посторение рейтинговой системы и расчет рейтинга
        /// </summary>
        public static void BuildRatingSystem(int gameTypeId, PlayersRatingList players, CompetitionsList competitions, DateTime date)
        {
            // Загрузить список игроков с начальным рейтингом
            TA.DB.Manager.DatabaseManager.CurrentDb.ReadPlayerRatingList(gameTypeId, players);
#if FEDITION
            // Загрузить результаты по порядку возрастания даты
            TA.DB.Manager.DatabaseManager.CurrentDb.ReadRatingCompetitionList(gameTypeId, competitions, date);
            // Пересчитать рейтинги для каждого турнира по мере возрастания даты
            foreach (CompetitionInfo comp in competitions)
            {
                if (comp.IsRating) {
                    int avg_rating = 0;
                    foreach (PlayersCompetitionResult result in comp.Results.Values)
                    {
                        PlayerRating player = players[result.PlayerId];
                        // 1 - Посчитать штрафы за пропуск в зависимости от даты турнира и даты из списка игроков
                        if (player.LastRatingDate != DateTime.MinValue)
                            result.Penalty = (RatingSystem.GetMonthCount(player.LastRatingDate, comp.Date) / 3) * 25;
                        // 2 - Расчитать начальный рейтинг (Рейтинг из списка - штраф)
                        result.RatingBegin = player.Rating - result.Penalty;
                        avg_rating += result.RatingBegin;
                    }
                    foreach (PlayersCompetitionResult result in comp.Results.Values)
                    {
                        PlayerRating player = players[result.PlayerId];
                        // 4 - Расчитать дельту для кажого игрока                    
                        result.Delta = Convert.ToInt32(Math.Round(10.0 * (result.Points - result.OpponentsCount * RatingSystem.Pexp(result.RatingBegin - result.AvgOppRating(comp.Results)))));
                        // 5 - Обновить рейтинг и дату в списке игроков 
                        player.Rating = result.RatingBegin + result.Delta;
                        player.LastRatingDate = comp.Date;
                    }
                }
            }
#endif
        }
        public static PlayersRatingList GetPlayersRating(int gameTypeId, DateTime date)
        {
            PlayersRatingList players = new PlayersRatingList();
            CompetitionsList competitions = new CompetitionsList();
            BuildRatingSystem(gameTypeId, players, competitions, date);
#if FEDITION
            foreach (PlayerRating player in players.Values)
            {
                if (player.LastRatingDate != DateTime.MinValue)
                    player.Rating -= (RatingSystem.GetMonthCount(player.LastRatingDate, date) / 3) * 25;
            }
#endif
            return players;
        }
        public static RatingSystem CreateRatingSystem(int gameTypeId, string gameTypeName) 
        {
            RatingSystem rs = new RatingSystem(gameTypeId, gameTypeName);
            BuildRatingSystem(gameTypeId, rs.Players, rs.Competitions, DateTime.MaxValue);
            return rs;
        }
        public static void SaveRatingSystemToXml(RatingSystem RatingSystem, string filename, DateTime date)
        {
            string xsl_filename = Path.GetFileNameWithoutExtension(filename) + ".xsl";

            File.Copy("RatingXSL.xslt", Path.Combine(Path.GetDirectoryName(filename), xsl_filename), true);
            PlayersRatingList current_rating = GetPlayersRating(RatingSystem.GameTypeId, date);
            XmlDocument doc = new XmlDocument();
            // Аттрибуты документа
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Encoding.UTF8.WebName, String.Empty));
            doc.AppendChild(doc.CreateProcessingInstruction("xml-stylesheet", String.Format("type='text/xsl' href='{0}'", xsl_filename)));

            // Создаем корневой узел
            XmlNode RootNode = doc.CreateElement("RatingSystem");
            RootNode.Attributes.Append(doc.CreateAttribute("Date")).Value = date.ToString("dd.MM.yyyy");
            RootNode.Attributes.Append(doc.CreateAttribute("GameType")).Value = RatingSystem.GameTypeId.ToString();
            RootNode.Attributes.Append(doc.CreateAttribute("GameName")).Value = RatingSystem.GameTypeName;
            doc.AppendChild(RootNode);

            // Узел соревнований
            XmlNode CompetitionsNode = doc.CreateElement("Competitions");
            foreach (CompetitionInfo comp in RatingSystem.Competitions)
            {
                XmlNode competitionNode = doc.CreateElement("Competition");
                competitionNode.Attributes.Append(doc.CreateAttribute("Date")).Value = comp.Date.ToString("dd.MM.yyyy");
                CompetitionsNode.AppendChild(competitionNode);
            }
            RootNode.AppendChild(CompetitionsNode);

            // Узел результатов
            XmlNode ResultsNode = doc.CreateElement("Results");
            foreach (PlayerRating player in current_rating.Values)
            {
                XmlNode playerNode = doc.CreateElement("Player");
                playerNode.Attributes.Append(doc.CreateAttribute("Guid")).Value = player.Guid.ToString();
                playerNode.Attributes.Append(doc.CreateAttribute("FName")).Value = player.FName;
                playerNode.Attributes.Append(doc.CreateAttribute("PName")).Value = player.PName;
                playerNode.Attributes.Append(doc.CreateAttribute("LName")).Value = player.LName;
                playerNode.Attributes.Append(doc.CreateAttribute("Nick")).Value = player.Name;
                playerNode.Attributes.Append(doc.CreateAttribute("EMail")).Value = player.EMail;
                playerNode.Attributes.Append(doc.CreateAttribute("Phone")).Value = player.Phone;
                playerNode.Attributes.Append(doc.CreateAttribute("Country")).Value = player.Country;
                playerNode.Attributes.Append(doc.CreateAttribute("City")).Value = player.City;
                playerNode.Attributes.Append(doc.CreateAttribute("RatingBegin")).Value = player.RatingBegin.ToString();
                playerNode.Attributes.Append(doc.CreateAttribute("RatingCurrent")).Value = player.Rating.ToString();
                foreach (TA.RatingSystem.CompetitionInfo comp in RatingSystem.Competitions)
                {
                    XmlNode resultNode = doc.CreateElement("Result");
                    resultNode.Attributes.Append(doc.CreateAttribute("Date")).Value = comp.Date.ToString("dd.MM.yyyy");
                    string penalty = "";
                    string points = "";
                    if (comp.Results.ContainsKey(player.Id))
                    {
                        TA.RatingSystem.PlayersCompetitionResult res = comp.Results[player.Id];
                        penalty = res.Penalty == 0 ? "" : (-res.Penalty).ToString();
                        points = res.Delta.ToString();
                        if (res.Delta > 0)
                            points = "+" + points;
                    }
                    resultNode.Attributes.Append(doc.CreateAttribute("Penalty")).Value = penalty;
                    resultNode.Attributes.Append(doc.CreateAttribute("Points")).Value = points;
                    playerNode.AppendChild(resultNode);
                }
                ResultsNode.AppendChild(playerNode);

            }
            RootNode.AppendChild(ResultsNode);
            doc.Save(filename);
        }
#endif
    }
}
