using System;
using System.Diagnostics;

namespace Problem4
{
    public static class Program
    {
        // https://projecteuler.net/problem=4
        // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
        // Find the largest palindrome made from the product of two 3-digit numbers.
        private static void Main()
        {
            var timer = Stopwatch.StartNew();

            var largest = 0;

            for (var i = 999; i >= 100; i--)
            {
                for (var j = 999; j >= 100; j--)
                {
                    var prod = i * j;
                    if (prod <= largest) break;

                    if (prod != ReverseNumber(prod)) continue;

                    if (prod > largest) largest = prod;
                }
            }

            timer.Stop();

            Console.WriteLine($"Answer: {largest}, Time: {timer.ElapsedTicks}");

            Console.ReadKey();
        }

        private static int ReverseNumber(int n)
        {
            var reversed = 0;
            while (n > 0)
            {
                reversed = 10 * reversed + n % 10;
                n /= 10;
            }

            return reversed;
        }
    }
}