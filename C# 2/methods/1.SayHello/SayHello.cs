using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 1. Say Hello

    Write a method that asks the user for his name and prints “Hello, <name>”
    Write a program to test this method.
*/
namespace _1.SayHello
{
    class SayHello
    {
        static string[] SayHelloMethod()
        {
            Console.WriteLine("enter your name");
            string name = Console.ReadLine();
            string strForPrint = "Hello " + name;
            string[] output = { strForPrint, name };
            Console.WriteLine(strForPrint);
            return output;
        }
        static bool testSayHelloMethod(string[] output)
        {
            string theCorrectStr = "Hello " + output[1];
            if (theCorrectStr == output[0])
            {
                return true;
            }
            return false;
        }
        static void Main()
        {
            string[] output = SayHelloMethod();
            bool answer = testSayHelloMethod(output);
            Console.WriteLine("the method works correctly: {0}", answer);
        }
    }
}
