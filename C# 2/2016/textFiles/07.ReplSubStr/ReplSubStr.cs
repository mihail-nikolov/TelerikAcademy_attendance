using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 7. Replace sub-string

    Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
    Ensure it will work with large files (e.g. 100 MB).
*/
namespace _07.ReplSubStr
{
    class ReplSubStr
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader(@"E:\my documents\telerik\2015\C# 2\textFiles\file4.txt");
            StreamWriter writer = new StreamWriter(@"E:\my documents\telerik\2015\C# 2\textFiles\07.ReplSubStr\written.txt");
            string strToWrite = "";
            using (reader1)
            {
                strToWrite += reader1.ReadToEnd();
                Console.WriteLine(strToWrite);
            }
            strToWrite = strToWrite.Replace("start", "finish");

            Console.WriteLine(strToWrite);
            using (writer)
            {
                writer.Write(strToWrite);
            }
        }
    }
}
