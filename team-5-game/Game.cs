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
            sprite.bgPosition = new Vector2(0,0);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            sprite.DrawBackground();
            sprite.DrawPlayer();
            sprite.DrawAsteroid();
            
            Window.ClearBackground(Color.Black);
        }
    }
}
