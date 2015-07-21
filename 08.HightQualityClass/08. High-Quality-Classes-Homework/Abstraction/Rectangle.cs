namespace Abstraction
{
    using System;

    public class Rectangle : IFigure
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
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

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be negative or zero.");
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

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be negative or zero.");
                }

                this.height = value;
            }
        }

        public double CalculationPerimeter()
        {
            var perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalculationSurface()
        {
            var surface = this.Width * this.Height;
            return surface;
        }
    }
}
