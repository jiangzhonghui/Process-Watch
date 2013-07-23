using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    //        if (e.Error != null)
    //        {
    //            Exception ex = e.Error;
    //MessageBox.Show("pizda Whoops! Please contact the developers with the following" 
    //      + " information:\n\n" + ex.Message + ex.StackTrace, 
    //      "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
  
    //        }
        }

        private void Procesy_FormClosing(object sender, FormClosingEventArgs e)
        {
            watcher.SaveProcessesHistory();
            watcher.SaveSetttings();
        }

        private void Procesy_FormClosed(object sender, FormClosedEventArgs e)
        {

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
