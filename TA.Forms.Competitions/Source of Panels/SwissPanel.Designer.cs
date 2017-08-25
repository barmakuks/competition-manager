namespace TA.Competitions.Forms
{
    partial class SwissPanel
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

        #region Component Designer generated code

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
            this.border1 = new WindowSkin.Border();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.ibxPrizeCount = new WindowSkin.IntegerBox();
            this.btnCancelRound = new WindowSkin.Button();
            this.lblPrizeCount = new System.Windows.Forms.Label();
            this.lblRoundCount = new System.Windows.Forms.Label();
            this.btnNextRound = new WindowSkin.Button();
            this.lvResults = new WindowSkin.ObjectListView();
            this.pnlTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictMain
            // 
            this.pictMain.Location = new System.Drawing.Point(294, 48);
            this.pictMain.Size = new System.Drawing.Size(499, 328);
            this.pictMain.TabIndex = 2;
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = false;
            this.border1.Size = new System.Drawing.Size(793, 48);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.ibxPrizeCount);
            this.pnlTools.Controls.Add(this.btnCancelRound);
            this.pnlTools.Controls.Add(this.lblPrizeCount);
            this.pnlTools.Controls.Add(this.lblRoundCount);
            this.pnlTools.Controls.Add(this.btnNextRound);
            this.pnlTools.Controls.Add(this.border1);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTools.Location = new System.Drawing.Point(0, 0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(793, 48);
            this.pnlTools.TabIndex = 0;
            // 
            // ibxPrizeCount
            // 
            this.ibxPrizeCount.Location = new System.Drawing.Point(394, 16);
            this.ibxPrizeCount.MaximumSize = new System.Drawing.Size(100, 19);
            this.ibxPrizeCount.MaximumValue = 16;
            this.ibxPrizeCount.MinimumSize = new System.Drawing.Size(60, 19);
            this.ibxPrizeCount.MinimumValue = 1;
            this.ibxPrizeCount.Name = "ibxPrizeCount";
            this.ibxPrizeCount.Size = new System.Drawing.Size(60, 19);
            this.ibxPrizeCount.TabIndex = 2;
            this.ibxPrizeCount.Value = 1;
            this.ibxPrizeCount.ValueChanged += new System.EventHandler(this.txtPrizeCount_ValueChanged);
            // 
            // btnCancelRound
            // 
            this.btnCancelRound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnCancelRound.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancelRound.Down = false;
            this.btnCancelRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancelRound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnCancelRound.Image = null;
            this.btnCancelRound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelRound.Location = new System.Drawing.Point(142, 13);
            this.btnCancelRound.Name = "btnCancelRound";
            this.btnCancelRound.RadioButton = false;
            this.btnCancelRound.Size = new System.Drawing.Size(140, 23);
            this.btnCancelRound.TabIndex = 1;
            this.btnCancelRound.Text = "Cancel Round";
            this.btnCancelRound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelRound.Click += new System.EventHandler(this.btnCancelRound_Click);
            // 
            // lblPrizeCount
            // 
            this.lblPrizeCount.AutoSize = true;
            this.lblPrizeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrizeCount.Location = new System.Drawing.Point(299, 19);
            this.lblPrizeCount.Name = "lblPrizeCount";
            this.lblPrizeCount.Size = new System.Drawing.Size(89, 13);
            this.lblPrizeCount.TabIndex = 2;
            this.lblPrizeCount.Text = "Number of prizes:";
            // 
            // lblRoundCount
            // 
            this.lblRoundCount.AutoSize = true;
            this.lblRoundCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRoundCount.Location = new System.Drawing.Point(482, 19);
            this.lblRoundCount.Name = "lblRoundCount";
            this.lblRoundCount.Size = new System.Drawing.Size(170, 13);
            this.lblRoundCount.TabIndex = 4;
            this.lblRoundCount.Text = "Recommended number of rounds :";
            // 
            // btnNextRound
            // 
            this.btnNextRound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnNextRound.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNextRound.Down = false;
            this.btnNextRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNextRound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnNextRound.Image = null;
            this.btnNextRound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextRound.Location = new System.Drawing.Point(15, 13);
            this.btnNextRound.Name = "btnNextRound";
            this.btnNextRound.RadioButton = false;
            this.btnNextRound.Size = new System.Drawing.Size(120, 23);
            this.btnNextRound.TabIndex = 0;
            this.btnNextRound.Text = "Next Round";
            this.btnNextRound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextRound.Click += new System.EventHandler(this.btnNextRound_Click);
            // 
            // lvResults
            // 
            this.lvResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            objectListViewColumn1.FormatString = "";
            objectListViewColumn1.Name = "CurrentPlace";
            objectListViewColumn1.Text = "";
            objectListViewColumn1.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn1.Width = 30;
            objectListViewColumn2.FormatString = "";
            objectListViewColumn2.Name = "NickName";
            objectListViewColumn2.Text = "Players";
            objectListViewColumn2.Width = 150;
            objectListViewColumn3.ConvertValueString = true;
            objectListViewColumn3.FormatString = "";
            objectListViewColumn3.Name = "TotalPoints";
            objectListViewColumn3.Sortable = false;
            objectListViewColumn3.Text = "Pts";
            objectListViewColumn3.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn3.Width = 40;
            objectListViewColumn4.ConvertValueString = true;
            objectListViewColumn4.FormatString = "";
            objectListViewColumn4.Name = "Tag";
            objectListViewColumn4.Sortable = false;
            objectListViewColumn4.Text = "KB";
            objectListViewColumn4.TextAlignment = System.Drawing.StringAlignment.Center;
            objectListViewColumn4.Width = 40;
            this.lvResults.Columns.Add(objectListViewColumn1);
            this.lvResults.Columns.Add(objectListViewColumn2);
            this.lvResults.Columns.Add(objectListViewColumn3);
            this.lvResults.Columns.Add(objectListViewColumn4);
            this.lvResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvResults.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvResults.HeaderHeight = 19;
            this.lvResults.LinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lvResults.Location = new System.Drawing.Point(0, 48);
            this.lvResults.Name = "lvResults";
            this.lvResults.RowHeight = 19;
            this.lvResults.SelectedIndex = -1;
            this.lvResults.Size = new System.Drawing.Size(294, 328);
            this.lvResults.TabIndex = 1;
            this.lvResults.GetCellString += new WindowSkin.ObjectListViewGetItemString(this.lvResults_OnGetCellString_1);
            // 
            // SwissPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lvResults);
            this.Controls.Add(this.pnlTools);
            this.Name = "SwissPanel";
            this.Size = new System.Drawing.Size(793, 376);
            this.OnMatchEdit += new TA.Competitions.Forms.OnMatchEdit(this.CompetitionSwissPanel_OnMatchEdit);
            this.Controls.SetChildIndex(this.pnlTools, 0);
            this.Controls.SetChildIndex(this.lvResults, 0);
            this.Controls.SetChildIndex(this.pictMain, 0);
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowSkin.Border border1;
        protected System.Windows.Forms.Label lblPrizeCount;
        protected System.Windows.Forms.Panel pnlTools;
        protected WindowSkin.Button btnNextRound;
        protected WindowSkin.ObjectListView lvResults;
        protected WindowSkin.Button btnCancelRound;
        protected WindowSkin.IntegerBox ibxPrizeCount;
        protected System.Windows.Forms.Label lblRoundCount;
    }
}
