namespace Problem3
{
    using System;
    using System.Numerics;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            BigInteger finalResult = 0;
            if (word.Length > 1)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (i != 0)
                    {
                        BigInteger preffix = Regex.Matches(text, word.Substring(0, i)).Count;
                        BigInteger suffix = Regex.Matches(text, word.Substring(i)).Count;
                        Console.WriteLine("{0} {1}", word.Substring(0, i), word.Substring(i));
                        finalResult += preffix * suffix;
                    }
                }
            }
            finalResult += Regex.Matches(text, word).Count;
            Console.WriteLine(finalResult);
        }
    }
}
