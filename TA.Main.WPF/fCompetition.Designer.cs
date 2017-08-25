namespace TA.Main
{
    partial class fCompetition
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
            WindowSkin.ObjectListViewColumn objectListViewColumn6 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn7 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn8 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn9 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn10 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn11 = new WindowSkin.ObjectListViewColumn();
            WindowSkin.ObjectListViewColumn objectListViewColumn12 = new WindowSkin.ObjectListViewColumn();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpgProperties = new System.Windows.Forms.TabPage();
            this.pnlProperties = new System.Windows.Forms.Panel();
            this.lvCompetitionPlayers = new WindowSkin.ObjectListView();
            this.lblCompetitionTypeDescription = new System.Windows.Forms.Label();
            this.btnChangeProperties = new WindowSkin.Button();
            this.btnSeedFinish = new WindowSkin.Button();
            this.btnPlayerAdd = new WindowSkin.Button();
            this.txtCurrentState = new WindowSkin.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompetitionType = new WindowSkin.TextBox();
            this.txtTypeOfSport = new WindowSkin.TextBox();
            this.cbxChangesRating = new WindowSkin.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompetitionName = new WindowSkin.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.border2 = new WindowSkin.Border();
            this.tpgCompetition = new System.Windows.Forms.TabPage();
            this.pnlScalePicture = new System.Windows.Forms.Panel();
            this.ibxScale = new WindowSkin.IntegerBox();
            this.btnFinish = new WindowSkin.Button();
            this.btnSavePicture = new WindowSkin.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrintPicture = new WindowSkin.Button();
            this.border11 = new WindowSkin.Border();
            this.tpgResults = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.border9 = new WindowSkin.Border();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvPlayerPlace = new WindowSkin.ObjectListView();
            this.lvRatingAfter = new WindowSkin.ObjectListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSaveResults = new WindowSkin.Button();
            this.border8 = new WindowSkin.Border();
            this.btnPrizeMoney = new WindowSkin.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new WindowSkin.Button();
            this.border3 = new WindowSkin.Border();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.border1 = new WindowSkin.Border();
            this.tcMain.SuspendLayout();
            this.tpgProperties.SuspendLayout();
            this.pnlProperties.SuspendLayout();
            this.tpgCompetition.SuspendLayout();
            this.pnlScalePicture.SuspendLayout();
            this.tpgResults.SuspendLayout();
            this.panel5.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpgProperties);
            this.tcMain.Controls.Add(this.tpgCompetition);
            this.tcMain.Controls.Add(this.tpgResults);
            this.tcMain.Location = new System.Drawing.Point(10, 11);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(981, 510);
            this.tcMain.TabIndex = 1;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tpgProperties
            // 
            this.tpgProperties.Controls.Add(this.pnlProperties);
            this.tpgProperties.Location = new System.Drawing.Point(4, 22);
            this.tpgProperties.Name = "tpgProperties";
            this.tpgProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tpgProperties.Size = new System.Drawing.Size(973, 484);
            this.tpgProperties.TabIndex = 4;
            this.tpgProperties.Text = "Registration and Draw";
            this.tpgProperties.UseVisualStyleBackColor = true;
            // 
            // pnlProperties
            // 
            this.pnlProperties.Controls.Add(this.lvCompetitionPlayers);
            this.pnlProperties.Controls.Add(this.lblCompetitionTypeDescription);
            this.pnlProperties.Controls.Add(this.btnChangeProperties);
            this.pnlProperties.Controls.Add(this.btnSeedFinish);
            this.pnlProperties.Controls.Add(this.btnPlayerAdd);
            this.pnlProperties.Controls.Add(this.txtCurrentState);
            this.pnlProperties.Controls.Add(this.label3);
            this.pnlProperties.Controls.Add(this.txtCompetitionType);
            this.pnlProperties.Controls.Add(this.txtTypeOfSport);
            this.pnlProperties.Controls.Add(this.cbxChangesRating);
            this.pnlProperties.Controls.Add(this.label4);
            this.pnlProperties.Controls.Add(this.label2);
            this.pnlProperties.Controls.Add(this.txtCompetitionName);
            this.pnlProperties.Controls.Add(this.label1);
            this.pnlProperties.Controls.Add(this.border2);
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProperties.Location = new System.Drawing.Point(3, 3);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.Size = new System.Drawing.Size(967, 478);
            this.pnlProperties.TabIndex = 0;
            // 
            // lvCompetitionPlayers
            // 
            this.lvCompetitionPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCompetitionPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn1.FormatString = "";
            objectListViewColumn1.Name = "SeedNo";
            objectListViewColumn1.Text = "Draw";
            objectListViewColumn1.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn1.Width = 65;
            objectListViewColumn2.FormatString = "";
            objectListViewColumn2.Name = "FullName";
            objectListViewColumn2.Text = "Player";
            objectListViewColumn2.TruncHeaderText = false;
            objectListViewColumn2.Width = 210;
            objectListViewColumn3.FormatString = "";
            objectListViewColumn3.Name = "RatingBeforeCompetition";
            objectListViewColumn3.Text = "Start Rating";
            objectListViewColumn3.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn3.TruncHeaderText = false;
            objectListViewColumn3.Width = 75;
            this.lvCompetitionPlayers.Columns.Add(objectListViewColumn1);
            this.lvCompetitionPlayers.Columns.Add(objectListViewColumn2);
            this.lvCompetitionPlayers.Columns.Add(objectListViewColumn3);
            this.lvCompetitionPlayers.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvCompetitionPlayers.HeaderHeight = 34;
            this.lvCompetitionPlayers.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lvCompetitionPlayers.Location = new System.Drawing.Point(488, 26);
            this.lvCompetitionPlayers.Name = "lvCompetitionPlayers";
            this.lvCompetitionPlayers.RowHeight = 19;
            this.lvCompetitionPlayers.SelectedIndex = -1;
            this.lvCompetitionPlayers.Size = new System.Drawing.Size(295, 437);
            this.lvCompetitionPlayers.TabIndex = 38;
            // 
            // lblCompetitionTypeDescription
            // 
            this.lblCompetitionTypeDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCompetitionTypeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCompetitionTypeDescription.Location = new System.Drawing.Point(29, 172);
            this.lblCompetitionTypeDescription.Name = "lblCompetitionTypeDescription";
            this.lblCompetitionTypeDescription.Size = new System.Drawing.Size(453, 57);
            this.lblCompetitionTypeDescription.TabIndex = 36;
            // 
            // btnChangeProperties
            // 
            this.btnChangeProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnChangeProperties.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnChangeProperties.Down = false;
            this.btnChangeProperties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnChangeProperties.Image = null;
            this.btnChangeProperties.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeProperties.Location = new System.Drawing.Point(312, 315);
            this.btnChangeProperties.Name = "btnChangeProperties";
            this.btnChangeProperties.RadioButton = false;
            this.btnChangeProperties.Size = new System.Drawing.Size(170, 23);
            this.btnChangeProperties.TabIndex = 33;
            this.btnChangeProperties.Tag = "1";
            this.btnChangeProperties.Text = "Edit Parameters";
            this.btnChangeProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnChangeProperties.Click += new System.EventHandler(this.btnChangeProperties_Click);
            // 
            // btnSeedFinish
            // 
            this.btnSeedFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeedFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnSeedFinish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSeedFinish.Down = false;
            this.btnSeedFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnSeedFinish.Image = null;
            this.btnSeedFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeedFinish.Location = new System.Drawing.Point(789, 315);
            this.btnSeedFinish.Name = "btnSeedFinish";
            this.btnSeedFinish.RadioButton = false;
            this.btnSeedFinish.Size = new System.Drawing.Size(162, 23);
            this.btnSeedFinish.TabIndex = 32;
            this.btnSeedFinish.Text = "Start Competition";
            this.btnSeedFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSeedFinish.Click += new System.EventHandler(this.btnSeedFinish_Click);
            // 
            // btnPlayerAdd
            // 
            this.btnPlayerAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayerAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnPlayerAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPlayerAdd.Down = false;
            this.btnPlayerAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnPlayerAdd.Image = null;
            this.btnPlayerAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayerAdd.Location = new System.Drawing.Point(789, 26);
            this.btnPlayerAdd.Name = "btnPlayerAdd";
            this.btnPlayerAdd.RadioButton = false;
            this.btnPlayerAdd.Size = new System.Drawing.Size(162, 23);
            this.btnPlayerAdd.TabIndex = 28;
            this.btnPlayerAdd.Text = "List of Competition Players ";
            this.btnPlayerAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPlayerAdd.Click += new System.EventHandler(this.btnPlayerAdd_Click);
            // 
            // txtCurrentState
            // 
            this.txtCurrentState.Location = new System.Drawing.Point(29, 264);
            this.txtCurrentState.Name = "txtCurrentState";
            this.txtCurrentState.ReadOnly = true;
            this.txtCurrentState.Size = new System.Drawing.Size(453, 20);
            this.txtCurrentState.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Current State";
            // 
            // txtCompetitionType
            // 
            this.txtCompetitionType.Location = new System.Drawing.Point(29, 143);
            this.txtCompetitionType.Name = "txtCompetitionType";
            this.txtCompetitionType.ReadOnly = true;
            this.txtCompetitionType.Size = new System.Drawing.Size(453, 20);
            this.txtCompetitionType.TabIndex = 25;
            // 
            // txtTypeOfSport
            // 
            this.txtTypeOfSport.Location = new System.Drawing.Point(29, 41);
            this.txtTypeOfSport.Name = "txtTypeOfSport";
            this.txtTypeOfSport.ReadOnly = true;
            this.txtTypeOfSport.Size = new System.Drawing.Size(204, 20);
            this.txtTypeOfSport.TabIndex = 22;
            // 
            // cbxChangesRating
            // 
            this.cbxChangesRating.AutoSize = true;
            this.cbxChangesRating.Enabled = false;
            this.cbxChangesRating.Location = new System.Drawing.Point(239, 43);
            this.cbxChangesRating.Name = "cbxChangesRating";
            this.cbxChangesRating.Size = new System.Drawing.Size(119, 15);
            this.cbxChangesRating.TabIndex = 23;
            this.cbxChangesRating.Text = "Rating Competition";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Type of Sport";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Competition Format";
            // 
            // txtCompetitionName
            // 
            this.txtCompetitionName.Location = new System.Drawing.Point(29, 92);
            this.txtCompetitionName.Name = "txtCompetitionName";
            this.txtCompetitionName.ReadOnly = true;
            this.txtCompetitionName.Size = new System.Drawing.Size(453, 20);
            this.txtCompetitionName.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Competition Name";
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(967, 478);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 10000;
            this.border2.TabStop = false;
            // 
            // tpgCompetition
            // 
            this.tpgCompetition.AutoScroll = true;
            this.tpgCompetition.Controls.Add(this.pnlScalePicture);
            this.tpgCompetition.Location = new System.Drawing.Point(4, 22);
            this.tpgCompetition.Name = "tpgCompetition";
            this.tpgCompetition.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCompetition.Size = new System.Drawing.Size(973, 484);
            this.tpgCompetition.TabIndex = 2;
            this.tpgCompetition.Text = "Matches and Current Results";
            this.tpgCompetition.UseVisualStyleBackColor = true;
            // 
            // pnlScalePicture
            // 
            this.pnlScalePicture.Controls.Add(this.ibxScale);
            this.pnlScalePicture.Controls.Add(this.btnFinish);
            this.pnlScalePicture.Controls.Add(this.btnSavePicture);
            this.pnlScalePicture.Controls.Add(this.label7);
            this.pnlScalePicture.Controls.Add(this.btnPrintPicture);
            this.pnlScalePicture.Controls.Add(this.border11);
            this.pnlScalePicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScalePicture.Location = new System.Drawing.Point(3, 3);
            this.pnlScalePicture.Name = "pnlScalePicture";
            this.pnlScalePicture.Size = new System.Drawing.Size(967, 46);
            this.pnlScalePicture.TabIndex = 1;
            // 
            // ibxScale
            // 
            this.ibxScale.Increment = 10;
            this.ibxScale.Location = new System.Drawing.Point(175, 13);
            this.ibxScale.MaximumSize = new System.Drawing.Size(100, 19);
            this.ibxScale.MaximumValue = 300;
            this.ibxScale.MinimumSize = new System.Drawing.Size(60, 19);
            this.ibxScale.MinimumValue = 50;
            this.ibxScale.Name = "ibxScale";
            this.ibxScale.Size = new System.Drawing.Size(60, 19);
            this.ibxScale.TabIndex = 2;
            this.ibxScale.Value = 100;
            this.ibxScale.WheelStep = 20;
            this.ibxScale.ValueChanged += new System.EventHandler(this.udScale_ValueChanged);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFinish.Down = false;
            this.btnFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnFinish.Image = null;
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(719, 12);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.RadioButton = false;
            this.btnFinish.Size = new System.Drawing.Size(238, 23);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Finish Competition";
            this.btnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnSavePicture
            // 
            this.btnSavePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnSavePicture.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSavePicture.Down = false;
            this.btnSavePicture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnSavePicture.Image = global::TA.Main.Properties.Resources.app_act_save_disk_24x24;
            this.btnSavePicture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePicture.Location = new System.Drawing.Point(47, 8);
            this.btnSavePicture.Name = "btnSavePicture";
            this.btnSavePicture.RadioButton = false;
            this.btnSavePicture.Size = new System.Drawing.Size(35, 30);
            this.btnSavePicture.TabIndex = 1;
            this.btnSavePicture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.btnSavePicture, "Save");
            this.btnSavePicture.Click += new System.EventHandler(this.btnSavePicture_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(100, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Scale View";
            // 
            // btnPrintPicture
            // 
            this.btnPrintPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnPrintPicture.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintPicture.Down = false;
            this.btnPrintPicture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnPrintPicture.Image = global::TA.Main.Properties.Resources.Crystal_Clear_action_fileprint_24x24;
            this.btnPrintPicture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintPicture.Location = new System.Drawing.Point(9, 8);
            this.btnPrintPicture.Name = "btnPrintPicture";
            this.btnPrintPicture.RadioButton = false;
            this.btnPrintPicture.Size = new System.Drawing.Size(35, 30);
            this.btnPrintPicture.TabIndex = 0;
            this.btnPrintPicture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.btnPrintPicture, "Print");
            this.btnPrintPicture.Click += new System.EventHandler(this.btnPrintPicture_Click);
            // 
            // border11
            // 
            this.border11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border11.Location = new System.Drawing.Point(0, 0);
            this.border11.MinimizedBox = false;
            this.border11.Name = "border11";
            this.border11.ShowCaption = false;
            this.border11.Size = new System.Drawing.Size(967, 46);
            this.border11.Sizeable = false;
            this.border11.TabIndex = 10000;
            this.border11.TabStop = false;
            // 
            // tpgResults
            // 
            this.tpgResults.Controls.Add(this.panel5);
            this.tpgResults.Controls.Add(this.panel2);
            this.tpgResults.Location = new System.Drawing.Point(4, 22);
            this.tpgResults.Name = "tpgResults";
            this.tpgResults.Padding = new System.Windows.Forms.Padding(3);
            this.tpgResults.Size = new System.Drawing.Size(973, 484);
            this.tpgResults.TabIndex = 3;
            this.tpgResults.Text = "Final Results";
            this.tpgResults.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.border9);
            this.panel5.Controls.Add(this.splitContainer1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 49);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(967, 432);
            this.panel5.TabIndex = 8;
            // 
            // border9
            // 
            this.border9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border9.Location = new System.Drawing.Point(0, 0);
            this.border9.MinimizedBox = false;
            this.border9.Name = "border9";
            this.border9.ShowCaption = false;
            this.border9.Size = new System.Drawing.Size(967, 432);
            this.border9.Sizeable = false;
            this.border9.TabIndex = 10000;
            this.border9.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 7);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvPlayerPlace);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvRatingAfter);
            this.splitContainer1.Size = new System.Drawing.Size(947, 417);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 7;
            // 
            // lvPlayerPlace
            // 
            this.lvPlayerPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn4.FormatString = "";
            objectListViewColumn4.Name = "Place";
            objectListViewColumn4.Text = "Place";
            objectListViewColumn4.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn4.TruncHeaderText = false;
            objectListViewColumn4.Width = 60;
            objectListViewColumn5.FormatString = "";
            objectListViewColumn5.Name = "FullName";
            objectListViewColumn5.Text = "Player";
            objectListViewColumn5.Width = 220;
            objectListViewColumn6.FormatString = "";
            objectListViewColumn6.Name = "TotalPoints";
            objectListViewColumn6.Text = "Points";
            objectListViewColumn6.Width = 60;
            this.lvPlayerPlace.Columns.Add(objectListViewColumn4);
            this.lvPlayerPlace.Columns.Add(objectListViewColumn5);
            this.lvPlayerPlace.Columns.Add(objectListViewColumn6);
            this.lvPlayerPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPlayerPlace.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvPlayerPlace.HeaderHeight = 32;
            this.lvPlayerPlace.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lvPlayerPlace.Location = new System.Drawing.Point(0, 0);
            this.lvPlayerPlace.Name = "lvPlayerPlace";
            this.lvPlayerPlace.RowHeight = 19;
            this.lvPlayerPlace.SelectedIndex = -1;
            this.lvPlayerPlace.Size = new System.Drawing.Size(348, 417);
            this.lvPlayerPlace.TabIndex = 0;
            // 
            // lvRatingAfter
            // 
            this.lvRatingAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn7.FormatString = "";
            objectListViewColumn7.Name = "PlayerName";
            objectListViewColumn7.Text = "Player";
            objectListViewColumn7.TruncHeaderText = false;
            objectListViewColumn7.Width = 200;
            objectListViewColumn8.FormatString = "";
            objectListViewColumn8.Name = "RatingBegin";
            objectListViewColumn8.Text = "Start Rating";
            objectListViewColumn8.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn8.TruncHeaderText = false;
            objectListViewColumn8.Width = 80;
            objectListViewColumn9.FormatString = "";
            objectListViewColumn9.Name = "OpponentsCount";
            objectListViewColumn9.Text = "Number of Opponents";
            objectListViewColumn9.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn9.TruncHeaderText = false;
            objectListViewColumn9.Width = 80;
            objectListViewColumn10.ConvertValueString = true;
            objectListViewColumn10.FormatString = "";
            objectListViewColumn10.Name = "Points";
            objectListViewColumn10.Text = "Sum of Points";
            objectListViewColumn10.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn10.TruncHeaderText = false;
            objectListViewColumn10.Width = 80;
            objectListViewColumn11.FormatString = "";
            objectListViewColumn11.Name = "Delta";
            objectListViewColumn11.Text = "Change in Rating";
            objectListViewColumn11.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn11.TruncHeaderText = false;
            objectListViewColumn11.Width = 80;
            objectListViewColumn12.FormatString = "";
            objectListViewColumn12.Name = "RatingEnd";
            objectListViewColumn12.Text = "Final Rating";
            objectListViewColumn12.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn12.TruncHeaderText = false;
            objectListViewColumn12.Width = 80;
            this.lvRatingAfter.Columns.Add(objectListViewColumn7);
            this.lvRatingAfter.Columns.Add(objectListViewColumn8);
            this.lvRatingAfter.Columns.Add(objectListViewColumn9);
            this.lvRatingAfter.Columns.Add(objectListViewColumn10);
            this.lvRatingAfter.Columns.Add(objectListViewColumn11);
            this.lvRatingAfter.Columns.Add(objectListViewColumn12);
            this.lvRatingAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRatingAfter.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvRatingAfter.HeaderHeight = 32;
            this.lvRatingAfter.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lvRatingAfter.Location = new System.Drawing.Point(0, 0);
            this.lvRatingAfter.Name = "lvRatingAfter";
            this.lvRatingAfter.RowHeight = 19;
            this.lvRatingAfter.SelectedIndex = -1;
            this.lvRatingAfter.Size = new System.Drawing.Size(594, 417);
            this.lvRatingAfter.TabIndex = 0;
            this.lvRatingAfter.GetCellString += new WindowSkin.ObjectListViewGetItemString(this.lvRatingAfter_OnGetCellString);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSaveResults);
            this.panel2.Controls.Add(this.border8);
            this.panel2.Controls.Add(this.btnPrizeMoney);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 46);
            this.panel2.TabIndex = 6;
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnSaveResults.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveResults.Down = false;
            this.btnSaveResults.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnSaveResults.Image = global::TA.Main.Properties.Resources.app_act_save_disk_24x24;
            this.btnSaveResults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveResults.Location = new System.Drawing.Point(9, 8);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.RadioButton = false;
            this.btnSaveResults.Size = new System.Drawing.Size(35, 30);
            this.btnSaveResults.TabIndex = 8;
            this.btnSaveResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.btnSaveResults, "Save Compertition Report in HTML");
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // border8
            // 
            this.border8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border8.Location = new System.Drawing.Point(0, 0);
            this.border8.MinimizedBox = false;
            this.border8.Name = "border8";
            this.border8.ShowCaption = false;
            this.border8.Size = new System.Drawing.Size(967, 46);
            this.border8.Sizeable = false;
            this.border8.TabIndex = 10000;
            this.border8.TabStop = false;
            // 
            // btnPrizeMoney
            // 
            this.btnPrizeMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnPrizeMoney.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrizeMoney.Down = false;
            this.btnPrizeMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnPrizeMoney.Image = null;
            this.btnPrizeMoney.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrizeMoney.Location = new System.Drawing.Point(452, 12);
            this.btnPrizeMoney.Name = "btnPrizeMoney";
            this.btnPrizeMoney.RadioButton = false;
            this.btnPrizeMoney.Size = new System.Drawing.Size(174, 23);
            this.btnPrizeMoney.TabIndex = 6;
            this.btnPrizeMoney.Text = "Призовой фонд";
            this.btnPrizeMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrizeMoney.Visible = false;
            this.btnPrizeMoney.Click += new System.EventHandler(this.btnPrizeMoney_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.border3);
            this.panel1.Controls.Add(this.tcMain);
            this.panel1.Location = new System.Drawing.Point(9, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 528);
            this.panel1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Down = false;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnClose.Image = global::TA.Main.Properties.Resources.app_act_exit_20x20;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Location = new System.Drawing.Point(962, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.RadioButton = false;
            this.btnClose.Size = new System.Drawing.Size(26, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // border3
            // 
            this.border3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border3.Location = new System.Drawing.Point(0, 0);
            this.border3.MinimizedBox = false;
            this.border3.Name = "border3";
            this.border3.ShowCaption = false;
            this.border3.Size = new System.Drawing.Size(996, 528);
            this.border3.Sizeable = false;
            this.border3.TabIndex = 10000;
            this.border3.TabStop = false;
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "JPEG format|*.jpg|Bitmap format|*.bmp|PNG format|*.png|GIF format|*.gif";
            this.saveDialog.RestoreDirectory = true;
            this.saveDialog.Title = "Save Picture";
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(1014, 556);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            this.border1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.border1_MouseDoubleClick);
            // 
            // fCompetition
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1014, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.border1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fCompetition";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tcMain.ResumeLayout(false);
            this.tpgProperties.ResumeLayout(false);
            this.pnlProperties.ResumeLayout(false);
            this.pnlProperties.PerformLayout();
            this.tpgCompetition.ResumeLayout(false);
            this.pnlScalePicture.ResumeLayout(false);
            this.pnlScalePicture.PerformLayout();
            this.tpgResults.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpgCompetition;
        private System.Windows.Forms.TabPage tpgResults;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private WindowSkin.Button btnPrizeMoney;
        private WindowSkin.Border border1;
        private System.Windows.Forms.Panel panel1;
        private WindowSkin.Border border3;
        private WindowSkin.Border border8;
        private System.Windows.Forms.Panel panel5;
        private WindowSkin.Border border9;
        private WindowSkin.Button btnClose;
        private System.Windows.Forms.TabPage tpgProperties;
        private System.Windows.Forms.Panel pnlProperties;
        private WindowSkin.TextBox txtCompetitionType;
        private WindowSkin.TextBox txtTypeOfSport;
        private WindowSkin.CheckBox cbxChangesRating;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private WindowSkin.TextBox txtCompetitionName;
        private System.Windows.Forms.Label label1;
        private WindowSkin.TextBox txtCurrentState;
        private System.Windows.Forms.Label label3;
        private WindowSkin.Border border2;
        private System.Windows.Forms.Panel pnlScalePicture;
        private WindowSkin.Button btnSavePicture;
        private System.Windows.Forms.Label label7;
        private WindowSkin.Button btnPrintPicture;
        private WindowSkin.Border border11;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private WindowSkin.Button btnFinish;
        private WindowSkin.Button btnSeedFinish;
        private WindowSkin.Button btnPlayerAdd;
        private WindowSkin.Button btnChangeProperties;
        private System.Windows.Forms.Label lblCompetitionTypeDescription;
        private WindowSkin.ObjectListView lvCompetitionPlayers;
        private WindowSkin.ObjectListView lvPlayerPlace;
        private WindowSkin.ObjectListView lvRatingAfter;
        private System.Windows.Forms.ToolTip toolTip1;
        private WindowSkin.IntegerBox ibxScale;
        private WindowSkin.Button btnSaveResults;
    }
}