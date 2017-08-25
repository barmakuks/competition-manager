namespace TA.Competitions.Forms
{
    partial class fFipsMatchEdit
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
            this.border1 = new WindowSkin.Border();
            this.btnOk = new WindowSkin.Button();
            this.btnCancel = new WindowSkin.Button();
            this.rbtnNoResult = new System.Windows.Forms.RadioButton();
            this.rbtnMatchOver = new System.Windows.Forms.RadioButton();
            this.lblPlayerA = new System.Windows.Forms.Label();
            this.lblPlayerB = new System.Windows.Forms.Label();
            this.txtPointsA = new WindowSkin.TextBox();
            this.txtPointsB = new WindowSkin.TextBox();
            this.pnlMatchResults = new System.Windows.Forms.Panel();
            this.btnRight = new WindowSkin.Button();
            this.btnLeft = new WindowSkin.Button();
            this.pnlMatchResults.SuspendLayout();
            this.SuspendLayout();
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
            this.border1.Size = new System.Drawing.Size(343, 153);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Down = false;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnOk.Image = null;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(90, 112);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Down = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnCancel.Image = null;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(175, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtnNoResult
            // 
            this.rbtnNoResult.AutoSize = true;
            this.rbtnNoResult.Checked = true;
            this.rbtnNoResult.Location = new System.Drawing.Point(46, 28);
            this.rbtnNoResult.Name = "rbtnNoResult";
            this.rbtnNoResult.Size = new System.Drawing.Size(143, 17);
            this.rbtnNoResult.TabIndex = 27;
            this.rbtnNoResult.TabStop = true;
            this.rbtnNoResult.Text = "The match is not finished";
            this.rbtnNoResult.UseVisualStyleBackColor = true;
            this.rbtnNoResult.CheckedChanged += new System.EventHandler(this.rbtnNoResult_CheckedChanged);
            // 
            // rbtnMatchOver
            // 
            this.rbtnMatchOver.AutoSize = true;
            this.rbtnMatchOver.Location = new System.Drawing.Point(46, 51);
            this.rbtnMatchOver.Name = "rbtnMatchOver";
            this.rbtnMatchOver.Size = new System.Drawing.Size(168, 17);
            this.rbtnMatchOver.TabIndex = 28;
            this.rbtnMatchOver.Text = "The match ended with a result";
            this.rbtnMatchOver.UseVisualStyleBackColor = true;
            this.rbtnMatchOver.CheckedChanged += new System.EventHandler(this.rbtnNoResult_CheckedChanged);
            // 
            // lblPlayerA
            // 
            this.lblPlayerA.Location = new System.Drawing.Point(3, 3);
            this.lblPlayerA.Name = "lblPlayerA";
            this.lblPlayerA.Size = new System.Drawing.Size(113, 22);
            this.lblPlayerA.TabIndex = 29;
            this.lblPlayerA.Text = "Karnauhov";
            this.lblPlayerA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayerB
            // 
            this.lblPlayerB.Location = new System.Drawing.Point(213, 3);
            this.lblPlayerB.Name = "lblPlayerB";
            this.lblPlayerB.Size = new System.Drawing.Size(113, 22);
            this.lblPlayerB.TabIndex = 30;
            this.lblPlayerB.Text = "Karnauhov";
            this.lblPlayerB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPointsA
            // 
            this.txtPointsA.Location = new System.Drawing.Point(119, 5);
            this.txtPointsA.Name = "txtPointsA";
            this.txtPointsA.ReadOnly = true;
            this.txtPointsA.Size = new System.Drawing.Size(34, 19);
            this.txtPointsA.TabIndex = 31;
            this.txtPointsA.Text = "0";
            this.txtPointsA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPointsA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPointsA_KeyDown);
            // 
            // txtPointsB
            // 
            this.txtPointsB.Location = new System.Drawing.Point(171, 5);
            this.txtPointsB.Name = "txtPointsB";
            this.txtPointsB.ReadOnly = true;
            this.txtPointsB.Size = new System.Drawing.Size(38, 19);
            this.txtPointsB.TabIndex = 32;
            this.txtPointsB.Text = "0";
            this.txtPointsB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPointsB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPointsB_KeyDown);
            // 
            // pnlMatchResults
            // 
            this.pnlMatchResults.Controls.Add(this.txtPointsB);
            this.pnlMatchResults.Controls.Add(this.btnRight);
            this.pnlMatchResults.Controls.Add(this.lblPlayerA);
            this.pnlMatchResults.Controls.Add(this.btnLeft);
            this.pnlMatchResults.Controls.Add(this.lblPlayerB);
            this.pnlMatchResults.Controls.Add(this.txtPointsA);
            this.pnlMatchResults.Location = new System.Drawing.Point(8, 68);
            this.pnlMatchResults.Name = "pnlMatchResults";
            this.pnlMatchResults.Size = new System.Drawing.Size(327, 33);
            this.pnlMatchResults.TabIndex = 35;
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnRight.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRight.Down = false;
            this.btnRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnRight.Image = global::TA.Competitions.Forms.Properties.Resources.Arrow_right;
            this.btnRight.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRight.Location = new System.Drawing.Point(161, 5);
            this.btnRight.Name = "btnRight";
            this.btnRight.RadioButton = false;
            this.btnRight.Size = new System.Drawing.Size(9, 19);
            this.btnRight.TabIndex = 34;
            this.btnRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnLeft.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLeft.Down = false;
            this.btnLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnLeft.Image = global::TA.Competitions.Forms.Properties.Resources.Arrow_left;
            this.btnLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLeft.Location = new System.Drawing.Point(153, 5);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.RadioButton = false;
            this.btnLeft.Size = new System.Drawing.Size(9, 19);
            this.btnLeft.TabIndex = 33;
            this.btnLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // fFipsMatchEdit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(343, 153);
            this.Controls.Add(this.pnlMatchResults);
            this.Controls.Add(this.rbtnMatchOver);
            this.Controls.Add(this.rbtnNoResult);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fFipsMatchEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match Result";
            this.pnlMatchResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowSkin.Border border1;
        private WindowSkin.Button btnOk;
        private WindowSkin.Button btnCancel;
        private System.Windows.Forms.RadioButton rbtnNoResult;
        private System.Windows.Forms.RadioButton rbtnMatchOver;
        private System.Windows.Forms.Label lblPlayerA;
        private System.Windows.Forms.Label lblPlayerB;
        private WindowSkin.TextBox txtPointsA;
        private WindowSkin.TextBox txtPointsB;
        private WindowSkin.Button btnLeft;
        private WindowSkin.Button btnRight;
        private System.Windows.Forms.Panel pnlMatchResults;

    }
}