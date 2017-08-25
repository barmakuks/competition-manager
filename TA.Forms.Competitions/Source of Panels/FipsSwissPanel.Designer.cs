namespace TA.Competitions.Forms
{
    partial class FipsSwissPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRebuy = new WindowSkin.Button();
            this.pnlTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.btnRebuy);
            this.pnlTools.Controls.SetChildIndex(this.btnCancelRound, 0);
            this.pnlTools.Controls.SetChildIndex(this.btnNextRound, 0);
            this.pnlTools.Controls.SetChildIndex(this.btnRebuy, 0);
            this.pnlTools.Controls.SetChildIndex(this.lblPrizeCount, 0);
            this.pnlTools.Controls.SetChildIndex(this.ibxPrizeCount, 0);
            // 
            // pictMain
            // 
            this.pictMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictMain.Dock = System.Windows.Forms.DockStyle.None;
            this.pictMain.Location = new System.Drawing.Point(275, 48);
            this.pictMain.Size = new System.Drawing.Size(518, 328);
            // 
            // btnRebuy
            // 
            this.btnRebuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRebuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnRebuy.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRebuy.Down = false;
            this.btnRebuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRebuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnRebuy.Image = null;
            this.btnRebuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRebuy.Location = new System.Drawing.Point(691, 13);
            this.btnRebuy.Name = "btnRebuy";
            this.btnRebuy.RadioButton = false;
            this.btnRebuy.Size = new System.Drawing.Size(87, 23);
            this.btnRebuy.TabIndex = 5;
            this.btnRebuy.Text = "Rebuy";
            this.btnRebuy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRebuy.Click += new System.EventHandler(this.btnRebuy_Click);
            // 
            // FipsSwissPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "FipsSwissPanel";
            this.OnAfterMatchPictureUpdate += new System.EventHandler(this.CompetitionFipsSwissPanel_OnAfterMatchPictureUpdate);            
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowSkin.Button btnRebuy;
    }
}
