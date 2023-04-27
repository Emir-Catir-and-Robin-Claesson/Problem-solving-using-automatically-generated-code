using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestsShared;

namespace SortingProblemTest
{
    public class SortingTest : ProgramTest
    {
        public SortingTest(TestInfo testInfo) : base(testInfo)
        {
        }

        protected override string GenerateInput()
        {
            StringBuilder sb = new StringBuilder();

            var rnd = new Random();

            var numOfPeople = rnd.Next(100, 300);

            sb.AppendLine($"{numOfPeople}");

            for (int i = 0; i < numOfPeople; i++)
            {
                sb.AppendLine(new PersonData().ToString());
            }

            return sb.ToString();
        }

        protected override (bool isCorrect, string failMessage) VerifyOutput(string testInput, string testOutput)
        {
            var inputRows = testInput.TrimEnd().Replace("\r", "").Split('\n');
            var outputRows = testOutput.TrimEnd().Replace("\r", "").Split('\n');


            var numOfPeople = int.Parse(inputRows[0]);
            var people = new List<PersonData>();

            for (int i = 1; i <= numOfPeople; i++)
            {
                people.Add(new PersonData(inputRows[i]));
            }

            var sortedPeople = people.OrderBy(x => x.Height).ThenBy(x => x.Weight).
                                       ThenBy(x => x.Age).ThenBy(x => x.HomeTown).
                                       ThenBy(x => x.Name).ToList();

            var outputPeople = new List<PersonData>();
            for (int i = 0; i < numOfPeople; i++)
            {
                outputPeople.Add(new PersonData(outputRows[i]));
            }

            for (int i = 0; i < numOfPeople; i++)
            {
                var outputPerson = outputPeople[i];
                var sortedPerson = sortedPeople[i];
                if (outputPerson != sortedPerson)
                {
                    return (false, $"Person {i + 1} is not sorted correctly: Gave '{outputPerson}' but should have been '{sortedPeople[i]}");
                }
            }

            return (true, string.Empty);
        }
    }
}
