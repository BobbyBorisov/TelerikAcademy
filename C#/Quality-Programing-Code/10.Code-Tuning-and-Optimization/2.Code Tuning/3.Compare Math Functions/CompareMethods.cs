using System;
using System.Linq;

namespace CompareMathFunctions
{
    public static class CompareMethods
    {
        public const int Repeat = 100000;

        public static void SquareRoot(float value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sqrt(value);
            }
        }

        public static void SquareRoot(int value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sqrt(value);
            }
        }

        public static void SquareRoot(long value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sqrt(value);
            }
        }

        public static void SquareRoot(double value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sqrt(value);
            }
        }

        public static void SquareRoot(decimal value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sqrt((double)value);
            }
        }

        public static void NaturalLogarithm(float value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Log(value);
            }
        }

        public static void NaturalLogarithm(int value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Log(value);
            }
        }

        public static void NaturalLogarithm(long value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Log(value);
            }
        }

        public static void NaturalLogarithm(double value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Log(value);
            }
        }

        public static void NaturalLogarithm(decimal value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Log((double)value);
            }
        }

        public static void Sinus(float value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sin(value);
            }
        }

        public static void Sinus(int value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sin(value);
            }
        }

        public static void Sinus(long value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sin(value);
            }
        }

        public static void Sinus(double value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sin(value);
            }
        }

        public static void Sinus(decimal value)
        {
            for (int i = 0; i < Repeat; i++)
            {
                Math.Sin((double)value);
            }
        }
    }
}
