using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Player
    {
        private Score score;

        public bool HasWeapon { get; set; }
        public bool IsAlive { get; set; }
        public int Gold { get; set; }


        public Player()
        {
            HasWeapon = false;
            IsAlive = true;
            Gold = 0;
            score = new Score();
        }

        public void Status()
        {
            Console.WriteLine(string.Format(@"[{0} points earned] {1}", score.CurrentScore(), HasWeapon ? "You are armed and dangerous." : "You are weaponless."));
        }

    }
}
