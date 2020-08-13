using CardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameTests
{
    [TestClass]
    public class LuckOfTheDrawTests
    {
        [TestMethod]
        public void CheckLuckOfDrawCreation()
        {
            LuckOfTheDraw lLuckOfTheDraw = new LuckOfTheDraw(2, 5);

            Assert.AreEqual(lLuckOfTheDraw.NumberOfPlayers, 2);
            Assert.AreEqual(lLuckOfTheDraw.CardsPerPlayer, 5);
        }

        [TestMethod]
        public void CheckCardsPerPlayerHigherThanPossible()
        {
            LuckOfTheDraw lLuckOfTheDraw = new LuckOfTheDraw(10, 10);

            Assert.AreEqual(lLuckOfTheDraw.CardsPerPlayer, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckExceptionThrown()
        {
            LuckOfTheDraw lLuckOfTheDraw = new LuckOfTheDraw(53, 1);
        }
    }
}
