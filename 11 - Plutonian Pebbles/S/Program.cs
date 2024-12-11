using aoc;

bool test = false;

string[] input = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

string[] numbers = input[0].Split(' ');

Stone? startStone = null;

{
    Stone? lastStone = null;
    
    foreach (string number in numbers)
    {
        Stone stone = new Stone(number);

        if (lastStone == null)
        {
            startStone = stone;
        }
        else
        {
            lastStone.NextStone = stone;
        }
        
        lastStone = stone;
    }
}

for (int i = 0; i < 25; i++)
{
    Stone? currentStone = startStone;
    while (currentStone != null)
    {
        if(i < 6) Console.Write($"{currentStone.Value} ");

        Stone? nextStone = currentStone.NextStone;
        currentStone.Blink();
        currentStone = nextStone;
    }
    
    if(i < 6) Console.WriteLine();
}

{
    Stone? currentStone = startStone!;
    long cnt = 0;
    while (currentStone != null)
    {
        cnt++;
        currentStone = currentStone.NextStone;
    }
    
    Console.WriteLine(cnt);
}