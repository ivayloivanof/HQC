namespace TankFactory
{
    using System;

    using Units;

    internal class Program
    {
        public static void Main()
        {
            TankFactory tiger = new GermanTankFactory();
            tiger.CreateTank();
            TankFactory t34 = new RussianTankFactory();
            t34.CreateTank();
            TankFactory m1Abrams = new AmericanTankFactory();
            m1Abrams.CreateTank();
            
            Console.WriteLine(tiger);
            Console.WriteLine(t34);
            Console.WriteLine(m1Abrams);
        }
    }
}
