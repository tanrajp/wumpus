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
            All = None|UnExplored|Explored|Wall|Entrance|Weapon|Gold|Wumpus
        }

        public Cave()
        {
            
            InitialiseCave();
        }
        
        private void InitialiseCave()
        {
            map = new RoomType[SIZE + 2, SIZE + 2];
            SetUpWalls();
            SetAllUnexplored();
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

        private void SetWumpusRooms()
        {
            int numOfRooms = Convert.ToInt32(SIZE * WUMPUS);
            int[] xcords = CalculateArrayCoordinates(numOfRooms);
            int[] ycords = CalculateArrayCoordinates(numOfRooms);

            for (int i = 0; i < numOfRooms; i++)
            {
                while (!((map[xcords[i], ycords[i]] & RoomType.All) != 0))
                {
                    map[xcords[i], ycords[i]] = RoomType.Wumpus;
                }
            }

        }

        private int GetRandomNumber()
        {
            var r = new Random();
            return r.Next(1, 9);
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
            else if (r.HasFlag(RoomType.None))
            {
                Console.Write('~');
            }
        }

        private void PrintRoomChar2(int x, int y)
        {
            RoomType r = map[x, y];
            if ((r & RoomType.UnExplored) == RoomType.UnExplored)
            {
                Console.Write('?');
            }
            if ((r & RoomType.Explored) == RoomType.Explored)
            {
                Console.Write('.');
            }
            if ((r & RoomType.Wall) == RoomType.Wall)
            {
                Console.Write('#');
            }
            if ((r & RoomType.Entrance) == RoomType.Entrance)
            {
                Console.Write('^');
            }
            if ((r & RoomType.Weapon) == RoomType.Weapon)
            {
                Console.Write('W');
            }
            if ((r & RoomType.Gold) == RoomType.Gold)
            {
                Console.Write('$');
            }
            if ((r & RoomType.Wumpus) == RoomType.Wumpus)
            {
                Console.Write('E');
            }
            if ((r & RoomType.None) == RoomType.None)
            {
                Console.Write('~');
            }
        }
    }
}
