using DodgerGameManager.Models;

namespace DodgerGameManager.Services;

/// <summary>
/// Manages all game data with CRUD operations
/// </summary>
public class GameDataService
{
    // Collections to store game entities - demonstrating Lists
    private List<Player> players;
    private List<GameSession> gameSessions;
    private List<Obstacle> obstacles;
    private List<PowerUp> powerUps;

    // ID generators for auto-incrementing IDs
    private int nextPlayerId = 1;
    private int nextSessionId = 1;
    private int nextObstacleId = 1;
    private int nextPowerUpId = 1;

    public GameDataService()
    {
        players = new List<Player>();
        gameSessions = new List<GameSession>();
        obstacles = new List<Obstacle>();
        powerUps = new List<PowerUp>();
    }

    #region Player CRUD Operations

    // CREATE - Add a new player to the system
    public Player CreatePlayer(string playerName)
    {
        var player = new Player
        {
            PlayerId = nextPlayerId++,
            PlayerName = playerName,
            DateRegistered = DateTime.Now,
            LastPlayed = DateTime.Now,
            Rank = "Beginner"
        };
        players.Add(player);
        return player;
    }

    /// <summary>
    /// READ - Get all players
    /// </summary>
    public List<Player> GetAllPlayers() => players;

    /// <summary>
    /// READ - Get a specific player by ID
    /// </summary>
    public Player? GetPlayerById(int playerId)
    {
        return players.FirstOrDefault(p => p.PlayerId == playerId);
    }

    /// <summary>
    /// UPDATE - Modify an existing player
    /// </summary>
    public bool UpdatePlayer(int playerId, Action<Player> updateAction)
    {
        var player = GetPlayerById(playerId);
        if (player == null) return false;

        updateAction(player);
        return true;
    }

    /// <summary>
    /// DELETE - Remove a player from the system
    /// </summary>
    public bool DeletePlayer(int playerId)
    {
        var player = GetPlayerById(playerId);
        if (player == null) return false;

        players.Remove(player);
        // Also remove associated game sessions
        gameSessions.RemoveAll(s => s.PlayerId == playerId);
        return true;
    }

    #endregion

    #region GameSession CRUD Operations

    /// <summary>
    /// CREATE - Add a new game session
    /// </summary>
    public GameSession CreateGameSession(int playerId, string playerName, int score, int level, TimeSpan duration)
    {
        var session = new GameSession
        {
            SessionId = nextSessionId++,
            PlayerId = playerId,
            PlayerName = playerName,
            Score = score,
            Level = level,
            Duration = duration,
            SessionDate = DateTime.Now,
            Difficulty = "Normal"
        };
        gameSessions.Add(session);

        // Update player statistics
        UpdatePlayerStats(playerId, score);

        return session;
    }

    /// <summary>
    /// READ - Get all game sessions
    /// </summary>
    public List<GameSession> GetAllGameSessions() => gameSessions;

    /// <summary>
    /// READ - Get a specific game session by ID
    /// </summary>
    public GameSession? GetGameSessionById(int sessionId)
    {
        return gameSessions.FirstOrDefault(s => s.SessionId == sessionId);
    }

    /// <summary>
    /// READ - Get all sessions for a specific player
    /// </summary>
    public List<GameSession> GetGameSessionsByPlayerId(int playerId)
    {
        return gameSessions.Where(s => s.PlayerId == playerId).ToList();
    }

    /// <summary>
    /// UPDATE - Modify an existing game session
    /// </summary>
    public bool UpdateGameSession(int sessionId, Action<GameSession> updateAction)
    {
        var session = GetGameSessionById(sessionId);
        if (session == null) return false;

        updateAction(session);
        return true;
    }

    /// <summary>
    /// DELETE - Remove a game session
    /// </summary>
    public bool DeleteGameSession(int sessionId)
    {
        var session = GetGameSessionById(sessionId);
        if (session == null) return false;

        gameSessions.Remove(session);
        return true;
    }

    /// <summary>
    /// Helper method to update player statistics after a game
    /// </summary>
    private void UpdatePlayerStats(int playerId, int score)
    {
        var player = GetPlayerById(playerId);
        if (player == null) return;

        player.TotalGamesPlayed++;
        player.TotalScore += score;
        player.LastPlayed = DateTime.Now;

        if (score > player.HighestScore)
        {
            player.HighestScore = score;
        }

        // Update rank based on high score
        player.Rank = score switch
        {
            >= 10000 => "Legend",
            >= 5000 => "Master",
            >= 2500 => "Expert",
            >= 1000 => "Advanced",
            >= 500 => "Intermediate",
            _ => "Beginner"
        };
    }

    #endregion

    #region Obstacle CRUD Operations

    /// <summary>
    /// CREATE - Add a new obstacle
    /// </summary>
    public Obstacle CreateObstacle(string name, string type, double speed, int damage, int size)
    {
        var obstacle = new Obstacle
        {
            ObstacleId = nextObstacleId++,
            ObstacleName = name,
            ObstacleType = type,
            Speed = speed,
            DamagePoints = damage,
            Size = size,
            IsActive = true
        };
        obstacles.Add(obstacle);
        return obstacle;
    }

    /// <summary>
    /// READ - Get all obstacles
    /// </summary>
    public List<Obstacle> GetAllObstacles() => obstacles;

    /// <summary>
    /// READ - Get a specific obstacle by ID
    /// </summary>
    public Obstacle? GetObstacleById(int obstacleId)
    {
        return obstacles.FirstOrDefault(o => o.ObstacleId == obstacleId);
    }

    /// <summary>
    /// UPDATE - Modify an existing obstacle
    /// </summary>
    public bool UpdateObstacle(int obstacleId, Action<Obstacle> updateAction)
    {
        var obstacle = GetObstacleById(obstacleId);
        if (obstacle == null) return false;

        updateAction(obstacle);
        return true;
    }

    /// <summary>
    /// DELETE - Remove an obstacle
    /// </summary>
    public bool DeleteObstacle(int obstacleId)
    {
        var obstacle = GetObstacleById(obstacleId);
        if (obstacle == null) return false;

        obstacles.Remove(obstacle);
        return true;
    }

    #endregion

    #region PowerUp CRUD Operations

    /// <summary>
    /// CREATE - Add a new power-up
    /// </summary>
    public PowerUp CreatePowerUp(string name, string type, string effect, int duration, int pointsValue)
    {
        var powerUp = new PowerUp
        {
            PowerUpId = nextPowerUpId++,
            PowerUpName = name,
            PowerUpType = type,
            Effect = effect,
            DurationSeconds = duration,
            PointsValue = pointsValue,
            IsCollectible = true
        };
        powerUps.Add(powerUp);
        return powerUp;
    }

    /// <summary>
    /// READ - Get all power-ups
    /// </summary>
    public List<PowerUp> GetAllPowerUps() => powerUps;

    /// <summary>
    /// READ - Get a specific power-up by ID
    /// </summary>
    public PowerUp? GetPowerUpById(int powerUpId)
    {
        return powerUps.FirstOrDefault(p => p.PowerUpId == powerUpId);
    }

    /// <summary>
    /// UPDATE - Modify an existing power-up
    /// </summary>
    public bool UpdatePowerUp(int powerUpId, Action<PowerUp> updateAction)
    {
        var powerUp = GetPowerUpById(powerUpId);
        if (powerUp == null) return false;

        updateAction(powerUp);
        return true;
    }

    /// <summary>
    /// DELETE - Remove a power-up
    /// </summary>
    public bool DeletePowerUp(int powerUpId)
    {
        var powerUp = GetPowerUpById(powerUpId);
        if (powerUp == null) return false;

        powerUps.Remove(powerUp);
        return true;
    }

    #endregion

    #region Data Statistics

    public int GetTotalPlayers() => players.Count;
    public int GetTotalGameSessions() => gameSessions.Count;
    public int GetTotalObstacles() => obstacles.Count;
    public int GetTotalPowerUps() => powerUps.Count;

    public void ClearAllData()
    {
        players.Clear();
        gameSessions.Clear();
        obstacles.Clear();
        powerUps.Clear();
        
        nextPlayerId = 1;
        nextSessionId = 1;
        nextObstacleId = 1;
        nextPowerUpId = 1;
    }

    #endregion
}
