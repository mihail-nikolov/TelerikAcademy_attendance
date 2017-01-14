//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;
//using Wintellect.PowerCollections;

//namespace Exam_DSA_part1
//{
//    class Node
//    {
//        public Node()
//        {
//            this.Children = new List<Node>();
//        }

//        public List<Node> Children { get; set; }
//    }

//    class Rings
//    {
//        static BigInteger answer = 1;
//        static List<int>[] nodes;
//        //bool answerWillBeBigger

//        static void Main()
//        {
//            int n = int.Parse(Console.ReadLine());
//            //Node[] nodes = new Node[n];
//            nodes = new List<int>[n];
//            int root = 0;

//            for (int i = 0; i < n; i++)
//            {
//                int parrent = int.Parse(Console.ReadLine());
//                int child = i;

//                if (nodes[child] == null)
//                {
//                    nodes[child] = new List<int>();
//                }

//                if (parrent == 0)
//                {
//                    root = child;
//                }
//                else
//                {
//                    parrent--;
//                    if (nodes[parrent] == null)
//                    {
//                        nodes[parrent] = new List<int>();
//                    }

//                    nodes[parrent].Add(child);
//                }
//            }

//            bool[] visited = new bool[n];

//            Bfs(root, visited);
//            if (answer == 1)
//            {
//                Console.WriteLine(1);
//            }
//            else
//            {
//                Console.WriteLine(answer);
//            }
//        }

//        private static void Bfs(int root, bool[] visited)
//        {
//            //one 2 parents could have 1 child?
//            var queue = new Queue<int>();
//            queue.Enqueue(root);

//            while (queue.Count > 0)
//            {
//                var currentNodeNumber = queue.Dequeue();
//                var currentNode = nodes[currentNodeNumber];

//                int numNodesWhoCanSwap = 0;

//                foreach (var c in currentNode)
//                {
//                    if (!visited[c])
//                    {
//                        queue.Enqueue(c);
//                        numNodesWhoCanSwap++;
//                    }

//                }

//                if (numNodesWhoCanSwap >= 2)
//                {
//                    answer *= Factorial(numNodesWhoCanSwap);
//                }
//            }
//        }

//        public static BigInteger Factorial(BigInteger n)
//        {
//            for (BigInteger i = n - 1; i > 1; i--)
//            {
//                n *= i;
//            }

//            return n;
//        }
//        //public static BigInteger Factorial(int n)
//        //{
//        //    BigInteger sum = n;
//        //    BigInteger result = n;
//        //    for (int i = n - 2; i > 1; i -= 2)
//        //    {
//        //        sum = (sum + i);
//        //        result *= sum;
//        //    }

//        //    if (n % 2 != 0)
//        //        result *= (BigInteger)Math.Round((double)n / 2, MidpointRounding.AwayFromZero);

//        //    return result;
//        //}
//    }
//}