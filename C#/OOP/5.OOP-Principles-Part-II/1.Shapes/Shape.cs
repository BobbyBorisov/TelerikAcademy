using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Task
{
    abstract class Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public abstract double CalculateSurface();

        public Shape(double height, double width) {
            this.Height = height;
            this.Width = width;
        }
    }
}
