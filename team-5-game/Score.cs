using System;
using System.Numerics;

namespace Game10003
{
    public class Score
    {
        int scoreNumber;
        string scoreText;
        Vector2 position;

        public Score()
        {
            scoreNumber = 0;
            scoreText = "Score: ";
            position = new Vector2(0, Window.Height - 20);
        }

        public void DisplayScore()
        {
            Text.Size = 20;
            Text.Color = Color.OffWhite;
            Text.Draw(scoreText + scoreNumber, position);
        }

        public void AddScore(int amount)
        {
            scoreNumber += amount;
        }

        public void RemoveScore(int amount)
        {
            scoreNumber -= amount;
        }
    }
}
