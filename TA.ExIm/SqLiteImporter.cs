using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using TA.DB.Manager;
using TA.DB;
using TA.Corel;

namespace TA.ExIm
{
    class SqLiteImporter : XmlImporter
    {
        private TA.DB.DatabaseInterface database = null;
        public override bool Open(string pathToDatabase)
        {
            try
            {
                FDate = File.GetLastAccessTime(pathToDatabase);
                string cs = String.Format("Data Source={0};New=False;Version=3", pathToDatabase);
                database = DatabaseManager.CreateDb(cs);
                // 1 - Прочитать параметры                                
                FAppGuid = new Guid(database.GetParamValue(0, "INSTANCE_GUID"));
                // 2 - Прочитать список игроков
                ImportPlayers();
                // 3 - Прочитать рейтинги
                ImportRatings();
                // 4 - Прочитать турниры
                ImportTournaments();
                    // 4.1 - Прочитать соревнования
                        // 4.1.1 - Прочитать список участников
                        // 4.1.2 - Прочитать матчи
                return true;
            }
            catch (Exception) 
            {
                return false;
            }            
        }

        private void ImportPlayers()
        {
            PlayerList players = new PlayerList();
            database.ReadPlayerList(players);
            FPlayers.Clear();
            FPlayers.AddRange(players.Values);
        }
        private void ImportRatings()
        {
            FRatings.Clear();
            TypeOfSportList games = new TypeOfSportList();
            database.ReadTypeOfSportList(games);
            foreach(TypeOfSport game in games.Values)
            {
                XmlExporter.RatingNode node = new XmlExporter.RatingNode();
                node.Game = game;
                TA.RatingSystem.PlayersRatingList ratings = new TA.RatingSystem.PlayersRatingList();
                database.ReadPlayerRatingList(game.Id, ratings);
                node.Ratings.AddRange(ratings.Values);
                FRatings.Add(game, node);
            }
        }
        private void ImportTournaments()
        {
            FTournaments.Clear();
            TournamentList tours = new TournamentList();
            database.ReadTournamentList(tours);
            foreach (Tournament tour in tours.Values) 
            {
                database.ReadCompetitionList(tour);
                foreach (Competition comp in tour.Competitions.Values) 
                {
                    database.ReadCompetitionPlayersList(comp, CompetitionPlayerList.SortByField.SeedNo);
                    database.ReadCompetitionMatchesList(comp);
                }
                FTournaments.Add(tour);
            }
        }

    }
}
