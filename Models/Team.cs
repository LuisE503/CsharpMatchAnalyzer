namespace CsharpMatchAnalyzer.Models;

// Represent a team and the rating used by the probability calculation.
public class Team
{
    public string Name { get; }
    public double Rating { get; }

    // Create a team with a validated name and numeric rating.
    public Team(string name, double rating)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Team name cannot be empty.", nameof(name));
        }

        Name = name.Trim();
        Rating = rating;
    }
}
