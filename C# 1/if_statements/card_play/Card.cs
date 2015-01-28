using System;
using System.Linq;


namespace card_play
{
    class Card
    {
        static void Main()
        {
            string[] validSignsArr = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
            Console.Write("enter sign: ");
            string sign = Console.ReadLine();
            if(validSignsArr.Contains(sign))
            {
                Console.WriteLine("yes");
                return;
            }
            Console.WriteLine("no");
        }
    }
}
