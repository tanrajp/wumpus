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

        private RoomType[,] map;

        [Flags]
        enum RoomType
        {
            Empty = 0,
            UnExplored = 2,
            Explored = 4,
            Wall = 6,
            Entrance = 8,
            Weapon = 10,
            Gold = 12
        }

        public Cave()
        {
            map = new RoomType[SIZE + 2, SIZE + 2];
        }

        private void SetUpWalls()
        {
            //Vertical Walls
            for (int y = 0; y < map.GetLength(0); y++)
            {
                map[0, y] = RoomType.Wall;
                map[9, y] = RoomType.Wall;
            }

            //Horizontal Walls
            for (int x = 0; x < map.GetLength(1); x++)
            {
                map[x, 0] = RoomType.Wall;
                map[x, 9] = RoomType.Wall;
            }
        }

        private void SetWumpusRooms()
        {
            int numOfRooms = Convert.ToInt32(SIZE * WUMPUS);
        }

        public void DisplayDebugMap()
        {
            
        }

        public void DisplayMap(int playerPosition)
        {
            throw new NotImplementedException();
        }

        public void GetRoomDescription()
        {
            throw new NotImplementedException();
        }
    }
}
