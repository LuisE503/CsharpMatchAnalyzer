namespace CsharpMatchAnalyzer.Models;

// Store the teams and historical score from one match record.
public class Match
{
    public Team HomeTeam { get; }
    public Team AwayTeam { get; }
    public int HomeGoals { get; }
    public int AwayGoals { get; }

    // Create a match record used by the analyzer and report writer.
    public Match(Team homeTeam, Team awayTeam, int homeGoals, int awayGoals)
    {
        if (homeGoals < 0 || awayGoals < 0)
        {
            throw new ArgumentException("Goals cannot be negative.");
        }

        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeGoals = homeGoals;
        AwayGoals = awayGoals;
    }
}
