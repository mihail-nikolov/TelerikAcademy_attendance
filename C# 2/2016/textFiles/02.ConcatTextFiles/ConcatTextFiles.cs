using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 2. Concatenate text files

    Write a program that concatenates two text files into another text file.
*/
namespace _02.ConcatTextFiles
{
    class ConcatTextFiles
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader(@"E:\my documents\telerik\2015\C# 2\textFiles\file1.txt");
            StreamReader reader2 = new StreamReader(@"E:\my documents\telerik\2015\C# 2\textFiles\file2.txt");
            StreamWriter writer = new StreamWriter(@"E:\my documents\telerik\2015\C# 2\textFiles\02.ConcatTextFiles\written.txt");
            string strToWrite = "";
            using (reader1)
            {
                strToWrite += reader1.ReadToEnd();
                Console.WriteLine(strToWrite);
            }
            using (reader2)
            {
                strToWrite += reader2.ReadToEnd();
                Console.WriteLine(strToWrite);
            }
            using (writer)
            {
                writer.Write(strToWrite);
            }
        }
    }
}
