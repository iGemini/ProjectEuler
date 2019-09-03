using System;
using System.Diagnostics;
using System.Linq;

namespace Problem6
{
    public static class Program
    {
        // https://projecteuler.net/problem=6
        // The sum of the squares of the first ten natural numbers is,
        // 12 + 22 + ... + 102 = 385
        //
        // The square of the sum of the first ten natural numbers is,
        // (1 + 2 + ... + 10)2 = 552 = 3025
        //
        // Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is
        // 3025 − 385 = 2640.
        //
        // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        private static void Main()
        {
            const int n = 100;

            var timer = Stopwatch.StartNew();

            // Sum of integers from 1 to n = n * (n + 1) / 2
            var squareOfSum = Math.Pow(n * (n + 1) / 2, 2);

            var sumOfSquares = Enumerable.Range(1, 100).Sum(x => Math.Pow(x, 2));

            timer.Stop();

            Console.WriteLine($"Answer: {squareOfSum - sumOfSquares}, Time: {timer.ElapsedTicks}");

            Console.ReadKey();
        }
    }
}