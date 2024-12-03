using System;

namespace RockPaperScissorsGame
{
    // Player controlled by user input
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name) { }

        // Prompts the user to select a Roshambo move
        public override Roshambo GenerateRoshambo()
        {
            while (true)
            {
                Console.WriteLine("Rock, paper, or scissors? (R/P/S):");
                string? input = Console.ReadLine(); // Allow nulls
                if (!string.IsNullOrEmpty(input) && Validator.IsValidRoshambo(input.ToLower(), out Roshambo choice))
                {
                    return choice;
                }

                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}