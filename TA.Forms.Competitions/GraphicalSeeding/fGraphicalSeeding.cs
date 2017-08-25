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
    public partial class fGraphicalSeeding : Form, Localizator.ILocalizableForm
    {
        private int[] FSeedingOrder = null;
        private CompetitionPlayerList FPlayers = null;
        SeedingArgs _seeding_args = null;
        private CompetitionPlayerList PlayersToSeed 
        {
            get {
                return FPlayers;
            }
            set {
                FPlayers = value;
                grSeeding.SetPlayersList(value.Values.ToArray());
            }
        }
        private int[] SeedingOrder 
        {
            get { return FSeedingOrder; }
        }
        private void SetSeedingOrder(int[] seedOrder, Seeding.SeedType type, int aParam) 
        {
            FSeedingOrder = seedOrder;
            grSeeding.SetSeedingOrder(seedOrder, type, aParam);
        }

        private fGraphicalSeeding()
        {
            InitializeComponent();
            grSeeding.BackColor = WindowSkin.Palette.TextBackColor;
            LocalizeComponents();
        }
        public static bool Seed(SeedingArgs args) 
        {
            fGraphicalSeeding form = new fGraphicalSeeding();
            form._seeding_args = args;
            form.SetSeedingOrder(args.SeedOrder, args.SeedType, args.Param);
            form.PlayersToSeed = args.PlayersToSeed;
            form.grSeeding.UpdateSeeds();
            form.grSeeding.ShowRating = args.AllowRating;
            form.UpdateButtons();
            form.Height = Screen.PrimaryScreen.Bounds.Height - 200;
            if (form.ShowDialog() == DialogResult.OK) 
            {
                form.grSeeding.SeedPlayers(args.PlayersToSeed);
                return true;
            }
            return false;
        }

        private void UpdateButtons ()
        {
            btnOk.Enabled = grSeeding.AllPlayersSeeded && grSeeding.AllMatchesHasPlayers;
            btnAutoDrawing.Enabled = _seeding_args.AllowAuto;
            btnHandDrawing.Enabled = _seeding_args.AllowManual;
            btnRatingDrawing.Enabled = _seeding_args.AllowRating;
            btnCancelDrawing.Enabled = _seeding_args.AllowReset;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void grSeeding_AfterPlayerSeed(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grSeeding.ManualSeed();
            grSeeding.Invalidate();
            UpdateButtons();
        }

        private void btnRatingDrawing_Click(object sender, EventArgs e)
        {
            grSeeding.Seed(Seeding.SortOrder.Rating);
        }

        private void btnAutoDrawing_Click(object sender, EventArgs e)
        {
            bool is_correct_seeding = false;
            do
            {
                grSeeding.Seed(Seeding.SortOrder.Random);
                if (_seeding_args.LastPlayerWithBay == 0)
                    is_correct_seeding = true;
                else 
                {
                    // проверяем, что бы игрок два раза подряд с баем не играл
                    int opp_id = grSeeding.GetOpponentId(_seeding_args.LastPlayerWithBay);
                    is_correct_seeding = grSeeding.GetOpponentId(_seeding_args.LastPlayerWithBay) != 0;
                }

            } while (!is_correct_seeding);

        }

        private void btnCancelDrawing_Click(object sender, EventArgs e)
        {
            grSeeding.CancelSeed();
        }


        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.label1.Text = Localizator.Dictionary.GetString("PLAYERS");
            this.label2.Text = Localizator.Dictionary.GetString("MATCHES");
            this.label3.Text = Localizator.Dictionary.GetString("METHOD_DRAW");
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.btnHandDrawing.Text = Localizator.Dictionary.GetString("HAND_DRAW");
            this.btnRatingDrawing.Text = Localizator.Dictionary.GetString("RATING_DRAW");
            this.btnAutoDrawing.Text = Localizator.Dictionary.GetString("AUTO_DRAW");
            this.btnCancelDrawing.Text = Localizator.Dictionary.GetString("CANCEL_DRAW");
            this.Text = Localizator.Dictionary.GetString("DRAW_PLAYERS");
            
        }

        #endregion
    }
    public class SeedingArgs
    {
        public CompetitionPlayerList PlayersToSeed = null;
        public int[] SeedOrder = null;
        public Seeding.SeedType SeedType = Seeding.SeedType.Matches;
        public bool AllowRating = false;
        public bool AllowManual = true;
        public bool AllowAuto = true;
        public bool AllowReset = true;
        public int Param = 0;
        public bool IsComplete
        {
            get
            {
                return SeedOrder != null && PlayersToSeed != null;
            }
        }
        public static SeedingArgs Empty
        {
            get
            {
                return new SeedingArgs();
            }
        }
        /// <summary>
        /// Последний игрок игравший с баем
        /// </summary>
        public int LastPlayerWithBay = 0;
    }

}
