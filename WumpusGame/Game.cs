using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Game
    {
        public Game()
        {
            Cave c = new Cave();
            c.DisplayMap();

            Console.Read();
        }

        public static void Main(string[] args)
        {
            Game g = new Game();
        }
    }
}
