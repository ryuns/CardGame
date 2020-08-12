using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Card
    {
        public int Value { get; set; }

        public Suit Suit { get; set; }

        public bool Drawn { get; set; }

        public string theReadableValue
        {
            get
            {
                switch (Value)
                {
                    case 1:
                        return "Ace";
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    default:
                        return Value.ToString();
                }
            }
        }

        public Card(int pValue, Suit pSuit)
        {
            Value = pValue;
            Suit = pSuit;
            Drawn = false;
        }

        public override string ToString()
        {
            return theReadableValue + " of " + Suit.ToString();
        }
    }
}
