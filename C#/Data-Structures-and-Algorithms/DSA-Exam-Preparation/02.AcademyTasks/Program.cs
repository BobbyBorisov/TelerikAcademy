using System;
using System.Linq;

namespace _02.AcademyTasks
{
    class Program
    {
        private static int variety;
        private static string[] data;
        private static int tasksCount;
        static void Main(string[] args)
        {
            data = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            variety = int.Parse(Console.ReadLine());
            tasksCount = data.Length;
            Solve();
            Console.WriteLine(tasksCount);
        }

        private static void Solve()
        {
            bool isAnswerFaound = false;
            for (int i = 0; i < data.Length - 1; i++)
            {
                int firstTaskVariety = int.Parse(data[i]);
                for (int j = i + 1; j < data.Length; j++)
                {
                    int secondTaskVariety = int.Parse(data[j]);
                    if (Math.Max(firstTaskVariety, secondTaskVariety) - Math.Min(firstTaskVariety, secondTaskVariety) >= variety)
                    {
                        tasksCount = 0;
                        if (i != 0)
                        {
                            tasksCount += i;
                        }

                        int variable = j - i;

                        tasksCount += ((variable / 2) + 1) + (variable % 2);
                        isAnswerFaound = true;
                        break;
                    }
                }

                if (isAnswerFaound)
                {
                    break;
                }
            }
        }
    }
}
