namespace TA.Competitions.Forms
{
    partial class fGroupWinnersSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGroupWinnersSelect));
            this.btnCancel = new WindowSkin.Button();
            this.btnOk = new WindowSkin.Button();
            this.border1 = new WindowSkin.Border();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.pictureControl1 = new WindowSkins.PictureControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.grsdDrawing = new Seeding.GraphicalSeeding();
            this.border2 = new WindowSkin.Border();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnCancel.Location = new System.Drawing.Point(688, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnOk.Location = new System.Drawing.Point(580, 383);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(93, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.border1.Size = new System.Drawing.Size(805, 421);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Check players qualified to the next round";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Players qualified to the next round";
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Location = new System.Drawing.Point(429, 27);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerCount.TabIndex = 8;
            this.lblPlayerCount.Text = "label3";
            // 
            // pictureControl1
            // 
            this.pictureControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureControl1.Location = new System.Drawing.Point(12, 43);
            this.pictureControl1.Name = "pictureControl1";
            this.pictureControl1.Picture = ((System.Drawing.Bitmap)(resources.GetObject("pictureControl1.Picture")));
            this.pictureControl1.PictureSize = new System.Drawing.Size(10, 10);
            this.pictureControl1.Size = new System.Drawing.Size(276, 363);
            this.pictureControl1.TabIndex = 1;
            this.pictureControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureControl1_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.grsdDrawing);
            this.panel1.Controls.Add(this.border2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(293, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 333);
            this.panel1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(252, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "First leg playoffs";
            // 
            // grsdDrawing
            // 
            this.grsdDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grsdDrawing.Location = new System.Drawing.Point(11, 29);
            this.grsdDrawing.Name = "grsdDrawing";
            this.grsdDrawing.PlayersInGroup = 4;
            this.grsdDrawing.Size = new System.Drawing.Size(479, 294);
            this.grsdDrawing.TabIndex = 1;
            this.grsdDrawing.AfterPlayerSeed += new System.EventHandler(this.graphicalSeeding1_AfterPlayerSeed);
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(503, 333);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 10000;
            this.border2.TabStop = false;
            // 
            // fGroupWinnersSelect
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(805, 421);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pictureControl1);
            this.Controls.Add(this.border1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fGroupWinnersSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The draw players for the playoffs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowSkin.Border border1;
        private WindowSkins.PictureControl pictureControl1;
        private WindowSkin.Button btnOk;
        private WindowSkin.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private Seeding.GraphicalSeeding grsdDrawing;
        private WindowSkin.Border border2;
    }
}