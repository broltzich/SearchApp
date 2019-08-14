namespace SearchApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.DirectoryTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FileTemplateTextBox = new System.Windows.Forms.TextBox();
            this.FileContentTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ResultTreeView = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Directory:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.Location = new System.Drawing.Point(685, 79);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BrowseButton.Size = new System.Drawing.Size(89, 28);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // DirectoryTextBox
            // 
            this.DirectoryTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryTextBox.Location = new System.Drawing.Point(128, 81);
            this.DirectoryTextBox.Name = "DirectoryTextBox";
            this.DirectoryTextBox.Size = new System.Drawing.Size(540, 25);
            this.DirectoryTextBox.TabIndex = 2;
            this.DirectoryTextBox.TextChanged += new System.EventHandler(this.DirectoryTextBox_TextChanged);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "File template:";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "File contains text:";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // FileTemplateTextBox
            // 
            this.FileTemplateTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTemplateTextBox.Location = new System.Drawing.Point(128, 120);
            this.FileTemplateTextBox.Name = "FileTemplateTextBox";
            this.FileTemplateTextBox.Size = new System.Drawing.Size(540, 25);
            this.FileTemplateTextBox.TabIndex = 5;
            this.FileTemplateTextBox.TextChanged += new System.EventHandler(this.FileTemplateTextBox_TextChanged);
            // 
            // FileContentTextBox
            // 
            this.FileContentTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileContentTextBox.Location = new System.Drawing.Point(128, 160);
            this.FileContentTextBox.Multiline = true;
            this.FileContentTextBox.Name = "FileContentTextBox";
            this.FileContentTextBox.Size = new System.Drawing.Size(540, 87);
            this.FileContentTextBox.TabIndex = 6;
            this.FileContentTextBox.TextChanged += new System.EventHandler(this.FileContentTextBox_TextChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(351, 274);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(115, 27);
            this.SearchButton.TabIndex = 7;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_ClickAsync);
            // 
            // ResultTreeView
            // 
            this.ResultTreeView.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultTreeView.Location = new System.Drawing.Point(36, 340);
            this.ResultTreeView.Name = "ResultTreeView";
            this.ResultTreeView.Size = new System.Drawing.Size(738, 325);
            this.ResultTreeView.TabIndex = 8;
            this.ResultTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ResultTreeView_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(718, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "???";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 688);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResultTreeView);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.FileContentTextBox);
            this.Controls.Add(this.FileTemplateTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DirectoryTextBox);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox DirectoryTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FileTemplateTextBox;
        private System.Windows.Forms.TextBox FileContentTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TreeView ResultTreeView;
        private System.Windows.Forms.Button button1;
    }
}

