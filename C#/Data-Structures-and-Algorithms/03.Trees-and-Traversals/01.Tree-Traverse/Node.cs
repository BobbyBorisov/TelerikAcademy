using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tree_Traverse
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }
        public bool hasParent = false;

        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }
    }
}
