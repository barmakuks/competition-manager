#define TRIAL_EDITION
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using TA.DB.Manager;
using System.Diagnostics;

namespace TA.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
#if FEDITION
                WindowSkin.Palette.CurrentSkin = WindowSkin.WindowsSkins.Black;
#endif
#if STANDARD
                WindowSkin.Palette.CurrentSkin = WindowSkin.WindowsSkins.MiddleBlue;
#endif
#if DEBUG
                WindowSkin.Palette.CurrentSkin = WindowSkin.WindowsSkins.Green;
#endif
                string DBT = ConfigurationManager.AppSettings["DatabaseType"];
                DatabaseManager.CreateCurrentDb(ConfigurationManager.AppSettings["ConnectionString"]);

                string lang = Settings.Language;
                Localizator.Dictionary.CreateDictionary(lang);
                WindowSkin.MessageBox.STR_ABORT = Localizator.Dictionary.GetString("ABORT");
                WindowSkin.MessageBox.STR_CANCEL = Localizator.Dictionary.GetString("CANCEL");
                WindowSkin.MessageBox.STR_IGNORE = Localizator.Dictionary.GetString("IGNORE");
                WindowSkin.MessageBox.STR_NO = Localizator.Dictionary.GetString("NO");
                WindowSkin.MessageBox.STR_OK = Localizator.Dictionary.GetString("OK");
                WindowSkin.MessageBox.STR_RETRY = Localizator.Dictionary.GetString("RETRY");
                WindowSkin.MessageBox.STR_YES = Localizator.Dictionary.GetString("YES");

                WindowSkin.MessageBox.STR_CAPTION = Localizator.Dictionary.GetString("MESSAGE");

                Updater.DatabaseUpdater.TryUpdateDatabase();
                fMain mainForm = new fMain();
                CheckUpdate.CheckLastVersion(Utils.Utils.GetLastBuildDate(), mainForm);
                //CheckUpdate.CheckLastVersion(new DateTime(2009,12,12), mainForm);
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                ErrorViewer.ErrorView.Show(ex);
            }

        }
    }
}