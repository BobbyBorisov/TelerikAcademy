using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Problem_2___Risk_Wins__Risk_Loses
{
    public static class TestGenerator
    {
        public const string FileNamesFormat = "test.{0:000}.in.txt";

        public static void GenerateTests()
        {
            List<Tuple<bool, int, int, int>> testCases = new List<Tuple<bool, int, int, int>>(); // initial, target, forbidden count
            testCases.Add(new Tuple<bool, int, int, int>(true, 0, 88765, 0)); // 1
            testCases.Add(new Tuple<bool, int, int, int>(true, 10000, 50000, 10)); // 2
            testCases.Add(new Tuple<bool, int, int, int>(true, 5000, 25000, 50)); // 3
            testCases.Add(new Tuple<bool, int, int, int>(true, 20000, 12345, 100)); // 4
            testCases.Add(new Tuple<bool, int, int, int>(true, 10001, 564, 1000)); // 5
            testCases.Add(new Tuple<bool, int, int, int>(true, 10001, 5, 1500)); // 6
            testCases.Add(new Tuple<bool, int, int, int>(true, 123, 56785, 2000)); // 7
            testCases.Add(new Tuple<bool, int, int, int>(true, 434, 75634, 5000)); // 8
            testCases.Add(new Tuple<bool, int, int, int>(true, 12345, 98765, 8000)); // 9
            testCases.Add(new Tuple<bool, int, int, int>(true, 1, 24236, 10000)); // 10
            testCases.Add(new Tuple<bool, int, int, int>(true, 0, 34654, 15000)); // 11
            testCases.Add(new Tuple<bool, int, int, int>(true, 11, 76343, 22000)); // 12
            testCases.Add(new Tuple<bool, int, int, int>(true, 11111, 22222, 25000)); // 13
            testCases.Add(new Tuple<bool, int, int, int>(true, 84756, 33333, 30000)); // 14
            testCases.Add(new Tuple<bool, int, int, int>(true, 95675, 44444, 40000)); // 15
            testCases.Add(new Tuple<bool, int, int, int>(true, 99999, 55555, 50000)); // 16
            testCases.Add(new Tuple<bool, int, int, int>(true, 0, 55555, 60000)); // 17
            testCases.Add(new Tuple<bool, int, int, int>(true, 93333, 8, 75000)); // 18
            testCases.Add(new Tuple<bool, int, int, int>(true, 1, 45454, 80000)); // 19
            testCases.Add(new Tuple<bool, int, int, int>(true, 10000, 45454, 90000)); // 20
            testCases.Add(new Tuple<bool, int, int, int>(true, 10001, 20002, 100000)); // 21
            testCases.Add(new Tuple<bool, int, int, int>(true, 10001, 99999, 120000)); // 22
            testCases.Add(new Tuple<bool, int, int, int>(true, 1337, 1338, 150000)); // 23
            testCases.Add(new Tuple<bool, int, int, int>(true, 1111, 55555, 150000)); // 24
            testCases.Add(new Tuple<bool, int, int, int>(true, 0, 43210, 150000)); // 25

            Random rand = new Random();

            for (int i = 1; i <= testCases.Count; i++)
            {
                var testCase = testCases[i - 1];
                if (!testCase.Item1)
                {
                    Console.WriteLine("Test {0} -> Skipped!", i);
                    continue;
                }

                string startCombination = testCase.Item2.ToString("00000");
                string targetCombination = testCase.Item3.ToString("00000");
                List<string> forbiddenCombinations = new List<string>();

                using (StreamWriter sw = new StreamWriter(string.Format(FileNamesFormat, i)))
                {
                    sw.WriteLine(startCombination); // initial
                    sw.WriteLine(targetCombination); // target
                    sw.WriteLine(testCase.Item4); // forbidden count
                    for (int j = 1; j <= testCase.Item4; j++)
                    {
                        int randomNumber = rand.Next(0, 100000);
                        while(randomNumber == testCase.Item2 || randomNumber == testCase.Item3)
                        {
                            randomNumber = rand.Next(0, 100000);
                        }
                        string forbiddenCombination = randomNumber.ToString("00000");
                        forbiddenCombinations.Add(forbiddenCombination);
                        sw.WriteLine(forbiddenCombination);
                    }
                }

                Stopwatch watch = new Stopwatch();
                LowestButtonsCountFinder finder = new LowestButtonsCountFinder(startCombination, targetCombination, forbiddenCombinations);
                LowestButtonsCountSlowFinder slowFinder = new LowestButtonsCountSlowFinder(startCombination, targetCombination, forbiddenCombinations);
                watch.Start();
                int result = finder.Find();
                watch.Stop();
                long timeFast = watch.ElapsedMilliseconds;
                watch.Reset();
                watch.Start();
                int resultFromSlowFinder = slowFinder.Find();
                watch.Stop();
                long timeSlow = watch.ElapsedMilliseconds;
                Console.WriteLine("Test  {0:00}  ->  Ans fast: {1},\tAns slow: {2},\tTime fast: {3},\tTime slow: {4}", i, result, resultFromSlowFinder, timeFast, timeSlow);
            }
        }
    }
}
