namespace aoc;

public class Manual
{
    public Manual(string input)
    {
        Pages = input.Split(",").Select(int.Parse).ToArray();
        
        PageList = input;
    }
    
    public int MiddlePage => Pages[Pages.Length / 2];
    
    public string PageList { get; private set; }
    
    public int[] Pages { get; private set; }
}