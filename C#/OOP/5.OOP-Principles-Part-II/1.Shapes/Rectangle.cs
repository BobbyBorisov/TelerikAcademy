using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Task
{
    class Rectangle: Shape
    {
        
        public Rectangle(double height, double width)
            : base(height, width) {  }

        public override double CalculateSurface()
        {
            return Height * Width;
        }
    }
}
