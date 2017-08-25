namespace TA.Competitions.Forms
{
    partial class FipsSwissParamsPanel
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
            this.txtStartPoints = new WindowSkin.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxAllowRebuy = new WindowSkin.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLateStartPoints = new WindowSkin.TextBox();
            this.cbxAutosetStartPoints = new WindowSkin.CheckBox();
            this.btnSetStartPoints = new WindowSkin.Button();
            this.lblPts = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStartPoints
            // 
            this.txtStartPoints.Location = new System.Drawing.Point(127, 13);
            this.txtStartPoints.Name = "txtStartPoints";
            this.txtStartPoints.ReadOnly = false;
            this.txtStartPoints.Size = new System.Drawing.Size(45, 20);
            this.txtStartPoints.TabIndex = 29;
            this.txtStartPoints.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Start points:";
            // 
            // cbxAllowRebuy
            // 
            this.cbxAllowRebuy.AutoSize = true;
            this.cbxAllowRebuy.Location = new System.Drawing.Point(3, 77);
            this.cbxAllowRebuy.Name = "cbxAllowRebuy";
            this.cbxAllowRebuy.Size = new System.Drawing.Size(157, 15);
            this.cbxAllowRebuy.TabIndex = 31;
            this.cbxAllowRebuy.Text = "Allow Rebuy and late entry";
            this.cbxAllowRebuy.CheckedChanged += new System.EventHandler(this.cbxAllowRebuy_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Late entry start points";
            // 
            // txtLateStartPoints
            // 
            this.txtLateStartPoints.Location = new System.Drawing.Point(26, 113);
            this.txtLateStartPoints.Name = "txtLateStartPoints";
            this.txtLateStartPoints.ReadOnly = false;
            this.txtLateStartPoints.Size = new System.Drawing.Size(76, 20);
            this.txtLateStartPoints.TabIndex = 32;
            this.txtLateStartPoints.Text = "100";
            // 
            // cbxAutosetStartPoints
            // 
            this.cbxAutosetStartPoints.AutoSize = true;
            this.cbxAutosetStartPoints.Location = new System.Drawing.Point(12, 16);
            this.cbxAutosetStartPoints.Name = "cbxAutosetStartPoints";
            this.cbxAutosetStartPoints.Size = new System.Drawing.Size(112, 15);
            this.cbxAutosetStartPoints.TabIndex = 34;
            this.cbxAutosetStartPoints.Text = "Всем игрокам по";
            this.cbxAutosetStartPoints.CheckedChanged += new System.EventHandler(this.cbxSetStartPoints_CheckedChanged);
            // 
            // btnSetStartPoints
            // 
            this.btnSetStartPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnSetStartPoints.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSetStartPoints.Down = false;
            this.btnSetStartPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnSetStartPoints.Image = null;
            this.btnSetStartPoints.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetStartPoints.Location = new System.Drawing.Point(12, 39);
            this.btnSetStartPoints.Name = "btnSetStartPoints";
            this.btnSetStartPoints.RadioButton = false;
            this.btnSetStartPoints.Size = new System.Drawing.Size(199, 23);
            this.btnSetStartPoints.TabIndex = 35;
            this.btnSetStartPoints.Text = "Установить вручную";
            this.btnSetStartPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSetStartPoints.Click += new System.EventHandler(this.btnSetStartPoints_Click);
            // 
            // lblPts
            // 
            this.lblPts.AutoSize = true;
            this.lblPts.Location = new System.Drawing.Point(175, 16);
            this.lblPts.Name = "lblPts";
            this.lblPts.Size = new System.Drawing.Size(36, 13);
            this.lblPts.TabIndex = 36;
            this.lblPts.Text = "очков";
            // 
            // FipsSwissParamsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPts);
            this.Controls.Add(this.btnSetStartPoints);
            this.Controls.Add(this.cbxAutosetStartPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLateStartPoints);
            this.Controls.Add(this.cbxAllowRebuy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStartPoints);
            this.Name = "FipsSwissParamsPanel";
            this.Size = new System.Drawing.Size(225, 248);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowSkin.TextBox txtStartPoints;
        private System.Windows.Forms.Label label1;
        private WindowSkin.CheckBox cbxAllowRebuy;
        private System.Windows.Forms.Label label2;
        private WindowSkin.TextBox txtLateStartPoints;
        private WindowSkin.CheckBox cbxAutosetStartPoints;
        private WindowSkin.Button btnSetStartPoints;
        private System.Windows.Forms.Label lblPts;
    }
}
