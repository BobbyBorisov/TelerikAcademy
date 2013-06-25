using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Problem_4___Reach_N
{
    class Program
    {
        const int TESTS_COUNT = 4;

        static void Main(string[] args)
        {
            for (int i = 1; i <= TESTS_COUNT; i++)
            {
                long N = long.Parse(Console.ReadLine());
                ThePower solver = new ThePower();
                long transformationsCount = solver.Count(N);
                Console.WriteLine(transformationsCount);
            }
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private OrderedBag<T> bag;

        public int Count
        {
            get
            {
                return bag.Count;
            }
            private set
            {
            }
        }

        public PriorityQueue()
        {
            bag = new OrderedBag<T>();
        }

        public void Enqueue(T element)
        {
            bag.Add(element);
        }

        public T Dequeue()
        {
            var element = bag.GetFirst();
            bag.RemoveFirst();
            return element;
        }
    }

    public class ThePower
    {
        private class State : IComparable<State>
        {
            public long Number { get; set; }
            public long Steps { get; set; }

            public State(long number, long steps)
            {
                this.Number = number;
                this.Steps = steps;
            }

            public int CompareTo(State state)
            {
                return (this.Steps < state.Steps) ? -1 : 1;
            }
        }

        long powSteps(long x, int p)
        {
            long result = 1;
            while (p != 0)
            {
                if (p % 2 == 1)
                {
                    result *= x;
                }
                x *= x;
                p /= 2;
            }
            return result;
        }

        public long Count(long N)
        {
            if (N < 1)
            {
                return -1;
            }

            if (N == 1)
            {
                return 0;
            }

            PriorityQueue<State> queue = new PriorityQueue<State>();

            // Start from N
            queue.Enqueue(new State(N, 0));

            while (queue.Count > 0)
            {
                State currentState = queue.Dequeue();

                if (currentState.Number == 1)
                {
                    // We reached 1
                    return currentState.Steps - 1;
                }

                // Console.WriteLine(cur.n + " " + cur.steps);

                // 2 ^ 60 is greater than 10 ^ 18
                for (int power = 2; power <= 60; power++)
                {
                    double powerBase = Math.Pow(currentState.Number, 1.0 / power);
                    if (powerBase < 1) break;
                    long next = (long)Math.Round(powerBase); // next ^ power = currentState.Number
                    // calculate the number of steps required to transform from next to currentState.Number
                    long numberOfSteps = (Math.Abs(powSteps(next, power) - currentState.Number));
                    queue.Enqueue(new State(next, currentState.Steps + numberOfSteps + 1));
                }
            }

            return -1;
        }
    }
}
