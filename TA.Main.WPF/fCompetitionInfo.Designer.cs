namespace TA.Main
{
    partial class fCompetitionInfo
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
            this.cbxChangesRating = new WindowSkin.CheckBox();
            this.cbxGameType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCompetitionType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompetitionName = new WindowSkin.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new WindowSkin.Button();
            this.btnCancel = new WindowSkin.Button();
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
            this.border1.Size = new System.Drawing.Size(450, 238);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // cbxChangesRating
            // 
            this.cbxChangesRating.AutoSize = true;
            this.cbxChangesRating.Location = new System.Drawing.Point(234, 46);
            this.cbxChangesRating.Name = "cbxChangesRating";
            this.cbxChangesRating.Size = new System.Drawing.Size(119, 15);
            this.cbxChangesRating.TabIndex = 1;
            this.cbxChangesRating.Text = "Rating Competition";
            // 
            // cbxGameType
            // 
            this.cbxGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGameType.FormattingEnabled = true;
            this.cbxGameType.Location = new System.Drawing.Point(23, 44);
            this.cbxGameType.Name = "cbxGameType";
            this.cbxGameType.Size = new System.Drawing.Size(201, 21);
            this.cbxGameType.TabIndex = 0;
            this.cbxGameType.TextChanged += new System.EventHandler(this.cbxCompetitionType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Game";
            // 
            // cbxCompetitionType
            // 
            this.cbxCompetitionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompetitionType.FormattingEnabled = true;
            this.cbxCompetitionType.Items.AddRange(new object[] {
            "Double Elimination"});
            this.cbxCompetitionType.Location = new System.Drawing.Point(24, 151);
            this.cbxCompetitionType.Name = "cbxCompetitionType";
            this.cbxCompetitionType.Size = new System.Drawing.Size(400, 21);
            this.cbxCompetitionType.TabIndex = 3;
            this.cbxCompetitionType.SelectedIndexChanged += new System.EventHandler(this.cbxCompetitionType_SelectedIndexChanged);
            this.cbxCompetitionType.TextChanged += new System.EventHandler(this.cbxCompetitionType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Competition Format";
            // 
            // txtCompetitionName
            // 
            this.txtCompetitionName.Location = new System.Drawing.Point(24, 95);
            this.txtCompetitionName.Name = "txtCompetitionName";
            this.txtCompetitionName.ReadOnly = false;
            this.txtCompetitionName.Size = new System.Drawing.Size(400, 20);
            this.txtCompetitionName.TabIndex = 2;
            this.txtCompetitionName.TextChanged += new System.EventHandler(this.cbxCompetitionType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Competition Title";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Down = false;
            this.btnOk.Enabled = false;
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnOk.Image = null;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(257, 193);
            this.btnOk.Name = "btnOk";
            this.btnOk.RadioButton = false;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Down = false;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnCancel.Image = null;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(349, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButton = false;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fCompetitionInfo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 238);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbxChangesRating);
            this.Controls.Add(this.cbxGameType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxCompetitionType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCompetitionName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.border1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fCompetitionInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Competition Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowSkin.Border border1;
        private WindowSkin.CheckBox cbxChangesRating;
        private System.Windows.Forms.ComboBox cbxGameType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCompetitionType;
        private System.Windows.Forms.Label label2;
        private WindowSkin.TextBox txtCompetitionName;
        private System.Windows.Forms.Label label1;
        private WindowSkin.Button btnOk;
        private WindowSkin.Button btnCancel;
    }
}