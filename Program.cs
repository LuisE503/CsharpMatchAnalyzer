using CsharpMatchAnalyzer.Models;
using CsharpMatchAnalyzer.Services;

string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
string inputPath = Path.Combine(projectDirectory, "data", "matches.csv");
string outputPath = Path.Combine(projectDirectory, "output", "match-probabilities.txt");

Console.WriteLine("C# Match Probability Analyzer");
Console.WriteLine("=============================");

try
{
	List<Match> matches = CsvMatchReader.LoadMatches(inputPath);
	List<MatchPrediction> predictions = matches
		.Select(PredictionCalculator.Calculate)
		.ToList();

	ReportWriter.Write(outputPath, predictions);
	DisplaySummary(predictions, outputPath);
}
catch (FileNotFoundException exception)
{
	Console.WriteLine($"Input file error: {exception.Message}");
}
catch (FormatException exception)
{
	Console.WriteLine($"CSV format error: {exception.Message}");
}
catch (IOException exception)
{
	Console.WriteLine($"File operation error: {exception.Message}");
}

// Display the results that were calculated and saved by the program.
static void DisplaySummary(List<MatchPrediction> predictions, string outputPath)
{
	Console.WriteLine($"Processed matches: {predictions.Count}");
	Console.WriteLine($"Results written to: {outputPath}");
	Console.WriteLine();

	foreach (MatchPrediction prediction in predictions)
	{
		Console.WriteLine(
			$"{prediction.Match.HomeTeam.Name} vs {prediction.Match.AwayTeam.Name}: " +
			$"{prediction.MostLikelyResult} ({prediction.MostLikelyProbability:P1})");
	}
}
