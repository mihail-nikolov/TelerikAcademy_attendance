using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int ValidHandCount = 5;

        public bool IsValidHand(IHand hand)
        {
            var cards = hand.Cards;

            if (cards.Count != ValidHandCount)
            {
                return false;
            }

            for (int i = 0; i < cards.Count - 1; i++)
            {
                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (cards[i].Suit == cards[j].Suit && cards[i].Face == cards[j].Face)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int neededNumberFromKind = 4;
            var cards = hand.Cards;
            int counter = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (cards[i].Face == cards[j].Face)
                    {
                        counter++;
                    }
                }
                
                if (counter == neededNumberFromKind)
                {
                    return true;
                }
                counter = 0;
            }
            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            var cards = hand.Cards;

            var suit = cards[0].Suit;
            foreach (var card in cards)
            {
                if (card.Suit != suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
