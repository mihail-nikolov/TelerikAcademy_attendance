using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 3. Line numbers

    Write a program that reads a text file and inserts line numbers in front of each of its lines.
    The result should be written to another text file.
*/
namespace _03.LineNums
{
    class LineNums
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"E:\my documents\telerik\2015\C# 2\textFiles\file1.txt");
            StreamWriter writer = new StreamWriter(@"E:\my documents\telerik\2015\C# 2\textFiles\03.LineNums\written.txt");
            List<string> readFile = new List<string> { };
            using (reader)
            {
                readFile.Add(reader.ReadLine());
                while (reader.ReadLine() != null)
                {
                    readFile.Add(reader.ReadLine());
                }
            }
            using (writer)
            {

                for (int i = 0; i < readFile.Count; i++)
                {
                    string strToWrite = (i + 1).ToString() + ") " + readFile[i];
                    writer.WriteLine(strToWrite);
                } 
            }
        }
    }
}
