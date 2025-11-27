namespace DodgerGameManager.Models;

/// <summary>
/// Represents power-ups that players can collect in the game
/// Demonstrates: Game item management
/// Learning Outcome: Creating Records and Data Structures
/// </summary>
public class PowerUp
{
    public int PowerUpId { get; set; }
    public string PowerUpName { get; set; }
    public string PowerUpType { get; set; }
    public int DurationSeconds { get; set; }
    public int PointsValue { get; set; }
    public string Effect { get; set; }
    public double SpawnRate { get; set; }
    public string Rarity { get; set; }
    public bool IsCollectible { get; set; }

    public PowerUp()
    {
        PowerUpId = 0;
        PowerUpName = string.Empty;
        PowerUpType = "Bonus";
        DurationSeconds = 5;
        PointsValue = 100;
        Effect = "Score Boost";
        SpawnRate = 0.1;
        Rarity = "Common";
        IsCollectible = true;
    }

    public override string ToString()
    {
        return $"[{PowerUpId}] {PowerUpName} ({PowerUpType}) - Effect: {Effect} | Duration: {DurationSeconds}s | Value: {PointsValue} | Rarity: {Rarity}";
    }
}
