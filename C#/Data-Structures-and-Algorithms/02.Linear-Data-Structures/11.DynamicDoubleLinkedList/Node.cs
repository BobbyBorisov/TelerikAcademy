using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.DynamicDoubleLinkedList
{
    public class Node<T>
    {
        public T Element { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T element, Node<T> prevNode)
        {
            this.Element = element;
            prevNode.Next = this;
            this.Previous = prevNode;
        }

        public Node(T element, Node<T> prevNode, Node<T> nextNode)
        {
            this.Element = element;
            prevNode.Next = this;
            this.Previous = prevNode;
            nextNode.Previous = this;
            this.Next = nextNode;
        }

        public Node(T element)
        {
            this.Element = element;
            Next = null;
        }
    }
}
