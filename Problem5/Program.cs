using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5
{
    public static class Program
    {
        private static void Main()
        {
            const int max = 20;
            var isPrime = new bool[max + 1];
            var primes = new List<int>();
            var factorList = new List<Tuple<int, int>>();
            double output = 0;

            // Sieve of Eratosthenes
            for (var i = 2; i <= max; i++)
            {
                isPrime[i] = true;
            }

            for (var i = 2; i <= max; i++)
            {
                if (!isPrime[i]) continue;
                for (var j = i * 2; j <= max; j += i)
                {
                    isPrime[j] = false;
                }
            }

            for (var i = 2; i <= max; i++)
            {
                if (!isPrime[i]) continue;
                primes.Add(i);
            }

            for (var i = 2; i <= 20; i++)
            {
                var factors = new List<Tuple<int, int>>();
                var test = i;

                foreach (var prime in primes)
                {
                    if (test % prime != 0) continue;

                    if (factors.All(x => x.Item1 != prime))
                    {
                        factors.Add(new Tuple<int, int>(prime, 1));
                        test /= prime;
                    }

                    while (test % prime == 0)
                    {
                        var tuple = factors.First(x => x.Item1 == prime);
                        factors.Remove(tuple);
                        factors.Add(new Tuple<int, int>(prime, tuple.Item2 + 1));
                        test /= prime;
                    }
                }

                foreach (var factor in factors)
                {
                    if (factorList.All(x => x.Item1 != factor.Item1))
                    {
                        factorList.Add(factor);
                        continue;
                    }

                    if (factorList.First(x => x.Item1 == factor.Item1).Item2 < factor.Item2)
                    {
                        factorList.Remove(factorList.First(x => x.Item1 == factor.Item1));
                        factorList.Add(factor);
                    }
                }
            }

            output = factorList.Sum(x => Math.Pow(x.Item1, x.Item2));

            Console.WriteLine($"Answer: {output}");

            Console.ReadKey();
        }
    }
}