using System;

namespace Workshop_hw2
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var numbers = new long[N];

            for (int i = 0; i < N; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            int k = 0;

            while (k < N)
            {
                long number = numbers[k];
                int j = k + 1;
                int count = 1;

                while (numbers[j] == number)
                {
                    count++;
                    j++;

                    if (j == N)
                    {
                        break;
                    }
                }

                if (count % 2 == 1)
                {
                    Console.WriteLine(number);
                    return;
                }
                k = j;
            }
        }
    }
}

