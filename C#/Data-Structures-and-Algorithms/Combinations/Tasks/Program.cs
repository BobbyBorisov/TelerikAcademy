using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Tasks
{
    class Task : IComparable<Task>
    {
        public string Name;
        public long Complexity;

        public Task(string name, long complexity) 
        {
            this.Name = name;
            this.Complexity = complexity;
        }

        public int CompareTo(Task other)
        {
            if (this.Complexity < other.Complexity) 
            {
                return -1;
            }
            else if (this.Complexity > other.Complexity)
            {
                return 1;
            }
            else 
            {
                return this.Name.CompareTo(other.Name);
            }
        }
    }

    class Program
    {
        const string NEW_COMMAND = "New";
        const string SOLVE_COMMAND = "Solve";
        const string REST = "Rest";

        static StringBuilder output = new StringBuilder();
        static PriorityQueue<Task> tasksQueue = new PriorityQueue<Task>();

        static void Main(string[] args)
        {
            var commandsCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < commandsCount; i++) 
            {
                ProcessCommand(Console.ReadLine());
            }
            Console.WriteLine(output.ToString());
        }

        static void ProcessCommand(string line) 
        {
            var commandParts = line.Split(new char[] { ' ' }, 3);

            if (commandParts[0] == NEW_COMMAND) 
            {
                var complexity = int.Parse(commandParts[1]);
                var name = commandParts[2];

                tasksQueue.Enqueue(new Task(name, complexity));
            }
            else if (commandParts[0] == SOLVE_COMMAND) 
            {
                if (tasksQueue.Count == 0) 
                {
                    output.AppendLine(REST);
                    return;
                }
                
                var element = tasksQueue.Dequeue();

                output.AppendLine(element.Name);
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
}
