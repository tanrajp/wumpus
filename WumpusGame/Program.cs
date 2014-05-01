using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Program
    {

        private Player player;

        public Program()
        {
            Cave cave = new Cave();
            player = new Player(10, cave.GetEntranceCoord());
            Console.WriteLine("Welcome to the Wumpus Game.");

            while (player.IsAlive)
            {
                cave.DisplayMap(player.GetXpos(), player.GetYPos());
                cave.GetRoomDescription(player.GetXpos(), player.GetYPos());
                cave.GetEnvironmentDescription();
                Console.WriteLine(player.Status());
                //cave.DisplayDebugMap();
                GetInput();
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
                case "?":
                    DisplayHelp();
                    break;
                case "x":
                    System.Environment.Exit(0);
                    break;
                case "n":
                    player.North();
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            


        }


    }
}
