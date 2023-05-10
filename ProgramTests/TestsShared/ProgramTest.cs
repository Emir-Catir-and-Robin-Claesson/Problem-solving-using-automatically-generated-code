using System.Diagnostics;
using System.Text.Json;

namespace TestsShared
{
    /// <summary>
    /// Base class for ACG generated program tests. Contains the logic for running the test.
    /// </summary>
    public abstract class ProgramTest
    {
        private TestInfo _testInfo;

        protected ProgramTest(TestInfo testInfo)
        {
            _testInfo = testInfo;
        }

        /// <summary>
        /// Generate the input for a test
        /// </summary>
        /// <returns>Input string in the format specified in the problem description</returns>
        protected abstract string GenerateInput();

        /// <summary>
        /// Verifies the output from a test is correct
        /// </summary>
        /// <param name="testInput">Input given to the tested program</param>
        /// <param name="testOutput">Output from the tested program</param>
        /// <returns>Tuple with bool isCorrect and string failMessage: isCorrect says if the test passed, if test failed failMessage contains the reason for failure</returns>
        protected abstract (bool isCorrect, string failMessage) VerifyOutput(string testInput, string testOutput);


        /// <summary>
        /// Runs the test with the ammount of rouds specified in TestInfo. 
        /// Also saves the result to Test_Result.json
        /// </summary>
        /// <returns>The results of the tests</returns>
        public TestResult RunTest()
        {
            var testResult = new TestResult();

            for (int i = 0; i < _testInfo.NumOfRounds; i++)
            {
                Console.Write($"\rRunning test... {i + 1}/{_testInfo.NumOfRounds}");

                var testInput = GenerateInput();

                var process = new Process();
                process.StartInfo.FileName = _testInfo.FileName;
                process.StartInfo.Arguments = _testInfo.Arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();

                process.StandardInput.WriteLine(testInput);
                var testOutput = process.StandardOutput.ReadToEnd();
                var testError = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (testError != "")
                {
                    var testErrorLog = new TestLog
                    {
                        Input = testInput,
                        Output = testOutput,
                        CorrectOutput = false,
                        FailMessage = $"Error during runtime: '{testError}'"
                    };

                    testResult.FailedTests.Add(testErrorLog);
                }
                else
                {
                    var verification = VerifyOutput(testInput, testOutput);

                    var testLog = new TestLog
                    {
                        Input = testInput,
                        Output = testOutput,
                        CorrectOutput = verification.isCorrect,
                        FailMessage = verification.failMessage
                    };

                    if (verification.isCorrect)
                        testResult.SucceededTests.Add(testLog);
                    else
                        testResult.FailedTests.Add(testLog);
                }
            }
            Console.WriteLine("\r\nTest Complete");

            var jsonString = JsonSerializer.Serialize(testResult);

            var writer = new StreamWriter("Test_Result.json", false);
            writer.WriteLine(jsonString);
            writer.Close();

            return testResult;
        }

    }
}