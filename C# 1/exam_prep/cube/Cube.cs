using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cube
{
    class Cube
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int j = 1; j <= N; j++)
            {
                if (j == 1)
                {
                    for (int i = 1; i <= N; i++)
                    {
                        Console.Write(": ");
                    }
                    Console.Write("\n");
                }
                else if (j == N)
                {
                    for (int i = 1; i <= N; i++)
                    {
                        Console.Write(": ");
                    }
                    for (int i = 1; i < N; i++)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(":");
                    Console.Write("\n");
                }
                else
                {
                    for (int i = 1; i <= j + 1; i++)
                    {
                        if (i == 1 || i == j+1)
                        {
                            Console.Write(":");
                        }
                        else if (i > 1 && i < j+1)
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }
            
        }
    }
}
