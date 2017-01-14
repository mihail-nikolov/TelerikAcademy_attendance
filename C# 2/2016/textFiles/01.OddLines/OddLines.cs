using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 1. Odd lines

    Write a program that reads a text file and prints on the console its odd lines*/
namespace _01.OddLines
{
    class OddLines
    {
        static void Main()
        {
            string fileLocation = @"E:\my documents\telerik\2015\C# 2\textFiles\file1.txt";
            StreamReader reader = new StreamReader(fileLocation);
            using (reader)
            {
                string line = reader.ReadToEnd();
                string[] lines = line.Split('\n');
                for (int i = 0; i < lines.Length; i += 2)
                {
                    Console.WriteLine("Line {0}: {1}", i + 1, lines[i]);
                }
            }
        }
    }
}
