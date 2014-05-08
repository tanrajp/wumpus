using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Cave
    {
        [Flags]
        enum RoomType
        {
            Entrance = 2,
            Wumpus = 4,
            PitTrap = 8,
            Gold = 16,
            Weapon = 32,
            Empty = 64,
            Explored = 128,
            Wall = 256,
        }

        private RoomType[,] map;
        private const double WUMPUS = 0.15;
        private const double PIT = 0.05;
        private const double GOLD = 0.15;
        private const double WEAPON = 0.15;

        public Cave()
        {
            map = new RoomType[12, 12];
            SetUpWalls();
        }

        private void SetUpWalls()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                map[i, 0] = RoomType.Wall;
                map[i, 11] = RoomType.Wall;

                map[0, i] = RoomType.Wall;
                map[11, i] = RoomType.Wall;
            }
        }

        private void PrintRoom(Tuple<int, int> curPos)
        {
            RoomType room = map[curPos.Item1, curPos.Item2];

            if (room.HasFlag(RoomType.Wall))
            {
                Console.Write('#');
            }
            else
            {
                Console.Write('.');
            }
        }

        public void DisplayMap()
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    PrintRoom(new Tuple<int,int>(x,y));
                }
                Console.WriteLine(" ");
            }
        }


    }
}
