using System.Text.RegularExpressions;
using aoc;

bool test = false;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

int part = 1;

var rules = new List<Rule>();
var manuals = new List<Manual>();
var invalidManuals = new List<Manual>();

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
    foreach (var rule in rules)
    {
        if (!IsManualValid(manual, rule))
        {
            invalidManuals.Add(manual);
            break;
        }
    }
}

foreach (var invalidManual in invalidManuals)
{
    Console.WriteLine($"Invalid manual: [{invalidManual.PageList}] - Middle page: {invalidManual.MiddlePage}");
}

Console.WriteLine("Fixing invalid manuals...");

foreach (var invalidManual in invalidManuals)
{
    var broken = true;

    while (broken)
    {
        broken = false;
        
        foreach (var rule in rules)
        {
            if (!IsManualValid(invalidManual, rule))
            {
                SwapPages(invalidManual, rule);
                broken = true;
                break;
            }
        }
    }
}

Console.WriteLine("Fixed manuals...");

long result = 0;

foreach (var invalidManual in invalidManuals)
{
    Console.WriteLine($"Invalid manual: [{invalidManual.PageList}] - Middle page: {invalidManual.MiddlePage}");
    
    result += invalidManual.MiddlePage;
}

Console.WriteLine(result);

void SwapPages(Manual manual, Rule rule)
{
    // index of number in a list
    int indexSecond = manual.Pages.ToList().IndexOf(rule.Second);
    int indexFirst = manual.Pages.ToList().IndexOf(rule.First, indexSecond);
    
    (manual.Pages[indexFirst], manual.Pages[indexSecond]) = (manual.Pages[indexSecond], manual.Pages[indexFirst]);
}

bool IsManualValid(Manual manual, Rule rule)
{
    Regex regex = new Regex($".*{rule.Second}.*{rule.First}.*");
    
    if (regex.IsMatch(manual.PageList))
    {
        return false;
    }
    
    return true;
}