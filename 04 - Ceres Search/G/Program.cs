bool test = false;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

int width = allLines[0].Length;
int height = allLines.Length;

var result = 0;

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        if (!IsXMas(x, y))
        {
            continue;
        }
        
        result ++;
    }
}

Console.WriteLine(result);

bool IsXMas(int startX, int startY)
{
    if (GetChar(startX, startY) != 'A')
    {
        return false;
    }

    char[] diag1 = { GetChar(startX - 1, startY - 1), GetChar(startX + 1, startY + 1) };
    char[] diag2 = { GetChar(startX - 1, startY + 1), GetChar(startX + 1, startY - 1) };
    
    if (string.Join("",diag1.Order()) == "MS" && string.Join("",diag2.Order()) == "MS")
    {
        return true;
    }

    return false;
}

char GetChar(int x, int y)
{
    if (x < 0 || x >= width || y < 0 || y >= height)
    {
        return ' ';
    }

    return allLines[y][x];
}