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
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                watcher.Update();
                System.Threading.Thread.Sleep(500);
            }
        }

        void AddNewProcessMethod(string name)
        {
            watcher.LoadProcessName(name);
        }

        delegate void AddNewProcess(string name);

        ////dodanie nowego procesu
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (processTextBox.Text.Length > 0)
        //    {
        //        AddNewProcessMethod(processTextBox.Text);                              
        //        processTextBox.Text = String.Empty;
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //czy nazwa ktoregos procesu zostala wybrana
        //    if (listView1.SelectedIndices.Count > 0)
        //    {
        //        watcher.DeleteProcessName(listView1.SelectedItems[0].Text);
        //    }
        //    processTextBox.Text = String.Empty;
        //}

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form detailForm = new Form2(watcher.GetProcessByName(listView1.SelectedItems[0].Text));
            detailForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(watcher);
            form.ShowDialog();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void Procesy_FormClosing(object sender, FormClosingEventArgs e)
        {
            watcher.SaveProcessesHistory();
            watcher.SaveSetttings();
        }

        private void Procesy_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }

    }
}
