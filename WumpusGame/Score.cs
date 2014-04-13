using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    class Score
    {

        private int currentScore;

        public Score()
        {
            currentScore = 0;
        }

        public int CurrentScore()
        {
            return currentScore;
        }
    }
}
