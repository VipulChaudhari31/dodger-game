using DodgerGameManager.Models;
using DodgerGameManager.Services;

namespace DodgerGameManager;

/// <summary>
/// Dodger Game Data Management System
/// Sprint 2: CRUD Operations Implementation
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║   DODGER GAME DATA MANAGEMENT SYSTEM - Sprint 2  ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");

        Console.WriteLine("Sprint 2: CRUD Operations Implementation\n");
        Console.WriteLine("Learning Outcomes Demonstrated:");
        Console.WriteLine("✓ Understanding Data Management");
        Console.WriteLine("✓ Using Arrays and Lists");
        Console.WriteLine("✓ Implementing CRUD Operations\n");

        // Demonstrate CRUD operations
        DemonstrateCRUDOperations();
    }


    static void DemonstrateCRUDOperations()
    {
        var dataService = new GameDataService();

        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║            CRUD OPERATIONS DEMONSTRATION               ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

        // ============ CREATE Operations ============
        Console.WriteLine("--- CREATE Operations ---\n");
        
        Console.WriteLine("Creating Players...");
        var player1 = dataService.CreatePlayer("SpaceAce");
        var player2 = dataService.CreatePlayer("MeteorMaster");
        var player3 = dataService.CreatePlayer("StarNavigator");
        Console.WriteLine($"✓ Created {dataService.GetTotalPlayers()} players\n");

        Console.WriteLine("Creating Obstacles...");
        var obstacle1 = dataService.CreateObstacle("Red Meteor", "Meteor", 3.5, 100, 25);
        var obstacle2 = dataService.CreateObstacle("Blue Comet", "Comet", 4.0, 120, 30);
        Console.WriteLine($"✓ Created {dataService.GetTotalObstacles()} obstacles\n");

        Console.WriteLine("Creating Power-ups...");
        var powerUp1 = dataService.CreatePowerUp("Shield Boost", "Defensive", "Temporary Shield", 10, 200);
        var powerUp2 = dataService.CreatePowerUp("Speed Burst", "Offensive", "Increased Speed", 5, 150);
        Console.WriteLine($"✓ Created {dataService.GetTotalPowerUps()} power-ups\n");

        Console.WriteLine("Creating Game Sessions...");
        var session1 = dataService.CreateGameSession(player1.PlayerId, player1.PlayerName, 2500, 3, TimeSpan.FromMinutes(3));
        var session2 = dataService.CreateGameSession(player2.PlayerId, player2.PlayerName, 5500, 6, TimeSpan.FromMinutes(7));
        Console.WriteLine($"✓ Created {dataService.GetTotalGameSessions()} game sessions\n");

        // ============ READ Operations ============
        Console.WriteLine("--- READ Operations ---\n");
        
        Console.WriteLine("All Players:");
        foreach (var player in dataService.GetAllPlayers())
        {
            Console.WriteLine($"  {player}");
        }
        Console.WriteLine();

        Console.WriteLine("All Obstacles:");
        foreach (var obstacle in dataService.GetAllObstacles())
        {
            Console.WriteLine($"  {obstacle}");
        }
        Console.WriteLine();

        Console.WriteLine("All Power-ups:");
        foreach (var powerUp in dataService.GetAllPowerUps())
        {
            Console.WriteLine($"  {powerUp}");
        }
        Console.WriteLine();

        Console.WriteLine("All Game Sessions:");
        foreach (var session in dataService.GetAllGameSessions())
        {
            Console.WriteLine($"  {session}");
        }
        Console.WriteLine();

        Console.WriteLine($"Getting Player by ID (ID: {player1.PlayerId}):");
        var foundPlayer = dataService.GetPlayerById(player1.PlayerId);
        Console.WriteLine($"  {foundPlayer}\n");

        Console.WriteLine($"Getting Sessions for Player '{player2.PlayerName}':");
        var playerSessions = dataService.GetGameSessionsByPlayerId(player2.PlayerId);
        foreach (var session in playerSessions)
        {
            Console.WriteLine($"  {session}");
        }
        Console.WriteLine();

        // ============ UPDATE Operations ============
        Console.WriteLine("--- UPDATE Operations ---\n");
        
        Console.WriteLine($"Updating Player '{player3.PlayerName}'...");
        Console.WriteLine($"  Before: {dataService.GetPlayerById(player3.PlayerId)}");
        
        dataService.UpdatePlayer(player3.PlayerId, p =>
        {
            p.HighestScore = 8000;
            p.TotalGamesPlayed = 15;
            p.TotalScore = 45000;
            p.Rank = "Master";
        });
        
        Console.WriteLine($"  After:  {dataService.GetPlayerById(player3.PlayerId)}\n");

        Console.WriteLine($"Updating Obstacle '{obstacle1.ObstacleName}'...");
        Console.WriteLine($"  Before: {dataService.GetObstacleById(obstacle1.ObstacleId)}");
        
        dataService.UpdateObstacle(obstacle1.ObstacleId, o =>
        {
            o.Speed = 5.0;
            o.DamagePoints = 150;
            o.Color = "Dark Red";
        });
        
        Console.WriteLine($"  After:  {dataService.GetObstacleById(obstacle1.ObstacleId)}\n");

        Console.WriteLine($"Updating Power-up '{powerUp1.PowerUpName}'...");
        Console.WriteLine($"  Before: {dataService.GetPowerUpById(powerUp1.PowerUpId)}");
        
        dataService.UpdatePowerUp(powerUp1.PowerUpId, p =>
        {
            p.DurationSeconds = 15;
            p.PointsValue = 300;
            p.Rarity = "Epic";
        });
        
        Console.WriteLine($"  After:  {dataService.GetPowerUpById(powerUp1.PowerUpId)}\n");

        // ============ DELETE Operations ============
        Console.WriteLine("--- DELETE Operations ---\n");
        
        Console.WriteLine($"Total Power-ups before deletion: {dataService.GetTotalPowerUps()}");
        Console.WriteLine($"Deleting Power-up ID {powerUp2.PowerUpId}...");
        bool deleted = dataService.DeletePowerUp(powerUp2.PowerUpId);
        Console.WriteLine($"✓ Deletion successful: {deleted}");
        Console.WriteLine($"Total Power-ups after deletion: {dataService.GetTotalPowerUps()}\n");

        // ============ Summary ============
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    DATA SUMMARY                        ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");
        Console.WriteLine($"Total Players:       {dataService.GetTotalPlayers()}");
        Console.WriteLine($"Total Obstacles:     {dataService.GetTotalObstacles()}");
        Console.WriteLine($"Total Power-ups:     {dataService.GetTotalPowerUps()}");
        Console.WriteLine($"Total Game Sessions: {dataService.GetTotalGameSessions()}\n");

        Console.WriteLine("✓ All CRUD operations completed successfully!");
        Console.WriteLine("\nReady for Sprint 3: Random Data Generation");
    }
}
