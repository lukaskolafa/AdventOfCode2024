using aoc;

bool test = false;

string[] input = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

string[] numbers = input[0].Split(' ');

IDictionary<long, Stone> currentStones = new Dictionary<long, Stone>();
IDictionary<long, Stone> nextLevelStones = new Dictionary<long, Stone>();

foreach (string number in numbers)
{
    Stone stone = new Stone(number, 1);

    if (!currentStones.TryAdd(stone.Value, stone))
    {
        currentStones[stone.Value].Count += stone.Count;
    }
}

for (int i = 0; i < 75; i++)
{
    foreach (Stone stone in currentStones.Values)
    {
        Stone[] newStones = stone.Blink();
        
        foreach (Stone newStone in newStones)
        {
            if (!nextLevelStones.TryAdd(newStone.Value, newStone))
            {
                nextLevelStones[newStone.Value].Count += newStone.Count;
            }
        }
    }

    currentStones = nextLevelStones;
    nextLevelStones = new Dictionary<long, Stone>();
    
    // foreach(var st in currentStones)
    // {
    //     Console.Write($"{st.Value.Count}*{st.Value.Value} ");
    // }
    
    Console.WriteLine();
    Console.WriteLine($"{i+1}: {currentStones.Select(x => x.Value.Count).Sum()}");
}
