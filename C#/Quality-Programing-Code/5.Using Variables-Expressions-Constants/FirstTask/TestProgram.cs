namespace FigureManipulator
{
    using System;
    using System.Linq;

    public class TestProgram
    {
        public static void Main()
        {
            var rectangle = new Figure(10, 15);
            var newFigure = Figure.GetRotatedFigure(rectangle, 10);
            Console.WriteLine(rectangle.ToString());
            Console.WriteLine(newFigure.ToString());
        }
    }
}
