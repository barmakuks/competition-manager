using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

using TA.DB.Manager;
using TA.Corel;
using TA.RatingSystem.Builder;

namespace TA.ExIm
{
    internal partial class fExport : Form, Localizator.ILocalizableForm
    {
        public fExport()
        {
            InitializeComponent();
            LocalizeComponents();
            mainTreeView.BackColor = WindowSkin.Palette.TextBackColor;
            mainTreeView.ForeColor = WindowSkin.Palette.ForeColor;
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

        private bool OpenDatabase() 
        {
            TreeNode node = new TreeNode();            
            node.Text = Localizator.Dictionary.GetString("PLAYER_LIST");// "Список игроков";
            
            node.Tag = new PlayerList();
            mainTreeView.Nodes.Add(node);
#if FEDITION || DEBUG           
            node = new TreeNode();
            node.Text = Localizator.Dictionary.GetString("RATING_LISTS");// "Рейтинговые листы";
            mainTreeView.Nodes.Add(node);
            DatabaseManager.CurrentDb.ReadTypeOfSportList(Globals.Games);
            foreach (TypeOfSport sport in Globals.Games.Values)
            {
                TreeNode child = new TreeNode();
                child.Text = sport.Name;
                child.Tag = sport;
                node.Nodes.Add(child);
            }
#endif
            node = new TreeNode();
            node.Text = Localizator.Dictionary.GetString("TOURNAMENTS");// "Турниры";
            node.Tag = 3;
            mainTreeView.Nodes.Add(node);
            TournamentList tourns = new TournamentList();
            DatabaseManager.CurrentDb.ReadTournamentList(tourns);
            CompetitionList comps = new CompetitionList();
            foreach (Tournament tour in tourns.Values)
            {
                TreeNode child = new TreeNode();
                child.Text = String.Format("{0} - {1}", tour.Info.DateBegin.ToString("dd.MM.yyyy"), tour.Info.Name);
                child.Tag = tour;
                node.Nodes.Add(child);
                DatabaseManager.CurrentDb.ReadCompetitionList(tour);
                foreach (Competition comp in tour.Competitions.Values)
                {
                    TreeNode sub_child = new TreeNode();
                    sub_child.Text = comp.Info.Name;
                    sub_child.Tag = comp;
                    DatabaseManager.CurrentDb.ReadCompetitionPlayersList(comp, CompetitionPlayerList.SortByField.SeedNo);
                    DatabaseManager.CurrentDb.ReadCompetitionMatchesList(comp);
                    child.Nodes.Add(sub_child);

                }
            }
            mainTreeView.ExpandAll();
            return true;
        }
        private void ParseTree(TA.ExIm.XmlExporter exporter, TreeNode current_node, TreeNodeCollection nodes)
        {
            if (current_node != null)
            {
                if (current_node.Checked)
                {
                    if (current_node.Tag is PlayerList)
                    {
                        PlayerList players = current_node.Tag as PlayerList;
                        DatabaseManager.CurrentDb.ReadPlayerList(players);
                        exporter.AddPlayers(players.Values.ToArray());                        
                    }
                    if (current_node.Tag is TypeOfSport)
                    {
                        TypeOfSport game = current_node.Tag as TypeOfSport;
                        RatingSystemBuilder rsb = new RatingSystemBuilder();
                        TA.RatingSystem.RatingSystem rs = RatingSystemBuilder.CreateRatingSystem(game.Id, game.Name);
                        exporter.AddRatingList(game, rs.Players.Values.ToArray());                        
                    }
                    if (current_node.Tag is Tournament)
                    {
                        Tournament tour = current_node.Tag as Tournament;
                        List<Competition> comps = new List<Competition>();
                        foreach (TreeNode node in current_node.Nodes)
                        {
                            if (node.Checked && node.Tag is Competition)
                            {
                                comps.Add(node.Tag as Competition);                                
                            }
                        }
                        if (comps.Count > 0)
                            exporter.AddTournament(tour.Info, comps.ToArray());
                    }
                }

            }
            foreach (TreeNode node in nodes)
            {
                if (nodes.Count > 0)
                    ParseTree(exporter, node, node.Nodes);
            }
        }
        private void Export() 
        {
            saveFileDialog.FileName = DateTime.Now.ToString("yyyy-MM-dd");
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;            
            TA.ExIm.XmlExporter exporter = new TA.ExIm.XmlExporter();
            exporter.SetHeaderInfo(DateTime.Now, Guid.NewGuid().ToString());
            ParseTree(exporter, null, mainTreeView.Nodes);
            
            string filename = saveFileDialog.FileName;

            if (saveFileDialog.FilterIndex == 2) 
            {
                filename = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Path.GetFileName(saveFileDialog.FileName), saveFileDialog.DefaultExt));
            }            
            TextWriter writer = new StreamWriter(filename);
            writer.Write(exporter.ToString());
            writer.Close();
            if (saveFileDialog.FilterIndex == 2) 
            {
                Zipper.PackFile(filename, saveFileDialog.FileName);
            }
        }
        
        public static bool ShowExport() 
        {
            fExport form = new fExport();
            form.OpenDatabase();
            form.ShowDialog();
            return true;
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            Text = Localizator.Dictionary.GetString("EXPORT");
            lblCaption.Text = Localizator.Dictionary.GetString("SELECT_DATA_EXPORT");
            btnStartOperation.Text = Localizator.Dictionary.GetString("EXPORT");
            saveFileDialog.Title = Localizator.Dictionary.GetString("EXPORT");
            btnClose.Text = Localizator.Dictionary.GetString("CLOSE");
        }

        #endregion

        private void btnStartOperation_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
