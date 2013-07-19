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

    //select process

    public partial class Form4 : Form
    {
        public string processName { set; get; }
        
        public Form4()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.processName = Path.GetFileNameWithoutExtension(pathBox.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {

                if (Path.GetExtension(openFileDialog1.FileName) == ".exe")
                {

                    this.pathBox.Text = openFileDialog1.InitialDirectory + openFileDialog1.FileName;

                }
                else
                {
                    MessageBox.Show("Wrong file extension", "Extension error", MessageBoxButtons.OK);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void AddNewProcessForm_Load(object sender, EventArgs e)
        {

        }

    }
}
