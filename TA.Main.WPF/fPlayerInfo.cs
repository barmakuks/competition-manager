using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.DB.Manager;

namespace TA.Main
{
    public partial class fPlayerInfo : Form, Localizator.ILocalizableForm
    {        
        public fPlayerInfo()
        {
            InitializeComponent();
            LocalizeComponents();
            cbxCountry.BackColor = WindowSkin.Palette.TextBackColor;
            int top = 0;
            foreach (TypeOfSport sport in Globals.Games.Values) 
            {
                GameRatingControl control = new GameRatingControl();
                control.GameId = sport.Id;
                control.GameName = sport.Name;
                control.Location = new Point(0, top);
                control.Width = pnlRating.Width - 20;
                top += control.Height;
                pnlRating.Controls.Add(control);
            }
            
        }
        private PlayerInfo PlayerInfo;
        private void SetInfo(PlayerInfo info) 
        {
            PlayerInfo = info;
            txtFName.Text = info.FirstName;
            txtLName.Text = info.LastName;
            txtPName.Text = info.PatronymicName;
            cbxCountry.Items.Clear();
            cbxCountry.Items.AddRange(Globals.Countries.ToArray());
            cbxCountry.Text = info.Country;
            txtCity.Text = info.City;
            txtEMail.Text = info.EMail;
            txtPhone.Text = info.Phone;
            txtNName.Text = info.NickName;
#if STANDARD || FEDITION_PLUS || STANDARD_PLUS || FEDITION
            foreach (Control control in pnlRating.Controls)
            {
                if (control is GameRatingControl)
                {
                    GameRatingControl rating_control = control as GameRatingControl;
                    PlayerRatingInfo rating = DatabaseManager.CurrentDb.GetPlayerBeginRating(rating_control.GameId, info.Id);
                    if (rating != null)
                    {
                        rating_control.IsActive = rating.IsActive;
                        rating_control.RatingBegin = rating.RatingBegin;
                    }
                }
            }
#else           
            form.pnlRating.Visible = false;
#endif
        }
        public static bool Edit(PlayerInfo info) 
        {
            fPlayerInfo form = new fPlayerInfo();
            form.SetInfo(info);
            form.txtLName.Focus();            
            bool editing = info.Id > 0;
            form.btnMore.Visible = !editing;
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK || res == DialogResult.Retry)
            {
                form.SaveInfo();
                return res == DialogResult.Retry || editing;
            }
            return false;
        }
        private bool CanApply 
        {
            get {
                return !(txtFName.Text == "" || txtLName.Text == "");
            }

        }
        private void SaveInfo() 
        {
            PlayerInfo.FirstName = txtFName.Text;
            PlayerInfo.LastName = txtLName.Text;
            PlayerInfo.PatronymicName = txtPName.Text;
            PlayerInfo.Country = cbxCountry.Text;
            PlayerInfo.City = txtCity.Text;
            PlayerInfo.EMail = txtEMail.Text;
            PlayerInfo.Phone = txtPhone.Text;
            PlayerInfo.NickName = txtNName.Text;
            DatabaseManager.CurrentDb.PlayerInfoSave(PlayerInfo);
            PlayerRatingInfo rating = new PlayerRatingInfo();
            rating.PlayerId = PlayerInfo.Id;
            foreach (Control control in pnlRating.Controls)
            {
                if (control is GameRatingControl)
                {
                    GameRatingControl rating_control = control as GameRatingControl;
                    rating.IsActive = rating_control.IsActive;
                    rating.GameType = rating_control.GameId;
                    rating.RatingBegin = rating_control.RatingBegin;
                    DatabaseManager.CurrentDb.PlayerBeginRatingUpdate(rating);
                }
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanApply)
                return;
            if (txtNName.Text == "")
                txtNName.Text = CombineNickName(txtLName.Text, txtFName.Text);
            DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fPlayerInfo_Shown(object sender, EventArgs e)
        {
            txtLName.Focus();
        }
        private string CombineNickName(string last_name, string first_name) 
        {
            return last_name + " " + first_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CanApply) return;
            if (txtNName.Text == "")
                txtNName.Text = CombineNickName(txtLName.Text, txtFName.Text);
            DialogResult = DialogResult.Retry;
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.label1.Text = Localizator.Dictionary.GetString("COUNTRY");
            this.label2.Text = Localizator.Dictionary.GetString("SURNAME");
            this.label3.Text = Localizator.Dictionary.GetString("NAME");
            this.label4.Text = Localizator.Dictionary.GetString("PATRONYMIC");
            this.label5.Text = Localizator.Dictionary.GetString("PHONES");
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.groupBox1.Text = Localizator.Dictionary.GetString("PERSONAL_INFO");
            this.label8.Text = Localizator.Dictionary.GetString("NICKNAME");
            this.groupBox2.Text = Localizator.Dictionary.GetString("ADDIT_INFO");
            this.label7.Text = Localizator.Dictionary.GetString("EMAIL");
            this.label6.Text = Localizator.Dictionary.GetString("ADDRESS");
            this.groupBox3.Text = Localizator.Dictionary.GetString("START_RATING");
            this.btnMore.Text = Localizator.Dictionary.GetString("MORE");
            this.Text = Localizator.Dictionary.GetString("PLAYER_INFO");
            
        }

        #endregion
    }
}