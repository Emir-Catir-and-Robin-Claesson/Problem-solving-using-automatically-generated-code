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

        private void loadTestDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openDataFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openDataFileDialog.FileName))
                {
                    try
                    {
                        TestResult = (TestResult)JsonSerializer.Deserialize(File.ReadAllText(openDataFileDialog.FileName), typeof(TestResult));
                        treeViewTestResult.Nodes.Clear();
                        treeViewTestResult.Nodes.Add(TestResultToTreeNodes(TestResult));
                    }
                    catch
                    {
                        MessageBox.Show("Could not read test data from file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private TreeNode TestResultToTreeNodes(TestResult testResult)
        {
            var root = new TreeNode("Test Result");

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
    }
}