using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Utils;

namespace TA.Main
{
    class Settings
    {
        public static string AppDataFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\reginfo";
        /*public static Utils.IniFile IniFile
        {
            get
            {
                return new IniFile(AppDataFilePath);
            }
        }*/
        /// <summary>
        /// Текущий язык интерфейса
        /// </summary>
        public static string Language
        {
            get
            {                
                string str = TA.DB.Manager.DatabaseManager.CurrentDb.GetParamValue(0, "LANG");
                if(str == "")
                    str = "EN";
                return str;
            }
            set
            {
                TA.DB.Manager.DatabaseManager.CurrentDb.SetParamValue(0, "LANG", value);
            }
        }
    }
}
