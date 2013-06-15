using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SequenceOfNumbersViaQueue
{
    class SequenceOfNumbersViaQueue
    {
        static void Main(string[] args)
        {
            int n = 2;


            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int index = 0;
            Console.WriteLine("S =");
            while (queue.Count > 0)
            {
                index++;
                int current = queue.Dequeue();
                Console.WriteLine(" " + current);
                if (queue.Count == 50)
                {
                    break;
                }
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
        }
    }
}
