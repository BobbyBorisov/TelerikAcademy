using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.DynamicStack
{
    public class DynamicStack<T>
    {
        private Node<T> top;
        private int count;


        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public DynamicStack()
        {
            this.top = null;
            this.count = 0;
        }

        public void Push(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot push null value");
            }
            if (top == null)
            {
                // We have empty list
                top = new Node<T>(item);
                top.Next = null;
            }
            else
            {
                // We have non-empty list
                Node<T> newNode = new Node<T>(item);
                newNode.Next = top;
                top = newNode;
            }
            count++;
        }

        public object Pop()
        {
            var myelement = top.Element;
            top = top.Next;
            this.count--;
            return myelement;
        }

        public object Peek()
        {
            return top.Element;
        }

        public void Clear()
        {
            while (top != null)
            {
                this.Pop();
            }
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot search for null value");
            }

            Node<T> current = top;

            while (current != null)
            {

                if (current.Element.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public object[] ToArray()
        {
            var list = new List<object>();
            var current = top;
            while (current != null)
            {
                list.Add(current.Element);
                current = current.Next;
            }

            return list.ToArray();
        }
    }
}
