using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Decode
{
    class Program
    {
        public static string CYPHER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static string Encrypt(string text, string cypher)
        {
            StringBuilder sb = new StringBuilder(text);
            int maxLen = Math.Max(sb.Length, cypher.Length);
            int diff = Math.Abs(sb.Length - cypher.Length);
            for (int i = 0; i < maxLen; i++)
            {
                if (sb.Length > cypher.Length)
                {
                    int cypherIndex = i % cypher.Length;
                    int fIndex = (int)sb[i] - 65;
                    int sIndex = (int)cypher[cypherIndex] - 65;
                    char newSymbol = (char)((fIndex ^ sIndex) + 65);
                    sb[i] = newSymbol;
                }
                else
                {
                    int sbIndex = i % sb.Length;
                    int fIndex = (int)sb[sbIndex] - 65;
                    int sIndex = (int)cypher[i] - 65;
                    char newSymbol = (char)((fIndex ^ sIndex) + 65);
                    sb[sbIndex] = newSymbol;
                }

            }
            return sb.ToString();
        }
        static bool ASCIIConstrain(string text)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
            foreach (var item in asciiBytes)
            {
                if (item < 65 || item > 127)
                {
                    return false;
                }
            }
            return true;
        }
        static string getTheCypher(string str, int cypherLen)
        {
            int startIndex = str.Length - cypherLen;
            StringBuilder sb = new StringBuilder();
            for (int i = startIndex; i < str.Length; i++)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
        static string clearTheCypher(string str, int cypherLen)
        {
            int endIndex = str.Length - cypherLen;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < endIndex; i++)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
        static string clearTheCypherLen(string str, int cypherLen)
        {
            int posToCleaer = str.Length - cypherLen.ToString().Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < posToCleaer; i++)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
        static string Decode(string str)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    count *= 10;
                    count += (int)char.GetNumericValue(str[i]);
                }
                else
                {
                    if (count == 0)
                    {
                        sb.Append(str[i]);
                    }
                    else
                    {
                        sb.Append(str[i], count);
                        count = 0;
                    }
                }
            }
            return sb.ToString();
        }
        static int getTheCypherLen(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(str[i]))
                {
                    break;
                }
                sb.Append(str[i]);
            }
            string sbStr = sb.ToString();
            char[] charArray = sbStr.ToCharArray();
            Array.Reverse(charArray);
            string theLen = new string(charArray);
            return int.Parse(theLen);
        }
        static void Main(string[] args)
        {
            string encryptedText = Console.ReadLine();
            int cypherLen = getTheCypherLen(encryptedText);
            string strToDecode = clearTheCypherLen(encryptedText, cypherLen);
            string decoded = Decode(strToDecode);
            string cypher = getTheCypher(decoded, cypherLen);
            string cleanMassage = clearTheCypher(decoded, cypherLen);
            string decrypted = Encrypt(cleanMassage, cypher);
            Console.WriteLine(decrypted);
        }
    }
}
