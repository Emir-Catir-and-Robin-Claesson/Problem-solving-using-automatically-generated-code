using ElectricalOutletTest;
using TestsShared;

var testInfo = TestInfo.GetFromStdIn();
var test = new ElectricalTest(testInfo);
var testResult = test.RunTest();

Console.WriteLine(testResult.GetTestStats());