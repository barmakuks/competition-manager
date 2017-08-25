using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.DB.Manager;

namespace Updater
{
    public class DatabaseUpdater
    {
        private const int CURRENT_VERSION = 3;
        public static void TryUpdateDatabase() 
        {
            int dbVersion = DatabaseManager.CurrentDb.DatabaseVersion;
            if (dbVersion < CURRENT_VERSION) 
            {
                if (WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("DB_OUTDATED"), Localizator.Dictionary.GetString("UPDATE"), MessageBoxButtons.YesNo) == DialogResult.Yes) 
                {
                    string[] update_sql = GetSqlForUpdate(dbVersion);
                    if(SqlExecutor.ExecuteSql(update_sql))
                        DatabaseManager.CurrentDb.DatabaseVersion = CURRENT_VERSION;
                }
            }
        }
        private static string[] GetSqlForUpdate(int dbVersion) 
        {
            List<string> update_sql = new List<string>();
            
            #region Обновления до версии № 1
            if (dbVersion < 1) 
            {
                update_sql.Add(@"ALTER TABLE 'main'.'Matches' ADD COLUMN 'Title' VARCHAR(50);");
                update_sql.Add(@"DROP VIEW 'main'.'vMatches';");
                update_sql.Add(@"CREATE  VIEW 'main'.'vMatches' AS    
                                SELECT     m.Id, m.CompetitionId, m.MatchLabel, m.PlayerA_Id, m.PlayerB_Id, m.Winner_Id,  
                        		p1.NickName AS PlayerA_Nick, p2.NickName AS PlayerB_Nick,
                                m.Winners_MatchLabel, m.Loosers_MatchLabel, 
                                m.PlayerA_Points, m.PlayerB_Points, m.PlayerA_Tag, m.PlayerB_Tag,
                                m.Tag, m.Title
                                FROM Matches m LEFT OUTER JOIN
                                  Players p1 ON m.PlayerA_Id = p1.Id LEFT OUTER JOIN
                                  Players p2 ON m.PlayerB_Id = p2.Id");
            }
            #endregion
            #region Обновления до версии № 2
            if (dbVersion < 2)
            {
                #region Итоговые места Double Elimination
                //Итоговые места для Double Elimination (8 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 07-08'
                                WHERE CompetitionType = 1 and playerCount =8 and MatchLabel like '2.01.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-06'
                                WHERE CompetitionType = 1 and playerCount =8 and MatchLabel like '2.02.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 04'
                                WHERE CompetitionType = 1 and playerCount =8 and MatchLabel like '2.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03'
                                WHERE CompetitionType = 1 and playerCount =8 and MatchLabel like '2.04.%'");
                //Итоговые места для Double Elimination (16 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 13-16'
                                WHERE CompetitionType = 1 and playerCount =16 and MatchLabel like '2.01.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-12'
                                WHERE CompetitionType = 1 and playerCount =16 and MatchLabel like '2.02.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 07-08'
                                WHERE CompetitionType = 1 and playerCount =16 and MatchLabel like '2.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-06'
                                WHERE CompetitionType = 1 and playerCount =16 and MatchLabel like '2.04.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 04'
                                WHERE CompetitionType = 1 and playerCount =16 and MatchLabel like '2.05.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03'
                                WHERE CompetitionType = 1 and playerCount =16 and MatchLabel like '2.06.%'");
                //Итоговые места для Double Elimination (32 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 25-32'
                                WHERE CompetitionType = 1 and playerCount =32 and MatchLabel like '2.01.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-24'
                                WHERE CompetitionType = 1 and playerCount =32 and MatchLabel like '2.02.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 13-16'
                                WHERE CompetitionType = 1 and playerCount =32 and MatchLabel like '2.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-12'
                                WHERE CompetitionType = 1 and playerCount =32 and MatchLabel like '2.04.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 07-08'
                                WHERE CompetitionType = 1 and playerCount =32 and MatchLabel like '2.05.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-06'
                                WHERE CompetitionType = 1 and playerCount =32 and MatchLabel like '2.06.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 04'
                                WHERE CompetitionType = 1 and playerCount =32 and MatchLabel like '2.07.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03'
                                WHERE CompetitionType = 1 and playerCount =32 and MatchLabel like '2.08.%'");
                //Итоговые места для Double Elimination (64 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 49-64'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.01.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 33-48'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.02.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 25-32'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-24'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.04.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 13-16'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.05.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-12'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.06.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 07-08'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.07.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-06'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.08.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 04'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.09.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03'
                                WHERE CompetitionType = 1 and playerCount =64 and MatchLabel like '2.10.%'");
                //Итоговые места для Double Elimination (128 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 49-64'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 33-48'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.04.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 25-32'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.05.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-24'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.06.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 13-16'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.07.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-12'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.08.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 07-08'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.09.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-06'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.10.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 04'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.11.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03'
                                WHERE CompetitionType = 1 and playerCount =128 and MatchLabel like '2.12.%'");
                //Итоговые места для Double Elimination (256 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 49-64'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.05.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 33-48'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.06.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 25-32'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.07.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-24'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.08.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 13-16'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.09.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-12'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.10.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 07-08'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.11.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-06'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.12.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 04'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.13.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03'
                                WHERE CompetitionType = 1 and playerCount =256 and MatchLabel like '2.14.%'");

                //Итоговые места для Double Elimination (512 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 49-64'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.07.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 33-48'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.08.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 25-32'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.09.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-24'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.10.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 13-16'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.11.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-12'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.12.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 07-08'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.13.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-06'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.14.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 04'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.15.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03'
                                WHERE CompetitionType = 1 and playerCount =512 and MatchLabel like '2.16.%'");
                #endregion
                #region Итоговые места Олимпийка
                //Итоговые места для Олимпийка (8 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-08'
                                WHERE CompetitionType = 2 and playerCount =8 and MatchLabel like '1.01.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03-04'
                                WHERE CompetitionType = 2 and playerCount =8 and MatchLabel like '1.02.%'");
                //Итоговые места для Олимпийка (16 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-16'
                                WHERE CompetitionType = 2 and playerCount =16 and MatchLabel like '1.01.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-08'
                                WHERE CompetitionType = 2 and playerCount =16 and MatchLabel like '1.02.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03-04'
                                WHERE CompetitionType = 2 and playerCount =16 and MatchLabel like '1.03.%'");
                //Итоговые места для Олимпийка (32 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-32'
                                WHERE CompetitionType = 2 and playerCount =32 and MatchLabel like '1.01.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-16'
                                WHERE CompetitionType = 2 and playerCount =32 and MatchLabel like '1.02.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-08'
                                WHERE CompetitionType = 2 and playerCount =32 and MatchLabel like '1.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03-04'
                                WHERE CompetitionType = 2 and playerCount =32 and MatchLabel like '1.04.%'");
                //Итоговые места для Олимпийка (64 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 33-64'
                                WHERE CompetitionType = 2 and playerCount =64 and MatchLabel like '1.01.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-32'
                                WHERE CompetitionType = 2 and playerCount =64 and MatchLabel like '1.02.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-16'
                                WHERE CompetitionType = 2 and playerCount =64 and MatchLabel like '1.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-08'
                                WHERE CompetitionType = 2 and playerCount =64 and MatchLabel like '1.04.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03-04'
                                WHERE CompetitionType = 2 and playerCount =64 and MatchLabel like '1.05.%'");
                //Итоговые места для Олимпийка (128 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 33-64'
                                WHERE CompetitionType = 2 and playerCount =128 and MatchLabel like '1.02.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-32'
                                WHERE CompetitionType = 2 and playerCount =128 and MatchLabel like '1.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-16'
                                WHERE CompetitionType = 2 and playerCount =128 and MatchLabel like '1.04.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-08'
                                WHERE CompetitionType = 2 and playerCount =128 and MatchLabel like '1.05.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03-04'
                                WHERE CompetitionType = 2 and playerCount =128 and MatchLabel like '1.06.%'");
                //Итоговые места для Олимпийка (256 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 33-64'
                                WHERE CompetitionType = 2 and playerCount =256 and MatchLabel like '1.03.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-32'
                                WHERE CompetitionType = 2 and playerCount =256 and MatchLabel like '1.04.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-16'
                                WHERE CompetitionType = 2 and playerCount =256 and MatchLabel like '1.05.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-08'
                                WHERE CompetitionType = 2 and playerCount =256 and MatchLabel like '1.06.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03-04'
                                WHERE CompetitionType = 2 and playerCount =256 and MatchLabel like '1.07.%'");
                //Итоговые места для Олимпийка (512 игроков)
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 33-64'
                                WHERE CompetitionType = 2 and playerCount =512 and MatchLabel like '1.04.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 17-32'
                                WHERE CompetitionType = 2 and playerCount =512  and MatchLabel like '1.05.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 09-16'
                                WHERE CompetitionType = 2 and playerCount =512 and MatchLabel like '1.06.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 05-08'
                                WHERE CompetitionType = 2 and playerCount =512 and MatchLabel like '1.07.%'");
                update_sql.Add(@"UPDATE  SeedTemplate SET Loosers_MatchLabel = 'PLACE 03-04'
                                WHERE CompetitionType = 2 and playerCount =512 and MatchLabel like '1.08.%'");

                #endregion
            }
            #endregion
            #region Обновления до версии № 3
            if (dbVersion < 3)
            {
                update_sql.Add(@"DROP VIEW 'main'.'vMatches';");
                update_sql.Add(@"CREATE  VIEW 'main'.'vMatches' AS    
                                SELECT     m.Id, m.CompetitionId, m.MatchLabel, m.PlayerA_Id, m.PlayerB_Id, m.Winner_Id,  
                        		p1.NickName AS PlayerA_Nick, p2.NickName AS PlayerB_Nick,
                                m.Winners_MatchLabel, m.Loosers_MatchLabel, 
                                m.PlayerA_Points, m.PlayerB_Points, m.PlayerA_Tag, m.PlayerB_Tag,
                                m.Tag, m.Title, p1.Identifier as PlayerA_Guid, p2.Identifier as PlayerB_Guid
                                FROM Matches m LEFT OUTER JOIN
                                  Players p1 ON m.PlayerA_Id = p1.Id LEFT OUTER JOIN
                                  Players p2 ON m.PlayerB_Id = p2.Id");                

            }
            #endregion
            return update_sql.ToArray();
        }
    }
}
