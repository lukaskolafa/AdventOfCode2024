namespace aoc;

public class Stone(string value, long count)
{
    public long Value { get; } = long.Parse(value);
    
    public long Count { get; set; } = count;

    public Stone[] Blink()
    {
        if (Value == 0)
        {
            return [new Stone("1", Count)];
        }

        string strval = Value.ToString();

        if (strval.Length % 2 == 0)
        {
            string val1 = strval.Substring(0, strval.Length / 2);
            string val2 = strval.Substring(strval.Length / 2);

            return [new Stone(val1, Count), new Stone(val2, Count)];
        }

        return [new Stone($"{Value * 2024}", Count)];
    }
}