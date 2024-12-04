bool test = false;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

int cnt = 0;

for (long i = 0; i < allLines.Length; i++)
{
    var line = allLines[i];

    var numbers = line.Split(" ").Select(int.Parse).ToArray();

    var diffs = new List<int>();
    for (int j = 0; j < numbers.Length - 1; j++)
    {
        diffs.Add(numbers[j + 1] - numbers[j]);
    }
    
    if (!diffs.All(x => x > 0) && !diffs.All(x => x < 0))
    {
        continue;
    }

    if (diffs.Any(x => x == 0))
    {
        continue;
    }
    
    if (diffs.Any(x => x > 3) || diffs.Any(x => x < -3))
    {
        continue;
    }

    cnt++;
}

Console.WriteLine(cnt);