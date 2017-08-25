namespace TA.Main
{
    partial class fTournamentInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new WindowSkin.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlace = new WindowSkin.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new WindowSkin.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new WindowSkin.Button();
            this.btnCompetitionEdit = new WindowSkin.Button();
            this.btnCompetitionAdd = new WindowSkin.Button();
            this.btnClose = new WindowSkin.Button();
            this.border1 = new WindowSkin.Border();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new WindowSkin.Button();
            this.border3 = new WindowSkin.Border();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvCompetitions = new WindowSkin.ObjectListView();
            this.label6 = new System.Windows.Forms.Label();
            this.border2 = new WindowSkin.Border();
            this.saveXmlDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tournament Title";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtName.Location = new System.Drawing.Point(20, 68);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = false;
            this.txtName.Size = new System.Drawing.Size(306, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(370, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Place";
            // 
            // txtPlace
            // 
            this.txtPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPlace.Location = new System.Drawing.Point(373, 68);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.ReadOnly = false;
            this.txtPlace.Size = new System.Drawing.Size(275, 20);
            this.txtPlace.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(17, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tournament Date";
            // 
            // txtDateBegin
            // 
            this.txtDateBegin.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.txtDateBegin.CalendarTitleBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtDateBegin.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.txtDateBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateBegin.Location = new System.Drawing.Point(198, 15);
            this.txtDateBegin.Name = "txtDateBegin";
            this.txtDateBegin.Size = new System.Drawing.Size(128, 20);
            this.txtDateBegin.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(334, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Finish";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.txtDateEnd.CalendarTitleBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtDateEnd.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.txtDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateEnd.Location = new System.Drawing.Point(373, 15);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(128, 20);
            this.txtDateEnd.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Down = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnSave.Image = null;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(663, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.RadioButton = false;
            this.btnSave.Size = new System.Drawing.Size(93, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(135, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Start";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.Down = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnDelete.Image = null;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(215, 309);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RadioButton = false;
            this.btnDelete.Size = new System.Drawing.Size(93, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Remove";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCompetitionEdit
            // 
            this.btnCompetitionEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompetitionEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnCompetitionEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCompetitionEdit.Down = false;
            this.btnCompetitionEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCompetitionEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnCompetitionEdit.Image = null;
            this.btnCompetitionEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompetitionEdit.Location = new System.Drawing.Point(115, 309);
            this.btnCompetitionEdit.Name = "btnCompetitionEdit";
            this.btnCompetitionEdit.RadioButton = false;
            this.btnCompetitionEdit.Size = new System.Drawing.Size(93, 23);
            this.btnCompetitionEdit.TabIndex = 2;
            this.btnCompetitionEdit.Text = "Open";
            this.btnCompetitionEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCompetitionEdit.Click += new System.EventHandler(this.btnCompetitionEdit_Click);
            // 
            // btnCompetitionAdd
            // 
            this.btnCompetitionAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompetitionAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnCompetitionAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCompetitionAdd.Down = false;
            this.btnCompetitionAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCompetitionAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnCompetitionAdd.Image = null;
            this.btnCompetitionAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompetitionAdd.Location = new System.Drawing.Point(16, 309);
            this.btnCompetitionAdd.Name = "btnCompetitionAdd";
            this.btnCompetitionAdd.RadioButton = false;
            this.btnCompetitionAdd.Size = new System.Drawing.Size(93, 23);
            this.btnCompetitionAdd.TabIndex = 1;
            this.btnCompetitionAdd.Text = "Create";
            this.btnCompetitionAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCompetitionAdd.Click += new System.EventHandler(this.btnCompetitionAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Down = false;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnClose.Image = null;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(663, 309);
            this.btnClose.Name = "btnClose";
            this.btnClose.RadioButton = false;
            this.btnClose.Size = new System.Drawing.Size(93, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.border1.Size = new System.Drawing.Size(788, 486);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.border3);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtPlace);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDateBegin);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDateEnd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(8, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 111);
            this.panel1.TabIndex = 13;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Down = false;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnExport.Image = null;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(663, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.RadioButton = false;
            this.btnExport.Size = new System.Drawing.Size(93, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // border3
            // 
            this.border3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border3.Location = new System.Drawing.Point(0, 0);
            this.border3.MinimizedBox = false;
            this.border3.Name = "border3";
            this.border3.ShowCaption = false;
            this.border3.Size = new System.Drawing.Size(772, 111);
            this.border3.Sizeable = false;
            this.border3.TabIndex = 10000;
            this.border3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lvCompetitions);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.border2);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnCompetitionAdd);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnCompetitionEdit);
            this.panel2.Location = new System.Drawing.Point(8, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 346);
            this.panel2.TabIndex = 14;
            // 
            // lvCompetitions
            // 
            this.lvCompetitions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCompetitions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn1.FormatString = "";
            objectListViewColumn1.Name = "Info.Id";
            objectListViewColumn1.Sortable = false;
            objectListViewColumn1.Text = "Id";
            objectListViewColumn1.TruncHeaderText = false;
            objectListViewColumn1.Visible = false;
            objectListViewColumn2.FormatString = "";
            objectListViewColumn2.Name = "Info.SportType.Name";
            objectListViewColumn2.Text = "Game";
            objectListViewColumn2.TruncHeaderText = false;
            objectListViewColumn3.FormatString = "";
            objectListViewColumn3.Name = "Info.Name";
            objectListViewColumn3.Text = "Competition Title";
            objectListViewColumn3.TruncHeaderText = false;
            objectListViewColumn3.Width = 180;
            objectListViewColumn4.FormatString = "";
            objectListViewColumn4.Name = "Info.PlayerCount";
            objectListViewColumn4.Text = "Players";
            objectListViewColumn4.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn4.TruncHeaderText = false;
            objectListViewColumn4.Width = 85;
            objectListViewColumn5.FormatString = "";
            objectListViewColumn5.Name = "Info.StatusString";
            objectListViewColumn5.Text = "Current State";
            objectListViewColumn5.TruncHeaderText = false;
            objectListViewColumn5.Width = 150;
            objectListViewColumn6.FormatString = "";
            objectListViewColumn6.Name = "Info.CompetitionTypeName";
            objectListViewColumn6.Text = "Competition Format";
            objectListViewColumn6.Width = 200;
            this.lvCompetitions.Columns.Add(objectListViewColumn1);
            this.lvCompetitions.Columns.Add(objectListViewColumn2);
            this.lvCompetitions.Columns.Add(objectListViewColumn3);
            this.lvCompetitions.Columns.Add(objectListViewColumn4);
            this.lvCompetitions.Columns.Add(objectListViewColumn5);
            this.lvCompetitions.Columns.Add(objectListViewColumn6);
            this.lvCompetitions.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvCompetitions.HeaderHeight = 19;
            this.lvCompetitions.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lvCompetitions.Location = new System.Drawing.Point(16, 28);
            this.lvCompetitions.Name = "lvCompetitions";
            this.lvCompetitions.RowHeight = 19;
            this.lvCompetitions.SelectedIndex = -1;
            this.lvCompetitions.Size = new System.Drawing.Size(740, 275);
            this.lvCompetitions.TabIndex = 8;
            this.lvCompetitions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCompetitions_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(13, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tournament Competitions";
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(772, 346);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 10000;
            this.border2.TabStop = false;
            // 
            // saveXmlDialog
            // 
            this.saveXmlDialog.DefaultExt = "txml";
            this.saveXmlDialog.Filter = "Tournament export files|*.txml";
            this.saveXmlDialog.RestoreDirectory = true;
            this.saveXmlDialog.Title = "Tournament Export";
            // 
            // fTournamentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(788, 486);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.border1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(723, 255);
            this.Name = "fTournamentInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tournament Information";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private WindowSkin.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private WindowSkin.TextBox txtPlace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDateBegin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtDateEnd;
        private WindowSkin.Button btnSave;
        private System.Windows.Forms.Label label5;
        private WindowSkin.Button btnCompetitionEdit;
        private WindowSkin.Button btnCompetitionAdd;
        private WindowSkin.Button btnClose;
        private WindowSkin.Button btnDelete;
        private WindowSkin.Border border1;
        private System.Windows.Forms.Panel panel1;
        private WindowSkin.Border border3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private WindowSkin.Border border2;
        private WindowSkin.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveXmlDialog;
        private WindowSkin.ObjectListView lvCompetitions;
    }
}