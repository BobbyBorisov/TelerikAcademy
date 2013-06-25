using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Problem_4___LinkedOut
{
    public static class TestGenerator
    {
        public const string FileNamesFormat = "test.{0:000}.in.txt";
        public static Random rand = new Random();

        public static void GenerateTests()
        {
            List<Tuple<bool, int, int, int>> testCases = new List<Tuple<bool, int, int, int>>(); // generate?, K=users, N=connections, M=questions, K > M
            testCases.Add(new Tuple<bool, int, int, int>(true, 10, 15, 9)); // 1
            testCases.Add(new Tuple<bool, int, int, int>(true, 20, 5, 19)); // 2
            testCases.Add(new Tuple<bool, int, int, int>(true, 50, 200, 49)); // 3
            testCases.Add(new Tuple<bool, int, int, int>(true, 50, 25*49, 49)); // 4
            testCases.Add(new Tuple<bool, int, int, int>(true, 75, 75, 70)); // 5
            testCases.Add(new Tuple<bool, int, int, int>(true, 99, 9, 90)); // 6
            testCases.Add(new Tuple<bool, int, int, int>(true, 100, 500, 99)); // 7
            testCases.Add(new Tuple<bool, int, int, int>(true, 150, 500, 120)); // 8
            testCases.Add(new Tuple<bool, int, int, int>(true, 200, 2000, 199)); // 9
            testCases.Add(new Tuple<bool, int, int, int>(true, 250, 1000, 249)); // 10
            testCases.Add(new Tuple<bool, int, int, int>(true, 300, 1000, 200)); // 11
            testCases.Add(new Tuple<bool, int, int, int>(true, 350, 1000, 300)); // 12
            testCases.Add(new Tuple<bool, int, int, int>(true, 400, 1000, 399)); // 13
            testCases.Add(new Tuple<bool, int, int, int>(true, 500, 5000, 499)); // 14
            testCases.Add(new Tuple<bool, int, int, int>(true, 567, 5000, 500)); // 15
            testCases.Add(new Tuple<bool, int, int, int>(true, 654, 10000, 600)); // 16
            testCases.Add(new Tuple<bool, int, int, int>(true, 701, 20000, 700)); // 17
            testCases.Add(new Tuple<bool, int, int, int>(true, 750, 20000, 709)); // 18
            testCases.Add(new Tuple<bool, int, int, int>(true, 800, 20000, 700)); // 19
            testCases.Add(new Tuple<bool, int, int, int>(true, 900, 100000, 800)); // 20
            testCases.Add(new Tuple<bool, int, int, int>(true, 1000, 1000, 1)); // 21
            testCases.Add(new Tuple<bool, int, int, int>(true, 1000, 20000, 500)); // 22
            testCases.Add(new Tuple<bool, int, int, int>(true, 1000, 50000, 999)); // 23
            testCases.Add(new Tuple<bool, int, int, int>(true, 1000, 100000, 999)); // 24
            testCases.Add(new Tuple<bool, int, int, int>(true, 1000, 100000, 999)); // 25


            for (int i = 1; i <= testCases.Count; i++)
            {
                var testCase = testCases[i - 1];
                if (!testCase.Item1)
                {
                    Console.WriteLine("Test {0:00} -> Skipped!", i);
                    continue;
                }

                // Generate users
                HashSet<string> usersHashSet = new HashSet<string>();
                for (int j = 1; j <= testCase.Item2; j++)
                {
                    string user = GetRandomName();
                    while (usersHashSet.Contains(user))
                    {
                        user = GetRandomName();
                    }
                    usersHashSet.Add(user);
                }
                List<string> users = usersHashSet.ToList();
                users = users.Shuffle().ToList();

                // Get first user
                string fromUser = users[0];

                // Generate degree questions
                List<string> questions = users.Skip(1).Take(testCase.Item4).ToList();

                // Generate connections
                HashSet<Tuple<string, string>> connectionsHashSet = new HashSet<Tuple<string, string>>();
                for (int j = 1; j <= testCase.Item3; j++)
                {
                    int randIndex1 = rand.Next(0, users.Count);
                    int randIndex2 = rand.Next(0, users.Count);
                    while (randIndex1 == randIndex2)
                    {
                        randIndex2 = rand.Next(0, users.Count);
                    }
                    string user1 = users[randIndex1];
                    string user2 = users[randIndex2];
                    if (user1.CompareTo(user2) < 0)
                    {
                        string oldValue = user1;
                        user1 = user2;
                        user2 = oldValue;
                    }
                    var connection = new Tuple<string, string>(user1, user2);
                    if (!connectionsHashSet.Contains(connection))
                    {
                        connectionsHashSet.Add(connection);
                    }
                    else
                    {
                        j--;
                    }
                }
                List<Tuple<string, string>> connections = connectionsHashSet.ToList();


                using (StreamWriter sw = new StreamWriter(string.Format(FileNamesFormat, i)))
                {
                    sw.WriteLine(fromUser);

                    sw.WriteLine(connections.Count);
                    foreach (var connection in connections)
                    {
                        if (rand.Next(1, 3) == 1)
                        {
                            sw.WriteLine("{0} {1}", connection.Item1, connection.Item2);
                        }
                        else
                        {
                            sw.WriteLine("{1} {0}", connection.Item1, connection.Item2);
                        }
                    }

                    sw.WriteLine(questions.Count);
                    foreach (var user in questions)
                    {
                        sw.WriteLine(user);
                    }
                }

                Stopwatch watch = new Stopwatch();
                LinkedOut linkedOut = new LinkedOut(connections);
                watch.Start();
                var res = linkedOut.FindConnectionDegrees(fromUser, questions);
                watch.Stop();
                long time = watch.ElapsedMilliseconds;
                Console.WriteLine("Test {0:00} -> Time: {1}", i, time);
            }
        }

        public static string GetRandomName()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int len = rand.Next(2, 20);
            StringBuilder sb = new StringBuilder(len);
            for (int i = 1; i <= len; i++)
            {
                sb.Append(chars[rand.Next(0, chars.Length)]);
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
