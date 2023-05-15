using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsShared;

namespace BoxesProblem
{
    public class BoxesTest : ProgramTest
    {
        public BoxesTest(TestInfo testinfo) : base(testinfo)
        {
            
        }

        protected override string GenerateInput()
        {
            var random = new Random();

            var boxMaxWeight = random.Next(3, 10);
            var numOfItems = random.Next(3, 10);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{boxMaxWeight}");
            stringBuilder.AppendLine($"{numOfItems}");
            for (int i = 0; i < numOfItems; i++)
            {
                var weightOfItem = random.Next(1, boxMaxWeight);
                stringBuilder.AppendLine($"{weightOfItem}");
            }

            return stringBuilder.ToString();
        }

        protected override (bool isCorrect, string failMessage) VerifyOutput(string testInput, string testOutput)
        {
            var inputRows = testInput.TrimEnd().Replace("\r", "").Split('\n');
            var outputRows = testOutput.TrimEnd().Replace("\r", "").Split('\n');


            var firstInputRowSplit = inputRows[0].Split(' ');
            var answerToOutput = int.Parse(outputRows[0]);
            var boxWeightCapacity = int.Parse(firstInputRowSplit[0]);
            var numOfItems = int.Parse(inputRows[1]);
            int sumOfItemWeights = 0;
            int optimalAmountOfBoxesNeeded;
            List<int> itemWeights = new List<int>();
            for(int i = 2; i < numOfItems+2; i++)
            {
                itemWeights.Add(int.Parse(inputRows[i]));
                sumOfItemWeights += int.Parse(inputRows[i]);
            }
            optimalAmountOfBoxesNeeded = FindOptimalAmountOfBoxes(itemWeights, boxWeightCapacity);

            if (sumOfItemWeights > boxWeightCapacity * answerToOutput)
                return (false, $"Sum of items weight is greater than total capacity");
            else if (answerToOutput > optimalAmountOfBoxesNeeded)
                return (false, $"More boxes used than needed");
            
            return (true, $"Optimal number of boxes");
        }

        private int FindOptimalAmountOfBoxes(List<int> itemWeights, int targetCapacity)
        {
            
            int boxesNeeded = 0;
            List<int> result = new List<int>();
            while (itemWeights.Count > 0)
            {
                //Försök fyll låda fullt, annars försök störst möjligt
                for (int i = targetCapacity; i > 0; i--)
                {
                    //Töm results
                    result = new List<int>();
                    result = FillBox(itemWeights,result, i, 0, 0);
                    if(result.Sum() == i)
                        break;
                }
                //Ta bort items från itemlistan
                for(int i = 0; i < result.Count; i++)
                {
                    itemWeights.Remove(result.ElementAt(i));
                }
                boxesNeeded++;            
            }
            return boxesNeeded;
        }

        private List<int> FillBox(List<int> itemWeights, List<int> result, int targetCapacity,int index, int sum)
        {

            if(index < itemWeights.Count)
                sum += itemWeights[index];
            //Om vi nått slutet på listan
            if(index == itemWeights.Count)
            {
                if (sum == targetCapacity)
                {
                    result.Add(itemWeights[index]);
                    return result;
                }
                else
                {
                    return result;
                }
            }
            //Om sum är maxKapacitet av lådan
            else if (sum == targetCapacity)
            {
                result.Add(itemWeights[index]);
                return result;
            }
            //Inkludera nästa element
            else if (sum < targetCapacity)
            {
                result.Add(itemWeights[index]);
                FillBox(itemWeights, result, targetCapacity, index + 1, sum);
            }
            //Exkludera elementet
            else if (sum > targetCapacity)
            {
                sum -= itemWeights[index];
                FillBox(itemWeights, result, targetCapacity, index + 1, sum);
                return result;
            }
            return result;
        }
    }
}
