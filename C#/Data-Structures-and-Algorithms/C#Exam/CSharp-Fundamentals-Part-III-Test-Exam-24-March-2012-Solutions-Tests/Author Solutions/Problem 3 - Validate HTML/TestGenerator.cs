using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Problem_3___Validate_HTML
{
    public static class TestGenerator
    {
        public const string FileNamesFormat = "test.{0:000}.in.txt";
        public const string AllowedChars = "abcdefghijklmnopqrstuvwxyz";
        private static Random rand = new Random();

        public static void GenerateTests()
        {
            List<Tuple<bool, int, int, int>> testCases = new List<Tuple<bool, int, int, int>>(); // run?, valid, invalid, tags
            testCases.Add(new Tuple<bool, int, int, int>(false, 10, 10, 5)); // 1
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 5, 10)); // 2
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 25, 25)); // 3
            testCases.Add(new Tuple<bool, int, int, int>(true, 1, 49, 50)); // 4
            testCases.Add(new Tuple<bool, int, int, int>(true, 20, 15, 125)); // 5
            testCases.Add(new Tuple<bool, int, int, int>(true, 10, 25, 200)); // 6
            testCases.Add(new Tuple<bool, int, int, int>(true, 15, 30, 250)); // 7
            testCases.Add(new Tuple<bool, int, int, int>(true, 20, 30, 300)); // 8
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 400)); // 9
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 500)); // 10
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 1000)); // 11
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 1500)); // 12
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 2000)); // 13
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 2500)); // 14
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 3000)); // 15
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 3500)); // 16
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 4000)); // 17
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 4500)); // 18
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 5000)); // 19
            testCases.Add(new Tuple<bool, int, int, int>(true, 5, 45, 5000)); // 20

            for (int testNumber = 1; testNumber <= testCases.Count; testNumber++)
            {
                var testCase = testCases[testNumber - 1];
                if (!testCase.Item1)
                {
                    Console.WriteLine("Test {0:00} -> Skipped!", testNumber);
                    continue;
                }

                List<string> strings = new List<string>();

                using (StreamWriter sw = new StreamWriter(string.Format(FileNamesFormat, testNumber)))
                {
                    sw.WriteLine(testCase.Item2 + testCase.Item3); // strings count

                    // Valid HTML
                    for (int i = 1; i <= testCase.Item2; i++)
                    {
                        strings.Add(GenerateValidHTML(testCase.Item4));
                    }

                    // Invalid HTML
                    for (int i = 1; i <= testCase.Item3; i++)
                    {
                        strings.Add(GenerateInvalidHTML(testCase.Item4));
                    }

                    strings = strings.Shuffle().ToList();
                    foreach (var str in strings)
                    {
                        sw.WriteLine(str);
                    }
                }


                StringBuilder answer = new StringBuilder();
                Stopwatch watch = new Stopwatch();
                HTMLValidator solver = new HTMLValidator();
                watch.Start();
                foreach (var str in strings)
                {
                    bool res = solver.ValidateHTML(str);
                    answer.Append(res ? '1' : '0');
                }
                //answer.Clear();
                watch.Stop();
                Console.WriteLine("Test {0:00} -> Time: {1},\tAnswer: {2}", testNumber, watch.Elapsed, answer.ToString());
            }
        }

        private static string GenerateValidHTML(int tagsCount)
        {
            Stack<string> stack = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            int opened = 0;
            int allTags = tagsCount * 2;
            for (int i = 1; i <= allTags; i++)
            {
                if (opened == 0) // Open
                {
                    string str = GetRandomName(2, 10);
                    sb.AppendFormat("<{0}>", str);
                    stack.Push(str);
                    opened++;
                    tagsCount--;
                }
                else if (tagsCount == 0) // Close
                {
                    string str = stack.Pop();
                    sb.AppendFormat("</{0}>", str);
                    opened--;
                }
                else
                {
                    int r = rand.Next(1, 4);
                    if (r == 1) // Close
                    {
                        string str = stack.Pop();
                        sb.AppendFormat("</{0}>", str);
                        opened--;
                    }
                    else // Open
                    {
                        string str = GetRandomName(2, 10);
                        sb.AppendFormat("<{0}>", str);
                        stack.Push(str);
                        tagsCount--;
                        opened++;
                    }
                }
            }

            // close or create
            return sb.ToString();
        }

        private static string GenerateInvalidHTML(int tagsCount)
        {
            Stack<string> stack = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            int opened = 0;
            int allTags = tagsCount * 2 + rand.Next(-1, 2);
            for (int i = 1; i <= allTags; i++)
            {
                int r = rand.Next(1, 3);
                if (r == 1) // Close
                {
                    if (stack.Count > 0)
                    {
                        string str = stack.Pop();
                        sb.AppendFormat("</{0}>", str);
                        opened--;
                    }
                }
                if (r == 2) // Open
                {
                    string str = GetRandomName(2, 10);
                    sb.AppendFormat("<{0}>", str);
                    stack.Push(str);
                    tagsCount--;
                    opened++;
                }
            }
            return sb.ToString();
        }

        public static string GetRandomName(int minLength, int maxLength)
        {
            int len = rand.Next(minLength, maxLength + 1);
            StringBuilder sb = new StringBuilder(len);
            for (int i = 1; i <= len; i++)
            {
                sb.Append(AllowedChars[rand.Next(0, AllowedChars.Length)]);
            }
            return sb.ToString().Trim();
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
