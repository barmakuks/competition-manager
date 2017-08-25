using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.RatingSystem;
using System.IO;

namespace TA.Main
{
    public partial class framePlayerRating : UserControl, Localizator.ILocalizableForm
    {
        private TypeOfSport FSport;
        public TypeOfSport Sport 
        {
            get {
                return FSport;
            }
        }
        public void UpdateGrid() 
        {
            Invalidate();
        }
        public framePlayerRating()
        {
            InitializeComponent();
            LocalizeComponents();
            pnlToolBar.BackColor = WindowSkin.Palette.BackColor;
            rsControl.HeaderBkColor = WindowSkin.Palette.Colors[4];
            rsControl.PlayersBkColor = WindowSkin.Palette.Colors[3];
            rsControl.RatingBkColor = WindowSkin.Palette.Colors[2];
            rsControl.ResultsBkColor = WindowSkin.Palette.TextBackColor;
            rsControl.LineColor = WindowSkin.Palette.Colors[8];
            toolTip.BackColor = WindowSkin.Palette.TextBackColor;
            toolTip.ForeColor = WindowSkin.Palette.ForeColor;
#if FEDITION_PLUS || FEDITION
            btnSave.Visible = true;
#else
            btnSave.Visible = false;
#endif
        }
        public static framePlayerRating CreateControl(TypeOfSport aSport) 
        {
            framePlayerRating frame = new framePlayerRating();
            frame.FSport = aSport;            
            frame.rsControl.Open(aSport.Id, aSport.Name);
            return frame;
        }
        public void Rebuild() 
        {
            rsControl.Open(Sport.Id, Sport.Name);
            UpdateGrid();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Image img = rsControl.DrawToImage();
            PicturePrinter.Printer.Preview(img);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
#if FEDITION_PLUS || FEDITION
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XML files|*.xml";
            dlg.FileName = String.Format("{0}-{1}.xml", Sport.Name, DateTime.Today.ToString("yyyy_MM_dd"));
            dlg.DefaultExt = "xml";
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                RatingSystem.Builder.RatingSystemBuilder.SaveRatingSystemToXml(rsControl.RatingSystem,dlg.FileName, DateTime.Today);
            }
#endif
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(ParentForm is Form)
                ParentForm.Close();
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.toolTip.SetToolTip(this.btnExit, Localizator.Dictionary.GetString("CLOSE"));
            this.toolTip.SetToolTip(this.btnPrint, Localizator.Dictionary.GetString("PRINT"));
            this.toolTip.SetToolTip(this.btnSave, Localizator.Dictionary.GetString("SAVE_TO_FILE"));
        }

        #endregion
    }
}
