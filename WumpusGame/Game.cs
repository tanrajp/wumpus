using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Game
    {
        private Player player;
        private Cave cave;

        public Game()
        {
            player = new Player();
            cave = new Cave(this);

            PrintIntro();
            cave.DisplayMiniMap(player.GetCurPos());
            cave.ParseCurrentRoom(player.GetCurPos());
            player.GetStatus();

            Console.Read();
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Cave GetCave()
        {
            return cave;
        }

        private void PrintIntro()
        {
            Console.Title = "Wumpus Game";
            Console.WriteLine("Wumpus Game");
            Console.WriteLine("by Tanraj Panesar");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void Main(string[] args)
        {
            Game g = new Game();
        }
    }
}
