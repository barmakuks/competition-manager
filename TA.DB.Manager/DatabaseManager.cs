using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.DB;
#if MSSQL
using TA.DB.MsSql;
#endif
using TA.DB.SQLite;
using System.IO;

namespace TA.DB.Manager
{
    public class DatabaseManager
    {
        private static DatabaseInterface FDatabase = null;
        public static DatabaseInterface CurrentDb 
        {
            get {
                return FDatabase;
            }
            set { 
            }
        }
        public static void CreateCurrentDb(string aConnetionString) 
        {
        #if DEBUG
            string fileName = "data.cmdb";
        #elif FEDITION
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Competition Manager\data.cmdb");        
        #elif STANDARD
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Competition Manager\data_std.cmdb");        
        #endif
            aConnetionString = "Data Source = " + fileName + ";";
            FDatabase = CreateDb(aConnetionString);
        }
        public static DatabaseInterface CreateDb(string aConnetionString) 
        {
        #if MSSQL
            reutrn new MsSqlDatabase(aConnetionString);
        #endif
        #if SQLITE
            return new SQLiteDatabase(aConnetionString);
        #endif

        }
    }
}
