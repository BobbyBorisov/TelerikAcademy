namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public Figure()
        {
        }

        public Figure(double radius)
        {
            this.Radius = radius;
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width { get; set; }

        public virtual double Height { get; set; }

        public virtual double Radius { get; set; }
        
        protected abstract double CalcPerimeter();

        protected abstract double CalcSurface();
    }
}
