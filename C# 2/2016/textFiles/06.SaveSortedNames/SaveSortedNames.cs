using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 6. Save sorted names

    Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
*/
namespace _06.SaveSortedNames
{
    class SaveSortedNames
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"E:\my documents\telerik\2015\C# 2\textFiles\file3.txt");
            StreamWriter writer = new StreamWriter(@"E:\my documents\telerik\2015\C# 2\textFiles\06.SaveSortedNames\written.txt");
            List<string> readFile = new List<string> { };
            using (reader)
            {
                readFile.Add(reader.ReadLine());
                while (reader.ReadLine() != null)
                {
                    readFile.Add(reader.ReadLine());
                }
            }
            readFile.Sort();
            using (writer)
            {

                for (int i = 0; i < readFile.Count; i++)
                {
                    writer.WriteLine(readFile[i]);
                }
            }
        }
    }
}
