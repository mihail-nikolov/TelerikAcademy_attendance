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
            string fileLocation = @"E:\my documents\telerik\2015\C# 2\textFiles\all_kinds.txt";
            StreamReader reader = new StreamReader(fileLocation);
            using (reader)
            {
                string theFile = reader.ReadToEnd();
                string[] lines = theFile.Split('\n');
                string newPath = @"E:\lists\for_work\";
                foreach (var line in lines)
                {
                    if (!line.StartsWith("#"))
                    {
                        char separator = '\\';
                        string[] parsedFile = line.Split(separator);
                        string theFileName = parsedFile[parsedFile.Length - 1];
                        string theStrToCopy = @"E:" + line;
                        Console.WriteLine(theStrToCopy);
                        string theNewPlace = newPath + theFileName;
                        Console.WriteLine(theNewPlace);
                        File.Copy(theStrToCopy, theNewPlace);
                    }
                }
            }
        }
    }
}
