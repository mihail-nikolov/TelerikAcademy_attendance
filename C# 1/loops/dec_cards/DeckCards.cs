using System;
using System.Collections;
using System.Collections.Generic;

namespace dec_cards
{
    class DeckCards
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> cardsSign = new Dictionary<int, string>()
            {
                {1, "clubs"}, {2, "diamonds"}, {3, "hearts"}, {4, "spades"}
            };
            string theCard = "";
            for (int i = 2; i <= 14; i++)
            {
                switch (i)
                {
                    case 11:
                        theCard = "D";
                        break;
                    case 12:
                        theCard = "J";
                        break;
                    case 13:
                        theCard = "K";
                        break;
                    case 14:
                        theCard = "A";
                        break;
                    default:
                        theCard = i.ToString();
                        break;
                }
                for (int j = 1; j <= 4; j++)
                {
                    Console.WriteLine(theCard + " of " + cardsSign[j]);
                }
                theCard = "";
            }
        }
    }
}
