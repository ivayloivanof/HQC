namespace Mines.Models
{
    using System;
    using System.Collections.Generic;

    public static class Rating
    {
        private const string PointsName = "Points";

        private static void ViewRating(List<Point> points)
        {
            Console.WriteLine("\n{0}:", PointsName);

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cans", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(Messages.EmptyRaiting);
            }
        }
    }
}
