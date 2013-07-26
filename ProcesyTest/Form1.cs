﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            LogManager.GetCurrentClassLogger().Info("Started");   
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

        private void Procesy_FormClosed(object sender, FormClosedEventArgs e)
        {
            watcher.SaveProcessesHistory();
            watcher.SaveSetttings();
            NLog.LogManager.GetCurrentClassLogger().Info("Closed");
        }

        private void UnhideToTray()
        {
            notifyIcon1.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void HideToTray()
        {
            notifyIcon1.Visible = true;
            this.Hide();
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
     //       if (listView1.SelectedItems.Count > 0)
            {
                Form detailForm = new Form2(watcher.GetProcessByName(listView1.SelectedItems[0].Text));
                detailForm.Show();
            }
        }

        private void processManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(watcher);
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

        
    }
}
