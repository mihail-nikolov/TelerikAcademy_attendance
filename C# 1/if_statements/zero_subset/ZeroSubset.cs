using System;


namespace zero_subset
{
    class ZeroSubset
    {
        static void Main()
        {
            int[] numArr = new int[5];
            int counter = 0;
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine("enter a number: ");
                int num = int.Parse(Console.ReadLine());
                numArr[i] = num;
            }
            for (int i1 = 0; i1 < numArr.Length - 1; i1++)
            {
                for (int i2 = i1 + 1; i2 < numArr.Length - 1; i2++)
                {
                    if ((numArr[i1] + numArr[i2]) == 0)
                    {
                        Console.WriteLine("{0} {1}", numArr[i1], numArr[i2]);
                        counter++;
                    }
                    for (int i3 = i1 + 2; i3 < numArr.Length - 1; i3++)
                    {
                        if ((numArr[i1] + numArr[i2] + numArr[i3]) == 0)
                        {
                            Console.WriteLine("{0} {1} {2}", numArr[i1], numArr[i2], numArr[i3]);
                            counter++;
                        }
                        for (int i4 = i1 + 3; i4 < numArr.Length - 1; i4++)
                        {
                            if ((numArr[i1] + numArr[i2] + numArr[i3] + numArr[i4]) == 0)
                            {
                                Console.WriteLine("{0} {1} {2} {3} ", numArr[i1], numArr[i2], numArr[i3], numArr[i4]);
                                counter++;
                            }
                            if ((numArr[i1] + numArr[i2] + numArr[i3] + numArr[i4] + numArr[numArr.Length - 1]) == 0)
                            {
                                Console.WriteLine("{0} {1} {2} {3} {4}", numArr[i1], numArr[i2], numArr[i3], numArr[i4], +numArr[numArr.Length - 1]);
                                counter++;
                            }

                        }
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("no zero subset");
            }
        }

        public static int counter { get; set; }
    }
}
