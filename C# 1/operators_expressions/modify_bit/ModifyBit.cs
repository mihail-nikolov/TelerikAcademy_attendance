using System;


namespace modify_bit
{
    class ModifyBit
    {
        static void Main()
        {
            int number = 5;
            string numBin = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine("{0} --> {1}", number, numBin);
            int position = 3;
            int v = 1;
            if (v != 0 && v != 1)
            {
                Console.WriteLine("v must be 0 or 1");
                return;
            }
            int thePos = (numBin.Length - 1) - position;
            char[] binArr = numBin.ToCharArray();
            Console.WriteLine("num at the pos {0} --> {1}", position, binArr[thePos]);
            binArr[thePos] = Char.Parse(v.ToString()); ;
            Console.WriteLine("newBin --> {0}", new string(binArr));
        }
    }
}
