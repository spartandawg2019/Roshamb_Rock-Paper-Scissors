using System;

namespace RockPaperScissorsGame
{
    // Main program for running the game
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!");
            Console.Write("Enter your name: ");
            string? playerName = Console.ReadLine(); // Allow null
            if (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("Name cannot be empty. Defaulting to 'Player'.");
                playerName = "Player";
            }
            HumanPlayer human = new HumanPlayer(playerName);

            while (true)
            {
                Console.WriteLine("Would you like to play against The Jets or The Sharks (j/s)?:");
                string? opponentInput = Console.ReadLine();
                if (string.IsNullOrEmpty(opponentInput))
                {
                    Console.WriteLine("Invalid input. Please enter 'j' or 's'.");
                    continue;
                }

                Player opponent;
                try
                {
                    opponent = Validator.SelectOpponent(opponentInput);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue; // Retry on invalid input
                }

                Roshambo humanChoice = human.GenerateRoshambo();
                Roshambo opponentChoice = opponent.GenerateRoshambo();

                Console.WriteLine($"{human.Name}: {humanChoice.ToString().ToLower()}");
                Console.WriteLine($"{opponent.Name}: {opponentChoice.ToString().ToLower()}");

                string result = DetermineWinner(humanChoice, opponentChoice, human.Name, opponent.Name);
                Console.WriteLine(result);

                Console.WriteLine("Play again? (y/n):");
                string? playAgainInput = Console.ReadLine();
                if (string.IsNullOrEmpty(playAgainInput))
                {
                    Console.WriteLine("Invalid input. Exiting game.");
                    break;
                }

                if (!Validator.GetYesOrNo(playAgainInput))
                {
                    break; // Exit loop if the user doesn't want to play again
                }
            }

            Console.WriteLine("Thanks for playing!");
        }

        // Determines the outcome of a match and returns the result
        private static string DetermineWinner(Roshambo player1Choice, Roshambo player2Choice, string player1Name, string player2Name)
        {
            if (player1Choice == player2Choice)
            {
                return "Draw!"; // Both players made the same move
            }

            if ((player1Choice == Roshambo.Rock && player2Choice == Roshambo.Scissors) ||
                (player1Choice == Roshambo.Paper && player2Choice == Roshambo.Rock) ||
                (player1Choice == Roshambo.Scissors && player2Choice == Roshambo.Paper))
            {
                return $"{player1Name} wins!"; // Player 1 wins
            }

            return $"{player2Name} wins!"; // Player 2 wins
        }
    }
}