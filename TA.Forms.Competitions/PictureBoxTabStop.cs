using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TA.Competitions.Forms
{
    public partial class PictureBoxTabStop : PictureBox
    {
        public PictureBoxTabStop()
        {
            InitializeComponent();
        }
        private bool FTabStop = true;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new bool TabStop 
        {
            get {
                return FTabStop;
            }
            set {
                FTabStop = value;
            }
        }
        
        private int FTabIndex;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new int TabIndex 
        {
            get {
                return FTabIndex;
            }
            set {
                FTabIndex = value;
            }
        }        

    }
}
