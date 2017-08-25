using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;

namespace TA.Corel
{
    public class TypeOfSportList : Dictionary<int, TypeOfSport>
    {

    }

    public class PlayerList : Dictionary<Guid, PlayerInfo>
    {
    }

    public class PropertiesList : Dictionary<string, string> 
    {
        public new string this[string key] 
        {
            set {
                if (!this.ContainsKey(key))
                    Add(key,value);
                else
                    base[key] = value;
            }
            get {
                if (!this.ContainsKey(key))
                    Add(key, "");
                    return base[key];
            }
        }
        public int GetInt32Value(string name, int defValue) 
        {
            string str = this[name];
            if (str == "")
                return defValue;
            else
                return Convert.ToInt32(str);
        }
        public bool GetBooleanValue(string name, bool defValue) 
        {
            string val = "";
            if (TryGetValue(name, out val))
                return val == true.ToString();
            else
                return defValue;
        }
        public string GetStringValue(string name, string defValue) 
        {
            string val = "";
            if (TryGetValue(name, out val))
                return val;
            else
                return defValue;
        }
    }
    public class CompetitionPlayerList : Dictionary<int, CompetitionPlayerInfo>
    {
        public enum SortByField { Name, Raiting, SeedNo, Place };

        public List<CompetitionPlayerInfo> GetSortedList(SortByField sortOrder) 
        {
            List<CompetitionPlayerInfo> sortedList = new List<CompetitionPlayerInfo>(this.Values);
            switch(sortOrder)
            {
                case SortByField.Name:
                    sortedList.Sort(new ComparePlayerByName(true));
                    break;
                case SortByField.Raiting:
                    sortedList.Sort(new ComparePlayerByRating(false));
                    break;
                case SortByField.SeedNo:
                    sortedList.Sort(new ComparePlayerBySeedNo(true));
                    break;
                case SortByField.Place:
                    sortedList.Sort(new ComparePlayerByPlace(true));
                    break;
            }
            return sortedList;            
        }
        public string XmlString()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode RootNode = doc.CreateElement("players");
            doc.AppendChild(RootNode);
            foreach (CompetitionPlayerInfo player in Values)
            {
                RootNode.InnerXml += player.XmlString();
            }
            return doc.OuterXml;
        }

    }

    public class MatchList : Dictionary<int, MatchInfo>
    {
        private Dictionary<MatchLabel, int> FLabels = new Dictionary<MatchLabel, int>();
        public MatchInfo GetMatchByLabel(MatchLabel label) 
        {
            if (label.IsEmpty)
                return null;
            else
            {
                MatchInfo info; 
                if(this.TryGetValue(FLabels[label], out info))
                    return info;
                else return null;
                //return this[FLabels[label]];
            }
            
        }
        public MatchInfo GetMatchByLabel(int division, int round, int match_no) 
        {
            return GetMatchByLabel(new MatchLabel(division, round, match_no));
        }
        public new void Add(int id, MatchInfo match)
        {
            base.Add(id, match);
            FLabels.Add(match.Label, id);
        }
        public new void Clear() 
        {
            base.Clear();
            FLabels.Clear();
        }
        public string XmlString() 
        {
            XmlDocument doc = new XmlDocument();
            XmlNode RootNode = doc.CreateElement("matches");
            doc.AppendChild(RootNode);
            foreach (MatchInfo match in Values) 
            {
                RootNode.InnerXml += match.XmlString();
            }
            return doc.OuterXml;
        }
    }

    public class CompetitionList : Dictionary<int, Competition>
    {
    }

    public class TournamentList : Dictionary<int, Tournament>
    {
    }
}
