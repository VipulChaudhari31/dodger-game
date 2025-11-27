using DodgerGameManager.Models;

namespace DodgerGameManager;

/// <summary>
/// Dodger Game Data Management System
/// Sprint 1: Data Models Implementation
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║   DODGER GAME DATA MANAGEMENT SYSTEM - Sprint 1  ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");

        Console.WriteLine("Sprint 1: Data Models Created Successfully!\n");
        Console.WriteLine("Learning Outcomes Demonstrated:");
        Console.WriteLine("✓ Introduction to Console Applications");
        Console.WriteLine("✓ Creating Records and Data Structures\n");

        // Demonstrate data models
        DemonstrateDataModels();
    }

    static void DemonstrateDataModels()
    {
        Console.WriteLine("--- Data Models Demonstration ---\n");

        // Create sample Player
        var player = new Player
        {
            PlayerId = 1,
            PlayerName = "SpaceAce",
            HighestScore = 5000,
            TotalGamesPlayed = 10,
            TotalScore = 35000,
            Rank = "Expert"
        };
        Console.WriteLine("Player Model:");
        Console.WriteLine(player);
        Console.WriteLine();

        // Create sample GameSession
        var session = new GameSession
        {
            SessionId = 1,
            PlayerId = 1,
            PlayerName = "SpaceAce",
            Score = 5000,
            Level = 6,
            Duration = new TimeSpan(0, 5, 30),
            ObstaclesDodged = 250,
            PowerUpsCollected = 5
        };
        Console.WriteLine("GameSession Model:");
        Console.WriteLine(session);
        Console.WriteLine();

        // Create sample Obstacle
        var obstacle = new Obstacle
        {
            ObstacleId = 1,
            ObstacleName = "Red Meteor",
            ObstacleType = "Meteor",
            Speed = 3.5,
            DamagePoints = 100,
            Size = 25
        };
        Console.WriteLine("Obstacle Model:");
        Console.WriteLine(obstacle);
        Console.WriteLine();

        // Create sample PowerUp
        var powerUp = new PowerUp
        {
            PowerUpId = 1,
            PowerUpName = "Shield Boost",
            PowerUpType = "Defensive",
            Effect = "Temporary Shield",
            DurationSeconds = 10,
            PointsValue = 200,
            Rarity = "Rare"
        };
        Console.WriteLine("PowerUp Model:");
        Console.WriteLine(powerUp);
        Console.WriteLine();

        Console.WriteLine("✓ All data models are working correctly!");
        Console.WriteLine("\nReady for Sprint 2: CRUD Operations");
    }
}
