using System;
using System.Collections.Generic;
using System.Text;

namespace TA.Corel
{
    public class Globals
    {
        private Globals() 
        {
        }
        private static TournamentList FTournaments = new TournamentList();
        private static PlayerList FPlayers = new PlayerList();
        private static TypeOfSportList FGames = new TypeOfSportList();
        private static List<string> FCountryList = new List<string>();
  
        /// <summary>
        /// Глобальный список турниров
        /// </summary>
        public static TournamentList Tournaments 
        {
            get{
                return FTournaments;
            }
        }
        /// <summary>
        /// Глобальный список игроков
        /// </summary>
        public static PlayerList Players {
            get {
                return FPlayers;
            }
        }
        /// <summary>
        /// Глобальный список видов спорта
        /// </summary>
        public static TypeOfSportList Games {
            get {
                return FGames;
            }
        }

        /// <summary>
        /// Список стран
        /// </summary>
        public static List<string> Countries 
        {
            get { return FCountryList; }
        }
        
    }
}
