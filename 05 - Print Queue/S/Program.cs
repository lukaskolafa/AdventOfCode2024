using System.Text.RegularExpressions;
using aoc;

bool test = false;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

int part = 1;

var rules = new List<Rule>();
var manuals = new List<Manual>();
var validManuals = new List<Manual>();

foreach (var line in allLines)
{
    if (line == "")
    {
        part = 2;
        continue;
    }
    
    if (part == 1)
    {
        rules.Add(new Rule(line));
    }
    else
    {
        manuals.Add(new Manual(line));
    }
}

foreach (var manual in manuals)
{
    bool isValid = true;
    
    foreach (var rule in rules)
    {
        if (!IsManualValid(manual, rule))
        {
            isValid = false;
            break;
        }
    }

    if (isValid)
    {
        validManuals.Add(manual);
    }
}

long result = 0;

foreach (var validManual in validManuals)
{
    Console.WriteLine($"Valid manual: [{validManual.PageList}] - Middle page: {validManual.MiddlePage}");
    
    result += validManual.MiddlePage;
}

Console.WriteLine(result);

bool IsManualValid(Manual manual, Rule rule)
{
    Regex regex = new Regex($".*{rule.Second}.*{rule.First}.*");
    
    if (regex.IsMatch(manual.PageList))
    {
        return false;
    }
    
    return true;
}