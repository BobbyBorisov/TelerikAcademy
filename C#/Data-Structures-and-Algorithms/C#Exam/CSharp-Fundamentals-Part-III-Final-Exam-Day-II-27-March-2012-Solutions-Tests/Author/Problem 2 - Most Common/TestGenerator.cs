using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Problem_2___Most_Common
{
    public static class TestGenerator
    {
        public const string FileNamesFormat = "test.{0:000}.in.txt";
        public const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const int MinStringLength = 1;
        public const int MaxStringLength = 6;
        private static readonly Random rand = new Random();

        public static void GenerateTests()
        {
            List<Tuple<bool, int, int, int>> testCases = new List<Tuple<bool, int, int, int>>(); // run?, numberOfHumans, maxStringLength
            testCases.Add(new Tuple<bool, int, int, int>(true, 8, 1, 8));     // 1
            testCases.Add(new Tuple<bool, int, int, int>(true, 100, 1, 8));   // 2
            testCases.Add(new Tuple<bool, int, int, int>(true, 500, 3, 7));   // 3
            testCases.Add(new Tuple<bool, int, int, int>(true, 1000, 6, 6));  // 4
            testCases.Add(new Tuple<bool, int, int, int>(true, 2000, 2, 4));  // 5
            testCases.Add(new Tuple<bool, int, int, int>(true, 10000, 1, 3)); // 6
            testCases.Add(new Tuple<bool, int, int, int>(true, 15000, 2, 2)); // 7
            testCases.Add(new Tuple<bool, int, int, int>(true, 15000, 1, 1)); // 8
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 7, 8)); // 9
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 2, 7)); // 10
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 5, 5)); // 11
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 1, 3)); // 12
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 1, 2)); // 13
            testCases.Add(new Tuple<bool, int, int, int>(true, 25000, 1, 1)); // 14
            testCases.Add(new Tuple<bool, int, int, int>(true, 50000, 1, 8)); // 15
            testCases.Add(new Tuple<bool, int, int, int>(true, 50000, 7, 7)); // 16
            testCases.Add(new Tuple<bool, int, int, int>(true, 50000, 2, 5)); // 17
            testCases.Add(new Tuple<bool, int, int, int>(true, 50000, 2, 4)); // 18
            testCases.Add(new Tuple<bool, int, int, int>(true, 50000, 3, 3)); // 19
            testCases.Add(new Tuple<bool, int, int, int>(true, 50000, 8, 8)); // 20

            for (int testNumber = 1; testNumber <= testCases.Count; testNumber++)
            {
                var testCase = testCases[testNumber - 1];
                if (!testCase.Item1)
                {
                    Console.WriteLine("Test {0:00} -> Skipped!", testNumber);
                    continue;
                }

                List<string> humans = new List<string>();

                using (StreamWriter sw = new StreamWriter(string.Format(FileNamesFormat, testNumber)))
                {
                    sw.WriteLine(testCase.Item2); // Commands count

                    // Add humans
                    for (int i = 1; i <= testCase.Item2; i++)
                    {
                        humans.Add(string.Format("{0} {1}, {2}, {3}, {4}, {5}",
                            GetRandomString(testCase.Item3, testCase.Item4), // first name
                            GetRandomString(testCase.Item3, testCase.Item4), // last name
                            rand.Next(1900, 2012 + 1), // birth year
                            GetRandomString(testCase.Item3, testCase.Item4), // eye color
                            GetRandomString(testCase.Item3, testCase.Item4), // hair color
                            rand.Next(150, 220 + 1))); // height
                    }

                    humans = humans.Shuffle().ToList();
                    foreach (var str in humans)
                    {
                        sw.WriteLine(str);
                    }
                }


                StringBuilder answer = new StringBuilder();
                Stopwatch watch = new Stopwatch();
                watch.Start();
                MostCommonCharacteristicsFinder finder = new MostCommonCharacteristicsFinder();
                foreach (string human in humans)
                {
                    finder.AddHuman(human);
                }
                answer.Append(finder.GetMostCommonFirstName() + "_");
                answer.Append(finder.GetMostCommonLastName() + "_");
                answer.Append(finder.GetMostCommonYearOfBirth().ToString() + "_");
                answer.Append(finder.GetMostCommonEyeColor() + "_");
                answer.Append(finder.GetMostCommonHairColor() + "_");
                answer.Append(finder.GetMostCommonHeight().ToString() + "_");
                watch.Stop();
                Console.WriteLine("\nTest {0:00} -> Time: {1},\nAnswer: {2}", testNumber, watch.Elapsed, answer.ToString());
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