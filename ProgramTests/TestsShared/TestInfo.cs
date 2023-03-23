using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsShared
{
    /// <summary>
    /// Info about what program to run and how many times to run a test
    /// </summary>
    public class TestInfo
    {
        /// <summary>
        /// Path to the file being run
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Commandline arguments for the program
        /// </summary>
        public string Arguments { get; set; } 

        /// <summary>
        /// How many time input should be generated and tested
        /// </summary>
        public int NumOfRounds { get; set; }

        public static TestInfo GetFromStdIn()
        {
            Console.Write("Enter program to run: ");
            var fileName = Console.ReadLine();
            Console.Write("Enter commandline arguments: ");
            var arguments = Console.ReadLine();
            Console.Write("Enter number of rounds: ");
            var numOfRounds = int.Parse(Console.ReadLine());
           
            return new TestInfo
            {
                FileName = fileName,
                Arguments = arguments,
                NumOfRounds = numOfRounds
            };
        }
    }
}
