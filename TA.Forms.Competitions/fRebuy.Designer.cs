namespace TA.Competitions.Forms
{
    partial class fRebuy
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
            this.btnOk = new WindowSkin.Button();
            this.btnCancel = new WindowSkin.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullName = new WindowSkin.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartPoints = new WindowSkin.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPoints = new WindowSkin.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRebuyPoints = new WindowSkin.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAvailablePoints = new WindowSkin.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddPoints = new WindowSkin.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNowAvailable = new WindowSkin.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.border1 = new WindowSkin.Border();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Down = false;
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnOk.Image = null;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(249, 197);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(64, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Down = false;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnCancel.Image = null;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(335, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Player";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(60, 26);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(340, 20);
            this.txtFullName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Available at this time points:";
            // 
            // txtStartPoints
            // 
            this.txtStartPoints.Location = new System.Drawing.Point(60, 81);
            this.txtStartPoints.Name = "txtStartPoints";
            this.txtStartPoints.ReadOnly = true;
            this.txtStartPoints.Size = new System.Drawing.Size(39, 20);
            this.txtStartPoints.TabIndex = 5;
            this.txtStartPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Start";
            // 
            // txtPoints
            // 
            this.txtPoints.Location = new System.Drawing.Point(180, 81);
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.ReadOnly = true;
            this.txtPoints.Size = new System.Drawing.Size(39, 20);
            this.txtPoints.TabIndex = 6;
            this.txtPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(122, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "earned";
            // 
            // txtRebuyPoints
            // 
            this.txtRebuyPoints.Location = new System.Drawing.Point(279, 81);
            this.txtRebuyPoints.Name = "txtRebuyPoints";
            this.txtRebuyPoints.ReadOnly = true;
            this.txtRebuyPoints.Size = new System.Drawing.Size(39, 20);
            this.txtRebuyPoints.TabIndex = 7;
            this.txtRebuyPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(225, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "rebuy";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAvailablePoints
            // 
            this.txtAvailablePoints.Location = new System.Drawing.Point(355, 81);
            this.txtAvailablePoints.Name = "txtAvailablePoints";
            this.txtAvailablePoints.ReadOnly = true;
            this.txtAvailablePoints.Size = new System.Drawing.Size(45, 20);
            this.txtAvailablePoints.TabIndex = 8;
            this.txtAvailablePoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(317, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAddPoints
            // 
            this.txtAddPoints.Location = new System.Drawing.Point(338, 117);
            this.txtAddPoints.Name = "txtAddPoints";
            this.txtAddPoints.ReadOnly = false;
            this.txtAddPoints.Size = new System.Drawing.Size(62, 20);
            this.txtAddPoints.TabIndex = 0;
            this.txtAddPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAddPoints.TextType = WindowSkin.TextBox.TextTypes.Integer;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Add or Remove";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNowAvailable
            // 
            this.txtNowAvailable.Location = new System.Drawing.Point(338, 154);
            this.txtNowAvailable.Name = "txtNowAvailable";
            this.txtNowAvailable.ReadOnly = true;
            this.txtNowAvailable.Size = new System.Drawing.Size(62, 20);
            this.txtNowAvailable.TabIndex = 1;
            this.txtNowAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Available points";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.border1.Size = new System.Drawing.Size(417, 239);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // fRebuy
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(417, 239);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.txtNowAvailable);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAddPoints);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAvailablePoints);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRebuyPoints);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPoints);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStartPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fRebuy";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add or Remove Points";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowSkin.Button btnOk;
        private WindowSkin.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private WindowSkin.TextBox txtFullName;
        private System.Windows.Forms.Label label2;
        private WindowSkin.TextBox txtStartPoints;
        private System.Windows.Forms.Label label4;
        private WindowSkin.TextBox txtPoints;
        private System.Windows.Forms.Label label3;
        private WindowSkin.TextBox txtRebuyPoints;
        private System.Windows.Forms.Label label5;
        private WindowSkin.TextBox txtAvailablePoints;
        private System.Windows.Forms.Label label6;
        private WindowSkin.TextBox txtAddPoints;
        private System.Windows.Forms.Label label7;
        private WindowSkin.TextBox txtNowAvailable;
        private System.Windows.Forms.Label label8;
        private WindowSkin.Border border1;
    }
}