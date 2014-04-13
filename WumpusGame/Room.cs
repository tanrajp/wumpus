using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public abstract class Room
    {
        public int Xloc { get; set; }
        public int Yloc { get; set; }
        public string RoomType { get; set; }
        public string Description { get; set; }
        public char RommChar { get; set; }

    }
}
