using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;
using TA.Corel;
using TA.RatingSystem;
namespace TA.ExIm
{
    class XmlImporter : IImporter
    {
        protected DateTime FDate;
        protected Guid FAppGuid;

        protected List<PlayerInfo> FPlayers = new List<PlayerInfo>();

        protected Dictionary<TypeOfSport, XmlExporter.RatingNode> FRatings = new Dictionary<TypeOfSport, XmlExporter.RatingNode>();
        protected XmlExporter.RatingNode rating_node = null;

        protected List<Tournament> FTournaments = new List<Tournament>();
        protected Tournament tournament = null;

        protected Competition competition = null;
        protected MatchInfo match = null;
        

        public virtual bool Open(string pathToXml)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(pathToXml);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:    // Узел является элементом.                        
                            if (reader.Name == "CM_XML")
                            {
                                FDate = DateTime.ParseExact(reader.GetAttribute("date"), "yyyyMMdd", CultureInfo.InvariantCulture);
                                FAppGuid = new Guid(reader.GetAttribute("app_guid"));
                            }
                            if (reader.Name == "MEMBERS") 
                            {
                                FPlayers.Clear();
                            }
                            if (reader.Name == "MEMBER") 
                            {
                                PlayerInfo player = new PlayerInfo();
                                player.Identifier = new Guid(reader.GetAttribute("GUID"));
                                player.NickName = reader.GetAttribute("nick");
                                player.LastName = reader.GetAttribute("lname");
                                player.FirstName = reader.GetAttribute("fname");
                                player.PatronymicName = reader.GetAttribute("pname");
                                player.Country = reader.GetAttribute("country");
                                player.City = reader.GetAttribute("city");
                                player.Phone = reader.GetAttribute("phones");
                                player.EMail = reader.GetAttribute("email");

                                // в trial версии можно экспортировать за раз не более 10 игроков
                                if(EditionManager.Edition != EditionType.Mini)
                                    if (!EditionManager.IsTrial || FPlayers.Count < 10) // в trial версии можно экспортировать за раз не более 10 игроков
                                        FPlayers.Add(player);
                            }
                            if (reader.Name == "RATINGS") 
                            {
                                // Начинаем экспортирование рейтингов
                                FRatings.Clear();
                            }
                            if (reader.Name == "RATING") 
                            {
                                rating_node = new XmlExporter.RatingNode();
                                rating_node.Game = new TypeOfSport();
                                rating_node.Game.Id = Convert.ToInt32(reader.GetAttribute("id"));
                                rating_node.Game.Name = reader.GetAttribute("name");
                                // в trial версии можно экспортировать за раз не более 1 рейтинга
                                if(EditionManager.Edition != EditionType.Mini)
                                    if (!EditionManager.IsTrial || FRatings.Count < 1)
                                        FRatings.Add(rating_node.Game, rating_node);
                            }
                            if (reader.Name == "PLAYER_RATING")
                            {
                                if (EditionManager.Edition != EditionType.Mini) 
                                {
                                    if (rating_node == null)
                                        throw new Exception("Не задан рейтинговый лист");
                                    PlayerRating rating = new PlayerRating();
                                    string date = reader.GetAttribute("date");
                                    if (date != "")
                                        rating.LastRatingDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                                    rating.Guid = new Guid(reader.GetAttribute("guid"));
                                    rating.RatingBegin = Convert.ToInt32(reader.GetAttribute("start"));
                                    rating.Rating = Convert.ToInt32(reader.GetAttribute("current"));
                                    rating.Name = reader.GetAttribute("name");
                                    rating_node.Ratings.Add(rating);
                                }
                            }
                            if (reader.Name == "TOURNAMENTS") 
                            {
                                FTournaments.Clear();
                            }
                            if (reader.Name == "TOURNAMENT") 
                            {
                                tournament = new Tournament();
                                tournament.Info.DateBegin = DateTime.ParseExact(reader.GetAttribute("begin"), "yyyyMMdd", CultureInfo.InvariantCulture);
                                tournament.Info.DateEnd = DateTime.ParseExact(reader.GetAttribute("end"), "yyyyMMdd", CultureInfo.InvariantCulture);
                                tournament.Info.Name = reader.GetAttribute("name");
                                tournament.Info.Place = reader.GetAttribute("place");
                                
                                if(EditionManager.Edition != EditionType.Mini && EditionManager.Edition != EditionType.Standard)
                                    if (!EditionManager.IsTrial || FTournaments.Count < 1) // в trial версии можно экспортировать за раз не более 1 турнира
                                        FTournaments.Add(tournament);
                            }
                            if (reader.Name == "COMPETITIONS") 
                            {
                                if (tournament == null)
                                    throw new Exception("Tournamet is not initialized");
                                tournament.Competitions.Clear();
                            }
                            if (reader.Name == "COMPETITION") 
                            {
                                TA.Corel.CompetitionInfo ci = new TA.Corel.CompetitionInfo();
                                ci.ChangesRating = Convert.ToBoolean(reader.GetAttribute("rating"));
                                ci.CompetitionType.Id = Convert.ToInt32(reader.GetAttribute("type"));
                                ci.CompetitionType.Name = reader.GetAttribute("type_name");
                                ci.Date = DateTime.ParseExact(reader.GetAttribute("date"),"yyyyMMdd", CultureInfo.InvariantCulture);
                                ci.Name = reader.GetAttribute("name");
                                ci.SportType.Id = Convert.ToInt32(reader.GetAttribute("sport"));
                                ci.Status = (TA.Corel.CompetitionInfo.CompetitionState)(Enum.Parse(typeof(TA.Corel.CompetitionInfo.CompetitionState), reader.GetAttribute("status")));
                                competition = TA.Competitions.CompetitionFactory.CreateCompetition(ci);
                                // в trial версии можно экспортировать за раз не более 1 соревнования
                                if (!EditionManager.IsTrial || tournament.Competitions.Count < 1)
                                    tournament.Competitions.Add(tournament.Competitions.Count + 1, competition);                                
                            }
                            if (reader.Name == "PARAMS") 
                            {
                                if (competition == null)
                                    throw new Exception("Competition is not initialized");
                                competition.Info.Properties.Clear();
                            }
                            if (reader.Name == "PARAM") 
                            {
                                if (competition == null)
                                    throw new Exception("Competition is not initialized");
                                competition.Info.Properties.Add(reader.GetAttribute("name"), reader.GetAttribute("value"));
                            }
                            if (reader.Name == "PLAYERS")
                            {
                                if (competition == null)
                                    throw new Exception("Competition is not initialized");
                                competition.Players.Clear();
                            }
                            if (reader.Name == "PLAYER")
                            {
                                if (competition == null)
                                    throw new Exception("Competition is not initialized");
                                CompetitionPlayerInfo pi = new CompetitionPlayerInfo();
                                pi.Identifier = new Guid(reader.GetAttribute("guid"));
                                pi.Place = new TA.Utils.StringAlt(reader.GetAttribute("place"));
                                pi.RatingBeforeCompetition = Convert.ToInt32(reader.GetAttribute("rating"));
                                pi.SeedNo = Convert.ToInt32(reader.GetAttribute("seed"));
                                pi.StartPoints = Convert.ToInt32(reader.GetAttribute("start_points"));
                                pi.RebuyPoints = Convert.ToInt32(reader.GetAttribute("rebuy_points"));
                                competition.Players.Add(competition.Players.Count + 1, pi);
                            }

                            if (reader.Name == "MATCHES") 
                            {
                                if (competition == null)
                                    throw new Exception("Competition is not initialized");
                                competition.Matches.Clear();
                            }
                            if (reader.Name == "MATCH") 
                            {
                                if (competition == null)
                                    throw new Exception("Competition is not initialized");
                                match = new MatchInfo();
                                match.Label.Label = reader.GetAttribute("label");
                                match.Loosers_MatchLabel.Label = reader.GetAttribute("looser_label");
                                match.Winners_MatchLabel.Label = reader.GetAttribute("winner_label");
                                match.Winner = (MatchLabel.PlayerLetters)Enum.Parse(typeof(MatchLabel.PlayerLetters), reader.GetAttribute("winner"));                                     
                                competition.Matches.Add(competition.Matches.Count + 1, match);
                            }
                            if (reader.Name == "PLAYER_A") 
                            {
                                if (match == null)
                                    throw new Exception("Match is not initialized");
                                match.PlayerA.Id = Convert.ToInt32(reader.GetAttribute("id"));
                                match.PlayerA.Guid = new Guid(reader.GetAttribute("guid"));
                                match.PlayerA.Points = Convert.ToInt32(reader.GetAttribute("points"));
                                match.PlayerA.Tag = Convert.ToInt32(reader.GetAttribute("tag"));
                            }
                            if (reader.Name == "PLAYER_B") 
                            {
                                if (match == null)
                                    throw new Exception("Match is not initialized");
                                match.PlayerB.Id = Convert.ToInt32(reader.GetAttribute("id"));
                                match.PlayerB.Guid = new Guid(reader.GetAttribute("guid"));
                                match.PlayerB.Points = Convert.ToInt32(reader.GetAttribute("points"));
                                match.PlayerB.Tag = Convert.ToInt32(reader.GetAttribute("tag"));
                            }
                            break;
                    }
                }
                return true;
            }
            catch (Exception) 
            {
                
                return false;
            }            
        }
        public DateTime GetDate()
        {
            return FDate;
        }
        public Guid GetAppGuid()
        {
            return FAppGuid;
            
        }
        public PlayerInfo[] GetPlayers()
        {
            return FPlayers.ToArray();            
        }
        public TypeOfSport[] GetTypesOfSport()
        {
            return FRatings.Keys.ToArray();            
        }
        public PlayerRating[] GetPlayersRatings(TypeOfSport game)
        {
            return FRatings[game].Ratings.ToArray();            
        }
        public Tournament[] GetTournaments()
        {
            return FTournaments.ToArray();
            
        }        
    }
}
