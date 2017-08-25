using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TA.Corel
{
    public class TournamentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public TournamentInfo()
        {
            Id = -1; DateBegin = DateEnd = DateTime.MinValue;
        }
        public TournamentInfo(TournamentInfo aCopy)
        {
            Id = aCopy.Id;
            Name = aCopy.Name;
            Place = aCopy.Place;
            DateBegin = aCopy.DateBegin;
            DateEnd = aCopy.DateEnd;
        }
    }
    public class Tournament
    {
        private TournamentInfo FInfo = new TournamentInfo();
        private CompetitionList FCompetitions = new CompetitionList();

        public TournamentInfo Info 
        {
            get {
                return FInfo;
            }
        }
        public CompetitionList Competitions 
        {
            get {
                return FCompetitions;
            }
        }
        public void ExportToXml(string pathToXml) 
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Encoding.UTF8.WebName, String.Empty));
            XmlNode RootNode = doc.CreateElement("tournament");
            doc.AppendChild(RootNode);

            XmlAttribute attr = doc.CreateAttribute("dateBegin");
            attr.Value = Info.DateBegin.ToString("yyyy.MM.dd");
            RootNode.Attributes.Append(attr);

            attr = doc.CreateAttribute("dateEnd");
            attr.Value = Info.DateEnd.ToString("yyyy.MM.dd");
            RootNode.Attributes.Append(attr);

            attr = doc.CreateAttribute("name");
            attr.Value = Info.Name;
            RootNode.Attributes.Append(attr);

            attr = doc.CreateAttribute("place");
            attr.Value = Info.Place;
            RootNode.Attributes.Append(attr);

            foreach (TA.Corel.Competition competition in Competitions.Values) 
            {
                RootNode.InnerXml += competition.XmlString();
            }
            doc.Save(pathToXml);
        }
    }
}
