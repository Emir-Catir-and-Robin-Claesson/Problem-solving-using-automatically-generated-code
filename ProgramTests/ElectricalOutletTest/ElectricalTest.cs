using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsShared;

namespace ElectricalOutletTest
{
    public class ElectricalTest : ProgramTest
    {
        public ElectricalTest(TestInfo testInfo) : base(testInfo)
        {
        }

        protected override string GenerateInput()
        {
            var rnd = new Random();

            var numOfStands = rnd.Next(4, 10);

            var matrix = new int[numOfStands, numOfStands];

            for (int y = 0; y < numOfStands; y++)
            {
                for (int x = y + 1; x < numOfStands; x++)
                {
                    if (y != x)
                    {
                        var dist = rnd.Next(100, 400);
                        matrix[x, y] = dist;
                        matrix[y, x] = dist;
                    }
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine($"{numOfStands}");
            for (int y = 0; y < numOfStands; y++)
            {
                for (int x = 0; x < numOfStands; x++)
                {
                    sb.Append($"{matrix[x, y]} ");
                }
                sb.AppendLine();
            }
            string s = sb.ToString();
            return sb.ToString();
        }

        protected override (bool isCorrect, string failMessage) VerifyOutput(string testInput, string testOutput)
        {
            //Convert input and output to lists of lists of ints
            var testInputLines = testInput.TrimEnd().Split(Environment.NewLine).Select(x => x.TrimEnd().Split(' ').Select(x => int.Parse(x)).ToList()).ToList();
            var testOutputLines = testOutput.TrimEnd().Split(Environment.NewLine).Select(x => x.TrimEnd().Split(' ').Select(x => int.Parse(x)).ToList()).ToList();

            var numOfStands = testInputLines[0][0];
            testInputLines.RemoveAt(0);

            try
            {

            //Count how many times each stand is used in solution
            var placedBeneath = new int[numOfStands].ToList();
            foreach (var row in testOutputLines)
            {
                placedBeneath[row[3] - 1]++;
            }
            if(placedBeneath.Any(x => x > 1))
            {
                return (false, $"Stand {placedBeneath.FindIndex(x => x > 1) + 1} have more than one than one cord place beneath");
            }
            if(placedBeneath.Any(x => x == 0))
            {
                return (false, $"Stand {placedBeneath.FindIndex(x => x < 1) + 1} does not have a cord place beneath");
            }

            }
            catch
            {
                return (false, "Output not formatted correctly");
            }

            

            return (true, "");
        }
    }
}
