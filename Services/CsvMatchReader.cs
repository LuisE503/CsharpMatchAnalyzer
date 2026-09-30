using CsharpMatchAnalyzer.Models;

namespace CsharpMatchAnalyzer.Services;

// Read match history from a simple comma-separated values file.
public static class CsvMatchReader
{
    // Load valid match records while reporting malformed rows clearly.
    public static List<Match> LoadMatches(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Could not find the input file: {path}");
        }

        string[] lines = File.ReadAllLines(path);
        var matches = new List<Match>();

        foreach (string line in lines.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] columns = line.Split(',');
            if (columns.Length != 6)
            {
                throw new FormatException($"Expected 6 columns but found {columns.Length}: {line}");
            }

            matches.Add(ParseMatch(columns, line));
        }

        return matches;
    }

    // Convert one CSV row into Team and Match objects.
    private static Match ParseMatch(string[] columns, string sourceLine)
    {
        if (!int.TryParse(columns[2], out int homeGoals) ||
            !int.TryParse(columns[3], out int awayGoals) ||
            !double.TryParse(columns[4], out double homeRating) ||
            !double.TryParse(columns[5], out double awayRating))
        {
            throw new FormatException($"Could not parse numeric values: {sourceLine}");
        }

        var homeTeam = new Team(columns[0], homeRating);
        var awayTeam = new Team(columns[1], awayRating);
        return new Match(homeTeam, awayTeam, homeGoals, awayGoals);
    }
}
