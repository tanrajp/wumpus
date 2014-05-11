using System;

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
            Player = 1 << 10,
            All = Wumpus | PitTrap | Gold | Weapon | Entrance
        }

        private RoomType[,] map;
        private const double WUMPUS = 0.15;
        private const double PIT = 0.05;
        private const double GOLD = 0.15;
        private const double WEAPON = 0.15;
        private Game game;

        public Cave(Game game)
        {
            this.game = game;
            map = new RoomType[12, 12];
            SetUpWalls();
            SetAllUnxplored();
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
                    map[x, y] = RoomType.UnExplored | RoomType.Empty;
                }
            }
        }

        private void SetEntrance()
        {
            Random rnd = new Random();

            int x = 10;
            int y = rnd.Next(1,11);

            map[x, y] = RoomType.Entrance;
            Tuple<int, int> pos = new Tuple<int,int>(x,y);
            game.GetPlayer().SetCurPos(pos);
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
                    map[xcoord, ycoord] = map[xcoord, ycoord] | rt;
                    index++;
                }
            }
        }

        public bool ParseCurrentRoom(Tuple<int, int> curPos) // fix this.
        {
            RoomType room = map[curPos.Item1, curPos.Item2];
            bool Continue = true;

            if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Gold))
            {
                ExploreRoom(curPos);
                Console.WriteLine("Before you lies the the gold of adventure seekers who feed a Wumpus Recently");
            }
            else if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Weapon))
            {
                ExploreRoom(curPos);
                Console.WriteLine("Cast before you in a rock a sword awaits to be looted and name yourself King");
            }
            else if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Entrance))
            {
                Console.WriteLine("You see the entrance here. You wish to run away?");
            }
            else if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.PitTrap))
            {
                Continue = false;
                ExploreRoom(curPos);
                game.GetPlayer().IsAlive = false;
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaahhhhhhhhhh noooooooooooooooooo Splat");
            }
            else if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Wumpus))
            {
                ExploreRoom(curPos);
                if (game.GetPlayer().HasWeapon == true)
                {
                    Continue = true;
                    game.GetPlayer().SetCurrentScore(10);
                    Console.WriteLine("You slay the ugly beast with your sword");
                }
                if (game.GetPlayer().HasWeapon == false)
                {
                    Continue = false;
                    Console.WriteLine("A Wumpus attacks you and makes you his lunch.");
                }
            }
            else if(map[curPos.Item1,curPos.Item2].HasFlag(RoomType.Empty))
            {
                if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.UnExplored))
                {
                    ExploreRoom(curPos);
                    game.GetPlayer().SetCurrentScore(1);
                    Console.WriteLine("You see nothing, maybe in the next room...");
                }
                else
                {
                    Console.WriteLine("This room looks familiar. You have been here before");
                }
            }

            return Continue;
        }

        private void ExploreRoom(Tuple<int,int> curPos)
        {
            map[curPos.Item1, curPos.Item2] &= ~RoomType.UnExplored;
            map[curPos.Item1,curPos.Item2] = map[curPos.Item1, curPos.Item2] | RoomType.Explored;
        }

        private void ConvertWeaponRooms()
        {
            for (int i = 1; i < 11; i++)
            {
                for (int y = 1; y < 11; y++)
                {
                    if (map[i, y].HasFlag(RoomType.Weapon))
                    {
                        map[i, y] &= ~RoomType.Weapon;
                        map[i, y] |= RoomType.Gold;
                    }
                }
            }
        }

        public void DisplayMiniMap(Tuple<int, int> currentPos)
        {
            RoomType[,] view = new RoomType[3, 3];
            view = CreateMiniView(currentPos);

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
                        PrintRoom(new Tuple<int,int>(i, j), view);
                    }
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public void DescribeSurroundings(Tuple<int,int> currentPos) //fix this
        {
            int x = currentPos.Item1;
            int y = currentPos.Item2;

            if (map[x - 1, y].HasFlag(RoomType.Wumpus))
            {
                Console.WriteLine("There is a fowl stench in the air");
            }
            else if (map[x + 1, y].HasFlag(RoomType.Wumpus))
            {
                Console.WriteLine("There is a fowl stench in the air");
            }
            else if (map[x, y - 1].HasFlag(RoomType.Wumpus))
            {
                Console.WriteLine("There is a fowl stench in the air");
            }
            else if (map[x, y + 1].HasFlag(RoomType.Wumpus))
            {
                Console.WriteLine("There is a fowl stench in the air");
            }
            else if (map[x - 1, y].HasFlag(RoomType.PitTrap))
            {
                Console.WriteLine("You hear howling winds");
            }
            else if (map[x + 1, y].HasFlag(RoomType.PitTrap))
            {
                Console.WriteLine("You hear howling winds");
            }
            else if (map[x, y - 1].HasFlag(RoomType.PitTrap))
            {
                Console.WriteLine("You hear howling winds");
            }
            else if (map[x, y + 1].HasFlag(RoomType.PitTrap))
            {
                Console.WriteLine("You hear howling winds");
            }


        }

        private RoomType[,] CreateMiniView(Tuple<int, int> currentPos)
        {
            RoomType[,] view = new RoomType[3, 3];

            view[0, 0] = map[currentPos.Item1 - 1, currentPos.Item2 - 1];
            view[0, 1] = map[currentPos.Item1 - 1, currentPos.Item2];
            view[0, 2] = map[currentPos.Item1 - 1, currentPos.Item2 + 1];

            view[1, 0] = map[currentPos.Item1, currentPos.Item2 - 1];
            view[1, 1] = map[currentPos.Item1, currentPos.Item2] | RoomType.Player;
            view[1, 2] = map[currentPos.Item1, currentPos.Item2 + 1];

            view[2, 0] = map[currentPos.Item1 + 1, currentPos.Item2 - 1];
            view[2, 1] = map[currentPos.Item1 + 1, currentPos.Item2];
            view[2, 2] = map[currentPos.Item1 + 1, currentPos.Item2 + 1];

            return view;
        }

        private void PrintRoom(Tuple<int, int> curPos, RoomType[,] view)
        {
            RoomType room = view[curPos.Item1, curPos.Item2];

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
                    PrintRoom(new Tuple<int,int>(x,y), map);
                }
                Console.WriteLine(" ");
            }
        }

        public void Loot(Tuple<int,int> curPos)
        {
            if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Gold))
            {
                map[curPos.Item1, curPos.Item2] &= ~RoomType.Gold;
                game.GetPlayer().SetCurrentScore(5);
                Console.WriteLine("You loot the room");
            }
            else if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Weapon))
            {
                map[curPos.Item1, curPos.Item2] &= ~RoomType.Weapon;
                game.GetPlayer().HasWeapon = true;
                game.GetPlayer().SetCurrentScore(5);
                Console.WriteLine("You pick the mightly weapon");
                ConvertWeaponRooms();
            }
        }

        public void RunAway(Tuple<int,int> curPos)
        {
            if (map[curPos.Item1, curPos.Item2].HasFlag(RoomType.Entrance))
            {
                game.CanContinue = false;
                Console.WriteLine("You ran away");
            }
        }
    }
}
