using System;

namespace WumpusGame
{
    public class Player
    {

        private Tuple<int, int> curPos;
        private int score;

        public Player()
        {
            IsAlive = true;
            HasWeapon = false;
            score = 0;
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

        public void SetCurPos(Tuple<int, int> curPos)
        {
            this.curPos = curPos;
        }

        public Tuple<int, int> GetCurPos()
        {
            return curPos;
        }

        public void GetStatus()
        {
            Console.WriteLine(string.Format(@"[{0} points earned] {1}", GetCurrentScore(), HasWeapon ? "You are armed and dangerous." : "You are weaponless."));
        }

        public int GetCurrentScore()
        {
            return score;
        }

        public void SetCurrentScore(int s)
        {
            score += s;
        }
    }
}
