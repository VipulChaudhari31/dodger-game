namespace DodgerGameManager.Models;

// Represents obstacles (meteors) in the game
public record Obstacle
{
    public int ObstacleId { get; init; }
    public string ObstacleName { get; set; }
    public string ObstacleType { get; set; }
    public double Speed { get; set; }
    public int DamagePoints { get; set; }
    public int Size { get; set; }
    public string Color { get; set; }
    public int PointsOnDodge { get; set; }
    public bool IsActive { get; set; }

    public Obstacle()
    {
        ObstacleId = 0;
        ObstacleName = string.Empty;
        ObstacleType = "Meteor";
        Speed = 2.0;
        DamagePoints = 100;
        Size = 20;
        Color = "Red";
        PointsOnDodge = 10;
        IsActive = true;
    }

    public override string ToString()
    {
        return $"[{ObstacleId}] {ObstacleName} ({ObstacleType}) - Speed: {Speed} | Size: {Size} | Damage: {DamagePoints} | Points: {PointsOnDodge}";
    }
}
