namespace RecursiveNestedLoops
{
    using System;

    // Write a recursive program that simulates the execution of n nested loops from 1 to n.
    // Example: n=2 --> 1 1/1 2/2 1/2 2
    public class RecursiveNestedLoops
    {
        public static int numberOfLoops;

        public static int numberOfIterations;

        public static int[] loops;

        public static void Main()
        {
            Console.Write("N = ");
            numberOfLoops = int.Parse(Console.ReadLine());
            numberOfIterations = numberOfLoops;

            loops = new int[numberOfLoops];
            NestedLoops(0);
        }

        public static void NestedLoops(int currentLoop)
        {
            if (currentLoop == numberOfLoops)
            {
                PrintLoops();
                return;
            }

            for (int counter = 1; counter <= numberOfIterations; counter++)
            {
                loops[currentLoop] = counter;
                NestedLoops(currentLoop + 1);
            }
        }

        public static void PrintLoops()
        {
            for (int i = 0; i < numberOfLoops; i++)
            {
                Console.Write("{0} ", loops[i]);
            }

            Console.WriteLine();
        }
    }
}
