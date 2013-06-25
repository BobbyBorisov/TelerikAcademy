using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Problem_1___Tasks
{
    class Program
    {
        static void Main()
        {
            // TestGenerator.GenerateTests(); return;
            StringBuilder output = new StringBuilder();
            TaskSolver taskSolver = new TaskSolver();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= commandsCount; i++)
            {
                string command = Console.ReadLine();
                string result = taskSolver.ExecuteCommand(command);
                if (!string.IsNullOrEmpty(result))
                {
                    output.AppendLine(result);
                }
            }
            Console.Write(output.ToString());
        }
    }

    public class TaskSolver
    {
        const string NEW_COMMAND = "New";
        const string SOLVE_COMMAND = "Solve";
        const string REST_RESULT = "Rest";

        PriorityQueue<Task> queue;

        public TaskSolver()
        {
            queue = new PriorityQueue<Task>();
        }

        public string ExecuteCommand(string command)
        {
            string[] commandParts = command.Split(new char[] { ' ' }, 3);
            if (commandParts[0] == NEW_COMMAND)
            {
                int taskComplexity = int.Parse(commandParts[1]);
                string taskName = commandParts[2];
                Task task = new Task(taskName, taskComplexity);
                queue.Enqueue(task);
                return string.Empty;
            }
            else if (commandParts[0] == SOLVE_COMMAND)
            {
                if (queue.Count == 0)
                {
                    return REST_RESULT;
                }
                else
                {
                    Task task = queue.Dequeue();
                    return task.Name;
                }
            }
            else return string.Empty;
        }
    }

    public class Task : IComparable<Task>
    {
        public string Name { get; set; }
        public int Complexity { get; set; }

        public Task(string name, int complexity)
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

        public override bool Equals(object obj)
        {
            Task task = obj as Task;
            return task.Complexity == this.Complexity && task.Name.Equals(this.Name);
        }

        public override int GetHashCode()
        {
            return this.Complexity ^ this.Name.GetHashCode();
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
