using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CardGame
{
    public class LuckOfTheDraw : IGame
    {
        private int numberOfPlayers;

        public int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
            private set
            {
                if (value > theDeck.Cards.Length)
                {
                    throw new ArgumentException("The number of players can not exceed the number of cards");
                }
                else
                {
                    numberOfPlayers = value;
                }
            }
        }

        private int cardsPerPlayer;

        public int CardsPerPlayer { 
            get 
            { 
                return cardsPerPlayer; 
            }
            private set
            {
                if(value > theDeck.Cards.Length / NumberOfPlayers)
                {
                    int lMaxValue = theDeck.Cards.Length / NumberOfPlayers;
                    Console.WriteLine("the cards per player can not be greater than " + lMaxValue);
                    Console.WriteLine("the cards per player has been set to " + lMaxValue);
                    cardsPerPlayer = lMaxValue;
                }
                else
                {
                    cardsPerPlayer = value;
                }
            }
        }

        public List<Player> Players { get; }

        public List<Player> Winners { get; private set; }

        public List<int> Scores { get; private set; }

        private Deck theDeck = new Deck();

        public LuckOfTheDraw() 
        {
            Players = new List<Player>();

            bool lValid = false;
            while(!lValid)
            {
                try
                {
                    Console.WriteLine("Please enter a number of players");
                    NumberOfPlayers = getValidInt();
                    lValid = true;
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            for(int i = 0; i < NumberOfPlayers; i++)
            {
                Console.WriteLine("Player " + (i + 1) + " enter your name");
                Players.Add(new Player(Console.ReadLine()));
            }

            Console.WriteLine("Please enter the number of cards per player");
            CardsPerPlayer = getValidInt();
        }

        public LuckOfTheDraw(int pNumberOfPlayers, int pCardsPerPlayer)
        {
            NumberOfPlayers = pNumberOfPlayers;
            CardsPerPlayer = pCardsPerPlayer;
        }

        public void PlayGame()
        {
            theDeck.Shuffle();

            for(int i = 0; i < CardsPerPlayer; i++)
            {
                for(int j = 0; j < NumberOfPlayers; j++)
                {
                    Card lCard = theDeck.DrawCard();
                    Players[j].addCard(lCard);
                    lCard.Drawn = true;
                }
            }

            int lHighScore = CalculateHighScore();
            Winners = new List<Player>();
            for(int i = 0; i < Scores.Count; i++)
            {
                if(Scores[i] == lHighScore)
                {
                    Winners.Add(Players[i]);
                }
            }
        }

        private int CalculateScore(Player pPlayer)
        {
            int lScore = 0;
            for(int i = 0; i < pPlayer.Cards.Count(); i++)
            {
                if(pPlayer.Cards[i].Value > 10)
                {
                    lScore += 10;
                }
                else
                {
                    lScore += pPlayer.Cards[i].Value;
                }
            }

            return lScore;
        }

        private int CalculateHighScore()
        {
            Scores = new List<int>();
            int lHighScore = 0;
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                int lScore = CalculateScore(Players[i]);
                Scores.Add(lScore);

                if (lScore > lHighScore)
                {
                    lHighScore = lScore;
                }
            }

            return lHighScore;
        }

        private int getValidInt()
        {
            int lValue;
            string lValueString = Console.ReadLine();

            while (!int.TryParse(lValueString, out lValue))
            {
                Console.WriteLine("Please enter a numeric value");

                lValueString = Console.ReadLine();
            }

            return lValue;
        }
    }
}
