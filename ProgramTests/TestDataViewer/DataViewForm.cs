using TestsShared;
using System.Text.Json;

namespace TestDataViewer
{
    public partial class DataViewForm : Form
    {
        TestResult TestResult { get; set; } = new TestResult();

        public DataViewForm()
        {
            InitializeComponent();
        }

        private void DataViewForm_Load(object sender, EventArgs e)
        {
            openDataFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_File_Click(object sender, EventArgs e)
        {
            if (openDataFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openDataFileDialog.FileName))
                {
                    try
                    {
                        TestResult = (TestResult)JsonSerializer.Deserialize(File.ReadAllText(openDataFileDialog.FileName), typeof(TestResult));
                        treeViewTestResult.Nodes.Clear();
                        treeViewTestResult.Nodes.Add(TestResultToTreeNodes(TestResult, "Test Result"));
                        treeViewTestResult.Nodes[0].Expand();

                        textBox_FilePath.Text = openDataFileDialog.FileName;
                        UpdateResultInformation();
                    }
                    catch
                    {
                        MessageBox.Show("Could not read test data from file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button_Folder_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if(Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    Cursor.Current = Cursors.WaitCursor; 
                    string[] allTestResults = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.json", SearchOption.AllDirectories);

                    treeViewTestResult.Nodes.Clear();
                    
                    foreach(string filePath in allTestResults)
                    {
                        try
                        {
                            TestResult = (TestResult)JsonSerializer.Deserialize(File.ReadAllText(filePath), typeof(TestResult));
                            treeViewTestResult.Nodes.Add(TestResultToTreeNodes(TestResult, filePath.Replace(folderBrowserDialog.SelectedPath, "")));
                        }
                        catch { }
                    }

                    treeViewTestResult.Nodes[0].Expand();
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private TreeNode TestResultToTreeNodes(TestResult testResult, string rootName)
        {
            var root = new TreeNode(rootName);

            root.Nodes.Add(TestLogsToTreeNodes(testResult.SucceededTests, "Succeeded"));
            root.Nodes.Add(TestLogsToTreeNodes(testResult.FailedTests, "Failed"));

            return root;
        }

        private TreeNode TestLogsToTreeNodes(List<TestLog> testLogs, string testPrefix)
        {
            var root = new TreeNode($"{testPrefix} Tests");
            for (int i = 0; i < testLogs.Count; i++)
            {
                var testNode = new TreeNode($"{testPrefix} Test #{i + 1}");

                var inputNode = testNode.Nodes.Add("Input");
                inputNode.Nodes.Add(testLogs[i].Input);

                var outputNode = testNode.Nodes.Add("Test Output");
                outputNode.Nodes.Add(testLogs[i].Output);

                if (testLogs[i].FailMessage != string.Empty)
                {
                    var failMessageNode = testNode.Nodes.Add("Fail Message");
                    failMessageNode.Nodes.Add(testLogs[i].FailMessage);
                }

                root.Nodes.Add(testNode);
            }

            return root;
        }

        private void UpdateResultInformation()
        {
            int numOfTotalTests = TestResult.SucceededTests.Count + TestResult.FailedTests.Count;
            label_Total.Text = $"Total: {numOfTotalTests}";
            label_Correct.Text = $"Succeeded: {TestResult.SucceededTests.Count}";
            label_Incorrect.Text = $"Failed: {TestResult.FailedTests.Count}";
            label_Percentage.Text = $"Success rate: {Math.Round((double)TestResult.SucceededTests.Count / numOfTotalTests * 100, 2)}%";

        }


        private void button_Filter_Click(object sender, EventArgs e)
        {

        }


    }
}