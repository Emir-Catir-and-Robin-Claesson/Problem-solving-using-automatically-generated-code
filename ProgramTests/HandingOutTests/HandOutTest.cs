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

            int numOfPeople = rnd.Next(4, 13);

            sb.AppendLine($"{numOfPeople}");

            for (int i = 1; i < numOfPeople; i++)
            {
                for(int j = i+1; j <= numOfPeople; j++)
                {
                    var distance = rnd.Next(1, 10);
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

            for (int i = 1; i < inputRows.Length; i++)
            {
                var splitRow = (inputRows[i].Split());
                int student1 = int.Parse(splitRow[0]);
                var student2 = int.Parse(splitRow[1]);
                int distance = int.Parse(splitRow[2]);
                
                studentsAdjMatrix[student1, student2] = distance;
                studentsAdjMatrix[student2, student1] = distance;        
            }

            var suggestedShortestDistance = int.Parse(outputRows[0]);
            var suggestedPath = outputRows[1].Split();
            int controlSum = 0;
            List<int> chosenPath = new List<int>();
            chosenPath.Add(1);
            for(int i = 0; i < suggestedPath.Length-1; i++)
            {
                //Check if suggested path is valid
                var fromStudent = int.Parse(suggestedPath[i]);
                if(fromStudent == 0 || fromStudent > numOfStudents)
                    return (false, $"Path invovles non existing student {fromStudent}: Student numbers from 1 to {numOfStudents} are available but chose '{fromStudent}");
                var toStudent = int.Parse(suggestedPath[i+1]);
                if(toStudent == 0 || toStudent > numOfStudents)
                    return (false, $"Path invovles non existing student {toStudent}: Student numbers from 1 to {numOfStudents} are available but chose '{toStudent}");


                //Some ACG adds the last student while other don't to make a more fair evaluation this is corrected for.
                //If last student happen to be 1, ignore this.
                if (toStudent == 1 && (i + 1) == (suggestedPath.Length - 1))
                    break;

                controlSum += studentsAdjMatrix[fromStudent, toStudent];

                //Check that path do not pass a student twice
                if(chosenPath.Contains(toStudent))
                    return (false, $"Path pases student {toStudent} twice");
                
                chosenPath.Add(toStudent);
            }
            //Check so that every student is visisted
            if ((chosenPath.Count()) != numOfStudents)
                return (false, $"Path does not include all students, path contains {chosenPath.Count()}, total number of students is: {numOfStudents}");
            //Check is distance is correctly calculated
            if (controlSum != suggestedShortestDistance)
                return (false, $"Path is valid but distance is wrongfully calculated, control sum: {controlSum}, suggested: {suggestedShortestDistance}");

            return (true, string.Empty);
        }
    }
}

