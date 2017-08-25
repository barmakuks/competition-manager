using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.DB.Manager;
using TA.Competitions;


namespace TA.Main
{
    public partial class fTournamentInfo : Form, Localizator.ILocalizableForm
    {
        private enum EditPanelState { View, Edit }
        private Tournament FTournament;
        //private CompetitionList FCompetitionList = new CompetitionList();
        private EditPanelState TournamentPanelState 
        {
            get {
                if (txtName.Enabled)
                    return EditPanelState.Edit;
                else
                    return EditPanelState.View;
            }
            set {
                switch (value)
                { 
                    case EditPanelState.View:
                        txtDateBegin.Enabled = false;
                        txtDateEnd.Enabled = false;
                        txtName.Enabled = false;
                        txtPlace.Enabled = false;
                        btnSave.Text = Localizator.Dictionary.GetString("CHANGE");
                        btnCompetitionAdd.Enabled = true;
                        btnCompetitionEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        lvCompetitions.Enabled = true;
                        break;
                    case EditPanelState.Edit:
                        txtDateBegin.Enabled = true;
                        txtDateEnd.Enabled = true;
                        txtName.Enabled = true;
                        txtPlace.Enabled = true;
                        btnSave.Text = Localizator.Dictionary.GetString("APPLY");
                        btnCompetitionAdd.Enabled = false;
                        btnCompetitionEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        lvCompetitions.Enabled = false;
                        break;
                }
            }
        }
        private void UpdateCompetitionGrid() 
        {
            DatabaseManager.CurrentDb.ReadCompetitionList(FTournament);
            lvCompetitions.Clear();            
            lvCompetitions.AddRange(FTournament.Competitions.Values);
        }
        public fTournamentInfo()
        {
            InitializeComponent();
            LocalizeComponents();
            lvCompetitions.BackColor = WindowSkin.Palette.TextBackColor;
            txtDateBegin.CalendarMonthBackground = WindowSkin.Palette.TextBackColor;
            txtDateBegin.CalendarTitleBackColor = WindowSkin.Palette.ForeColor;
            txtDateBegin.CalendarTitleForeColor = WindowSkin.Palette.ActiveCaptionColor;
            txtDateBegin.CalendarTrailingForeColor = WindowSkin.Palette.ActiveCaptionColor;
            txtDateEnd.CalendarMonthBackground = WindowSkin.Palette.TextBackColor;
            txtDateEnd.CalendarTitleBackColor = WindowSkin.Palette.ForeColor;
            txtDateEnd.CalendarTitleForeColor = WindowSkin.Palette.ActiveCaptionColor;
            txtDateEnd.CalendarTrailingForeColor = WindowSkin.Palette.ActiveCaptionColor;

#if FEDITION_PLUS || STANDARD_PLUS
            btnExport.Visible = true;
#else
            btnExport.Visible = false;
#endif

        }

        public static bool Edit(Tournament tournament) 
        {
            fTournamentInfo form = new fTournamentInfo();
            form.SetTournamentInfo(tournament);
            if (tournament.Info.Id == -1)
                form.TournamentPanelState = EditPanelState.Edit;
            else
                form.TournamentPanelState = EditPanelState.View;
            return form.ShowDialog() == DialogResult.OK;
        }

        private void SetTournamentInfo(Tournament info)
        {
            FTournament = info;
            txtDateBegin.Value = FTournament.Info.DateBegin;
            txtDateEnd.Value = FTournament.Info.DateEnd;
            txtName.Text = FTournament.Info.Name;
            txtPlace.Text = FTournament.Info.Place;
            UpdateCompetitionGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
                DialogResult = DialogResult.OK;
            else 
            {
                if (FTournament.Info.Id == -1)
                    DialogResult = DialogResult.Cancel;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TournamentPanelState == EditPanelState.View)
                TournamentPanelState = EditPanelState.Edit;
            else 
            {
                if (GetTournamentInfo()) 
                {
                    DatabaseManager.CurrentDb.TournamentInfoSave(FTournament.Info);
                    TournamentPanelState = EditPanelState.View;
                }
            }
        }

        private bool GetTournamentInfo()
        {
            if (txtName.Text == "")
                return false;
            FTournament.Info.DateBegin = txtDateBegin.Value;
            FTournament.Info.DateEnd = txtDateEnd.Value;
            FTournament.Info.Name = txtName.Text;
            FTournament.Info.Place = txtPlace.Text;
            return true;
        }
        private void btnCompetitionAdd_Click(object sender, EventArgs e)
        {
#if BETA
            if (FTournament.Competitions.Count >= EditionManager.MaxTournamentCount)
            {
                WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("BETA_LIMIT_COMPETITIONS"));
                return;
            }
#endif

            CompetitionInfo info = new CompetitionInfo();
            info.TournamentId = FTournament.Info.Id;
            info.Date = FTournament.Info.DateBegin;
            if (fCompetitionInfo.Edit(info)) 
            {
                Competition competition = CompetitionFactory.CreateCompetition(info);
                DatabaseManager.CurrentDb.CompetitionInfoSave(competition.Info);
                FTournament.Competitions.Add(competition.Info.Id, competition);
                fCompetition.Edit(competition);
            }
            UpdateCompetitionGrid();
        }
        private void btnCompetitionEdit_Click(object sender, EventArgs e)
        {
            if (lvCompetitions.SelectedObject == null)
                return;
            Competition comp = FTournament.Competitions[(lvCompetitions.SelectedObject as Competition).Info.Id];
            if (comp.Info.Date == DateTime.MinValue)
                comp.Info.Date = FTournament.Info.DateBegin;
            if (fCompetition.Edit(comp))
            {
                UpdateCompetitionGrid();                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCompetitions.SelectedObject == null)
                return;
            int id = (lvCompetitions.SelectedObject as Competition).Info.Id;
            if (WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("ASK_REMOVE_COMPETITION"), Localizator.Dictionary.GetString("COMPETITION_REMOVE"), MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                DatabaseManager.CurrentDb.CompetitionDelete(id);
                UpdateCompetitionGrid();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveXmlDialog.FileName = String.Format("{0}-{1} {2}", FTournament.Info.Place, FTournament.Info.Name, FTournament.Info.DateBegin.ToString("yyyyMMdd"));
            saveXmlDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveXmlDialog.ShowDialog() == DialogResult.OK) 
            {
                foreach (Competition comp in FTournament.Competitions.Values)
                {
                    DatabaseManager.CurrentDb.ReadCompetitionPlayersList(comp, CompetitionPlayerList.SortByField.Name);
                    DatabaseManager.CurrentDb.ReadCompetitionMatchesList(comp);
                }
                FTournament.ExportToXml(saveXmlDialog.FileName);
            }
        }

        private void lvCompetitions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnCompetitionEdit_Click(sender, e);
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.label1.Text = Localizator.Dictionary.GetString("TOURNAMENT_TITLE");
            this.label2.Text = Localizator.Dictionary.GetString("PLACE");
            this.label3.Text = Localizator.Dictionary.GetString("TOURNAMENT_DATE");
            this.label4.Text = Localizator.Dictionary.GetString("DATE_FINISH");
            this.btnSave.Text = Localizator.Dictionary.GetString("SAVE");
            this.label5.Text = Localizator.Dictionary.GetString("DATE_START");
            this.label6.Text = Localizator.Dictionary.GetString("TOURNAMENT_COMPETITIONS");
            this.btnDelete.Text = Localizator.Dictionary.GetString("REMOVE");
            this.btnCompetitionEdit.Text = Localizator.Dictionary.GetString("OPEN");
            this.btnCompetitionAdd.Text = Localizator.Dictionary.GetString("CREATE");
            this.btnClose.Text = Localizator.Dictionary.GetString("CLOSE");
            this.btnExport.Text = Localizator.Dictionary.GetString("EXPORT");

            this.lvCompetitions.Columns["Info.SportType.Name"].Text = Localizator.Dictionary.GetString("GAME");
            this.lvCompetitions.Columns["Info.Name"].Text = Localizator.Dictionary.GetString("COMPETITION_TITLE");
            this.lvCompetitions.Columns["Info.PlayerCount"].Text = Localizator.Dictionary.GetString("PLAYERS_SPACE");
            this.lvCompetitions.Columns["Info.StatusString"].Text = Localizator.Dictionary.GetString("CURRENT_STATE");
            this.lvCompetitions.Columns["Info.CompetitionTypeName"].Text = Localizator.Dictionary.GetString("COMPETITION_FORMAT");

            this.saveXmlDialog.Filter = Localizator.Dictionary.GetString("TOURNAMENT_FILE_FILTER");
            this.saveXmlDialog.Title = Localizator.Dictionary.GetString("TOURNAMENT_EXPORT");
            this.Text = Localizator.Dictionary.GetString("TOURNAMENT_INFO");

        }

        #endregion
    }
}