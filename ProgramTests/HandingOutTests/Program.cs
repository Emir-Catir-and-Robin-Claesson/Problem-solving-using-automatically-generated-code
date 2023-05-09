using HandingOutTests;
using TestsShared;

var testInfo = TestInfo.GetFromStdIn();
var test = new HandOutTest(testInfo);
var testResult = test.RunTest();

Console.WriteLine(testResult.GetTestStats());