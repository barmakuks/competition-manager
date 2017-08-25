namespace TA.Competitions.Forms
{
    partial class RobinOlympicParamsPanel
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
            this.ibxKnockoutPlayersCount = new WindowSkin.IntegerBox();
            this.ibxGroupCount = new WindowSkin.IntegerBox();
            this.cbxThirdPlaceMatch = new WindowSkin.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Groups:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total number of players entering the grid playoffs";
            // 
            // ibxKnockoutPlayersCount
            // 
            this.ibxKnockoutPlayersCount.AllowManualEditing = false;
            this.ibxKnockoutPlayersCount.Location = new System.Drawing.Point(37, 80);
            this.ibxKnockoutPlayersCount.MaximumSize = new System.Drawing.Size(86, 19);
            this.ibxKnockoutPlayersCount.MaximumValue = 128;
            this.ibxKnockoutPlayersCount.MinimumSize = new System.Drawing.Size(51, 19);
            this.ibxKnockoutPlayersCount.MinimumValue = 1;
            this.ibxKnockoutPlayersCount.Name = "ibxKnockoutPlayersCount";
            this.ibxKnockoutPlayersCount.Size = new System.Drawing.Size(63, 19);
            this.ibxKnockoutPlayersCount.TabIndex = 4;
            this.ibxKnockoutPlayersCount.Value = 1;
            this.ibxKnockoutPlayersCount.ValueChangeValidator += new WindowSkin.IntegerBox.ValueChangeValidate(this.ibxGroupCount_HowToChangeValue);
            // 
            // ibxGroupCount
            // 
            this.ibxGroupCount.AllowManualEditing = false;
            this.ibxGroupCount.Location = new System.Drawing.Point(37, 16);
            this.ibxGroupCount.MaximumSize = new System.Drawing.Size(86, 19);
            this.ibxGroupCount.MaximumValue = 128;
            this.ibxGroupCount.MinimumSize = new System.Drawing.Size(51, 19);
            this.ibxGroupCount.MinimumValue = 1;
            this.ibxGroupCount.Name = "ibxGroupCount";
            this.ibxGroupCount.Size = new System.Drawing.Size(63, 19);
            this.ibxGroupCount.TabIndex = 5;
            this.ibxGroupCount.Value = 1;
            this.ibxGroupCount.ValueChanged += new System.EventHandler(this.ibxGroupCount_ValueChanged);
            this.ibxGroupCount.ValueChangeValidator += new WindowSkin.IntegerBox.ValueChangeValidate(this.ibxGroupCount_HowToChangeValue);
            // 
            // cbxThirdPlaceMatch
            // 
            this.cbxThirdPlaceMatch.AutoSize = true;
            this.cbxThirdPlaceMatch.Location = new System.Drawing.Point(4, 110);
            this.cbxThirdPlaceMatch.Name = "cbxThirdPlaceMatch";
            this.cbxThirdPlaceMatch.Size = new System.Drawing.Size(171, 15);
            this.cbxThirdPlaceMatch.TabIndex = 33;
            this.cbxThirdPlaceMatch.Text = "Create a match for 3rd place?";
            // 
            // RobinOlympicParamsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cbxThirdPlaceMatch);
            this.Controls.Add(this.ibxGroupCount);
            this.Controls.Add(this.ibxKnockoutPlayersCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RobinOlympicParamsPanel";
            this.Size = new System.Drawing.Size(337, 296);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WindowSkin.IntegerBox ibxKnockoutPlayersCount;
        private WindowSkin.IntegerBox ibxGroupCount;
        private WindowSkin.CheckBox cbxThirdPlaceMatch;
    }
}
