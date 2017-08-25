namespace Seeding
{
    partial class fManualSeeding
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
            WindowSkin.ObjectListViewColumn objectListViewColumn4 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn5 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn6 = new WindowSkin.ObjectListViewColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentPlayer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdSource = new WindowSkin.ObjectListView();
            this.border1 = new WindowSkin.Border();
            this.btnCancel = new WindowSkin.Button();
            this.btnOk = new WindowSkin.Button();
            this.btnNext = new WindowSkin.Button();
            this.btnSkip = new WindowSkin.Button();
            this.grdDest = new WindowSkin.ObjectListView();
            this.ibxDrawNo = new WindowSkin.IntegerBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(238, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Selected Player:";
            // 
            // lblCurrentPlayer
            // 
            this.lblCurrentPlayer.AutoSize = true;
            this.lblCurrentPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentPlayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCurrentPlayer.Location = new System.Drawing.Point(235, 58);
            this.lblCurrentPlayer.Name = "lblCurrentPlayer";
            this.lblCurrentPlayer.Size = new System.Drawing.Size(178, 24);
            this.lblCurrentPlayer.TabIndex = 3;
            this.lblCurrentPlayer.Text = "Болсуновский П.Н.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Draw No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Source Players List:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(455, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Draw:";
            // 
            // grdSource
            // 
            this.grdSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn4.FormatString = "";
            objectListViewColumn4.Name = "Name";
            objectListViewColumn4.Sortable = false;
            objectListViewColumn4.Text = "Player";
            objectListViewColumn4.Width = 180;
            this.grdSource.Columns.Add(objectListViewColumn4);
            this.grdSource.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grdSource.HeaderHeight = 19;
            this.grdSource.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.grdSource.Location = new System.Drawing.Point(15, 35);
            this.grdSource.Name = "grdSource";
            this.grdSource.RowHeight = 17;
            this.grdSource.SelectedIndex = -1;
            this.grdSource.Size = new System.Drawing.Size(194, 259);
            this.grdSource.TabIndex = 2;
            this.grdSource.SelectedIndexChanged += new System.EventHandler(this.grdSource_SelectionChanged);
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = true;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(705, 306);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Down = false;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnCancel.Image = null;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(593, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Down = false;
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnOk.Image = null;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(486, 271);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(100, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Apply";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNext.Down = false;
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNext.Image = null;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(338, 133);
            this.btnNext.Name = "btnNext";
            this.btnNext.RadioButton = false;
            this.btnNext.Size = new System.Drawing.Size(100, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSkip.Down = false;
            this.btnSkip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnSkip.Image = null;
            this.btnSkip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSkip.Location = new System.Drawing.Point(228, 133);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.RadioButton = false;
            this.btnSkip.Size = new System.Drawing.Size(100, 23);
            this.btnSkip.TabIndex = 4;
            this.btnSkip.Text = "Skip";
            this.btnSkip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // grdDest
            // 
            this.grdDest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn5.FormatString = "";
            objectListViewColumn5.Name = "SeedNo";
            objectListViewColumn5.Text = "No";
            objectListViewColumn5.Width = 70;
            objectListViewColumn6.FormatString = "";
            objectListViewColumn6.Name = "Name";
            objectListViewColumn6.Sortable = false;
            objectListViewColumn6.Text = "Player";
            objectListViewColumn6.Width = 150;
            this.grdDest.Columns.Add(objectListViewColumn5);
            this.grdDest.Columns.Add(objectListViewColumn6);
            this.grdDest.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grdDest.HeaderHeight = 19;
            this.grdDest.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.grdDest.Location = new System.Drawing.Point(449, 35);
            this.grdDest.Name = "grdDest";
            this.grdDest.RowHeight = 17;
            this.grdDest.SelectedIndex = -1;
            this.grdDest.Size = new System.Drawing.Size(244, 230);
            this.grdDest.TabIndex = 6;
            // 
            // ibxDrawNo
            // 
            this.ibxDrawNo.Location = new System.Drawing.Point(338, 90);
            this.ibxDrawNo.MaximumSize = new System.Drawing.Size(100, 19);
            this.ibxDrawNo.MaximumValue = 100;
            this.ibxDrawNo.MinimumSize = new System.Drawing.Size(60, 19);
            this.ibxDrawNo.MinimumValue = 0;
            this.ibxDrawNo.Name = "ibxDrawNo";
            this.ibxDrawNo.Size = new System.Drawing.Size(100, 19);
            this.ibxDrawNo.TabIndex = 3;
            this.ibxDrawNo.Value = 0;
            this.ibxDrawNo.ValueChanged += new System.EventHandler(this.txtSeedNo_ValueChanged);
            // 
            // fManualSeeding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 306);
            this.Controls.Add(this.ibxDrawNo);
            this.Controls.Add(this.grdDest);
            this.Controls.Add(this.grdSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCurrentPlayer);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fManualSeeding";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Draw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.Label label5;
        private WindowSkin.Button btnSkip;
        private WindowSkin.Button btnNext;
        private WindowSkin.Button btnOk;
        private WindowSkin.Button btnCancel;
        private WindowSkin.Border border1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WindowSkin.ObjectListView grdSource;
        private WindowSkin.ObjectListView grdDest;
        private WindowSkin.IntegerBox ibxDrawNo;
    }
}