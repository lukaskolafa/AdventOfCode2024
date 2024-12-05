namespace aoc;

public class Manual
{
    public Manual(string input)
    {
        Pages = input.Split(",").Select(int.Parse).ToArray();
    }
    
    public int MiddlePage => Pages[Pages.Length / 2];

    public string PageList => string.Join(",", Pages);
    
    public int[] Pages { get; private set; }
}