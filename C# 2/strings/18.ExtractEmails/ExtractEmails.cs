using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 18. Extract e-mails

    Write a program for extracting all email addresses from given text.
    All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.
*/
namespace _18.ExtractEmails
{
    class ExtractEmails
    {
        static void Main()
        {
            string text = "Please contact us by phone (+001 222 222 222) or by email at example@gmail.com or at test.user@yahoo.co.uk. This is not email: test@test. This also: @gmail.com. Neither this: a@a.b.";
            string[] words = text.Split(' ');
            string emailSymbol = "@";
            string emailDomain = ".";
            List<string> emails = new List<string> { };
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(emailSymbol) && (words[i].IndexOf(emailSymbol) >= 2) && (words[i].IndexOf(emailDomain) < words[i].Length - 2))
                {
                    words[i] = words[i].TrimEnd('.');
                    emails.Add(words[i]);
                    Console.WriteLine(words[i]);
                }
            }
        }
    }
}
