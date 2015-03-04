using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 7. Encode/decode

    Write a program that encodes and decodes a string using given encryption key (cipher).
    The key consists of a sequence of characters.
    The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.
*/
namespace _7.EncodeDecode
{
    class EncodeDecode
    {
        static void Main()
        {
            string myStr = "Test";
            Console.WriteLine(myStr);
            string key = "ab";
            string decoded = "";
            string encoded = "";
            int keyLen = key.Length;
            for (int i = 0; i < myStr.Length; i++)
            {
                encoded += (char)(myStr[i] ^ key[i%keyLen]);
            }
            Console.WriteLine(encoded);
            for (int j = 0; j < encoded.Length; j++)
            {
                decoded += (char)(encoded[j] ^ key[j % keyLen]);
            }
            Console.WriteLine(decoded);

        }
    }
}
