namespace DodgerGameManager.Models;

// Represents a player in the dodger game system
public record Player
{
    public int PlayerId { get; init; }
    public string PlayerName { get; set; }
    public int TotalGamesPlayed { get; set; }
    public int HighestScore { get; set; }
    public int TotalScore { get; set; }
    public DateTime DateRegistered { get; init; }
    public DateTime LastPlayed { get; set; }
    public string Rank { get; set; }

    public Player()
    {
        PlayerId = 0;
        PlayerName = string.Empty;
        TotalGamesPlayed = 0;
        HighestScore = 0;
        TotalScore = 0;
        DateRegistered = DateTime.Now;
        LastPlayed = DateTime.Now;
        Rank = "Beginner";
    }

    public double GetAverageScore()
    {
        return TotalGamesPlayed > 0 ? (double)TotalScore / TotalGamesPlayed : 0;
    }

    public override string ToString()
    {
        return $"[{PlayerId}] {PlayerName} - Rank: {Rank} | High Score: {HighestScore} | Avg: {GetAverageScore():F2} | Games: {TotalGamesPlayed}";
    }
}
