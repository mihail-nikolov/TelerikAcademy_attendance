using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*Problem 11. Prefix "test"

    Write a program that deletes from a text file all words that start with the prefix test.
    Words contain only the symbols 0…9, a…z, A…Z, _.
*/
namespace _11.PrefixTest
{
    class PrefixTest
    {
        static void Main()
        {
            string pathText = @"E:\my documents\telerik\2015\C# 2\textFiles\file7.txt";
            string pathResult = @"E:\my documents\telerik\2015\C# 2\textFiles\11.PrefixTest\written.txt";
            ExtractTextWithoutTags(pathText, pathResult);
        }
        static void ExtractTextWithoutTags(string pathText, string pathResult)
        {
            using (StreamWriter result = new StreamWriter(pathResult))
            {
                using (StreamReader reader = new StreamReader(pathText))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = Regex.Replace(reader.ReadLine(), @"\btest\S*", String.Empty).Trim();
                        result.Write(line);
                    }
                }
            }
        }
    }
}
