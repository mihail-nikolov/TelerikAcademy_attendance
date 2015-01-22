using System;


namespace prime_num_check
{
    class PrimeNumCheck
    {
        static void Main()
        {
            Console.Write("enter number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("the number {0} is", number);
            if (number == 1 && number == 0)
            {
                Console.WriteLine("NOT Prime");
            }
            else
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        Console.WriteLine("NOT Prime");
                        return;
                    }
                }
                Console.WriteLine("Prime");
            }
        }
    }
}
