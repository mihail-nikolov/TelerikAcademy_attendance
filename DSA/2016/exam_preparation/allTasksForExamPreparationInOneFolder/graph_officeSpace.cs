namespace Problem2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    /* Topological sorting */
    class Sol_2
    {
        private static List<Node> nodes;

        public static void Main(string[] args)
        {
            int numberTasks = int.Parse(Console.ReadLine());
            nodes = new List<Node>(numberTasks);
            var timePerTask = (Console.ReadLine()).Split(' ').Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < timePerTask.Length; i++)
            {
                nodes.Add(new Node(i, timePerTask[i]));
            }

            for (int i = 0; i < numberTasks; i++)
            {
                var dependencies = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToArray();
                if (dependencies[0] != -1)
                {
                    foreach (var item in dependencies)
                    {
                        nodes[i].Parents.Add(nodes[item]);
                    }
                }
            }

            int[] minutes = new int[numberTasks];

            for (int i = 0; i < minutes.Length; i++)
            {
                //Console.WriteLine("{0}[{1}] <- {2}", nodes[i].Name, nodes[i].Time, string.Join(", ", nodes[i].Parents));
                bool[] visited = new bool[numberTasks];
                if (minutes[i] == 0)
                {
                    minutes[i] = CalcMinTime(i, minutes, visited);
                }
            }

            Console.WriteLine(minutes.Max());
        }

        private static int CalcMinTime(int rootIndex, int[] minutes, bool[] visited)
        {
            if (visited[rootIndex])
            {
                Console.WriteLine(-1);
                Environment.Exit(0);
            }

            var root = nodes[rootIndex];
            visited[rootIndex] = true;

            if (root.Parents.Count == 0)
            {
                return root.Time;
            }

            var maxParentTime = 0;

            foreach (var parent in root.Parents)
            {
                if (minutes[parent.Name] == 0)
                {
                    var parentTime = CalcMinTime(parent.Name, minutes, visited);
                    minutes[parent.Name] = parentTime;
                }
                maxParentTime = Math.Max(minutes[parent.Name], maxParentTime);
            }

            return maxParentTime + root.Time;
        }
    }

    class Node
    {
        public Node(int name, int time)
        {
            this.Name = name;
            this.Time = time;
            this.Parents = new List<Node>();
        }

        public int Name { get; set; }

        public int Time { get; set; }

        public List<Node> Parents { get; set; }
    }
}