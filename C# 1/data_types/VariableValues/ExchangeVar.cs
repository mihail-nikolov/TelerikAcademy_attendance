using System;


namespace VariableValues
{
    class ExchangeVar
    {
        static void Main()
        {
            int a = 5;
            int b = 10;
            int tmp;
            Console.WriteLine("before:\na = {0}\nb = {1}", a, b);
            
            tmp = a;
            a = b;
            b = tmp;
            Console.WriteLine("after:\na = {0}\nb = {1}", a, b);


        }
    }
}
