namespace aoc;

public class Challenge(long[] input, long expectedResult)
{
    private long[] Input { get; } = input;

    private long ExpectedResult { get; } = expectedResult;

    public Result Solve()
    {
        if (Input.Length == 0)
        {
            throw new Exception("Something went wrong");
        }
        
        long currentElement = Input.Last();

        if (Input.Length == 1)
        {
            return currentElement == ExpectedResult ? Result.Success : Result.Fail;
        }
        
        bool canDivide = ExpectedResult % currentElement == 0;
        bool canSubtract = ExpectedResult - currentElement > 0;
        
        if (!canDivide && !canSubtract)
        {
            return Result.Fail;
        }
        
        long[] nextStepInput = new long[Input.Length - 1];
        Array.Copy(Input, nextStepInput, Input.Length - 1);

        if (canDivide)
        {
            var challengeDivide = new Challenge(nextStepInput, ExpectedResult / currentElement);
            
            if (challengeDivide.Solve() == Result.Success)
            {
                return Result.Success;
            }
        }

        if (canSubtract)
        {
            var challengeSubtract = new Challenge(nextStepInput, ExpectedResult - currentElement);

            if (challengeSubtract.Solve() == Result.Success)
            {
                return Result.Success;
            }
        }
        
        return Result.Fail;
    }
    
    public enum Result
    {
        Fail,
        Success,
    }
}