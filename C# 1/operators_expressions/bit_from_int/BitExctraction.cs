using System;


namespace bit_from_int
{
    class BitExctraction
    {
        static void Main()
        {
            int number = 62241;
            string numBin = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine("{0} --> {1}", number, numBin);
            int position = 11;
            char theBit = numBin[numBin.Length - position - 1];
            Console.WriteLine("bit at pos. {0} is {1}", position, theBit);
        }
    }
}
