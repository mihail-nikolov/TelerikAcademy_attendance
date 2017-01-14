using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestTostringShouldReturnCorrectResult()
        {
            //arrange 
            Card myCard = new Card(CardFace.Ace, CardSuit.Spades);
            // act and assert
            Assert.AreEqual("Ace of Spades", myCard.ToString());
        }
    }
}
