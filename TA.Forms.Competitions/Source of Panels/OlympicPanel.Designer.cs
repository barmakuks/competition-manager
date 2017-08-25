namespace TA.Competitions.Forms
{
    partial class OlympicPanel
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
            this.SuspendLayout();
            // 
            // pictMain
            // 
            this.pictMain.Size = new System.Drawing.Size(346, 317);
            // 
            // OlympicPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "OlympicPanel";
            this.Size = new System.Drawing.Size(346, 317);
            this.OnMatchEdit += new TA.Competitions.Forms.OnMatchEdit(this.CompetitionOlympicPanel_OnMatchEdit);
            this.ResumeLayout(false);

        }

        #endregion


    }
}
