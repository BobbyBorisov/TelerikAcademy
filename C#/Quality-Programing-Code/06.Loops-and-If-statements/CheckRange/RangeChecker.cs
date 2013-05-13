namespace CheckRange
{
    using System;
    using System.Linq;

    public class RangeChecker
    {
        public static void Main(string[] args)
        {
            var x = 3;
            var y = 5;
            var min = 0;
            var maxX = 10;
            var maxY = 15;
            var visited = false;

            if (IsInRange(x, min, maxX) && IsInRange(y, min, maxY) && !visited)
            {
               VisitCell(x, y);
               visited = true;
            }
        }

        public static bool IsInRange(int x, int minX, int maxX) 
        {
            bool check = (x >= minX) && (x <= maxX);

            return check;
        }

        private static void VisitCell(int x, int y) 
        {
            Console.WriteLine("Visiting cell[{0},{1}]", x, y);
        }
    }
}
