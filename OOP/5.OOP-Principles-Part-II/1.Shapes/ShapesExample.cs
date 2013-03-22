using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Task
{
    class ShapesExample
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>()
        {
            new Rectangle(2,3),
            new Triangle(4,3),
            new Circle(4,2)
        };

            foreach (Shape item in shapes)
            {
                Console.WriteLine("Shape = {0} surface = {1:F2}",
                item.GetType().Name.PadRight(9, ' '),
                item.CalculateSurface());
            }
        }
    }
}
