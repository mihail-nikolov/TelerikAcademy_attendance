using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Problem 10. Extract text from XML

    Write a program that extracts from given XML file all the text without the tags.
*/
namespace _10.ExtractTextFromHTML
{
    class ExtractTextFromHTML
    {
        static StringBuilder textWithoutTags = new StringBuilder();
        static void Main()
        {
            string pathXML = @"E:\my documents\telerik\2015\C# 2\textFiles\file5.xml";
            ExtractTextWithoutTags(pathXML);
            Console.WriteLine(textWithoutTags);
        }
        static void ExtractTextWithoutTags(string pathTextFile)
        {
            using (StreamReader reader = new StreamReader(pathTextFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = Regex.Replace(reader.ReadLine(), @"<[^>]*>", String.Empty).Trim();
                    if (line != "") textWithoutTags.AppendLine(line);
                }
            }
        }
    }
}
