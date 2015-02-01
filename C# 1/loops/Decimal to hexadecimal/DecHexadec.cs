using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decimal_to_hexadecimal
{
    class DecHexadec
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            long num = long.Parse(Console.ReadLine());
            string[] hex = new string[32];
            int baseNum = 16;
            long rem;
            if (num == 0)
            {
                Console.WriteLine("0");
                return;
            }
            do
            {
                for (int i = 0; i < hex.Length; i++)
                {
                    if (num % baseNum < 10)
                    {
                        rem = num % baseNum;
                        num = num / baseNum;
                        hex[(hex.Length - 1) - i] = rem.ToString();
                    }
                    else
                    {
                        rem = num % baseNum;
                        num = num / baseNum;
                        switch (rem)
                        {
                            case 10: hex[(hex.Length - 1) - i] = "A"; break;
                            case 11: hex[(hex.Length - 1) - i] = "B"; break;
                            case 12: hex[(hex.Length - 1) - i] = "C"; break;
                            case 13: hex[(hex.Length - 1) - i] = "D"; break;
                            case 14: hex[(hex.Length - 1) - i] = "E"; break;
                            case 15: hex[(hex.Length - 1) - i] = "F"; break;
                        }
                    }
                }
            }
            while (num != 0);
            string hexStr = string.Join("", hex);
            string hexStrTr = hexStr.Trim('0');
            Console.WriteLine(hexStrTr);
        }
    }
}
