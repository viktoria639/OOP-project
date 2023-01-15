using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tack_Toe
{
    public class Game
    {
        private Player? firstPlayer;
        public Player FirstPlayer 
        {
            get { return firstPlayer; }
            set { if (value != null) firstPlayer = value; }
        }
        private Player? secondPlayer;
        public Player SecondPlayer
        {
            get { return secondPlayer; }
            set { if (value != null) secondPlayer = value; }
        }

        private int raiting;
        public int Raiting { 
            get { return raiting; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Raiting");
                raiting = value;
            } 
        }

    }
}
