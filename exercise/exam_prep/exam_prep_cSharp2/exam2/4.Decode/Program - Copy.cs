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
        static string[] SplitStr(string str)
        {
            int lastJIndex = 0;
            string[] splittedStr = new string[str.Length];
            bool flag = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == lastJIndex)
                {
                    for (int j = i; j < str.Length; j++)
                    {
                        if (str[j] != str[i])
                        {
                            //flag = true;
                            lastJIndex = j;
                            break;
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder(splittedStr[i]);
                            sb.Append(str[j]);
                            splittedStr[i] = sb.ToString();
                        }
                    }
                    if (flag) break;//if true -> leave the two loops! else only the nested one!!!
                }
            }
            splittedStr = splittedStr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return splittedStr;
        }
        static string Encode(string[] splittedStr)
        {
            StringBuilder encodedStr = new StringBuilder();
            for (int i = 0; i < splittedStr.Length; i++)
            {
                string tmpStr = splittedStr[i].Length.ToString() + splittedStr[i][0];
                if (tmpStr.Length < splittedStr[i].Length)
                {
                    encodedStr.Append(tmpStr);
                }
                else
                {
                    encodedStr.Append(splittedStr[i]);
                }
            }
            return encodedStr.ToString();
        }
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
                    char newSymbol = (char)((CYPHER.IndexOf(sb[i]) ^ CYPHER.IndexOf(cypher[cypherIndex])) + 65);
                    sb[i] = newSymbol;
                }
                else
                {
                   /* if (i > sb.Length - 1)
                    {
                        break;
                    }*/
                    int sbIndex = i % sb.Length;
                    char newSymbol = (char)((CYPHER.IndexOf(sb[sbIndex]) ^ CYPHER.IndexOf(cypher[i])) + 65);
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
        static string getTheCypher(string str)
        {
            StringBuilder sb = new StringBuilder(str);
        }
        static string clearTheCypher(string str, int cypherLen)
        {

        }
        static string Decode(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Remove(str.Length - 1, 1);
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (Char.IsDigit(sb[i]))
                {
                    int count = (int)Char.GetNumericValue(sb[i]);
                    for (int j = 0; j < length; j++)
                    {
                        
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Encrypt("PRTMU", "PQR"));
            Console.WriteLine();
            string encryptedText = Console.ReadLine();
            int cypherLen = encryptedText[encryptedText.Length - 1];
            //var regex = new Regex("^[A-Z]+$");
            //bool isContainsOnlyCapLetters = regex.IsMatch(text);
            //bool lenConstr = text.Length > 0 && text.Length <= 1500;
            //bool ASCIIConstrainAnsw = ASCIIConstrain(text);
            //if (isContainsOnlyCapLetters && lenConstr && ASCIIConstrainAnsw)
            //{
                //string[] splittedStr = SplitStr(text);
                //string encoded = Encode(splittedStr);
                //Console.WriteLine(encoded);
            //}
        }
    }
}
