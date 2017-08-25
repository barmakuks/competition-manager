namespace TA.Competitions.Forms
{
    partial class fGraphicalSeeding
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new WindowSkin.Button();
            this.btnCancel = new WindowSkin.Button();
            this.btnHandDrawing = new WindowSkin.Button();
            this.grSeeding = new Seeding.GraphicalSeeding();
            this.btnRatingDrawing = new WindowSkin.Button();
            this.btnAutoDrawing = new WindowSkin.Button();
            this.btnCancelDrawing = new WindowSkin.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = true;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(535, 478);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(311, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Matches";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Down = false;
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnOk.Image = null;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(329, 441);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(88, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Down = false;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnCancel.Image = null;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(423, 441);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(88, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHandDrawing
            // 
            this.btnHandDrawing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnHandDrawing.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHandDrawing.Down = false;
            this.btnHandDrawing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnHandDrawing.Image = null;
            this.btnHandDrawing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHandDrawing.Location = new System.Drawing.Point(21, 39);
            this.btnHandDrawing.Name = "btnHandDrawing";
            this.btnHandDrawing.RadioButton = false;
            this.btnHandDrawing.Size = new System.Drawing.Size(96, 23);
            this.btnHandDrawing.TabIndex = 10;
            this.btnHandDrawing.Text = "Manual";
            this.btnHandDrawing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHandDrawing.Click += new System.EventHandler(this.button1_Click);
            // 
            // grSeeding
            // 
            this.grSeeding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grSeeding.Location = new System.Drawing.Point(21, 87);
            this.grSeeding.Name = "grSeeding";
            this.grSeeding.PlayersInGroup = 4;
            this.grSeeding.ShowBorder = true;
            this.grSeeding.Size = new System.Drawing.Size(490, 345);
            this.grSeeding.TabIndex = 3;
            this.grSeeding.AfterPlayerSeed += new System.EventHandler(this.grSeeding_AfterPlayerSeed);
            // 
            // btnRatingDrawing
            // 
            this.btnRatingDrawing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnRatingDrawing.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRatingDrawing.Down = false;
            this.btnRatingDrawing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnRatingDrawing.Image = null;
            this.btnRatingDrawing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRatingDrawing.Location = new System.Drawing.Point(225, 39);
            this.btnRatingDrawing.Name = "btnRatingDrawing";
            this.btnRatingDrawing.RadioButton = false;
            this.btnRatingDrawing.Size = new System.Drawing.Size(96, 23);
            this.btnRatingDrawing.TabIndex = 12;
            this.btnRatingDrawing.Text = "Rating";
            this.btnRatingDrawing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRatingDrawing.Click += new System.EventHandler(this.btnRatingDrawing_Click);
            // 
            // btnAutoDrawing
            // 
            this.btnAutoDrawing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnAutoDrawing.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAutoDrawing.Down = false;
            this.btnAutoDrawing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnAutoDrawing.Image = null;
            this.btnAutoDrawing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoDrawing.Location = new System.Drawing.Point(123, 39);
            this.btnAutoDrawing.Name = "btnAutoDrawing";
            this.btnAutoDrawing.RadioButton = false;
            this.btnAutoDrawing.Size = new System.Drawing.Size(96, 23);
            this.btnAutoDrawing.TabIndex = 13;
            this.btnAutoDrawing.Text = "Computer";
            this.btnAutoDrawing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAutoDrawing.Click += new System.EventHandler(this.btnAutoDrawing_Click);
            // 
            // btnCancelDrawing
            // 
            this.btnCancelDrawing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnCancelDrawing.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancelDrawing.Down = false;
            this.btnCancelDrawing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnCancelDrawing.Image = null;
            this.btnCancelDrawing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelDrawing.Location = new System.Drawing.Point(414, 39);
            this.btnCancelDrawing.Name = "btnCancelDrawing";
            this.btnCancelDrawing.RadioButton = false;
            this.btnCancelDrawing.Size = new System.Drawing.Size(96, 23);
            this.btnCancelDrawing.TabIndex = 14;
            this.btnCancelDrawing.Text = "Cancel Drawing";
            this.btnCancelDrawing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelDrawing.Click += new System.EventHandler(this.btnCancelDrawing_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(18, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Method of  Drawing";
            // 
            // fGraphicalSeeding
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(535, 478);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelDrawing);
            this.Controls.Add(this.btnAutoDrawing);
            this.Controls.Add(this.btnRatingDrawing);
            this.Controls.Add(this.btnHandDrawing);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grSeeding);
            this.Controls.Add(this.border1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fGraphicalSeeding";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw Players";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowSkin.Border border1;
        private Seeding.GraphicalSeeding grSeeding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WindowSkin.Button btnOk;
        private WindowSkin.Button btnCancel;
        private WindowSkin.Button btnHandDrawing;
        private WindowSkin.Button btnRatingDrawing;
        private WindowSkin.Button btnAutoDrawing;
        private WindowSkin.Button btnCancelDrawing;
        private System.Windows.Forms.Label label3;
    }
}