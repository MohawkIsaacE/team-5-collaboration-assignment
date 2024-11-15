using Raylib_cs;
using System;
using System.Numerics;

namespace Game10003
{
    public class Enemy
    {
        // Variables
        Vector2 position;
        Vector2 direction;
        float speed = 200;
        float size = 20;
        bool isActive;
        Color color = Color.OffWhite; // If no image
        Image image; // If no colour

        float leftSide, rightSide, topSide, bottomSide;

        /// <summary>
        ///     Determines where to spawn the enemy
        /// </summary>
        public void Spawn()
        {
            int randomSide;
            // Create a random direction for the enemy to move
            direction = Random.Direction();
            Console.WriteLine($"{direction.X}x {direction.Y}y");
            // Randomize where the enemy should start from
            randomSide = Random.Integer(1, 3);
            /* 
            Determine where to spawn the enemy based on the direction it's going to move
            Direction positive X, positive Y will spawn somewhere top left
            Direction positive X, negative Y will spawn somewhere bottom left
            Direction negative X, positive Y will spawn somewhere top right
            Direction negative X, negative Y will spawn somewhere bottom right
            */
            if (direction.X >= 0 && direction.Y >= 0)
            {
                if (randomSide == 0) position = new Vector2(Random.Float(-size, Window.Width / 2), 0);
                else position = new Vector2(0, Random.Float(-size, Window.Height / 2));
                Console.WriteLine("here1");
            }
            else if (direction.X >= 0 && direction.Y < 0)
            {
                if (randomSide == 0) position = new Vector2(Random.Float(-size, Window.Width - size), Window.Height + size);
                else position = new Vector2(-size, Random.Float(Window.Height - size, -size));
                Console.WriteLine("here2");
            }
            else if (direction.X < 0 && direction.Y >= 0)
            {
                if (randomSide == 0) position = new Vector2(Random.Float(Window.Width / 2, Window.Width + size), 0);
                else position = new Vector2(Window.Width + size, Random.Float(-size, Window.Height / 2));
                Console.WriteLine("here3");
            }
            else if (direction.X < 0 && direction.Y < 0)
            {
                if (randomSide == 0) position = new Vector2(Random.Float(Window.Width / 2, Window.Width + size), Window.Height + size);
                else position = new Vector2(Window.Width + size, Random.Float(Window.Height / 2, Window.Height + size));
                Console.WriteLine("here4");
            }
        }

        /// <summary>
        ///     Moves the enemy
        /// </summary>
        public void Move()
        {
            position += Vector2.Normalize(direction) * speed * Time.DeltaTime;
            //Console.WriteLine($"{position.X}x {position.Y}y");
        }

        /// <summary>
        ///     Renders the enemy to the screen
        /// </summary>
        public void Render()
        {
            Draw.FillColor = color;
            Draw.Square(position, size);
        }

        /// <summary>
        ///     Uses window collision to check if the enemy is off the screen
        /// </summary>
        /// <returns></returns>
        private bool isOffScreen()
        {
            return false;
        }

        /// <summary>
        ///     Updates the sides of the enemy based on its position
        ///     To be used for collision
        /// </summary>
        private void UpdateCollision()
        {

        }
    }
}
