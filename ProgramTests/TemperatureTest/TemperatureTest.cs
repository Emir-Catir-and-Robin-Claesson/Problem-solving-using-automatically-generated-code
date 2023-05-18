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


            var globalMin = decimal.MaxValue;
            var globalMax = decimal.MinValue;
            var globalTotal = 0.0m;

            var roundingErrors = new StringBuilder();

            for (int i = 0; i < numOfWeeks; i++)
            {
                var temps = inputRows[1 + i].TrimEnd().Split(' ').Select(m => decimal.Parse(m, _culture)).ToList();

                var localMin = decimal.MaxValue;
                var localMax = decimal.MinValue;
                var localTotal = 0.0m;

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

                var localAvg = Decimal.Round(localTotal / numOfMeasurements, 1, MidpointRounding.AwayFromZero);

                var outputData = outputRows[i].TrimEnd().Split();
                var outputMin = decimal.Parse(outputData[0], _culture);
                var outputMax = decimal.Parse(outputData[1], _culture);
                var outputAvg = decimal.Parse(outputData[2], _culture);

                if (outputMin != localMin)
                {
                    if (Math.Abs(outputMin - localMin) < 0.2m)
                    {
                        roundingErrors.AppendLine($"Wrong local min on week '{i + 1}': Gave '{outputMin}' but should have been '{localMin}' | ");
                    }
                    else
                    {
                        return (false, $"Wrong local min on week '{i + 1}': Gave '{outputMin}' but should have been '{localMin}'");
                    }
                }

                if (outputMax != localMax)
                {
                    if (Math.Abs(outputMax - localMax) < 0.2m)
                    {
                        roundingErrors.AppendLine($"Wrong local max on week '{i + 1}': Gave '{outputMax}' but should have been '{localMax}' | ");
                    }
                    else
                    {
                        return (false, $"Wrong local max on week '{i + 1}': Gave '{outputMax}' but should have been '{localMax}'");
                    }

                }

                if (outputAvg != localAvg)
                {
                    if (Math.Abs(outputMax - localMax) < 0.2m)
                    {
                        roundingErrors.AppendLine($"Wrong local avg on week '{i + 1}': Gave '{outputAvg}' but should have been '{localAvg}' | ");
                    }
                    else
                    {
                        return (false, $"Wrong local avg on week '{i + 1}': Gave '{outputAvg}' but should have been '{localAvg}'");

                    }
                }
            }

            var globalAvg = Decimal.Round(globalTotal / (numOfMeasurements * numOfWeeks), 1, MidpointRounding.AwayFromZero);


            var outputGlobalData = outputRows.Last().TrimEnd().Split();
            var outputGlobalMin = decimal.Parse(outputGlobalData[0], _culture);
            var outputGlobalMax = decimal.Parse(outputGlobalData[1], _culture);
            var outputGlobalAvg = decimal.Parse(outputGlobalData[2], _culture);

            if (outputGlobalMin != globalMin)
            {
                if (Math.Abs(outputGlobalMin - globalMin) < 0.2m)
                {
                    roundingErrors.AppendLine($"Wrong global min: Gave '{outputGlobalMin}' but should have been '{globalMin}' | ");
                }
                else
                {
                    return (false, $"Wrong global min: Gave '{outputGlobalMin}' but should have been '{globalMin}'");
                }
            }
            if (outputGlobalMax != globalMax)
            {
                if (Math.Abs(outputGlobalMax - globalMax) < 0.2m)
                {
                    roundingErrors.AppendLine($"Wrong global max: Gave '{outputGlobalMax}' but should have been '{globalMax}' | ");
                }
                else
                {
                    return (false, $"Wrong global max: Gave '{outputGlobalMax}' but should have been '{globalMax}'");
                }
            }
            if (outputGlobalAvg != globalAvg)
            {
                if (Math.Abs(outputGlobalAvg - globalAvg) < 0.2m)
                {
                    roundingErrors.AppendLine($"Wrong global average: Gave '{outputGlobalAvg}' but should have been '{globalAvg} | '");
                }
                else
                {
                    return (false, $"Wrong global average: Gave '{outputGlobalAvg}' but should have been '{globalAvg}'");
                }
            }

            return (true, roundingErrors.ToString());
        }
    }
}
