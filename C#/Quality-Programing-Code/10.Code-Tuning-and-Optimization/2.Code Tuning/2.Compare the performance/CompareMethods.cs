using System;
using System.Diagnostics;

namespace CompareThePerformance
{
    public class CompareMethods
    {
        public const int Repeat = 100000;

        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.Write(stopwatch.Elapsed);
        }

        public static void Add(int value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value += 100;
            }
        }
        public static void Add(long value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value += 100L;
            }
        }
        public static void Add(float value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value += 100F;
            }
        }
        public static void Add(double value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value += 100;
            }
        }
        public static void Add(decimal value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value += 100M;
            }
        }

        public static void Substract(int value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value -= 100;
            }
        }
        public static void Substract(long value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value -= 100L;
            }
        }
        public static void Substract(float value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value -= 100F;
            }
        }
        public static void Substract(double value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value -= 100;
            }
        }
        public static void Substract(decimal value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value -= 100M;
            }
        }

        public static void Increment(int value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value++;
            }
        }
        public static void Increment(long value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value++;
            }
        }
        public static void Increment(float value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value++;
            }
        }
        public static void Increment(double value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value++;
            }
        }
        public static void Increment(decimal value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value++;
            }
        }

        public static void Multiply(int value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 10 * 10;
            }
        }
        public static void Multiply(long value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 10L * 10L;
            }
        }
        public static void Multiply(float value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 10F * 10F;
            }
        }
        public static void Multiply(double value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 10 * 10;
            }
        }
        public static void Multiply(decimal value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 10M * 10M;
            }
        }

        public static void Divide(int value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 100 / 10;
            }
        }
        public static void Divide(long value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 100L / 10L;
            }
        }
        public static void Divide(float value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 100F / 10F;
            }
        }
        public static void Divide(double value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 100 / 10;
            }
        }
        public static void Divide(decimal value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                value = 100M / 10M;
            }
        }
    }
}
