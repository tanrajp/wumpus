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
            None = 0,
            UnExplored = 1,
            Explored = 2,
            Wall = 4,
            Entrance = 8,
            Weapon = 16,
            Gold = 32,
            Wumpus=64,
            Trap = 128,
            All = None|UnExplored|Explored|Wall|Entrance|Weapon|Gold|Wumpus|Trap
        }

        public Cave()
        {
            
            InitialiseCave();
        }
        
        private void InitialiseCave()
        {
            map = new RoomType[SIZE + 2, SIZE + 2];
            SetUpCave();

        }

        private void SetUpCave()
        {
            SetUpWalls();
            SetUpRoom(RoomType.Wumpus, WUMPUS);
            SetUpRoom(RoomType.Trap, TRAP);
            SetUpRoom(RoomType.Gold, GOLD);
            SetUpRoom(RoomType.Weapon, WEAPON);
        }

        private void SetAllUnexplored()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    map[i, j] = RoomType.UnExplored;
                }
            }
        }

        private void SetUpWalls()
        {
            //Vertical Walls
            for (int y = 0; y < map.GetLength(0); y++)
            {
                map[0, y] = RoomType.Wall;
                map[SIZE+1, y] = RoomType.Wall;
            }

            //Horizontal Walls
            for (int x = 0; x < map.GetLength(1); x++)
            {
                map[x, 0] = RoomType.Wall;
                map[x, SIZE+1] = RoomType.Wall;
            }
        }

        private void SetUpRoom(RoomType rt, double roomnums)
        {
            int numOfRooms = Convert.ToInt32((SIZE * SIZE) * roomnums);
            int xcoord, ycoord, index = 0;

            while (index < numOfRooms)
            {
                xcoord = GetRandomNumber();
                ycoord = GetRandomNumber();

                if (!((map[xcoord, ycoord] & RoomType.All) != 0))
                {
                    map[xcoord, ycoord] = rt;
                    index++;
                }

            }
        }

        private int GetRandomNumber()
        {
            var r = new Random();
            return r.Next(1, 11);
        }

        private int[] CalculateArrayCoordinates(int size)
        {
            int[] arr = new int[size];
            int index = 0;

            while (index < size)
            {
                arr[index] = GetRandomNumber();
                index++;
            }

            return arr;
        }

        public void DisplayDebugMap()
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    PrintRoomChar(i, j);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public void DisplayMap(int playerPosition)
        {
            throw new NotImplementedException();
        }

        public void GetRoomDescription()
        {
            throw new NotImplementedException();
        }

        private void PrintRoomChar(int x, int y)
        {
            RoomType r = map[x, y];
            if (r.HasFlag(RoomType.UnExplored))
            {
                Console.Write('?');
            }
            else if (r.HasFlag(RoomType.Explored))
            {
                Console.Write('.');
            }
            else if (r.HasFlag(RoomType.Wall))
            {
                Console.Write('#');
            }
            else if (r.HasFlag(RoomType.Entrance))
            {
                Console.Write('^');
            }
            else if (r.HasFlag(RoomType.Weapon))
            {
                Console.Write('W');
            }
            else if (r.HasFlag(RoomType.Gold))
            {
                Console.Write('$');
            }
            else if (r.HasFlag(RoomType.Wumpus))
            {
                Console.Write('E');
            }
            else if (r.HasFlag(RoomType.Trap))
            {
                Console.Write('T');
            }
            else if (r.HasFlag(RoomType.None))
            {
                Console.Write('~');
            }
        }
    }
}
