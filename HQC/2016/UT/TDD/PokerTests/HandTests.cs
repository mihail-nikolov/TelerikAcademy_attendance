using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TestToStringShouldWorkCorrectly()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            var hand = new Hand(cards);

            //act and assert
            Assert.AreEqual(hand.ToString(), 
@"Ace of Diamonds
Ace of Hearts
Ace of Spades");
        }
    }
}
