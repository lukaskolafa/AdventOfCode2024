bool test = false;

string[] allLines = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

int width = allLines[0].Length;
int height = allLines.Length;

var result = 0;

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        var words = GetWordsAllDirections(x, y, 4);
        var cnt = words.Count(w => w == "XMAS");
        
        result += cnt;
    }
}

Console.WriteLine(result);

string[] GetWordsAllDirections(int startX, int startY, int count)
{
    string[] words = new string[8];
    words[0] = GetWord(startX, startY, 0, 1, count);
    words[1] = GetWord(startX, startY, 1, 1, count);
    words[2] = GetWord(startX, startY, 1, 0, count);
    words[3] = GetWord(startX, startY, 1, -1, count);
    words[4] = GetWord(startX, startY, 0, -1, count);
    words[5] = GetWord(startX, startY, -1, -1, count);
    words[6] = GetWord(startX, startY, -1, 0, count);
    words[7] = GetWord(startX, startY, -1, 1, count);

    return words;
}

string GetWord(int startX, int startY, int stepX, int stepY, int count)
{
    string word = "";
    for (int i = 0; i < count; i++)
    {
        word += GetChar(startX + i * stepX, startY + i * stepY);
    }

    return word;
}

char GetChar(int x, int y)
{
    if (x < 0 || x >= width || y < 0 || y >= height)
    {
        return ' ';
    }

    return allLines[y][x];
}