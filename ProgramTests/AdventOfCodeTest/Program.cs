using AdventOfCodeTest;
using TestsShared;

var testInfo = TestInfo.GetFromStdIn();
var test = new AoCTest(testInfo);
var testResult = test.RunTest();

Console.WriteLine(testResult.GetTestStats());