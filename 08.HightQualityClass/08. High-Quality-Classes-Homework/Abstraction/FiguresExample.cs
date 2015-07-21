namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            try
            {
                IFigure circle = new Circle(5);
                Console.WriteLine(
                    "I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.",
                    circle.CalculationPerimeter(),
                    circle.CalculationSurface());

                IFigure rect = new Rectangle(2, 3);
                Console.WriteLine(
                    "I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.",
                    rect.CalculationPerimeter(),
                    rect.CalculationSurface());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
