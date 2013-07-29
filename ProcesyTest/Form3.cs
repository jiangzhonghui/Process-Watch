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

        public Form3(Watcher watcher) : this()
        {
            this.watcher = watcher;
            Utility.RefreshProcessesListView(listView1, watcher);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AskDelete)
            {
                if (Properties.Settings.Default.AskExit)
                {
                    string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    switch (MessageBox.Show(String.Format("Are you sure you want to exit {0}?", name), name, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            break;

                        case System.Windows.Forms.DialogResult.No:
                            return;
                    }
                }
            }

            foreach (ListViewItem item in listView1.CheckedItems)
            {
                try
                {
                    watcher.DeleteProcessName(item.Text);
                }
                catch (KeyNotFoundException)
                {
                    throw;
                }
            }
            Utility.RefreshProcessesListView(listView1, watcher);
        }

        //new form where you can add processes
        private void addButton_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Text = addButton.Text;
            var result = form.ShowDialog();
            if(result == DialogResult.OK)
            {
                watcher.LoadProcessName(form.processName);
                Utility.RefreshProcessesListView(listView1, watcher);
                watcher.SaveSetttings();
            }
        }

        //new form where you can choose currently working processes to add
        private void scanButton_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Text = scanButton.Text;
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                watcher.LoadProcessName(form.processesNames.ToArray());
                Utility.RefreshProcessesListView(listView1, watcher);
                watcher.SaveSetttings();
            }
        }

        private void listBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            Utility.RefreshProcessesListView(listView1, watcher);
        }


        private void selectAllButton_Click(object sender, EventArgs e)
        {
            Utility.ChceckAllListViewItems(listView1, true);
        }

        private void selectNoneButton_Click(object sender, EventArgs e)
        {
            Utility.ChceckAllListViewItems(listView1, false);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int sortColumn = -1;

        private void button1_Click_1(object sender, EventArgs e)
        {
            Utility.ListViewSort(listView1, ref sortColumn, 0);
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView1.CheckedItems.Count > 0)
            {
                deleteButton.Enabled = true;
            }
            else
            {
                deleteButton.Enabled = false;
            }
        }

    }
}
