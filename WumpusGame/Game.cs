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

            bool CanContinue = true;
            while (CanContinue)
            {
                cave.DisplayMiniMap(player.GetCurPos());
                CanContinue = cave.ParseCurrentRoom(player.GetCurPos());
                if (CanContinue == false)
                {
                    break;
                }
                player.GetStatus();
                Console.WriteLine("Enter Move (? for help) > ");
                ParseInput(Console.ReadLine());
            }
            PrintGameOver();
            Console.Read();
        }

        private void ParseInput(string input)
        {
            int x = player.GetCurPos().Item1;
            int y = player.GetCurPos().Item2;

            switch (input.ToUpper())
            {
                case "N":
                    x--;
                    break;
                case "S":
                    x++;
                    break;
                case "E":
                    y++;
                    break;
                case "W":
                    y--;
                    break;
                case "?":
                    PrintHelp();
                    break;
                case "L":
                    cave.Loot();
                    break;
                case "R":
                    
                    break;
                case "X":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Input Error!");
                    break;
            }
            player.SetCurPos(new Tuple<int,int>(x,y));
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

        private void PrintHelp()
        {
            Console.WriteLine("N Move 1 space north");
            Console.WriteLine("E Move 1 space east");
            Console.WriteLine("S Move 1 space south");
            Console.WriteLine("W Move 1 space west");
            Console.WriteLine("X exit game");
            Console.WriteLine("R run away");
            Console.WriteLine(" ");
        }

        public void PrintGameOver()
        {
            Console.WriteLine("***Game Over ***");
            Console.WriteLine("You scored " + player.GetCurrentScore() + " points");
        }

        public static void Main(string[] args)
        {
            Game g = new Game();
        }
    }
}
