namespace TA.ExIm
{
    partial class fExport
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
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.lblCaption = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnStartOperation = new WindowSkin.Button();
            this.border1 = new WindowSkin.Border();
            this.btnClose = new WindowSkin.Button();
            this.SuspendLayout();
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
            this.mainTreeView.Size = new System.Drawing.Size(406, 290);
            this.mainTreeView.TabIndex = 3;
            this.mainTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.mainTreeView_AfterCheck);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(12, 29);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(126, 13);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "Select data to export";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "cmdx";
            this.saveFileDialog.Filter = "Competition Manager data exchange files|*.cmdx|Competition Manager data exchange " +
                "zipped files|*.cmzx";
            this.saveFileDialog.RestoreDirectory = true;
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
            this.btnStartOperation.Location = new System.Drawing.Point(437, 49);
            this.btnStartOperation.Name = "btnStartOperation";
            this.btnStartOperation.RadioButton = false;
            this.btnStartOperation.Size = new System.Drawing.Size(124, 23);
            this.btnStartOperation.TabIndex = 6;
            this.btnStartOperation.Text = "Export";
            this.btnStartOperation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStartOperation.Click += new System.EventHandler(this.btnStartOperation_Click);
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
            this.border1.Size = new System.Drawing.Size(585, 351);
            this.border1.Sizeable = true;
            this.border1.TabIndex = 4;
            this.border1.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(437, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.RadioButton = false;
            this.btnClose.Size = new System.Drawing.Size(124, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Export";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 351);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartOperation);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.mainTreeView);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fExport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export / Import Operations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView mainTreeView;
        private WindowSkin.Border border1;
        private System.Windows.Forms.Label lblCaption;
        private WindowSkin.Button btnStartOperation;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private WindowSkin.Button btnClose;
    }
}