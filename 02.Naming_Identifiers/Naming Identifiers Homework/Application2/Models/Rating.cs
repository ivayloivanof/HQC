namespace Mines.Models
{
    using System;
    using System.Collections.Generic;

    public static class Rating
    {
        private static void ViewRating(List<Minesweeper.zaKlasiraneto> to4kii)
        {
            Console.WriteLine("\nTo4KI:");
            if (to4kii.Count > 0)
            {
                for (int i = 0; i < to4kii.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, to4kii[i].igra4, to4kii[i].kolko);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }
    }
}
