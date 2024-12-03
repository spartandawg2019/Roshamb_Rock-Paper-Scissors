using System;

namespace RockPaperScissorsGame
{
    // Player class that generates a random choice
    public class RandomPlayer : Player
    {
        private static readonly Random Random = new Random();

        public RandomPlayer(string name) : base(name) { }

        
        public override Roshambo GenerateRoshambo()
        {
            return (Roshambo)Random.Next(0, 3); // Maps 0-2 to Rock, Paper, Scissors
        }
    }
}