namespace SetOfWords
{
    using System;
    using System.IO;
    using System.Linq;
    /// <summary>
    /// Source: http://geekyisawesome.blogspot.bg/2015/04/new-and-improved-c-trie.html
    /// </summary>
    using Triepocalypse;

    //Write a program that finds a set of words(e.g. 1000 words) in a large text(e.g. 100 MB text file).

    //Print how many times each word occurs in the text.
    //Hint: you may find a C# trie in Internet.
    public class Program
    {
        static void Main()
        {           
            Trie<int> trie = new Trie<int>();

            using (StreamReader reader = new StreamReader("..\\..\\text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    reader
                        .ReadLine()
                        .Split(' ', '.', ',', '?', '!', ':')
                        .ToList()
                        .ForEach(word =>
                        {
                            if (!trie.ContainsKey(word))
                            {
                                trie.Add(word, 1);
                            }
                            else
                            {
                                trie[word] += 1;
                            }
                        });
                }
            }
            foreach (var item in trie)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
    }
}
