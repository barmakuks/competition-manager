namespace TA.Main
{
    partial class fMain
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
            this.components = new System.ComponentModel.Container();
            WindowSkin.ObjectListViewColumn objectListViewColumn1 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn2 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn3 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn4 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn5 = new WindowSkin.ObjectListViewColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDownload = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDownloadPrompt = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.olvTournaments = new WindowSkin.ObjectListView();
            this.btnImport = new WindowSkin.Button();
            this.btnExport = new WindowSkin.Button();
            this.btnDownload = new WindowSkin.Button();
            this.btnSettings = new WindowSkin.Button();
            this.btnExit = new WindowSkin.Button();
            this.btnAbout = new WindowSkin.Button();
            this.btnDelete = new WindowSkin.Button();
            this.btnTournamentEdit = new WindowSkin.Button();
            this.btnTournamentAdd = new WindowSkin.Button();
            this.btnPlayerList = new WindowSkin.Button();
            this.border2 = new WindowSkin.Border();
            this.border1 = new WindowSkin.Border();
            this.panel1.SuspendLayout();
            this.pnlDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.pnlDownload);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnAbout);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnTournamentEdit);
            this.panel1.Controls.Add(this.btnTournamentAdd);
            this.panel1.Controls.Add(this.btnPlayerList);
            this.panel1.Controls.Add(this.border2);
            this.panel1.Location = new System.Drawing.Point(8, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 64);
            this.panel1.TabIndex = 4;
            // 
            // pnlDownload
            // 
            this.pnlDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDownload.Controls.Add(this.btnDownload);
            this.pnlDownload.Controls.Add(this.label2);
            this.pnlDownload.Controls.Add(this.lblDownloadPrompt);
            this.pnlDownload.Location = new System.Drawing.Point(337, 8);
            this.pnlDownload.Name = "pnlDownload";
            this.pnlDownload.Size = new System.Drawing.Size(373, 49);
            this.pnlDownload.TabIndex = 10;
            this.pnlDownload.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(115, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "www.competition-manager.com";
            this.label2.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lblDownloadPrompt
            // 
            this.lblDownloadPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDownloadPrompt.Location = new System.Drawing.Point(17, 5);
            this.lblDownloadPrompt.Name = "lblDownloadPrompt";
            this.lblDownloadPrompt.Size = new System.Drawing.Size(299, 15);
            this.lblDownloadPrompt.TabIndex = 3;
            this.lblDownloadPrompt.Text = "There is a newer version of Competition Manager on the site";
            this.lblDownloadPrompt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // olvTournaments
            // 
            this.olvTournaments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.olvTournaments.BackColor = System.Drawing.SystemColors.Control;
            objectListViewColumn1.FormatString = null;
            objectListViewColumn1.Name = "Info.Id";
            objectListViewColumn1.Text = "Id";
            objectListViewColumn1.Visible = false;
            objectListViewColumn2.FormatString = "dd.MM.yyyy";
            objectListViewColumn2.Name = "Info.DateBegin";
            objectListViewColumn2.Text = "Start Date";
            objectListViewColumn2.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn2.Width = 120;
            objectListViewColumn3.FormatString = "dd.MM.yyyy";
            objectListViewColumn3.Name = "Info.DateEnd";
            objectListViewColumn3.Text = "Finish Date";
            objectListViewColumn3.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn3.Width = 120;
            objectListViewColumn4.FormatString = null;
            objectListViewColumn4.Name = "Info.Place";
            objectListViewColumn4.Text = "Tournament Place";
            objectListViewColumn4.Width = 200;
            objectListViewColumn5.FormatString = null;
            objectListViewColumn5.Name = "Info.Name";
            objectListViewColumn5.Text = "Tournament Title";
            objectListViewColumn5.Width = 400;
            this.olvTournaments.Columns.Add(objectListViewColumn1);
            this.olvTournaments.Columns.Add(objectListViewColumn2);
            this.olvTournaments.Columns.Add(objectListViewColumn3);
            this.olvTournaments.Columns.Add(objectListViewColumn4);
            this.olvTournaments.Columns.Add(objectListViewColumn5);
            this.olvTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.olvTournaments.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.olvTournaments.HeaderHeight = 21;
            this.olvTournaments.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.olvTournaments.Location = new System.Drawing.Point(8, 81);
            this.olvTournaments.Name = "olvTournaments";
            this.olvTournaments.RowHeight = 19;
            this.olvTournaments.SelectedIndex = -1;
            this.olvTournaments.Size = new System.Drawing.Size(870, 584);
            this.olvTournaments.TabIndex = 5;
            this.olvTournaments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.olvTournaments_MouseDoubleClick);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnImport.Down = false;
            this.btnImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnImport.Image = global::TA.Main.Properties.Resources.db_import_40x40;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImport.Location = new System.Drawing.Point(271, 8);
            this.btnImport.Name = "btnImport";
            this.btnImport.RadioButton = false;
            this.btnImport.Size = new System.Drawing.Size(48, 48);
            this.btnImport.TabIndex = 11;
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnImport, "Export / Import");
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Down = false;
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnExport.Image = global::TA.Main.Properties.Resources.db_export_40x40;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExport.Location = new System.Drawing.Point(222, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.RadioButton = false;
            this.btnExport.Size = new System.Drawing.Size(48, 48);
            this.btnExport.TabIndex = 4;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnExport, "Export / Import");
            this.btnExport.Click += new System.EventHandler(this.btnExIm_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnDownload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDownload.Down = false;
            this.btnDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnDownload.Image = global::TA.Main.Properties.Resources.home_32x32;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDownload.Location = new System.Drawing.Point(322, 0);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.RadioButton = false;
            this.btnDownload.Size = new System.Drawing.Size(48, 48);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnDownload, "Settings");
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnSettings.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSettings.Down = false;
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnSettings.Image = global::TA.Main.Properties.Resources.settings_alt_32x32;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSettings.Location = new System.Drawing.Point(716, 8);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.RadioButton = false;
            this.btnSettings.Size = new System.Drawing.Size(48, 48);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnSettings, "Settings");
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Down = false;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnExit.Image = global::TA.Main.Properties.Resources.exit_40x40;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.Location = new System.Drawing.Point(815, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.RadioButton = false;
            this.btnExit.Size = new System.Drawing.Size(48, 48);
            this.btnExit.TabIndex = 7;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnExit, "Exit Program");
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnAbout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAbout.Down = false;
            this.btnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnAbout.Image = global::TA.Main.Properties.Resources.action_button_info_32x32;
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAbout.Location = new System.Drawing.Point(766, 8);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.RadioButton = false;
            this.btnAbout.Size = new System.Drawing.Size(48, 48);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnAbout, "About...");
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.Down = false;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnDelete.Image = global::TA.Main.Properties.Resources.tournament_delete_40x401;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Location = new System.Drawing.Point(164, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RadioButton = false;
            this.btnDelete.Size = new System.Drawing.Size(48, 48);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnDelete, "Remove Tournament");
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTournamentEdit
            // 
            this.btnTournamentEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnTournamentEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTournamentEdit.Down = false;
            this.btnTournamentEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnTournamentEdit.Image = global::TA.Main.Properties.Resources.tournament_edit_40x40;
            this.btnTournamentEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTournamentEdit.Location = new System.Drawing.Point(115, 8);
            this.btnTournamentEdit.Name = "btnTournamentEdit";
            this.btnTournamentEdit.RadioButton = false;
            this.btnTournamentEdit.Size = new System.Drawing.Size(48, 48);
            this.btnTournamentEdit.TabIndex = 2;
            this.btnTournamentEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnTournamentEdit, "Open Tournament");
            this.btnTournamentEdit.Click += new System.EventHandler(this.btnTournamentEdit_Click);
            // 
            // btnTournamentAdd
            // 
            this.btnTournamentAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnTournamentAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTournamentAdd.Down = false;
            this.btnTournamentAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnTournamentAdd.Image = global::TA.Main.Properties.Resources.tournament_add_40x40;
            this.btnTournamentAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTournamentAdd.Location = new System.Drawing.Point(66, 8);
            this.btnTournamentAdd.Name = "btnTournamentAdd";
            this.btnTournamentAdd.RadioButton = false;
            this.btnTournamentAdd.Size = new System.Drawing.Size(48, 48);
            this.btnTournamentAdd.TabIndex = 1;
            this.btnTournamentAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnTournamentAdd, "Create New Tournament");
            this.btnTournamentAdd.Click += new System.EventHandler(this.btnTournamentAdd_Click);
            // 
            // btnPlayerList
            // 
            this.btnPlayerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.btnPlayerList.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPlayerList.Down = false;
            this.btnPlayerList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnPlayerList.Image = global::TA.Main.Properties.Resources.players_list_40x40;
            this.btnPlayerList.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPlayerList.Location = new System.Drawing.Point(8, 8);
            this.btnPlayerList.Name = "btnPlayerList";
            this.btnPlayerList.RadioButton = false;
            this.btnPlayerList.Size = new System.Drawing.Size(48, 48);
            this.btnPlayerList.TabIndex = 0;
            this.btnPlayerList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnPlayerList, "Players List");
            this.btnPlayerList.Click += new System.EventHandler(this.btnPlayersList_Click);
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(871, 64);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 1;
            this.border2.TabStop = false;
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(62)))), ((int)(((byte)(33)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = true;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(887, 673);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 673);
            this.Controls.Add(this.olvTournaments);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.border1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(35)))), ((int)(((byte)(4)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Competition Manager";
            this.panel1.ResumeLayout(false);
            this.pnlDownload.ResumeLayout(false);
            this.pnlDownload.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowSkin.Border border1;
        private System.Windows.Forms.Panel panel1;
        private WindowSkin.Button btnAbout;
        private WindowSkin.Button btnDelete;
        private WindowSkin.Button btnTournamentEdit;
        private WindowSkin.Button btnTournamentAdd;
        private WindowSkin.Button btnPlayerList;
        private WindowSkin.Border border2;
        private WindowSkin.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip;
        private WindowSkin.ObjectListView olvTournaments;
        private WindowSkin.Button btnSettings;
        private System.Windows.Forms.Panel pnlDownload;
        private System.Windows.Forms.Label lblDownloadPrompt;
        private System.Windows.Forms.Label label2;
        private WindowSkin.Button btnDownload;
        private WindowSkin.Button btnExport;
        private WindowSkin.Button btnImport;
    }
}

