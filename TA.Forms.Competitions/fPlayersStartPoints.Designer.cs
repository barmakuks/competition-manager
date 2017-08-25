namespace TA.Competitions.Forms
{
    partial class fPlayersStartPoints
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
            WindowSkin.ObjectListViewColumn objectListViewColumn1 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn2 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn3 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn4 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn5 = new WindowSkin.ObjectListViewColumn();
            this.lvPlayers = new WindowSkin.ObjectListView();
            this.btnClose = new WindowSkin.Button();
            this.btnRebuy = new WindowSkin.Button();
            this.border1 = new WindowSkin.Border();
            this.btnPlayersList = new WindowSkin.Button();
            this.btnSetStartPoints = new WindowSkin.Button();
            this.SuspendLayout();
            // 
            // lvPlayers
            // 
            this.lvPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn1.FormatString = "";
            objectListViewColumn1.Name = "FullName";
            objectListViewColumn1.Text = "Player";
            objectListViewColumn1.Width = 220;
            objectListViewColumn2.FormatString = "";
            objectListViewColumn2.Name = "StartPoints";
            objectListViewColumn2.Text = "Start points";
            objectListViewColumn2.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn2.TruncHeaderText = false;
            objectListViewColumn2.Width = 75;
            objectListViewColumn3.FormatString = "";
            objectListViewColumn3.Name = "Points";
            objectListViewColumn3.Text = "Points earned";
            objectListViewColumn3.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn3.TruncHeaderText = false;
            objectListViewColumn3.Width = 75;
            objectListViewColumn4.FormatString = "";
            objectListViewColumn4.Name = "RebuyPoints";
            objectListViewColumn4.Text = "Rebuy points";
            objectListViewColumn4.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn4.TruncHeaderText = false;
            objectListViewColumn4.Width = 75;
            objectListViewColumn5.FormatString = "";
            objectListViewColumn5.Name = "AvailablePoints";
            objectListViewColumn5.Text = "Available Points";
            objectListViewColumn5.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn5.TruncHeaderText = false;
            objectListViewColumn5.Width = 75;
            this.lvPlayers.Columns.Add(objectListViewColumn1);
            this.lvPlayers.Columns.Add(objectListViewColumn2);
            this.lvPlayers.Columns.Add(objectListViewColumn3);
            this.lvPlayers.Columns.Add(objectListViewColumn4);
            this.lvPlayers.Columns.Add(objectListViewColumn5);
            this.lvPlayers.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvPlayers.HeaderHeight = 36;
            this.lvPlayers.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lvPlayers.Location = new System.Drawing.Point(10, 25);
            this.lvPlayers.Name = "lvPlayers";
            this.lvPlayers.RowHeight = 19;
            this.lvPlayers.SelectedIndex = -1;
            this.lvPlayers.Size = new System.Drawing.Size(549, 389);
            this.lvPlayers.TabIndex = 0;
            this.lvPlayers.DoubleClick += new System.EventHandler(this.lvPlayers_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Down = false;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnClose.Image = null;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(459, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.RadioButton = false;
            this.btnClose.Size = new System.Drawing.Size(99, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRebuy
            // 
            this.btnRebuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRebuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnRebuy.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRebuy.Down = false;
            this.btnRebuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnRebuy.Image = null;
            this.btnRebuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRebuy.Location = new System.Drawing.Point(158, 420);
            this.btnRebuy.Name = "btnRebuy";
            this.btnRebuy.RadioButton = false;
            this.btnRebuy.Size = new System.Drawing.Size(141, 23);
            this.btnRebuy.TabIndex = 1;
            this.btnRebuy.Text = "Add or Remove points";
            this.btnRebuy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRebuy.Click += new System.EventHandler(this.btnRebuy_Click);
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(569, 455);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // btnPlayersList
            // 
            this.btnPlayersList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnPlayersList.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPlayersList.Down = false;
            this.btnPlayersList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnPlayersList.Image = null;
            this.btnPlayersList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayersList.Location = new System.Drawing.Point(304, 420);
            this.btnPlayersList.Name = "btnPlayersList";
            this.btnPlayersList.RadioButton = false;
            this.btnPlayersList.Size = new System.Drawing.Size(141, 23);
            this.btnPlayersList.TabIndex = 4;
            this.btnPlayersList.Text = "Players List";
            this.btnPlayersList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPlayersList.Click += new System.EventHandler(this.btnPlayersList_Click);
            // 
            // btnSetStartPoints
            // 
            this.btnSetStartPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetStartPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnSetStartPoints.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSetStartPoints.Down = false;
            this.btnSetStartPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnSetStartPoints.Image = null;
            this.btnSetStartPoints.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetStartPoints.Location = new System.Drawing.Point(12, 420);
            this.btnSetStartPoints.Name = "btnSetStartPoints";
            this.btnSetStartPoints.RadioButton = false;
            this.btnSetStartPoints.Size = new System.Drawing.Size(141, 23);
            this.btnSetStartPoints.TabIndex = 10001;
            this.btnSetStartPoints.Text = "Add or Remove points";
            this.btnSetStartPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSetStartPoints.Visible = false;
            this.btnSetStartPoints.Click += new System.EventHandler(this.btnSetStartPoints_Click);
            // 
            // fPlayersStartPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(569, 455);
            this.Controls.Add(this.btnSetStartPoints);
            this.Controls.Add(this.btnPlayersList);
            this.Controls.Add(this.lvPlayers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRebuy);
            this.Controls.Add(this.border1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fPlayersStartPoints";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add or Remove points";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowSkin.Border border1;
        private WindowSkin.Button btnRebuy;
        private WindowSkin.Button btnClose;
        private WindowSkin.ObjectListView lvPlayers;
        private WindowSkin.Button btnPlayersList;
        private WindowSkin.Button btnSetStartPoints;
    }
}