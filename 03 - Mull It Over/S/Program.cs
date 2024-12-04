using System.Text.RegularExpressions;

bool test = false;

string text = File.ReadAllText(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

Regex regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

var matches = regex.Matches(text);

long result = 0;

foreach (Match match in matches)
{
    var n1 = int.Parse(match.Groups[1].Value);
    var n2 = int.Parse(match.Groups[2].Value);
    
    result += n1 * n2;
}

Console.WriteLine(result);