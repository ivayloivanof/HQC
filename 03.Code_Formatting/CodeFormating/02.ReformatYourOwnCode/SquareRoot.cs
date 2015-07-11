namespace _02.ReformatYourOwnCode
{
    using System;

    public class SquareRoot
    {
        public static void Start()
        {
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                SqareRoot(number);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static void SqareRoot(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("number", "Number is negative!");
            }

            Console.WriteLine(Math.Sqrt(number));
        }
    }
}
