namespace AdventOfCode.Challenges;

public sealed class Day01 : Challenge
{
    public override int Day { get; } = 1;

    public override void Run(string[] inputLines)
    {
        var splits = inputLines
          .Select(x => x.Trim().Split("   "))
          .Select(x => (Left: x[0], Right: x[1]));

        var left = splits.Select(x => int.Parse(x.Left)).Order();
        var right = splits.Select(x => int.Parse(x.Right)).Order();

        var diffSum = left.Zip(right).Sum(x => Math.Abs(x.First - x.Second));
        Console.WriteLine($"Total Difference: {diffSum}");

        var similaritySum = left.Sum(x => x * right.Count(y => x == y));
        Console.WriteLine($"Similarity Sum: {similaritySum}");
    }
}

