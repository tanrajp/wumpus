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

        private int xpos;
        private int ypos;

        public Player(int x, int y)
        {
            HasWeapon = false;
            IsAlive = true;
            Gold = 0;
            xpos = x;
            ypos = y;
            score = new Score();
        }

        public string Status()
        {
            return string.Format(@"[{0} points earned] {1}", score.CurrentScore(), HasWeapon ? "You are armed and dangerous." : "You are weaponless.");
        }

        public int GetXpos()
        {
            return xpos;
        }

        public int GetYPos()
        {
            return ypos;
        }

        public void North()
        {
            xpos--;
        }
    }
}
