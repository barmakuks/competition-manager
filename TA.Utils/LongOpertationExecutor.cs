using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TA.Utils
{
    public partial class LongOpertationExecutor : Form, Localizator.ILocalizableForm
    {

        public delegate void DelegateWithParams(params object[] args);
        public delegate void SimpleDelegate();
        private Delegate FunctionToExecute;
        private object[] Args;
        public LongOpertationExecutor()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public static bool Execute(DelegateWithParams functionToExecute, params object[] args) 
        {
            LongOpertationExecutor form = new LongOpertationExecutor();
            form.FunctionToExecute = functionToExecute;
            form.Args = args;
            form.backgroundWorker.RunWorkerAsync();
            return form.ShowDialog() == DialogResult.OK;
        }
        public static bool Execute(SimpleDelegate functionToExecute)
        {
            LongOpertationExecutor form = new LongOpertationExecutor();
            form.FunctionToExecute = functionToExecute;
            form.Args = null;
            form.backgroundWorker.RunWorkerAsync();
            return form.ShowDialog() == DialogResult.OK;
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Thread.Sleep(200);
                if (FunctionToExecute != null)
                {
                    if (FunctionToExecute is SimpleDelegate)
                    {
                        SimpleDelegate func = FunctionToExecute as SimpleDelegate;
                        func();
                    }
                    if (FunctionToExecute is DelegateWithParams)
                    {
                        DelegateWithParams func = FunctionToExecute as DelegateWithParams;
                        func(Args);
                    }
                }
            }
            catch (Exception ex) 
            {
                WindowSkin.MessageBox.Show(ex.Message, "Error");
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.label1.Text = Localizator.Dictionary.GetString("PLEASE_WAIT");
            this.Text = Localizator.Dictionary.GetString("DB_WORK");
        }

        #endregion
    }
}
