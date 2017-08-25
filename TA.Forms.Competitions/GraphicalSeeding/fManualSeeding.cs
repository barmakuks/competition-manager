using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TA.Corel;

namespace Seeding
{
    public partial class fManualSeeding : Form, Localizator.ILocalizableForm
    {
        private PlayersList FSource = new PlayersList();
        private PlayersList FDest = new PlayersList();
        private int[] FFreeValues = null;
        private int prev_value = 0;
        private void UpdateSourceGrid() 
        {
            grdSource.Clear();
            grdSource.AddRange(FSource.Values);
        }
        private void UpdateDestGrid()
        {
            grdDest.Clear();
            foreach (PlayerItem player in FDest.Values)
            {
                grdDest.Add(player);
            }
        }
        private void UpdateGrids() 
        {
            UpdateSourceGrid();
            UpdateDestGrid();
        }
        public fManualSeeding()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        
        /// <summary>
        /// Вызов диалога жеребьевки игроков
        /// </summary>
        /// <param name="players">Список игроков, у каждого игрока есть поле SeedNo, которое будет заполнено после жеребьевки
        /// </param>
        /// <returns>True, если рассеивание завершено</returns>
        internal static bool ShowSeedDialog(PlayerItem[] players) 
        {
            fManualSeeding form = new fManualSeeding();
            form.FSource.Clear();
            foreach (PlayerItem player in players)
            {
                form.FSource.Add(player.Id, player.Clone() as PlayerItem);
            }
            form.FFreeValues = new int[players.Length + 1];
            for (int i = 0; i < form.FFreeValues.Length; i++)
            {
                form.FFreeValues[i] = 0;
            }
            form.ibxDrawNo.MinimumValue = 1;
            form.ibxDrawNo.MaximumValue = players.Length;
            form.FDest.Clear();
            form.UpdateGrids();
            form.btnOk.Enabled = false;
            form.grdSource.SelectedIndex = 0;
            if (form.ShowDialog() == DialogResult.OK) 
            {
                foreach (PlayerItem player in form.FDest.Values) 
                {
                    players[player.Id].SeedNo = player.SeedNo;
                }
                return true;
            }
            return false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (grdSource.SelectedIndex == -1)
                return;
            int seedNo = Convert.ToInt32(ibxDrawNo.Value);
            PlayerItem player;
            if (FDest.ContainsKey(seedNo))
                return;
            else
            {
                player = (PlayerItem)(grdSource.SelectedObject);
                player.SeedNo = seedNo;
                FFreeValues[seedNo] = 1;
                FDest.Add(seedNo, player);
                grdSource.RemoveAt(grdSource.SelectedIndex);
                int next_value = FindNextFreeValue(prev_value, ibxDrawNo.Value);
                if (next_value != 0)
                    ibxDrawNo.Value = next_value;
                UpdateDestGrid();
            }
            btnNext.Enabled = grdSource.ObjectCount != 0;
            btnSkip.Enabled = grdSource.ObjectCount != 0;
            ibxDrawNo.Enabled = grdSource.ObjectCount != 0;
            btnOk.Enabled = grdSource.ObjectCount == 0 && grdDest.ObjectCount != 0;
        }

        private void grdSource_SelectionChanged(object sender, EventArgs e)
        {
            if (grdSource.SelectedIndex != -1)
            {
                ibxDrawNo.Enabled = true;
                btnNext.Enabled = true;
                btnSkip.Enabled = true;
                btnOk.Enabled = false;
                if(grdSource.SelectedObject != null)
                {
                    lblCurrentPlayer.Text = (grdSource.SelectedObject as PlayerItem).Name;
                }
                else
                lblCurrentPlayer.Text = "";
            }
            else
            {
                lblCurrentPlayer.Text = "";
                ibxDrawNo.Enabled = false;
                btnNext.Enabled = false;
                btnSkip.Enabled = false;
                btnOk.Enabled = true;
            }
            

        }

        private void txtSeedNo_ValueChanged(object sender, EventArgs e)
        {
            int new_value = FindNextFreeValue(prev_value, ibxDrawNo.Value);
            if (new_value != 0)
            {
                prev_value = ibxDrawNo.Value;
                ibxDrawNo.Value = new_value;
            }
            else 
            {
                ibxDrawNo.Value = prev_value;
            }
        }

        private int FindNextFreeValue(decimal prev_value, decimal current_value)
        {
            int currentNo = Convert.ToInt32(current_value);
            int index = currentNo;
            while (FFreeValues[index] != 0)
            {
                if (index == currentNo)
                {
                    if (prev_value > currentNo)
                        index--;
                    else
                        index++;
                }
                else 
                {
                    if (index > currentNo)
                        index++;
                    if (index < currentNo)
                        index--;
                }
                if (index >= FFreeValues.Length)
                    index = currentNo - 1;
            }
            return index;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            if (grdSource.SelectedIndex == -1)
                return;
            int index = grdSource.SelectedIndex;
            if(index < grdSource.ObjectCount - 1)
                grdSource.SelectedIndex += 1;
            else
                grdSource.SelectedIndex = 0;
        }

        private void grdDest_OnDrawItem(object Sender, WindowSkin.ObjectListItemArgs args)
        {            
            if (args.Item is CompetitionPlayerInfo) 
            {
                Rectangle rect = args.Bounds;
                rect.Width = 20;
                CompetitionPlayerInfo player = args.Item as CompetitionPlayerInfo;
                args.Graphics.DrawString(player.SeedNo.ToString(), Font, args.TextBrush, rect, args.StringFormat);
                rect = args.Bounds;
                rect.Offset(20, 0);
                rect.Width -= 20;
                args.Graphics.DrawString(player.ToString(), Font, args.TextBrush, rect, args.StringFormat);
            }
            else
            {

                args.Graphics.DrawString(args.Item.ToString(), Font, args.TextBrush, args.Bounds, args.StringFormat);
            }
        }


        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.label3.Text = Localizator.Dictionary.GetString("SELECTED_PLAYER");
            this.label5.Text = Localizator.Dictionary.GetString("DRAW_NO");
            this.label1.Text = Localizator.Dictionary.GetString("SOURCE_PLAYERS");
            this.label2.Text = Localizator.Dictionary.GetString("DRAW_RESULTS");

            this.grdSource.Columns["Name"].Text = Localizator.Dictionary.GetString("PLAYER");

            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.btnOk.Text = Localizator.Dictionary.GetString("APPLY");
            this.btnNext.Text = Localizator.Dictionary.GetString("NEXT");
            this.btnSkip.Text = Localizator.Dictionary.GetString("SKIP");

            this.grdDest.Columns["SeedNo"].Text = Localizator.Dictionary.GetString("DRAW_NO");
            this.grdDest.Columns["Name"].Text = Localizator.Dictionary.GetString("PLAYER");

            this.Text = Localizator.Dictionary.GetString("MANUAL_DRAW");
        }

        #endregion
    }
}