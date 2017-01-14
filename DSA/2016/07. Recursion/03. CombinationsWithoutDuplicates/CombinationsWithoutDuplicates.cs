using System;
using System.Collections.Generic;

namespace _03.CombinationsWithoutDuplicates
{
    public static class CombinationsWithoutDuplicates
    {
        // Modify the previous program to skip duplicates:
        // n=4, k=2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
        public static void Main()
        {
            var result = new List<string>();
            result.PutCombinations(1, 4, new int[2], 0);
            Console.WriteLine(string.Join(", ", result));
        }

        private static void PutCombinations(this IList<string> output, int startNumber, int endNumber, int[] placeholder, int index)
        {
            if (index == placeholder.Length)
            {
                output.Add(string.Format("({0})", string.Join(" ", placeholder)));
                return;
            }

            for (var number = startNumber; number <= endNumber; number++)
            {
                placeholder[index] = number;
                output.PutCombinations(number + 1, endNumber, placeholder, index + 1);
            }
        }
    }
}
