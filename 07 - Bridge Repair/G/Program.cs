using aoc;

bool test = false;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

long result = 0;

foreach (var line in allLines)
{
    string[] parts = line.Split(':');
    long[] numbers = parts[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
    long expectedResult = long.Parse(parts[0]);
    
    var challenge = new Challenge(numbers, expectedResult);
    if (challenge.Solve() == Challenge.Result.Success)
    {
        result += expectedResult;
        
        Console.WriteLine("Success: " + line);
    }
}

Console.WriteLine(result);