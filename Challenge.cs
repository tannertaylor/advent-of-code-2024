namespace AdventOfCode;

public abstract class Challenge
{
    public abstract int Day { get; }

    public abstract void Run(string[] inputLines);
}
