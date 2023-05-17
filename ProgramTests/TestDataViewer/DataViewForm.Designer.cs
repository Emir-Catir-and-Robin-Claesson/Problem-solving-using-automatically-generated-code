namespace TestDataViewer
{
    partial class DataViewForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openDataFileDialog = new OpenFileDialog();
            treeViewTestResult = new TreeView();
            panel_Controls = new Panel();
            button_Folder = new Button();
            button_File = new Button();
            label_Percentage = new Label();
            label_Total = new Label();
            label_Incorrect = new Label();
            label_Correct = new Label();
            label_Result = new Label();
            textBox_FilePath = new TextBox();
            folderBrowserDialog = new FolderBrowserDialog();
            button_VerifyTemperature = new Button();
            panel_Controls.SuspendLayout();
            SuspendLayout();
            // 
            // openDataFileDialog
            // 
            openDataFileDialog.FileName = "Test_Result.json";
            openDataFileDialog.RestoreDirectory = true;
            // 
            // treeViewTestResult
            // 
            treeViewTestResult.Location = new Point(0, 0);
            treeViewTestResult.Margin = new Padding(3, 2, 3, 2);
            treeViewTestResult.Name = "treeViewTestResult";
            treeViewTestResult.Size = new Size(769, 545);
            treeViewTestResult.TabIndex = 1;
            treeViewTestResult.AfterSelect += treeViewTestResult_AfterSelect;
            // 
            // panel_Controls
            // 
            panel_Controls.Controls.Add(button_VerifyTemperature);
            panel_Controls.Controls.Add(button_Folder);
            panel_Controls.Controls.Add(button_File);
            panel_Controls.Controls.Add(label_Percentage);
            panel_Controls.Controls.Add(label_Total);
            panel_Controls.Controls.Add(label_Incorrect);
            panel_Controls.Controls.Add(label_Correct);
            panel_Controls.Controls.Add(label_Result);
            panel_Controls.Dock = DockStyle.Right;
            panel_Controls.Location = new Point(769, 0);
            panel_Controls.Name = "panel_Controls";
            panel_Controls.Size = new Size(194, 573);
            panel_Controls.TabIndex = 2;
            // 
            // button_Folder
            // 
            button_Folder.Dock = DockStyle.Top;
            button_Folder.Location = new Point(0, 40);
            button_Folder.Name = "button_Folder";
            button_Folder.Size = new Size(194, 40);
            button_Folder.TabIndex = 9;
            button_Folder.Text = "Open test folder";
            button_Folder.UseVisualStyleBackColor = true;
            button_Folder.Click += button_Folder_Click;
            // 
            // button_File
            // 
            button_File.Dock = DockStyle.Top;
            button_File.Location = new Point(0, 0);
            button_File.Name = "button_File";
            button_File.Size = new Size(194, 40);
            button_File.TabIndex = 8;
            button_File.Text = "Open test result";
            button_File.UseVisualStyleBackColor = true;
            button_File.Click += button_File_Click;
            // 
            // label_Percentage
            // 
            label_Percentage.AutoSize = true;
            label_Percentage.Location = new Point(3, 186);
            label_Percentage.Name = "label_Percentage";
            label_Percentage.Size = new Size(74, 15);
            label_Percentage.TabIndex = 4;
            label_Percentage.Text = "Success rate:";
            // 
            // label_Total
            // 
            label_Total.AutoSize = true;
            label_Total.Location = new Point(3, 141);
            label_Total.Name = "label_Total";
            label_Total.Size = new Size(35, 15);
            label_Total.TabIndex = 3;
            label_Total.Text = "Total:";
            // 
            // label_Incorrect
            // 
            label_Incorrect.AutoSize = true;
            label_Incorrect.Location = new Point(3, 171);
            label_Incorrect.Name = "label_Incorrect";
            label_Incorrect.Size = new Size(41, 15);
            label_Incorrect.TabIndex = 2;
            label_Incorrect.Text = "Failed:";
            // 
            // label_Correct
            // 
            label_Correct.AutoSize = true;
            label_Correct.Location = new Point(3, 156);
            label_Correct.Name = "label_Correct";
            label_Correct.Size = new Size(67, 15);
            label_Correct.TabIndex = 1;
            label_Correct.Text = "Succeeded:";
            // 
            // label_Result
            // 
            label_Result.AutoSize = true;
            label_Result.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_Result.Location = new Point(3, 120);
            label_Result.Name = "label_Result";
            label_Result.Size = new Size(57, 21);
            label_Result.TabIndex = 0;
            label_Result.Text = "Result";
            // 
            // textBox_FilePath
            // 
            textBox_FilePath.Dock = DockStyle.Bottom;
            textBox_FilePath.Location = new Point(0, 550);
            textBox_FilePath.Name = "textBox_FilePath";
            textBox_FilePath.ReadOnly = true;
            textBox_FilePath.Size = new Size(769, 23);
            textBox_FilePath.TabIndex = 8;
            // 
            // button_VerifyTemperature
            // 
            button_VerifyTemperature.Dock = DockStyle.Bottom;
            button_VerifyTemperature.Location = new Point(0, 550);
            button_VerifyTemperature.Name = "button_VerifyTemperature";
            button_VerifyTemperature.Size = new Size(194, 23);
            button_VerifyTemperature.TabIndex = 10;
            button_VerifyTemperature.Text = "Verify Temperature result";
            button_VerifyTemperature.UseVisualStyleBackColor = true;
            button_VerifyTemperature.Click += button_VerifyTemperature_Click;
            // 
            // DataViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 573);
            Controls.Add(textBox_FilePath);
            Controls.Add(panel_Controls);
            Controls.Add(treeViewTestResult);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DataViewForm";
            Text = "Test Data Viewer";
            Load += DataViewForm_Load;
            Resize += DataViewForm_Resize;
            panel_Controls.ResumeLayout(false);
            panel_Controls.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openDataFileDialog;
        private TreeView treeViewTestResult;
        private Panel panel_Controls;
        private Label label_Result;
        private Label label_Correct;
        private Label label_Percentage;
        private Label label_Total;
        private Label label_Incorrect;
        private TextBox textBox_FilePath;
        private Button button_File;
        private Button button_Folder;
        private FolderBrowserDialog folderBrowserDialog;
        private Button button_VerifyTemperature;
    }
}