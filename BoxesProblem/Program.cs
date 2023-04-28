using BoxesProblem;
using TestsShared;

var testInfo = TestInfo.GetFromStdIn();

var test = new BoxesTest(testInfo);
var testResult = test.RunTest();

Console.WriteLine(testResult.GetTestStats());


