namespace CohesionAndCoupling
{
    using System;

    public static class Utils
    {
        public static double Width { get; set; }

        public static double Height { get; set; }

        public static double Depth { get; set; }
        
        public static double CalculationDistance2D(double x1, double y1, double x2, double y2)
        {
            var distance = Math.Sqrt(
                                    ((x2 - x1) * (x2 - x1)) + 
                                    ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static double CalculationDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            var distance = Math.Sqrt(
                                    ((x2 - x1) * (x2 - x1)) + 
                                    ((y2 - y1) * (y2 - y1)) + 
                                    ((z2 - z1) * (z2 - z1)));
            return distance;
        }

        public static double CalculationVolume()
        {
            var volume = Width * Height * Depth;
            return volume;
        }
            
        // ReSharper disable once InconsistentNaming
        public static double CalculationDiagonalXYZ()
        {
            var distance = CalculationDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        // ReSharper disable once InconsistentNaming
        public static double CalculationDiagonalXY()
        {
            var distance = CalculationDistance2D(0, 0, Width, Height);
            return distance;
        }

        // ReSharper disable once InconsistentNaming
        public static double CalculationDiagonalXZ()
        {
            var distance = CalculationDistance2D(0, 0, Width, Depth);
            return distance;
        }

        // ReSharper disable once InconsistentNaming
        public static double CalculationDiagonalYZ()
        {
            var distance = CalculationDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}
