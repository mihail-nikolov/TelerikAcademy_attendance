using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*Problem 8. Replace whole word

    Modify the solution of the previous problem to replace only whole words (not strings).
*/
namespace _08.ReplWholeWord
{
    class ReplWholeWord
    {
        static void Main()
        {
            string pathText = @"E:\my documents\telerik\2015\C# 2\textFiles\file6.txt";
            string pathResult = @"E:\my documents\telerik\2015\C# 2\textFiles\08.ReplWholeWord\written.txt";
            ReplaceAllWholeWords(pathText, pathResult);
        }
        static void ReplaceAllWholeWords(string pathText, string pathResult)
        {
            using (StreamWriter result = new StreamWriter(pathResult))
            {
                using (StreamReader reader = new StreamReader(pathText))
                {
                    while (!reader.EndOfStream)
                        result.WriteLine(Regex.Replace(reader.ReadLine(), @"\bstart\b", "finish"));
                }
            }
        }
    }
}
