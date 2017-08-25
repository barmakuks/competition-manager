using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TA.Corel
{
    /// <summary>
    /// Представление соревнования в структуре турнира
    /// </summary>
    public abstract class Competition
    {
        private CompetitionInfo FInfo = new CompetitionInfo();
        private MatchList FMatches = new MatchList();
        private CompetitionPlayerList FPlayers = new CompetitionPlayerList();
        
        public CompetitionInfo Info 
        {
            get {
                return FInfo;
            }
        }
        public MatchList Matches 
        {
            get {
                return FMatches;
            }
        }
        public CompetitionPlayerList Players {
            get {
                return FPlayers;
            }
        }
        public virtual List<CompetitionPlayerInfo> PlayersResults 
        {
            get {
                return FPlayers.GetSortedList(CompetitionPlayerList.SortByField.Place);
            }
        }
        public virtual List<CompetitionPlayerInfo> PlayersPlaces 
        {
            get {
                return PlayersResults;
            }
        } 
        private XmlAttribute CreateAttribute(XmlDocument doc, string attrName, string attrValue) 
        {
            XmlAttribute attr = doc.CreateAttribute(attrName);
            attr.Value = attrValue;
            return attr;
        }
        public virtual string XmlString() 
        {
            XmlDocument doc = new XmlDocument();
            XmlNode RootNode = doc.CreateElement("CompetitionInfo");
            RootNode.Attributes.Append(CreateAttribute(doc, "gameType", Info.SportType.Id.ToString()));
            RootNode.Attributes.Append(CreateAttribute(doc, "rating", Info.ChangesRating.ToString()));
            RootNode.Attributes.Append(CreateAttribute(doc, "name", Info.Name));
            RootNode.Attributes.Append(CreateAttribute(doc, "status", Enum.GetName(typeof(CompetitionInfo.CompetitionState), Info.Status)));
            RootNode.Attributes.Append(CreateAttribute(doc, "drawingtype", Info.CompetitionType.ToString()));
            doc.AppendChild(RootNode);
            RootNode.InnerXml += Players.XmlString();
            RootNode.InnerXml += Matches.XmlString();
            return doc.OuterXml;
        }
        public abstract void InitializeMatches();
        public abstract bool CanFinishRegistration
        {
            get;
        }
        public virtual bool CanFinishCompetition
        {
            get
            {
                if (Matches.Values.Count == 0)
                    return false;
                foreach (MatchInfo match in Matches.Values)
                {
                    if (match.Winner == MatchLabel.PlayerLetters.Unknown)
                        return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Возвращает порядок жеребьевки игроков
        /// </summary>
        /// <returns></returns>
        public abstract int[] GetSeedOrder();
        /// <summary>
        /// true - если игроки нуждаются в жеребьевке перед началом соревнований
        /// </summary>
        public virtual bool NeedsPlayersDrawing { get { return true; } }

        /// <summary>
        /// Проверяет правильно ли заполнены параметры соревнования
        /// </summary>
        /// <param name="error">Строка сообщения о неправильных параметрах</param>
        /// <returns>True, если параметры правильные</returns> 
        public virtual bool CheckCompetitionParams(ref string error) 
        {
            return true;
        }

    }
}
