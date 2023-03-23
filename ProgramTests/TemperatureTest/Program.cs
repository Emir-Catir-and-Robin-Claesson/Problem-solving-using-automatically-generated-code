using TemperatureProblemTest;
using TestsShared;

var testInfo = TestInfo.GetFromStdIn();
var test = new TemperatureTest(testInfo);
var testResult = test.RunTest();

Console.WriteLine(testResult.GetTestStats());