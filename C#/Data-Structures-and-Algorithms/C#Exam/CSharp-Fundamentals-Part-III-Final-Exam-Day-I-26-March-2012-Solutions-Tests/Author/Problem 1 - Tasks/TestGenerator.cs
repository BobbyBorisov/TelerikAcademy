using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Problem_1___Tasks
{
    public static class TestGenerator
    {
        public const string FileNamesFormat = "test.{0:000}.in.txt";
        public const string AllowedChars = "- abcdefghijklmnopqrstuvwxyz - ABCDEFGHIJKLMNOPQRSTUVWXYZ - 0123456789 -";
        public const int MinStringLength = 1;
        public const int MaxStringLength = 6;
        private static Random rand = new Random();

        public static void GenerateTests()
        {
            List<Tuple<bool, int, int, int>> testCases = new List<Tuple<bool, int, int, int>>(); // run?, new, solve, maxComplexity
            testCases.Add(new Tuple<bool, int, int, int>(true, 10, 100, 2000000000));   // 1
            testCases.Add(new Tuple<bool, int, int, int>(true, 50, 500, 2000000000));   // 2
            testCases.Add(new Tuple<bool, int, int, int>(true, 100, 100, 2));   // 3
            testCases.Add(new Tuple<bool, int, int, int>(true, 500, 500, 2000000000));   // 4
            testCases.Add(new Tuple<bool, int, int, int>(true, 1000, 1000, 2000000000));   // 5
            testCases.Add(new Tuple<bool, int, int, int>(true, 5000, 5000, 2000000000));   // 6
            testCases.Add(new Tuple<bool, int, int, int>(true, 10000, 10000, 2000));   // 7
            testCases.Add(new Tuple<bool, int, int, int>(true, 10000, 10000, 2000000000));   // 8
            testCases.Add(new Tuple<bool, int, int, int>(true, 10000, 10000, 2));   // 9
            testCases.Add(new Tuple<bool, int, int, int>(true, 20000, 20000, 1));   // 10
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 25000, 2000000000));   // 11
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 25000, 2000000000));   // 12
            testCases.Add(new Tuple<bool, int, int, int>(true, 49000, 1000, 2));   // 13
            testCases.Add(new Tuple<bool, int, int, int>(true, 49970, 30, 2));   // 14
            testCases.Add(new Tuple<bool, int, int, int>(true, 49990, 10, 2));   // 14
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 25000, 1));   // 16
            testCases.Add(new Tuple<bool, int, int, int>(true, 49000, 1000, 2000000000));   // 17
            testCases.Add(new Tuple<bool, int, int, int>(true, 49000, 1000, 2000000000));   // 18
            testCases.Add(new Tuple<bool, int, int, int>(true, 1000, 49000, 2000000000));   // 19
            testCases.Add(new Tuple<bool, int, int, int>(true, 49000, 1000, 1));   // 20

            for (int testNumber = 1; testNumber <= testCases.Count; testNumber++)
            {
                var testCase = testCases[testNumber - 1];
                if (!testCase.Item1)
                {
                    Console.WriteLine("Test {0:00} -> Skipped!", testNumber);
                    continue;
                }

                List<string> commands = new List<string>();

                using (StreamWriter sw = new StreamWriter(string.Format(FileNamesFormat, testNumber)))
                {
                    sw.WriteLine(testCase.Item2 + testCase.Item3); // Commands count

                    // New command
                    for (int i = 1; i <= testCase.Item2; i++)
                    {
                        commands.Add(string.Format("New {0} {1}", rand.Next(1, testCase.Item4), GetRandomString(MinStringLength, MaxStringLength).Trim()));
                    }

                    // Solve command
                    for (int i = 1; i <= testCase.Item3; i++)
                    {
                        commands.Add("Solve");
                    }

                    commands = commands.Shuffle().ToList();
                    foreach (var str in commands)
                    {
                        sw.WriteLine(str);
                    }
                }


                StringBuilder answer = new StringBuilder();
                Stopwatch watch = new Stopwatch();
                watch.Start();
                TaskSolver solver = new TaskSolver();
                foreach (string command in commands)
                {
                    answer.AppendLine(solver.ExecuteCommand(command));
                }
                answer.Clear();
                watch.Stop();
                Console.WriteLine("Test {0:00} -> Time: {1},\tAnswer: {2}", testNumber, watch.Elapsed, answer.ToString());
            }
        }

        public static string GetRandomString(int minLength, int maxLength)
        {
            int len = rand.Next(minLength, maxLength + 1);
            StringBuilder sb = new StringBuilder(len);
            for (int i = 1; i <= len; i++)
            {
                sb.Append(AllowedChars[rand.Next(0, AllowedChars.Length)]);
            }
            string randString = sb.ToString().Trim();
            if (string.IsNullOrWhiteSpace(randString)) return GetRandomString(minLength, maxLength);
            else return randString;
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var array = source.ToArray();
            var n = array.Length;
            while (n > 1)
            {
                var k = rand.Next(n);
                n--;
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            return array;
        }

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }
    }
}
