namespace ProcesyTest
{
    partial class Form7
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.selectAllButton1 = new System.Windows.Forms.Button();
            this.selectNoneButton1 = new System.Windows.Forms.Button();
            this.selectAllButton2 = new System.Windows.Forms.Button();
            this.selectNoneButton2 = new System.Windows.Forms.Button();
            this.pathButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.fromCheckBox = new System.Windows.Forms.CheckBox();
            this.toCheckBox = new System.Windows.Forms.CheckBox();
            this.fromButton = new System.Windows.Forms.Button();
            this.toButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(160, 214);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(212, 12);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(160, 214);
            this.checkedListBox2.TabIndex = 1;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(178, 84);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(27, 20);
            this.addButton.TabIndex = 2;
            this.addButton.Text = ">>";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(178, 108);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(27, 20);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "<<";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(12, 261);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(363, 47);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // selectAllButton1
            // 
            this.selectAllButton1.Location = new System.Drawing.Point(58, 232);
            this.selectAllButton1.Name = "selectAllButton1";
            this.selectAllButton1.Size = new System.Drawing.Size(40, 23);
            this.selectAllButton1.TabIndex = 5;
            this.selectAllButton1.Text = "all";
            this.selectAllButton1.UseVisualStyleBackColor = true;
            this.selectAllButton1.Click += new System.EventHandler(this.selectAllButton1_Click);
            // 
            // selectNoneButton1
            // 
            this.selectNoneButton1.Location = new System.Drawing.Point(12, 232);
            this.selectNoneButton1.Name = "selectNoneButton1";
            this.selectNoneButton1.Size = new System.Drawing.Size(40, 23);
            this.selectNoneButton1.TabIndex = 6;
            this.selectNoneButton1.Text = "none";
            this.selectNoneButton1.UseVisualStyleBackColor = true;
            this.selectNoneButton1.Click += new System.EventHandler(this.selectNoneButton1_Click);
            // 
            // selectAllButton2
            // 
            this.selectAllButton2.Location = new System.Drawing.Point(286, 232);
            this.selectAllButton2.Name = "selectAllButton2";
            this.selectAllButton2.Size = new System.Drawing.Size(40, 23);
            this.selectAllButton2.TabIndex = 7;
            this.selectAllButton2.Text = "all";
            this.selectAllButton2.UseVisualStyleBackColor = true;
            this.selectAllButton2.Click += new System.EventHandler(this.selectAllButton2_Click);
            // 
            // selectNoneButton2
            // 
            this.selectNoneButton2.Location = new System.Drawing.Point(332, 232);
            this.selectNoneButton2.Name = "selectNoneButton2";
            this.selectNoneButton2.Size = new System.Drawing.Size(40, 23);
            this.selectNoneButton2.TabIndex = 8;
            this.selectNoneButton2.Text = "none";
            this.selectNoneButton2.UseVisualStyleBackColor = true;
            this.selectNoneButton2.Click += new System.EventHandler(this.selectNoneButton2_Click);
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(12, 327);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(86, 23);
            this.pathButton.TabIndex = 10;
            this.pathButton.Text = "Change path";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(17, 311);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(35, 13);
            this.pathLabel.TabIndex = 11;
            this.pathLabel.Text = "path";
            // 
            // fromCheckBox
            // 
            this.fromCheckBox.AutoSize = true;
            this.fromCheckBox.Location = new System.Drawing.Point(220, 333);
            this.fromCheckBox.Name = "fromCheckBox";
            this.fromCheckBox.Size = new System.Drawing.Size(49, 17);
            this.fromCheckBox.TabIndex = 12;
            this.fromCheckBox.Text = "From";
            this.fromCheckBox.UseVisualStyleBackColor = true;
            this.fromCheckBox.CheckedChanged += new System.EventHandler(this.fromCheckBox_CheckedChanged);
            // 
            // toCheckBox
            // 
            this.toCheckBox.AutoSize = true;
            this.toCheckBox.Location = new System.Drawing.Point(220, 386);
            this.toCheckBox.Name = "toCheckBox";
            this.toCheckBox.Size = new System.Drawing.Size(39, 17);
            this.toCheckBox.TabIndex = 13;
            this.toCheckBox.Text = "To";
            this.toCheckBox.UseVisualStyleBackColor = true;
            this.toCheckBox.CheckedChanged += new System.EventHandler(this.toCheckBox_CheckedChanged);
            // 
            // fromButton
            // 
            this.fromButton.Enabled = false;
            this.fromButton.Location = new System.Drawing.Point(230, 356);
            this.fromButton.Name = "fromButton";
            this.fromButton.Size = new System.Drawing.Size(75, 23);
            this.fromButton.TabIndex = 14;
            this.fromButton.Text = "Select date";
            this.fromButton.UseVisualStyleBackColor = true;
            this.fromButton.Click += new System.EventHandler(this.fromButton_Click);
            // 
            // toButton
            // 
            this.toButton.Enabled = false;
            this.toButton.Location = new System.Drawing.Point(230, 409);
            this.toButton.Name = "toButton";
            this.toButton.Size = new System.Drawing.Size(75, 23);
            this.toButton.TabIndex = 15;
            this.toButton.Text = "Select date";
            this.toButton.UseVisualStyleBackColor = true;
            this.toButton.Click += new System.EventHandler(this.toButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Time range";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 476);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toButton);
            this.Controls.Add(this.fromButton);
            this.Controls.Add(this.toCheckBox);
            this.Controls.Add(this.fromCheckBox);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathButton);
            this.Controls.Add(this.selectNoneButton2);
            this.Controls.Add(this.selectAllButton2);
            this.Controls.Add(this.selectNoneButton1);
            this.Controls.Add(this.selectAllButton1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button selectAllButton1;
        private System.Windows.Forms.Button selectNoneButton1;
        private System.Windows.Forms.Button selectAllButton2;
        private System.Windows.Forms.Button selectNoneButton2;
        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.CheckBox fromCheckBox;
        private System.Windows.Forms.CheckBox toCheckBox;
        private System.Windows.Forms.Button fromButton;
        private System.Windows.Forms.Button toButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}