using Raylib_cs;
using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Game10003
{
    public class Sprites
    {
        public Vector2 playerPosition;
        public Vector2 asteroidPosition;
        public Vector2 bgPosition;

        
        public Texture2D player = Graphics.LoadTexture("../../../../Assets/GameShip.png");
        public Texture2D asteroid = Graphics.LoadTexture("../../../../Assets/GameAsteroid.png");
        public Texture2D background = Graphics.LoadTexture("../../../../Assets/GameBackground.png");

        public void DrawAsteroid()
        {
            Graphics.Scale = 0.1f;
            Graphics.Draw(asteroid, asteroidPosition);
        }

        public void DrawPlayer()
        {
            Graphics.Scale = 0.1f;
            Graphics.Draw(player, playerPosition);
        }

        public void DrawBackground()
        {
            Graphics.Scale = 1f;
            Graphics.Draw(background, bgPosition);
        }


    }
}
