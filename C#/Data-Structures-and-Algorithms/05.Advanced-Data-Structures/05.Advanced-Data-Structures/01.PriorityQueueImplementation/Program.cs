using System;
using System.Linq;

namespace _01.PriorityQueueImplementation
{
    class Program
    {
        static void Main()
        {
            PriorityQueue<int> heap = new PriorityQueue<int>(2);
            heap.Enqueue(1);
            heap.Enqueue(21);
            heap.Enqueue(3);
            heap.Enqueue(6);
            Console.WriteLine(heap.Dequeue());
            heap.Enqueue(31);
            heap.Enqueue(5);
            Console.WriteLine("ToString elements");
            Console.WriteLine(heap.ToString());
            Console.WriteLine("Dequeue elements");
            while (heap.Count > 0)
            {
                Console.Write("{0}, ", heap.Dequeue());
            }
        }
    }
}
