using System;


namespace bit_exchange_adv
{
    class BitExChAdv
    {
        static void swap(char[] arr, int pos1, int pos2)
        {
            //int thePos1 = (arr.Length - 1) - pos1;
            //int thePos2 = (arr.Length - 1) - pos2;
            char tmp = arr[pos1];
            arr[pos1] = arr[pos2];
            arr[pos2] = tmp;
        }
        static void Main()
        {
            int number = 1140867093;
            string numBin = Convert.ToString(number, 2).PadLeft(32, '0');
            Console.WriteLine("{0} --> {1}", number, numBin);
            char[] binArr = numBin.ToCharArray();
           
            int p = 3;
            int q = 24;
            int binPPos = (binArr.Length - 1) - p;
            int binQPos = (binArr.Length - 1) - q;
            int k = 3;
            int border1 = p + k - 1;
            int border2 = q + k - 1;
            if (border1 > (binArr.Length - 1) || border2 > (binArr.Length - 1))
            {
                Console.WriteLine("OUT OF RANGE");
                return;
            }
             if (((p > q) && border1 < q) || ((p < q) && border1 > q))
             {
                Console.WriteLine("The first and the second sequenceare overlapped.");
                return;
             }
            for (int i = binPPos; i >= (binArr.Length - 1) - border1; i--)
            {
                BitExChAdv.swap(binArr, i, binQPos);
                binQPos--;
            }
            Console.WriteLine("newBin --> {0}", new string(binArr));
            string newBinaryNum = new string(binArr);
            uint theNewN = Convert.ToUInt32(newBinaryNum, 2);
            Console.WriteLine("{0} --> {1}", newBinaryNum, theNewN);
        }
    }
}
