namespace TA.ExIm
{
    partial class fImport
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnClose = new WindowSkin.Button();
            this.btnStartOperation = new WindowSkin.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.border1 = new WindowSkin.Border();
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.btnCloseProgressPanel = new WindowSkin.Button();
            this.txtProgressErrors = new System.Windows.Forms.TextBox();
            this.border2 = new WindowSkin.Border();
            this.lblOperationProgress = new System.Windows.Forms.Label();
            this.lblTotalProgress = new System.Windows.Forms.Label();
            this.pbOperationProgress = new System.Windows.Forms.ProgressBar();
            this.pbTotalProgress = new System.Windows.Forms.ProgressBar();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "cmdx";
            this.openFileDialog.Filter = "Competition Manager data exchange files|*.cmdx;*.cmzx|Competition Manager data fi" +
                "les|*.cmdb|All files|*.*";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Down = false;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnClose.Image = null;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(396, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.RadioButton = false;
            this.btnClose.Size = new System.Drawing.Size(124, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Export";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStartOperation
            // 
            this.btnStartOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartOperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnStartOperation.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStartOperation.Down = false;
            this.btnStartOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnStartOperation.Image = null;
            this.btnStartOperation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartOperation.Location = new System.Drawing.Point(396, 49);
            this.btnStartOperation.Name = "btnStartOperation";
            this.btnStartOperation.RadioButton = false;
            this.btnStartOperation.Size = new System.Drawing.Size(124, 23);
            this.btnStartOperation.TabIndex = 11;
            this.btnStartOperation.Text = "Export";
            this.btnStartOperation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStartOperation.Click += new System.EventHandler(this.btnStartOperation_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(12, 29);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(126, 13);
            this.lblCaption.TabIndex = 10;
            this.lblCaption.Text = "Select data to export";
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(534, 362);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 9;
            this.border1.TabStop = false;
            // 
            // mainTreeView
            // 
            this.mainTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTreeView.BackColor = System.Drawing.SystemColors.Info;
            this.mainTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainTreeView.CheckBoxes = true;
            this.mainTreeView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mainTreeView.Location = new System.Drawing.Point(12, 49);
            this.mainTreeView.Name = "mainTreeView";
            this.mainTreeView.Size = new System.Drawing.Size(378, 290);
            this.mainTreeView.TabIndex = 8;
            this.mainTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.mainTreeView_AfterCheck);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProgress.Controls.Add(this.btnCloseProgressPanel);
            this.pnlProgress.Controls.Add(this.txtProgressErrors);
            this.pnlProgress.Controls.Add(this.border2);
            this.pnlProgress.Controls.Add(this.lblOperationProgress);
            this.pnlProgress.Controls.Add(this.lblTotalProgress);
            this.pnlProgress.Controls.Add(this.pbOperationProgress);
            this.pnlProgress.Controls.Add(this.pbTotalProgress);
            this.pnlProgress.Location = new System.Drawing.Point(89, 49);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(364, 290);
            this.pnlProgress.TabIndex = 13;
            this.pnlProgress.Visible = false;
            // 
            // btnCloseProgressPanel
            // 
            this.btnCloseProgressPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnCloseProgressPanel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCloseProgressPanel.Down = false;
            this.btnCloseProgressPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnCloseProgressPanel.Image = null;
            this.btnCloseProgressPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseProgressPanel.Location = new System.Drawing.Point(248, 253);
            this.btnCloseProgressPanel.Name = "btnCloseProgressPanel";
            this.btnCloseProgressPanel.RadioButton = false;
            this.btnCloseProgressPanel.Size = new System.Drawing.Size(98, 26);
            this.btnCloseProgressPanel.TabIndex = 6;
            this.btnCloseProgressPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCloseProgressPanel.Click += new System.EventHandler(this.btnCloseProgressPanel_Click);
            // 
            // txtProgressErrors
            // 
            this.txtProgressErrors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProgressErrors.Location = new System.Drawing.Point(17, 109);
            this.txtProgressErrors.Multiline = true;
            this.txtProgressErrors.Name = "txtProgressErrors";
            this.txtProgressErrors.ReadOnly = true;
            this.txtProgressErrors.Size = new System.Drawing.Size(329, 138);
            this.txtProgressErrors.TabIndex = 5;
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(364, 290);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 4;
            this.border2.TabStop = false;
            // 
            // lblOperationProgress
            // 
            this.lblOperationProgress.Location = new System.Drawing.Point(18, 55);
            this.lblOperationProgress.Name = "lblOperationProgress";
            this.lblOperationProgress.Size = new System.Drawing.Size(328, 30);
            this.lblOperationProgress.TabIndex = 3;
            this.lblOperationProgress.Text = "label2";
            this.lblOperationProgress.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTotalProgress
            // 
            this.lblTotalProgress.AutoSize = true;
            this.lblTotalProgress.Location = new System.Drawing.Point(18, 14);
            this.lblTotalProgress.Name = "lblTotalProgress";
            this.lblTotalProgress.Size = new System.Drawing.Size(35, 13);
            this.lblTotalProgress.TabIndex = 2;
            this.lblTotalProgress.Text = "label1";
            // 
            // pbOperationProgress
            // 
            this.pbOperationProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOperationProgress.Location = new System.Drawing.Point(17, 88);
            this.pbOperationProgress.Name = "pbOperationProgress";
            this.pbOperationProgress.Size = new System.Drawing.Size(330, 15);
            this.pbOperationProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbOperationProgress.TabIndex = 1;
            // 
            // pbTotalProgress
            // 
            this.pbTotalProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTotalProgress.Location = new System.Drawing.Point(16, 30);
            this.pbTotalProgress.Name = "pbTotalProgress";
            this.pbTotalProgress.Size = new System.Drawing.Size(330, 15);
            this.pbTotalProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTotalProgress.TabIndex = 0;
            // 
            // fImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 362);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartOperation);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.mainTreeView);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fImport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fImport";
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private WindowSkin.Button btnClose;
        private WindowSkin.Button btnStartOperation;
        private System.Windows.Forms.Label lblCaption;
        private WindowSkin.Border border1;
        private System.Windows.Forms.TreeView mainTreeView;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar pbTotalProgress;
        private System.Windows.Forms.Label lblOperationProgress;
        private System.Windows.Forms.Label lblTotalProgress;
        private System.Windows.Forms.ProgressBar pbOperationProgress;
        private WindowSkin.Button btnCloseProgressPanel;
        private System.Windows.Forms.TextBox txtProgressErrors;
        private WindowSkin.Border border2;
    }
}