namespace _02.ReformatYourOwnCode
{
    using System;

    class Program
    {
        static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                SqareRoot(number);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static void SqareRoot(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("Number is negative!");
            Console.WriteLine(Math.Sqrt(number));
        }
    }
}
