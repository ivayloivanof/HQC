namespace CohesionAndCoupling
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class UtilsExamples
    {
        public static void Main()
        {
            try
            {
                //Console.WriteLine(Utils.GetFileExtension("example"));
                Console.WriteLine(File.GetFileExtension("example.pdf"));
                Console.WriteLine(File.GetFileExtension("example.new.pdf"));

                //Console.WriteLine(Utils.GetFileNameWithoutExtension("example"));
                Console.WriteLine(File.GetFileNameWithoutExtension("example.pdf"));
                Console.WriteLine(File.GetFileNameWithoutExtension("example.new.pdf"));

                Console.WriteLine("Distance in the 2D space = {0:f2}", Utils.CalculationDistance2D(1, -2, 3, 4));
                Console.WriteLine("Distance in the 3D space = {0:f2}", Utils.CalculationDistance3D(5, 2, -1, 3, -6, 4));

                Utils.Width = 3;
                Utils.Height = 4;
                Utils.Depth = 5;
                Console.WriteLine("Volume = {0:f2}", Utils.CalculationVolume());
                Console.WriteLine("Diagonal XYZ = {0:f2}", Utils.CalculationDiagonalXYZ());
                Console.WriteLine("Diagonal XY = {0:f2}", Utils.CalculationDiagonalXY());
                Console.WriteLine("Diagonal XZ = {0:f2}", Utils.CalculationDiagonalXZ());
                Console.WriteLine("Diagonal YZ = {0:f2}", Utils.CalculationDiagonalYZ());
            }
            catch (FileMissingExtension ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
