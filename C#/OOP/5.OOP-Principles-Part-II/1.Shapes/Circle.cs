using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Task
{
    class Circle: Shape
    {

        public Circle(double radius)
            :base(radius,radius) {  }
       
        public override double CalculateSurface()
        {
            return (Math.PI * (Height / 2) * (Height / 2));
        }
    }
}
