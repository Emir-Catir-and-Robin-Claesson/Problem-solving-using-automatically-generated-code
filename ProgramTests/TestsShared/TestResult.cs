using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsShared
{
    /// <summary>
    /// Logs from all rounds in a test
    /// </summary>
    public record TestResult
    {

        public TestResult(TestResult other)
        {
            SucceededTests = new List<TestLog>(other.SucceededTests);
            FailedTests = new List<TestLog>(other.FailedTests);
        }

        /// <summary>
        /// Logs for all rounds that was succesfull (correct output)
        /// </summary>
        public List<TestLog> SucceededTests { get; set; } = new List<TestLog>();

        /// <summary>
        /// Logs for all rounds that was unsuccesfull (incorrect output)
        /// </summary>
        public List<TestLog> FailedTests { get; set; } = new List<TestLog>();

        /// <summary>
        /// Gets the ammount of succeeded and failed tests in a string 
        /// </summary>
        /// <returns></returns>
        public string GetTestStats() => $"Succeeded: {SucceededTests.Count}, Failed: {FailedTests.Count}";
    }
}
