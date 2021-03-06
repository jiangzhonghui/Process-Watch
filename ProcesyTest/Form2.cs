﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcesyTest
{
    public partial class Form2 : Form
    {
        ProcessToWatch process;

        List<ListViewItem> historyListViewItem;
        List<ProcessHistoryDetail> historyDetailList;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ProcessToWatch process)
        {
            InitializeComponent();
            historyListViewItem = new List<ListViewItem>();
            this.process = process;
            this.Text = process.ProcessName + "'s details";
            LoadHistory();
            //backgroundWorker1.RunWorkerAsync();
        }

        void LoadHistory()
        {
            historyDetailList = process.processHistory;

            foreach (ProcessHistoryDetail detail in historyDetailList)
            {
                //historyListViewItem.Add(new ListViewItem());
                //historyListViewItem.Last().Text = DateTimeFormatter.FormatLong(detail.Start);
                historyListViewItem.Add(new ListViewItem(DateTimeFormatter.FormatLong(detail.Start)));
                historyListViewItem.Last().SubItems.Add(TimeSpanFormatter.Format(detail.Duration));
                historyListViewItem.Last().SubItems.Add(DateTimeFormatter.FormatLong(detail.End));
            }

            listView1.Items.AddRange(historyListViewItem.ToArray());

            ReportItem details = new ReportItem(process.processHistory);


            totalTimeLabel.Text = String.Format("Total time: {0}", TimeSpanFormatter.Format(details.TotalTime));
            averageTimeLabel.Text = String.Format("Average time: {0}", TimeSpanFormatter.Format(details.AverageTime));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private int sortColumn = -1;

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Utility.ListViewSort(listView1, ref sortColumn, e.Column);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
