namespace Seeding
{
    partial class GraphicalSeeding
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
            this.sbLeft = new WindowSkin.ScrollBar();
            this.sbRight = new WindowSkin.ScrollBar();
            this.SuspendLayout();
            // 
            // sbLeft
            // 
            this.sbLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.sbLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.sbLeft.Location = new System.Drawing.Point(0, 0);
            this.sbLeft.Max = 100;
            this.sbLeft.Name = "sbLeft";
            this.sbLeft.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.sbLeft.Size = new System.Drawing.Size(10, 425);
            this.sbLeft.TabIndex = 0;
            this.sbLeft.Value = 0;
            this.sbLeft.ValueChanged += new System.EventHandler(this.sbLeft_ValueChanged);
            // 
            // sbRight
            // 
            this.sbRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(214)))));
            this.sbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbRight.Location = new System.Drawing.Point(460, 0);
            this.sbRight.Max = 100;
            this.sbRight.Name = "sbRight";
            this.sbRight.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.sbRight.Size = new System.Drawing.Size(10, 425);
            this.sbRight.TabIndex = 1;
            this.sbRight.Value = 0;
            this.sbRight.ValueChanged += new System.EventHandler(this.sbLeft_ValueChanged);
            // 
            // GraphicalSeeding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbRight);
            this.Controls.Add(this.sbLeft);
            this.Name = "GraphicalSeeding";
            this.Size = new System.Drawing.Size(470, 425);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowSkin.ScrollBar sbLeft;
        private WindowSkin.ScrollBar sbRight;
    }
}
