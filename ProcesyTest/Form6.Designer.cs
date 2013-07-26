namespace ProcesyTest
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.askExitCheckBox = new System.Windows.Forms.CheckBox();
            this.askDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startTrayCheckBox
            // 
            this.startTrayCheckBox.AutoSize = true;
            this.startTrayCheckBox.Location = new System.Drawing.Point(43, 12);
            this.startTrayCheckBox.Name = "startTrayCheckBox";
            this.startTrayCheckBox.Size = new System.Drawing.Size(96, 17);
            this.startTrayCheckBox.TabIndex = 0;
            this.startTrayCheckBox.Text = "Start minimized";
            this.startTrayCheckBox.UseVisualStyleBackColor = true;
            this.startTrayCheckBox.CheckedChanged += new System.EventHandler(this.startTrayCheckBox_CheckedChanged);
            // 
            // askExitCheckBox
            // 
            this.askExitCheckBox.AutoSize = true;
            this.askExitCheckBox.Location = new System.Drawing.Point(43, 35);
            this.askExitCheckBox.Name = "askExitCheckBox";
            this.askExitCheckBox.Size = new System.Drawing.Size(78, 17);
            this.askExitCheckBox.TabIndex = 2;
            this.askExitCheckBox.Text = "Ask on exit";
            this.askExitCheckBox.UseVisualStyleBackColor = true;
            this.askExitCheckBox.CheckedChanged += new System.EventHandler(this.askExitCheckBox_CheckedChanged);
            // 
            // askDeleteCheckBox
            // 
            this.askDeleteCheckBox.AutoSize = true;
            this.askDeleteCheckBox.Location = new System.Drawing.Point(43, 58);
            this.askDeleteCheckBox.Name = "askDeleteCheckBox";
            this.askDeleteCheckBox.Size = new System.Drawing.Size(76, 17);
            this.askDeleteCheckBox.TabIndex = 3;
            this.askDeleteCheckBox.Text = "Ask delete";
            this.askDeleteCheckBox.UseVisualStyleBackColor = true;
            this.askDeleteCheckBox.CheckedChanged += new System.EventHandler(this.askDeleteCheckBox_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 104);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(91, 104);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 133);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.askDeleteCheckBox);
            this.Controls.Add(this.askExitCheckBox);
            this.Controls.Add(this.startTrayCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form6";
            this.ShowIcon = false;
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox startTrayCheckBox;
        private System.Windows.Forms.CheckBox askExitCheckBox;
        private System.Windows.Forms.CheckBox askDeleteCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}