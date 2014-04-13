using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Player
    {
        public bool HasWeapon { get; set; }
        public bool IsAlive { get; set; }
        public int Gold { get; set; }
        //public Score score {get;set;}

        public Player()
        {
            HasWeapon = false;
            IsAlive = true;
            Gold = 0;
        }

        public string Status()
        {
            return string.Format(@"[{0} points earned] {1}", -1, HasWeapon ? "You are armed and dangerous." : "You are weaponless.");
        }

        public int GetPosition()
        {
            throw new NotImplementedException();
        }
    }
}
