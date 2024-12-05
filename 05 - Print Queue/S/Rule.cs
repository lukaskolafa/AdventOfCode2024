namespace aoc;

public class Rule
{
    public Rule(string input)
    {
        var parts = input.Split("|");
        
        First = int.Parse(parts[0]);
        Second = int.Parse(parts[1]);
    }
    
    public int First { get; private set; }
    
    public int Second { get; private set; }
}