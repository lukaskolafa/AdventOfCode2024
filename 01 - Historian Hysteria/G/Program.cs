using System.Text.RegularExpressions;

bool test = false;

long result = 0;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

var left = new List<long>();
var right = new List<long>();

for (int i = 0; i < allLines.Length; i++)
{
    var line = allLines[i];
    var match = Regex.Match(line, @"^(\d+)\s+(\d+)$");
    
    var firstDigit = match.Groups[1].Value;
    var lastDigit = match.Groups[2].Value;

    left.Add(long.Parse(firstDigit));
    right.Add(long.Parse(lastDigit));
}

for (int i = 0; i < allLines.Length; i++)
{
    result += left[i] * right.Count(x => x == left[i]);
}

Console.WriteLine(result);

// 626149 too low