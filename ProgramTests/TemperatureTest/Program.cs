using TemperatureProblemTest;
using TestsShared;

var testInfo = TestInfo.GetFromStdIn();

Console.Write("Enter char used as float separator (, or .):");
char floatSeparator = Console.ReadLine()[0];

var test = new TemperatureTest(testInfo, floatSeparator);
var testResult = test.RunTest();
Console.WriteLine(testResult.GetTestStats());