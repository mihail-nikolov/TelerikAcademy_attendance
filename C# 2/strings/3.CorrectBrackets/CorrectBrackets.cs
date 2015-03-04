using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 3. Correct brackets

    Write a program to check if in a given expression the brackets are put correctly.

Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).*/
namespace _3.CorrectBrackets
{
    class CorrectBrackets
    {
        static void Main()
        {
            string expression = "((a+b))";
            char opening = '(';
            char closing = ')';
            int count = 0;
            for (int i = 0; i < expression.Length - 2; i++)
            {
                if (expression[i] == opening)
                {
                    count++;
                }
            }
            for (int i = expression.Length - 1; i > 0; i--)
            {
                if (expression[i] == closing)
                {
                    count--;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("correct!");
            }
            else
            {
                Console.WriteLine("NOT correct!");
            }
        }
    }
}
