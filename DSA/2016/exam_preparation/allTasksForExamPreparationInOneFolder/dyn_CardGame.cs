using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStr_Portals
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] cards = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int[,] intervals = new int[N, N];
            for (int length = 3; length <= N; length++)
            {
                for (int i = 0; i <= N - length; i++)
                {
                    for (int j = i + 1; j < i + length - 1; j++)
                    {
                        int currentPosition = intervals[i, j] + intervals[j, i + length - 1] + cards[j] * (cards[i] + cards[i + length - 1]);
                        intervals[i, i + length - 1] = Math.Max(intervals[i, i + length - 1], currentPosition);
                        //if (intervals[i, i + length - 1] < currentPosition)
                        //{
                        //    intervals[i, i + length - 1] = currentPosition;
                        //}
                    }
                }
            }
            Console.WriteLine(intervals[0, N - 1]);
        }

        //static int CalculatePoints(int cardIndex, List<int> cards)
        //{
        //    //if (cardIndex == 0 || cardIndex == cards.Count - 1)
        //    //{
        //    //    return 0;
        //    //}

        //    int answer = cards[cardIndex] * (cards[cardIndex - 1] + cards[cardIndex + 1]);
        //    return answer;
        //}
    }
}
