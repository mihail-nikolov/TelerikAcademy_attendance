using System;


namespace multiplication_sign
{
    class MultiSign
    {
        static void Main()
        {
            int counter = 0;
            string answer = "";
            double[] numsArr = new double[3];
            for (int i = 0; i <= 2; i++)
            {
                Console.Write("enter num: ");
                double n = double.Parse(Console.ReadLine());
                numsArr[i] = n;
            }
            for (int i = 0; i <= numsArr.Length - 1; i++)
            {
                if (numsArr[i] == 0)
                {
                    answer = "0";
                    Console.WriteLine("the sign is {0}", answer);
                    return;
                }
                else if (numsArr[i] < 0)
                {
                    counter++;
                }
            }
            if (counter % 2 == 0)
            {
                answer = "+";
            }
            else
            {
                answer = "-";
            }
            Console.WriteLine("the sign is {0}", answer);
        }
    }
}
