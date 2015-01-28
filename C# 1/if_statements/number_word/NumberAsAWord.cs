using System;
using System.Collections;
using System.Collections.Generic;

namespace number_word
{
    class NumberAsAWord
    {
        static void Main()
        {
            Dictionary<int, string> digitMap = new Dictionary<int, string>()
            {
                {0, "zero"}, {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"},
                {6 , "six"}, {7, "seven"}, {8 , "eight"}, {9 , "nine"}, {10, "ten"}, {11, "eleven"},
                {12, "twelve"}, {13, "thirteen"}, {14 , "fourteen"}, {15, "fifteen"}, {16, "sixteen"},
                {17, "seventeen"}, {18 , "eighteen"},{19 , "nineteen"}, {20 , "twenty"}, {30, "thirty"},
                {40, "fourty"}, {50, "fifty"}, {60, "sixty"}, {70, "seventy"}, {80, "eighty"}, {90, "ninety"}
            };
            Console.Write("Enter number: ");
            string inputNumberStr = Console.ReadLine();
            int inputNumber = int.Parse(inputNumberStr);
            if (inputNumberStr.Length == 1)
            {
                Console.WriteLine(digitMap[inputNumber]);
            }
            else if (inputNumberStr.Length == 2)
            {
                int decPart = inputNumber / 10;
                int decPartRem = inputNumber % 10;
                int decNumberFromMap = decPart * 10;
                if (inputNumber <= 20)
                {
                    Console.WriteLine(digitMap[inputNumber]);
                }

                else if (decPartRem == 0)
                {
                    Console.WriteLine(digitMap[decNumberFromMap]);
                }
                else
                {
                    Console.WriteLine(digitMap[decNumberFromMap] + " " + digitMap[decPartRem]);
                }
            }
            else
            {
                int hunPart = inputNumber / 100;
                int dec = inputNumber % 100;
                int decPart = dec / 10;
                int decPartRem = dec % 10;
                int decNumberFromMap = decPart * 10;
                if (decPart == 0)
                {
                    if (decPartRem == 0)
                    {
                        Console.WriteLine(digitMap[hunPart] + "  hundred");
                    }
                    else 
                    {
                        Console.WriteLine(digitMap[hunPart] + "  hundred and " + digitMap[decPartRem]);
                    }
                }
                else if (decPart >= 1 && decPart < 2)
                {
                    Console.WriteLine(digitMap[hunPart] + "  hundred and " + digitMap[dec]);
                }
                else
                {
                    if (decPartRem == 0)
                    {
                        Console.WriteLine(digitMap[hunPart] + "  hundred and " + digitMap[dec]);
                    }
                    else
                    {
                        Console.WriteLine(digitMap[hunPart] + "  hundred and " + digitMap[decNumberFromMap] + " " + digitMap[decPartRem]);
                    }
                }
            }

        }
    }
}
