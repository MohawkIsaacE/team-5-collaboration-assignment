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
        Vector2 size;
        bool isActive;
        Color color; // If no image
        Image image; // If no colour

        float leftSide, rightSide, topSide, bottomSide;

        /// <summary>
        ///     Determines where to spawn the enemy
        /// </summary>
        public void Spawn()
        {

        }

        /// <summary>
        ///     Moves the enemy
        /// </summary>
        public void Move()
        {

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
