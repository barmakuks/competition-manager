namespace TA.Competitions.Forms
{
    partial class OlympicParamsPanel
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
            this.cbxThirdPlaceMatch = new WindowSkin.CheckBox();
            this.SuspendLayout();
            // 
            // cbxThirdPlaceMatch
            // 
            this.cbxThirdPlaceMatch.AutoSize = true;
            this.cbxThirdPlaceMatch.Location = new System.Drawing.Point(3, 4);
            this.cbxThirdPlaceMatch.Name = "cbxThirdPlaceMatch";
            this.cbxThirdPlaceMatch.Size = new System.Drawing.Size(171, 15);
            this.cbxThirdPlaceMatch.TabIndex = 32;
            this.cbxThirdPlaceMatch.Text = "Create a match for 3rd place?";
            // 
            // OlympicParamsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cbxThirdPlaceMatch);
            this.Name = "OlympicParamsPanel";
            this.Size = new System.Drawing.Size(311, 292);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowSkin.CheckBox cbxThirdPlaceMatch;
    }
}
