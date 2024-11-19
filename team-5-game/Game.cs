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
        int numOfActiveEnemies;
        int spawnChance;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Asteroids");
            Window.SetSize(600, 600);

            // Initializes the enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Enemy();
            }
            numOfActiveEnemies = 0;
            spawnChance = 10;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);

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

                // Update the max amount of enemies on screen when one goes off screen
                // Also stops the offscreen enemy from moving
                if (enemies[i].IsOffScreen())
                {
                    enemies[i].SetDirection(Vector2.Zero);
                    enemies[i].SetOffScreen(false);
                    enemies[i].isActive = false;
                    numOfActiveEnemies--;
                }

                enemies[i].Render();
            }
        }
    }
}
