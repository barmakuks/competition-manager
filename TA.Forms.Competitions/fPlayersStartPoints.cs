using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.Utils;
using TA.DB.Manager;

namespace TA.Competitions.Forms
{
    public partial class fPlayersStartPoints : Form, Localizator.ILocalizableForm
    {
        private Competition FCompetition;
        private int LateStartPoints;
        private fPlayersStartPoints()
        {
            InitializeComponent();
            lvPlayers.BackColor = WindowSkin.Palette.TextBackColor;
            LocalizeComponents();
        }
        public static bool Edit(Competition aCompetition, int lateStartPoints) 
        {
            fPlayersStartPoints form = new fPlayersStartPoints();
            form.LateStartPoints = lateStartPoints;
            form.FCompetition = aCompetition;
            form.UpdatePlayersList();
            form.ShowDialog();
            return true;
        }

        private void btnRebuy_Click(object sender, EventArgs e)
        {
            CompetitionPlayerInfo player = lvPlayers.SelectedObject as CompetitionPlayerInfo;
            if (player != null) 
            {
                player.RebuyPoints += fRebuy.Edit(player, false); 
                TA.DB.Manager.DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
                lvPlayers.Invalidate();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private delegate void SimpleDelegate();
        private void UpdatePlayersList() 
        {
            if (lvPlayers.InvokeRequired)
            {                
                this.Invoke(new SimpleDelegate(UpdatePlayersList));
            }
            else 
            {
                lvPlayers.Clear();
                lvPlayers.AddRange(FCompetition.Players.Values);
            }
        }
        private void btnPlayersList_Click(object sender, EventArgs e)
        {
            CompetitionPlayerList listA = FCompetition.Players;
            List<int> listB = new List<int>();
            foreach (int id in listA.Keys)
            {
                listB.Add(id);
            }
            if (fPlayerSelect.Select(FCompetition.Info.SportType.Id, listA))
            {
                LongOpertationExecutor.Execute(SaveCompetitionPlayers, listA, listB);
            }

        }
        private void SaveCompetitionPlayers(params object[] args)
        {
            if (args.Length != 2)
                throw new Exception("Wrong param count");
            CompetitionPlayerList playersToSave = args[0] as CompetitionPlayerList;
            List<int> playersToDelete = args[1] as List<int>;
#if FEDITION || STANDARD || FEDITION_PLUS || STANDARD_PLUS
            TA.RatingSystem.PlayersRatingList players_rating = TA.RatingSystem.Builder.RatingSystemBuilder.GetPlayersRating(FCompetition.Info.SportType.Id, FCompetition.Info.Date);
#endif
            foreach (CompetitionPlayerInfo player in playersToSave.Values)
            {
                player.CompetitionId = FCompetition.Info.Id;
#if FEDITION || STANDARD || FEDITION_PLUS || STANDARD_PLUS
                player.RatingBeforeCompetition = players_rating[player.Id].Rating;
#else
                player.RatingBeforeCompetition = 0;
#endif
                if (player.StartPoints == 0)
                    player.StartPoints = LateStartPoints;
                DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
                if (playersToDelete.Contains(player.Id))
                    playersToDelete.Remove(player.Id);
                if (!FCompetition.Players.ContainsKey(player.Id))
                    FCompetition.Players.Add(player.Id, player);
            }
            foreach (int playerId in playersToDelete)
            {
                DatabaseManager.CurrentDb.CompetitionPlayerInfoDelete(FCompetition.Info.Id, playerId);
                FCompetition.Players.Remove(playerId);
            }
            UpdatePlayersList();
        }


        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.lvPlayers.Columns["FullName"].Text = Localizator.Dictionary.GetString("PLAYER");
            this.lvPlayers.Columns["StartPoints"].Text = Localizator.Dictionary.GetString("START_POINTS");
            this.lvPlayers.Columns["Points"].Text = Localizator.Dictionary.GetString("POINTS_EARNED");
            this.lvPlayers.Columns["RebuyPoints"].Text = Localizator.Dictionary.GetString("REBUY_POINTS");
            this.lvPlayers.Columns["AvailablePoints"].Text = Localizator.Dictionary.GetString("AVAIL_PTS");

            this.btnSetStartPoints.Text = Localizator.Dictionary.GetString("START_POINTS");
            this.btnClose.Text = Localizator.Dictionary.GetString("CLOSE");
            this.btnRebuy.Text = Localizator.Dictionary.GetString("ADD_REMOVE");
            this.btnPlayersList.Text = Localizator.Dictionary.GetString("PLAYER_LIST");
            this.Text = Localizator.Dictionary.GetString("ADD_REMOVE_PTS");
        }

        #endregion

        private void btnSetStartPoints_Click(object sender, EventArgs e)
        {
            CompetitionPlayerInfo player = lvPlayers.SelectedObject as CompetitionPlayerInfo;
            if (player != null)
            {
                player.StartPoints = fRebuy.Edit(player, true);
                TA.DB.Manager.DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
                lvPlayers.Invalidate();
            }
        }

        internal static void EditStartPoints(Competition aCompetition)
        {
            fPlayersStartPoints form = new fPlayersStartPoints();
            form.LateStartPoints = 0;
            form.FCompetition = aCompetition;
            form.btnSetStartPoints.Visible = true;
            form.btnRebuy.Visible = false;
            form.btnPlayersList.Visible = false;
            form.UpdatePlayersList();
            form.ShowDialog();
            
        }

        private void lvPlayers_DoubleClick(object sender, EventArgs e)
        {
            if (btnSetStartPoints.Visible)
                btnSetStartPoints_Click(sender, e);
            else
                btnRebuy_Click(sender, e);
        }
    }
}
