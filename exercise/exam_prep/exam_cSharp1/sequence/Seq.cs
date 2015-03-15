using System;



class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int maxzeroes = 0;
        int maxones = 0;
        string bitNums = "";
        for (int i = 0; i < N; i++)
        {
            int num = int.Parse(Console.ReadLine());
            string numBin = Convert.ToString(num, 2).PadLeft(30, '0');
            bitNums = String.Concat(bitNums, numBin);
        }
        for (int i = 0; i < bitNums.Length; i++)
        {
            if (bitNums[i] == '1')
            {
                int tmpOne = 0;
                for (int j = i; j < bitNums.Length; j++)
                {
                    if (bitNums[j] == '1')
                    {
                        tmpOne++;
                    }
                    else
                    {
                        if (tmpOne > maxones)
                        {
                            maxones = tmpOne;
                        }
                        break;
                    }
                }
            }
            else
            {
                int tmpZero = 0;
                for (int j = i; j < bitNums.Length; j++)
                {
                    if (bitNums[j] == '0')
                    {
                        tmpZero++;
                    }
                    else
                    {
                        if (tmpZero > maxzeroes)
                        {
                            maxzeroes = tmpZero;
                        }
                        break;
                    }
                }
            }
        }
        Console.WriteLine(maxones);
        Console.WriteLine(maxzeroes);
    }


}