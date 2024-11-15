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
        Enemy enemy = new Enemy();

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Asteroids");
            Window.SetSize(600, 600);

            enemy.Spawn();
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            if (Input.IsKeyboardKeyPressed(KeyboardInput.G))
            {
                enemy.Spawn();
            }

            enemy.Move();
            enemy.Render();
        }
    }
}
