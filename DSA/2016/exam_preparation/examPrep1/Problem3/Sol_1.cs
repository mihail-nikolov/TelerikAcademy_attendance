//namespace Problem3
//{
//    using System;
//    using System.Numerics;
//    using System.Text.RegularExpressions;

//    class Sol_1
//    {
//        static void Main()
//        {
//            string word = Console.ReadLine();
//            string text = Console.ReadLine();
//            int finalResult = 0;
//            if (word.Length > 1)
//            {
//                for (int i = 1; i < word.Length; i++)
//                {
//                    int preffix = Count(text, word.Substring(0, i));
//                    int suffix = Count(text, word.Substring(i));
//                    //Console.WriteLine("{0} {1}", word.Substring(0, i), word.Substring(i));
//                    finalResult += preffix * suffix;
//                }
//            }
//            finalResult += Count(text, word);
//            Console.WriteLine(finalResult);
//        }

//        static int Count(string text, string pattern)
//        {
//            int count = 0;
//            int lastIndexMatch = 0;

//            while (lastIndexMatch < text.Length)
//            {
//                int index = text.IndexOf(pattern, lastIndexMatch);
//                if (index < 0)
//                {
//                    break;
//                }
//                count++;
//                lastIndexMatch = index + 1;
//            }

//            return count;
//        }
//    }
//}
