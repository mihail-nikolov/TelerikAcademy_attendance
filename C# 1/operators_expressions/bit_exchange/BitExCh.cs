using System;


namespace bit_exchange
{
    class BitExCh
    {
        static void swap(char[] arr, int pos1, int pos2)
        {
            int thePos1 = (arr.Length - 1) - pos1;
            int thePos2 = (arr.Length - 1) - pos2;
            char tmp = arr[thePos1];
            arr[thePos1] = arr[thePos2];
            arr[thePos2] = tmp;
        }
        static void Main()
        {
            int number = 5351;
            string numBin = Convert.ToString(number, 2).PadLeft(32, '0');
            Console.WriteLine("{0} --> {1}", number, numBin);
            char[] binArr = numBin.ToCharArray();

            BitExCh.swap(binArr, 3, 24);
            BitExCh.swap(binArr, 4, 25);
            BitExCh.swap(binArr, 5, 26);

            Console.WriteLine("newBin --> {0}", new string(binArr));
            string newBinaryNum = new string(binArr);
            uint theNewN = Convert.ToUInt32(newBinaryNum, 2);
            Console.WriteLine("{0} --> {1}", newBinaryNum, theNewN);
        }
    }
}
