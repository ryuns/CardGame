using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    interface IGame
    {
        List<Player> Players { get; }

        List<Player> Winners { get; }

        void PlayGame();
    }
}
