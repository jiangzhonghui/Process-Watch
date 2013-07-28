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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            loadSettings();
        }

        private void startTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AskDelete = askDeleteCheckBox.Checked;
            Properties.Settings.Default.AskExit = askExitCheckBox.Checked;
            Properties.Settings.Default.StartInTray = startTrayCheckBox.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void loadSettings()
        {
            askDeleteCheckBox.Checked = Properties.Settings.Default.AskDelete;
            askExitCheckBox.Checked = Properties.Settings.Default.AskExit;
            startTrayCheckBox.Checked = Properties.Settings.Default.StartInTray;
        }

        private void closeCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void askExitCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void askDeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
