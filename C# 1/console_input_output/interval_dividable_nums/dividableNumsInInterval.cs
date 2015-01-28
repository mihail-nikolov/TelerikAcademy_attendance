using System;


namespace interval_dividable_nums
{
    class dividableNumsInInterval
    {
        static void Main()
        {
            int counter = 0;
            int divNum = 5;
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            if (b < a)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }
            else if (a == b) 
            {
                Console.WriteLine("the nums must be different");
                return;
            }
            for (int i = a; i <= b; i++)
            {
                if (i % divNum == 0)
                {
                    counter++;
                }
            }
            Console.WriteLine("numbers divided by 5 are: {0}", counter);
        }
    }
}
