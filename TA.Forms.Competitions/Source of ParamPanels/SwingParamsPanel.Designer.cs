namespace TA.Competitions.Forms
{
    partial class SwingParamsPanel
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
            this.lblBetsSequence = new System.Windows.Forms.Label();
            this.txtBetSequence = new WindowSkin.TextBox();
            this.SuspendLayout();
            // 
            // lblBetsSequence
            // 
            this.lblBetsSequence.AutoSize = true;
            this.lblBetsSequence.Location = new System.Drawing.Point(3, 147);
            this.lblBetsSequence.Name = "lblBetsSequence";
            this.lblBetsSequence.Size = new System.Drawing.Size(153, 13);
            this.lblBetsSequence.TabIndex = 37;
            this.lblBetsSequence.Text = "Последовательность ставок";
            // 
            // txtBetSequence
            // 
            this.txtBetSequence.Location = new System.Drawing.Point(26, 163);
            this.txtBetSequence.Name = "txtBetSequence";
            this.txtBetSequence.ReadOnly = false;
            this.txtBetSequence.Size = new System.Drawing.Size(185, 20);
            this.txtBetSequence.TabIndex = 39;
            // 
            // SwingParamsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBetSequence);
            this.Controls.Add(this.lblBetsSequence);
            this.Name = "SwingParamsPanel";
            this.Controls.SetChildIndex(this.lblBetsSequence, 0);
            this.Controls.SetChildIndex(this.txtBetSequence, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBetsSequence;
        private WindowSkin.TextBox txtBetSequence;
    }
}
