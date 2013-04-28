namespace FigureManipulator
{
    using System;
    using System.Linq;

    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get 
            {
                return this.width;
            }
            
            set 
            {
                if (value < 0) 
                {
                    throw new ArgumentException("Width cannot be negative number!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get 
            {
                return this.height; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be negative number!");
                }

                this.height = value;
            }
        }
        
        public static Figure GetRotatedFigure(Figure figure, double rotatingAngle)
        {
            double cosOfAngle = Math.Cos(rotatingAngle);
            double sinOfAngle = Math.Sin(rotatingAngle);

            var newWidth = (Math.Abs(cosOfAngle) * figure.Width) +
                        (Math.Abs(sinOfAngle) * figure.Height);

            var newHeight = (Math.Abs(sinOfAngle) * figure.Width) +
                         (Math.Abs(cosOfAngle) * figure.Height);
            
            return new Figure(newWidth, newHeight);
        }

        public override string ToString()
        {
            return string.Format("width:{0}, height:{1}", this.Width, this.Height);
        }
    }
}
