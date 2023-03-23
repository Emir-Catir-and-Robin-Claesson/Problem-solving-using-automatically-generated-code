﻿using System;
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
        /// <summary>
        /// Logs for all rounds that was succesfull (correct output)
        /// </summary>
        public List<TestLog> SucceededTests { get; private init; } = new List<TestLog>();

        /// <summary>
        /// Logs for all rounds that was unsuccesfull (incorrect output)
        /// </summary>
        public List<TestLog> FailedTests { get; private init; } = new List<TestLog>();

        /// <summary>
        /// Gets the ammount of succeeded and failed tests in a string 
        /// </summary>
        /// <returns></returns>
        public string GetTestStats() => $"Succeeded: {SucceededTests.Count}, Failed: {FailedTests.Count}";
    }
}
