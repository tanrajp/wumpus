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
            Entrance = 1,
            Wumpus = 1 << 2,
            PitTrap = 1 << 3,
            Gold = 1 << 4,
            Weapon = 1 << 5,
            Empty = 1 << 6,
            Explored = 1 << 7,
            Wall = 1 << 8,
            UnExplored = 1 << 9,
            All = UnExplored | Explored | Wall | Entrance | Weapon | Gold | Wumpus | PitTrap
        }

        private RoomType[,] map;
        private const double WUMPUS = 0.15;
        private const double PIT = 0.05;
        private const double GOLD = 0.15;
        private const double WEAPON = 0.15;
        private Tuple<int,int> Entrance;

        public Cave()
        {
            map = new RoomType[12, 12];
            SetUpWalls();
            //SetAllUnxplored();
            SetEntrance();
            SetUpRoom(RoomType.Wumpus, WUMPUS);
            SetUpRoom(RoomType.PitTrap, PIT);
            SetUpRoom(RoomType.Gold, GOLD);
            SetUpRoom(RoomType.Weapon, WEAPON);
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

        private void SetAllUnxplored()
        {
            for (int x =1 ; x <11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    map[x, y] = RoomType.UnExplored;
                }
            }
        }

        private void SetEntrance()
        {
            Random rnd = new Random();

            int x = 10;
            int y = rnd.Next(1,11);

            map[x, y] = RoomType.Entrance;
        }

        private void SetUpRoom(RoomType rt, double roomnums)
        {
            int numOfRooms = Convert.ToInt32((10 * 10) * roomnums);
            int xcoord, ycoord, index = 0;
            Random rng = new Random();

            while (index < numOfRooms)
            {
                xcoord = rng.Next(1, 11);
                ycoord = rng.Next(1, 11);

                if (!((map[xcoord, ycoord] & RoomType.All) != 0))
                {
                    map[xcoord, ycoord] = rt;
                    index++;
                }
            }
        }

        public void ParseCurrentRoom(Tuple<int, int> curPos)
        {
            RoomType room = map[curPos.Item1, curPos.Item2];
            if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Gold))
            {
                ExploreRoom(curPos);
                Console.WriteLine("Before you lies the the gold of adventure seekers who feed a Wumpus Recently");
            }
            if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Weapon))
            {
                ExploreRoom(curPos);
                Console.WriteLine("Cast before you in a rock a sword awaits to be looted and name yourself King");
            }
            if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Entrance))
            {
                Console.WriteLine("You see the entrance here. You wish to run away?");
            }
        }

        private void ExploreRoom(Tuple<int,int> curPos)
        {
            map[curPos.Item1,curPos.Item2] = RoomType.Explored;
        }

        private void ConvertWeaponRooms()
        {

        }

        public Tuple<int, int> GetEntrance()
        {
            return Entrance;
        }

        private void PrintRoom(Tuple<int, int> curPos)
        {
            RoomType room = map[curPos.Item1, curPos.Item2];

            if (room.HasFlag(RoomType.Wall))
            {
                Console.Write('#');
            }
            else if (room.HasFlag(RoomType.UnExplored))
            {
                Console.Write('?');
            }
            else if (room.HasFlag(RoomType.Gold))
            {
                Console.Write('$');
            }
            else if (room.HasFlag(RoomType.Weapon))
            {
                Console.Write('W');
            }
            else if (room.HasFlag(RoomType.Entrance))
            {
                Console.Write('^');
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
