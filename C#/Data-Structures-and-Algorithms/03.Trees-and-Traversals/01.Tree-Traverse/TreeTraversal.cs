using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tree_Traverse
{
    class TreeTraversal
    {
        private const int PATH_SUM = 6;
        private const int SUBTREE_SUM =12;

        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            var nodes = new Node<int>[numberOfNodes];

            for (int i = 0; i < nodes.Length; i++) 
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < nodes.Length - 1; i++)
            {
                string line = Console.ReadLine();
                var lineArray = line.Split(' ');
                var parent = int.Parse(lineArray[0]);
                var children = int.Parse(lineArray[1]);

                nodes[parent].Children.Add(nodes[children]);
                nodes[children].hasParent = true;
            }

            //1.Find the root
            var root = FindRoot(nodes);
            Console.WriteLine("Root = {0}",root.Value);

            //2.Find all leaves
            var leaves = FindLeaves(nodes);

            //3.Find middle nodes
            var middleNodes = FindMiddleNodes(nodes);

            //4.Find longest path
            var longestPath = FindLongestPath(root);
            Console.WriteLine("Longest path is:{0}",longestPath);

            //5.Find paths with given sum of nodes 6
            PrintPathWithGivenSum(nodes);

            //6.Find all subtrees with given sum of all child nodes
            PrintSubtreeWithGivenSum(root);
        }

        private static Node<int> FindRoot(Node<int>[] nodes) 
        {
            var root = nodes.First(x => x.hasParent == false && x.Children.Count > 0);
            return root;
        }

        private static IEnumerable<Node<int>> FindLeaves(Node<int>[] nodes) 
        {
            var leaves = nodes.Where(x => x.Children.Count == 0);
            return leaves;
        }

        private static IEnumerable<Node<int>> FindMiddleNodes(Node<int>[] nodes) 
        {
            var middleNodes = nodes.Where(x => x.hasParent == true && x.Children.Count > 0);
            return middleNodes;
        }

        private static int FindLongestPath(Node<int> root) 
        {
            if (root.Children.Count == 0) 
            {
                return 0;
            }

            var maxPath = 0;
            foreach (var child in root.Children)
            {
                var currentPath = FindLongestPath(child);
                maxPath = Math.Max(maxPath, currentPath);
            }

            return maxPath + 1;
        }

        private static void FindPathWithGivenSum(Node<int> root, List<List<Node<int>>> allPaths, List<Node<int>> currentPath, int currentSum) 
        {
            currentSum += root.Value;

            if (currentSum <= PATH_SUM)
            {
                currentPath.Add(root);

                if (currentSum == PATH_SUM)
                {
                    var newList = new List<Node<int>>(currentPath);
                    allPaths.Add(newList);
                    currentPath.RemoveRange(1, currentPath.Count - 1);
                }
            }
            else 
            {
                return;
            }

            foreach (var child in root.Children)
            {
                FindPathWithGivenSum(child, allPaths, currentPath, currentSum);
                if (currentPath.Count > 1) 
                {
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }

        private static void PrintPathWithGivenSum(Node<int>[] nodes)
        {
            for (int j = 0; j < nodes.Length; j++)
            {
                var allPaths = new List<List<Node<int>>>();
                var currentPath = new List<Node<int>>();
                FindPathWithGivenSum(nodes[j], allPaths, currentPath, 0);
                foreach (var foundPath in allPaths)
                {
                    Console.Write("Path:");
                    for (var i = 0; i < foundPath.Count; i++)
                    {
                        Console.Write(foundPath[i].Value + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static int FindSubtreeSum(Node<int> root, List<Node<int>> listOfSubTrees)
        {
            int sum = root.Value;

            foreach (var child in root.Children)
            {
                sum += FindSubtreeSum(child, listOfSubTrees);
            }

            if (sum == SUBTREE_SUM)
            {
                listOfSubTrees.Add(root);
            }

            return sum;
        }

        private static void PrintSubtreeWithGivenSum(Node<int> root)
        {
            Console.Write("Subtree(s) with sum of {0}: ", SUBTREE_SUM);
            List<Node<int>> listOfSubTrees = new List<Node<int>>();
            FindSubtreeSum(root, listOfSubTrees);
            foreach (var subtree in listOfSubTrees)
            {
                Console.Write(subtree.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
