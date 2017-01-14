namespace RecursiveNestedLoops
{
    using System;
    using System.Collections.Generic;

    // Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set.
    // Example: n= 3, k= 2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

    public static class CombinationsWithDuplicates
    {
        public static void Main()
        {
            var result = new List<string>();
            result.PutCombinations(1, 3, new int[2], 0);
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
                output.PutCombinations(number, endNumber, placeholder, index + 1);
            }
        }
    }
}
