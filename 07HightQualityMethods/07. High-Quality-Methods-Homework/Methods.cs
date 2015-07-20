namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine(CalculationTriangleArea(3, 4, 5));
                Console.WriteLine(ConvertNumberToDigit(5));
                Console.WriteLine(FindMaxElementOfArray(5, -1, 3, 2, 14, 2, 3));
                Console.WriteLine();
                PrintAsNumberInSpecialFormat(1.3, "f");
                PrintAsNumberInSpecialFormat(0.75, "%");
                PrintAsNumberInSpecialFormat(2.30, "r");
                Console.WriteLine();
                var peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
                var stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

                Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
                Console.WriteLine();
                bool horizontal, vertical;
                Console.WriteLine(CalculationDistance(3, -1, 5, 2.5, out horizontal, out vertical));
                Console.WriteLine("Horizontal? " + horizontal);
                Console.WriteLine("Vertical? " + vertical);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static double CalculationTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            var s = (a + b + c) / 2;
            var area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static string ConvertNumberToDigit(byte number)
        {
            if (number < 10)
            {
                switch (number)
                {
                    case 0: return "zero";
                    case 1: return "one";
                    case 2: return "two";
                    case 3: return "three";
                    case 4: return "four";
                    case 5: return "five";
                    case 6: return "six";
                    case 7: return "seven";
                    case 8: return "eight";
                    case 9: return "nine";
                }
            }

            throw new ArgumentException("Invalid number! Not convert to digit");
        }

        public static int FindMaxElementOfArray(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Array from elements is empty.");
            }

            for (var i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static void PrintAsNumberInSpecialFormat(object number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new InvalidOperationException("This format in not correct.");
            }
        }

        public static double CalculationDistance(double x1, double y1, double x2, double y2, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);

            var distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }
    }
}
