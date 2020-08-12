using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck
    {
        private int NumberOfCards = 13;
        public Card[] Cards { get; }

        public Deck()
        {
            Cards = new Card[52];
            ConstructDeck();
        }

        private void ConstructDeck()
        {
            for (int i = 0; i < NumberOfCards; i++)
            {
                Cards[i] = new Card(i + 1, Suit.Hearts);
                Cards[i + NumberOfCards] = new Card(i + 1, Suit.Diamonds);
                Cards[i + NumberOfCards * 2] = new Card(i + 1, Suit.Spades);
                Cards[i + NumberOfCards * 3] = new Card(i + 1, Suit.Clubs);
            }
        }

        public void ResetDeck()
        {
            Array.ForEach(Cards, card => card.Drawn = false);
        }

        public void ShuffleDeck()
        {
            ResetDeck();
            for (int n = Cards.Length - 1; n > 0; --n)
            {
                int k = RNG.NextInt(n + 1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }

        public Card DrawCard()
        {
            return Cards.First(card => !card.Drawn);
        }
    }
}
