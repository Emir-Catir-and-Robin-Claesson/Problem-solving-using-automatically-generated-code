using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsShared;

namespace HandingOutTests
{
    public class HandOutTest : ProgramTest
    {
        public HandOutTest(TestInfo testInfo) : base(testInfo)
        {

        }

        protected override string GenerateInput()
        {
            StringBuilder sb = new StringBuilder();

            var rnd = new Random();

            var numOfPeople = rnd.Next(100, 300);

            sb.AppendLine($"{numOfPeople}");

            for (int i = 1; i < numOfPeople; i++)
            {
                for(int j = i+1; j < numOfPeople; j++)
                {
                    var distance = rnd.Next(1, 25);
                    sb.AppendLine($"{i} {j} {distance}");
                }
            }

            return sb.ToString();
        }

        protected override (bool isCorrect, string failMessage) VerifyOutput(string testInput, string testOutput)
        {
            var inputRows = testInput.TrimEnd().Replace("\r", "").Split('\n');
            var outputRows = testOutput.TrimEnd().Replace("\r", "").Split('\n');

            
            //Put distances between students in an adjMatrix
            var numOfStudents = int.Parse(inputRows[0]);
            int[,] studentsAdjMatrix = new int[numOfStudents+1, numOfStudents+1];

            for (int i = 1; i <= numOfStudents; i++)
            {
                for(int j = i; j <= numOfStudents; j++)
                {
                    if(i == j)
                    {
                        studentsAdjMatrix[i, j] = 0;
                        studentsAdjMatrix[j, i] = 0;
                    }
                    else
                    {
                        var student1 = (inputRows[i]);
                        var student2 = (inputRows[i + 1]);
                        int distance = int.Parse(inputRows[i + 2]);

                        studentsAdjMatrix[i, j] = distance;
                        studentsAdjMatrix[j, i] = distance;
                    }
                }
            }

            var suggestedShortestDistance = int.Parse(outputRows[0]);
            int controlSum = 0;
            List<int> chosenPath = new List<int>();
            for(int i = 1; i < outputRows.Length; i++)
            {
                //Check if suggested path is valid
                var fromStudent = int.Parse(outputRows[i]);
                if(fromStudent == 0 || fromStudent > numOfStudents)
                    return (false, $"Path invovles non existing student {fromStudent}: Student numbers from 1 to {numOfStudents} are available but chose '{fromStudent}");
                var toStudent = int.Parse(outputRows[i+1]);
                if(toStudent == 0 || toStudent > numOfStudents)
                    return (false, $"Path invovles non existing student {toStudent}: Student numbers from 1 to {numOfStudents} are available but chose '{toStudent}");

                controlSum += studentsAdjMatrix[fromStudent, toStudent];
                
                //Check that path do not pass a student twice
                if(chosenPath.Contains(fromStudent))
                    return (false, $"Path pases student {fromStudent} twice");
                
                chosenPath.Add(fromStudent);
            }
            //Check is distance is correctly calculated
            if (controlSum != suggestedShortestDistance)
                return (false, $"Path is valid but distance is wrongfully calculated, control sum: {controlSum}, suggested: {suggestedShortestDistance}");

            return (true, string.Empty);
        }
    }
}

