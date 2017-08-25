using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;

namespace TA.DB
{
    public class Utils 
    {
        public static int IsNull(string value, int defaultValue)
        {
            if (value != "")
                return Convert.ToInt32(value);
            else
                return defaultValue;
        }
    }
    public interface DatabaseInterface : 
        ExImInterface, // Функции экспорта - импорта
#if FEDITION || STANDARD || FEDITION_PLUS || STANDARD_PLUS
        RatingInterface // Функции для работы с рейтинговой системой
#endif
    {
        #region Public properties
        string[] CompetitionTypes
        {
            get;
        }
        bool IsDatabaseEmpty
        {
            get;
        }
        int DatabaseVersion { get; set; }
        #endregion

        #region Tournament functions
        bool ReadTournamentList(TournamentList list);
        bool TournamentInfoSave(TournamentInfo info);
        bool TournamentDelete(int tournamentId);
        #endregion

        #region Competitions functions
        string GetParamValue(int competitionId, string paramName);
        void SetParamValue(int competitionId, string paramName, string paramValue);
        bool ReadProperties(int competitionId, PropertiesList properties);
        bool WriteProperties(int competitionId, PropertiesList properties);

        bool CompetitionInfoSave(CompetitionInfo info);
        bool ReadCompetitionList(Tournament tournament);
        bool ReadCompetitionList(int tournamentId, CompetitionList list);
        bool CompetitionDelete(int competitionId);

        bool ReadCompetitionPlayersList(int competitionId, CompetitionPlayerList players, CompetitionPlayerList.SortByField sortOrder);
        bool ReadCompetitionPlayersList(TA.Corel.Competition competition, CompetitionPlayerList.SortByField sortOrder);
        /// <summary>
        /// Creates matches for competition
        /// </summary>
        /// <param name="aCompetition"></param>
        /// <returns></returns>
        bool CreateMatches(TA.Corel.Competition aCompetition, int aGridType);
        bool ReadCompetitionMatchesList(TA.Corel.Competition competition);
        #endregion

        #region Matches Functions 
        bool CreateMatch(int competitionId, MatchInfo match);
        bool DeleteMatch(int match_id);
        bool DeleteMatch(MatchInfo match);
        bool WriteMatch(MatchInfo match);
        bool WriteMatch(MatchInfo match, int Depth);
        #endregion

        #region Player Functions
        bool TryToDeletePlayer(int playerId);
        bool PlayerInfoSave(PlayerInfo info);
        bool ReadPlayerList(PlayerList list);
        bool ReadPlayerList(int gameType, PlayerList list);
        #endregion

        #region Competition Players functions
        bool CompetitionPlayerInfoSave(CompetitionPlayerInfo info);
        bool CompetitionPlayerInfoDelete(int competitionId, int playerId);
        bool SetCompetitionPlayerPlace(int aCompetitionId, int aPlayerId, string place);
        #endregion

        #region Other functions
        bool ReadTypeOfSportList(TypeOfSportList list);
        bool SaveTypeOfSport(TypeOfSport sport);
        bool DeleteTypeOfSport(int id);
        bool ExecuteSQL(string sqlCode);
        #endregion
        
    }
}
