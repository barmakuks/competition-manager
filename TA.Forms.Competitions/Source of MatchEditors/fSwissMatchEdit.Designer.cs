namespace TA.Competitions.Forms
{
    partial class fSwissMatchEdit
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
            this.border1 = new WindowSkin.Border();
            this.rbtnNoResult = new System.Windows.Forms.RadioButton();
            this.rbtnWinnerA = new System.Windows.Forms.RadioButton();
            this.rbtnDraw = new System.Windows.Forms.RadioButton();
            this.rbtnWinnerB = new System.Windows.Forms.RadioButton();
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
            this.btnOk.Location = new System.Drawing.Point(58, 135);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 17;
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
            this.btnCancel.Location = new System.Drawing.Point(143, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.border1.Size = new System.Drawing.Size(269, 174);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // rbtnNoResult
            // 
            this.rbtnNoResult.AutoSize = true;
            this.rbtnNoResult.Checked = true;
            this.rbtnNoResult.Location = new System.Drawing.Point(46, 29);
            this.rbtnNoResult.Name = "rbtnNoResult";
            this.rbtnNoResult.Size = new System.Drawing.Size(143, 17);
            this.rbtnNoResult.TabIndex = 23;
            this.rbtnNoResult.TabStop = true;
            this.rbtnNoResult.Text = "The match is not finished";
            this.rbtnNoResult.UseVisualStyleBackColor = true;
            // 
            // rbtnWinnerA
            // 
            this.rbtnWinnerA.AutoSize = true;
            this.rbtnWinnerA.Location = new System.Drawing.Point(46, 52);
            this.rbtnWinnerA.Name = "rbtnWinnerA";
            this.rbtnWinnerA.Size = new System.Drawing.Size(72, 17);
            this.rbtnWinnerA.TabIndex = 24;
            this.rbtnWinnerA.Text = "Winner is ";
            this.rbtnWinnerA.UseVisualStyleBackColor = true;
            // 
            // rbtnDraw
            // 
            this.rbtnDraw.AutoSize = true;
            this.rbtnDraw.Location = new System.Drawing.Point(46, 75);
            this.rbtnDraw.Name = "rbtnDraw";
            this.rbtnDraw.Size = new System.Drawing.Size(155, 17);
            this.rbtnDraw.TabIndex = 25;
            this.rbtnDraw.Text = "The match ended in a draw";
            this.rbtnDraw.UseVisualStyleBackColor = true;
            // 
            // rbtnWinnerB
            // 
            this.rbtnWinnerB.AutoSize = true;
            this.rbtnWinnerB.Location = new System.Drawing.Point(46, 98);
            this.rbtnWinnerB.Name = "rbtnWinnerB";
            this.rbtnWinnerB.Size = new System.Drawing.Size(72, 17);
            this.rbtnWinnerB.TabIndex = 26;
            this.rbtnWinnerB.Text = "Winner is ";
            this.rbtnWinnerB.UseVisualStyleBackColor = true;
            // 
            // fSwissMatchEdit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(269, 174);
            this.Controls.Add(this.rbtnWinnerB);
            this.Controls.Add(this.rbtnDraw);
            this.Controls.Add(this.rbtnWinnerA);
            this.Controls.Add(this.rbtnNoResult);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fSwissMatchEdit";
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
        private WindowSkin.Border border1;
        private System.Windows.Forms.RadioButton rbtnNoResult;
        private System.Windows.Forms.RadioButton rbtnWinnerA;
        private System.Windows.Forms.RadioButton rbtnDraw;
        private System.Windows.Forms.RadioButton rbtnWinnerB;
    }
}