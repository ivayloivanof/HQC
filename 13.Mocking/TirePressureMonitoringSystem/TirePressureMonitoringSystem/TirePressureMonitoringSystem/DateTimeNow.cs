namespace TirePressureMonitoringSystem
{
    using System;

    public class DateTimeNow
    {
        public static void Main()
        {
            DateTime now = DateTime.Now;
            DateTime tommorow = DateTime.Now.AddDays(1);

            Console.WriteLine(now);
            Console.WriteLine(tommorow);
        }
    }
}
