namespace TA.Main
{
    partial class fRegistationInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fRegistationInfo));
            this.txtEMail = new WindowSkin.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrganization = new WindowSkin.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new WindowSkin.TextBox();
            this.btnRegister = new WindowSkin.Button();
            this.btnMakeKeyOut = new WindowSkin.Button();
            this.txtRegistrationKey = new WindowSkin.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtActivationKey = new WindowSkin.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCopy = new WindowSkin.Button();
            this.btnEmail = new WindowSkin.Button();
            this.border1 = new WindowSkin.Border();
            this.btnClose = new WindowSkin.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.border2 = new WindowSkin.Border();
            this.panel2 = new System.Windows.Forms.Panel();
            this.border3 = new WindowSkin.Border();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(14, 74);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.ReadOnly = false;
            this.txtEMail.Size = new System.Drawing.Size(242, 20);
            this.txtEMail.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(11, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "E-mail *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(11, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Organization";
            // 
            // txtOrganization
            // 
            this.txtOrganization.Location = new System.Drawing.Point(14, 30);
            this.txtOrganization.Name = "txtOrganization";
            this.txtOrganization.ReadOnly = false;
            this.txtOrganization.Size = new System.Drawing.Size(242, 20);
            this.txtOrganization.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(268, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username *";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(271, 30);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = false;
            this.txtName.Size = new System.Drawing.Size(244, 20);
            this.txtName.TabIndex = 1;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnRegister.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRegister.Down = false;
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnRegister.Image = null;
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegister.Location = new System.Drawing.Point(393, 29);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.RadioButton = false;
            this.btnRegister.Size = new System.Drawing.Size(122, 23);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register";
            this.btnRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnMakeKeyOut
            // 
            this.btnMakeKeyOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnMakeKeyOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMakeKeyOut.Down = false;
            this.btnMakeKeyOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnMakeKeyOut.Image = null;
            this.btnMakeKeyOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMakeKeyOut.Location = new System.Drawing.Point(271, 72);
            this.btnMakeKeyOut.Name = "btnMakeKeyOut";
            this.btnMakeKeyOut.RadioButton = false;
            this.btnMakeKeyOut.Size = new System.Drawing.Size(244, 23);
            this.btnMakeKeyOut.TabIndex = 3;
            this.btnMakeKeyOut.Text = "Generate Registration Code";
            this.btnMakeKeyOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMakeKeyOut.Click += new System.EventHandler(this.btnMakeKeyOut_Click);
            // 
            // txtRegistrationKey
            // 
            this.txtRegistrationKey.Location = new System.Drawing.Point(14, 30);
            this.txtRegistrationKey.Name = "txtRegistrationKey";
            this.txtRegistrationKey.ReadOnly = false;
            this.txtRegistrationKey.Size = new System.Drawing.Size(373, 20);
            this.txtRegistrationKey.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(11, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Activation Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(11, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Registration Code";
            // 
            // txtActivationKey
            // 
            this.txtActivationKey.Location = new System.Drawing.Point(14, 118);
            this.txtActivationKey.Name = "txtActivationKey";
            this.txtActivationKey.ReadOnly = true;
            this.txtActivationKey.Size = new System.Drawing.Size(242, 20);
            this.txtActivationKey.TabIndex = 4;
            this.txtActivationKey.TextChanged += new System.EventHandler(this.txtKeyIn_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Activation Code and press Activate";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(13, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(533, 44);
            this.label7.TabIndex = 7;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(13, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(512, 33);
            this.label8.TabIndex = 8;
            this.label8.Text = "Please send an Registration Code to the address vitalii.misiura@gmail.com, and af" +
                "ter some time we will send a new Activation Code to your e-mail";
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnCopy.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCopy.Down = false;
            this.btnCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnCopy.Image = null;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(271, 116);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.RadioButton = false;
            this.btnCopy.Size = new System.Drawing.Size(244, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy to clipboard";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnEmail.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEmail.Down = false;
            this.btnEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnEmail.Image = null;
            this.btnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmail.Location = new System.Drawing.Point(403, 267);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.RadioButton = false;
            this.btnEmail.Size = new System.Drawing.Size(122, 23);
            this.btnEmail.TabIndex = 3;
            this.btnEmail.Text = "Send e-mail";
            this.btnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEmail.Visible = false;
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = true;
            this.border1.Size = new System.Drawing.Size(558, 440);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Down = false;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnClose.Image = null;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(403, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.RadioButton = false;
            this.btnClose.Size = new System.Drawing.Size(122, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.border2);
            this.panel1.Controls.Add(this.txtRegistrationKey);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Location = new System.Drawing.Point(10, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 70);
            this.panel1.TabIndex = 0;
            // 
            // border2
            // 
            this.border2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border2.Location = new System.Drawing.Point(0, 0);
            this.border2.MinimizedBox = false;
            this.border2.Name = "border2";
            this.border2.ShowCaption = false;
            this.border2.Size = new System.Drawing.Size(536, 70);
            this.border2.Sizeable = false;
            this.border2.TabIndex = 10000;
            this.border2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.border3);
            this.panel2.Controls.Add(this.txtOrganization);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtEMail);
            this.panel2.Controls.Add(this.btnMakeKeyOut);
            this.panel2.Controls.Add(this.btnCopy);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtActivationKey);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(10, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 157);
            this.panel2.TabIndex = 1;
            // 
            // border3
            // 
            this.border3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border3.Location = new System.Drawing.Point(0, 0);
            this.border3.MinimizedBox = false;
            this.border3.Name = "border3";
            this.border3.ShowCaption = false;
            this.border3.Size = new System.Drawing.Size(536, 157);
            this.border3.Sizeable = false;
            this.border3.TabIndex = 10000;
            this.border3.TabStop = false;
            // 
            // fRegistationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(558, 440);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.border1);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fRegistationInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software registration";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private WindowSkin.TextBox txtOrganization;
        private System.Windows.Forms.Label label2;
        private WindowSkin.TextBox txtName;
        private WindowSkin.Button btnMakeKeyOut;
        private WindowSkin.TextBox txtRegistrationKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private WindowSkin.TextBox txtActivationKey;
        private WindowSkin.TextBox txtEMail;
        private System.Windows.Forms.Label label6;
        private WindowSkin.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private WindowSkin.Button btnCopy;
        private WindowSkin.Button btnEmail;
        private WindowSkin.Border border1;
        private WindowSkin.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private WindowSkin.Border border2;
        private WindowSkin.Border border3;
    }
}