using System;
using System.Collections.Generic;
using System.Data;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            //Console.WriteLine(254 & 488 );
            //Console.WriteLine();
            //Console.WriteLine();
            try
            {
                int answer = CalculateRPN(expression);
                Console.WriteLine(answer);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static int CalculateRPN(string expression)
        {
            var expressionArr = expression.Split(' ');
            var numbers = new Stack<int>();
            DataTable dt = new DataTable();

            foreach (var item in expressionArr)
            {
                int number;
                bool isNumeric = int.TryParse(item, out number);
                if (isNumeric)
                {
                    numbers.Push(number);
                }
                else
                {
                    int secondNumber = numbers.Pop();
                    int firstNumber = numbers.Pop();
                    int answer = 0;

                    switch (item)
                    {
                        case "&":
                            answer = firstNumber & secondNumber;
                            break;
                        case "|":
                            answer = firstNumber | secondNumber;
                            break;
                        case "^":
                            answer = firstNumber ^ secondNumber;
                            break;
                        case "+":
                            answer = firstNumber + secondNumber;
                            break;
                        case "-":
                            answer = firstNumber - secondNumber;
                            break;
                        case "*":
                            answer = firstNumber * secondNumber;
                            break;
                        case "/":
                            answer = firstNumber / secondNumber;
                            break;

                        default:
                            throw new ArgumentException("wrong operator parameter");
                    }
                    
                    numbers.Push(answer);
                }
            }

            if (numbers.Count > 1)
            {
                throw new ArithmeticException("error calculation");
            }

            return numbers.Peek();
        }
    }
}
