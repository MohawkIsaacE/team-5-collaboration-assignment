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
        public float speed;
        float size;
        bool isActive;
        Color color = Color.OffWhite; // If no image
        Image image; // If no colour

        float leftSide, rightSide, topSide, bottomSide;
        bool isGoingDownRight, isGoingUpRight, isGoingDownLeft, isGoingUpLeft;

        /// <summary>
        ///     Determines where to spawn the enemy
        /// </summary>
        public void Spawn()
        {
            // Create a random direction for the enemy to move
            direction = Random.Direction();
            CalculateMoveDirection();
            
            // Randomize the enemy size
            size = Random.Float(15, 41);

            // Randomize where the enemy should start from
            int randomSide = Random.Integer(1, 3);

            /* 
            Determine where to spawn the enemy based on the direction it's going to move
            Direction positive X, positive Y will spawn somewhere top left
            Direction positive X, negative Y will spawn somewhere bottom left
            Direction negative X, positive Y will spawn somewhere top right
            Direction negative X, negative Y will spawn somewhere bottom right
            */
            if (isGoingDownRight)
            {
                if (randomSide == 0) position = new Vector2(Random.Float(-size * 2, Window.Width / 2), 0);
                else position = new Vector2(0, Random.Float(-size * 2, Window.Height / 2));
                Console.WriteLine("isGoingDownRight");
            }
            else if (isGoingUpRight)
            {
                if (randomSide == 0) position = new Vector2(Random.Float(-size * 2, Window.Width - size), Window.Height + size);
                else position = new Vector2(-size, Random.Float(Window.Height - size, -size * 2));
                Console.WriteLine("isGoingUpRight");
            }
            else if (isGoingDownLeft)
            {
                if (randomSide == 0) position = new Vector2(Random.Float(Window.Width / 2, Window.Width + size), size * 2);
                else position = new Vector2(Window.Width + size, Random.Float(-size * 2, Window.Height / 2));
                Console.WriteLine("isGoingDownLeft");
            }
            else if (isGoingUpLeft)
            {
                if (randomSide == 0) position = new Vector2(Random.Float(Window.Width / 2, Window.Width + size), Window.Height + size);
                else position = new Vector2(Window.Width + size, Random.Float(Window.Height / 2, Window.Height + size));
                Console.WriteLine("isGoingUpLeft");
            }
        }

        private void CalculateMoveDirection()
        {
            isGoingDownRight = direction.X >= 0 && direction.Y >= 0;
            isGoingUpRight = direction.X >= 0 && direction.Y < 0;
            isGoingDownLeft = direction.X < 0 && direction.Y >= 0;
            isGoingUpLeft = direction.X < 0 && direction.Y < 0;
        }

        /// <summary>
        ///     Moves the enemy
        /// </summary>
        public void Move()
        {
            position += Vector2.Normalize(direction) * speed * Time.DeltaTime;
            if (isOffScreen())
            {
                Spawn();
            }
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
            bool isOffScreen = false;

            if (isGoingDownRight)
            {
                if (position.X > Window.Width || position.Y > Window.Height)
                {
                    isOffScreen = true;
                    Console.WriteLine("offScreenRightOrBottom");
                }
            }
            else if (isGoingUpRight)
            {
                if (position.X > Window.Width || position.Y < 0)
                {
                    isOffScreen = true;
                    Console.WriteLine("offScreenRightOrTop");
                }
            }
            else if (isGoingDownLeft)
            {
                if (position.X < 0 || position.Y > Window.Height)
                {
                    isOffScreen = true;
                    Console.WriteLine("offScreenLeftOrBottom");
                }
            }
            else if (isGoingUpLeft)
            {
                if (position.X < 0 || position.Y < 0)
                {
                    isOffScreen = true;
                    Console.WriteLine("offScreenLeftOrTop");
                }
            }
            return isOffScreen;
        }

        /// <summary>
        ///     Updates the sides of the enemy based on its position
        ///     To be used for collision
        /// </summary>
        private void UpdateCollision()
        {
            leftSide = position.X;
            rightSide = position.X + size;
            topSide = position.Y;
            bottomSide = position.Y + size;
        }
    }
}
