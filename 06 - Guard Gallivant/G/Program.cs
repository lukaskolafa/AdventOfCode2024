using aoc;

bool test = false;

string[] input = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

(int startH, int startW) = GetStartPosition(input);

var result = 0;
for (int h = 0; h < input.Length; h++)
{
    for (int w = 0; w < input[0].Length; w++)
    {
        if (input[h][w] != '.')
        {
            continue;
        }
        
        input[h] = input[h].Remove(w, 1).Insert(w, "#");

        if (IsLoop(input, startH, startW))
        {
            result++;
        }
        
        input[h] = input[h].Remove(w, 1).Insert(w, ".");
    }
}

Console.WriteLine(result);

bool IsLoop(string[] inputMap, int startH, int startW)
{
    Direction currentDirection = Direction.Up;

    Direction[,] visits = new Direction[inputMap.Length, inputMap[0].Length];

    (int currentH, int currentW) = (startH, startW);
    visits[currentH, currentW] = currentDirection;

    while (true)
    {
        var newPositionCandidate = Walk(currentH, currentW, currentDirection);

        if (newPositionCandidate.Width < 0 || newPositionCandidate.Width >= inputMap[0].Length || newPositionCandidate.Height < 0 || newPositionCandidate.Height >= inputMap.Length)
        {
            return false;
        }
        
        if (visits[newPositionCandidate.Height, newPositionCandidate.Width] == currentDirection)
        {
            return true;
        }

        char newChar = inputMap[newPositionCandidate.Height][newPositionCandidate.Width];

        switch (newChar)
        {
            case '.':
            case '^':
                currentH = newPositionCandidate.Height;
                currentW = newPositionCandidate.Width;
                visits[currentH, currentW] = currentDirection;
                break;
            case '#':
                currentDirection = NextDirection(currentDirection);
                break;
            default:
                throw new Exception("Invalid character");
        }
    }
}

(int Height, int Width) Walk(int fromH, int fromW, Direction direction)
{
    switch (direction)
    {
        case Direction.Up: return (fromH - 1, fromW);
        case Direction.Right: return (fromH, fromW + 1);
        case Direction.Down: return (fromH + 1, fromW);
        case Direction.Left: return (fromH, fromW - 1);
        default: throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
    }
}

(int Height, int Width) GetStartPosition(string[] inputMap)
{
    for (int h = 0; h < inputMap.Length; h++)
    {
        for (int w = 0; w < inputMap[0].Length; w++)
        {
            if (inputMap[h][w] == '^')
            {
                return (h, w);
            }
        }
    }
    
    throw new Exception("No start position found");
}

Direction NextDirection(Direction direction)
{
    switch (direction)
    {
        case Direction.Up:
            return Direction.Right;
        case Direction.Right:
            return Direction.Down;
        case Direction.Down:
            return Direction.Left;
        case Direction.Left:
            return Direction.Up;
        default:
            throw new ArgumentOutOfRangeException();
    }
}


