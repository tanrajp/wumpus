using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Program
    {


        public Program()
        {
            Game game = new Game();
            Player player = game.GetPlayer();
            Cave cave = game.GetCave();

            Console.WriteLine("Welcome to the Wumpus Game.");

            while (player.IsAlive)
            {
                cave.DisplayMap(game.GetCurrentPosition());
                cave.GetRoomDescription(game.GetCurrentPosition());
                cave.GetEnvironmentDescription();
                player.Status();
                game.ParseInput(Console.ReadLine());
            }


            Console.ReadLine();
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("N Move 1 space north");
            Console.WriteLine("E Move 1 space east");
            Console.WriteLine("S Move 1 space south");
            Console.WriteLine("W Move 1 space west");
            Console.WriteLine("X exit game");
        }

        private void GetInput()
        {
            Console.WriteLine("Enter Move (? for help) >");
            string input = Console.ReadLine();
            switch (input)
            {
                //case "?":
                //    DisplayHelp();
                //    break;
                //case "x":
                //    System.Environment.Exit(0);
                //    break;
                //case "n":
                //    player.North();
                //    cave.SetExplored(player.GetXpos(), player.GetYPos());
                //    break;
                //case "e":
                //    player.East();
                //    cave.SetExplored(player.GetXpos(), player.GetYPos());
                //    break;
                //case "s":
                //    player.South();
                //    cave.SetExplored(player.GetXpos(), player.GetYPos());
                //    break;
                //case "w":
                //    player.West();
                //    cave.SetExplored(player.GetXpos(), player.GetYPos());
                //    break;
                //default:
                //    Console.WriteLine("Default");
                //    break;
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            


        }


    }
}
