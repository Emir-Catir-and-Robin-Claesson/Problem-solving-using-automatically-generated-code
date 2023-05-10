using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsShared;
namespace AdventOfCodeTest
{
    public class AoCTest : ProgramTest
    {
        public AoCTest(TestInfo testInfo) : base(testInfo)
        {
        }

        protected override string GenerateInput()
        {
            var sb = new StringBuilder();
            var rnd = new Random();

            var numOfContainers = rnd.Next(15, 20);

            sb.AppendLine($"{numOfContainers}");

            for (int i = 0; i < numOfContainers; i++)
            {
                sb.AppendLine($"{rnd.Next(5, 50)}");
            }

            return sb.ToString();
        }

        protected override (bool isCorrect, string failMessage) VerifyOutput(string testInput, string testOutput)
        {
            var containers = testInput.Split(Environment.NewLine).Skip(1).Select(x => int.Parse(x)).ToList();
            var combinations = GetCombinations(containers);
            var answer = combinations.Count(x => x.Sum() == 150);

            var testAnswer = int.Parse(testOutput);

            if (testAnswer == answer)
            {
                return (false, $"Wrong answer: Gave '{testAnswer}' but should have been '{answer}'");
            }
            else
            {
                return (true, "");
            }
        }

        //https://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values
        private List<List<int>> GetCombinations(List<int> list)
        {
            List<List<int>> combos = new List<List<int>>();

            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                List<int> combo = new List<int>();
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');

                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        combo.Add(list[j]);
                    }
                }

                combos.Add(combo);
            }

            return combos;
        }
    }
}
