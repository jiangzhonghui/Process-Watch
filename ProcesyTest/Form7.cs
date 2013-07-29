using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProcesyTest
{
    public partial class Form7 : Form
    {
        public Form7(Watcher watcher)
        {
            InitializeComponent();
            this.watcher = watcher;
        }

        private Watcher watcher;

        private void Form7_Load(object sender, EventArgs e)
        {
            Utility.RefreshProcessesListView(listView1, watcher);

            //wpisanie ustawionego czasu
            string fromTime = Properties.Settings.Default.FromTime;
            string toTime = Properties.Settings.Default.ToTime;
            if (!String.IsNullOrWhiteSpace(fromTime))
            {
                this.fromButton.Text = fromTime;
            }
            if (!String.IsNullOrWhiteSpace(toTime))
            {
                this.toButton.Text = toTime;
            }

            SetPathLabel();
        }

        private void SetPathLabel()
        {
            const int maxLenght = 20;

            string path = Properties.Settings.Default.ReportPath;
            if (path.Length > maxLenght)
            {
                pathLabel.Text = "...";

                string newPath = Path.GetFileName(Path.GetDirectoryName(path));
                if (!(newPath.Length > maxLenght))
                {
                    pathLabel.Text += newPath;
                }
            }
            else
            {
                pathLabel.Text = path;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                ListViewItem lv = listView2.FindItemWithText(item.Text);

                if(lv == null)
                {
                    listView2.Items.Add(new ListViewItem(item.Text));
                }
            }

            Utility.ChceckAllListViewItems(listView1, false);

            if (listView2.Items.Count > 0)
            {
                createButton.Enabled = true;
            }
        }

        private void ClearCheckedListBox(CheckedListBox list)
        {
            while (list.CheckedItems.Count > 0)
            {
                list.Items.Remove(listView2.CheckedItems[0]);
            }
        }

        

        private void removeButton_Click(object sender, EventArgs e)
        {
           // foreach
            Utility.RemoveCheckListViewItems(listView2);
            Utility.ChceckAllListViewItems(listView2, false);

            if (listView2.Items.Count < 1)
            {
                createButton.Enabled = false;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.SelectAllListView(listView1, false);
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.SelectAllListView(listView2, false);
        }

        private void selectNoneButton1_Click(object sender, EventArgs e)
        {
            Utility.ChceckAllListViewItems(listView1, false);
        }

        private void selectNoneButton2_Click(object sender, EventArgs e)
        {
            Utility.ChceckAllListViewItems(listView2, false);
        }

        private void selectAllButton2_Click(object sender, EventArgs e)
        {
            Utility.ChceckAllListViewItems(listView2, true);
        }

        private void selectAllButton1_Click(object sender, EventArgs e)
        {
            Utility.ChceckAllListViewItems(listView1, true);
        }

        private void fromCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.fromButton.Enabled = fromCheckBox.Checked;
        }

        private void toCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.toButton.Enabled = toCheckBox.Checked;
        }

        private void fromButton_Click(object sender, EventArgs e)
        {
            if (SelectDate(fromButton))
            {
                Properties.Settings.Default.FromTime = fromButton.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void toButton_Click(object sender, EventArgs e)
        {
            if (SelectDate(toButton))
            {
                Properties.Settings.Default.ToTime = toButton.Text;
                Properties.Settings.Default.Save();
            }
        }

        bool SelectDate(Button button)
        {
            Form8 form = new Form8();
            System.Windows.Forms.DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                button.Text = form.chosenDate.ToShortDateString();
                return true;
            }
            return false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            List<ProcessToWatch> toReport = new List<ProcessToWatch>();
            foreach (var p in listView2.Items)
            {
                toReport.Add(watcher.GetProcessByName(p.ToString()));
            }

            ReportCreator report = new ReportCreator(toReport) { ReportPath = pathLabel.Text };

            if (fromButton.Enabled || toButton.Enabled)
            {
                DateTime fromTime = DateTime.MinValue;
                DateTime toTime = DateTime.MaxValue;

                bool fromResult = DateTime.TryParse(fromButton.Text, out fromTime);
                bool toResult = DateTime.TryParse(toButton.Text, out toTime);

                report.Create(fromTime, toTime);
            }
            else
            {
                report.Create();
            }

            createButton.Enabled = false;

            while (listView2.Items.Count > 0)
            {
                listView2.Items.RemoveAt(0);
            }

        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Properties.Settings.Default.ReportPath = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
                SetPathLabel();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int sortColumn1 = -1;
        private int sortColumn2 = -1;

        private void sortButton1_Click(object sender, EventArgs e)
        {
            Utility.ListViewSort(listView1, ref sortColumn1, 0);
        }

        private void sortButton2_Click(object sender, EventArgs e)
        {
            Utility.ListViewSort(listView2, ref sortColumn2, 0);
        }

    }
}
