using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.DB.Manager;
using TA.RatingSystem;

namespace TA.ExIm
{
    internal partial class fImport : Form, Localizator.ILocalizableForm
    {
        public fImport()
        {
            InitializeComponent();
            LocalizeComponents();
            mainTreeView.BackColor = WindowSkin.Palette.TextBackColor;
            mainTreeView.ForeColor = WindowSkin.Palette.ForeColor;
            pbOperationProgress.ForeColor = WindowSkin.Palette.Colors[9];
            pbTotalProgress.ForeColor = WindowSkin.Palette.Colors[9];
        }
        public static bool ShowImport()
        {
            if (EditionManager.Edition == EditionType.Mini) 
            {
                WindowSkin.MessageBox.Show( Localizator.Dictionary.GetString("OPERATION_IS_NOT_AVAILABLE"));
            }

            fImport form = new fImport();
            if (form.openFileDialog.ShowDialog() != DialogResult.OK)
                return false;
            string filename = form.openFileDialog.FileName;
            if (form.ParseImport(filename))
                form.ShowDialog();
            else
            {
                WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("IS_NOT_CMDX_FILE"), Localizator.Dictionary.GetString("ERROR"));
            }
            return true;
        }
        private bool ParseImport(string filename)
        {
            IImporter importer = Importer.GetImporter(filename);
            if (importer != null && importer.Open(filename)) 
            {
                mainTreeView.Nodes.Clear();
                PlayerInfo[] players = importer.GetPlayers();
                if(players != null && players.Length > 0)
                {
                    TreeNode node = new TreeNode(Localizator.Dictionary.GetString("PLAYER_LIST"));
                    node.Tag = players;
                    mainTreeView.Nodes.Add(node);
                }
                TypeOfSport[] games = importer.GetTypesOfSport();
                if (games != null && games.Length > 0)
                {
                    TreeNode node = new TreeNode(Localizator.Dictionary.GetString("RATING_LISTS"));
                    node.Tag = games;
                    mainTreeView.Nodes.Add(node);
                    foreach (TypeOfSport sport in games)
                    {
                        TreeNode child = new TreeNode();
                        child.Text = sport.Name;
                        XmlExporter.RatingNode rating_node = new XmlExporter.RatingNode();
                        rating_node.Game = sport;
                        rating_node.Ratings.AddRange(importer.GetPlayersRatings(sport));
                        child.Tag = rating_node;
                        node.Nodes.Add(child);
                    }
                }

                Tournament[] tourns = importer.GetTournaments();
                if (tourns != null && tourns.Length > 0)
                {
                    TreeNode node = new TreeNode();
                    node.Text = Localizator.Dictionary.GetString("TOURNAMENTS");// "Турниры";
                    node.Tag = tourns;
                    mainTreeView.Nodes.Add(node);
                    CompetitionList comps = new CompetitionList();
                    foreach (Tournament tour in tourns)
                    {
                        TreeNode child = new TreeNode();
                        child.Text = String.Format("{0} - {1}", tour.Info.DateBegin.ToString("dd.MM.yyyy"), tour.Info.Name);
                        child.Tag = tour;
                        node.Nodes.Add(child);
                        foreach (Competition comp in tour.Competitions.Values)
                        {
                            TreeNode sub_child = new TreeNode();
                            sub_child.Text = comp.Info.Name;
                            sub_child.Tag = comp;
                            child.Nodes.Add(sub_child);
                        }
                    }
                    mainTreeView.ExpandAll();
                }
                return true;
            }
            return false;
        }
        private void ImportPlayers(PlayerInfo[] players) 
        {
            pbOperationProgress.Value = 0;
            pbOperationProgress.Maximum = players.Length;
            lblTotalProgress.Text = Localizator.Dictionary.GetString("IMPORT_PLAYERS");// "Импортирование списка игроков";                        
            foreach (PlayerInfo player in players) 
            {
                lblOperationProgress.Text = player.FullName;
                pbOperationProgress.Value += 1;
                Application.DoEvents();
                if (Globals.Players.ContainsKey(player.Identifier))
                    player.Id = Globals.Players[player.Identifier].Id;
                else {
                    player.Id = -1;
                    //player.Id = SearchPlayer(player);
                    //TO DO : 2011/06/11
                    //если найден в БД, то если это FEDERAL, то player.Guid заменить на Guid из базы данных (но только после импорта матчей!!!)
                    // если это STANDARD, то Guid в БД заменить на player.GUID
                }
                    
                DatabaseManager.CurrentDb.PlayerInfoSave(player);
                Application.DoEvents();
            }
            DatabaseManager.CurrentDb.ReadPlayerList(Globals.Players);
        }

        private int SearchPlayer(PlayerInfo player)
        {
            List<PlayerInfo> players = new List<PlayerInfo>();  
            foreach (PlayerInfo pl in Globals.Players.Values) {
                if (TA.Utils.NameComparer.Compare(pl.LastName, player.LastName) == 0 
                    || TA.Utils.NameComparer.Compare(pl.LastName, player.FirstName) == 0
                    || TA.Utils.NameComparer.Compare(pl.FirstName, player.LastName) == 0) // смотрим, если есть похожие фамилии или имена
                {
                    players.Add(pl);
                    return pl.Id;
                }                
            }
            if (players.Count > 0)
                return FindSimilarPlayer(player, players);
            else return -1;
        }

        private int FindSimilarPlayer(PlayerInfo player, List<PlayerInfo> players)
        {
            throw new NotImplementedException();
        }
        private void ImportTypeOfSport(TypeOfSport sport) 
        {
            DatabaseManager.CurrentDb.ReadTypeOfSportList(Globals.Games);
            if(Globals.Games.ContainsKey(sport.Id))
            {
                Globals.Games[sport.Id].Name = sport.Name;
            }
            DatabaseManager.CurrentDb.SaveTypeOfSport(sport);
            DatabaseManager.CurrentDb.ReadTypeOfSportList(Globals.Games);
        }
        private void ImportRating(XmlExporter.RatingNode ratingNode) 
        {
            pbOperationProgress.Value = 0;
            pbOperationProgress.Maximum = ratingNode.Ratings.Count;
            lblTotalProgress.Text = Localizator.Dictionary.GetString("IMPORT_RATINGS");// "Импортирование рейтингов";
            lblOperationProgress.Text = ratingNode.Game.Name;
            Application.DoEvents();
            ImportTypeOfSport(ratingNode.Game);            
            foreach (PlayerRating rating in ratingNode.Ratings) 
            {
                if (Globals.Players.ContainsKey(rating.Guid))
                {
                    rating.Id = Globals.Players[rating.Guid].Id;
#if FEDITION
                    DatabaseManager.CurrentDb.PlayerBeginRatingUpdate(new PlayerRatingInfo(ratingNode.Game.Id, rating.Id, rating.RatingBegin, true));
#endif
#if STANDARD
                    DatabaseManager.CurrentDb.PlayerBeginRatingUpdate(new PlayerRatingInfo(ratingNode.Game.Id, rating.Id, rating.Rating, true));
#endif
                }
                else 
                {
                    AddErrorText(Localizator.Dictionary.GetString("NOT_FOUND"), rating.Name.ToString());
                }
                pbOperationProgress.Value += 1;
                Application.DoEvents();
            }
        }
        private void ImportTournament(Tournament tournament)
        {
            lblTotalProgress.Text = Localizator.Dictionary.GetString("IMPORT_TOURNAMENTS");// "Импортирование турниров";
            lblOperationProgress.Text = tournament.Info.Name;
            Application.DoEvents();
            tournament.Info.Id = -1;
            DatabaseManager.CurrentDb.TournamentInfoSave(tournament.Info);            
            foreach (Competition comp in tournament.Competitions.Values)
            {
                comp.Info.TournamentId = tournament.Info.Id;
                pbOperationProgress.Value = 0;
                pbOperationProgress.Maximum = comp.Players.Count + comp.Matches.Count;
                lblOperationProgress.Text = tournament.Info.Name + " : " + comp.Info.Name;
                comp.Info.Id = -1;
                DatabaseManager.CurrentDb.CompetitionInfoSave(comp.Info);
                foreach (CompetitionPlayerInfo player in comp.Players.Values) 
                {
                    if (!Globals.Players.ContainsKey(player.Identifier))
                    {
                        AddErrorText(Localizator.Dictionary.GetString("NOT_FOUND"), player.FullName.ToString());
                    }
                    else 
                    {
                        player.Id = Globals.Players[player.Identifier].Id;
                        player.CompetitionId = comp.Info.Id;
                        DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
                        if (!player.Place.IsNull)
                            DatabaseManager.CurrentDb.SetCompetitionPlayerPlace(comp.Info.Id, player.Id, player.Place);
                    }
                    pbOperationProgress.Value += 1;
                }
                foreach (MatchInfo match in comp.Matches.Values) 
                {
                    if (match.PlayerA.Guid != Guid.Empty)
                    {
                        if (Globals.Players.ContainsKey(match.PlayerA.Guid))
                            match.PlayerA.Id = Globals.Players[match.PlayerA.Guid].Id;
                        else 
                        {
                            AddErrorText(Localizator.Dictionary.GetString("NOT_FOUND"), match.PlayerA.Name);
                            return;
                        }
                            
                    }
                    if (match.PlayerB.Guid != Guid.Empty)
                    {
                        if (Globals.Players.ContainsKey(match.PlayerB.Guid))
                            match.PlayerB.Id = Globals.Players[match.PlayerB.Guid].Id;
                        else                         
                        {
                            AddErrorText(Localizator.Dictionary.GetString("NOT_FOUND"), match.PlayerA.Name);
                            return;
                        }                        
                    }
                    DatabaseManager.CurrentDb.CreateMatch(comp.Info.Id, match);
                    pbOperationProgress.Value += 1;
                }
                Application.DoEvents();
            }
        }

        private void AddErrorText(string error, string info)
        {
            txtProgressErrors.Text += error + " : " + info + Environment.NewLine;
            txtProgressErrors.SelectionStart = txtProgressErrors.Text.Length;
            txtProgressErrors.ScrollToCaret();
        }
        private void SetProgressPanelVisible(bool visible) 
        {
            btnClose.Enabled = !visible;
            btnStartOperation.Enabled = !visible;
            mainTreeView.Enabled = !visible;
            btnCloseProgressPanel.Visible = false;
            txtProgressErrors.Text = "";
            txtProgressErrors.BackColor = WindowSkin.Palette.TextBackColor;
            pnlProgress.Visible = visible;
        }
        private void Import()
        {
            try
            {
                pbTotalProgress.Value = 0;
                pbTotalProgress.Maximum = mainTreeView.Nodes.Count;
                SetProgressPanelVisible(true);
                DatabaseManager.CurrentDb.ReadPlayerList(Globals.Players);
                foreach (TreeNode node in mainTreeView.Nodes)
                {
                    //  Если это список игроков
                    if (node.Checked && node.Tag is PlayerInfo[])
                    {
                        ImportPlayers(node.Tag as PlayerInfo[]);
                        pbTotalProgress.Value += 1;
                    }
                    // Если это рейтинги
                    if (node.Checked && node.Tag is TypeOfSport[])
                    {
                        foreach (TreeNode child in node.Nodes) 
                        {
                            if (child.Checked && child.Tag is XmlExporter.RatingNode) 
                            {
                                ImportRating(child.Tag as XmlExporter.RatingNode);
                            }
                        }
                        pbTotalProgress.Value += 1;
                    }
                    if (node.Checked && node.Tag is Tournament[]) 
                    {
                        foreach (TreeNode child in node.Nodes)
                        {
                            if (child.Checked && child.Tag is Tournament)
                            {
                                ImportTournament(child.Tag as Tournament);
                            }
                        }
                        pbTotalProgress.Value += 1;
                    }
                }
                string title = Localizator.Dictionary.GetString("IMPORT_COMPLETE");
                WindowSkin.MessageBox.Show(title, title);
            }
            finally 
            {
                if (txtProgressErrors.Text == "")
                    SetProgressPanelVisible(false);
                else
                    btnCloseProgressPanel.Visible = true;
            }
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            Text = Localizator.Dictionary.GetString("IMPORT");
            lblCaption.Text = Localizator.Dictionary.GetString("SELECT_DATA_IMPORT");
            btnStartOperation.Text = Localizator.Dictionary.GetString("IMPORT");
            openFileDialog.Title = Localizator.Dictionary.GetString("IMPORT");
            btnClose.Text = Localizator.Dictionary.GetString("CLOSE");
            btnCloseProgressPanel.Text = Localizator.Dictionary.GetString("CLOSE");
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool block_OnCheck = false;
        void SetNodeChecked(TreeNode node, bool isChecked, bool deepCheck)
        {
            node.Checked = isChecked;
            if (deepCheck)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    SetNodeChecked(child, isChecked, true);
                }
            }
            if (node.Parent != null)
            {
                if (isChecked)
                    SetNodeChecked(node.Parent, isChecked, false);
                else
                {
                    bool same_value = true;
                    foreach (TreeNode child in node.Parent.Nodes)
                    {
                        same_value &= child.Checked == isChecked;
                    }
                    if (same_value)
                        SetNodeChecked(node.Parent, isChecked, false);
                }
            }
        }
        private void mainTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (block_OnCheck)
                return;
            block_OnCheck = true;
            try
            {
                SetNodeChecked(e.Node, e.Node.Checked, true);
            }
            finally
            {
                block_OnCheck = false;
            }
        }

        private void btnStartOperation_Click(object sender, EventArgs e)
        {
            if (EditionManager.IsTrial)
                WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("TRIAL_RESTRICTIONS"));
            else
                Import();
        }

        private void btnCloseProgressPanel_Click(object sender, EventArgs e)
        {
            SetProgressPanelVisible(false);
        }

    }
}
