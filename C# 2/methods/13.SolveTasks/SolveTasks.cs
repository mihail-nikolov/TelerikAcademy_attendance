using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
/*Problem 13. Solve tasks

    Write a program that can solve these tasks:
        Reverses the digits of a number
        Calculates the average of a sequence of integers
        Solves a linear equation a * x + b = 0
    Create appropriate methods.
    Provide a simple text-based menu for the user to choose which task to solve.
    Validate the input data:
        The decimal number should be non-negative
        The sequence should not be empty
        a should not be equal to 0
*/
namespace _13.SolveTasks
{

    class SolveTasks
    {
        static int[] GetSequenceInt(int n)
        {
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("num = ");
                int theNum = int.Parse(Console.ReadLine());
                nums[i] = theNum;
            }
            return nums;
        }
        static bool ValidateSeq(int n)
        {
            bool answer = true;
            if (n <= 0)
            {
                answer = false;
            }
            return answer;
        }
        static string CalcAv(int[] nums)
        {
            int sum = nums.Sum();
            int average = sum / nums.Length;
            return average.ToString();
        }
        static string Reverse(double num)
        {
            string numStr = num.ToString();
            string reversedNum = "";
            for (int i = numStr.Length - 1; i >= 0; i--)
            {
                reversedNum += numStr[i];
            }
            return reversedNum;
        }
        static bool ValidateReverser(double n)
        {
            bool answer = true;
            if (n < 0)
            {
                answer = false;
            }
            return answer;
        }
        static string LinearSolver(double a, double b)
        {
            double x = -b / a;
            return x.ToString();
        }
        static bool ValidateLinearSolver(double a)
        {
            bool answer = true;
            if (a == 0)
            {
                answer = false;
            }
            return answer;
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("1.Reverses the digits of a number");
            Console.WriteLine("2.Calculates the average of a sequence of integers");
            Console.WriteLine("3.Solves a linear equation a * x + b = 0");
            Console.Write("your choice: ");
            int usrChoice = int.Parse(Console.ReadLine());
            switch (usrChoice)
            {
                case 1:
                    Console.Write("please enter num = ");
                    double num = double.Parse(Console.ReadLine());
                    if (ValidateReverser(num))
                    {
                        string reversedNum = Reverse(num);
                        Console.WriteLine("{0} --> {1}", num, reversedNum);
                    }
                    else
                    {
                        Console.WriteLine("the num should be > 0");
                    }
                    break;
                case 2:
                    Console.Write("please enter the length n = ");
                    int n = int.Parse(Console.ReadLine());
                    if (ValidateSeq(n))
                    {
                        int[] nums = GetSequenceInt(n);
                        string average = CalcAv(nums);
                        Console.WriteLine("the average is {0}", average);
                    }
                    else
                    {
                        Console.WriteLine("the sequence must be with length > 0");
                    }
                    break;
                case 3:
                    Console.WriteLine("enter the parameters a and b a*x + b = 0: ");
                    Console.Write("a = ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    double b = double.Parse(Console.ReadLine());
                    if (ValidateLinearSolver(a))
                    {
                        string answer = LinearSolver(a, b);
                        Console.WriteLine("the average is {0}", answer);
                    }
                    else
                    {
                        Console.WriteLine("a must be > 0");
                    }
                    break;
                default: Console.WriteLine("you should enter choice 1-3");
                    break;
            }
        }
    }
}
