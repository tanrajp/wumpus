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

        public void ParseInput(string input)
        {
            string in = input;
        }


    }
}
