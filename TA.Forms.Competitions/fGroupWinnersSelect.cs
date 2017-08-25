using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using Sortition;

namespace TA.Competitions.Forms
{
    public partial class fGroupWinnersSelect : Form, Localizator.ILocalizableForm
    {
        private GroupPaintersList Painters;
        private RobinOlympic Competition;
        private Dictionary<int, bool> CheckedPlayers = new Dictionary<int, bool>();
        private fGroupWinnersSelect()
        {
            InitializeComponent();
            LocalizeComponents();
            //lstSelectedPlayers.BackColor = WindowSkin.Palette.Colors[0];
        }
        /// <summary>
        /// Подтверждение списка игроков, проходящих в следующий раунд
        /// </summary>
        /// <param name="competition">RobinOlympic Competition</param>
        /// <returns>Список игроков, прошедших в плей-офф</returns>
        internal static CompetitionPlayerInfo[] SelectWinners(RobinOlympic competition, GroupPaintersList groups) 
        {
            fGroupWinnersSelect form = new fGroupWinnersSelect();
            form.Painters = groups;
            form.Competition = competition;
            int player_in_group = competition.KOPlayerCount / competition.GroupCount;
            foreach (GroupPainter painter in groups.Values)
            {
                for (int i = 0; i < player_in_group && i < painter.Players.Length; i++)
                {
                    form.CheckedPlayers.Add(painter.Players[i].Id, true);
                }
            }
            form.pictureControl1.BackColor = WindowSkin.Palette.Colors[0];
            form.pictureControl1.Picture = form.CreatePicture();
            int width = form.Width - form.pictureControl1.Width + form.pictureControl1.Picture.Width + 50;
            if (width > Screen.PrimaryScreen.Bounds.Width - 100)
                width = Screen.PrimaryScreen.Bounds.Width - 100;
            int height = form.Height - form.pictureControl1.Height + form.pictureControl1.Picture.Height + 50;
            if (height > Screen.PrimaryScreen.Bounds.Height - 100)
                height = Screen.PrimaryScreen.Bounds.Height - 100;
            form.Width = width;
            form.Height = height;
            form.lblPlayerCount.Text = String.Format(Localizator.Dictionary.GetString("PERS"), competition.KOPlayerCount);
            form.lblPlayerCount.Left = form.label1.Left + form.label1.Width + 3;
            form.grsdDrawing.SetSeedingOrder(SortitionByRating.GetOlympicSortitionOrder(competition.KOPlayerCount), Seeding.SeedType.Olympic, 0);
            if (form.ShowDialog() == DialogResult.OK) 
            {                
                return form.SelectedPlayers;
            }
            return null;
        }

        private Bitmap CreatePicture() 
        {
            int bmp_width = 0;
            int bmp_height = 0;
            int w,h;            
            foreach (GroupPainter painter in Painters.Values) 
            {
                w = painter.ClientRect.Left + painter.ClientRect.Width;
                h = painter.ClientRect.Top + painter.ClientRect.Height;
                if(bmp_height - 20 < h)
                    bmp_height = h + 20;
                if(bmp_width - 20 < w)
                    bmp_width = w + 20;
            }
            Bitmap bmp = new Bitmap(bmp_width, bmp_height);
            Graphics gr = Graphics.FromImage(bmp);
            Size checkbox_size = WindowSkin.CheckBoxPainter.Unchecked.Size;
            foreach (GroupPainter painter in Painters.Values) 
            {
                painter.Draw(gr);
                int y = painter.Top + GroupPainterSettings.SmallSize.Height * 2 + 1;
                int x = painter.Left + 1;
                int top = painter.Top + GroupPainterSettings.SmallSize.Height * 2 + (GroupPainterSettings.SmallSize.Height - checkbox_size.Height) / 2 + 1;
                int left = painter.Left + (GroupPainterSettings.SmallSize.Width - checkbox_size.Width) / 2 /*+ painter.ClientRect.Width*/;
                foreach (MatchPlayer player in painter.Players) 
                {
                    gr.FillRectangle(new SolidBrush(GroupPainterSettings.GroupColors.Place), x,y, GroupPainterSettings.SmallSize.Width-1, GroupPainterSettings.SmallSize.Height-1);
                    if(CheckedPlayers.ContainsKey(player.Id) && CheckedPlayers[player.Id])
                        gr.DrawImage(WindowSkin.CheckBoxPainter.Checked, left, top);
                    else
                        gr.DrawImage(WindowSkin.CheckBoxPainter.Unchecked, left, top);
                    top += GroupPainterSettings.SmallSize.Height;
                    y += GroupPainterSettings.SmallSize.Height;
                }
            }
            List<CompetitionPlayerInfo> players = new List<CompetitionPlayerInfo>();
            foreach (int playerId in CheckedPlayers.Keys) 
            {
                if (CheckedPlayers[playerId])
                    players.Add(Competition.Players[playerId]);
            }
            /*lstSelectedPlayers.Clear();
            lstSelectedPlayers.AddRange(players);*/
            grsdDrawing.SetPlayersList(players.ToArray(), true);
            UpdateButtons();
            return bmp;
        }

        private void UpdateButtons()
        {
            btnOk.Enabled = grsdDrawing.AllMatchesHasPlayers && grsdDrawing.AllPlayersSeeded;
        }        
        private void pictureControl1_MouseClick(object sender, MouseEventArgs e)
        {
            Point MousePoint = pictureControl1.GetPicturePoint(e.Location);
            //MousePoint.X -= 20; // Смещаем точку на 20px для того, что бы попасть в CheckBox
            //MessageBox.Show(str);
            foreach (GroupPainter painter in Painters.Values) 
            {
                if (painter.In(MousePoint)) 
                {
                    int index = (MousePoint.Y - painter.Top) / GroupPainterSettings.SmallSize.Height - 2;
                    if (index >= 0) 
                    {
                        int playerId = painter.Players[index].Id;
                        if (!CheckedPlayers.ContainsKey(playerId))
                            CheckedPlayers.Add(playerId, true);
                        else
                        {
                            CheckedPlayers[playerId] = !CheckedPlayers[playerId];
                        }
                        pictureControl1.Picture = CreatePicture();
                        return;
                    }                        
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (grsdDrawing.AllMatchesHasPlayers)
                DialogResult = DialogResult.OK;
        }

        private CompetitionPlayerInfo[] SelectedPlayers
        {
            get {
                /*List<CompetitionPlayerInfo> list = new List<CompetitionPlayerInfo>();
                foreach (GroupPainter painter in Painters.Values) 
                {
                    foreach (MatchPlayer player in painter.Players) 
                    {
                        if (CheckedPlayers.ContainsKey(player.Id) && CheckedPlayers[player.Id])
                            list.Add(Competition.Players[player.Id]);
                    }
                }*/
                List<CompetitionPlayerInfo> list = new List<CompetitionPlayerInfo>();
                int[] res = grsdDrawing.GetSeededPlayersIdArray();
                for(int i = 0; i < res.Length;i++)
                {
                    if (Competition.Players.ContainsKey(res[i]))
                        list.Add(Competition.Players[res[i]]);
                    else
                        list.Add(CompetitionPlayerInfo.Dummy);                    
                }
                return list.ToArray();
            }
        }

        private void graphicalSeeding1_AfterPlayerSeed(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnCancel.Text = Localizator.Dictionary.GetString( "CANCEL");
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.label1.Text = Localizator.Dictionary.GetString("CHECK_QUALIFIED_PLAYERS");
            this.label2.Text = Localizator.Dictionary.GetString("PLAYER_NEXT_ROUND");
            this.label3.Text = Localizator.Dictionary.GetString("FIRST_PLAYOFFS");
            this.Text = Localizator.Dictionary.GetString("DRAW_PLAYOFF");
        }

        #endregion
    }
}
