using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PrintSequenceUntilNumber
{
    class PrintSequence
    {
        static void Main(string[] args)
        {
            int n = 5;
            var stopDigit = 16;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int index = 0;
            Console.WriteLine("S =");
            while (queue.Count > 0)
            {

                int current = queue.Dequeue();
                Console.WriteLine(" " + current);
                if (current == stopDigit)
                {
                    break;
                }
                queue.Enqueue(2 * current);
                queue.Enqueue(current + 2);
                queue.Enqueue(current + 1);


            }
        }
    }
}
