using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;

namespace Seeding
{
    public enum SortOrder { NoOrder, Name, Rating, Random }
    public enum SeedType { Matches, Groups, Olympic}
    public partial class GraphicalSeeding : UserControl
    {
        private const int WHEEL_DELTA = 120;

        #region PRIVATE MEMBERS
        private int DraggedIndex = -1;
        private Point DraggedLocation = Point.Empty;
        private Point DraggedOffset = Point.Empty;
        private PlayersList FPlayers = new PlayersList();
        private SeedList FSeeds = new SeedList();
        private bool FShowBorder = false;
        private bool FShowRating = false;
        private SortOrder FSortOrder = SortOrder.NoOrder;
        private int MaxVisiblePlayers
        {
            get
            {
                return (Height - PlayersLocation.Y * 2) / ItemSize.Height + 1;
            }
        }
        private int MaxVisibleSeeds
        {
            get
            {
                return ((Height - SeedsLocation.Y * 2) / ItemSize.Height + 1) * 2;
            }
        }
        private Point PlayersLocation = new Point(12, 2);
        private Point SeedsLocation = new Point(200, 2);
        private PlayersList Players { get { return FPlayers; } }
        private SeedList Seeds { get { return FSeeds; } }

        #endregion

        #region PUBLIC STATIC 
        public static Color BackColorEmpty = WindowSkin.Palette.Colors[0];// Color.White;
        public static Color BackColorNotEmpty = WindowSkin.Palette.Colors[1];//Color.LightGray;
        public static Color BackColorOver = Color.Yellow;
        public static Color BorderColor = WindowSkin.Palette.Colors[8]; //Color.Black;
        public static Color TextColor = WindowSkin.Palette.Colors[10]; //Color.Black;
        public static Color EmptyTextColor = WindowSkin.Palette.Colors[6]; //Color.Black;

        public static Size ItemSize { get { return new Size(120, 18); } }
        public static Font ItemFont = new Font(FontFamily.GenericSansSerif, ItemSize.Height / 2 - 1, FontStyle.Regular);
        public static Font RatingFont = new Font(FontFamily.GenericSansSerif, ItemSize.Height / 2 - 2, FontStyle.Regular);
        #endregion

        #region PUBLIC PROPERTIES
        public bool AllMatchesHasPlayers
        {
            get
            {
                int index = 0;
                bool flag = false;
                foreach (SeedItem seed in Seeds.Values)
                {
                    if (index % 2 == 0)
                        flag = seed.Id > 0;
                    else
                        if (!flag && seed.Id <= 0)
                            return false;
                    index++;
                }
                return true;
            }
        }
        public bool AllPlayersSeeded
        {
            get
            {
                foreach (PlayerItem player in Players.Values)
                {
                    if (player.SeedNo <= 0)
                        return false;
                }
                return true;
            }
        }
        public int PlayersInGroup 
        {
            get {
                return Seeds.PlayersInGroup;
            }
            set {
                Seeds.PlayersInGroup = value;                
            }
        }
        #endregion

        #region PUBLISHED PROPERTIES
        [Browsable(true)]
        [DefaultValue(SortOrder.NoOrder)]
        [Description("Порядок соортировки исходного списка игроков")]
        public SortOrder SortBy
        {
            get
            {
                return FSortOrder;
            }
            set
            {
                FSortOrder = value;
                FPlayers.SortBy = value;
            }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Отображать рамку")]
        public bool ShowBorder
        {
            get {
                return FShowBorder;
            }
            set {
                FShowBorder = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [Description("true - Отобажать рейтинг рядом с фамилией игрока")]
        public bool ShowRating
        {
            get { return FShowRating; }
            set
            {
                FShowRating = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(SeedType.Matches)]
        [Description("Вид турнирной сетки")]
        public SeedType Type {
            get { return Seeds.Type; }
        }

        #endregion

        //CONSTRUCTOR
        public GraphicalSeeding()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, false);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.UserMouse, true);
        }

        #region PRIVATE FUNCTIONS
        private void sbLeft_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        private int GetLeftIndex(Point point)
        {
            int index = 0;
            Rectangle rect = new Rectangle(PlayersLocation, ItemSize);
            foreach (PlayerItem player in FPlayers.Players)
            {
                if (index >= sbLeft.Value)
                {
                    if (rect.Contains(point))
                    {
                        if (player.SeedNo <= 0)
                        {
                            DraggedOffset = new Point(rect.Left - point.X, rect.Top - point.Y);
                            return player.Id;
                        }
                        else
                            return -1;
                    }

                    rect.Offset(0, rect.Height);
                }
                index++;
            }
            return -1;
        }
        private int GetSeedPlace(Point location)
        {
            Point loc = new Point(location.X, location.Y);
            loc.Offset(-SeedsLocation.X, -SeedsLocation.Y);
            foreach (SeedItem seed in FSeeds.Values)
            {
                if(seed.In(loc, sbRight.Value))
                {
                    if (DraggedIndex == -1)
                        DraggedOffset = new Point(seed.Location.X - loc.X, seed.Location.Y - loc.Y - sbRight.Value);
                    return seed.SeedNo;
                }
            }
            return -1;
        }
        private void TryToPlaceDraggedObject(Point location)
        {
            try
            {
                if (DraggedIndex == -1)
                    return;
                int seedPlace = GetSeedPlace(location);
                if (seedPlace > -1)
                {
                    if (FSeeds[seedPlace].Id > -1)
                    {
                        FPlayers[FSeeds[seedPlace].Id].SeedNo = 0;
                    }
                    FPlayers[DraggedIndex].SeedNo = seedPlace;
                    FSeeds[seedPlace].Id = FPlayers[DraggedIndex].Id;
                    //FSeeds[seedPlace].Index = FPlayers[DraggedIndex].Index;
                    FSeeds[seedPlace].Name = FPlayers[DraggedIndex].Name;
                }
            }
            finally
            {
                Invalidate();
            }
        }
        private void ClearPlayersList()
        {
            Players.Clear();
        }
        private void AddPlayer(int id, int seedNo, int rating, string name)
        {
            PlayerItem pl = new PlayerItem(id, name);
            pl.SeedNo = seedNo;
            pl.Rating = rating;
            Players.Add(id, pl);
        }

        private void EmptySeeds()
        {
            foreach (SeedItem seed in Seeds.Values)
            {
                seed.Empty();
            }
        }
        private void ClearSeeds()
        {
            Seeds.Clear();
        }
        #endregion

        #region PUBLIC FUNCTIONS
        public void FillDummy(int playerCount, int seedCount, SeedType type, int aParam) 
        {
            List<CompetitionPlayerInfo> players = new List<CompetitionPlayerInfo>();
            Random rnd = new Random();
            for (int i = 0; i < playerCount; i++)
            {
                CompetitionPlayerInfo player = new CompetitionPlayerInfo();
                player.Id = i + 1;
                player.NickName = "Player " + (i + 1).ToString("d2");
                player.RatingBeforeCompetition = 1500 + rnd.Next(-100, 100);
                players.Add(player);
            }
            SetPlayersList(players.ToArray());
            int[] seed = new int[seedCount];
            for (int i = 0; i < seed.Length; i++) 
            {
                if( i % 2 == 0)
                    seed[i] = i / 2 + 1;
                else
                    seed[i] = (seed.Length + 1 + i) / 2;
            } 
            SetSeedingOrder(seed, type, aParam);
        }
        public void UpdateSeeds() 
        {
            foreach(PlayerItem player in Players.Values)
            {
                if (Seeds.ContainsKey(player.SeedNo)) 
                {
                    Seeds[player.SeedNo].Id = player.Id;
                    Seeds[player.SeedNo].Name = player.Name;
                }
            }
            foreach (SeedItem seed in Seeds.Values) 
            {
                if (!Players.ContainsKey(seed.Id))
                {
                    seed.Empty();
                }
                else 
                {
                    Players[seed.Id].SeedNo = seed.SeedNo;
                }
            }
        }
        public void SetPlayersList(CompetitionPlayerInfo[] players)
        {
            SetPlayersList(players, false);
        }
        public void SetPlayersList(CompetitionPlayerInfo[] players, bool withEmptySeeds)
        {
            ClearPlayersList();
            foreach (CompetitionPlayerInfo player in players)
            {
                if (withEmptySeeds)
                    AddPlayer(player.Id, 0, player.RatingBeforeCompetition, player.NickName);
                else
                    AddPlayer(player.Id, player.SeedNo, player.RatingBeforeCompetition, player.NickName);
            }
            Players.SortBy = SortBy;
            UpdateSeeds();
            Invalidate();
        }
        public void SetSeedingOrder(int[] seedingOrder, SeedType type, int aParam)
        {
            Seeds.SetSeedOrder(type, seedingOrder, aParam);
        }
        /// <summary>
        /// Заполняет список игроков номерами посева
        /// </summary>
        /// <param name="playersToSeed">Список игроков</param>
        public void SeedPlayers(CompetitionPlayerList playersToSeed)
        {
            foreach (PlayerItem player in Players.Values)
            {
                playersToSeed[player.Id].SeedNo = player.SeedNo;
            }
        }
        public int[] GetSeededPlayersIdArray()
        {
            int[] res = new int[Seeds.Count];
            int i = 0;
            foreach (SeedItem item in Seeds.Values)
            {
                res[i++] = item.Id;
            }
            return res;
        }
        /// <summary>
        /// Выполняет рассеивание исходного списка игроков
        /// </summary>
        /// <param name="sortBy">Порядок рассеивания</param>
        public void Seed(SortOrder sortBy)
        {
            CancelSeed();
            PlayerItem[] players = Players.SortedArray(sortBy);
            for (int i = 0; i < players.Length; i++)
            {
                Players[players[i].Id].SeedNo = i + 1;
                Seeds[i + 1].Id = players[i].Id;
                Seeds[i + 1].Name = players[i].Name;
            }
            Invalidate();
            if (AfterPlayerSeed != null)
                AfterPlayerSeed(this, EventArgs.Empty);
        }
        public void ManualSeed() 
        {
            CancelSeed();
            if (Seeding.fManualSeeding.ShowSeedDialog(Players.Values.ToArray()))
            {
                UpdateSeeds();
            }
        }
        public void CancelSeed() 
        {
            EmptySeeds();
            foreach (PlayerItem player in Players.Values) 
            {
                player.SeedNo = 0;
            }
            Invalidate();
        }
        #endregion

        #region EVENT HANDLERS
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Select();
            Point point = new Point(e.Location.X, e.Location.Y);
            DraggedIndex = GetLeftIndex(point);
            if (DraggedIndex == -1)
            {
                int seedPlace = GetSeedPlace(point);
                if (seedPlace > -1)
                {
                    DraggedIndex = FSeeds[seedPlace].Id;
                    if (DraggedIndex > -1) 
                    {
                        FPlayers[DraggedIndex].SeedNo = 0;
                        FSeeds[seedPlace].Empty();
                    }
                }
            }
            DraggedLocation = e.Location;
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (DraggedIndex > -1)
            {

                /*if (e.Location.Y > ClipRectangle.Height - sbVertical.Max + sbVertical.Value)
                    sbVertical.Value += (sbVertical.Max - sbVertical.Value) / (e.Location.Y - ClipRectangle.Height + sbVertical.Max - sbVertical.Value);*/
                DraggedLocation = new Point(e.Location.X, e.Location.Y);
                Point loc = e.Location;
                loc.Offset(DraggedOffset);
                FSeeds.SeedOver = GetSeedPlace(loc);
                Invalidate();
            }
            else 
            {
                FSeeds.SeedOver = -1;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (DraggedIndex > -1)
            {
                Point loc = e.Location;
                loc.Offset(DraggedOffset);
                TryToPlaceDraggedObject(loc);
                if (AfterPlayerSeed != null)
                    AfterPlayerSeed(this, EventArgs.Empty);
            }
            DraggedIndex = -1;
            Invalidate();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Location.X < PlayersLocation.X + ItemSize.Width) 
            {
                sbLeft.Value -= e.Delta / WHEEL_DELTA;
                Invalidate();
            }
            if (e.Location.X > SeedsLocation.X) 
            {
                sbRight.Value -= e.Delta / WHEEL_DELTA * SeedItem.Size.Height * 2;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);
            FPlayers.Draw(gr, PlayersLocation, sbLeft.Value, MaxVisiblePlayers, ShowRating);
            FSeeds.Draw(gr, SeedsLocation, sbRight.Value, MaxVisibleSeeds);
            if (DraggedIndex != -1)
            {
                Point loc = DraggedLocation;
                loc.Offset(DraggedOffset);
                FPlayers[DraggedIndex].Draw(gr, loc, false);
            }
            if(ShowBorder)
                gr.DrawRectangle(new Pen(BorderColor), 0, 0, Width - 1, Height - 1);
            e.Graphics.DrawImageUnscaled(bmp, 0, 0);
            
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (MaxVisiblePlayers > FPlayers.Count - sbLeft.Value)
                sbLeft.Value = FPlayers.Count - MaxVisiblePlayers + 1;
            sbLeft.Max = FPlayers.Count - MaxVisiblePlayers + 1;
            sbLeft.Visible = sbLeft.Max > 0;

            if (FSeeds.Count > 0)
            {
                if (Height < FSeeds.FullHeight - sbRight.Value && sbRight.Value != 0)
                    sbRight.Value = (FSeeds.FullHeight - Height);
                sbRight.Max = (FSeeds.FullHeight - Height);
            }
            else 
            {
                sbRight.Max = 1;
            }
            sbRight.Visible =  sbRight.Max > 1;
            Invalidate();
        }
        #endregion

        #region PUBLISHED EVENTS
        [Browsable(true)]
        [Description("Вызывается после того, как игрок получит жребий")]
        public event EventHandler AfterPlayerSeed;
        #endregion


        internal int GetOpponentId(int playerId)
        {
            if (!Players.ContainsKey(playerId))
                return -1;
            int player_seed_no = Players[playerId].SeedNo;
            int opponent_seed_no = ((Players.Count + 1) / 2 + player_seed_no) % Players.Count;
            foreach (PlayerItem player in Players.Values) 
            {
                if (player.SeedNo == opponent_seed_no)
                    return player.Id;
            }
            return -1;
        }
    }
}
