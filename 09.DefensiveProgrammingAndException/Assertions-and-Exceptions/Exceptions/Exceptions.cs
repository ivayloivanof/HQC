namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Exceptions
    {
        public static void Main()
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            try
            {
                Console.WriteLine(ExtractEnding("I love C#", 2));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(ExtractEnding("Nakov", 4));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(ExtractEnding("beer", 4));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(ExtractEnding("Hi", 100));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            try
            {
                Console.WriteLine("{0} is prime", CheckPrime(23));
            }
            catch (IsNotPrimeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("{0} is prime", CheckPrime(33));
                Console.WriteLine("33 is prime.");
            }
            catch (IsNotPrimeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var peterExams = new List<Exam>()
                                        {
                                            new SimpleMathExam(2),
                                            new CSharpExam(55),
                                            new CSharpExam(100),
                                            new SimpleMathExam(1),
                                            new CSharpExam(0),
                                        };
            var peter = new Student("Peter", "Petrov", peterExams);
            var peterAverageResult = peter.CalcAverageExamResultInPercents();

            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }

        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            var result = new List<T>();
            for (var i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("The number of elements in string, is greater than the length of string.");
            }

            var result = new StringBuilder();
            for (var i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static int CheckPrime(int number)
        {
            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    throw new IsNotPrimeException(String.Format("The number {0}, is not prime!", number));
                }
            }

            return number;
        }
    }
}
