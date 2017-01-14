//namespace Problem2
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    class Sol_1
//    {
//        private static List<Node> nodes;

//        public static void Main(string[] args)
//        {
//            int numberTasks = int.Parse(Console.ReadLine());
//            nodes = new List<Node>(numberTasks);
//            var timePerTask = (Console.ReadLine()).Split(' ').Select(x => int.Parse(x)).ToArray();

//            for (int i = 0; i < timePerTask.Length; i++)
//            {
//                nodes.Add(new Node(i, timePerTask[i]));
//            }

//            for (int i = 0; i < numberTasks; i++)
//            {
//                var dependencies = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
//                if (dependencies[0] != 0)
//                {
//                    foreach (var item in dependencies)
//                    {
//                        nodes[item - 1].Children.Add(nodes[i]);
//                        nodes[i].Parents++;
//                    }
//                }
//            }

//            var result = TopologicalSort();
//            Console.WriteLine(result);
//        }



//        private static int TopologicalSort()
//        {
//            var jobs = new SortedSet<Node>();

//            foreach (var task in nodes)
//            {
//                if (task.Parents == 0)
//                {
//                    jobs.Add(task);
//                }
//            }

//            int result = 0;
//            int jobsCompleted = 0;

//            while (jobs.Count > 0)
//            {
//                var current = jobs.First();
//                jobs.Remove(current);
//                jobsCompleted++;

//                result = current.Time;

//                foreach (var child in current.Children)
//                {
//                    child.Parents--;
//                    if (child.Parents == 0)
//                    {
//                        child.Time += current.Time;
//                        jobs.Add(child);
//                    }
//                }
//            }

//            return jobsCompleted == nodes.Count ? result : -1;
//        }
//    }

//    class Node : IComparable<Node>
//    {
//        public Node(int name, int time)
//        {
//            this.Name = name;
//            this.Time = time;
//            this.Children = new List<Node>();
//            this.Parents = 0;
//        }

//        public int Name { get; set; }

//        public int Time { get; set; }

//        public List<Node> Children { get; set; }

//        public int Parents { get; set; }

//        public int CompareTo(Node other)
//        {
//            var result = this.Time.CompareTo(other.Time);
//            return result != 0 ? result : this.Name.CompareTo(other.Name);
//        }
//    }
//}
