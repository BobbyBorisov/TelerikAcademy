namespace Methods
{
    using System;
    
    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException();
            }

            double sum = (a + b + c) / 2;
            double area = Math.Sqrt(sum * (sum - a) * (sum - b) * (sum - c));
            return area;
        }

        public static string NumberToText(int number)
        {
            var result = string.Empty;

            switch (number)
            {
                case 0: 
                        result = "zero";
                        break;
                case 1: 
                        result = "zero";
                        break;
                case 2: 
                        result = "zero";
                        break;
                case 3: 
                        result = "zero";
                        break;
                case 4: 
                        result = "zero";
                        break;
                case 5: 
                        result = "zero";
                        break;
                case 6: 
                        result = "zero";
                        break;
                case 7: 
                        result = "zero";
                        break;
                case 8: 
                        result = "zero";
                        break;
                case 9: 
                        result = "zero";
                        break;
                default:
                        result = "invalid number";
                        break;
            }

            return result;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException();
            }

            var max = int.MinValue;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            } 
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            } 
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = y1 == y2;
            isVertical = x1 == x2;

            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToText(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ïvanov", "Sofia", new DateTime(1992, 3, 17));
            Student stella = new Student("Stella", "Markova", "Vidin", new DateTime(1993, 11, 3));

            var isOlderThan = peter.IsOlderThan(stella);
            if (isOlderThan < 0) 
            {
                Console.WriteLine("Is older");
            }
            else if (isOlderThan > 0)
            {
                Console.WriteLine("Is younger");
            }
            else 
            {
                Console.WriteLine("Are on the same age");
            }
        }
    }
}
