using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RSystem
{
    public partial class RSControl : UserControl
    {
        #region Приватные члены класса
        /// <summary>
        /// Максимальное количество отображаемых колонок
        /// </summary>
        private int VisibleColCount
        {
            get
            {
                return (Width - ColWidth_P - ColWidth_R) / ColWidth_C;
            }
        }
        private int VisibleRowCount {
            get {
                return (Height - Height_Footer - Height_Header) / Height_Row;
            }
        }
        private int ViewColFrom {
            get {
                if (hScrollBar.Visible)
                    return hScrollBar.Value;
                else
                    return 0;
            }
        }
        private int ViewRowFrom 
        {
            get {
                if (vScrollBar.Visible)
                    return vScrollBar.Value;
                else
                    return 0;
            }
        }
        private Player[] FPlayers;
        private RatingSystem RS = null;
        private DateTime FRatingDate = DateTime.Now;
        #endregion

        #region Размеры колонок и строк
        /// <summary>
        /// Ширина колонки игроков        
        /// </summary>        
        private int ColWidth_P = 120; 
        /// <summary>
        /// Ширина колонки турниров 
        /// </summary>
        private int ColWidth_C = 70; 
        /// <summary>
        /// Ширина колонки текущего рейтинга
        /// </summary>
        private int ColWidth_R = 100; 
        /// <summary>
        /// Высота заголовка
        /// </summary>
        private int Height_Header = 54;
        /// <summary>
        /// высота строки
        /// </summary>
        private int Height_Row = 17;
        /// <summary>
        /// Высота футера
        /// </summary>
        private int Height_Footer = 13;

        /// <summary>
        /// Очертания подсказки
        /// </summary>
        private Point[] points = new Point[]{new Point(-1, 56), new Point(3 ,48), new Point(3 ,4),
                                            new Point(7 ,0), new Point(127 ,0), new Point(131 ,4),
                                            new Point(131 ,48), new Point(126 ,53), new Point(8 ,52)};
        private Point[] draw_points = new Point[]{new Point(0, 55), new Point(3 ,48), new Point(3 ,4),
                                            new Point(7 ,0), new Point(126 ,0), new Point(130 ,4),
                                            new Point(130 ,48), new Point(126 ,52), new Point(7 ,52),
                                            new Point(0,55)};
        /*private Point[] points = new Point[]{new Point(0,30), new Point(8,22), new Point(8,3), 
                                             new Point(11,0), new Point(131,0), new Point(134,3), 
                                             new Point(134,56), new Point(130,60), new Point(12,60), 
                                             new Point(8,56), new Point(8,38), new Point(0,30)};*/


        #endregion

        #region Области рисования
        /// <summary>
        /// Область заголовков турниров
        /// </summary>
        private Rectangle Rect_Header_C = new Rectangle();
        /// <summary>
        /// Область списка игроков
        /// </summary>
        private Rectangle Rect_Players = new Rectangle();
        /// <summary>
        /// Область результатов
        /// </summary>
        private Rectangle Rect_Results = new Rectangle();
        /// <summary>
        /// Область текущего рейтинга
        /// </summary>
        private Rectangle Rect_Rating = new Rectangle();
        /// <summary>
        /// Область футера
        /// </summary>
        private Rectangle Rect_Footer = new Rectangle();
        /// <summary>
        /// Bitmap для фонового рисования
        /// </summary>
        private Bitmap background = null;
        #endregion

        #region Форматирование строк
        private StringFormat sf_left = new StringFormat();
        private StringFormat sf_right = new StringFormat();
        private StringFormat sf_center = new StringFormat();
        #endregion

        #region Цвета для рисования
        #region Общие
        /// <summary>
        /// Цвет линий
        /// </summary>
        public Color LineColor
        {
            get
            {
                return FLinePen.Color;
            }
            set
            {
                FLinePen.Color = value; Invalidate();
            }
        }
        private Pen FLinePen = new Pen(Color.LightGray);            
        #endregion
        #region Заголовок
            /// <summary>
            /// Цвет фона заголовка
            /// </summary>
            public Color HeaderBkColor
            {
                get
                {
                    return FHeaderBkBrush.Color;
                }
                set
                {
                    FHeaderBkBrush.Color = value;
                }
            }
            private SolidBrush FHeaderBkBrush = new SolidBrush(Color.Green);
            /// <summary>
            /// Цвет шрифта заголовка
            /// </summary>
            public Color HeaderColor {
                get { return FHeaderBrush.Color; }
                set { FHeaderBrush.Color = value; }
            }
            private SolidBrush FHeaderBrush = new SolidBrush(Color.Black);
        #endregion
        #region Список игроков
        /// <summary>
        /// Цвет фона списка игроков
        /// </summary>
        public Color PlayersBkColor 
        {
            get { return FPlayersBrush.Color; }
            set { FPlayersBrush.Color = value; Invalidate(); }
        }
        private SolidBrush FPlayersBrush = new SolidBrush(Color.LightBlue);
        /// <summary>
        /// Цвет шрифта списка игроков
        /// </summary>
        public Color PlayersForeColor {
            get { return FPlayersFontBrush.Color; }
            set { FPlayersFontBrush.Color = value; Invalidate(); }
        }
        private SolidBrush FPlayersFontBrush = new SolidBrush(Color.Black);
        #endregion
        #region Колонка "Текущий рейтинг"
        public Color RatingBkColor 
        {
            get { return FRatingBkBrush.Color; }
            set { FRatingBkBrush.Color = value; Invalidate(); }
        }
        private SolidBrush FRatingBkBrush = new SolidBrush(Color.LightBlue);
        public Color RatingForeColor {
            get { return FRatingFontBrush.Color; }
            set { FRatingFontBrush.Color = value; Invalidate(); }
        }
        private SolidBrush FRatingFontBrush = new SolidBrush(Color.Black);
        #endregion
        #region Footer
        #endregion
        #region Область результатов
        /// <summary>
        /// Цвет шрифта Дельты
        /// </summary>
        public Color DeltaColor
        {
            get
            {
                return FDeltaBrush.Color;
            }
            set
            {
                FDeltaBrush.Color = value;
            }
        }
        private SolidBrush FDeltaBrush = new SolidBrush(Color.Green);
        /// <summary>
        /// Цвет шрифта Штрафа за пропуски
        /// </summary>
        public Color PenaltyColor
        {
            get
            {
                return FPenaltyBrush.Color;
            }
            set
            {
                FPenaltyBrush.Color = value;
            }
        }
        private SolidBrush FPenaltyBrush = new SolidBrush(Color.Red);
        public Color ResultsBkColor 
        {
            get { return FResultBkBrush.Color; }
            set { FResultBkBrush.Color = value; Invalidate(); }
        }
        private SolidBrush FResultBkBrush = new SolidBrush(Color.White);

        #endregion
        #endregion

        #region Public Methods
        /// <summary>
        /// Текущая рейтинговая система
        /// </summary>
        public RatingSystem RatingSystem
        {
            get
            {
                return RS;
            }
        }
        public RSControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            sf_left.LineAlignment = StringAlignment.Center;
            sf_right.LineAlignment = StringAlignment.Center;
            sf_center.LineAlignment = StringAlignment.Center;

            sf_left.Alignment = StringAlignment.Near;
            sf_right.Alignment = StringAlignment.Far;
            sf_center.Alignment = StringAlignment.Center;

            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(points);
            pnlInfo.Region = new Region(path);
            /*points[4].X -= 1;
            points[5].X -= 1;
            points[6].X -= 1;
            points[7].Y -= 1;
            points[8].X -= 1;
            points[8].Y -= 1;*/
        }
        /// <summary>
        /// Открывает и обновляет рейтинговую систему
        /// </summary>
        /// <param name="GameTypeId">Id рейтинговой системы</param>
        public void Open(int GameTypeId)
        {
            RS = new RatingSystem(GameTypeId);
            Players current_rating = RatingSystem.GetPlayersRating(GameTypeId, FRatingDate);
            FPlayers = new Player[current_rating.Count];
            int i = 0;
            foreach (Player player in current_rating.Values)
            {
                FPlayers[i] = player;
                i++;
            }
            /*FPlayers = new Player[RS.Players.Count];
            int i = 0;
            foreach (Player player in RS.Players.Values)
            {
                FPlayers[i] = player;
                i++;
            }*/
            SetScrollBars();
        }
        #endregion

        #region Implementation
        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLines(Pens.Black, draw_points);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);                        
            if (background == null)
                background = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(background);
            gr.FillRectangle(FPlayersBrush, Rect_Players);
            gr.FillRectangle(FResultBkBrush, Rect_Results);
            gr.FillRectangle(FHeaderBkBrush, Rect_Header_C);
            gr.FillRectangle(FRatingBkBrush, Rect_Rating);
            gr.FillRectangle(Brushes.WhiteSmoke, Rect_Footer);
            gr.DrawString("Список игроков", Font, FPlayersFontBrush, new Rectangle(0, 0, ColWidth_P, Height_Header), sf_center);
            Rectangle header_caption_rect = new Rectangle(ColWidth_P, 0, Rect_Results.Width, Height_Header / 2);
            gr.DrawRectangle(FLinePen, header_caption_rect);
            gr.DrawString("Результаты участия в турнирах", Font, FPlayersFontBrush, header_caption_rect, sf_center);
            
            
            
            if (RS != null)
            {   
                
                Rectangle player_rect = new Rectangle(0, Height_Header, ColWidth_P, Height_Row);
                Rectangle rating_rect = new Rectangle(Width - ColWidth_R, Height_Header, ColWidth_R, Height_Row);
                Rectangle comp_rect = new Rectangle(new Point(ColWidth_P, Height_Header),new Size(ColWidth_C, Height_Row) );
                
                for(int p = ViewRowFrom; p < FPlayers.Length && p < ViewRowFrom + VisibleRowCount; p++) 
                {
                    Player player = FPlayers[p];
                    gr.DrawRectangle(FLinePen, player_rect);
                    gr.DrawRectangle(FLinePen, new Rectangle(player_rect.Location, new Size(Width, Height_Row)));
                    gr.DrawString(player.Name, Font, FPlayersFontBrush, player_rect, sf_left);

                    comp_rect.X = ColWidth_P + 1;
                    comp_rect.Y = player_rect.Y;
                    Rectangle header_rect = new Rectangle(comp_rect.X, Height_Header / 2, ColWidth_C, Height_Header / 2);
                    for (int i = ViewColFrom; (i < RS.Competitions.Count) && (i - ViewColFrom < VisibleColCount); i++) 
                    {
                        gr.DrawRectangle(FLinePen, header_rect);
                        gr.DrawString(RS.Competitions[i].Date.ToString("dd.MM.yyyy"), Font, FHeaderBrush, header_rect, sf_center);
                        header_rect.Offset(header_rect.Width, 0);
                        gr.DrawRectangle(FLinePen, comp_rect);
                        if (RS.Competitions[i].Results.ContainsKey(player.Id)) 
                        {
                            CompetitionResult res = RS.Competitions[i].Results[player.Id];
                            if(res.Penalty != 0)
                                gr.DrawString((-res.Penalty).ToString(), Font, FPenaltyBrush, comp_rect, sf_left);
                            string delta = res.Delta.ToString();
                            if(res.Delta > 0)
                                delta = "+" + delta;
                            gr.DrawString(delta, Font, FDeltaBrush, comp_rect, sf_right);
                        }
                        comp_rect.Offset(comp_rect.Width, 0);
                    }
                    gr.FillRectangle(FRatingBkBrush, rating_rect);
                    gr.DrawRectangle(FLinePen, rating_rect);
                    gr.DrawString(player.Rating.ToString(), Font, FRatingFontBrush, rating_rect, sf_left);
                    player_rect.Offset(0, player_rect.Height);
                    rating_rect.Offset(0, rating_rect.Height);
                }
            }
            Rectangle rating_header_rect = new Rectangle(Width - ColWidth_R, 0, ColWidth_R, Height_Header);
            gr.FillRectangle(FRatingBkBrush, rating_header_rect);
            gr.DrawRectangle(FLinePen, rating_header_rect);
            string date_str = String.Format("Рейтинг на {0}", FRatingDate.ToString("dd.MM.yyyy"));
            gr.DrawString(date_str, Font, FRatingFontBrush, rating_header_rect, sf_center);
            //gr.DrawString(hScrollBar.Value.ToString(), Font, FRatingFontBrush, rating_header_rect, sf_center);

            e.Graphics.DrawImage(background, 0, 0, Width, Height);
        }
        private bool MouseToCell(Point aLocation, out Point aResult) 
        {
            if (!Rect_Results.Contains(aLocation)) 
            {
                aResult = Point.Empty;
                return false;
            }
            aResult = new Point((aLocation.X - Rect_Results.X) / ColWidth_C + ViewColFrom, (aLocation.Y - Rect_Results.Y) / Height_Row + ViewRowFrom);
            return true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (RS == null)
                return;
            Point cell;
            if (MouseToCell(e.Location, out cell) && (RS.Players.Count > cell.Y) && (RS.Competitions.Count > cell.X) && (cell.X - ViewColFrom < VisibleColCount))
            {
                Point loc = Rect_Results.Location;
                loc.Offset((cell.X - ViewColFrom + 1) * ColWidth_C - ColWidth_C / 2, (cell.Y - ViewRowFrom) * Height_Row + 2 - pnlInfo.Height);
                //lblCellInfo.Text = String.Format("{0}x{1}", cell.X, cell.Y);
                pnlInfo.Location = loc;
                int playerId = FPlayers[cell.Y].Id;
                Competition comp = RS.Competitions[cell.X];
                if (comp.Results.ContainsKey(playerId))
                {
                    CompetitionResult res = comp.Results[playerId];
                    lblInfoRatingBegin.Text = res.RatingBegin.ToString();
                    lblInfoDelta.Text = res.Delta.ToString();
                    lblInfoPenalty.Text = (res.Penalty == 0) ? "-" : res.Penalty.ToString();
                    lblInfoRating.Text = (res.RatingBegin + res.Delta).ToString();
                    pnlInfo.Visible = true;
                    pnlInfo.BringToFront();
                }
                else 
                {
                    pnlInfo.Visible = false;
                }
            }
            else 
            {
                pnlInfo.Visible = false;
            }

        }
        protected override void OnResize(EventArgs e)
        {
            //base.OnResize(e);
            Rect_Header_C = new Rectangle(ColWidth_P, 0, Width - ColWidth_P - ColWidth_R, Height_Header);
            Rect_Results = new Rectangle(ColWidth_P, Height_Header, Rect_Header_C.Width, Height - Height_Header - Height_Footer);
            Rect_Players = new Rectangle(0, 0, ColWidth_P, Height);
            Rect_Rating = new Rectangle(Width - ColWidth_R, 0, ColWidth_R, Height);
            Rect_Footer = new Rectangle(ColWidth_P, Height - Height_Footer, Width - ColWidth_P - ColWidth_R, Height_Footer);
            hScrollBar.Location = Rect_Footer.Location;
            hScrollBar.Size = new Size(Rect_Footer.Width, Rect_Footer.Height);
            vScrollBar.Location = new Point(Width - vScrollBar.Width, Height_Header);
            vScrollBar.Height = Height - Height_Header - Height_Footer;
            if (RS == null)
            {
                hScrollBar.Visible = false;
                vScrollBar.Visible = false;
            }
            else 
            {
                SetScrollBars();
            }
            background = new Bitmap(Width, Height);
            Invalidate();
        }
        private void SetScrollBars() 
        {
            // Устанавливаем параметры горизонтального ScrollBar
            hScrollBar.Visible = VisibleColCount < RS.Competitions.Count;
            if (hScrollBar.Visible)
            {
                hScrollBar.Maximum = RS.Competitions.Count - VisibleColCount;
                if (VisibleColCount > RS.Competitions.Count - hScrollBar.Value)
                    hScrollBar.Value = RS.Competitions.Count - hScrollBar.Value;

            }
            else
            {
                hScrollBar.Value = 0;
            }
            // Устанавливаем параметры вертикального ScrollBar
            vScrollBar.Visible = VisibleRowCount < RS.Players.Count;
            if (vScrollBar.Visible)
            {
                vScrollBar.Maximum = RS.Players.Count - VisibleRowCount;
                if (VisibleColCount > RS.Players.Count - vScrollBar.Value)
                    vScrollBar.Value = RS.Players.Count - vScrollBar.Value;
            }
            else
            {
                vScrollBar.Value = 0;
            }
        }
        #endregion

        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
