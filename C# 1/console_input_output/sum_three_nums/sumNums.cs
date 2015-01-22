using System;


namespace sum_three_nums
{
    class sumNums
    {
        static void Main()
        {
            Console.WriteLine("new_num is: {0}", new_nm);
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());
            double sum = a + b + c;
            Console.WriteLine("sum = {0}", sum);
        }
    }
}
