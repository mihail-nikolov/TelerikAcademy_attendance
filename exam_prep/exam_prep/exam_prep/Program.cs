using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_prep
{
    class Program
    {
        static int countingChars(string numStr)
        {
            int counter = 0;
            if (!numStr.Contains('.'))
            {
                return counter;
            }
            for (int i = numStr.Length - 1; i >= 0; i--)
            {
                if (numStr[i] == '.')
                {
                    break;
                }
                counter++;
            }
            return counter;
        }
        static bool checkValidity(int n)
        {
            if (n <= 2)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int i = 100000;
            Console.WriteLine(i);
            double A = 2.00;
            Console.WriteLine(A);
            string Astring = A.ToString();
            int counter = Program.countingChars(Astring);
            Console.WriteLine(counter);
            bool answer = Program.checkValidity(counter);
            Console.WriteLine(answer);

        }
    }
}
