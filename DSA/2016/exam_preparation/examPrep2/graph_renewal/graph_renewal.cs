using System;
using System.Collections.Generic;

namespace graph_renewal
{
    class graph_renewal
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[,] existingRoads = FillRoadsMatrix(n);
            int[,] priceForBuilding = FillMatrixWithPrices(n);
            int[,] priceForDestroying = FillMatrixWithPrices(n);

            var cost = GetCost(existingRoads, priceForBuilding, priceForDestroying);
            Console.WriteLine(cost);
        }

        static int GetCost(bool[,] path, int[,] build, int[,] destroy)
        {
            int N = path.GetLength(0), totalCostToDestry = 0, totalCostTobuildFromBeggining = 0;
            // get the cost of each edge + destroy all the existing edges
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < N; ++i)
            {
                for (int j = i + 1; j < N; ++j)
                {
                    if (!path[i, j])
                    {
                        edges.Add(new Edge(i, j, build[i,j]));
                    }
                    else
                    {
                        int val = destroy[i, j];
                        // -val - if need to add the destroyed edge(path) again
                        edges.Add(new Edge(i, j, -val));
                        totalCostToDestry += val;
                    }
                }
            }

            // solve the MST on the graph, using Kruskal's algorithm
            edges.Sort();

            // before start connecting the vertices, make them all in different colour
            // same color => in one sub-graph
            // final result - make all vertices in one colour
            int[] color = new int[N];
            for (int i = 0; i < N; ++i)
            {
                color[i] = i;
            }

            for (int i = 0; i < edges.Count; ++i)
            {
                Edge e = edges[i];
                // vertices of the edge are not in the same component
                if (color[e.a] != color[e.b])
                {
                    totalCostTobuildFromBeggining += e.cost;

                    // recolor the component
                    int oldColor = color[e.b];
                    for (int j = 0; j < N; ++j)
                    {
                        if (color[j] == oldColor)
                        {
                            color[j] = color[e.a];
                        }
                    }
                }
            }

            // if a edge(path) is destroyed and added again (destroying was no needed -> val - val = 0)
            return totalCostToDestry + totalCostTobuildFromBeggining;
        }

        static bool[,] FillRoadsMatrix(int n)
        {
            bool[,] existingRoads = new bool[n, n];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '1')
                    {
                        existingRoads[i, j] = true;
                    }
                }
            }

            return existingRoads;
        }

        static int[,] FillMatrixWithPrices(int n)
        {
            int[,] priceForBuilding = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    priceForBuilding[i, j] = CalculatePrice(line[j]);
                }
            }

            return priceForBuilding;
        }

        //could be improved with dictionary
        //also can put in SB and convert int the end - compare chars in meantime
        static int CalculatePrice(char ch)
        {
            int takeOut = 65;

            if (Char.IsLower(ch))
            {
                takeOut = 71;
            }

            int number = (int)ch - takeOut;
            return number;
        }
    }

    class Edge : IComparable<Edge>
    {
        public int a;
        public int b;
        public int cost;

        public Edge(int a, int b, int cost)
        {
            this.a = a;
            this.b = b;
            this.cost = cost;
        }

        public int CompareTo(Edge e)
        {
            return cost - e.cost;
        }
    }
}
