using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        public string Nickname { get; set; }

        public List<Card> Cards { get; }

        public Player(string pNickname)
        {
            Nickname = pNickname;
            Cards = new List<Card>();
        }

        public void addCard(Card pCard) 
        { 
            Cards.Add(pCard); 
        }

        public override string ToString()
        {
            return Nickname;
        }
    }
}
