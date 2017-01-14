namespace Problem3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Sol_2
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            //var lps = ComputePartialMatchTable(word);
            //Console.WriteLine(string.Join(" ", lps));
            var prefixMatches = new int[word.Length + 1];
            KMP(text, word, prefixMatches);

            string reversedWord = new string(word.Reverse().ToArray());
            string reversedText = new string(text.Reverse().ToArray());
            var suffixMatches = new int[word.Length + 1];

            KMP(reversedText, reversedWord, suffixMatches);

            int total = prefixMatches[word.Length];
            for (int i = 1; i < word.Length; i++)
            {
                total += prefixMatches[i] * suffixMatches[word.Length - i];
            }

            Console.WriteLine(total);
        }

        public static List<int> KMP(string text, string pattern, int[] prefixMatches)
        {
            List<int> matches = new List<int>();
            int[] partialMatches = ComputePartialMatchTable(pattern);

            int matched = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (matched != -1 && pattern[matched] != text[i])
                {
                    matched = partialMatches[matched];
                }

                matched++;

                for (int j = matched; j > 0; j = partialMatches[j])
                {
                    prefixMatches[j]++;
                    //string matchedStr = pattern.Substring(0, j); 
                    //Console.WriteLine(new string(' ', i - matchedStr.Length + 1)+ matchedStr);
                }

                if (pattern.Length == matched)
                {
                    matches.Add(i - matched + 1);
                    matched = partialMatches[matched];
                }
            }

            return matches;
        }

        private static int[] ComputePartialMatchTable(string pattern)
        {
            var partialMatches = new int[pattern.Length + 1];
            partialMatches[0] = -1;
            partialMatches[1] = 0;

            for (int i = 1; i < pattern.Length; i++)
            {
                int failLink = partialMatches[i];
                while (failLink != -1)
                {
                    if (pattern[i] == pattern[failLink])
                    {
                        break;
                    }
                    failLink = partialMatches[failLink];
                }

                partialMatches[i + 1] = failLink + 1;
            }

            return partialMatches;
        }
    }
}
