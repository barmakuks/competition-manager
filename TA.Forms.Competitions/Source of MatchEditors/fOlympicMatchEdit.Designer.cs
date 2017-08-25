namespace TA.Competitions.Forms
{
    partial class fOlympicMatchEdit
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new WindowSkin.Button();
            this.btnCancel = new WindowSkin.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.cbxPlayerA = new WindowSkin.CheckBox();
            this.cbxPlayerB = new WindowSkin.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.border1 = new WindowSkin.Border();
            this.ibxPointsB = new WindowSkin.IntegerBox();
            this.ibxPointsA = new WindowSkin.IntegerBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Down = false;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnOk.Image = null;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(128, 120);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Down = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnCancel.Image = null;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(222, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Winner is ";
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWinner.Location = new System.Drawing.Point(114, 24);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(0, 13);
            this.lblWinner.TabIndex = 7;
            // 
            // cbxPlayerA
            // 
            this.cbxPlayerA.AutoSize = true;
            this.cbxPlayerA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxPlayerA.Location = new System.Drawing.Point(15, 54);
            this.cbxPlayerA.Name = "cbxPlayerA";
            this.cbxPlayerA.Size = new System.Drawing.Size(15, 14);
            this.cbxPlayerA.TabIndex = 0;
            this.cbxPlayerA.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbxPlayerA_MouseDoubleClick);
            this.cbxPlayerA.CheckedChanged += new System.EventHandler(this.cbxPlayerA_CheckedChanged);
            // 
            // cbxPlayerB
            // 
            this.cbxPlayerB.AutoSize = true;
            this.cbxPlayerB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxPlayerB.Location = new System.Drawing.Point(15, 88);
            this.cbxPlayerB.Name = "cbxPlayerB";
            this.cbxPlayerB.Size = new System.Drawing.Size(15, 14);
            this.cbxPlayerB.TabIndex = 1;
            this.cbxPlayerB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbxPlayerA_MouseDoubleClick);
            this.cbxPlayerB.CheckedChanged += new System.EventHandler(this.cbxPlayerB_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(253, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Score";
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(317, 160);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // ibxPointsB
            // 
            this.ibxPointsB.Location = new System.Drawing.Point(237, 83);
            this.ibxPointsB.MaximumSize = new System.Drawing.Size(100, 19);
            this.ibxPointsB.MaximumValue = 100;
            this.ibxPointsB.MinimumSize = new System.Drawing.Size(60, 19);
            this.ibxPointsB.MinimumValue = 0;
            this.ibxPointsB.Name = "ibxPointsB";
            this.ibxPointsB.Size = new System.Drawing.Size(60, 19);
            this.ibxPointsB.TabIndex = 3;
            this.ibxPointsB.Value = 0;
            // 
            // ibxPointsA
            // 
            this.ibxPointsA.Location = new System.Drawing.Point(237, 48);
            this.ibxPointsA.MaximumSize = new System.Drawing.Size(100, 19);
            this.ibxPointsA.MaximumValue = 100;
            this.ibxPointsA.MinimumSize = new System.Drawing.Size(60, 19);
            this.ibxPointsA.MinimumValue = 0;
            this.ibxPointsA.Name = "ibxPointsA";
            this.ibxPointsA.Size = new System.Drawing.Size(60, 19);
            this.ibxPointsA.TabIndex = 2;
            this.ibxPointsA.Value = 0;
            // 
            // fOlympicMatchEdit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(317, 160);
            this.Controls.Add(this.ibxPointsB);
            this.Controls.Add(this.ibxPointsA);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.cbxPlayerA);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxPlayerB);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fOlympicMatchEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match result";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowSkin.Button btnOk;
        private WindowSkin.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWinner;
        private WindowSkin.CheckBox cbxPlayerA;
        private WindowSkin.CheckBox cbxPlayerB;
        private System.Windows.Forms.Label label2;
        private WindowSkin.Border border1;
        private WindowSkin.IntegerBox ibxPointsB;
        private WindowSkin.IntegerBox ibxPointsA;
    }
}