namespace TA.Competitions.Forms
{
    partial class fSwingMatchEdit
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
            this.border1 = new WindowSkin.Border();
            this.btnOk = new WindowSkin.Button();
            this.btnCancel = new WindowSkin.Button();
            this.divPoints = new WindowSkin.NumberDevider();
            this.lblPlayerA = new System.Windows.Forms.Label();
            this.lblPlayerB = new System.Windows.Forms.Label();
            this.lblBetRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(285, 195);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10007;
            this.border1.TabStop = false;
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
            this.btnOk.Location = new System.Drawing.Point(63, 156);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10001;
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
            this.btnCancel.Location = new System.Drawing.Point(148, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10002;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divPoints
            // 
            this.divPoints.Location = new System.Drawing.Point(95, 90);
            this.divPoints.Name = "divPoints";
            this.divPoints.Size = new System.Drawing.Size(100, 58);
            this.divPoints.TabIndex = 10008;
            // 
            // lblPlayerA
            // 
            this.lblPlayerA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerA.Location = new System.Drawing.Point(12, 54);
            this.lblPlayerA.Name = "lblPlayerA";
            this.lblPlayerA.Size = new System.Drawing.Size(126, 35);
            this.lblPlayerA.TabIndex = 10009;
            this.lblPlayerA.Text = "label1";
            this.lblPlayerA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayerB
            // 
            this.lblPlayerB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerB.Location = new System.Drawing.Point(145, 54);
            this.lblPlayerB.Name = "lblPlayerB";
            this.lblPlayerB.Size = new System.Drawing.Size(126, 35);
            this.lblPlayerB.TabIndex = 10010;
            this.lblPlayerB.Text = "label1";
            this.lblPlayerB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBetRate
            // 
            this.lblBetRate.Location = new System.Drawing.Point(15, 24);
            this.lblBetRate.Name = "lblBetRate";
            this.lblBetRate.Size = new System.Drawing.Size(256, 17);
            this.lblBetRate.TabIndex = 10011;
            this.lblBetRate.Text = "Размер ставки";
            this.lblBetRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fSwingMatchEdit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(285, 195);
            this.Controls.Add(this.lblBetRate);
            this.Controls.Add(this.lblPlayerB);
            this.Controls.Add(this.lblPlayerA);
            this.Controls.Add(this.divPoints);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSwingMatchEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match results";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowSkin.Border border1;
        private WindowSkin.Button btnOk;
        private WindowSkin.Button btnCancel;
        private WindowSkin.NumberDevider divPoints;
        private System.Windows.Forms.Label lblPlayerA;
        private System.Windows.Forms.Label lblPlayerB;
        private System.Windows.Forms.Label lblBetRate;
    }
}