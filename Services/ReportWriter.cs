using System.Text;
using CsharpMatchAnalyzer.Models;

namespace CsharpMatchAnalyzer.Services;

// Format predictions and persist the analysis as a text report.
public static class ReportWriter
{
    // Create the output folder and write all calculated probabilities and odds.
    public static void Write(string path, IEnumerable<MatchPrediction> predictions)
    {
        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var report = new StringBuilder();
        report.AppendLine("MATCH PROBABILITY ANALYSIS");
        report.AppendLine("==========================");
        report.AppendLine();

        foreach (MatchPrediction prediction in predictions)
        {
            report.AppendLine($"{prediction.Match.HomeTeam.Name} vs {prediction.Match.AwayTeam.Name}");
            report.AppendLine($"Home win: {prediction.HomeWinProbability:P2} (odds {PredictionCalculator.ToDecimalOdds(prediction.HomeWinProbability):F2})");
            report.AppendLine($"Draw: {prediction.DrawProbability:P2} (odds {PredictionCalculator.ToDecimalOdds(prediction.DrawProbability):F2})");
            report.AppendLine($"Away win: {prediction.AwayWinProbability:P2} (odds {PredictionCalculator.ToDecimalOdds(prediction.AwayWinProbability):F2})");
            report.AppendLine($"Most likely result: {prediction.MostLikelyResult}");
            report.AppendLine(new string('-', 40));
        }

        File.WriteAllText(path, report.ToString());
    }
}
