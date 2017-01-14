namespace _01.TreeOfNNodes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var reader = new StringReader(
@"7
2 4
3 2
5 0
3 5
5 6
5 1");

            Console.SetIn(reader);

            int n = int.Parse(Console.ReadLine());

            var treeNodes = new TreeNode<int>[n];

            for (int i = 0; i < n; i++)
            {
                treeNodes[i] = new TreeNode<int>(i);                
            }

            for (int i = 1; i < n; i++)
            {
                var parentChild = Console.ReadLine().Split(' ');
                var parent = int.Parse(parentChild[0]);
                var child = int.Parse(parentChild[1]);

                treeNodes[parent].AddChild(treeNodes[child]);
            }

            var root = TreeNode<int>.FindRoot(treeNodes);
            var leafs = TreeNode<int>.FindLeafNodes(treeNodes);
            var middleNodes = TreeNode<int>.FindMiddleNodes(treeNodes);
            var longestPath = TreeNode<int>.FindLongestPath(root);

            Console.WriteLine("The root is {0}", root.Value);
            Console.WriteLine("The leafs are {0}", string.Join(", ", leafs.Select(l => l.Value)));
            Console.WriteLine("The middle nodes are {0}", string.Join(", ", middleNodes.Select(node => node.Value)));
            Console.WriteLine("The longest path is {0}", longestPath);
        }
    }


}
