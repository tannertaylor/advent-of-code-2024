using AdventOfCode;

Console.WriteLine("Advent of Code 2024");

if (args.Length != 1)
    throw new InvalidOperationException("Expected one and only one argument: the day for which to run the challenge.");

if (!int.TryParse(args[0], out var day))
  throw new InvalidOperationException("Argument must be an integer.");

var assembly = typeof(Program).Assembly;
var challengeTypes = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(Challenge)) && !x.IsAbstract);
var challenges = challengeTypes.Select(x => Activator.CreateInstance(x)).OfType<Challenge>();
var targetChallenge = challenges.FirstOrDefault(x => x.Day == day);

if (targetChallenge is null)
  throw new InvalidOperationException($"Could not locate challenge for day {day}.");

var inputName = $"{targetChallenge.GetType().Name}Input.txt";
var inputResourceStream = assembly.GetManifestResourceStream($"AdventOfCode.Inputs.{inputName}")!;
using var inputResourceStreamReader = new StreamReader(inputResourceStream);
var input = inputResourceStreamReader.ReadToEnd().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine($"Running challenge for day {day}.");
targetChallenge.Run(input);

