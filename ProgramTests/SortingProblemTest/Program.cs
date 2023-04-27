using SortingProblemTest;
using TestsShared;

var testInfo = TestInfo.GetFromStdIn();
var test = new SortingTest(testInfo);
var testResult = test.RunTest();

Console.WriteLine(testResult.GetTestStats());