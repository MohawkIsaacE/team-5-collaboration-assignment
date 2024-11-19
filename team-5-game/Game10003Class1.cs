using System;
using System.Numerics;

namespace Game10003
{
    public class Player
    {
        //variables:
        Vector2 input = Vector2.Zero;
        Vector2 playerPosition = new Vector2(200, 200);
        Vector2 BulletPosition;
        bool isShootPressed = false;
        float BulletSpeed = 200;

        //Player/Bullet Functions
        public void Setup()
        {
            Window.SetSize(400, 400);


        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            input = Vector2.Zero;

            // Player movement
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right))
                input.X += 1;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left))
                input.X -= 1;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Up))
                input.Y -= 1;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Down))
                input.Y += 1;


            playerPosition += input * 180 * Time.DeltaTime;
            float mouseLine = Input.GetMouseX() + Input.GetMouseY();
            DrawPlayer();
            //Self Explanatory
            void DrawPlayer()
            {
                Draw.LineSize = 2;
                Draw.LineColor = Color.Red;
                Draw.FillColor = Color.Blue;
                Draw.Square(playerPosition, 20);

            }
            //Stops player from moving off the screen
            if (playerPosition.X < 0)
                playerPosition.X = 0;
            if (playerPosition.X > Window.Width - 30)
                playerPosition.X = Window.Width - 30;
            if (playerPosition.Y > Window.Height - 30)
                playerPosition.Y = Window.Height - 30;
            if (playerPosition.Y < 0)
                playerPosition.Y = 0;


            //Checks if the button was pressed to activate the bullet variant
            if (Input.IsMouseButtonDown(MouseInput.Left))
            {
                BulletPosition = new Vector2(playerPosition.X + 10, playerPosition.Y - 2);
                isShootPressed = true;

            }

            if (isShootPressed)
            {
                BulletPosition.Y -= BulletSpeed * Time.DeltaTime;
            }
            if (isShootPressed)
            {
                Draw.LineSize = 3;
                Draw.Line(BulletPosition, new Vector2(BulletPosition.X, BulletPosition.Y - 2));
            }
            if (BulletPosition.Y < 0)
            {
                isShootPressed = false;
            }

        }
    }
}
