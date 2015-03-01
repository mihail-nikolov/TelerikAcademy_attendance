using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 24. Order words

    Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
*/
namespace _24.OrderWords
{
    class OrderWords
    {
        static void Main()
        {
            Console.Write("enter words splitted by spaces: ");
            string myStr = Console.ReadLine();
            string[] myStrArr = myStr.Split(' ');
            Array.Sort(myStrArr);
            string strForPrint = string.Join(", ", myStrArr);
            Console.WriteLine(strForPrint);
        }
    }
}
