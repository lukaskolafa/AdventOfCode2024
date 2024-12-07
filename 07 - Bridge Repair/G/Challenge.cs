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

        if (Input.Length == 1)
        {
            return Input[0] == ExpectedResult ? Result.Success : Result.Fail;
        }

        if (Input[0] > ExpectedResult)
        {
            return Result.Fail;
        }
        
        {
            long[] nextStepInput = new long[Input.Length - 1];
            Array.Copy(Input, 1, nextStepInput, 0, Input.Length - 1);
            nextStepInput[0] *= Input[0];
            
            var challengeDivide = new Challenge(nextStepInput, ExpectedResult);
            
            if (challengeDivide.Solve() == Result.Success)
            {
                return Result.Success;
            }
        }

        {
            long[] nextStepInput = new long[Input.Length - 1];
            Array.Copy(Input, 1, nextStepInput, 0, Input.Length - 1);
            nextStepInput[0] += Input[0];
            
            var challengeSubtract = new Challenge(nextStepInput, ExpectedResult);

            if (challengeSubtract.Solve() == Result.Success)
            {
                return Result.Success;
            }
        }

        {
            long[] nextStepInput = new long[Input.Length - 1];
            Array.Copy(Input, 1, nextStepInput, 0, Input.Length - 1);
            nextStepInput[0] = long.Parse($"{Input[0]}{nextStepInput[0]}");
            var challengeConnect = new Challenge(nextStepInput, ExpectedResult);

            if (challengeConnect.Solve() == Result.Success)
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