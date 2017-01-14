﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxFullOfBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            var possibleBalls = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var secondLine = Console.ReadLine().Split(' ');
            int numberBallsMin = int.Parse(secondLine[0]);
            int numberBallsMax = int.Parse(secondLine[1]);
            int total = 0;

            bool[] isWins = new bool[numberBallsMax + 1];
            for (int i = 1; i <= numberBallsMax; i++)
            {
                foreach (var possibillity in possibleBalls)
                {
                    if (possibillity > i)
                    {
                        continue;
                    }
                    if (!isWins[i - possibillity])
                    {
                        isWins[i] = true;
                    }
                }
            }

            for (int i = numberBallsMin; i <= numberBallsMax; i++)
            {
                if (isWins[i])
                {
                    total++;
                }
            }

            Console.WriteLine(total);

        }
    }
}
