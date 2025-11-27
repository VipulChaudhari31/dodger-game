namespace DodgerGameManager.Models;

/// <summary>
/// Represents a single game session with detailed statistics
/// Demonstrates: Complex data structures and relationships
/// Learning Outcome: Creating Records and Data Structures
/// </summary>
public class GameSession
{
    public int SessionId { get; set; }
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public int Level { get; set; }
    public DateTime SessionDate { get; set; }
    public TimeSpan Duration { get; set; }
    public int ObstaclesDodged { get; set; }
    public int PowerUpsCollected { get; set; }
    public bool NewHighScore { get; set; }
    public string Difficulty { get; set; }

    public GameSession()
    {
        SessionId = 0;
        PlayerId = 0;
        PlayerName = string.Empty;
        Score = 0;
        Level = 1;
        SessionDate = DateTime.Now;
        Duration = TimeSpan.Zero;
        ObstaclesDodged = 0;
        PowerUpsCollected = 0;
        NewHighScore = false;
        Difficulty = "Normal";
    }

    public double GetScorePerMinute()
    {
        return Duration.TotalMinutes > 0 ? Score / Duration.TotalMinutes : 0;
    }

    public override string ToString()
    {
        return $"Session #{SessionId} | Player: {PlayerName} | Score: {Score} | Level: {Level} | Duration: {Duration:mm\\:ss} | Date: {SessionDate:yyyy-MM-dd}";
    }
}
