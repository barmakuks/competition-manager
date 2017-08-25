namespace TA.Competitions.Forms
{
    partial class RobinOlympicPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinishGroupRound = new WindowSkin.Button();
            this.border1 = new WindowSkin.Border();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictMain
            // 
            this.pictMain.Location = new System.Drawing.Point(0, 48);
            this.pictMain.Size = new System.Drawing.Size(372, 328);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFinishGroupRound);
            this.panel1.Controls.Add(this.border1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 48);
            this.panel1.TabIndex = 6;
            // 
            // btnFinishGroupRound
            // 
            this.btnFinishGroupRound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.btnFinishGroupRound.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFinishGroupRound.Down = false;
            this.btnFinishGroupRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFinishGroupRound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.btnFinishGroupRound.Image = null;
            this.btnFinishGroupRound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinishGroupRound.Location = new System.Drawing.Point(15, 13);
            this.btnFinishGroupRound.Name = "btnFinishGroupRound";
            this.btnFinishGroupRound.RadioButton = false;
            this.btnFinishGroupRound.Size = new System.Drawing.Size(199, 23);
            this.btnFinishGroupRound.TabIndex = 1;
            this.btnFinishGroupRound.Text = "Finish group round";
            this.btnFinishGroupRound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFinishGroupRound.Click += new System.EventHandler(this.btnFinishGroupRound_Click);
            // 
            // border1
            // 
            this.border1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.border1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.MinimizedBox = false;
            this.border1.Name = "border1";
            this.border1.ShowCaption = false;
            this.border1.Size = new System.Drawing.Size(372, 48);
            this.border1.Sizeable = false;
            this.border1.TabIndex = 10000;
            this.border1.TabStop = false;
            // 
            // RobinOlympicPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Name = "RobinOlympicPanel";
            this.Size = new System.Drawing.Size(372, 376);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pictMain, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private WindowSkin.Border border1;
        private WindowSkin.Button btnFinishGroupRound;
    }
}
