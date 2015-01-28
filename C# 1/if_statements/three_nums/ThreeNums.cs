using System;


namespace three_nums
{
    class ThreeNums
    {
        static void Main()
        {
            double[] numsArr = new double[3];
            double answer = 0;
            for (int i = 0; i <= numsArr.Length - 1; i++)
            {
                Console.Write("enter num: ");
                double n = double.Parse(Console.ReadLine());
                numsArr[i] = n;
            }
            answer = numsArr[0];
            for (int i = 1; i <= numsArr.Length - 1; i++)
            {
                if (numsArr[i] > answer)
                {
                    answer = numsArr[i];
                }
            }
            Console.WriteLine("the biggest num is: {0}", answer);
                
        }
    }
}
