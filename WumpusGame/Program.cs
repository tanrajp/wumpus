﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    class Program
    {

        private static void DisplayHelp()
        {
            Console.WriteLine("N Move 1 space north");
            Console.WriteLine("E Move 1 space east");
            Console.WriteLine("S Move 1 space south");
            Console.WriteLine("W Move 1 space west");
            Console.WriteLine("X exit game");
        }

        private static void Input()
        {

        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Console.WriteLine("Wumpus Game");

            while (player.IsAlive)
            {
                Console.WriteLine(player.Status());
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
                    default:
                        Console.WriteLine("Default");
                        break;
                }

            }

            



            Console.ReadLine();
        }
    }
}
