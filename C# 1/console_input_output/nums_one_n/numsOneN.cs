using System;


namespace nums_one_n
{
    class numsOneN
    {
        static void Main()
        {
            //double outputSum = 0;
            Console.Write("n = ");
            string nInput = Console.ReadLine();
            int n = int.Parse(nInput);
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
