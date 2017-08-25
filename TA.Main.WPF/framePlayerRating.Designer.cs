namespace TA.Main
{
    partial class framePlayerRating
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
            this.components = new System.ComponentModel.Container();
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.btnExit = new WindowSkin.Button();
            this.btnPrint = new WindowSkin.Button();
            this.btnSave = new WindowSkin.Button();
            this.border1 = new WindowSkin.Border();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.border2 = new WindowSkin.Border();
            this.rsControl = new TA.RatingSystem.Builder.RSControl();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlToolBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnExit);
            this.pnlToolBar.Controls.Add(this.btnPrint);
            this.pnlToolBar.Controls.Add(this.btnSave);
            this.pnlToolBar.Controls.Add(this.border1);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(3, 3);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(608, 64);
            this.pnlToolBar.TabIndex = 3;
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
            this.btnExit.Location = new System.Drawing.Point(552, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.RadioButton = false;
            this.btnExit.Size = new System.Drawing.Size(48, 48);
            this.btnExit.TabIndex = 4;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnExit, "Close");
            this.btnExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Down = false;
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnPrint.Image = global::TA.Main.Properties.Resources.Crystal_Clear_action_fileprint_33_33;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(58, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RadioButton = false;
            this.btnPrint.Size = new System.Drawing.Size(48, 48);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnPrint, "Print");
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Down = false;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnSave.Image = global::TA.Main.Properties.Resources.app_act_save_disk_32x32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(8, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.RadioButton = false;
            this.btnSave.Size = new System.Drawing.Size(48, 48);
            this.btnSave.TabIndex = 2;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnSave, "Save to file");
            this.btnSave.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = false;
            this.border1.Size = new System.Drawing.Size(608, 64);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.border2);
            this.pnlMain.Controls.Add(this.rsControl);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 67);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(608, 372);
            this.pnlMain.TabIndex = 4;
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(608, 372);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 10000;
            this.border2.TabStop = false;
            // 
            // rsControl
            // 
            this.rsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rsControl.DeltaColor = System.Drawing.Color.Green;
            this.rsControl.HeaderBkColor = System.Drawing.Color.PaleGreen;
            this.rsControl.HeaderColor = System.Drawing.Color.Black;
            this.rsControl.LineColor = System.Drawing.Color.LightGray;
            this.rsControl.Location = new System.Drawing.Point(6, 7);
            this.rsControl.Name = "rsControl";
            this.rsControl.PenaltyColor = System.Drawing.Color.Red;
            this.rsControl.PlayersBkColor = System.Drawing.Color.LightCyan;
            this.rsControl.PlayersForeColor = System.Drawing.Color.Black;
            this.rsControl.RatingBkColor = System.Drawing.Color.LightCyan;
            this.rsControl.RatingForeColor = System.Drawing.Color.Black;
            this.rsControl.ResultsBkColor = System.Drawing.Color.WhiteSmoke;
            this.rsControl.Size = new System.Drawing.Size(594, 300);
            this.rsControl.TabIndex = 2;
            // 
            // framePlayerRating
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "framePlayerRating";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(614, 442);
            this.pnlToolBar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TA.RatingSystem.Builder.RSControl rsControl;
        private System.Windows.Forms.Panel pnlToolBar;
        private WindowSkin.Button btnPrint;
        private WindowSkin.Button btnSave;
        private WindowSkin.Border border1;
        private System.Windows.Forms.Panel pnlMain;
        private WindowSkin.Border border2;
        private WindowSkin.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip;


    }
}
