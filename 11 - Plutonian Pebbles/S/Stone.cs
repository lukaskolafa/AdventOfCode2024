namespace aoc;

public class Stone(string value)
{
    public long Value { get; private set; } = long.Parse(value);
    
    public Stone? NextStone { get; set; } = null;

    public void Blink()
    {
        var previousNextStone = NextStone;
        
        if (Value == 0)
        {
            Value = 1;
            
        }
        else
        {
            string strval = Value.ToString();

            if (strval.Length % 2 == 0)
            {
                string val1 = strval.Substring(0, strval.Length / 2);
                string val2 = strval.Substring(strval.Length / 2);

                Value = long.Parse(val1);

                NextStone = new Stone(val2)
                {
                    NextStone = previousNextStone
                };
            }
            else
            {
                Value *= 2024;
            }
        }
    }
}