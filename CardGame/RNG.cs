using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class RNG
    {
        private static Random rng = new Random();

        public static int NextInt()
        {
            return rng.Next();
        }

        public static int NextInt(int pMax)
        {
            return rng.Next(pMax);
        }
    }
}
