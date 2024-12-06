using aoc;

bool test = false;

string[] input = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

int currentH = 0;
int currentW = 0;

Direction direction = Direction.Up;

bool[,] visits = new bool[input.Length, input[0].Length];

for (int h = 0; h < input.Length; h++)
{
    for (int w = 0; w < input[0].Length; w++)
    {
        if (input[h][w] == '^')
        {
            currentH = h;
            currentW = w;
            
            visits[h, w] = true;
            
            break;
        }
    }
    
    if (currentH != 0)
    {
        break;
    }
}

while (true)
{
    var newPositionCandidate = Walk(currentH, currentW, direction);

    if (newPositionCandidate.Width < 0 || newPositionCandidate.Width >= input[0].Length ||
        newPositionCandidate.Height < 0 || newPositionCandidate.Height >= input.Length)
    {
        break;
    }

    char newChar = input[newPositionCandidate.Height][newPositionCandidate.Width];

    switch (newChar)
    {
        case '.':
        case '^':
            currentH = newPositionCandidate.Height;
            currentW = newPositionCandidate.Width;
            visits[currentH, currentW] = true;
            break;
        case '#':
            direction = NextDirection(direction);
            break;
        default:
            throw new Exception("Invalid character");
    }
}

var result = 0;
for (int h = 0; h < input.Length; h++)
{
    for (int w = 0; w < input[0].Length; w++)
    {
        if (visits[h,w])
        {
            result++;
        }
    }
}

Console.WriteLine(result);

(int Height, int Width) Walk(int fromH, int fromW, Direction currentDirection)
{
    switch (currentDirection)
    {
        case Direction.Up: return (fromH - 1, fromW);
        case Direction.Right: return (fromH, fromW + 1);
        case Direction.Down: return (fromH + 1, fromW);
        case Direction.Left: return (fromH, fromW - 1);
        default: throw new ArgumentOutOfRangeException(nameof(currentDirection), currentDirection, null);
    }
}

Direction NextDirection(Direction currentDirection)
{
    switch (currentDirection)
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


