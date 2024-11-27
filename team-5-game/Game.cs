// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Enemy[] enemies = new Enemy[10];
        Collision collisionChecker = new Collision();
        Score score = new Score();
        int numOfActiveEnemies;
        int spawnChance;
        bool enemyHasBeenHit;

        Player player = new Player();

        Sprites sprite = new Sprites();

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Asteroids");
            Window.SetSize(600, 600);

            sprite.playerPosition = new Vector2(10, 10);
            sprite.asteroidPosition = new Vector2(100, 100);
            sprite.bgPosition = new Vector2(0, 0);

            // Initializes the enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Enemy();
            }
            numOfActiveEnemies = 0;
            spawnChance = 10;
            score.position = new Vector2(5, Window.Height - 25);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            player.UpdatePlayer();

            // Handles the spawning of random enemies so they don't all spawn at once
            if (numOfActiveEnemies <= 10)
            {
                int randomEnemyNumber = Random.Integer(0, enemies.Length * spawnChance);

                if (randomEnemyNumber < enemies.Length && enemies[randomEnemyNumber].isActive == false)
                {
                    enemies[randomEnemyNumber].Spawn();
                    numOfActiveEnemies++;
                }
            }

            // Handles the enemy movement and rendering
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Move();
                enemyHasBeenHit = false;
                /*
                 * Update the max amount of enemies on screen when one goes off screen or is destroyed
                 * Also stops the enemy from moving
                 */
                // Detects if the bullet has collided with the enemy
                if (collisionChecker.IsPointInRectangle(player.BulletPosition, enemies[i].position, enemies[i].size, enemies[i].size))
                {
                    score.AddScore(20); // Gain points for destroying the enemy
                    enemyHasBeenHit = true;
                }
                // Detects if the player has collided with the enemy
                else if (collisionChecker.IsRectangleInRectangle(player.playerPosition, 20, 20, enemies[i].position, enemies[i].size, enemies[i].size)) 
                {
                    score.RemoveScore(50); // Lose points for being hit
                    enemyHasBeenHit = true;
                }
                // Detects if the enemy has gone off screen
                else if (enemies[i].IsOffScreen()) 
                {
                    score.AddScore(5); // Gain points for dodging the enemy
                    enemyHasBeenHit= true;
                }

                // Destroy enemy if it has been hit or gone off screen this frame
                if (enemyHasBeenHit)
                {
                    enemies[i].SetDirection(Vector2.Zero);
                    enemies[i].SetOffScreen(false);
                    enemies[i].isActive = false;
                    numOfActiveEnemies--;
                }

                sprite.DrawAsteroid(enemies[i].position);
            }

            // Display the score to the screen
            score.DisplayScore();
        }
    }
}
