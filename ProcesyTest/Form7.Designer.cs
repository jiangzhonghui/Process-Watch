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
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.sortButton1 = new System.Windows.Forms.Button();
            this.sortButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(8, 240);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(367, 47);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // selectAllButton1
            // 
            this.selectAllButton1.Location = new System.Drawing.Point(68, 211);
            this.selectAllButton1.Name = "selectAllButton1";
            this.selectAllButton1.Size = new System.Drawing.Size(40, 23);
            this.selectAllButton1.TabIndex = 5;
            this.selectAllButton1.Text = "All";
            this.selectAllButton1.UseVisualStyleBackColor = true;
            this.selectAllButton1.Click += new System.EventHandler(this.selectAllButton1_Click);
            // 
            // selectNoneButton1
            // 
            this.selectNoneButton1.Location = new System.Drawing.Point(8, 211);
            this.selectNoneButton1.Name = "selectNoneButton1";
            this.selectNoneButton1.Size = new System.Drawing.Size(54, 23);
            this.selectNoneButton1.TabIndex = 6;
            this.selectNoneButton1.Text = "None";
            this.selectNoneButton1.UseVisualStyleBackColor = true;
            this.selectNoneButton1.Click += new System.EventHandler(this.selectNoneButton1_Click);
            // 
            // selectAllButton2
            // 
            this.selectAllButton2.Location = new System.Drawing.Point(275, 211);
            this.selectAllButton2.Name = "selectAllButton2";
            this.selectAllButton2.Size = new System.Drawing.Size(40, 23);
            this.selectAllButton2.TabIndex = 7;
            this.selectAllButton2.Text = "All";
            this.selectAllButton2.UseVisualStyleBackColor = true;
            this.selectAllButton2.Click += new System.EventHandler(this.selectAllButton2_Click);
            // 
            // selectNoneButton2
            // 
            this.selectNoneButton2.Location = new System.Drawing.Point(321, 211);
            this.selectNoneButton2.Name = "selectNoneButton2";
            this.selectNoneButton2.Size = new System.Drawing.Size(54, 23);
            this.selectNoneButton2.TabIndex = 8;
            this.selectNoneButton2.Text = "None";
            this.selectNoneButton2.UseVisualStyleBackColor = true;
            this.selectNoneButton2.Click += new System.EventHandler(this.selectNoneButton2_Click);
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(7, 328);
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
            this.pathLabel.Location = new System.Drawing.Point(12, 312);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(28, 13);
            this.pathLabel.TabIndex = 11;
            this.pathLabel.Text = "path";
            // 
            // fromCheckBox
            // 
            this.fromCheckBox.AutoSize = true;
            this.fromCheckBox.Location = new System.Drawing.Point(219, 350);
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
            this.toCheckBox.Location = new System.Drawing.Point(219, 403);
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
            this.fromButton.Location = new System.Drawing.Point(229, 373);
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
            this.toButton.Location = new System.Drawing.Point(229, 426);
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
            this.label1.Location = new System.Drawing.Point(208, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Time range";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(8, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(164, 193);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // listView2
            // 
            this.listView2.CheckBoxes = true;
            this.listView2.Location = new System.Drawing.Point(211, 12);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(164, 193);
            this.listView2.TabIndex = 18;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // sortButton1
            // 
            this.sortButton1.Location = new System.Drawing.Point(114, 211);
            this.sortButton1.Name = "sortButton1";
            this.sortButton1.Size = new System.Drawing.Size(58, 23);
            this.sortButton1.TabIndex = 19;
            this.sortButton1.Text = "Sort";
            this.sortButton1.UseVisualStyleBackColor = true;
            this.sortButton1.Click += new System.EventHandler(this.sortButton1_Click);
            // 
            // sortButton2
            // 
            this.sortButton2.Location = new System.Drawing.Point(211, 211);
            this.sortButton2.Name = "sortButton2";
            this.sortButton2.Size = new System.Drawing.Size(58, 23);
            this.sortButton2.TabIndex = 20;
            this.sortButton2.Text = "Sort";
            this.sortButton2.UseVisualStyleBackColor = true;
            this.sortButton2.Click += new System.EventHandler(this.sortButton2_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 476);
            this.Controls.Add(this.sortButton2);
            this.Controls.Add(this.sortButton1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button sortButton1;
        private System.Windows.Forms.Button sortButton2;
    }
}