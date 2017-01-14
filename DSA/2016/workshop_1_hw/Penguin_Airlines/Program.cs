using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_Airlines
{
    class Program
    {
        static Node[] nodes;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            nodes = new Node[N];
            for (int i = 0; i < nodes.Length; i++)
            {
                var node = new Node(i);
                nodes[i] = node;

                var line = Console.ReadLine();
                if (line != "None")
                {
                    var children = line.Split(' ').Select(x => int.Parse(x)).ToArray();
                    foreach (var child in children)
                    {
                        node.Children.Add(child);
                    }
                }
            }

            bool[] visited = new bool[N];
            int[] components = new int[N];
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!visited[i])
                {
                    var node = nodes[i];
                    DFS(node, visited, components, i);
                }
            }

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Have a break")
                {
                    break;
                }

                var islands = line.Split(' ').Select(x => int.Parse(x)).ToArray();
                Node from = nodes[islands[0]];
                int to = islands[1];


                if (from.Children.Contains(to))
                {
                    Console.WriteLine("There is a direct flight.");
                }
                else
                {
                    if (components[from.Name] == components[to])
                    {
                        Console.WriteLine("There are flights, unfortunately they are not direct, grandma :(");
                    }
                    else
                    {
                        Console.WriteLine("No flights available.");
                    }
                }
            }

        }

        private static void DFS(Node from, bool[] visited, int[] components, int componentId)
        {
            visited[from.Name] = true;
            components[componentId] = componentId;

            foreach (var child in from.Children)
            {
                if (!visited[child])
                {
                    var childNode = nodes[child];
                    components[child] = componentId;
                    DFS(childNode, visited, components, componentId);
                }
            }
        }
    }

    class Node
    {
        public Node(int name)
        {
            this.Name = name;
            this.Children = new List<int>();
        }

        public int Name { get; set; }
        public List<int> Children { get; set; }
    }
}
