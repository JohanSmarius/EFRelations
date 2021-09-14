using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Game
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        //public ICollection<PlayerGame> PlayerGames { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}