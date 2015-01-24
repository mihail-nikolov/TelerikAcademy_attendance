using System;


namespace BitWise
{
    class BitWise
    {
        static void Main()
        {
            int number = 5;
            string numBin = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine("{0} --> {1}", number, numBin);
            int position = 3;
            int mask = 1 << position;
            int numbAndMask = number & mask;
            int bit = numbAndMask >> position;
            Console.WriteLine("bit at pos. {0} is {1}", position, bit);
        }
    }
}
