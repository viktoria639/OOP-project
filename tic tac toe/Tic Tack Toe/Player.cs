using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tack_Toe
{
    [Serializable]
    public class Player
    {
        public string Name { get; }
        private int raiting;
        public int Raiting 
        { get 
            {
                return raiting;
            }
            set
            {
                if (value < 0) 
                {
                    raiting = 0;
                }
                else
                {
                    raiting = value;
                }
            }
        }

        public Player(string name)
        {
            Name = name;
            Raiting = 0;
        }
        public override string ToString()
        {
            return "Player { " + nameof(Name) + ": " + Name + ", " + nameof(Raiting) + ": " + Raiting + "}";
        }
    }
}
