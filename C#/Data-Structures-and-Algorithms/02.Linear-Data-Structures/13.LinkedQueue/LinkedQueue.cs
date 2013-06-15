using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedQueue
{
    public class LinkedQueue<T>
    {
        private Node<T> tail;
        private Node<T> head;
        private int count;

        public LinkedQueue()
        {

        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T Peek()
        {
            if (this.count == 0)
            {
                throw new IndexOutOfRangeException("The Queue is empty.");
            }

            T firstElement = this.head.Element;

            return firstElement;
        }

        public void Enqueue(T element)
        {
            if (this.head == null)
            {

                this.head = new Node<T>(element);
                this.tail = this.head;
            }
            else
            {
                var newNode = new Node<T>(element, null, this.tail);
                this.tail = newNode;
            }

            this.count++;
        }

        public T Dequeue()
        {
            if (this.count == 0)
            {
                throw new IndexOutOfRangeException("The Queue is empty.");
            }

            T firstElement = this.head.Element;

            this.head = this.head.Next;

            if (this.head != null)
            {
                this.head.Previous = null;
            }

            this.count--;

            if (this.count == 0)
            {
                this.tail = null;
            }
            return firstElement;
        }

        private int IndexOf(T item)
        {
            int currentIndex = 0;
            Node<T> currnetNodeToBeRemoved = this.head;

            while (currentIndex < this.Count)
            {
                if (currnetNodeToBeRemoved.Element.Equals(item))
                {
                    return currentIndex;
                }

                currentIndex++;
                currnetNodeToBeRemoved = currnetNodeToBeRemoved.Next;
            }

            return -1;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public bool Contains(T item)
        {
            if (this.IndexOf(item) >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
