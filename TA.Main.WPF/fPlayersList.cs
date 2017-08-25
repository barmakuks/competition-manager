using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TA.Corel;
using TA.DB.Manager;
using TA.Utils;


namespace TA.Main
{
    public partial class fPlayersList : Form, Localizator.ILocalizableForm
    {
        Dictionary<int, framePlayerRating> GameFrames = new Dictionary<int, framePlayerRating>();
        IntComparer itemComparer = new IntComparer();

        public fPlayersList()
        {
            InitializeComponent();
            LocalizeComponents();
            Left = Screen.PrimaryScreen.Bounds.Left + 15;
            Width = Screen.PrimaryScreen.Bounds.Width - 30;
            Top = Screen.PrimaryScreen.Bounds.Top + 15;
            Height = Screen.PrimaryScreen.Bounds.Height - 60;
            pnlToolBar.BackColor = WindowSkin.Palette.BackColor;
            lvPlayerList.BackColor = WindowSkin.Palette.TextBackColor;
            toolTip.BackColor = WindowSkin.Palette.TextBackColor;
            toolTip.ForeColor = WindowSkin.Palette.ForeColor;
        }
        private void UpdateGrid() 
        {
            lvPlayerList.Clear();
            lvPlayerList.AddRange(Globals.Players.Values);
        }
        private void btnPlayerAdd_Click(object sender, EventArgs e)
        {
            bool res;
            do{
                PlayerInfo info = new PlayerInfo();                
                res = fPlayerInfo.Edit(info);
                if(res)
                {
                }
            } while (res);
            RefreshGrids();
        }
        private void RefreshGrids()
        {
            DatabaseManager.CurrentDb.ReadPlayerList(Globals.Players);
            UpdateGrid();
            foreach (framePlayerRating frame in GameFrames.Values) 
            {
                frame.Rebuild();// UpdateGrid();
            }
        }
        public static void ShowPlayersList() 
        {
            fPlayersList form = new fPlayersList();
            TypeOfSportList games = Globals.Games;
            form.GameFrames.Clear();
#if STANDARD || FEDITION_PLUS || STANDARD_PLUS || FEDITION
//#if FEDITION
            foreach (TypeOfSport sport in games.Values)
                {                    
                    TabPage page = new TabPage(sport.Name);
                    form.tcPlayers.TabPages.Add(page);
                    framePlayerRating frame = framePlayerRating.CreateControl(sport);                    
                    form.GameFrames.Add(form.tcPlayers.TabPages.Count -1, frame);
                    page.Controls.Add(frame);
                    frame.Dock = DockStyle.Fill;
                    frame.UpdateGrid();
                }
#endif
            form.RefreshGrids();
            form.LocateTabButtons();
            form.ShowDialog();
        }

        private void btnPlayerEdit_Click(object sender, EventArgs e)
        {
            if (lvPlayerList.SelectedObject == null)
                return;
            Guid guid = (lvPlayerList.SelectedObject as PlayerInfo).Identifier;
            PlayerInfo info = Globals.Players[guid];
            if (fPlayerInfo.Edit(info))
            {
                RefreshGrids();
            }

        }
        private void lvPlayers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Указываем сортируемую колонку
            itemComparer.ColumnIndex = e.Column;
            //Непосредственно инициируем сортировку
            ((ListView)sender).Sort();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvPlayerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnPlayerEdit_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvPlayerList.SelectedObject == null)
                return;
            Guid guid = (lvPlayerList.SelectedObject as PlayerInfo).Identifier;
            PlayerInfo info = Globals.Players[guid];
            if (WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("ASK_REMOVE_PLAYER_INFO"), Localizator.Dictionary.GetString("REMOVE_PLAYER_INFO"), MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                if (DatabaseManager.CurrentDb.TryToDeletePlayer(info.Id))
                {
                    Globals.Players.Remove(guid);
                    RefreshGrids();
                }
                else 
                {
                    WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("CANNOT_REMOVE_PLAYER_INFO"),Localizator.Dictionary.GetString("REG_REMOVE_ERROR"));
                }
            }
        }

        private void LocateTabButtons() 
        {
            Rectangle rect = tcPlayers.GetTabRect(tcPlayers.TabCount - 1);
            btnAddTab.Left = rect.Left + rect.Width + tcPlayers.Left + 1;
            btnAddTab.Top = tcPlayers.Top + rect.Top + 1;
            btnAddTab.Size = new Size(rect.Height + 4, rect.Height - 1);
            btnDeleteTab.Size = btnAddTab.Size;
            btnDeleteTab.Left = btnAddTab.Left + btnAddTab.Width;
            btnDeleteTab.Top = btnAddTab.Top;
            btnDeleteTab.Visible = tcPlayers.SelectedIndex > 0;
        }
        private void tcPlayers_DoubleClick(object sender, EventArgs e)
        {
            if (tcPlayers.SelectedIndex > 0) 
            {
                TypeOfSport sport = GameFrames[tcPlayers.SelectedIndex].Sport;
                if (fTypeOfSportEdit.Edit(sport, Globals.Games)) 
                {
                    tcPlayers.SelectedTab.Text = sport.Name;
                    LocateTabButtons();
                }                
            }
        }

        private void btnAddTab_Click(object sender, EventArgs e)
        {
            TypeOfSport sport = null;
            if (fTypeOfSportEdit.New(out sport, Globals.Games)) 
            {
                TabPage page = new TabPage(sport.Name);
                tcPlayers.TabPages.Add(page);
                framePlayerRating frame = framePlayerRating.CreateControl(sport);
                GameFrames.Add(tcPlayers.TabPages.Count - 1, frame);
                page.Controls.Add(frame);
                frame.Dock = DockStyle.Fill;
                frame.UpdateGrid();
                tcPlayers.SelectedTab = page;
                LocateTabButtons();
            }
        }


        private void tcPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteTab.Visible = tcPlayers.SelectedIndex > 0;
        }

        private void btnDeleteTab_Click(object sender, EventArgs e)
        {
            if (tcPlayers.SelectedIndex > 0)
            {
                TypeOfSport sport = GameFrames[tcPlayers.SelectedIndex].Sport;
                string str = String.Format(Localizator.Dictionary.GetString("ASK_REMOVE_RATING"), sport.Name);
                if (WindowSkin.MessageBox.Show(str, Localizator.Dictionary.GetString("REMOVE_RATING"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DatabaseManager.CurrentDb.DeleteTypeOfSport(sport.Id))
                    {
                        tcPlayers.TabPages.Remove(tcPlayers.SelectedTab);
                        Globals.Games.Remove(sport.Id);
                        LocateTabButtons();
                    }
                    else
                    {
                        WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("CANNOT_REMOVE_RATING"));
                    }
                }
            }
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.tpgPlayers.Text = Localizator.Dictionary.GetString("PLAYER_LIST");

            this.lvPlayerList.Columns[0].Text = Localizator.Dictionary.GetString("IDENTIFIER");
            this.lvPlayerList.Columns[1].Text = Localizator.Dictionary.GetString("NICKNAME");
            this.lvPlayerList.Columns[2].Text = Localizator.Dictionary.GetString("SURNAME");
            this.lvPlayerList.Columns[3].Text = Localizator.Dictionary.GetString("NAME");
            this.lvPlayerList.Columns[4].Text = Localizator.Dictionary.GetString("PATRONYMIC");
            this.lvPlayerList.Columns[5].Text = Localizator.Dictionary.GetString("COUNTRY");
            this.lvPlayerList.Columns[6].Text = Localizator.Dictionary.GetString("ADDRESS");
            this.lvPlayerList.Columns[7].Text = Localizator.Dictionary.GetString("PHONES");
            this.lvPlayerList.Columns[8].Text = Localizator.Dictionary.GetString("EMAIL");

            this.toolTip.SetToolTip(this.btnDelete, Localizator.Dictionary.GetString("REMOVE_PLAYER_INFO"));
            this.toolTip.SetToolTip(this.btnExit, Localizator.Dictionary.GetString("CLOSE_LIST"));
            this.toolTip.SetToolTip(this.btnEdit, Localizator.Dictionary.GetString("EDIT_REG_INFO"));
            this.toolTip.SetToolTip(this.btnAdd, Localizator.Dictionary.GetString("NEW_PLAYER_INFO"));
            this.toolTip.SetToolTip(this.btnAddTab, Localizator.Dictionary.GetString("NEW_RATING"));
            this.toolTip.SetToolTip(this.btnDeleteTab, Localizator.Dictionary.GetString("REMOVE_RATING"));

            this.Text = Localizator.Dictionary.GetString("PLAYER_LIST");

        }

        #endregion

    }
    class IntComparer : IComparer
    {
        int columnIndex = 0;
        bool sortAscending = true;
        //Это свойство инициализируется при каждом клике на column header'e
        public int ColumnIndex
        {
            set
            {
                //предыдущий клик был на этой же колонке?
                if (columnIndex == value)
                    //да - меняем направление сортировки
                    sortAscending = !sortAscending;
                else
                {
                    columnIndex = value;
                    sortAscending = true;
                }
            }
        }

        private int CompareStrings(string a, string b) 
        {
            return String.Compare(a, b) * (sortAscending ? 1 : -1);
        }
        private int CompareInt(int a, int b)
        {
            if (a < b)
                return sortAscending ? 1 : -1;
            if (a > b)
                return sortAscending ? -1 : 1;
            return 0;
        }

        //здесь непосредственно производится сравнение
        //возвращаемые значения:
        // < 0 если x < y
        // 0 если x = y
        // > 0 если x > y
        public int Compare(object x, object y)
        {            
            string valueX = ((ListViewItem)x).SubItems[columnIndex].Text;
            string valueY = ((ListViewItem)y).SubItems[columnIndex].Text;
            int a, b;
            if (Int32.TryParse(valueX, out a) && Int32.TryParse(valueY, out b))
                return CompareInt(a, b);
            else
                return CompareStrings(valueX, valueY);            
        }
    }
}