using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Cave
    {
        private const int SIZE = 10;
        private const double WUMPUS = 0.15;
        private const double TRAP = 0.05;
        private const double GOLD = 0.15;
        private const double WEAPON = 0.15;

        private char[,] map;

        private char Wall = '#';
        private char UE = '?';
        private char EE = '.';
        private char Ent = '^';
        private char Weap = 'W';
        private char G = '$';
        private char WUMP = 'E';

        public Cave()
        {
            map = new char[SIZE + 2, SIZE + 2];
        }

        public void InitialiseMap()
        {
            map = new char[SIZE + 2, SIZE + 2]
            {
                {Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,UE,UE,UE,UE,UE,UE,UE,UE,UE,UE,Wall},
                {Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall,Wall}
            };
        }

        public void CalculateWumpusRooms()
        {
            double numOfRoms = Math.Ceiling(SIZE * WUMPUS);
            int xc=0;
            int yc=0;
            int i = 1;
            while (i <= numOfRoms)
            {
                CalculateCoordinates(out xc, out yc);
            }
            map[xc, yc] = WUMP;
            
        }

        private void CalculateCoordinates(out int xcoord, out int ycoord)
        {
            int minVal = 1;
            int maxVal = SIZE;

            var r = new Random();
            int x = r.Next(minVal, maxVal);
            int y = r.Next(minVal, maxVal);

            while (map[x,y] != '#')
            {
                x = r.Next(minVal, maxVal);
                y = r.Next(minVal, maxVal);
            }
            xcoord = x;
            ycoord = y;

        }


        public void DisplayFullMap()
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void DisplayMap(int playerPosition)
        {
            throw new NotImplementedException();
        }
    }
}
