namespace TA.Main
{
    partial class fImportPlayers
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
            WindowSkin.ObjectListViewColumn objectListViewColumn6 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn7 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn8 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn9 = new WindowSkin.ObjectListViewColumn();
            this.border1 = new WindowSkin.Border();
            this.lvPlayerList = new WindowSkin.ObjectListView();
            this.pnlImportParams = new System.Windows.Forms.Panel();
            this.border2 = new WindowSkin.Border();
            this.cbxOnlyNew = new WindowSkin.CheckBox();
            this.cbxUpdateInfo = new WindowSkin.CheckBox();
            this.btnStart = new WindowSkin.Button();
            this.btnClose = new WindowSkin.Button();
            this.prbProgress = new System.Windows.Forms.ProgressBar();
            this.cbxImportRating = new WindowSkin.CheckBox();
            this.lstGames = new WindowSkin.CheckList();
            this.pnlImportParams.SuspendLayout();
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
            this.border1.Size = new System.Drawing.Size(735, 462);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 0;
            this.border1.TabStop = false;
            // 
            // lvPlayerList
            // 
            this.lvPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPlayerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn1.FormatString = "";
            objectListViewColumn1.Name = "Identofier";
            objectListViewColumn1.Text = "Identofier";
            objectListViewColumn1.Visible = false;
            objectListViewColumn2.FormatString = "";
            objectListViewColumn2.Name = "NickName";
            objectListViewColumn2.Text = "Nickname";
            objectListViewColumn2.Width = 150;
            objectListViewColumn3.FormatString = "";
            objectListViewColumn3.Name = "LastName";
            objectListViewColumn3.Text = "Surname";
            objectListViewColumn3.Width = 150;
            objectListViewColumn4.FormatString = "";
            objectListViewColumn4.Name = "FirstName";
            objectListViewColumn4.Text = "Name";
            objectListViewColumn5.FormatString = "";
            objectListViewColumn5.Name = "PatronymicName";
            objectListViewColumn5.Text = "Отчество";
            objectListViewColumn5.Visible = false;
            objectListViewColumn6.FormatString = "";
            objectListViewColumn6.Name = "Country";
            objectListViewColumn6.Text = "Country";
            objectListViewColumn7.FormatString = "";
            objectListViewColumn7.Name = "City";
            objectListViewColumn7.Text = "Address";
            objectListViewColumn8.FormatString = "";
            objectListViewColumn8.Name = "Phone";
            objectListViewColumn8.Text = "Phone";
            objectListViewColumn9.FormatString = "";
            objectListViewColumn9.Name = "EMail";
            objectListViewColumn9.Text = "e-mail";
            this.lvPlayerList.Columns.Add(objectListViewColumn1);
            this.lvPlayerList.Columns.Add(objectListViewColumn2);
            this.lvPlayerList.Columns.Add(objectListViewColumn3);
            this.lvPlayerList.Columns.Add(objectListViewColumn4);
            this.lvPlayerList.Columns.Add(objectListViewColumn5);
            this.lvPlayerList.Columns.Add(objectListViewColumn6);
            this.lvPlayerList.Columns.Add(objectListViewColumn7);
            this.lvPlayerList.Columns.Add(objectListViewColumn8);
            this.lvPlayerList.Columns.Add(objectListViewColumn9);
            this.lvPlayerList.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvPlayerList.HeaderHeight = 19;
            this.lvPlayerList.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lvPlayerList.Location = new System.Drawing.Point(12, 179);
            this.lvPlayerList.Name = "lvPlayerList";
            this.lvPlayerList.RowHeight = 19;
            this.lvPlayerList.SelectedIndex = -1;
            this.lvPlayerList.Size = new System.Drawing.Size(711, 271);
            this.lvPlayerList.TabIndex = 8;
            // 
            // pnlImportParams
            // 
            this.pnlImportParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImportParams.Controls.Add(this.lstGames);
            this.pnlImportParams.Controls.Add(this.cbxImportRating);
            this.pnlImportParams.Controls.Add(this.btnClose);
            this.pnlImportParams.Controls.Add(this.btnStart);
            this.pnlImportParams.Controls.Add(this.cbxUpdateInfo);
            this.pnlImportParams.Controls.Add(this.cbxOnlyNew);
            this.pnlImportParams.Controls.Add(this.border2);
            this.pnlImportParams.Location = new System.Drawing.Point(12, 24);
            this.pnlImportParams.Name = "pnlImportParams";
            this.pnlImportParams.Size = new System.Drawing.Size(711, 149);
            this.pnlImportParams.TabIndex = 9;
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(711, 149);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 0;
            this.border2.TabStop = false;
            // 
            // cbxOnlyNew
            // 
            this.cbxOnlyNew.Location = new System.Drawing.Point(17, 16);
            this.cbxOnlyNew.Name = "cbxOnlyNew";
            this.cbxOnlyNew.Size = new System.Drawing.Size(367, 15);
            this.cbxOnlyNew.TabIndex = 1;
            this.cbxOnlyNew.Text = "Импортировать данные только незарегистрированных игроков";
            this.cbxOnlyNew.CheckedChanged += new System.EventHandler(this.cbxOnlyNew_CheckedChanged);
            // 
            // cbxUpdateInfo
            // 
            this.cbxUpdateInfo.Location = new System.Drawing.Point(17, 37);
            this.cbxUpdateInfo.Name = "cbxUpdateInfo";
            this.cbxUpdateInfo.Size = new System.Drawing.Size(314, 15);
            this.cbxUpdateInfo.TabIndex = 2;
            this.cbxUpdateInfo.Text = "Перезаписывать данные зарегистрированных игроков";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStart.Down = false;
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnStart.Image = null;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(581, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.RadioButton = false;
            this.btnStart.Size = new System.Drawing.Size(113, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Импортировать";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Down = false;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnClose.Image = null;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(581, 45);
            this.btnClose.Name = "btnClose";
            this.btnClose.RadioButton = false;
            this.btnClose.Size = new System.Drawing.Size(113, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // prbProgress
            // 
            this.prbProgress.Location = new System.Drawing.Point(198, 257);
            this.prbProgress.Name = "prbProgress";
            this.prbProgress.Size = new System.Drawing.Size(323, 13);
            this.prbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prbProgress.TabIndex = 5;
            // 
            // cbxImportRating
            // 
            this.cbxImportRating.Location = new System.Drawing.Point(17, 58);
            this.cbxImportRating.Name = "cbxImportRating";
            this.cbxImportRating.Size = new System.Drawing.Size(282, 15);
            this.cbxImportRating.TabIndex = 5;
            this.cbxImportRating.Text = "Импортирование рейтинга";
            // 
            // lstGames
            // 
            this.lstGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            this.lstGames.CheckedObjects = new object[0];
            this.lstGames.ItemHeight = 15;
            this.lstGames.Location = new System.Drawing.Point(186, 58);
            this.lstGames.Name = "lstGames";
            this.lstGames.SelectedIndex = -1;
            this.lstGames.Size = new System.Drawing.Size(323, 74);
            this.lstGames.TabIndex = 6;
            this.lstGames.VerticalScrollVisible = true;
            this.lstGames.ViewFrom = 0;
            // 
            // fImportPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 462);
            this.Controls.Add(this.prbProgress);
            this.Controls.Add(this.pnlImportParams);
            this.Controls.Add(this.lvPlayerList);
            this.Controls.Add(this.border1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fImportPlayers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Players";
            this.pnlImportParams.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowSkin.Border border1;
        private WindowSkin.ObjectListView lvPlayerList;
        private System.Windows.Forms.Panel pnlImportParams;
        private WindowSkin.Border border2;
        private WindowSkin.CheckBox cbxUpdateInfo;
        private WindowSkin.CheckBox cbxOnlyNew;
        private WindowSkin.Button btnStart;
        private WindowSkin.Button btnClose;
        private System.Windows.Forms.ProgressBar prbProgress;
        private WindowSkin.CheckList lstGames;
        private WindowSkin.CheckBox cbxImportRating;
    }
}