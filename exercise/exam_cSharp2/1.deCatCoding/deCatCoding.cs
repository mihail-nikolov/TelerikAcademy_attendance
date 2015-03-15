using System;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _1.deCatCoding
{
    class deCatCoding
    {
        static BigInteger[] ToDec(string[] str)
        {
            BigInteger[] outStr = new BigInteger[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                string word = str[i];
                BigInteger numInDec = 0;
                BigInteger thePow = 1;
                for (int j = word.Length - 1; j >= 0; j--)
                {
                    BigInteger numFromCurChar = ((int)word[j] - 97) * thePow;
                    numInDec += numFromCurChar;
                    thePow*=21;
                }
                outStr[i] = numInDec;
            }
            return outStr;
        }
        static string[] ToTwentySix(BigInteger[] arr)
        {
            string[] outStr = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                StringBuilder answer = new StringBuilder();
                BigInteger theNum = arr[i];
                while (theNum != 0)
                {
                    BigInteger numToParse = (theNum % 26) + 97;
                    answer.Append((char)numToParse);
                    theNum /= 26;
                }
                char[] ansArr = answer.ToString().ToCharArray();
                Array.Reverse(ansArr);
                outStr[i] = new string(ansArr);
            }
            return outStr;
        }
        static void Main()
        {
            string input = Console.ReadLine();
            string[] inputArr = input.Split(' ');
            BigInteger[] toDec = ToDec(inputArr);
            string[] outputArr = ToTwentySix(toDec);
            string strForPrint = string.Join(" ", outputArr);
            Console.WriteLine(strForPrint);
        }
    }
}




