using System;
using System.Linq;

namespace _12.DynamicStack
{
    class Node<T>
    {
        public T Element { get; set; }

        public Node<T> Next { get; set; }

        public Node(T element)
        {
            this.Element = element;
        }
    }
}
