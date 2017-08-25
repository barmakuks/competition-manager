using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TA.CompetitionControllers;
using TA.Competitions.Forms;

namespace TA.Main
{
    public partial class fStartCompetition : Form, Localizator.ILocalizableForm
    {
        CompetitionParamsPanel ParamsPanel = null;
        protected fStartCompetition()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        internal void AppendPanel(CompetitionParamsPanel panel) 
        {
            // Размещаем панель дополнительных параметров
            if (panel != null)
            {
                ParamsPanel = panel;
                Controls.Add(panel);
                panel.Location = new Point(label1.Left, label1.Top + label1.Height);
                panel.Size = new Size(label1.Width, panel.MinHeight);
                //panel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                Height = Height - btnOk.Top + panel.Top + panel.Height + 16;
            }
            else 
            {
                Height = Height - btnOk.Top + label1.Top + label1.Height + 16;
            }
        }
        public static bool ShowStartWindow(CompetitionController aController) 
        {
            CompetitionParamsPanel panel = aController.GetParametersPanel();
            fStartCompetition form  = new fStartCompetition();
            form.AppendPanel(panel);
            bool result = form.ShowDialog() == DialogResult.OK;
            return result;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ParamsPanel != null)
                ParamsPanel.WriteParameters();
            DialogResult = DialogResult.OK;
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.btnOk.Text = Localizator.Dictionary.GetString("OK");
            this.btnCancel.Text = Localizator.Dictionary.GetString("CANCEL");
            this.label1.Text = Localizator.Dictionary.GetString("FINISH_DRAW");
            this.Text = Localizator.Dictionary.GetString("START_COMPETITION");
        }

        #endregion
    }
}
