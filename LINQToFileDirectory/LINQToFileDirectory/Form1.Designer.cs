namespace LINQToFileDirectory
{
    partial class LINQToFIleDirectoryForm
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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.direcrtoryTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(45, 57);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(279, 20);
            this.pathTextBox.TabIndex = 0;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(42, 41);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(109, 13);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "Enter Path to Search:";
            // 
            // searchButton
            // 
            this.searchButton.AutoSize = true;
            this.searchButton.Location = new System.Drawing.Point(228, 83);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(96, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search Directory";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(42, 119);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(52, 13);
            this.directoryLabel.TabIndex = 3;
            this.directoryLabel.Text = "Directory:";
            // 
            // resultTextBox
            // 
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTextBox.Location = new System.Drawing.Point(45, 138);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(279, 207);
            this.resultTextBox.TabIndex = 4;
            // 
            // direcrtoryTextBox
            // 
            this.direcrtoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direcrtoryTextBox.Location = new System.Drawing.Point(97, 112);
            this.direcrtoryTextBox.Name = "direcrtoryTextBox";
            this.direcrtoryTextBox.ReadOnly = true;
            this.direcrtoryTextBox.Size = new System.Drawing.Size(227, 20);
            this.direcrtoryTextBox.TabIndex = 5;
            // 
            // LINQToFIleDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 387);
            this.Controls.Add(this.direcrtoryTextBox);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.pathTextBox);
            this.Name = "LINQToFIleDirectoryForm";
            this.Text = "Searching Directory withLINQ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.TextBox direcrtoryTextBox;
    }
}

