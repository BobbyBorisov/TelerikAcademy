using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedQueue
{
    internal class Node<T>
    {
        private T element;
        private Node<T> next;
        private Node<T> previous;


        public Node(T element, Node<T> next = null, Node<T> prev = null)
        {
            this.Element = element;

            this.next = next;
            if (this.next != null)
            {
                next.Previous = this;
            }

            this.previous = prev;
            if (this.previous != null)
            {
                prev.Next = this;
            }
        }

        public T Element
        {
            get
            {
                return this.element;
            }
            set
            {
                this.element = value;
            }
        }

        public Node<T> Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }

        public Node<T> Previous
        {
            get
            {
                return this.previous;
            }
            set
            {
                this.previous = value;
            }
        }
    }
}
