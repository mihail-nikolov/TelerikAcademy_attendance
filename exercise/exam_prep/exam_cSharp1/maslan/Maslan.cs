using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Maslan
{
    static void Main(string[] args)
    {
        string numStr = Console.ReadLine();
        //string numStr = "5353824709134486";
        int productOfSums = 1;
        int itCounter = 0;
        while (true)
        {
            int curSum = 0;
            numStr = numStr.Remove(numStr.Length - 1);
            if (numStr.Length == 0)
            {
                itCounter++;
                numStr = productOfSums.ToString();
                if (itCounter == 10)
                {
                    Console.WriteLine(numStr);
                    return;
                }
                if (numStr.Length == 1)
                {
                    Console.WriteLine(itCounter);
                    Console.WriteLine(numStr);
                    return;
                }
                else
                {
                    productOfSums = 1;
                    numStr = numStr.Remove(numStr.Length - 1);
                }
            }
            for (int i = 1; i <= numStr.Length - 1; i += 2)
            {
                curSum += (int)Char.GetNumericValue(numStr[i]);
            }
            if (curSum != 0)
            {
                productOfSums *= curSum;
            }
        }
    }
}

