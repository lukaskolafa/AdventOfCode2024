namespace aoc;

public class Coordinates(int h, int w)
{
    public int H { get; } = h;
    
    public int W { get; } = w;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Coordinates coordinates = (Coordinates) obj;
        return H == coordinates.H && W == coordinates.W;
    }

    public static bool operator ==(Coordinates left, Coordinates right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Coordinates left, Coordinates right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(H, W);
    }
}