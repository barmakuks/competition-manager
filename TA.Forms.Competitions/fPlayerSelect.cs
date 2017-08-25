using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.DB.Manager;

namespace TA.Competitions.Forms
{
    public delegate void OnPlayersSelect(PlayerInfo aPlayer);
    public partial class fPlayerSelect : Form, Localizator.ILocalizableForm
    {
        private CompetitionPlayerList SelectedPlayers;
        public fPlayerSelect()
        {
            InitializeComponent();
            LocalizeComponents();
            lblLimit.Text = lblLimit.Text + String.Format(" ({0})", EditionManager.MaxPlayers);
        }
        public static bool Select(int gameType, CompetitionPlayerList SelectedPlayers) 
        {
            fPlayerSelect form = new fPlayerSelect();
            form.SelectedPlayers = SelectedPlayers;
            form.UpdatePlayersGrid(gameType);
            int height = (form.Height - form.lstPlayers.Height) + form.lstPlayers.ItemHeight * (form.lstPlayers.Count + 1);
            if(height > Screen.PrimaryScreen.Bounds.Height * 2 / 3)
                height = Screen.PrimaryScreen.Bounds.Height * 2 / 3;
            form.Height = height;
            return form.ShowDialog() == DialogResult.OK;
        }
        private void UpdatePlayersGrid(int gameType)
        {
            lstPlayers.Clear();
            DatabaseManager.CurrentDb.ReadPlayerList(gameType, Globals.Players);            
            foreach (PlayerInfo player in Globals.Players.Values) 
            {
                CheckState state = CheckState.Unchecked;
                bool readOnly = false;
                if (SelectedPlayers.ContainsKey(player.Id)) 
                {
                    state = CheckState.Checked;
                    readOnly = SelectedPlayers[player.Id].HasMatches;
                }
                int index = lstPlayers.Add(player,state,readOnly);
            }
            lblPlayersCount.Text = GetPlayersCountString();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            CompetitionPlayerList new_list = new CompetitionPlayerList();
            List<int> to_delete = new List<int>();
            // 1 - создаем текущий список игроков турнира
            foreach(PlayerInfo player in lstPlayers.CheckedObjects)
            {
                CompetitionPlayerInfo cp = new CompetitionPlayerInfo(player);
                new_list.Add(cp.Id, cp);
            }
            // 2 - добавляем тех, кто есть в текущем, но отсутсвует в исходном
            foreach (CompetitionPlayerInfo player in new_list.Values)
            {
                if (!SelectedPlayers.ContainsKey(player.Id)) 
                {
                    SelectedPlayers.Add(player.Id, player);
                }
            }
            // 3 - формируем список тех, кто есть в исходном списке, но кого нет в текущем списке
            foreach (CompetitionPlayerInfo player in SelectedPlayers.Values) 
            {
                if(!new_list.ContainsKey(player.Id))
                to_delete.Add(player.Id);
            }
            // 4 - удаляем из исходного списка тех, кого нет в текущем
            foreach (int id in to_delete) 
            {
                SelectedPlayers.Remove(id);
            }
            DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void grdPlayers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnOk_Click(sender, e);
        }
        private string GetPlayersCountString() 
        {
            int pc = lstPlayers.CheckedObjectsCount;
            string format_string = Localizator.Dictionary.GetString("SELECTED_INT_PLAYERS");
            if (pc == 0)
                format_string = Localizator.Dictionary.GetString("NO_PLAYER_SELECT");
            if(pc % 10 == 1 && (pc < 10 || pc > 20))
                format_string = Localizator.Dictionary.GetString("SELECTED_INT1_PLAYERS"); ;
            if ((pc % 10 == 2 || pc % 10 == 3 || pc % 10 == 4) && (pc < 10 || pc > 20))
                format_string = Localizator.Dictionary.GetString("SELECTED_INT2_PLAYERS");
            return String.Format(format_string, pc);
        }

        private void lstPlayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            lblPlayersCount.Text = GetPlayersCountString();
            btnOk.Enabled = lstPlayers.CheckedObjectsCount <= EditionManager.MaxPlayers;
            lblLimit.Visible = !btnOk.Enabled;
        }

        private void btnNewPlayer_Click(object sender, EventArgs e)
        {

        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnNewPlayer.Text = Localizator.Dictionary.GetString("NEW_PLAYER");
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.lblLimit.Text = Localizator.Dictionary.GetString("BETA_LIMIT_PLAYERS");
            this.Text = Localizator.Dictionary.GetString("PLAYER_SELECT");
        }

        #endregion
    }
}