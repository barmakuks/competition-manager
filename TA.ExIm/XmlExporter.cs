using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;
using TA.RatingSystem;

namespace TA.ExIm
{
    internal class XmlExporter : IExporter
    {
        private DateTime CreationDate;
        private string AppGuid;
        private PlayerInfo[] Players = null;
        internal class RatingNode 
        {
            public TypeOfSport Game;
            public List<PlayerRating> Ratings = new List<PlayerRating>();
        } 
        private List<RatingNode> Ratings = new List<RatingNode>();
        private List<Tournament> Tournaments = new List<Tournament>();

        public bool SetHeaderInfo(DateTime date, string appGuid)
        {
            CreationDate = date;
            AppGuid = appGuid;
            return true;
        }

        public bool AddPlayers(PlayerInfo[] players)
        {
            Players = players;
            return true;
        }

        public bool AddRatingList(TypeOfSport game, PlayerRating[] ratings)
        {
            RatingNode node = new RatingNode();
            node.Game = game;
            node.Ratings.Clear();
            node.Ratings.AddRange(ratings);
            Ratings.Add(node);
            return true;
        }

        public bool AddTournament(TournamentInfo tourInfo, Competition[] competitions)
        {
            Tournament tournament = new Tournament();
            tournament.Info.DateBegin = tourInfo.DateBegin;
            tournament.Info.DateEnd = tourInfo.DateEnd;
            tournament.Info.Id = tourInfo.Id;
            tournament.Info.Name = tourInfo.Name;
            tournament.Info.Place = tourInfo.Place;
            for (int i = 0; i < competitions.Length; i++)
                tournament.Competitions.Add(i, competitions[i]);
            Tournaments.Add(tournament);
            return true;
        }

        private string PlayerXmlString(PlayerInfo player) 
        {
            return  String.Format("<MEMBER GUID='{0}' nick='{1}' lname='{2}' fname='{3}' pname='{4}' country='{5}' city='{6}' phones='{7}' email='{8}'/>",
                                        player.Identifier, player.NickName, player.LastName, player.FirstName, player.PatronymicName, 
                                        player.Country, player.City, player.Phone, player.EMail);         
        }
        private string TournamentXmlString(Tournament tour) 
        {
            string tour_info = String.Format("begin='{0}' end='{1}' name='{2}' place='{3}'", 
                                tour.Info.DateBegin.ToString("yyyyMMdd"),
                                tour.Info.DateEnd.ToString("yyyyMMdd"),
                                tour.Info.Name, tour.Info.Place);
            StringBuilder competitions = new StringBuilder();
            foreach (Competition comp in tour.Competitions.Values) 
            {
                competitions.Append(CompetitionToXml(comp));
            }
            return String.Format("<TOURNAMENT {0}><COMPETITIONS>{1}</COMPETITIONS></TOURNAMENT>", tour_info, competitions.ToString());
        }
        private string CompetitionToXml(Competition comp)
        {
            string comp_info = String.Format("rating='{0}' type='{1}' type_name='{2}' date='{3}' name='{4}' sport='{5}' status='{6}'", 
                                comp.Info.ChangesRating,
                                comp.Info.CompetitionType.Id,
                                comp.Info.CompetitionType.Name,
                                comp.Info.Date.ToString("yyyyMMdd"),
                                comp.Info.Name,
                                comp.Info.SportType.Id,
                                comp.Info.Status);
            StringBuilder comp_params = new StringBuilder();
            foreach (KeyValuePair<string,string> param_pair in comp.Info.Properties) 
            {
                comp_params.Append(String.Format("<PARAM name='{0}' value='{1}'/>", param_pair.Key, param_pair.Value));
            }
            StringBuilder matches = new StringBuilder();
            foreach (MatchInfo match in comp.Matches.Values)
            {
                matches.Append(MatchToXml(match));
            }
            StringBuilder plrs = new StringBuilder();
            foreach (TA.Corel.CompetitionPlayerInfo player in comp.Players.Values) 
            {
                plrs.Append(String.Format("<PLAYER guid='{0}' rating='{1}' seed='{2}' place='{3}' start_points='{4}' rebuy_points='{5}' />",
                    player.Identifier, player.RatingBeforeCompetition, player.SeedNo, player.Place.ToString(), player.StartPoints, player.RebuyPoints));
            }
            return String.Format("<COMPETITION {0}><PARAMS>{1}</PARAMS><PLAYERS>{2}</PLAYERS><MATCHES>{3}</MATCHES></COMPETITION>", comp_info, comp_params.ToString(), plrs.ToString(), matches.ToString());
        }

        private string MatchToXml(MatchInfo match)
        {
            return match.XmlString();
        }
        private string ToXmlString() 
        {
            string header = String.Format("date='{0}' app_guid='{1}'", CreationDate.ToString("yyyyMMdd"), AppGuid);            
            string players = "";
            if (Players != null) 
            {
                string str = "";
                foreach (PlayerInfo player in Players) 
                {
                    str += PlayerXmlString(player);
                }
                players = String.Format("<MEMBERS>{0}</MEMBERS>", str);
            }
            string ratings = "";
            if (Ratings.Count > 0) 
            {
                string str = "";
                foreach (RatingNode node in Ratings) 
                {
                    str += RatingToXml(node);
                }
                ratings = String.Format("<RATINGS>{0}</RATINGS>", str);
            }
            string tournaments = "";
            if (Tournaments.Count > 0) 
            {
                string str = "";
                foreach (Tournament tour in Tournaments)
                {
                    str += TournamentXmlString(tour);
                }
                tournaments = String.Format("<TOURNAMENTS>{0}</TOURNAMENTS>", str);
            }
            string xml_string = String.Format("<?xml version='1.0' encoding='utf-8'?><CM_XML {0}>{1}{2}{3}</CM_XML>", header, players, ratings, tournaments);
            xml_string = xml_string.Replace("&", "&amp;");
            return FormatXmlString(xml_string,"  ");
        }

        private string FormatXmlString(string xml_string, string delimeter) 
        {
            StringBuilder result = new StringBuilder();
            string tab = "";
            
            for (int i = 0; i < xml_string.Length; i++) 
            {
                if (xml_string[i] == '/' && xml_string[i-1] != '<') 
                {
                    if (tab.Length - delimeter.Length > 0 && tab.Length - delimeter.Length < tab.Length)
                        tab = tab.Substring(0, tab.Length - delimeter.Length);
                }                    
                if (xml_string[i] == '<') 
                {
                    result.Append(Environment.NewLine);
                    if (xml_string[i + 1] != '/')
                    {
                        result.Append(tab);
                        result.Append(xml_string[i]);
                        tab += delimeter;
                    }
                    else 
                    {
                        if (tab.Length - delimeter.Length > 0 && tab.Length - delimeter.Length < tab.Length)
                            tab = tab.Substring(0, tab.Length - delimeter.Length);
                        result.Append(tab);
                        result.Append(xml_string[i]);
                    }
                        
                }                    
                else
                    result.Append(xml_string[i]);
            }
            return result.ToString().Trim();
        }
        private string RatingToXml(RatingNode node)
        {
            StringBuilder str = new StringBuilder();
            string rating_date = "";
            foreach (PlayerRating rating in node.Ratings) 
            {
                if (rating.LastRatingDate == DateTime.MinValue)
                    rating_date = "";
                else
                    rating_date = rating.LastRatingDate.ToString("yyyyMMdd");
                str.Append(String.Format("<PLAYER_RATING guid='{0}' name='{1}' date='{2}' start='{3}' current='{4}'/>", rating.Guid, rating.Name, rating_date, rating.RatingBegin, rating.Rating));
            }
            return String.Format("<RATING id='{0}' name='{1}'> {2} </RATING>", node.Game.Id, node.Game.Name, str.ToString());
        }
        public bool ExportToFile(string filename)
        {


            return false;
        }

        public override string ToString()
        {
            return ToXmlString();
        }
    }
}
