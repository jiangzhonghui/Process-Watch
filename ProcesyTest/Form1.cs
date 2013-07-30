using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;
using System.Collections;

namespace ProcesyTest
{
    public partial class ProcesyForm : Form
    {
        Watcher watcher;

        public ProcesyForm()
        {
            InitializeComponent();
            watcher = new Watcher() { ListView = listView1 };
            watcher.LoadSettings();
            backgroundWorker1.RunWorkerAsync();
        }

        private void UnhideToTray()
        {            
            this.Visible = true;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;            
        }

        private void HideToTray()
        {
            this.WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
            this.ShowInTaskbar = false;
            this.Visible = false;
        }

        //bool formShownOnce = false;

        //protected override void SetVisibleCore(bool value)
        //{
        //    if (!formShownOnce)
        //    {
        //        if (Properties.Settings.Default.startInTray)
        //        {
        //            value = false;
        //            notifyIcon1.Visible = true;
        //            //this.WindowState = FormWindowState.Minimized;
        //        }
        //        else
        //        {
        //            value = true;
        //        }

        //        formShownOnce = true;
        //    }

        //    base.SetVisibleCore(value);
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            notifyIcon1.Text = this.Text;

            LogManager.GetCurrentClassLogger().Info("Started");
            if (Properties.Settings.Default.StartInTray)
            {
                HideToTray();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                processToolStripMenuItem.Enabled = true;
            }
            else
            {
                processToolStripMenuItem.Enabled = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                watcher.Update();
                System.Threading.Thread.Sleep(200);
            }
        }

        void AddNewProcessMethod(string name)
        {
            watcher.LoadProcessName(name);
        }

        delegate void AddNewProcess(string name);

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form detailForm = new Form2(watcher.GetProcessByName(listView1.SelectedItems[0].Text));
            detailForm.Show();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogManager.GetCurrentClassLogger().Error(e.Error.Message);
            }
        }

        private void Procesy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.AskExit)
            {
                string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                switch (MessageBox.Show(String.Format("Are you sure you want to exit {0}?", name), name, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        break;

                    case System.Windows.Forms.DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void Procesy_FormClosed(object sender, FormClosedEventArgs e)
        {
            watcher.SaveProcessesHistory();
            watcher.SaveSetttings();
            NLog.LogManager.GetCurrentClassLogger().Info("Closed");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UnhideToTray();
        }

        private void ProcesyForm_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
                HideToTray();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnhideToTray();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Form detailForm = new Form2(watcher.GetProcessByName(listView1.SelectedItems[0].Text));
                detailForm.Show();
        }

        private void processManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(watcher);
            form.Text = processManagerToolStripMenuItem.Text;
            form.ShowDialog();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideToTray();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Text = preferencesToolStripMenuItem.Text;
            form.ShowDialog();
        }

        private void ProcesyForm_Shown(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReportCreator x = new ReportCreator(watcher.Processes);
            //DateTime data = new DateTime(2010, 11, 12);
            //DateTime datab = new DateTime(2013, 1, 1);
            //x.Create(data, datab);
        }

        private void reportCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7(watcher);
            form.Text = reportCreatorToolStripMenuItem.Text;
            form.Show();
        }

        private int sortColumn = -1;

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Utility.ListViewSort(listView1,ref sortColumn, e.Column);
        }

        
    }

    
}
