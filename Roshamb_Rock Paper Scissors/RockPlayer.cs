namespace RockPaperScissorsGame
{
    // Player class that always chooses Rock
    public class RockPlayer : Player
    {
        public RockPlayer(string name) : base(name) { }

        // Always returns Rock
        public override Roshambo GenerateRoshambo()
        {
            return Roshambo.Rock;
        }
    }
}