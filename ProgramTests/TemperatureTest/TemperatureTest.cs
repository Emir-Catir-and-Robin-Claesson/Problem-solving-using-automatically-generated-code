using System.Text;
using TestsShared;

namespace TemperatureProblemTest
{
    public class TemperatureTest : ProgramTest
    {
        public TemperatureTest(TestInfo testinfo) : base(testinfo)
        {
        }

        protected override string GenerateInput()
        {
            var random = new Random();

            var numOfWeeks = random.Next(4, 11);
            var numOfMeassurements = random.Next(3, 7);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{numOfWeeks} {numOfMeassurements}");

            for (int i = 0; i < numOfWeeks; i++)
            {
                for (int j = 0; j < numOfMeassurements; j++)
                {
                    stringBuilder.Append($"{random.Next(-10, 31)} ");
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        protected override (bool isCorrect, string failMessage) VerifyOutput(string testInput, string testOutput)
        {
            var inputRows = testInput.TrimEnd().Replace("\r", "").Split('\n');
            var outputRows = testOutput.TrimEnd().Replace("\r", "").Replace(".", ",").Split('\n');

            var firstInputRowSplit = inputRows[0].Split(' ');
            var numOfWeeks = int.Parse(firstInputRowSplit[0]);
            var numOfMeasurements = int.Parse(firstInputRowSplit[1]);


            var globalMin = double.MaxValue;
            var globalMax = double.MinValue;
            var globalTotal = 0.0;

            for (int i = 0; i < numOfWeeks; i++)
            {
                var temps = inputRows[1 + i].TrimEnd().Split(' ').Select(m => double.Parse(m)).ToList();

                var localMin = double.MaxValue;
                var localMax = double.MinValue;
                var localTotal = 0.0;

                for (int j = 0; j < numOfMeasurements; j++)
                {
                    if (temps[j] < localMin)
                        localMin = temps[j];
                    if (temps[j] > localMax)
                        localMax = temps[j];
                    localTotal += temps[j];
                }


                if (localMax > globalMax)
                    globalMax = localMax;
                if (localMin < globalMin)
                    globalMin = localMin;
                globalTotal += localTotal;

                var localAvg = localTotal / numOfMeasurements;

                var outputData = outputRows[i].TrimEnd().Split();
                var outputMin = double.Parse(outputData[0]);
                var outputMax = double.Parse(outputData[1]);
                var outputAvg = double.Parse(outputData[2]);

                if (outputMin != localMin)
                    return (false, $"Wrong local min on week '{i+1}': Gave '{outputMin}' but should have been '{localMin}'");
                if (outputMax != localMax)
                    return (false, $"Wrong local max on week '{i + 1}': Gave '{outputMax}' but should have been '{localMax}'");
                if (outputAvg != localAvg)
                    return (false, $"Wrong local avg on week '{i + 1}': Gave '{outputAvg}' but should have been '{localAvg}'");

            }

            var globalAvg = globalTotal / (numOfMeasurements * numOfWeeks);

            var outputGlobalData = outputRows.Last().TrimEnd().Split();
            var outputGlobalMin = double.Parse(outputGlobalData[0]);
            var outputGlobalMax = double.Parse(outputGlobalData[1]);
            var outputGlobalAvg = double.Parse(outputGlobalData[2]);

            if (outputGlobalMin != globalMin)
                return (false, $"Wrong global min: Gave '{outputGlobalMin}' but should have been '{globalMin}'");
            if (outputGlobalMax != globalMax)
                return (false, $"Wrong global max: Gave '{outputGlobalMax}' but should have been '{globalMax}'");
            if (outputGlobalAvg != globalAvg)
                return (false, $"Wrong global average: Gave '{outputGlobalAvg}' but should have been '{globalAvg}'");

            return (true, string.Empty);
        }
    }
}
