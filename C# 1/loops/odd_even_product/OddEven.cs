using System;


namespace odd_even_product
{
    class OddEven
    {
        static void Main()
        {
            Console.Write("enter numbers separated by space: ");
            string strNums = Console.ReadLine();
            string[] splStrNums = strNums.Split(' ');
            int[] myIntNums = Array.ConvertAll(splStrNums, int.Parse);
            int evenPr = 1;
            int oddPro = 1;
            for (int i = 0; i <= myIntNums.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    oddPro *= myIntNums[i];
                }
                else
                {
                    evenPr *= myIntNums[i];
                }
            }
            if (evenPr == oddPro)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

    }
}
