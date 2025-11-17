const canvas = document.getElementById("gameCanvas");
const ctx = canvas.getContext("2d");

const scoreDisplay = document.getElementById("score");
const highScoreDisplay = document.getElementById("highScore");

let player, obstacles, score, highScore, gameOver;

const PLAYER_SIZE = 20;
const OBSTACLE_WIDTH = 20;
const OBSTACLE_HEIGHT = 20;

let keys = {};

document.addEventListener("keydown", e => keys[e.key] = true);
document.addEventListener("keyup", e => keys[e.key] = false);

document.getElementById("restartBtn").onclick = startGame;

// -----------------------
//  Game Initialization
// -----------------------
function startGame() {
    player = {
        x: canvas.width / 2 - PLAYER_SIZE / 2,
        y: canvas.height - 50,
        speed: 4,
        size: PLAYER_SIZE
    };

    obstacles = [];
    score = 0;
    gameOver = false;

    highScore = localStorage.getItem("dodgerHighScore") || 0;
    highScoreDisplay.textContent = highScore;

    requestAnimationFrame(update);
}

// -----------------------
//  Spawning Obstacles
// -----------------------
function spawnObstacle() {
    obstacles.push({
        x: Math.random() * (canvas.width - OBSTACLE_WIDTH),
        y: -OBSTACLE_HEIGHT,
        speed: 2 + Math.random() * 3
    });
}

// -----------------------
//  Player Movement
// -----------------------
function movePlayer() {
    if (keys["ArrowLeft"] && player.x > 0) {
        player.x -= player.speed;
    }
    if (keys["ArrowRight"] && player.x < canvas.width - player.size) {
        player.x += player.speed;
    }
    if (keys["ArrowUp"] && player.y > 0) {
        player.y -= player.speed;
    }
    if (keys["ArrowDown"] && player.y < canvas.height - player.size) {
        player.y += player.speed;
    }
}

// -----------------------
//  Collision Detection
// -----------------------
function checkCollision(a, b) {
    return (
        a.x < b.x + OBSTACLE_WIDTH &&
        a.x + a.size > b.x &&
        a.y < b.y + OBSTACLE_HEIGHT &&
        a.y + a.size > b.y
    );
}

// -----------------------
//  Game Loop
// -----------------------
let spawnTimer = 0;

function update() {
    if (gameOver) return;

    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // Player movement
    movePlayer();

    // Draw player
    ctx.fillStyle = "#00e676";
    ctx.fillRect(player.x, player.y, player.size, player.size);

    // Obstacle spawning
    spawnTimer++;
    if (spawnTimer > 45) { 
        spawnObstacle();
        spawnTimer = 0;
    }

    // Move and draw obstacles
    ctx.fillStyle = "#ff1744";
    for (let i = obstacles.length - 1; i >= 0; i--) {
        let o = obstacles[i];
        o.y += o.speed;

        ctx.fillRect(o.x, o.y, OBSTACLE_WIDTH, OBSTACLE_HEIGHT);

        // Remove off-screen obstacles
        if (o.y > canvas.height) obstacles.splice(i, 1);

        // Check collision
        if (checkCollision(player, o)) {
            gameOver = true;
            handleGameOver();
        }
    }

    // Update score
    score++;
    scoreDisplay.textContent = score;

    requestAnimationFrame(update);
}

// -----------------------
//  Game Over Handling
// -----------------------
function handleGameOver() {
    ctx.fillStyle = "rgba(0,0,0,0.6)";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    ctx.fillStyle = "white";
    ctx.font = "30px Arial";
    ctx.textAlign = "center";
    ctx.fillText("GAME OVER", canvas.width / 2, canvas.height / 2);

    if (score > highScore) {
        localStorage.setItem("dodgerHighScore", score);
        highScoreDisplay.textContent = score;
    }
}

// Start game
startGame();
