using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErrorViewer
{
    internal partial class fErrorView : Form
    {
        internal fErrorView()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
    public class ErrorView 
    {
        public static bool IgnoreExceptions = false;
        public static void Show(Exception ex)
        {
            if (IgnoreExceptions)
                return;
            fErrorView form = new fErrorView();
            form.txtException.Text = ex.Message;
            form.txtStack.Text = ex.StackTrace;
            form.ShowDialog();
        }
    }
}