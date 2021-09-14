namespace ConsoleApp1
{
    public class GamePlayer
    {
        public int Id { get; set; }
        
        public Player Player { get; set; }

        public Game Game { get; set; }

        public int Score { get; set; }
    }
}