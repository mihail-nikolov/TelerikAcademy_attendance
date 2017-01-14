using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Problem 25. Extract text from HTML

    Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags*/
namespace _25.ExtractTextFromHTML
{
    class ExtractTextFromHTML
    {
        static string ExtractHtmlInnerText(string htmlText)
        {
            Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);
            string resultText = regex.Replace(htmlText, " ").Trim();
            return resultText;
        }
        static void Main()
        {
            string myHTML = @"<html>
<head><title>News</title></head>
<body><p><a href=""http://academy.telerik.com\"">Telerik
Academy</a>aims to provide free real-world practical
training for young people who want to turn into
skilful .NET software engineers.</p></body>
</html>";
            string newStr = ExtractHtmlInnerText(myHTML);
            Console.WriteLine(newStr);
        }
    }
}
