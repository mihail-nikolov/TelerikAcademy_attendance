using System;
using System.Collections.Generic;
using System.Linq;
/*longest pat*/
namespace Diameter
{
    class Program
    {
        private static Node[] nodes;

        static void Main(string[] args)
        {
            ushort N = ushort.Parse(Console.ReadLine());
            //nodes = new List<Tuple<ushort, int>>[N];
            nodes = new Node[N];


            for (ushort i = 0; i < N - 1; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string node1 = line[0];
                ushort node1Number = ushort.Parse(node1);
                string node2 = line[1];
                ushort node2Number = ushort.Parse(node2);
                int distance = int.Parse(line[2]);

                if (nodes[node1Number] == null)
                {
                    nodes[node1Number] = new Node();
                }
                if (nodes[node2Number] == null)
                {
                    nodes[node2Number] = new Node();
                }

                nodes[node1Number].Children.Add(new Tuple<ushort, int>(node2Number, distance));
                nodes[node2Number].Children.Add(new Tuple<ushort, int>(node1Number, distance));
            }

            int[] path = new int[N];
            ushort farthest = 0;

            path[0] = 0;
            TraverseDFS(0, path);
            for (ushort i = 0; i < path.Length; i++)
            {
                if (path[farthest] < path[i])
                {
                    farthest = i;
                }
            }

            path = new int[N];

            TraverseDFS(farthest, path);
            Console.WriteLine(path.Max());
        }

        public static void TraverseDFS(ushort rootNumber, int[] path, ushort lastVisitedNode = 65000)
        {
            var root = nodes[rootNumber];

            foreach (var childTuple in root.Children)
            {
                var childNumber = childTuple.Item1;

                if (lastVisitedNode != childNumber)
                {
                    path[childNumber] = path[rootNumber] + childTuple.Item2;
                    TraverseDFS(childNumber, path, rootNumber);
                }
            }
        }

        //public static string GetEdge(ushort node1, ushort node2)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    if (node1 > node2)
        //    {
        //        sb.Append(node2);
        //        sb.Append(node1);
        //    }
        //    else
        //    {
        //        sb.Append(node1);
        //        sb.Append(node2);
        //    }
        //    return sb.ToString();
        //}
    }


    class Node
    {
        public Node()
        {
            this.Children = new List<Tuple<ushort, int>>(2);
            //this.Name = name;
        }

        //public ushort Name { get; set; }

        public List<Tuple<ushort,int>> Children { get; private set; }
    }
}