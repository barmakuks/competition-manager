using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TA.DB.Manager;

namespace Updater
{
    public partial class SqlExecutor : Form, Localizator.ILocalizableForm
    {
        public SqlExecutor()
        {
            InitializeComponent();
            LocalizeComponents();
        }
        public static bool ExecuteSql(string[] sql_to_exec) 
        {
            SqlExecutor form = new SqlExecutor();
            try
            {
                foreach (string sql in sql_to_exec)
                {
                    form.Show();                    
                    form.slMonitor.Items.Add(sql);
                    form.slMonitor.SelectedIndex = form.slMonitor.Items.Count - 1;
                    form.slMonitor.Refresh();
                    Thread.Sleep(100);
                    if (DatabaseManager.CurrentDb.ExecuteSQL(sql))
                    {
                        form.slMonitor.Items.Add(Localizator.Dictionary.GetString("DONE"));
                    }
                    else 
                    {
                        form.slMonitor.Items.Add(Localizator.Dictionary.GetString("ERROR"));
                        return false;
                    }
                    form.slMonitor.SelectedIndex = form.slMonitor.Items.Count - 1;
                    form.slMonitor.Refresh();
                    Application.DoEvents();
                }
                return true;
            }
            finally 
            {
                Thread.Sleep(1000);
                form.Close();
            }
        }

        #region ILocalizableForm Members

        public void LocalizeComponents()
        {
            this.Text = Localizator.Dictionary.GetString("SQL_EXEC");
        }

        #endregion
    }
}
