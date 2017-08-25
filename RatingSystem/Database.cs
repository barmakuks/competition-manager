using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RSystem
{
    public class Database
    {
        public static string ConnectionString = "server=localhost;Trusted_Connection=true;database=BG_Tournaments;Connect Timeout=10000";
        public static string LastErrorString = "";
        public static bool ReadPlayerList(int GameTypeId, Players Players)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                string sql = "select PlayerId, rTrim(LastName + ' ' + Firstname + ' ' + PatronymicName) as [Name], RatingBegin from vPlayerRating where GameType = {0} order by GameType, LastName, Firstname, PatronymicName";
                SqlCommand command = new SqlCommand(String.Format(sql, GameTypeId), connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Players.Clear();
                while (reader.Read()) 
                {
                    Players.Add(Convert.ToInt32(reader["PlayerId"]), reader["Name"].ToString(), Convert.ToInt32(reader["RatingBegin"]));
                }
                LastErrorString = "";
                return true;
            }
            catch (Exception ex)
            {
                LastErrorString = ex.Message;
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool ReadCompetitionList(int GameTypeId, Competitions Competitions) 
        {
            return ReadCompetitionList(GameTypeId, Competitions, DateTime.Now);
        }
        public static bool ReadCompetitionList(int GameTypeId, Competitions Competitions, DateTime date)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                // Загружаем список турниров
                string sql = "set dateformat dmy; select * from vCompetitions where GameType = {0} and Status = 3 and DateBegin < '{1}' order by DateBegin";
                SqlCommand command = new SqlCommand(String.Format(sql, GameTypeId, date.ToString("dd.MM.yyyy")), connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Competitions.Clear();
                while (reader.Read())
                {
                    Competition comp = new Competition();
                    comp.Date = Convert.ToDateTime(reader["DateBegin"]);
                    comp.Id = Convert.ToInt32(reader["Id"]);
                    Competitions.Add(comp);
                }
                reader.Close();
                // Для каждого турнира загружаем результаты
                foreach (Competition comp in Competitions) 
                {
                    sql = "select * from vCompetitionResults where CompetitionId = {0} order by PlayerId";
                    command = new SqlCommand(String.Format(sql, comp.Id), connection);
                    reader = command.ExecuteReader();
                    comp.Results.Clear();
                    while (reader.Read())
                    {
                        int playerId = Convert.ToInt32(reader["PlayerId"]);
                        int points = Convert.ToInt32(reader["Points"]);
                        int oppCnt = Convert.ToInt32(reader["OppCount"]);
                        comp.Results.Add(playerId, points, oppCnt);
                    }
                    reader.Close();
                }
                LastErrorString = "";
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                LastErrorString = ex.Message;
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
