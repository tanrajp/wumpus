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
            cave.DisplayDebugMap();

            Console.WriteLine("Welcome to the Wumpus Game.");

            while (player.IsAlive)
            {
                cave.DisplayMap(game.GetCurrentPosition());
                Console.WriteLine(" ");
                cave.GetRoomDescription(game.GetCurrentPosition());
                cave.GetEnvironmentDescription(game.GetCurrentPosition());
                player.Status();
                Console.WriteLine("Enter Move (? for help) >");
                game.ParseInput(Console.ReadLine());
            }

            Console.ReadLine();
        }



        private void GetInput()
        {
            //Console.WriteLine("Enter Move (? for help) >");
            //string input = Console.ReadLine();
            //switch (input)
            //{
            //    case "?":
            //        DisplayHelp();
            //        break;
            //    case "x":
            //        System.Environment.Exit(0);
            //        break;
            //    case "n":
            //        player.North();
            //        cave.SetExplored(player.GetXpos(), player.GetYPos());
            //        break;
            //    case "e":
            //        player.East();
            //        cave.SetExplored(player.GetXpos(), player.GetYPos());
            //        break;
            //    case "s":
            //        player.South();
            //        cave.SetExplored(player.GetXpos(), player.GetYPos());
            //        break;
            //    case "w":
            //        player.West();
            //        cave.SetExplored(player.GetXpos(), player.GetYPos());
            //        break;
            //    default:
            //        Console.WriteLine("Default");
            //        break;
            //}
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            


        }


    }
}
