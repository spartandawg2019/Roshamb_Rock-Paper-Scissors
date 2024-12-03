using System;

namespace RockPaperScissorsGame
{
    // Utility class for input validation
    public static class Validator
    {
        // Validates and converts user input into a Roshambo value
        public static bool IsValidRoshambo(string? input, out Roshambo choice)
        {
            choice = Roshambo.Rock; // Default value
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return input switch
            {
                "r" => Enum.TryParse("Rock", out choice),
                "p" => Enum.TryParse("Paper", out choice),
                "s" => Enum.TryParse("Scissors", out choice),
                _ => false // Invalid input
            };
        }

        // Validates yes/no responses
        public static bool GetYesOrNo(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }

            return input.ToLower() switch
            {
                "y" => true,
                "n" => false,
                _ => throw new ArgumentException("Invalid input. Enter 'Y' or 'N'.")
            };
        }

        // Selects an opponent based on user input
        public static Player SelectOpponent(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }

            return input.ToLower() switch
            {
                "j" => new RockPlayer("The Jets"), // Fixed move opponent
                "s" => new RandomPlayer("The Sharks"), // Random move opponent
                _ => throw new ArgumentException("Invalid opponent. Enter 'J' or 'S'.")
            };
        }
    }
}