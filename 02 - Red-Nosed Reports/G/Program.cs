bool test = false;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

int cnt = 0;

for (long i = 0; i < allLines.Length; i++)
{
    var line = allLines[i];

    var numbers = line.Split(" ").Select(int.Parse).ToList();

    if (IsSafe(numbers))
    {
        cnt++;
        continue;
    }

    for (int j = 0; j < numbers.Count; j++)
    {
        var newNumbers = new List<int>(numbers);
        newNumbers.RemoveAt(j);

        if (IsSafe(newNumbers))
        {
            cnt++;
            break;
        }
    }
}

Console.WriteLine(cnt);

bool IsSafe(IList<int> numbers)
{
    var diffs = new List<int>();
    for (int j = 0; j < numbers.Count - 1; j++)
    {
        diffs.Add(numbers[j + 1] - numbers[j]);
    }
    
    if (!diffs.All(x => x > 0) && !diffs.All(x => x < 0))
    {
        return false;
    }

    if (diffs.Any(x => x == 0))
    {
        return false;
    }
    
    if (diffs.Any(x => x > 3) || diffs.Any(x => x < -3))
    {
        return false;
    }

    return true;
}