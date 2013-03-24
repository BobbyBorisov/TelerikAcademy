using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_II
{
    public static class CalculateDistance
    {
        private static double distance;
        
        public static void Calc(Point3D point1, Point3D point2) {
            distance = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2) + Math.Pow(point2.Z - point1.Z, 2));
            Console.WriteLine("Distance:{0}",distance);
        }
    }
}
