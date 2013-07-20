using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace ProcesyTest
{
    public partial class Form5 : Form
    {

        public List<string> processesNames { get; set; }

        void Scan()
        {
            Process[] processes = Process.GetProcesses();
            
            foreach (Process process in processes)
            {
                //if(process.StartInfo.UserName == "cypisek")
                //checkedListBox1.Items.Add(process.ProcessName);
                checkedListBox1.Items.Add(process.StartInfo.WorkingDirectory.ToString());
            }
        }

        void AnotherScan()
        {
            
        }

        public Form5()
        {
            InitializeComponent();
            processesNames = new List<string>();
            Scan();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {
                processesNames.Add(item.ToString());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                button1.Text = "add";
            }
            else
            {
                button1.Text = "close";
            }
        }
    }
}
