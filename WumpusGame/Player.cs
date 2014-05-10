using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Player
    {
        public Player()
        {
            IsAlive = true;
            HasWeapon = false;
        }

        public bool IsAlive
        {
            get;
            set;
        }

        public bool HasWeapon
        {
            get;
            set;
        }
    }
}
