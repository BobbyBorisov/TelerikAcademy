using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_II
{
    class TestPoint3D
    {

        static void Main() {

            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point0 = new Point3D(0, 0, 0);

            string test = point1.ToString();
            Console.WriteLine(test);

            CalculateDistance.Calc(Point3D.GetStart(), point1);
        }
    }
}
