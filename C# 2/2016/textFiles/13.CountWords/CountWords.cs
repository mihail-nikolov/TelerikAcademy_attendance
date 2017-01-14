using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 13. Count words

    Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file test.txt.
    The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
    Handle all possible exceptions in your methods.
*/
namespace _13.CountWords
{
    class CountWords
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader(@"E:\my documents\telerik\2015\C# 2\textFiles\file1.txt");
            StreamReader reader2 = new StreamReader(@"E:\my documents\telerik\2015\C# 2\textFiles\file2.txt");
            StreamWriter writer = new StreamWriter(@"E:\my documents\telerik\2015\C# 2\textFiles\02.ConcatTextFiles\written.txt");
            using()
        }
    }
}
