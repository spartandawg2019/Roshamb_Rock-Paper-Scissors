namespace RockPaperScissorsGame
{
    // Abstract base class representing a player in the game
    public abstract class Player
    {
        public string Name { get; set; }
        public Roshambo Choice { get; set; }

        public Player(string name)
        {
            Name = name;
        }

       
        public abstract Roshambo GenerateRoshambo();
    }
}