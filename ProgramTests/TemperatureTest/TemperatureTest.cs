using System.Globalization;
using System.Text;
using TestsShared;

namespace TemperatureProblemTest
{
    public class TemperatureTest : ProgramTest
    {
        //To take into account what floating number separator is used
        CultureInfo _culture;

        public TemperatureTest(TestInfo testinfo, char floatSeparator) : base(testinfo)
        {
            if (floatSeparator == ',')
            {
                _culture = new CultureInfo("fr-fr");
            }
            else
            {
                _culture = new CultureInfo("en-us");
            }
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
                    var rnd = random.Next(-100, 310);
                    var number = rnd / 10.0;

                    stringBuilder.Append($"{(rnd / 10.0).ToString(_culture)} ");
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        protected override (bool isCorrect, string failMessage) VerifyOutput(string testInput, string testOutput)
        {
            var inputRows = testInput.TrimEnd().Replace("\r", "").Split('\n');
            var outputRows = testOutput.TrimEnd().Replace("\r", "").Split('\n');

            var firstInputRowSplit = inputRows[0].Split(' ');
            var numOfWeeks = int.Parse(firstInputRowSplit[0]);
            var numOfMeasurements = int.Parse(firstInputRowSplit[1]);


            var globalMin = double.MaxValue;
            var globalMax = double.MinValue;
            var globalTotal = 0.0;

            for (int i = 0; i < numOfWeeks; i++)
            {
                var temps = inputRows[1 + i].TrimEnd().Split(' ').Select(m => double.Parse(m, _culture)).ToList();

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

                var localAvg = Math.Round(localTotal / numOfMeasurements, 1);

                var outputData = outputRows[i].TrimEnd().Split();
                var outputMin = double.Parse(outputData[0], _culture);
                var outputMax = double.Parse(outputData[1], _culture);
                var outputAvg = double.Parse(outputData[2], _culture);

                if (outputMin != localMin)
                    return (false, $"Wrong local min on week '{i + 1}': Gave '{outputMin}' but should have been '{localMin}'");
                if (outputMax != localMax)
                    return (false, $"Wrong local max on week '{i + 1}': Gave '{outputMax}' but should have been '{localMax}'");
                if (outputAvg != localAvg)
                    return (false, $"Wrong local avg on week '{i + 1}': Gave '{outputAvg}' but should have been '{localAvg}'");

            }

            var globalAvg = Math.Round(globalTotal / (numOfMeasurements * numOfWeeks), 1);

            var outputGlobalData = outputRows.Last().TrimEnd().Split();
            var outputGlobalMin = double.Parse(outputGlobalData[0], _culture);
            var outputGlobalMax = double.Parse(outputGlobalData[1], _culture);
            var outputGlobalAvg = double.Parse(outputGlobalData[2], _culture);

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
