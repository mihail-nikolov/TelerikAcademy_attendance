using System;


namespace bit_pos
{
    class BitPosition
    {
        static void Main()
        {
            int number = 5343;
            string numBin = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine("{0} --> {1}", number, numBin);
            int position = 7;
            int v = 1;
            int thePos = (numBin.Length - 1) - position;
            int binPos = (numBin.Length - 1) - thePos;
            char[] binArr = numBin.ToCharArray();
            if ((int)Char.GetNumericValue(binArr[thePos]) == v)
            {
                Console.WriteLine(true);
                return;
            }
            Console.WriteLine(false);
        }
    }
}
