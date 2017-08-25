namespace TA.Competitions.Forms
{
    partial class OlympicConsolationParamsPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.intMainPrize = new WindowSkin.IntegerBox();
            this.intConsolationPrize = new WindowSkin.IntegerBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Number of prizes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "in Consolation tournament";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "in Main tournament";
            // 
            // intMainPrize
            // 
            this.intMainPrize.AllowManualEditing = false;
            this.intMainPrize.Location = new System.Drawing.Point(151, 63);
            this.intMainPrize.MaximumSize = new System.Drawing.Size(100, 19);
            this.intMainPrize.MaximumValue = 16;
            this.intMainPrize.MinimumSize = new System.Drawing.Size(51, 19);
            this.intMainPrize.MinimumValue = 4;
            this.intMainPrize.Name = "intMainPrize";
            this.intMainPrize.Size = new System.Drawing.Size(51, 19);
            this.intMainPrize.TabIndex = 38;
            this.intMainPrize.Value = 4;
            this.intMainPrize.ValueChangeValidator += new WindowSkin.IntegerBox.ValueChangeValidate(this.intMainPrize_HowToChangeValue);
            // 
            // intConsolationPrize
            // 
            this.intConsolationPrize.AllowManualEditing = true;
            this.intConsolationPrize.Location = new System.Drawing.Point(151, 92);
            this.intConsolationPrize.MaximumSize = new System.Drawing.Size(117, 19);
            this.intConsolationPrize.MaximumValue = 4;
            this.intConsolationPrize.MinimumSize = new System.Drawing.Size(51, 19);
            this.intConsolationPrize.MinimumValue = 2;
            this.intConsolationPrize.Name = "intConsolationPrize";
            this.intConsolationPrize.Size = new System.Drawing.Size(51, 19);
            this.intConsolationPrize.TabIndex = 39;
            this.intConsolationPrize.Value = 2;
            this.intConsolationPrize.ValueChangeValidator += new WindowSkin.IntegerBox.ValueChangeValidate(this.intMainPrize_HowToChangeValue);
            // 
            // OlympicConsolationParamsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.intConsolationPrize);
            this.Controls.Add(this.intMainPrize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OlympicConsolationParamsPanel";
            this.Size = new System.Drawing.Size(387, 292);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.intMainPrize, 0);
            this.Controls.SetChildIndex(this.intConsolationPrize, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private WindowSkin.IntegerBox intMainPrize;
        private WindowSkin.IntegerBox intConsolationPrize;
    }
}
