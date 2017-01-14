using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 9. Delete odd lines

    Write a program that deletes from given text file all odd lines.
    The result should be in the same file.
*/
namespace _09.DelOddLines
{
    class DelOddLines
    {
        static void Main(string[] args)
        {
            string fileLocation = @"E:\my documents\telerik\2015\C# 2\textFiles\file1.txt";
            StreamReader reader = new StreamReader(fileLocation);
            string line = "";
            using (reader)
            {
                line = reader.ReadToEnd();
            }
            string[] lines = line.Split('\n');
            StreamWriter writer = new StreamWriter(fileLocation);
            using (writer)
            {
                for (int i = 0; i < lines.Length; i += 2)
                {
                    writer.WriteLine(lines[i]);
                }
            }
        }
    }
}
