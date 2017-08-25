namespace TA.Main
{
    partial class GameRatingControl
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
            this.cbxIsActive = new WindowSkin.CheckBox();
            this.ibxRating = new WindowSkin.IntegerBox();
            this.SuspendLayout();
            // 
            // cbxIsActive
            // 
            this.cbxIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxIsActive.Location = new System.Drawing.Point(3, 4);
            this.cbxIsActive.Name = "cbxIsActive";
            this.cbxIsActive.Size = new System.Drawing.Size(120, 15);
            this.cbxIsActive.TabIndex = 0;
            this.cbxIsActive.Text = "Backgammon";
            this.cbxIsActive.CheckedChanged += new System.EventHandler(this.cbxIsActive_CheckedChanged);
            // 
            // ibxRating
            // 
            this.ibxRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibxRating.Location = new System.Drawing.Point(382, 3);
            this.ibxRating.MaximumSize = new System.Drawing.Size(100, 19);
            this.ibxRating.MaximumValue = 100000;
            this.ibxRating.MinimumSize = new System.Drawing.Size(60, 19);
            this.ibxRating.MinimumValue = 0;
            this.ibxRating.Name = "ibxRating";
            this.ibxRating.Size = new System.Drawing.Size(80, 19);
            this.ibxRating.TabIndex = 1;
            this.ibxRating.Value = 0;
            this.ibxRating.WheelStep = 10;
            // 
            // GameRatingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxIsActive);
            this.Controls.Add(this.ibxRating);
            this.Name = "GameRatingControl";
            this.Size = new System.Drawing.Size(465, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowSkin.IntegerBox ibxRating;
        private WindowSkin.CheckBox cbxIsActive;
    }
}
