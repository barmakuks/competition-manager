using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using TA.Corel;
using ErrorViewer;
using System.Data.SQLite;
using System.Xml;

namespace TA.DB.SQLite
{
    public class SQLiteDatabase : TA.DB.DatabaseInterface
    {
        #region Public Properties
        private string ConnectionString = "";
        public SQLiteDatabase(string connetionString)
        {
            ConnectionString = connetionString;
        }
        public string[] CompetitionTypes
        {
            get
            {
                try
                {
                    ArrayList list = new ArrayList();
                    SQLiteConnection connection = new SQLiteConnection(ConnectionString);
                    SQLiteCommand command = new SQLiteCommand("select Id, Description from CompetitionTypes order by Id", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string str = Convert.ToString(reader["Description"]);
                        list.Add(str);
                    }
                    reader.Close();
                    return (string[])(list.ToArray(typeof(string)));
                }
                catch (Exception ex)
                {
                    ErrorView.Show(ex);
                    return null;
                }
            }
        }
        public bool IsDatabaseEmpty
        {
            get {
                SQLiteConnection connection = new SQLiteConnection(ConnectionString);
                try
                {
                    string sql = "select COUNT(*) as PC from Players";
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();
                    bool result = reader.Read() && reader[0].ToString() == "0";
                    reader.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    ErrorView.Show(ex);
                    return false;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
        public int DatabaseVersion
        {
            get
            {
                string str = GetParamValue(0, "DATABASE_VERSION");
                if (str != "")
                    return Convert.ToInt32(str);
                else return 0;
            }
            set
            {
                SetParamValue(0, "DATABASE_VERSION", value.ToString());
            }
        }

        #endregion

        #region Tournaments Functions
        public bool ReadTournamentList(TournamentList list)
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = ConnectionString;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                SQLiteCommand command = new SQLiteCommand("select * from Tournaments order by DateBegin", connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                list.Clear();
                SQLiteDataReader reader = (SQLiteDataReader)command.ExecuteReader();
                while (reader.Read())
                {
                    Tournament tournament = new Tournament();
                    TournamentInfo info = tournament.Info;
                    info.Id = Convert.ToInt32(reader["Id"]);
                    info.Name = Convert.ToString(reader["Name"]);
                    info.Place = Convert.ToString(reader["Place"]);
                    info.DateBegin = Convert.ToDateTime(reader["DateBegin"]);
                    info.DateEnd = Convert.ToDateTime(reader["DateEnd"]);
                    list.Add(info.Id, tournament);
#if BETA
                    if (list.Count >= EditionManager.MaxTournamentCount)
                        return true;
#endif
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool TournamentInfoSave(TA.Corel.TournamentInfo info)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql = "";
                if (info.Id == -1)
                {
                    sql = @"insert into Tournaments ([Name], Place, DateBegin, DateEnd)
		                        values (@Name, @Place, @DateBegin, @DateEnd);";
                }
                else
                {
                    sql = @"update Tournaments  set
                        		[Name] = @Name,
		                        Place = @place,
		                        DateBegin = @DateBegin,
		                        DateEnd = @DateEnd
		                        where [id] = @id";
                }
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                if (info.Id != -1)
                    command.Parameters.Add(new SQLiteParameter("@id", info.Id));
                command.Parameters.Add(new SQLiteParameter("@Name", info.Name));
                command.Parameters.Add(new SQLiteParameter("@Place", info.Place));
                command.Parameters.Add(new SQLiteParameter("@DateBegin", info.DateBegin));
                command.Parameters.Add(new SQLiteParameter("@DateEnd", info.DateEnd));
                command.ExecuteNonQuery();
                if (info.Id == -1)
                {
                    command = new SQLiteCommand("select MAX([id]) as Id from Tournaments", connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        info.Id = Convert.ToInt32(reader["Id"]);
                    reader.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        public bool TournamentDelete(int tournamentId)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(@"BEGIN TRANSACTION;
                        delete from CompetitionPlayers where CompetitionId in (select Id from Competitions where TournamentId = @tournamentId);
                        delete from CompetitionParams where CompetitionId in (select Id from Competitions where TournamentId = @tournamentId);
                        delete from Matches where CompetitionId in (select Id from Competitions where TournamentId = @tournamentId);
	                    delete from Competitions where TournamentId = @tournamentId;
	                    delete from Tournaments where Id = @tournamentId;
                        COMMIT", connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@tournamentId", tournamentId));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Competitions Functions
        public string GetParamValue(int competitionId, string paramName)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql_str = String.Format("select paramValue from CompetitionParams where CompetitionId = {0} and ParamName = '{1}'", competitionId, paramName.ToUpper());
                SQLiteCommand command = new SQLiteCommand(sql_str, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                string result = "";
                if (reader.Read())
                {
                    result = Convert.ToString(reader["paramValue"]);
                }
                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return "";
            }
            finally
            {
                connection.Close();
            }
        }
        public void SetParamValue(int competitionId, string paramName, string paramValue)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql_str = String.Format("select paramValue from CompetitionParams where CompetitionId = {0} and ParamName = '{1}'", competitionId, paramName.ToUpper());
                SQLiteCommand command = new SQLiteCommand(sql_str, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                string sql_format = "INSERT INTO CompetitionParams (CompetitionId, ParamName, ParamValue) VALUES ({0},'{1}','{2}')";
                if (reader.Read())
                {
                    sql_format = "UPDATE CompetitionParams SET ParamValue = '{2}' WHERE CompetitionId = {0} and ParamName = '{1}'";
                }
                reader.Close();
                command.CommandText = String.Format(sql_format, competitionId, paramName, paramValue);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool ReadProperties(int competitionId, PropertiesList properties)
        {
            properties.Clear();
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(String.Format("select * from CompetitionParams where CompetitionId = {0}", competitionId), connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    properties.Add(Convert.ToString(reader["ParamName"]), Convert.ToString(reader["ParamValue"]));
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool WriteProperties(int competitionId, PropertiesList properties)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(String.Format("DELETE FROM CompetitionParams where CompetitionId = {0}", competitionId), connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                foreach (string paramName in properties.Keys)
                {
                    command.CommandText = String.Format("INSERT INTO CompetitionParams (CompetitionId, ParamName, ParamValue) VALUES({0},'{1}','{2}')", competitionId, paramName, properties[paramName]);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool CompetitionInfoSave(TA.Corel.CompetitionInfo info)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql = "";
                if (info.Id == -1)
                {
                    sql = @"insert into Competitions (TournamentId, [Name], GameType, ChangesRating, Type,  Status)
		                    values (@tournamentId, @Name, @GameType, @ChangesRating, @Type, @status)";
                }
                else
                {
                    sql = @"update Competitions  set
		                    TournamentId = @tournamentId,
		                    GameType = @GameType,
		                    ChangesRating = @ChangesRating,
		                    [Name] = @Name,
		                    Type = @Type,
		                    Status = @status
		                    where [id] = @id";
                }
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                if (info.Id != -1)
                    command.Parameters.Add(new SQLiteParameter("@id", info.Id));

                command.Parameters.Add(new SQLiteParameter("@TournamentId", info.TournamentId));
                command.Parameters.Add(new SQLiteParameter("@Name", info.Name));
                command.Parameters.Add(new SQLiteParameter("@Status", (int)(info.Status)));
                command.Parameters.Add(new SQLiteParameter("@Type", info.CompetitionType.Id));
                command.Parameters.Add(new SQLiteParameter("@GameType", info.SportType.Id));
                command.Parameters.Add(new SQLiteParameter("@ChangesRating", info.ChangesRating));
                command.ExecuteNonQuery();
                if (info.Id == -1)
                {
                    command = new SQLiteCommand("select MAX(id) as Id from Competitions", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        info.Id = Convert.ToInt32(reader["Id"]);
                    }
                    reader.Close();
                }
                connection.Close();
                return WriteProperties(info.Id, info.Properties);
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool ReadCompetitionList(Tournament tournament)
        {
            return ReadCompetitionList(tournament.Info.Id, tournament.Competitions);
        }
        public bool ReadCompetitionList(int tournamentId, CompetitionList list)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql_str = String.Format("select * from vCompetitions where TournamentId = {0}", tournamentId);
                SQLiteCommand command = new SQLiteCommand(sql_str, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                list.Clear();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int type = Convert.ToInt32(reader["Type"]);
                    TA.Corel.Competition competition = TA.Competitions.CompetitionFactory.CreateCompetition(TA.Corel.CompetitionType.TypeList[type]);
                    CompetitionInfo info = competition.Info;
                    info.Id = Convert.ToInt32(reader["Id"]);
                    info.Name = Convert.ToString(reader["Name"]);
                    info.Status = (CompetitionInfo.CompetitionState)(Convert.ToInt32(reader["Status"]));
                    //info.CompetitionType = CompetitionType.TypeList[type];
                    info.Date = Convert.ToDateTime(reader["DateBegin"]);
                    info.PlayerCount = Convert.ToInt32(reader["PlayerCount"]);
                    info.TournamentId = tournamentId;
                    info.ChangesRating = Convert.ToBoolean(reader["ChangesRating"]);
                    info.SportType = Globals.Games[Convert.ToInt32(reader["GameType"])];
                    ReadProperties(info.Id, info.Properties);
                    list.Add(info.Id, competition);
#if BETA
                    if (list.Count >= EditionManager.MaxCompetitionCount)
                        return true;
#endif
                }
                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool CompetitionDelete(int competitionId)
        {
            string sql = @"BEGIN TRANSACTION;
	        delete from Matches where CompetitionId = @competitionId;
	        delete from CompetitionPlayers where CompetitionId = @competitionId;
	        delete from Competitions where Id = @competitionId;
            DELETE FROM CompetitionParams where CompetitionId = @competitionId;
            COMMIT;";
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@CompetitionId", competitionId));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool ReadCompetitionPlayersList(int competitionId, CompetitionPlayerList players, CompetitionPlayerList.SortByField sortOrder)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql_str = String.Format("select * from vCompetitionPlayers where CompetitionId = {0}", competitionId);
                switch (sortOrder)
                {
                    case CompetitionPlayerList.SortByField.Name:
                        sql_str = sql_str + " order by LastName, FirstName, PatronymicName";
                        break;
                    case CompetitionPlayerList.SortByField.Raiting:
                        sql_str = sql_str + " order by Rating desc";
                        break;
                    case CompetitionPlayerList.SortByField.SeedNo:
                        sql_str = sql_str + " order by SeedNo";
                        break;
                    case CompetitionPlayerList.SortByField.Place:
                        sql_str = sql_str + " and Place <> '' order by Place";
                        break;
                }
                SQLiteCommand command = new SQLiteCommand(sql_str, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                players.Clear();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompetitionPlayerInfo info = new CompetitionPlayerInfo();
                    info.Id = Convert.ToInt32(reader["PlayerId"]);
                    info.Identifier = new Guid(Convert.ToString(reader["Identifier"]));
                    info.FirstName = Convert.ToString(reader["FirstName"]);
                    info.LastName = Convert.ToString(reader["LastName"]);
                    info.PatronymicName = Convert.ToString(reader["PatronymicName"]);
                    info.NickName = Convert.ToString(reader["NickName"]);
                    info.Place = Convert.ToString(reader["Place"]);
                    info.CompetitionId = Convert.ToInt32(reader["CompetitionId"]);
                    info.SeedNo = Convert.ToInt32(reader["SeedNo"]);
                    info.StartPoints = Convert.ToInt32(reader["StartPoints"]);
                    info.RebuyPoints = Convert.ToInt32(reader["RebuyPoints"]);
                    info.RatingBeforeCompetition = Convert.ToInt32(reader["Rating"]);
                    info.EMail = reader["EMail"].ToString();
                    info.Phone = (reader["Phone"]).ToString();
                    info.Country = (reader["Country"]).ToString();
                    info.City = reader["City"].ToString();
                    players.Add(info.Id, info);
                }
#if !DEBUG
                if (players.Count > EditionManager.MaxPlayers)
                    throw new Exception("Exceeded the limit of players.");
#endif
                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool ReadCompetitionPlayersList(TA.Corel.Competition competition, CompetitionPlayerList.SortByField sortOrder)
        {
            return ReadCompetitionPlayersList(competition.Info.Id, competition.Players, sortOrder);
        }
        public bool CreateMatches(TA.Corel.Competition aCompetition, int aGridType)
        {
            if (ConnectionString == null)
                throw new Exception("Connection string is empty");
            if (aCompetition.Matches.Count != 0)
                throw new Exception("Competition matches already created");

            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(@"insert into Matches (CompetitionId, MatchLabel, PlayerA_Id, PlayerB_Id, PlayerA_Points, PlayerB_Points, Winner_Id, Winners_MatchLabel, Loosers_MatchLabel)
                        select @competition_id , MatchLabel, -1, -1, 0, 0,-1, Winners_MatchLabel, Loosers_MatchLabel
                        from SeedTemplate st, vCompetitions vc
                        where st.CompetitionType = @competition_type and [Id] = @competition_id
                        and st.PlayerCount >= vc.PlayerCount and st.PlayerCount < vc.PlayerCount * 2;", connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@competition_id", aCompetition.Info.Id));
                command.Parameters.Add(new SQLiteParameter("@competition_type", aGridType));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool ReadCompetitionMatchesList(TA.Corel.Competition aCompetition)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(String.Format("select * from vMatches where CompetitionId = {0} order by MatchLabel", aCompetition.Info.Id), connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                aCompetition.Matches.Clear();
                while (reader.Read())
                {
                    MatchInfo match = new MatchInfo();
                    match.Id = Convert.ToInt32(reader["Id"]);
                    match.Label.Label = reader["MatchLabel"].ToString();
                    match.PlayerA.Id = Convert.ToInt32(reader["PlayerA_Id"]);
                    match.PlayerA.Guid = TA.Utils.Utils.IsNullGuid(reader["PlayerA_Guid"]);
                    match.PlayerB.Guid = TA.Utils.Utils.IsNullGuid(reader["PlayerB_Guid"]);
                    match.PlayerB.Id = Convert.ToInt32(reader["PlayerB_Id"]);
                    match.PlayerA.Name = reader["PlayerA_Nick"].ToString();
                    match.PlayerB.Name = reader["PlayerB_Nick"].ToString();
                    match.PlayerA.Points = Convert.ToInt32(reader["PlayerA_Points"]);
                    match.PlayerB.Points = Convert.ToInt32(reader["PlayerB_Points"]);
                    match.PlayerA.Tag = Utils.IsNull(reader["PlayerA_Tag"].ToString(), 0);
                    match.PlayerB.Tag = Utils.IsNull(reader["PlayerB_Tag"].ToString(), 0);
                    match.Tag = Utils.IsNull(reader["Tag"].ToString(), 0);
                    match.WinnerId = Utils.IsNull(reader["Winner_Id"].ToString(), -1);
                    match.Winners_MatchLabel.Label = reader["Winners_MatchLabel"].ToString();
                    match.Loosers_MatchLabel.Label = reader["Loosers_MatchLabel"].ToString();
                    match.Title = reader["Title"].ToString();
                    aCompetition.Matches.Add(match.Id, match);
                    InitHasMatchesForPlayer(aCompetition, match.PlayerA.Id);
                    InitHasMatchesForPlayer(aCompetition, match.PlayerB.Id);
                }
                reader.Close();

                aCompetition.InitializeMatches();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        private void InitHasMatchesForPlayer(Competition aCompetition, int playerId)
        {
            if (playerId > 0)
            {
                if (aCompetition.Players.ContainsKey(playerId))
                    aCompetition.Players[playerId].HasMatches = true;
            }
        }
        #endregion

        #region Match Functions
        public bool CreateMatch(int competitionId, MatchInfo match)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql_format = @"insert into Matches
                                    (CompetitionId, MatchLabel, PlayerA_Id, PlayerB_Id, PlayerA_Points, PlayerA_Tag,
                                    PlayerB_Points, PlayerB_Tag,
                                    Winner_Id, Tag, Loosers_MatchLabel, Winners_MatchLabel, Title)
		                    values ({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, '{10}','{11}','{12}')";

                string sql = String.Format(sql_format, competitionId /*0*/, match.Label /*1*/,
                    match.PlayerA.Id /*2*/, match.PlayerB.Id /*3*/,
                    match.PlayerA.Points /*4*/, match.PlayerA.Tag /*5*/,
                    match.PlayerB.Points /*6*/, match.PlayerB.Tag /*7*/,
                    match.WinnerId /*8*/, match.Tag /*9*/,
                    match.Loosers_MatchLabel.Label /*10*/, match.Winners_MatchLabel.Label/*11*/, match.Title/*12*/);
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

                command = new SQLiteCommand("select MAX(id) as Id from Matches", connection);
                command.CommandType = System.Data.CommandType.Text;
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    match.Id = Convert.ToInt32(reader["Id"]);
                }
                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteMatch(int match_id)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(String.Format(@"DELETE FROM Matches WHERE [id] = {0}", match_id), connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool DeleteMatch(MatchInfo match)
        {
            return DeleteMatch(match.Id);
        }
        public bool WriteMatch(MatchInfo match)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(@"UPDATE Matches  SET
	                    PlayerA_Id = @playerA_id,
	                    PlayerB_Id = @playerB_id,
	                    PlayerA_Points = @playerA_points,
                        PlayerA_Tag = @playerA_Tag,
	                    PlayerB_Points = @playerB_points,
                        PlayerB_Tag = @playerB_Tag,
	                    Winner_Id = @winner_id,
                        Winners_MatchLabel = @winners_label,
                        Loosers_MatchLabel = @loosers_label,
                        Tag = @tag,
                        Title = @title
	                    WHERE [id] = @id", connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@id", match.Id));
                command.Parameters.Add(new SQLiteParameter("@playerA_id", match.PlayerA.Id));
                command.Parameters.Add(new SQLiteParameter("@playerB_id", match.PlayerB.Id));
                command.Parameters.Add(new SQLiteParameter("@playerA_points", match.PlayerA.Points));
                command.Parameters.Add(new SQLiteParameter("@playerA_Tag", match.PlayerA.Tag));
                command.Parameters.Add(new SQLiteParameter("@playerB_points", match.PlayerB.Points));
                command.Parameters.Add(new SQLiteParameter("@playerB_Tag", match.PlayerB.Tag));
                command.Parameters.Add(new SQLiteParameter("@winners_label", match.Winners_MatchLabel.Label));
                command.Parameters.Add(new SQLiteParameter("@loosers_label", match.Loosers_MatchLabel.Label));
                command.Parameters.Add(new SQLiteParameter("@tag", match.Tag));
                command.Parameters.Add(new SQLiteParameter("@title", match.Title));
                command.Parameters.Add(new SQLiteParameter("@winner_id", match.WinnerId));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool WriteMatch(MatchInfo match, int Depth)
        {
            WriteMatch(match);
            if (Depth > 0)
            {
                if (match.Looser_Match != null)
                    WriteMatch(match.Looser_Match, Depth - 1);
                if (match.Winner_Match != null)
                    WriteMatch(match.Winner_Match, Depth - 1);
            }
            return true;
        }
        #endregion

        #region Player Functions
        public bool TryToDeletePlayer(int playerId)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql = String.Format("SELECT PlayerId FROM CompetitionPlayers where PlayerId = {0}", playerId);
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();

                    return false;
                }
                reader.Close();

                sql = String.Format("DELETE FROM StartRatingList WHERE playerId = {0}; DELETE FROM Players WHERE Id = {0};", playerId);
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool PlayerInfoSave(TA.Corel.PlayerInfo info)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql = "";
                if (info.Id == -1)
                {
                    sql = @"insert into Players (Identifier, FirstName, PatronymicName, LastName, NickName, EMail, Phone, Country, City)
                    		values (@Identifier, @FirstName, @PatronymicName, @LastName, @NickName, @EMail, @Phone, @Country, @City)";
                }
                else
                {
                    sql = @"update Players  set
			                Identifier =@Identifier,
			                FirstName = @FirstName,
			                PatronymicName = @PatronymicName,
			                LastName = @LastName,
			                NickName = @NickName,
			                EMail = @EMail,
			                Phone = @Phone,
			                Country = @Country,
			                City = @City
		                    where [id] = @id";
                }
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                if (info.Id == -1)
                {
                    if(info.Identifier == Guid.Empty)
                        info.Identifier = Guid.NewGuid();
                }
                else
                {
                    command.Parameters.Add(new SQLiteParameter("@id", info.Id));
                }

                command.Parameters.Add(new SQLiteParameter("@Identifier", info.Identifier.ToString()));
                command.Parameters.Add(new SQLiteParameter("@FirstName", info.FirstName));
                command.Parameters.Add(new SQLiteParameter("@PatronymicName", info.PatronymicName));
                command.Parameters.Add(new SQLiteParameter("@LastName", info.LastName));
                command.Parameters.Add(new SQLiteParameter("@NickName", info.NickName));
                command.Parameters.Add(new SQLiteParameter("@EMail", info.EMail));
                command.Parameters.Add(new SQLiteParameter("@Phone", info.Phone));
                command.Parameters.Add(new SQLiteParameter("@Country", info.Country));
                command.Parameters.Add(new SQLiteParameter("@City", info.City));
                command.ExecuteNonQuery();
                if (info.Id == -1)
                {
                    command = new SQLiteCommand("select MAX(id) as Id from Players", connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        info.Id = Convert.ToInt32(reader["Id"]);
                    reader.Close();

                    sql = @"insert into StartRatingList(GameType, PlayerId, RatingStart)
		                    select Id, @id, 1500 from GameTypes";
                    command = new SQLiteCommand(sql, connection);
                    command.Parameters.Add(new SQLiteParameter("@id", info.Id));
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        public bool ReadPlayerList(TA.Corel.PlayerList list)
        {
            return ReadPlayerList(0, list);
        }
        public bool ReadPlayerList(int gameType, TA.Corel.PlayerList list)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql = String.Format(@"select * from Players
                                where Id in (select PlayerId from StartRatingList where GameType = {0} and IsActive = 1)
                                order by LastName, FirstName", gameType);
                if (gameType == 0)
                    sql = "select * from Players order by LastName, FirstName";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                Globals.Countries.Clear();
                list.Clear();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PlayerInfo info = new PlayerInfo();
                    info.Id = Convert.ToInt32(reader["Id"]);
                    info.Identifier = new Guid(reader["Identifier"].ToString());
                    info.FirstName = reader["FirstName"].ToString();
                    info.PatronymicName = reader["PatronymicName"].ToString();
                    info.LastName = reader["LastName"].ToString();
                    info.NickName = reader["NickName"].ToString();
                    info.EMail = reader["EMail"].ToString();
                    info.Phone = (reader["Phone"]).ToString();
                    info.Country = (reader["Country"]).ToString();
                    if (info.Country != "" && !Globals.Countries.Contains(info.Country))
                    {
                        Globals.Countries.Add(info.Country);
                    }
                    info.City = reader["City"].ToString();
                    list.Add(info.Identifier, info);
                }
                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        #endregion

        #region Competition Players functions
        public bool CompetitionPlayerInfoSave(TA.Corel.CompetitionPlayerInfo info)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand("select 1 from CompetitionPlayers where CompetitionId  = @competitionId and PlayerId = @playerId", connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@CompetitionId", info.CompetitionId));
                command.Parameters.Add(new SQLiteParameter("@PlayerId", info.Id));
                if (!command.ExecuteReader().Read())
                {
                    command = new SQLiteCommand(@"insert into CompetitionPlayers (CompetitionId, PlayerId, Rating, SeedNo, StartPoints, RebuyPoints)
		                            values (@CompetitionId, @PlayerId, @rating, @SeedNo, @StartPoints, @RebuyPoints);", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.Add(new SQLiteParameter("@CompetitionId", info.CompetitionId));
                    command.Parameters.Add(new SQLiteParameter("@PlayerId", info.Id));
                    command.Parameters.Add(new SQLiteParameter("@SeedNo", info.SeedNo));
                    command.Parameters.Add(new SQLiteParameter("@rating", info.RatingBeforeCompetition));
                    command.Parameters.Add(new SQLiteParameter("@StartPoints", info.StartPoints));
                    command.Parameters.Add(new SQLiteParameter("@RebuyPoints", info.RebuyPoints));

                    command.ExecuteNonQuery();
                }
                else
                {
                    command = new SQLiteCommand(@"update CompetitionPlayers  set
			                            SeedNo = @seedNo,
			                            Rating = @rating,
                                        StartPoints = @StartPoints,
                                        RebuyPoints = @RebuyPoints
		                            where CompetitionId  = @competitionId and PlayerId = @playerId", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.Add(new SQLiteParameter("@CompetitionId", info.CompetitionId));
                    command.Parameters.Add(new SQLiteParameter("@PlayerId", info.Id));
                    command.Parameters.Add(new SQLiteParameter("@SeedNo", info.SeedNo));
                    command.Parameters.Add(new SQLiteParameter("@rating", info.RatingBeforeCompetition));
                    command.Parameters.Add(new SQLiteParameter("@StartPoints", info.StartPoints));
                    command.Parameters.Add(new SQLiteParameter("@RebuyPoints", info.RebuyPoints));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool CompetitionPlayerInfoDelete(int competitionId, int playerId)
        {
            string sql = @"delete from CompetitionPlayers  where CompetitionId  = @competitionId and PlayerId = @playerId";
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@CompetitionId", competitionId));
                command.Parameters.Add(new SQLiteParameter("@PlayerId", playerId));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        public bool SetCompetitionPlayerPlace(int aCompetitionId, int aPlayerId, string place)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(@"update CompetitionPlayers  set
	                Place = @player_place
	                where CompetitionId = @competition_id and PlayerId = @player_id", connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@competition_id", aCompetitionId));
                command.Parameters.Add(new SQLiteParameter("@player_id", aPlayerId));
                command.Parameters.Add(new SQLiteParameter("@player_place", place));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        #endregion

        #region Other functions
        public bool ReadTypeOfSportList(TA.Corel.TypeOfSportList list)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand("select * from GameTypes", connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                list.Clear();
                SQLiteDataReader reader = (SQLiteDataReader)command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = Convert.ToString(reader["Name"]);
                    list.Add(id, new TypeOfSport(id, name));
                }
                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool SaveTypeOfSport(TypeOfSport sport)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql_select = String.Format("SELECT * FROM GameTypes WHERE Id = {0}", sport.Id);
                string sql_insert = String.Format("INSERT INTO GameTypes (Id, Name) VALUES({0},'{1}'); INSERT INTO StartRatingList (GameType, PlayerId, RatingStart, IsActive) select {0}, pl.Id, 1500, 1 from Players pl;", sport.Id, sport.Name);
                string sql_update = String.Format("UPDATE GameTypes SET Name ='{1}' WHERE Id = {0}", sport.Id, sport.Name);
                SQLiteCommand command = new SQLiteCommand(sql_select, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = (SQLiteDataReader)command.ExecuteReader();
                string sql_to_exec = sql_insert;
                if(reader.Read())
                {
                    sql_to_exec = sql_update;
                }
                reader.Close();
                command = new SQLiteCommand(sql_to_exec, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteTypeOfSport(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql_check = "SELECT * FROM Competitions WHERE GameType = " + id.ToString();
                string sql_delete = String.Format("DELETE FROM StartRatingList WHERE GameType = {0}; DELETE FROM GameTypes WHERE Id = {0}", id);
                SQLiteCommand command = new SQLiteCommand(sql_check, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = (SQLiteDataReader)command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();

                    return false;
                }
                reader.Close();
                command = new SQLiteCommand(sql_delete, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        public bool ExecuteSQL(string sqlCode)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand command = new SQLiteCommand(sqlCode, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Rating system DB functions
        public TA.Corel.PlayerRatingInfo GetPlayerBeginRating(int gameType, int playerId)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql = String.Format("select RatingStart, IsActive from StartRatingList where GameType = {0} and PlayerId = {1}", gameType, playerId);
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                PlayerRatingInfo info = new PlayerRatingInfo();
                info.IsActive = false;
                info.RatingBegin = 1500;
                while (reader.Read())
                {
                    info.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    info.RatingBegin = Convert.ToInt32(reader["RatingStart"]);
                }
                reader.Close();

                return info;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool PlayerBeginRatingUpdate(TA.Corel.PlayerRatingInfo info)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                SQLiteCommand select_command = new SQLiteCommand(@"select * from StartRatingList where GameType = @gametype and PlayerId = @playerId", connection);
                SQLiteCommand insert_command = new SQLiteCommand(@"INSERT INTO StartRatingList (GameType, PlayerId, RatingStart, IsActive)
                                    VALUES(@gametype, @playerId, @ratingbegin, @is_active)");
                SQLiteCommand update_command = new SQLiteCommand(@"update StartRatingList set
	                                RatingStart = @ratingbegin, IsActive = @is_active
                                    where GameType = @gametype and PlayerId = @playerId", connection);
                connection.Open();
                select_command.Parameters.Add(new SQLiteParameter("@gametype", info.GameType));
                select_command.Parameters.Add(new SQLiteParameter("@PlayerId", info.PlayerId));
                SQLiteDataReader reader = select_command.ExecuteReader();
                SQLiteCommand command = insert_command;
                if (reader.Read()) {
                    command = update_command;
                }
                reader.Close();

                command.CommandType = System.Data.CommandType.Text;

                command.Parameters.Add(new SQLiteParameter("@gametype", info.GameType));
                command.Parameters.Add(new SQLiteParameter("@PlayerId", info.PlayerId));
                command.Parameters.Add(new SQLiteParameter("@ratingbegin", info.RatingBegin));
                command.Parameters.Add(new SQLiteParameter("@is_active", info.IsActive));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        #if FEDITION || STANDARD || FEDITION_PLUS || STANDARD_PLUS
            public bool ReadPlayerRatingList(int GameTypeId, TA.RatingSystem.PlayersRatingList list)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string sql = "select * from vStartRatingList where GameType = {0} order by GameType, LastName, Firstname, PatronymicName";
                SQLiteCommand command = new SQLiteCommand(String.Format(sql, GameTypeId), connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                list.Clear();
                while (reader.Read())
                {
                    TA.RatingSystem.PlayerRating player = new TA.RatingSystem.PlayerRating();
                    player.Id = Convert.ToInt32(reader["PlayerId"]);
                    player.Name = reader["NickName"].ToString();
                    player.RatingBegin = Convert.ToInt32(reader["RatingStart"]);
                    player.Rating = player.RatingBegin;
                    player.Guid = new Guid(reader["Identifier"].ToString());
                    player.LName = reader["LastName"].ToString();
                    player.FName = reader["FirstName"].ToString();
                    player.PName = reader["PatronymicName"].ToString();
                    player.EMail = reader["EMail"].ToString();
                    player.Phone = reader["Phone"].ToString();
                    player.Country = reader["Country"].ToString();
                    player.City = reader["City"].ToString();
                    list.Add(player);
                }
                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
            public bool ReadRatingCompetitionList(int GameTypeId, TA.RatingSystem.CompetitionsList Competitions)
        {
            return ReadRatingCompetitionList(GameTypeId, Competitions, DateTime.Now);
        }
            public bool ReadRatingCompetitionList(int GameTypeId, TA.RatingSystem.CompetitionsList Competitions, DateTime date)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                // Загружаем список турниров
                SQLiteCommand command = new SQLiteCommand("select * from vCompetitions where ChangesRating = 1 and GameType = @game_type and Status = 2 and DateBegin < @date order by DateBegin", connection);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Add(new SQLiteParameter("@date", date));
                command.Parameters.Add(new SQLiteParameter("@game_type", GameTypeId));
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                Competitions.Clear();
                while (reader.Read())
                {
                    TA.RatingSystem.CompetitionInfo comp = new TA.RatingSystem.CompetitionInfo();
                    comp.Date = Convert.ToDateTime(reader["DateBegin"]);
                    comp.Id = Convert.ToInt32(reader["Id"]);
                    comp.IsRating = Convert.ToBoolean(reader["ChangesRating"]);
                    Competitions.Add(comp);
                }
                reader.Close();
                // Для каждого турнира загружаем результаты
                string sql = "";
                foreach (TA.RatingSystem.CompetitionInfo comp in Competitions)
                {
                    sql = "select * from vCompetitionResults where CompetitionId = {0} order by PlayerId";
                    command = new SQLiteCommand(String.Format(sql, comp.Id), connection);
                    reader = command.ExecuteReader();
                    comp.Results.Clear();
                    while (reader.Read())
                    {
                        int playerId = Convert.ToInt32(reader["PlayerId"]);
                        double points = Convert.ToDouble(reader["Result"]);
                        int oppId = Convert.ToInt32(reader["OppId"]);
                        comp.Results.Add(playerId, oppId, points);
                    }
                    reader.Close();
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        #endif
        #endregion

        #region ExImInterface Members

        public XmlDocument PlayersListToXml()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                string players_sql = @"SELECT Identifier, FirstName, LastName, PatronymicName, NickName, EMail, Phone, Country, City, GameType, RatingStart, IsActive
                FROM players p LEFT OUTER JOIN StartRatingList srl ON p.Id=srl.PlayerId
                    order by LastName, FirstName, NickName, Identifier";
                SQLiteCommand command = new SQLiteCommand(players_sql, connection);
                command.CommandType = System.Data.CommandType.Text;

                XmlDocument doc = new XmlDocument();
                // Аттрибуты документа
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Encoding.UTF8.WebName, String.Empty));
                //doc.AppendChild(doc.CreateProcessingInstruction("xml-stylesheet", String.Format("type='text/xsl' href='{0}'", xsl_filename)));
                // Создаем корневой узел
                XmlNode RootNode = doc.CreateElement("PlayersList");
                RootNode.Attributes.Append(doc.CreateAttribute("Date")).Value = DateTime.Today.ToString("dd.MM.yyyy");
                doc.AppendChild(RootNode);
                // Узел типов игры
                XmlNode gameTypesNode = doc.CreateElement("GameTypes");
                TypeOfSportList gameTypes = new TypeOfSportList();
                ReadTypeOfSportList(gameTypes);
                foreach (TypeOfSport sportType in gameTypes.Values)
                {
                    XmlNode sportTypeNode = doc.CreateElement("GameType");
                    sportTypeNode.Attributes.Append(doc.CreateAttribute("Id")).Value = sportType.Id.ToString();
                    sportTypeNode.Attributes.Append(doc.CreateAttribute("Name")).Value = sportType.Name;
                    gameTypesNode.AppendChild(sportTypeNode);
                }
                RootNode.AppendChild(gameTypesNode);

                XmlNode playersNode = doc.CreateElement("Players");
                connection.Open();
                SQLiteDataReader reader = (SQLiteDataReader)command.ExecuteReader();
                string guid = "";
                string new_guid = "";
                XmlNode playerNode = null;
                while (reader.Read())
                {
                    new_guid = Convert.ToString(reader["Identifier"]);
                    if(new_guid != guid)
                    {
                        guid = new_guid;
                        playerNode = doc.CreateElement("Player");
                        playersNode.AppendChild(playerNode);
                        playerNode.Attributes.Append(doc.CreateAttribute("Guid")).Value = guid;
                        playerNode.Attributes.Append(doc.CreateAttribute("LName")).Value = Convert.ToString(reader["LastName"]);
                        playerNode.Attributes.Append(doc.CreateAttribute("FName")).Value = Convert.ToString(reader["FirstName"]);
                        playerNode.Attributes.Append(doc.CreateAttribute("PName")).Value = Convert.ToString(reader["PatronymicName"]);
                        playerNode.Attributes.Append(doc.CreateAttribute("Nick")).Value = Convert.ToString(reader["NickName"]);
                        playerNode.Attributes.Append(doc.CreateAttribute("EMail")).Value = Convert.ToString(reader["EMail"]);
                        playerNode.Attributes.Append(doc.CreateAttribute("Phone")).Value = Convert.ToString(reader["Phone"]);
                        playerNode.Attributes.Append(doc.CreateAttribute("Country")).Value = Convert.ToString(reader["Country"]);
                        playerNode.Attributes.Append(doc.CreateAttribute("City")).Value = Convert.ToString(reader["City"]);
                    }
                    XmlNode startRatingNode = doc.CreateElement("RatingBegin");
                    startRatingNode.Attributes.Append(doc.CreateAttribute("GameType")).Value = Convert.ToString(reader["GameType"]);
                    startRatingNode.Attributes.Append(doc.CreateAttribute("RatingStart")).Value = Convert.ToString(reader["RatingStart"]);
                    startRatingNode.Attributes.Append(doc.CreateAttribute("IsActive")).Value = Convert.ToString(reader["IsActive"]);
                    playerNode.AppendChild(startRatingNode);
                }
                reader.Close();

                RootNode.AppendChild(playersNode);
                return doc;
            }
            catch (Exception ex)
            {
                ErrorView.Show(ex);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool PlayersListFromXml(string xml_string)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
