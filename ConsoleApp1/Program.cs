using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new TestContext();

            //var player = new Player() { Name = "Test1" };
            //var game = new Game() { StartTime = DateTime.Now };

            //player.Games = new List<Game>() { game };

            //context.Players.Add(player);
            //context.Games.Add(game);

            //context.SaveChanges();

            // Update the join entity without the explicit DbSet
            //var player2 = new Player() { Name = "Test2" };
            //var game2 = new Game() { StartTime = DateTime.Now };
            //var gamePlayer = new GamePlayer() { Game = game2, Player = player2, Score = 20 };

            //context.Set<GamePlayer>().Add(gamePlayer);
            //context.SaveChanges();

            // Update the join entity with the explicit DbSet
            //var player3 = new Player() { Name = "Test3" };
            //var game3 = new Game() { StartTime = DateTime.Now };
            //var gamePlayer3 = new GamePlayer() { Game = game3, Player = player3, Score = 30 };

            //context.GamePlayers.Add(gamePlayer3);
            //context.SaveChanges();

            var game = context.Games.Include(game => game.Players).Single(game => game.Id == 3);
            var player = context.Players.First(player => player.Name == "Test3");

            var enlistedPlayers = context.GamePlayers.Include(gp => gp.Player).Where(gp => gp.Player == player);
            context.RemoveRange(enlistedPlayers);

            context.Players.Remove(player);

            ////
            ////var player2 = new Player() { Name = "Test2" };
            //// game.Players.Add(player2);

            context.SaveChanges();
        }


    }
}
