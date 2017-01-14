namespace _01.TreeOfNNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }
            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException(
                    "The node already has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }

        public static TreeNode<T> FindRoot(IEnumerable<TreeNode<T>> treeNodes)
        {
            return treeNodes.FirstOrDefault(n => !n.hasParent);
        }

        public static IEnumerable<TreeNode<T>> FindLeafNodes(IEnumerable<TreeNode<T>> treeNodes)
        {
            return treeNodes.Where(n => n.ChildrenCount.Equals(0));
        }

        public static IEnumerable<TreeNode<T>> FindMiddleNodes(IEnumerable<TreeNode<T>> treeNodes)
        {
            return treeNodes.Where(n => n.hasParent && n.children.Any());
        }

        public static int FindLongestPath(TreeNode<int> root)
        {
            if (root.ChildrenCount == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var child in root.children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(child));
            }

            return maxPath + 1;
        }
    }
}
