using System;


namespace odd_even
{
    class OddEvene
    {
        static void Main()
        {
            Console.Write("enter the number: ");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 != 0)
            {
                Console.WriteLine("the num is ODD");
            }
            else
            {
                Console.WriteLine("the num is Even");
            }

        }
    }
}
