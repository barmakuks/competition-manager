using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TA.Corel;
using TA.DB.Manager;
using System.Threading;
using TA.ExIm;

namespace TA.Main
{
    public partial class fMain : Form , Localizator.ILocalizableForm
    {
        private static string UrlToDownload = @"http://www.competition-manager.com";

        public void RefreshGrid() 
        {
            DatabaseManager.CurrentDb.ReadTournamentList(Globals.Tournaments);            
            UpdateTournamentsGrid();
        }
        public void UpdateTournamentsGrid() 
        {
            olvTournaments.Clear();            
            olvTournaments.AddRange(Globals.Tournaments.Values);
        }
        public fMain()
        {
            InitializeComponent();
            LocalizeComponents();
            Left = Screen.PrimaryScreen.Bounds.Left + 15;
            Width = Screen.PrimaryScreen.Bounds.Width - 30;
            Top = Screen.PrimaryScreen.Bounds.Top + 15;
            Height = Screen.PrimaryScreen.Bounds.Height - 60;
            olvTournaments.BackColor = WindowSkin.Palette.TextBackColor;
            toolTip.BackColor = WindowSkin.Palette.TextBackColor;
            toolTip.ForeColor = WindowSkin.Palette.ForeColor;
            if (EditionManager.Edition == EditionType.Mini) 
            {
                btnImport.Visible = false;
            }

            string DBT = ConfigurationManager.AppSettings["DatabaseType"];
            //DatabaseManager.CreateDb(ConfigurationManager.AppSettings["ConnectionString"]);
            DatabaseManager.CurrentDb.ReadTypeOfSportList(Globals.Games);
            LicenseManager.CheckRegistration();

            /*Competition.CompetitionDb.ConnectionString = TA.Corel.Database.ConnectionString;
            TA.RatingSystem.Database.ConnectionString = TA.Corel.Database.ConnectionString;*/
            RefreshGrid();
        }
        private void btnTournamentAdd_Click(object sender, EventArgs e)
        {
#if BETA
            if(olvTournaments.ObjectCount >= EditionManager.MaxTournamentCount)
            {
                WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("BETA_LIMIT_TOURNAMENTS"));
                return;
            }
#endif
            Tournament tournament = new Tournament();
            tournament.Info.DateBegin = DateTime.Now;
            tournament.Info.DateEnd = tournament.Info.DateBegin.AddDays(1);
            if (fTournamentInfo.Edit(tournament))
            {
                DatabaseManager.CurrentDb.TournamentInfoSave(tournament.Info);
                RefreshGrid();
            }
        }

        private void btnTournamentEdit_Click(object sender, EventArgs e)
        {
            if (olvTournaments.SelectedObject == null)
                return;
            Tournament tournament = olvTournaments.SelectedObject as Tournament;
            if (fTournamentInfo.Edit(tournament)) 
            {
                UpdateTournamentsGrid();
            }
        }

        private void btnPlayersList_Click(object sender, EventArgs e)
        {
            fPlayersList.ShowPlayersList();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            fAbout.ShowAbout();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (olvTournaments.SelectedObject == null)
                return;
            if (WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("ASK_REMOVE_TOURNAMENT"), Localizator.Dictionary.GetString("REMOVE_TOURNAMENT"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseManager.CurrentDb.TournamentDelete((olvTournaments.SelectedObject as Tournament).Info.Id);
                DatabaseManager.CurrentDb.ReadTournamentList(Globals.Tournaments);
                UpdateTournamentsGrid();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void olvTournaments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnTournamentEdit_Click(sender, e);
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.toolTip.SetToolTip(this.btnExit, Localizator.Dictionary.GetString("EXIT"));
            this.toolTip.SetToolTip(this.btnAbout, Localizator.Dictionary.GetString("ABOUT"));
            this.toolTip.SetToolTip(this.btnDelete, Localizator.Dictionary.GetString("REMOVE_TOURNAMENT"));
            this.toolTip.SetToolTip(this.btnTournamentEdit, Localizator.Dictionary.GetString("OPEN_TOURNAMENT"));
            this.toolTip.SetToolTip(this.btnTournamentAdd, Localizator.Dictionary.GetString("CREATE_TOURNAMENT"));
            this.toolTip.SetToolTip(this.btnPlayerList, Localizator.Dictionary.GetString("PLAYER_LIST"));
            this.toolTip.SetToolTip(this.btnSettings, Localizator.Dictionary.GetString("SETTINGS"));
            this.toolTip.SetToolTip(this.btnExport, Localizator.Dictionary.GetString("EXPORT"));
            this.toolTip.SetToolTip(this.btnImport, Localizator.Dictionary.GetString("IMPORT")); 
            this.Text = Localizator.Dictionary.GetString("COMP_MAN");

            this.lblDownloadPrompt.Text = Localizator.Dictionary.GetString("NEW_VERSION_AVAILABLE");
            this.toolTip.SetToolTip(this.btnDownload, Localizator.Dictionary.GetString("DOWNLOAD_NEW"));

            this.olvTournaments.Columns[1].Text = Localizator.Dictionary.GetString("START_DATE");
            this.olvTournaments.Columns[2].Text = Localizator.Dictionary.GetString("FINISH_DATE");
            this.olvTournaments.Columns[3].Text = Localizator.Dictionary.GetString("TOURNAMENT_PLACE");
            this.olvTournaments.Columns[4].Text = Localizator.Dictionary.GetString("TOURNAMENT_TITLE");

        }

        #endregion

        private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (fSettings.Edit()) 
            {
                Localizator.Dictionary.CreateDictionary(Settings.Language);
                LocalizeComponents();
                Refresh();
            }
        }

        internal void ShowDownloadPanel()
        {
            if (pnlDownload.InvokeRequired)
            {
                this.Invoke(new Action(ShowDownloadPanel));
            }
            else 
            {
                pnlDownload.Visible = true;
            }
        }

        private void GoToDownload()
        {
            System.Diagnostics.Process.Start(UrlToDownload);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(delegate() { GoToDownload(); });
            t.Start();
            pnlDownload.Visible = false;
        }

        private void btnExIm_Click(object sender, EventArgs e)
        {
            ExImUtil.Export();            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (ExImUtil.Import()) 
            {
                DatabaseManager.CurrentDb.ReadTypeOfSportList(Globals.Games);
                RefreshGrid();
            }
        }
    }
}