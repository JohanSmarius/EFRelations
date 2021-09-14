using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public ICollection<PlayerGame> PlayerGames { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}