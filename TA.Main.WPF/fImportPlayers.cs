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

namespace TA.Main
{
    public partial class fImportPlayers : Form, Localizator.ILocalizableForm
    {
        private PlayerInfo[] FPlayers = null;
        public fImportPlayers()
        {
            InitializeComponent();
            LocalizeComponents();
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.Text = Localizator.Dictionary.GetString("IMPORT_PLAYERS");

            this.lvPlayerList.Columns[0].Text = Localizator.Dictionary.GetString("IDENTIFIER");
            this.lvPlayerList.Columns[1].Text = Localizator.Dictionary.GetString("NICKNAME");
            this.lvPlayerList.Columns[2].Text = Localizator.Dictionary.GetString("SURNAME");
            this.lvPlayerList.Columns[3].Text = Localizator.Dictionary.GetString("NAME");
            this.lvPlayerList.Columns[4].Text = Localizator.Dictionary.GetString("PATRONYMIC");
            this.lvPlayerList.Columns[5].Text = Localizator.Dictionary.GetString("COUNTRY");
            this.lvPlayerList.Columns[6].Text = Localizator.Dictionary.GetString("ADDRESS");
            this.lvPlayerList.Columns[7].Text = Localizator.Dictionary.GetString("PHONES");
            this.lvPlayerList.Columns[8].Text = Localizator.Dictionary.GetString("EMAIL");
            this.cbxOnlyNew.Text = Localizator.Dictionary.GetString("IMPORT_ONLY_NEW");
            this.cbxUpdateInfo.Text = Localizator.Dictionary.GetString("IMPORT_UPDATE_INFO");
            this.btnStart.Text = Localizator.Dictionary.GetString("IMPORT_BEGIN");
            this.btnClose.Text = Localizator.Dictionary.GetString("CLOSE");
        }

        public static bool Import(string xml_file) 
        {
            PlayerInfo[] players = null;
            if (ImportPlayers.ImportXml(xml_file, out players))
            {
                fImportPlayers form = new fImportPlayers();
                form.FPlayers = players;
                form.UpdatePlayersList();
                form.ShowDialog();
                return true;
            }
            else 
            {
                WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("IS_NOT_PLAYERS_FILE"));
            }
            return false;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxOnlyNew_CheckedChanged(object sender, EventArgs e)
        {
            cbxUpdateInfo.Enabled = !cbxOnlyNew.Checked;
            UpdatePlayersList();
        }

        private void UpdatePlayersList()
        {
            lvPlayerList.Clear();
            if (cbxOnlyNew.Checked)
            {
                foreach (PlayerInfo player in FPlayers) 
                {
                    if (!Globals.Players.ContainsKey(player.Identifier))
                        lvPlayerList.Add(player);                    
                }
            }
            else 
            {
                lvPlayerList.AddRange(FPlayers);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                prbProgress.Value = 0;
                prbProgress.Maximum = lvPlayerList.ObjectCount;
                prbProgress.Visible = true;
                foreach (PlayerInfo player in lvPlayerList.ObjectsArray)
                {
                    if (Globals.Players.ContainsKey(player.Identifier))
                        player.Id = Globals.Players[player.Identifier].Id;
                    TA.DB.Manager.DatabaseManager.CurrentDb.PlayerInfoSave(player);
                    prbProgress.Value += 1;
                    Application.DoEvents();
                }
            }
            finally {
                prbProgress.Visible = false;
            }
            TA.DB.Manager.DatabaseManager.CurrentDb.ReadPlayerList(Globals.Players);
            WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("IMPORT_COMPLETE"));
            Close();
        }
    }
}
