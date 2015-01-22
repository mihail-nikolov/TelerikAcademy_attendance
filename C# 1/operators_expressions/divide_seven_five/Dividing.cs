using System;


namespace divide_seven_five
{
    class Dividing
    {
        static void Main()
        {
            Console.Write("enter num: ");
            int num = int.Parse(Console.ReadLine());
            if (num % 7 == 0 && num % 5 == 0)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
