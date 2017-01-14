using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void TestIsvalidHand_ShouldReturnTrue()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();
            Assert.IsTrue(handChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsvalidHand_ShouldReturnFalse()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();
            Assert.IsFalse(handChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsvalidHand_ShouldReturnFalseWIthLessCards()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();
            Assert.IsFalse(handChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsFlush_ShouldReturnTrue()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
           
            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();

            Assert.IsTrue(handChecker.IsValidHand(hand));
            Assert.IsTrue(handChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_ShouldReturnFalse()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));

            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();

            Assert.IsTrue(handChecker.IsValidHand(hand));
            Assert.IsFalse(handChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestFourOfKind_ShouldReturnTrue()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();

            Assert.IsTrue(handChecker.IsValidHand(hand));
            Assert.IsFalse(handChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfKindWithThree_ShouldReturnFalse()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();

            Assert.IsTrue(handChecker.IsValidHand(hand));
            Assert.IsFalse(handChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfKindWithTwo_ShouldReturnFalse()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();

            Assert.IsTrue(handChecker.IsValidHand(hand));
            Assert.IsFalse(handChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfKindWithOne_ShouldReturnFalse()
        {
            //arrange 
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            var hand = new Hand(cards);

            //act and assert
            var handChecker = new PokerHandsChecker();

            Assert.IsTrue(handChecker.IsValidHand(hand));
            Assert.IsFalse(handChecker.IsFourOfAKind(hand));
        }
    }
}
