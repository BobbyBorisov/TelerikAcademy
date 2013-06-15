using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReadViaStack
{
    class ReverseViaStack
    {
        static void Main(string[] args)
        {
            var stackCollection = new Stack<int>();

            Console.Write("N=");
            var numberOfDigits = int.Parse(Console.ReadLine());

            for (var i = 0; i < numberOfDigits; i++)
            {
                var currentDigit = int.Parse(Console.ReadLine());
                stackCollection.Push(currentDigit);
            }

            Console.WriteLine("Elements in reverse order");
            while (stackCollection.Count > 0)
            {
                Console.WriteLine(stackCollection.Pop());
            }
        }
    }
}
