using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public partial class fGroupEditor : Form, Localizator.ILocalizableForm
    {
        protected Dictionary<int, MatchPainter> FMatchPainters = new Dictionary<int,MatchPainter>();
        private MatchList Matches = null;
        private Size FBitmapSize = new Size();
        private bool ReadOnly = false;

        public static void Edit(MatchList matches, bool readOnly) 
        {
            fGroupEditor form = new fGroupEditor();
            form.SetMatches(matches);
            form.ReadOnly = readOnly;
            form.Height = Math.Min(form.pictMain.Picture.Height + 100, Screen.PrimaryScreen.WorkingArea.Height - 100);
            form.ShowDialog();
        }
        public fGroupEditor()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public void SetMatches(MatchList matches)
        {
            Matches = matches;
            CreateGrid();
            UpdatePicture();
        }
        public void CreateGrid()
        {
            int ROUND_OFFSET = 20;
            int OFFSET = 4;
            Point round_left_top = new Point(30, 0);
            int match_top = 0;

            FBitmapSize.Height = match_top;
            FBitmapSize.Width = 0;

            Size LABEL_SIZE = new Size(SwissMatchPainter.Size.Width, SwissMatchPainter.Size.Height);

            int current_round = 0;
            FMatchPainters.Clear();
            foreach (MatchInfo match in Matches.Values)
            {
                if (current_round < match.Label.Round) 
                {
                    match_top += ROUND_OFFSET;
                    RoundLabelPainter label_painter = new RoundLabelPainter(String.Format(Localizator.Dictionary.GetString("ROUND_INT"), match.Label.Round));
                    label_painter.TopF = match_top;
                    label_painter.Left = round_left_top.X;
                    FBitmapSize.Width = Math.Max(FBitmapSize.Width, Convert.ToInt32(label_painter.Left) + LABEL_SIZE.Width + 50);
                    current_round = match.Label.Round;
                    FMatchPainters.Add(match.Id + 10000 + current_round, label_painter);
                    match_top += label_painter.ClientRect.Height;
                }
                match_top += OFFSET;
                SwissMatchPainter painter = new SwissMatchPainter();
                painter.TopF = match_top;
                FBitmapSize.Height = Math.Max(FBitmapSize.Height, Convert.ToInt32(painter.TopF) + 50);
                painter.Left = round_left_top.X;
                painter.Match = match;
                painter.OnAfterEdit += new OnMatchPainterEvent(AfterMatchEdit);
                FMatchPainters.Add(painter.Match.Id, painter);
                FBitmapSize.Width = painter.ClientRect.Width + ROUND_OFFSET * 2;
                match_top += painter.ClientRect.Height;
            }
        }
        public Bitmap GetPicture(Brush backBrush)
        {            
            Bitmap bmp = new Bitmap(FBitmapSize.Width, FBitmapSize.Height);
            Graphics gr = Graphics.FromImage(bmp);
            if (backBrush != null)
            {
                gr.FillRectangle(backBrush, 0, 0, bmp.Width, bmp.Height);
            }
            foreach (MatchPainter painter in FMatchPainters.Values)
            {
                painter.Draw(gr);
            }
            return bmp;
        }
        protected virtual bool EditMatch(MatchInfo match, bool readOnly)
        {
            return fSwissMatchEdit.Edit(match, readOnly);
        }
        private void AfterMatchEdit(MatchPainter aMatchView)
        {
            UpdatePicture();
        }
        private void OnMatchEdit(Point point)
        {
            foreach (MatchPainter painter in FMatchPainters.Values)
            {
                if (painter.In(point))
                {
                    if (painter.Match.PlayerA.Id == -1 || painter.Match.PlayerB.Id == -1)
                        return;
                    bool read_only = ReadOnly;
                    if (EditMatch(painter.Match, read_only))
                    {
                        Invalidate();
                        painter.UpdateChildren();
                        if (painter.OnAfterEdit != null)
                            painter.OnAfterEdit(painter);
                        UpdatePicture();
                        TA.DB.Manager.DatabaseManager.CurrentDb.WriteMatch(painter.Match, 1);
                    }
                    pictMain.Refresh();//
                }
            }
        }

        private void UpdatePicture()
        {
            pictMain.BackColor = Color.White;
            pictMain.Picture = GetPicture(null);
        }

        private void pictMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point MousePoint = new Point(e.X - 10, e.Y - 10);
            OnMatchEdit(MousePoint);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }



        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnOk.Text = Localizator.Dictionary.GetString("CLOSE");
            this.Text = Localizator.Dictionary.GetString("MATCHES_IN_GROUP");
        }

        #endregion
    }
}
