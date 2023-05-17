using TestsShared;
using System.Text.Json;
using System.Globalization;

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
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string[] allTestResults = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*_Result.json", SearchOption.AllDirectories);

                    treeViewTestResult.Nodes.Clear();

                    foreach (string filePath in allTestResults)
                    {
                        try
                        {
                            TestResult = (TestResult)JsonSerializer.Deserialize(File.ReadAllText(filePath), typeof(TestResult));
                            treeViewTestResult.Nodes.Add(TestResultToTreeNodes(TestResult, filePath.Replace(folderBrowserDialog.SelectedPath, "")));
                        }
                        catch { }
                    }

                }
            }

            Cursor.Current = Cursors.Default;
        }

        private TreeNode TestResultToTreeNodes(TestResult testResult, string rootName)
        {
            var root = new TreeNode($"{rootName} ({testResult.SucceededTests.Count}/{testResult.FailedTests.Count + testResult.SucceededTests.Count})");

            root.Nodes.Add(TestLogsToTreeNodes(testResult.SucceededTests, "Succeeded"));
            root.Nodes.Add(TestLogsToTreeNodes(testResult.FailedTests, "Failed"));

            return root;
        }

        private TreeNode TestLogsToTreeNodes(List<TestLog> testLogs, string testPrefix)
        {
            var root = new TreeNode($"{testPrefix} Tests: {testLogs.Count}");
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
        private void UpdateResultInformation(TreeNode testRoot)
        {
            int numOfTotalTests = testRoot.Nodes[0].Nodes.Count + testRoot.Nodes[1].Nodes.Count;
            label_Total.Text = $"Total: {numOfTotalTests}";
            label_Correct.Text = $"Succeeded: {testRoot.Nodes[0].Nodes.Count}";
            label_Incorrect.Text = $"Failed: {testRoot.Nodes[1].Nodes.Count}";
            label_Percentage.Text = $"Success rate: {Math.Round((double)testRoot.Nodes[0].Nodes.Count / numOfTotalTests * 100, 2)}%";

        }

        private void treeViewTestResult_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.Contains(".json"))
            {
                UpdateResultInformation(e.Node);
                textBox_FilePath.Text = e.Node.Text;
            }
        }

        private void DataViewForm_Resize(object sender, EventArgs e)
        {
            treeViewTestResult.Width = panel_Controls.Left;
            treeViewTestResult.Height = textBox_FilePath.Top;
        }

        private void button_VerifyTemperature_Click(object sender, EventArgs e)
        {
            var reportedCorrect = TestResult.SucceededTests.Count;
            var reportedIncorrect = TestResult.FailedTests.Count;

            var incorrectBecauseOfRounding = 0;
            foreach (var test in TestResult.FailedTests)
            {
                var reported = 0.0;
                var actual = 0.0;

                var splitError = test.FailMessage.Split('\'');

                try
                {

                    if (test.FailMessage.Contains("week"))
                    {
                        reported = double.Parse($"{splitError[3]}");
                        actual = double.Parse($"{splitError[5]}");
                    }
                    else
                    {
                        reported = double.Parse($"{splitError[1]}");
                        actual = double.Parse($"{splitError[3]}");
                    }
                }
                catch
                {
                    var culture = new CultureInfo("en-us");
                    if (test.FailMessage.Contains("week"))
                    {
                        reported = double.Parse($"{splitError[3]}", culture);
                        actual = double.Parse($"{splitError[5]}", culture);
                    }
                    else
                    {
                        reported = double.Parse($"{splitError[1]}", culture);
                        actual = double.Parse($"{splitError[3]}", culture);
                    }
                }

                if (Math.Abs(reported - actual) <= 0.15)
                {
                    incorrectBecauseOfRounding++;
                }
            }

            var message = $"Reported correct: {reportedCorrect}\r\nReported incorrect: {reportedIncorrect}\r\nVerified correct: {reportedCorrect + incorrectBecauseOfRounding}\r\nVerified incorrect: {reportedIncorrect - incorrectBecauseOfRounding}";
            MessageBox.Show(message, "Verification complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}