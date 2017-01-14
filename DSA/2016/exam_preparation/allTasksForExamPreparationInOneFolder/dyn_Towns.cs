namespace Problem4
{
    using System;

    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            var towns = new int[N];
            for (int i = 0; i < N; i++)
            {
                string[] line = new string[2];
                line = Console.ReadLine().Split(' ');
                towns[i] = int.Parse(line[0]);
            }

            int answer = Solve(towns);
            Console.WriteLine(answer);
        }

        private static int Solve(int[] towns)
        {
            var leftToRight = new int[towns.Length];
            
            for (int i = 0; i < leftToRight.Length; i++)
            {
                int maxLen = 0;
                for (int j = 0; j < i; j++)
                {
                    if (towns[j] < towns[i])
                    {
                        maxLen = Math.Max(maxLen, leftToRight[j]);
                    }
                }
                leftToRight[i] = maxLen + 1;
            }

            var RightToLeft = new int[towns.Length];
            for (int i = RightToLeft.Length - 1; i >= 0; i--)
            {
                int maxLen = 0;
                for (int j = RightToLeft.Length - 1; j > i; j--)
                {
                    if (towns[j] < towns[i])
                    {
                        maxLen = Math.Max(maxLen, RightToLeft[j]);
                    }
                }
                RightToLeft[i] = maxLen + 1;
            }
            int result = 0;
            for (int i = 0; i < towns.Length; i++)
            {
                result = Math.Max(result, leftToRight[i] + RightToLeft[i] - 1);
            }
            return result;
        }
    }
}
/*
Problem 4 – Towns
You are given N towns and you should find a path in them that satisfies few conditions. In each of the towns there are fixed number of citizens (between 1 and 1,000,000,000, inclusive).
The towns can be visited only in the order they are given on the console. You are not obligated to start the traversing from the first town. You can also skip some of the towns but you are not allowed to visit a town more than once.
For example if we have towns Sofia, Plovdiv, Varna and Burgas you can visit:
•	Sofia, Varna, Burgas (by skipping Plovdiv)
•	Plovdiv, Burgas (by starting from Plovdiv and skipping Varna)
•	Sofia, Plovdiv, Varna, Burgas (by visiting every town)
•	etc.
You are not allowed to visit the towns in wrong order. For example:
•	Varna, Sofia is not allowed because Varna should be visited after Sofia in the given order
•	Sofia, Varna, Sofia is not allowed because you are visiting Sofia for a second time
•	etc.
You should satisfy one more condition when traversing towns. If you divide the path into 2 sub-paths that share one common town (part of the original path) such that the last town of the first path is the first town of the second path, then all number of citizens in the first path should be in ascending order and all number of citizens (increasing number of citizens) in the second path should be in descending order (decreasing number of citizens). Yeah.
For example look at the first example below. The path Pleven, Burgas, Varna, Sofia, Ruse, StaraZagora satisfies this condition (in fact, it satisfies all conditions) because we can divide the path into 2 sub-paths (first: Pleven, Burgas, Varna, Sofia; second: Sofia, Ruse, StaraZagora) and the first path has increasing number of citizens and the second path has decreasing number of citizens.
Write a program that finds the longest path that satisfies the given conditions.

*/