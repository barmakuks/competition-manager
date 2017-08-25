namespace TA.Main
{
    partial class fPlayersList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPlayersList));
            this.tcPlayers = new System.Windows.Forms.TabControl();
            this.tpgPlayers = new System.Windows.Forms.TabPage();
            this.lvPlayerList = new WindowSkin.ObjectListView();
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.btnDelete = new WindowSkin.Button();
            this.btnExit = new WindowSkin.Button();
            this.btnEdit = new WindowSkin.Button();
            this.btnAdd = new WindowSkin.Button();
            this.border2 = new WindowSkin.Border();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddTab = new WindowSkin.Button();
            this.btnDeleteTab = new WindowSkin.Button();
            this.border1 = new WindowSkin.Border();
            this.tcPlayers.SuspendLayout();
            this.tpgPlayers.SuspendLayout();
            this.pnlToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPlayers
            // 
            this.tcPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPlayers.Controls.Add(this.tpgPlayers);
            this.tcPlayers.Location = new System.Drawing.Point(9, 21);
            this.tcPlayers.Name = "tcPlayers";
            this.tcPlayers.SelectedIndex = 0;
            this.tcPlayers.Size = new System.Drawing.Size(758, 554);
            this.tcPlayers.TabIndex = 1;
            this.tcPlayers.DoubleClick += new System.EventHandler(this.tcPlayers_DoubleClick);
            this.tcPlayers.SelectedIndexChanged += new System.EventHandler(this.tcPlayers_SelectedIndexChanged);
            // 
            // tpgPlayers
            // 
            this.tpgPlayers.Controls.Add(this.lvPlayerList);
            this.tpgPlayers.Controls.Add(this.pnlToolBar);
            this.tpgPlayers.Location = new System.Drawing.Point(4, 22);
            this.tpgPlayers.Name = "tpgPlayers";
            this.tpgPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tpgPlayers.Size = new System.Drawing.Size(750, 528);
            this.tpgPlayers.TabIndex = 0;
            this.tpgPlayers.Text = "Players List";
            this.tpgPlayers.UseVisualStyleBackColor = true;
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
            this.lvPlayerList.Location = new System.Drawing.Point(3, 67);
            this.lvPlayerList.Name = "lvPlayerList";
            this.lvPlayerList.RowHeight = 19;
            this.lvPlayerList.SelectedIndex = -1;
            this.lvPlayerList.Size = new System.Drawing.Size(746, 461);
            this.lvPlayerList.TabIndex = 7;
            this.lvPlayerList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPlayerList_MouseDoubleClick);
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnDelete);
            this.pnlToolBar.Controls.Add(this.btnExit);
            this.pnlToolBar.Controls.Add(this.btnEdit);
            this.pnlToolBar.Controls.Add(this.btnAdd);
            this.pnlToolBar.Controls.Add(this.border2);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(3, 3);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(744, 64);
            this.pnlToolBar.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.Down = false;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnDelete.Image = global::TA.Main.Properties.Resources.players_list_delete_40x40;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Location = new System.Drawing.Point(106, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RadioButton = false;
            this.btnDelete.Size = new System.Drawing.Size(48, 48);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnDelete, "Remove Registration");
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Down = false;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnExit.Image = global::TA.Main.Properties.Resources.players_exit_40x40;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.Location = new System.Drawing.Point(688, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.RadioButton = false;
            this.btnExit.Size = new System.Drawing.Size(48, 48);
            this.btnExit.TabIndex = 3;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnExit, "Close List");
            this.btnExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEdit.Down = false;
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnEdit.Image = global::TA.Main.Properties.Resources.players_list_edit_40x40;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.Location = new System.Drawing.Point(57, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RadioButton = false;
            this.btnEdit.Size = new System.Drawing.Size(48, 48);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnEdit, "Edit Registration Info");
            this.btnEdit.Click += new System.EventHandler(this.btnPlayerEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Down = false;
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnAdd.Image = global::TA.Main.Properties.Resources.players_list_add_40x40;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(8, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RadioButton = false;
            this.btnAdd.Size = new System.Drawing.Size(48, 48);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnAdd, "New Player Registration");
            this.btnAdd.Click += new System.EventHandler(this.btnPlayerAdd_Click);
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(744, 64);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 10000;
            this.border2.TabStop = false;
            // 
            // btnAddTab
            // 
            this.btnAddTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnAddTab.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddTab.Down = false;
            this.btnAddTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnAddTab.Image = null;
            this.btnAddTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTab.Location = new System.Drawing.Point(269, 20);
            this.btnAddTab.Name = "btnAddTab";
            this.btnAddTab.RadioButton = false;
            this.btnAddTab.Size = new System.Drawing.Size(21, 21);
            this.btnAddTab.TabIndex = 2;
            this.btnAddTab.Text = "+";
            this.btnAddTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnAddTab, "New Rating List");
            this.btnAddTab.Click += new System.EventHandler(this.btnAddTab_Click);
            // 
            // btnDeleteTab
            // 
            this.btnDeleteTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnDeleteTab.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeleteTab.Down = false;
            this.btnDeleteTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnDeleteTab.Image = null;
            this.btnDeleteTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteTab.Location = new System.Drawing.Point(291, 20);
            this.btnDeleteTab.Name = "btnDeleteTab";
            this.btnDeleteTab.RadioButton = false;
            this.btnDeleteTab.Size = new System.Drawing.Size(24, 21);
            this.btnDeleteTab.TabIndex = 4;
            this.btnDeleteTab.Text = "-";
            this.btnDeleteTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnDeleteTab, "Remove Rating List");
            this.btnDeleteTab.Click += new System.EventHandler(this.btnDeleteTab_Click);
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
            this.border1.Size = new System.Drawing.Size(776, 583);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // fPlayersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 583);
            this.Controls.Add(this.btnDeleteTab);
            this.Controls.Add(this.btnAddTab);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.tcPlayers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fPlayersList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Players List";
            this.tcPlayers.ResumeLayout(false);
            this.tpgPlayers.ResumeLayout(false);
            this.pnlToolBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPlayers;
        private System.Windows.Forms.TabPage tpgPlayers;
        private WindowSkin.Border border1;
        private System.Windows.Forms.Panel pnlToolBar;
        private WindowSkin.Button btnEdit;
        private WindowSkin.Button btnAdd;
        private WindowSkin.Border border2;
        private WindowSkin.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip;
        private WindowSkin.ObjectListView lvPlayerList;
        private WindowSkin.Button btnDelete;
        private WindowSkin.Button btnAddTab;
        private WindowSkin.Button btnDeleteTab;
    }
}