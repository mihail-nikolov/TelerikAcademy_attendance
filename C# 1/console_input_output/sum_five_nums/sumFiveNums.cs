using System;


namespace sum_five_nums
{
    class sumFiveNums
    {
        static void Main()
        {
            double outputSum = 0;
            Console.Write("enter five nums: ");
            string strInput = Console.ReadLine();
            for (int i = 0; i < strInput.Length; i++)
            {
                if (char.IsDigit(strInput[i]))
                {
                    outputSum += double.Parse(strInput[i].ToString());
                }
            }
            Console.WriteLine("the sum is: {0}", outputSum);
        }
    }
}
