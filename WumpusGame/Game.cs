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
        private int curX;
        private int curY;

        public Game()
        {
            player = new Player();
            cave = new Cave();
            curX = 10;
            curY = cave.GetEntranceCoord();
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Cave GetCave()
        {
            return cave;
        }

        public Tuple<int, int> GetCurrentPosition()
        {
            Tuple<int, int> curPos = new Tuple<int, int>(curX, curY);

            return curPos;
        }

        public void ParseInput(string rawInput)
        {
            string input = rawInput.ToUpper();
            switch (input)
            {
                case "?":
                    DisplayHelp();
                    break;
                case "X":
                    System.Environment.Exit(0);
                    break;
                case "R":
                    RunAway();
                    break;
                default:
                    Console.WriteLine("Input error, press ? for help");
                    break;
            }
        }

        private void RunAway()
        {
            Tuple<int,int> entrancePos = new Tuple<int,int>(10, cave.GetEntranceCoord());
            if (GetCurrentPosition().Equals(entrancePos))
            {
                player.IsAlive = false;
                Console.WriteLine("You exit the Wumpus cave and run to town. People buy you ales as you tell the story of your adventure.");
                Console.WriteLine("***GAME OVER***");
                Console.WriteLine("You scored " + player.GetCurrentScore() + " points! Well Played!");
            }
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("N Move 1 space north");
            Console.WriteLine("E Move 1 space east");
            Console.WriteLine("S Move 1 space south");
            Console.WriteLine("W Move 1 space west");
            Console.WriteLine("X exit game");
            Console.WriteLine(" ");
        }

    }
}
