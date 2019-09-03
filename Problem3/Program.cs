using System;

namespace Problem3
{
    public static class Program
    {
        // https://projecteuler.net/problem=3
        // The prime factors of 13195 are 5, 7, 13 and 29.
        // What is the largest prime factor of the number 600851475143 ?
        private static void Main()
        {
            var number = 6008514751430;
            int lastFactor;

            // Divide out all the 2s as 2 is the only even prime.
            // This lets us increase potential factors by 2 after this point, reducing search space.
            if (number % 2 == 0)
            {
                lastFactor = 2;
                number /= 2;
                while (number % 2 == 0) number /= 2;
            }
            else
            {
                lastFactor = 1;
            }

            var factor = 3;
            var maxFactor = Math.Sqrt(number);
            while (number > 1 && factor <= maxFactor)
            {
                if (number % factor == 0)
                {
                    number /= factor;
                    lastFactor = factor;

                    // Completely divide out each factor, so the next factor we encounter is guaranteed to be prime.
                    while (number % factor == 0) number /= factor;

                    maxFactor = Math.Sqrt(number);
                }

                // We can do this because the only even prime (2), has been fully factored out earlier.
                factor += 2;
            }

            // If the number has been completely reduced to 1, lastFactor is its largest prime factor.
            // Else, the remaining value of number is the number's largest prime factor.
            Console.WriteLine(number == 1 ? $"Answer: {lastFactor}" : $"Answer: {number}");

            Console.ReadKey();
        }
    }
}