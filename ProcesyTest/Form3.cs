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

    //form with settings

    public partial class Form3 : Form
    {
        Watcher watcher;

        public Form3()
        {
            InitializeComponent();
        }

        void RefreshProcessesListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(watcher.Processes.ToArray());
        }

        public Form3(Watcher watcher) : this()
        {
            this.watcher = watcher;
            RefreshProcessesListBox();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {
                watcher.DeleteProcessName(item.ToString());
            }
            RefreshProcessesListBox();
        }

        //new form where you can add processes
        private void addButton_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            var result = form.ShowDialog();
            if(result == DialogResult.OK)
            {
                watcher.LoadProcessName(form.processName);
                RefreshProcessesListBox();
                watcher.SaveSetttings();
            }
        }

        //new form where you can choose currently working processes to add
        private void scanButton_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                watcher.LoadProcessName(form.processesNames.ToArray());
                RefreshProcessesListBox();
                watcher.SaveSetttings();
            }
        }

    }
}
