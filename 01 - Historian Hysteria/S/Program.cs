using System.Text.RegularExpressions;

bool test = false;

long result = 0;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

var left = new List<long>();
var right = new List<long>();

for (long i = 0; i < allLines.Length; i++)
{
    var line = allLines[i];
    var match = Regex.Match(line, @"^(\d+)\s+(\d+)$");
    
    var firstDigit = match.Groups[1].Value;
    var lastDigit = match.Groups[2].Value;

    left.Add(long.Parse(firstDigit));
    right.Add(long.Parse(lastDigit));
}

var leftSorted = left.Order().ToArray();
var rightSorted = right.Order().ToArray();

for (long i = 0; i < allLines.Length; i++)
{
    var diff = Math.Abs(rightSorted[i] - leftSorted[i]);
    
    result += diff;
}

Console.WriteLine(result);

// 626149 too low