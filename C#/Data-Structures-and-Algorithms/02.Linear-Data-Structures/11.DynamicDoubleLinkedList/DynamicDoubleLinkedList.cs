using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.DynamicDoubleLinkedList
{
    public class DynamicDoubleLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        

        public int Count { get; private set; }
        public DynamicDoubleLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public void Add(T item)
        {
            if (head == null)
            {
                // We have empty list
                head = new Node<T>(item);
                tail = head;
            }
            else
            {
                // We have non-empty list
                var newNode = new Node<T>(item, tail);
                tail = newNode;
            }
            this.Count++;
        }

        public T RemoveByIndex(int index)
        {
            //Find the element by the index
            if (index > this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out range");
            }

            int currentIndex = 0;
            var currentNode = this.head;
            Node<T> prevNode = null;
            Node<T> nextNode = null;

            while (currentIndex < index)
            {
                prevNode = currentNode.Previous;
                nextNode = currentNode.Next;
                currentNode = currentNode.Next;

                currentIndex++;
            }

            //Remove the element
            this.Count--;
            if (this.Count == 0)
            {
                this.head = null;
            }
            else if (prevNode == null)
            {
                this.head = currentNode.Next;
                this.head.Previous = null;
            }
            else
            {
                if (currentNode.Next != null)
                {
                    prevNode.Next = nextNode;
                    nextNode.Previous = prevNode;
                }
                else
                {
                    currentNode = currentNode.Previous;
                    this.tail = currentNode;
                    this.tail.Next = null;

                }
            }

            return currentNode.Element;
        }

        public int RemoveByItem(T item)
        {
            //Find the element by the index
            int currentIndex = 0;
            var currentNode = this.head;
            Node<T> prevNode = null;
            Node<T> nextNode = null;

            while (currentNode != null)
            {
                if ((currentNode.Element != null &&
                   currentNode.Element.Equals(item)) ||
                  (currentNode.Element == null) && (item == null))
                {
                    break;
                }

                prevNode = currentNode;
                currentNode = currentNode.Next;
                nextNode = currentNode.Next;
                currentIndex++;
            }

            //Remove the element
            this.Count--;
            if (this.Count == 0)
            {
                this.head = null;
            }
            else if (prevNode == null)
            {
                this.head = currentNode.Next;
                this.head.Previous = null;
            }
            else
            {
                if (currentNode.Next != null)
                {
                    prevNode.Next = nextNode;
                    nextNode.Previous = prevNode;
                }
                else
                {
                    currentNode = currentNode.Previous;
                    this.tail = currentNode;
                    this.tail.Next = null;
                }
            }

            //this.tail = this.FindLastElement();

            return currentIndex;
        }

        private Node<T> FindLastElement()
        {
            Node<T> lastElement = null;
            if (this.head != null)
            {
                lastElement = this.head;
                while (lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
            }

            return lastElement;
        }

        public int IndexOf(T item)
        {

            //Find the element by the index
            int currentIndex = 0;
            var currentNode = this.head;


            while (currentNode != null)
            {
                if ((currentNode.Element != null &&
                   currentNode.Element.Equals(item)) ||
                  (currentNode.Element == null) && (item == null))
                {
                    return currentIndex;
                }


                currentNode = currentNode.Next;
                currentIndex++;
            }

            return -1;
        }

        public Node<T> GetElementByIndex(int index)
        {
            if (index > this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out range");
            }

            //Find the element by the index
            int currentIndex = 0;
            var currentNode = this.head;


            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            return currentNode;
        }

        public void Insert(int index, T element)
        {
            int currentIndex = 0;
            var currentNode = this.head;
            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;

                this.Count++;
                if (currentNode.Previous == null)
                {
                    var newNode = new Node<T>(element);
                    newNode.Previous = null;
                    newNode.Next = currentNode;
                    this.head = newNode;
                }
                else if (currentNode.Next == null)
                {
                    var newNode = new Node<T>(element, tail);
                    tail = newNode;
                }
                else
                {
                    var newNode = new Node<T>(element, currentNode, currentNode.Next);
                }

                this.tail = this.FindLastElement();


            }
        }

        public T[] ToArray()
        {
            var list = new List<T>();
            var currentNode = this.head;
            while (currentNode != null)
            {
                list.Add(currentNode.Element);
                currentNode = currentNode.Next;
            }

            return list.ToArray();
        }
    }
}
