using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        public int Value { get; set; }

        public Suit Suit { get; set; }

        public bool Drawn { get; set; }

        private string ReadableValue
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
            return ReadableValue + " of " + Suit.ToString();
        }

        public override bool Equals(object pObj)
        {
            if ((pObj == null) || !GetType().Equals(pObj.GetType()))
            {
                return false;
            }
            else
            {
                Card lCard = (Card)pObj;
                return (Value == lCard.Value) && (Suit == lCard.Suit);
            }
        }
    }
}
