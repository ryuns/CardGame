using System;
using CardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGameTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void CheckShuffle()
        {
            Deck lDeck = new Deck();
            Deck lDeckShuffle = new Deck();
            lDeckShuffle.Shuffle();
            
            CollectionAssert.AreNotEqual(lDeck.Cards, lDeckShuffle.Cards);
        }

        [TestMethod]
        public void CheckResetDeck()
        {
            Deck lDeck = new Deck();
            Array.ForEach(lDeck.Cards, card => card.Drawn = true);

            lDeck.Reset();

            Assert.IsTrue(Array.TrueForAll(lDeck.Cards, card => !card.Drawn));
        }
    }
}
