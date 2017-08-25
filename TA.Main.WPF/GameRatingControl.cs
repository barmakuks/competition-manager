using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TA.Main
{
    public partial class GameRatingControl : UserControl
    {
        public int GameId = 0;
        public string GameName {
            get {
                return cbxIsActive.Text;
            }
            set {
                cbxIsActive.Text = value;
            }
        }
        public bool IsActive {
            get {
                return cbxIsActive.Checked;
            }
            set {
                cbxIsActive.Checked = value;
            }
        }
        public int RatingBegin {
            get{
                return Convert.ToInt32(ibxRating.Value);
            }
            set {
                ibxRating.Value = value; 
            }
        }
        public GameRatingControl()
        {
            InitializeComponent();
            SetAccessibility();                        
        }

        private void SetAccessibility ()
        {            
            ibxRating.Enabled = cbxIsActive.Checked;
        }
        private void cbxIsActive_CheckedChanged(object sender, EventArgs e)
        {
            SetAccessibility();
        }
    }
}
