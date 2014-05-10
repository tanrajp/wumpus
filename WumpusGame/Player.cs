using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Player
    {
        private bool IsAlive;
        private bool HasWeapon;

        public Player()
        {
            IsAlive = true;
            HasWeapon = false;
        }
    }
}
