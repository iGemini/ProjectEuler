using System;

namespace Problem1
{
    public static class Program
    {
        // https://projecteuler.net/problem=1
        // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        // Find the sum of all the multiples of 3 or 5 below 1000.
        private static void Main()
        {
            const int upperBound = 999;

            // Subtract the sum of the numbers divisible by 15, as these have been added twice (3 and 5).
            var sum = SumDivisibleBy(upperBound, 3) + SumDivisibleBy(upperBound, 5) - SumDivisibleBy(upperBound, 15);

            Console.WriteLine($"Sum: {sum}");

            Console.ReadKey();
        }

        // Sum of a series of natural numbers:
        // 1 + 2 + 3 + 4 + 5 + 6 + ... + n = n * (n + 1) / 2
        // Sum of numbers divisible by 3:
        // 3 + 6 + 9 + 12 + 15 + 18 + ... + 999 = 3 * (1 + 2 + 3 + 4 + 5 + 6 + ... + 333) = 3 * 333 * (333 + 1) / 2
        // Sum of numbers divisible by 5:
        // 5 + 10 + 15 + 20 + 25 + 30 + ... + 995 = 5 * (1 + 2 + 3 + 4 + 5 + 6 + ... + 199) = 5 * 199 * (199 + 1) / 2
        private static int SumDivisibleBy(int number, int divisor)
        {
            var n = number / divisor;
            return divisor * (n * (n + 1) / 2);
        }
    }
}