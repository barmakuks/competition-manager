using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.Corel;

namespace TA.Competitions.Forms
{
    public partial class CompetitionParamsPanel : UserControl, Localizator.ILocalizableForm
    {
        protected Competition Competition = null;
        public CompetitionParamsPanel() 
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public CompetitionParamsPanel(Competition aCompetition)
            : this()
        {
            Competition = aCompetition;
            ReadParameters();
        }
        public virtual bool WriteParameters() 
        {
            return true;
        }
        public virtual void ReadParameters() 
        {
        }
        public virtual bool ReadOnly {get;set;}
        public int MinHeight 
        {
            get {
                int height = 0;
                foreach (Control comp in Controls) 
                {
                    height = Math.Max(comp.Top + comp.Height, height);
                }
                return height;
            }
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            
        }

        #endregion
    }
}
