using System;
using System.Numerics;

namespace Game10003
{
    public class Player
    {
        //variables:
        Vector2 input = Vector2.Zero;
        public Vector2 playerPosition = new Vector2(200, 200);
        public Vector2 BulletPosition;
        bool isShootPressed = false;
        bool isBulletActive = false;
        float BulletSpeed = 800;
        Vector2 bulletDirection;

        public void UpdatePlayer()
        {
            input = Vector2.Zero;

            // Player movement
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right) || Input.IsKeyboardKeyDown(KeyboardInput.D))
                input.X += 1;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left) || Input.IsKeyboardKeyDown(KeyboardInput.A))
                input.X -= 1;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Up) || Input.IsKeyboardKeyDown(KeyboardInput.W))
                input.Y -= 1;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Down) || Input.IsKeyboardKeyDown(KeyboardInput.S))
                input.Y += 1;


            playerPosition += input * 180 * Time.DeltaTime;
            float mouseLine = Input.GetMouseX() + Input.GetMouseY();

            float mouseLineX = Input.GetMouseX();
            float mouseLineY = Input.GetMouseY();

            DrawPlayer();

            // Calculate the direction from the player to the mouse cursor
            Vector2 directionToMouse = new Vector2(mouseLineX, mouseLineY) - playerPosition;


            // Calculate the distance to the mouse and clamp it to half the screen width
            float maxDistance = Window.Width / 2;
            float distanceToMouse = directionToMouse.Length();

            if (distanceToMouse > maxDistance)
            {
                directionToMouse = Vector2.Normalize(directionToMouse) * maxDistance;
            }

            // Normalize the direction to create a unit vector for movement
            bulletDirection = Vector2.Normalize(directionToMouse);

            // Draw the line from the player to the mouse with the clamped length
            Draw.LineColor = Color.Magenta;
            Draw.Line(playerPosition.X + 20 / 2, playerPosition.Y + 20 / 2, playerPosition.X + directionToMouse.X, playerPosition.Y + directionToMouse.Y);


            //Stops player from moving off the screen
            if (playerPosition.X < 0)
                playerPosition.X = 0;
            if (playerPosition.X > Window.Width - 30)
                playerPosition.X = Window.Width - 30;
            if (playerPosition.Y > Window.Height - 30)
                playerPosition.Y = Window.Height - 30;
            if (playerPosition.Y < 0)
                playerPosition.Y = 0;


            // Check if the shoot button (left mouse button) is pressed
            if (Input.IsMouseButtonDown(MouseInput.Left) && !isShootPressed)
            {
                // Shoot the bullet and save its direction
                BulletPosition = new Vector2(playerPosition.X + 10, playerPosition.Y - 2);  // Spawn the bullet at the player's position
                isBulletActive = true;
                isShootPressed = true;
            }

            // Move the bullet if it's active (shot)
            if (isBulletActive)
            {
                BulletPosition += bulletDirection * BulletSpeed * Time.DeltaTime;

                // Draw the bullet
                Draw.LineColor = Color.Green;
                Draw.LineSize = 3;
                Draw.Line(BulletPosition, new Vector2(BulletPosition.X, BulletPosition.Y - 2));
            }

            // Reset bullet when it goes off screen
            if (BulletPosition.Y < 0 || BulletPosition.X < 0 || BulletPosition.X > Window.Width || BulletPosition.Y > Window.Height)
            {
                isBulletActive = false;
                isShootPressed = false; // Reset shooting flag after the bullet disappears
            }
        }

        //Draw the player
        public void DrawPlayer()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Red;
            Draw.FillColor = Color.Blue;
            Draw.Square(playerPosition, 20);
        }
    }
}