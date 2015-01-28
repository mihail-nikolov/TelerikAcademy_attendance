using System;


namespace sum_n_nums
{
    class sumNNums
    {
        static void Main()
        {
            double outputSum = 0;
            Console.Write("n = ");
            string nInput = Console.ReadLine();
            int n = int.Parse(nInput);
            for (int i = 1; i <= n; i++)
            {
                Console.Write("n = ");
                string aNum = Console.ReadLine();
                int curNum = int.Parse(aNum);
                outputSum += curNum;
            }
            Console.WriteLine("the sum is: {0}", outputSum);
        }
    }
}
