using CsharpMatchAnalyzer.Models;

namespace CsharpMatchAnalyzer.Services;

// Calculate normalized match probabilities from team ratings and home advantage.
public static class PredictionCalculator
{
    // Calculate home win, draw, and away win probabilities for one match.
    public static MatchPrediction Calculate(Match match)
    {
        double ratingDifference = match.HomeTeam.Rating - match.AwayTeam.Rating;
        double homeAdvantage = 3.0;
        double homeScore = Math.Exp((ratingDifference + homeAdvantage) / 10.0);
        double awayScore = Math.Exp((-ratingDifference) / 10.0);
        double drawScore = 1.0 + Math.Abs(match.HomeGoals - match.AwayGoals) * 0.05;
        double totalScore = homeScore + drawScore + awayScore;

        return new MatchPrediction(
            match,
            homeScore / totalScore,
            drawScore / totalScore,
            awayScore / totalScore);
    }

    // Convert a probability into decimal betting odds for the report.
    public static double ToDecimalOdds(double probability)
    {
        return probability <= 0 ? 0 : 1 / probability;
    }
}
