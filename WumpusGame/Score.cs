using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Score
    {
        private int currentScore;

        public Score()
        {
            currentScore = 0;
        }

        public void IncreaseScore()
        {
            currentScore++;
        }

        public void DecreaseScore()
        {
            currentScore--;
        }
    }
}
