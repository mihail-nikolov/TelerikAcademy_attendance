using System;


namespace digit_word
{
    class digit_word
    {
        static void Main()
        {
            Console.Write("a = ");
            string a = Console.ReadLine();
            string theWord;
            switch (a)
            {
                case "0": theWord = "zero"; break;
                case "1": theWord = "one"; break;
                case "2": theWord = "two"; break;
                case "3": theWord = "three"; break;
                case "4": theWord = "four"; break;
                case "5": theWord = "five"; break;
                case "6": theWord = "six"; break;
                case "7": theWord = "seven"; break;
                case "8": theWord = "eight"; break;
                case "9": theWord = "nine"; break;
                default: theWord = "not a digit"; break;
            }
            Console.WriteLine("sorted nums are {0} --> {1}", a, theWord);
        }
    }
}
