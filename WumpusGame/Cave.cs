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
            Player = 256,
            All = None|UnExplored|Explored|Wall|Entrance|Weapon|Gold|Wumpus|Trap|Player
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
            //SetAllUnexplored();
            SetUpRoom(RoomType.Wumpus, WUMPUS);
            SetUpRoom(RoomType.Trap, TRAP);
            SetUpRoom(RoomType.Gold, GOLD);
            SetUpRoom(RoomType.Weapon, WEAPON);
            SetEntrance();
        }

        private void SetEntrance()
        {
            int ycoord = 10;

            for (int i = 1; i < 11; i++)
            {
                if (!((map[i, ycoord] & RoomType.All) != 0))
                {
                    map[ycoord, i] = RoomType.Entrance;
                    break;
                }
            }

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
                    map[xcoord, ycoord] = rt | RoomType.UnExplored;
                    index++;
                }

            }
        }

        private int GetRandomNumber()
        {
            var r = new Random();
            return r.Next(1, SIZE+1);
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

        public int GetEntranceCoord()
        {
            int xcord = 10;
            int ycord = 0;

            for (int i = 0; i < 12; i++)
            {
                if (map[xcord, i].HasFlag(RoomType.Entrance))
                {
                    ycord = i;
                }
            }
            return ycord;
        }

        public void TestMap()
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write("(" + i + "," + j + ")");
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public void DisplayDebugMap()
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    PrintRoomChar(i, j,map);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public void DisplayMap(Tuple<int,int> currentPos)
        {
            RoomType[,] view = new RoomType[3,3];

            view[0, 0] = map[currentPos.Item1-1, currentPos.Item2 - 1];
            view[0, 1] = map[currentPos.Item1 - 1, currentPos.Item2];
            view[0, 2] = map[currentPos.Item1 - 1, currentPos.Item2 + 1];

            view[1, 0] = map[currentPos.Item1, currentPos.Item2 - 1];
            view[1, 1] = map[currentPos.Item1, currentPos.Item2] | RoomType.Player;
            view[1, 2] = map[currentPos.Item1, currentPos.Item2 + 1];

            view[2, 0] = map[currentPos.Item1 + 1, currentPos.Item2 - 1];
            view[2, 1] = map[currentPos.Item1 + 1, currentPos.Item2];
            view[2, 2] = map[currentPos.Item1 + 1, currentPos.Item2 + 1];

            for (int i = 0; i < view.GetLength(1); i++)
            {
                for (int j = 0; j < view.GetLength(1); j++)
                {
                    if (view[i, j].HasFlag(RoomType.Player))
                    {
                        Console.Write("@");
                    }
                    else
                    {
                        PrintRoomChar(i, j, view);
                    }
                    Console.Write(' ');
                }
                Console.WriteLine();
            }

        }

        public void GetRoomDescription(Tuple<int, int> currPos)
        {
            RoomType r = map[currPos.Item1, currPos.Item2];

            if (r.HasFlag(RoomType.Entrance))
            {
                Console.WriteLine("You are at the entrance");
            }
            else if (r.HasFlag(RoomType.Gold))
            {
                Console.WriteLine("Before you lies Gold");
            }
            else if (r.HasFlag(RoomType.Trap))
            {
                Console.WriteLine("You died");
            }
            else if (r.HasFlag(RoomType.Weapon))
            {
                Console.WriteLine("You see a weapon");
            }
            else if (r.HasFlag(RoomType.Wumpus))
            {
                Console.WriteLine("You died");
            }
        }

        private void PrintRoomChar2(int x, int y, RoomType[,] room)
        {
            RoomType r = room[x, y];
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
            else if (r.HasFlag(RoomType.Player))
            {
                Console.WriteLine('@');
            }
            else
            {
                Console.WriteLine('?');
            }
        }

        private void PrintRoomChar(int x, int y,RoomType[,] room)
        {
            RoomType r = room[x, y];
            if (r.HasFlag(RoomType.UnExplored))
            {
                Console.Write('?');
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
            else if (r.HasFlag(RoomType.Player))
            {
                Console.WriteLine("@");
            }
            else if (r.HasFlag(RoomType.None))
            {
                Console.Write('?');
            }
            else if (r.HasFlag(RoomType.Explored))
            {
                Console.Write('.');
            }

        }

        public void GetEnvironmentDescription(Tuple<int,int> curPos)
        {
            
        }

        public void SetExplored(Tuple<int,int> curPos)
        {
            //map[curPos.Item1, curPos.Item2] &= ~RoomType.UnExplored;
            //map[curPos.Item1, curPos.Item2] |= RoomType.Explored;
            map[curPos.Item1, curPos.Item2] = RoomType.Explored;
        }

        public bool CanMove(Tuple<int,int> currPos)
        {
            bool canMove = false;
            if (currPos.Item1 <= SIZE || currPos.Item2 <= SIZE)
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }

            return canMove;
        }

        public void ExploreRoom(Tuple<int, int> curPos)
        {
            map[curPos.Item1, curPos.Item2] &= ~RoomType.UnExplored;
            map[curPos.Item1, curPos.Item2] |= RoomType.Explored;
        }

        public bool IsGoldRoom(Tuple<int, int> curPos)
        {
            bool gold = false;

            if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Gold))
            {
                gold = true;
            }
            return gold;
        }

        public bool IsWumpusRoom(Tuple<int, int> curPos)
        {
            bool wumpus = false;
            if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Wumpus))
            {
                wumpus = true;
            }
            return wumpus;
        }
    }
}
