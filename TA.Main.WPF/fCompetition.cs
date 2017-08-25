using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TA.Corel;
using TA.Competitions;
using TA.DB.Manager;
using TA.Competitions.Forms;
using TA.CompetitionControllers;
using TA.Utils;
using System.Drawing.Imaging;
using System.IO;

namespace TA.Main
{
    public partial class fCompetition : Form, Localizator.ILocalizableForm
    {
        private Competition FCompetition = null;
        private CompetitionPanel pnlCompetition = null;
        private CompetitionParamsPanel pnlCompetitionParams = null;
        private CompetitionController FCompetitionController = null;
        public fCompetition()
        {
            InitializeComponent();
            LocalizeComponents();
            pnlProperties.BackColor = WindowSkin.Palette.BackColor;
            lvCompetitionPlayers.BackColor = WindowSkin.Palette.TextBackColor;
            lvRatingAfter.BackColor = WindowSkin.Palette.TextBackColor;
#if STANDARD
            lvRatingAfter.BackColor = WindowSkin.Palette.DisabledCaptionColor;
            lvRatingAfter.Visible = false;
#endif
            lvPlayerPlace.BackColor = WindowSkin.Palette.TextBackColor;
            tpgCompetition.BackColor = WindowSkin.Palette.BackColor;
            tpgResults.BackColor = WindowSkin.Palette.BackColor;
            Left = Screen.PrimaryScreen.Bounds.Left + 15;
            Width = Screen.PrimaryScreen.Bounds.Width - 30;
            Top = Screen.PrimaryScreen.Bounds.Top + 15;
            Height = Screen.PrimaryScreen.Bounds.Height - 60;                      
        }

        /// <summary>
        /// Обновляет список игроков - участников турнира
        /// </summary>
        public void UpdateCompetitionPlayersGrid() 
        {
            btnPlayerAdd.Enabled = FCompetition.Info.Status == CompetitionInfo.CompetitionState.RegistrationAndSeeding;
            lvCompetitionPlayers.Clear();
            List<CompetitionPlayerInfo> players = null;
            bool set_visible = false;
            if (FCompetition.Info != null && FCompetition.Players.Count > 0) 
            {
                players = FCompetition.Players.GetSortedList(CompetitionPlayerList.SortByField.Name);
                if (players[0].SeedNo > 0)
                {
                    players = FCompetition.Players.GetSortedList(CompetitionPlayerList.SortByField.SeedNo);
                }
                set_visible = players[0].SeedNo > 0;
                lvCompetitionPlayers.AddRange(players);
            }
            lvCompetitionPlayers.Columns["SeedNo"].Visible = set_visible;
            UpdateButtons();
#if LIMITED 
                lvCompetitionPlayers.Columns["RatingBeforeCompetition"].Visible = false;
#endif
        }
        public void UpdateResultGrid() 
        {
            lvPlayerPlace.Columns["TotalPoints"].Visible = FCompetition.Info.CompetitionType == CompetitionType.FppSwiss;
            List<CompetitionPlayerInfo> players = FCompetition.PlayersPlaces;
            lvPlayerPlace.Clear();
            if (FCompetition.Info.Status == CompetitionInfo.CompetitionState.Finished)
            {
                foreach (CompetitionPlayerInfo player in players)
                {
                    lvPlayerPlace.Add(player);
                }
            }
        }
        /// <summary>
        /// Пересчитывает рейтинг и обновляет грид
        /// </summary>
        public void UpdateRatingAfterGrid()
        {
            //Пересичтывать рейтинг, только если это FedEdition
            if (!FCompetition.Info.ChangesRating)
            {
                lvRatingAfter.Visible = false;
                return;
            }

#if FEDITION 
            string game_name = FCompetition.Info.SportType.Name;
                TA.RatingSystem.RatingSystem RS = TA.RatingSystem.Builder.RatingSystemBuilder.CreateRatingSystem(FCompetition.Info.SportType.Id, game_name);
                TA.RatingSystem.CompetitionInfo competitionInfo = RS.Competitions.GetCompetitionById(FCompetition.Info.Id);

                lvRatingAfter.Clear();
                if (FCompetition.Info != null && competitionInfo != null)
                {
                    DatabaseManager.CurrentDb.ReadCompetitionPlayersList(FCompetition, CompetitionPlayerList.SortByField.Name);
                    foreach (CompetitionPlayerInfo player in FCompetition.PlayersResults)
                    {
                        if (competitionInfo.Results.ContainsKey(player.Id))
                        {
                            TA.RatingSystem.PlayersCompetitionResult res = competitionInfo.Results[player.Id];
                            res.PlayerName = player.FullName;
                            lvRatingAfter.Add(res);
                        }
                    }
                }
#endif
        }
        public void OpenCompetition(Competition aCompetition) 
        {
            FCompetition = aCompetition;
            DatabaseManager.CurrentDb.ReadCompetitionPlayersList(FCompetition, CompetitionPlayerList.SortByField.Name);
            DatabaseManager.CurrentDb.ReadCompetitionMatchesList(FCompetition);
            btnFinish.Enabled = FCompetition.CanFinishCompetition;
            CreatePanels();
            ArangePanels();
            SetCompetitionInfo();
        }
        private void CreatePanels()
        {
            FCompetitionController = CompetitionControllers.CompetitionControllers.GetController(FCompetition);
            pnlCompetition = FCompetitionController.GetControl(); 
            pnlCompetition.OnAfterMatchEdit += new EventHandler(OnAfterMatchEdit);
            if (pnlCompetition is SwissPanel) 
            {
                (pnlCompetition as SwissPanel).OnNextRoundClick += new EventHandler(OnNextRound); 
            }
            pnlCompetitionParams = FCompetitionController.GetParametersPanel();
            if (pnlCompetitionParams != null)
                pnlCompetitionParams.ReadOnly = true;
        }
        private void ArangePanels()
        {
            // Размещаем панель дополнительных параметров
            if (pnlCompetitionParams != null) 
            {
                pnlProperties.Controls.Add(pnlCompetitionParams);
                pnlCompetitionParams.Location = new Point(label3.Left, label3.Top + 51);
                pnlCompetitionParams.Size = new Size(txtCompetitionName.Width - btnChangeProperties.Width - 8, tpgProperties.Height - pnlCompetitionParams.Top - 20);
                pnlCompetitionParams.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            }
            // Размещаем панель сетки турнира
            Point loc = pnlScalePicture.Location;
            loc.Offset(0, pnlScalePicture.Height);
            //Dock = DockStyle.Fill;
            tpgCompetition.Controls.Add(pnlCompetition);
            pnlCompetition.Location = loc;
            pnlCompetition.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            pnlCompetition.Size = new Size(pnlScalePicture.Width, tpgCompetition.Size.Height - pnlScalePicture.Height);
        }
        public static bool Edit(Competition competition) 
        {
            fCompetition form = new fCompetition();
            form.OpenCompetition(competition);
            switch (form.FCompetition.Info.Status) 
            {
                case CompetitionInfo.CompetitionState.RegistrationAndSeeding:
                    form.tcMain.SelectedTab = form.tpgProperties;
                    break;
                case CompetitionInfo.CompetitionState.Playing:
                    form.tcMain.SelectedTab = form.tpgCompetition;
                    break;
                case CompetitionInfo.CompetitionState.Finished:
                    form.tcMain.SelectedTab = form.tpgResults;
                    form.UpdateRatingAfterGrid();
                    break;
            }
#if LIMITED
                form.lvPlayersSeeding.Columns[3].Width = 0;
                form.btnSeedRating.Visible = false;
                form.btnRatingRefresh.Visible = false;
                form.lvRatingAfter.Visible = false;
#endif
            form.ShowDialog();
            return true;
        }

        private void OnAfterMatchEdit(object sender, EventArgs e) 
        {
            btnFinish.Enabled = FCompetition.CanFinishCompetition && (FCompetition.Info.Status == CompetitionInfo.CompetitionState.Playing);
        }
        private void SetCompetitionInfo()
        {
            txtCompetitionName.Text = FCompetition.Info.Name;
            txtCompetitionType.Text = FCompetition.Info.CompetitionType.Name;
            lblCompetitionTypeDescription.Text = FCompetition.Info.CompetitionType.Description;
            cbxChangesRating.Checked = FCompetition.Info.ChangesRating;
            txtTypeOfSport.Text = FCompetition.Info.SportType.Name;
            txtCurrentState.Text = FCompetition.Info.StatusString;
            UpdateCompetitionPlayersGrid();
            UpdateResultGrid();
        }
        private void DoOnSelectPlayer(PlayerInfo player) 
        {
            if (player == null)
                return;
            CompetitionPlayerInfo cp = new CompetitionPlayerInfo(player);
            cp.CompetitionId = FCompetition.Info.Id;
            DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(cp);
        }
        private void SaveCompetitionPlayers(params object[] args) 
        {
            if (args.Length != 2)
                throw new Exception(Localizator.Dictionary.GetString("WRONG_PARAM_COUNT"));
            CompetitionPlayerList playersToSave = args[0] as CompetitionPlayerList;
            List<int> playersToDelete = args[1] as List<int>;
#if FEDITION || STANDARD || FEDITION_PLUS || STANDARD_PLUS
            TA.RatingSystem.PlayersRatingList players_rating = TA.RatingSystem.Builder.RatingSystemBuilder.GetPlayersRating(FCompetition.Info.SportType.Id, FCompetition.Info.Date);
#endif
            int seedNo = 1;
            foreach (CompetitionPlayerInfo player in playersToSave.Values)
            {
                if (!FCompetition.NeedsPlayersDrawing)
                    player.SeedNo = seedNo++;
                player.CompetitionId = FCompetition.Info.Id;
#if FEDITION || STANDARD || FEDITION_PLUS || STANDARD_PLUS
                player.RatingBeforeCompetition = players_rating[player.Id].Rating;
#else
                    player.RatingBeforeCompetition = 0;
#endif
                DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
                if (playersToDelete.Contains(player.Id))
                    playersToDelete.Remove(player.Id);
            }
            foreach (int playerId in playersToDelete)
            {
                DatabaseManager.CurrentDb.CompetitionPlayerInfoDelete(FCompetition.Info.Id, playerId);
            }

        }
        private void btnPlayerAdd_Click(object sender, EventArgs e)
        {
            CompetitionPlayerList listA = FCompetition.Players;
            List<int> listB = new List<int>();
            foreach (int id in listA.Keys) 
            {
                listB.Add(id);
            }
            if (fPlayerSelect.Select(FCompetition.Info.SportType.Id, listA))
            {
                LongOpertationExecutor.Execute(SaveCompetitionPlayers , listA, listB);
            }
            UpdateCompetitionPlayersGrid();
        }
        private void SeedAuto() 
        {
            ArrayList array = new ArrayList();
            CompetitionPlayerList players = FCompetition.Players;
            for (int i = 0; i < players.Count; i++)
            {
                array.Add(i);
            }
            Random rnd = new Random();
            int pc = players.Count;
            foreach (CompetitionPlayerInfo player in players.Values)
            {
                int index = rnd.Next(pc);
                player.SeedNo = Convert.ToInt32(array[index]) + 1;
                array.RemoveAt(index);
                pc--;
                DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
            }
        }
        private void btnSeedAuto_Click(object sender, EventArgs e)
        {
            LongOpertationExecutor.Execute(SeedAuto);
            UpdateCompetitionPlayersGrid();  
        }
        private void OnNextRound(object sender, EventArgs e) 
        {
            try
            {
                LongOpertationExecutor.Execute(SeedPlayers);
                pnlCompetition.OpenCompetition(FCompetition);
                DatabaseManager.CurrentDb.CompetitionInfoSave(FCompetition.Info);
                btnFinish.Enabled = false;
            }
            catch (Exception ex) 
            {
                WindowSkin.MessageBox.Show(ex.Message, Localizator.Dictionary.GetString("ERROR"));
            }
        }
        private void SeedPlayers() 
        {
            if (FCompetitionController.SeedPlayers()) 
            {
                foreach (CompetitionPlayerInfo player in FCompetition.Players.Values)
                {
                    player.HasMatches = true;
                }
            }
        }
        private void UpdateButtons() 
        {
            if (btnSeedFinish.InvokeRequired)
            {                
                this.Invoke(new Action(UpdateButtons));
            }
            else 
            {
                btnPlayerAdd.Enabled = FCompetition.Info.Status == CompetitionInfo.CompetitionState.RegistrationAndSeeding;
                //btnDrawPlayers.Enabled = FCompetition.CanFinishRegistration && FCompetition.NeedsPlayersDrawing;
                /*bool seed_finish = FCompetition.CanFinishRegistration;
                if (btnDrawPlayers.Enabled)
                    seed_finish = seed_finish && lvCompetitionPlayers.Columns["SeedNo"].Visible;*/
                btnSeedFinish.Enabled = FCompetition.CanFinishRegistration;// seed_finish;
            }
        }
        private void btnSeedFinish_Click(object sender, EventArgs e)
        {
            if (!fStartCompetition.ShowStartWindow(FCompetitionController))
                return;
            /* Начало изменений */
            SeedingArgs args = SeedingArgs.Empty;
            args.PlayersToSeed = FCompetition.Players;
            args.SeedOrder = FCompetitionController.GetDrawOrder(args.PlayersToSeed.Count);
            args.SeedType = Seeding.SeedType.Matches;
            args.AllowRating = FCompetition.Info.ChangesRating;


            if (FCompetition is Olympic)
            {
                args.SeedType = Seeding.SeedType.Olympic;
                args.LastPlayerWithBay = 0;
            }
            if (FCompetition is RobinOlympic)
            {
                args.SeedType = Seeding.SeedType.Groups;
                int playersInGroup = FCompetition.Players.Count / (FCompetition as RobinOlympic).GroupCount;
                if (playersInGroup * (FCompetition as RobinOlympic).GroupCount < FCompetition.Players.Count)
                    playersInGroup++;
                args.Param = playersInGroup;
            }

            //if (fGraphicalSeeding.Seed(args) /*конец изменений*/&& fStartCompetition.ShowStartWindow(FCompetitionController))
            if (fGraphicalSeeding.Seed(args))
            {
                if(pnlCompetitionParams != null) 
                    pnlCompetitionParams.ReadParameters();
                string error = "";
                if (!FCompetition.CheckCompetitionParams(ref error)) 
                {
                    if (error != "")
                        WindowSkin.MessageBox.Show(error, Localizator.Dictionary.GetString("PARAMS_ERROR"));
                    return;
                }
                    
                LongOpertationExecutor.Execute(SeedPlayers);
                pnlCompetition.OpenCompetition(FCompetition);
                tcMain.SelectedTab = tpgCompetition;
                FCompetition.Info.Status = CompetitionInfo.CompetitionState.Playing;
                DatabaseManager.CurrentDb.CompetitionInfoSave(FCompetition.Info);
                UpdateButtons();
            }

        }
        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlScalePicture.Enabled = pnlCompetition != null;
            btnFinish.Enabled = FCompetition.CanFinishCompetition && (FCompetition.Info.Status == CompetitionInfo.CompetitionState.Playing);
            if (tcMain.SelectedTab == tpgResults) 
            {
                UpdateResultGrid();
                UpdateRatingAfterGrid();
            }
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            //Database.UpdateCompetiotionResult(FCompetitionInfo.Id);
            FCompetition.Info.Status = CompetitionInfo.CompetitionState.Finished;
            DatabaseManager.CurrentDb.CompetitionInfoSave(FCompetition.Info);
            SetCompetitionInfo();
            tcMain.SelectedTab = tpgResults;
            pnlCompetition.UpdateButtonsActivity();
        }
        void SeedRating() 
        {
            ArrayList array = new ArrayList();
            List<CompetitionPlayerInfo> players = FCompetition.Players.GetSortedList(CompetitionPlayerList.SortByField.Raiting);
            int index = 0;
            //int[] sortition_order = FCompetition.GetSeedOrder();
            foreach (CompetitionPlayerInfo player in players)
            {
                player.SeedNo = index + 1;// sortition_order[index];
                index++;
                DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
            }
        }
        private void btnSeedRating_Click(object sender, EventArgs e)
        {
            LongOpertationExecutor.Execute(SeedRating);
            UpdateCompetitionPlayersGrid();
        }
        private void btnSeedHandly_Click(object sender, EventArgs e)
        {
            /*CompetitionPlayerList players = FCompetition.Players;
            if (Seeding.fManualSeeding.Edit(players)) 
            {
                foreach (CompetitionPlayerInfo player in players.Values) 
                {
                    DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
                }
                UpdateCompetitionPlayersGrid();
            }*/
        }
        private void btnSeedGraphical_Click(object sender, EventArgs e)
        {
            /*SeedingArgs args = SeedingArgs.Empty;
            args.PlayersToSeed = FCompetition.Players;
            args.SeedOrder = FCompetitionController.GetDrawOrder(args.PlayersToSeed.Count);
            args.SeedType = Seeding.SeedType.Matches;
            args.ShowRating = FCompetition.Info.ChangesRating;

            if (FCompetition is Olympic) 
            {
                args.SeedType = Seeding.SeedType.Olympic;
            }
            if (FCompetition is RobinOlympic) 
            {
                args.SeedType = Seeding.SeedType.Groups;
                int playersInGroup = FCompetition.Players.Count / (FCompetition as RobinOlympic).GroupCount;
                if(playersInGroup * (FCompetition as RobinOlympic).GroupCount < FCompetition.Players.Count )
                    playersInGroup++;
                args.Param = playersInGroup;
            }

            if (fGraphicalSeeding.Seed(args)) 
            {
                LongOpertationExecutor.Execute(SaveDrawing, args.PlayersToSeed);
            }*/
        }

        private void SaveDrawing(params object[] aParams)
        {
            CompetitionPlayerList players = aParams[0] as CompetitionPlayerList;
            foreach (CompetitionPlayerInfo player in players.Values)
            {
                DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
            }
            UpdateCompetitionPlayersGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrizeMoney_Click(object sender, EventArgs e)
        {
            //fMoneyDistribution.Distribute();
        }

        private void lvCompetitionPlayers_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
#if LIMITED 
            if (e.ColumnIndex == 2 || e.ColumnIndex == 0)
            {
                e.Cancel = true;
                e.NewWidth = lvCompetitionPlayers.Columns[e.ColumnIndex].Width;
            }
#endif
        }

        private void lvPlayersSeeding_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
#if LIMITED 
            if (e.ColumnIndex == 3)
            {
                e.Cancel = true;
                e.NewWidth = lvCompetitionPlayers.Columns[e.ColumnIndex].Width;
            }
#endif
        }

        private void border1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void btnPrintPicture_Click(object sender, EventArgs e)
        {
            if (pnlCompetition == null)
                return;
            PicturePrinter.Printer.Preview(pnlCompetition.GetPicture(null));
            pnlCompetition.Refresh();
        }



        private void btnSavePicture_Click(object sender, EventArgs e)
        {
            if (pnlCompetition == null)
                return;
            saveDialog.DefaultExt = "";
            saveDialog.FileName = "";
            saveDialog.Title = Localizator.Dictionary.GetString("SAVE_MATCHES");
            saveDialog.Filter = PictureSaver.Filter;            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = pnlCompetition.GetPicture(new SolidBrush(Color.White));
                PictureSaver.SavePicture(bmp, saveDialog.FileName, Utils.PictureSaver.Formats[saveDialog.FilterIndex - 1]);
            }
            pnlCompetition.Refresh();
        }

        private void udScale_ValueChanged(object sender, EventArgs e)
        {
            if (pnlCompetition != null)
                pnlCompetition.ScalePicture = ibxScale.Value / 100.0;
        }

        private void btnChangeProperties_Click(object sender, EventArgs e)
        {
            if (btnChangeProperties.Text == Localizator.Dictionary.GetString("EDIT_PARAMS"))
            {
                txtCompetitionName.ReadOnly = false;
                cbxChangesRating.Enabled = FCompetition.Info.CompetitionType.CanChangeRating;
                if (pnlCompetitionParams != null)
                    pnlCompetitionParams.ReadOnly = false;
                btnChangeProperties.Text = Localizator.Dictionary.GetString("APPLY_PARAMS");
            }
            else 
            {
                cbxChangesRating.Enabled = false;
                txtCompetitionName.ReadOnly = true;
                if (pnlCompetitionParams != null) 
                {
                    pnlCompetitionParams.ReadOnly = true;
                    pnlCompetitionParams.WriteParameters();
                }
                FCompetition.Info.ChangesRating = cbxChangesRating.Checked && FCompetition.Info.CompetitionType.CanChangeRating;
                FCompetition.Info.Name = txtCompetitionName.Text;
                DatabaseManager.CurrentDb.CompetitionInfoSave(FCompetition.Info);
                btnChangeProperties.Text = Localizator.Dictionary.GetString("CHANGE_PARAMS");
                UpdateButtons();
            }
        }

        private string lvRatingAfter_OnGetCellString(object obj, int columnIndex)
        {
            if (obj is double)
            {
                return Utils.Utils.GetPointsString(Convert.ToDouble(obj));
            }
            return "";
        }
        private void SaveToHtml(string html_filename) 
        {
            string pic_filename = Path.Combine(Path.GetDirectoryName(html_filename), Path.GetFileNameWithoutExtension(html_filename) + ".jpg");
            if (!Globals.Tournaments.ContainsKey(FCompetition.Info.TournamentId))
                DatabaseManager.CurrentDb.ReadTournamentList(Globals.Tournaments);
            TournamentInfo tInfo = Globals.Tournaments[FCompetition.Info.TournamentId].Info;
            string tDate = tInfo.DateBegin.ToString("dd.MM.yyyy") + " - " + tInfo.DateEnd.ToString("dd.MM.yyyy");
            string tPlace = tInfo.Place;
            string tName = tInfo.Name;
            string cName = FCompetition.Info.Name;
            string cDate = FCompetition.Info.Date.ToString("dd.MM.yyyy");
            string title = String.Format("{0}. {1}. {2} - {3}", tDate, tPlace, tName, cName);

            HtmlGenerator html = new HtmlGenerator();
            html.Title = title;
            StringBuilder body = new StringBuilder();
            body.AppendLine(html.TagString("h1", tDate + " - " + tPlace));
            body.AppendLine(html.TagString("h1", tName));
            body.AppendLine(html.TagString("h2", cName));

            // Список участников
            body.AppendLine(html.TagString("h3", Localizator.Dictionary.GetString("PLAYER_IN_COMPETITION",":")));
            body.AppendLine(html.TagString("p", lvCompetitionPlayers.ToHtmlTableString()));

            // Сетка турнира
            if (FCompetition.Info.Status != CompetitionInfo.CompetitionState.RegistrationAndSeeding)
            {
                Bitmap bmp = pnlCompetition.GetPicture(new SolidBrush(Color.White));
                PictureSaver.SavePicture(bmp, pic_filename, ImageFormat.Png);
                string fn = Path.GetFileName(pic_filename);
                string img = String.Format("<img src='{0}' alt=''/>", fn);
                body.AppendLine(html.TagString("h3", Localizator.Dictionary.GetString("COMPETITION_MATCHES"," :")));
                body.AppendLine(html.TagString("p", img));
            }

            // Результаты
            if (FCompetition.Info.Status == CompetitionInfo.CompetitionState.Finished)
            {
                body.AppendLine(html.TagString("h3", Localizator.Dictionary.GetString("COMPETITION_RESULTS"," :")));
                body.AppendLine(html.TagString("p", lvPlayerPlace.ToHtmlTableString()));
            }

            // Изменение рейтинга
#if FEDITION
            if (FCompetition.Info.Status == CompetitionInfo.CompetitionState.Finished && FCompetition.Info.ChangesRating)
            {
                body.AppendLine(html.TagString("h3", Localizator.Dictionary.GetString("RATING_CHANGES"," :")));
                body.AppendLine(html.TagString("p", lvRatingAfter.ToHtmlTableString()));
            }
#endif
            html.Body = body.ToString();
            html.SaveTo(html_filename);

        }
        private void btnSaveResults_Click(object sender, EventArgs e)
        {            
            saveDialog.Filter = Localizator.Dictionary.GetString("HTML_FILTER");
            saveDialog.FileName = "";
            saveDialog.Title = Localizator.Dictionary.GetString("SAVE_RESULTS");
            saveDialog.DefaultExt = "html";
            if (saveDialog.ShowDialog() == DialogResult.OK) 
            {
                SaveToHtml(saveDialog.FileName);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = saveDialog.FileName;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                p.Start();
            }
        }




        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.tpgProperties.Text = Localizator.Dictionary.GetString("REGISTRATION_AND_DRAW");
            //this.btnDrawPlayers.Text = Localizator.Dictionary.GetString("DRAW_PLAYERS");

            this.lvCompetitionPlayers.Columns["SeedNo"].Text = Localizator.Dictionary.GetString("DRAW_NO");
            this.lvCompetitionPlayers.Columns["FullName"].Text = Localizator.Dictionary.GetString("PLAYER");
            this.lvCompetitionPlayers.Columns["RatingBeforeCompetition"].Text = Localizator.Dictionary.GetString("START_RATING");

            this.btnChangeProperties.Text = Localizator.Dictionary.GetString("EDIT_PARAMS");
            this.btnSeedFinish.Text = Localizator.Dictionary.GetString("START_COMPETITION");
            this.btnPlayerAdd.Text = Localizator.Dictionary.GetString("LIST_COMPETITION_PLAYERS");
            this.label3.Text = Localizator.Dictionary.GetString("CURRENT_STATE");
            this.cbxChangesRating.Text = Localizator.Dictionary.GetString("RATING_COMPETITION");
            this.label4.Text = Localizator.Dictionary.GetString("TYPE_OF_SPORT");
            this.label2.Text = Localizator.Dictionary.GetString("COMPETITION_FORMAT");
            this.label1.Text = Localizator.Dictionary.GetString("COMPETITION_NAME");
            this.tpgCompetition.Text = Localizator.Dictionary.GetString("MATCHES_AND_RESULTS");
            this.btnFinish.Text = Localizator.Dictionary.GetString("FINISH_COMPETITION");
            this.toolTip1.SetToolTip(this.btnSavePicture, Localizator.Dictionary.GetString("SAVE"));
            this.label7.Text = Localizator.Dictionary.GetString("SCALE");
            this.toolTip1.SetToolTip(this.btnPrintPicture, Localizator.Dictionary.GetString("PRINT"));
            this.tpgResults.Text = Localizator.Dictionary.GetString("FINAL_RESULTS");


            this.lvPlayerPlace.Columns["Place"].Text = Localizator.Dictionary.GetString("PLACE_IN_COMPETITION");
            this.lvPlayerPlace.Columns["FullName"].Text = Localizator.Dictionary.GetString("PLAYER");
            this.lvPlayerPlace.Columns["TotalPoints"].Text = Localizator.Dictionary.GetString("POINTS");

            this.lvRatingAfter.Columns["PlayerName"].Text = Localizator.Dictionary.GetString("PLAYER");
            this.lvRatingAfter.Columns["RatingBegin"].Text = Localizator.Dictionary.GetString("START_RATING");
            this.lvRatingAfter.Columns["OpponentsCount"].Text = Localizator.Dictionary.GetString("NUMBER_OF_OPPONENT");
            this.lvRatingAfter.Columns["Points"].Text = Localizator.Dictionary.GetString("SUM_POINTS");
            this.lvRatingAfter.Columns["Delta"].Text = Localizator.Dictionary.GetString("CHANGE_IN_RATING");
            this.lvRatingAfter.Columns["RatingEnd"].Text = Localizator.Dictionary.GetString("FINAL_RATING");

            this.toolTip1.SetToolTip(this.btnSaveResults, Localizator.Dictionary.GetString("SAVE_HTML"));
            //this.btnPrizeMoney.Text = Localizator.Dictionary.GetString("Призовой фонд");

            this.saveDialog.Filter = Localizator.Dictionary.GetString("PICTURES_FILTER");
            this.saveDialog.Title = Localizator.Dictionary.GetString("SAVE_PICT");

            //throw new NotImplementedException();
        }

        #endregion
    }
}