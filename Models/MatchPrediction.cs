namespace CsharpMatchAnalyzer.Models;

// A value type containing normalized probabilities for one match.
public readonly struct MatchPrediction
{
    public Match Match { get; }
    public double HomeWinProbability { get; }
    public double DrawProbability { get; }
    public double AwayWinProbability { get; }
    public string MostLikelyResult { get; }
    public double MostLikelyProbability { get; }

    // Create a prediction and identify the result with the highest probability.
    public MatchPrediction(
        Match match,
        double homeWinProbability,
        double drawProbability,
        double awayWinProbability)
    {
        Match = match;
        HomeWinProbability = homeWinProbability;
        DrawProbability = drawProbability;
        AwayWinProbability = awayWinProbability;

        (MostLikelyResult, MostLikelyProbability) = FindMostLikelyResult(
            homeWinProbability,
            drawProbability,
            awayWinProbability);
    }

    // Return the result label and probability with the greatest value.
    private static (string Result, double Probability) FindMostLikelyResult(
        double homeWinProbability,
        double drawProbability,
        double awayWinProbability)
    {
        var outcomes = new Dictionary<string, double>
        {
            ["Home win"] = homeWinProbability,
            ["Draw"] = drawProbability,
            ["Away win"] = awayWinProbability
        };

        KeyValuePair<string, double> result = outcomes.MaxBy(outcome => outcome.Value);
        return (result.Key, result.Value);
    }
}
