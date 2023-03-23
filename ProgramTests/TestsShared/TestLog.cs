using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsShared
{
    /// <summary>
    /// Log results from a test round
    /// </summary>
    public record TestLog
    {
        /// <summary>
        /// Input given to the tested program
        /// </summary>
        public string Input { get; init; } = string.Empty;

        /// <summary>
        /// Output from the tested program
        /// </summary>
        public string Output { get; init; } = string.Empty;

        /// <summary>
        /// True if the output was correct
        /// </summary>
        public bool CorrectOutput { get; init; }

        /// <summary>
        /// If the output was incorrect, this contains the reason for failure. Default is empty string.
        /// </summary>
        public string FailMessage { get; init; } = string.Empty;
    }
}
