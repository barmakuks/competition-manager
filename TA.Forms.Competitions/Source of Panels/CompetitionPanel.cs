using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public delegate void OnMatchEdit(Point point);    
    public class CompetitionPanel : UserControl, Localizator.ILocalizableForm
    {
        protected TA.Corel.Competition FCompetition = null;
        protected Size FBitmapSize = new Size();
        protected WindowSkins.PictureControl pictMain;
        private double FScalePicture = 1.0;

        protected CompetitionPanel() : base()
        {
            InitializeComponent();
            LocalizeComponents();
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ContainerControl, true);
            pictMain.BackColor = Color.White;// WindowSkin.Palette.Colors[0];
        }

        /// <summary>
        /// Обновление видимости и доступности кнопок
        /// </summary>
        public virtual void UpdateButtonsActivity() 
        {
        }
        protected virtual void UpdatePicture()
        {
            if (FBitmapSize.Width * FBitmapSize.Height != 0)
            {
                pictMain.Picture = GetPicture(null);
            }
            pictMain.Invalidate();
        }
        public virtual void CreateGrid() { }
        public double ScalePicture
        {
            get
            {
                return FScalePicture;
            }
            set
            {
                FScalePicture = value;
                CreateGrid();
                UpdatePicture();
            }
        }

        public TA.Corel.Competition Competition
        {
            get
            {
                return FCompetition;
            }
        }

        protected virtual MatchPainter GetMatchPainter() 
        {
            throw new NotImplementedException();
        }
        public virtual void OpenCompetition(TA.Corel.Competition competition) 
        {
            FCompetition = competition;
            CreateGrid();
            UpdatePicture();
            UpdateButtonsActivity();
        }
        public virtual Bitmap GetPicture(Brush backBrush) 
        {
            throw new NotImplementedException(); 
        }
        public virtual event OnMatchEdit OnMatchEdit;
        public virtual event EventHandler OnAfterMatchEdit;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompetitionPanel));
            this.pictMain = new WindowSkins.PictureControl();
            this.SuspendLayout();
            // 
            // pictMain
            // 
            this.pictMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictMain.Location = new System.Drawing.Point(0, 0);
            this.pictMain.Name = "pictMain";
            this.pictMain.Picture = ((System.Drawing.Bitmap)(resources.GetObject("pictMain.Picture")));
            this.pictMain.PictureSize = new System.Drawing.Size(10, 10);
            this.pictMain.Size = new System.Drawing.Size(394, 376);
            this.pictMain.TabIndex = 5;
            this.pictMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictMain_MouseDoubleClick);
            // 
            // CompetitionPanel
            // 
            this.Controls.Add(this.pictMain);
            this.Name = "CompetitionPanel";
            this.Size = new System.Drawing.Size(394, 376);
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Вызывает событие OnAfterMatchEdit
        /// </summary>
        private void AfterMatchEdit(object sender, MouseEventArgs e) 
        {
            if (OnAfterMatchEdit != null)
                OnAfterMatchEdit(sender, e);
            UpdateButtonsActivity();
        }
        private void pictMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Competition == null)
                return;
            Point MousePoint = new Point(e.X - 10, e.Y - 10);
            if (OnMatchEdit != null)
                OnMatchEdit(MousePoint);
            AfterMatchEdit(sender, e);
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            
        }

        #endregion
    }
}
