using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorialTrailingZeros
{
    public class SilniaZero : IFactorialTrailingZeros
    {
        public new static IFactorialTrailingZeros GetInstance()
        {
            factorialInstance = new SilniaZero();
            return factorialInstance;
        }

        public override int CalculateCount(int number, int b)
        {
            return NumberOfZeros(number, b);
        }

        int NumberOfZeros(int n, int b)
        {
            int numberOfZeros = n;
            var factors = FactorBase(b);
            foreach (var tuple in factors)
            {
                var primeFactor = tuple.Item1;
                var exponent = tuple.Item2;
                int primeTimes = HighestPowerOfP(n, primeFactor);
                numberOfZeros = Math.Min(numberOfZeros, primeTimes / exponent);
            }
            return numberOfZeros;
        }

        /// <summary>
        /// Rozkład podstawy na czynniki pierwsze.
        /// </summary>
        /// <param name="b">base</param>
        /// <returns></returns>
        IEnumerable<Tuple<int, int>> FactorBase(int b)
        {
            for (int prime = 2; prime <= b; prime++)
            {
                if (b % prime != 0) continue; //to nie jest czynnik pierwszy
                var countFactors = 0;
                do
                {
                    b /= prime;
                    countFactors++;
                } while (b % prime == 0);
                yield return new Tuple<int, int>(prime, countFactors);
            }
        }

        /// <summary>
        /// [n/p] + [n/p^2] + [n/p^3] + [n/p^4] + ...
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        int HighestPowerOfP(int n, int p)
        {
            int mu = 0;
            while (n / p > 0)
            {
                mu += n / p;
                n /= p;
            }
            return mu;
        }

        /// <summary>
        /// Przypadek dla podstawy 10.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        int CalculateCount10(int number, int b)
        {
            //Z = floor(n / 5) + floor(n / 5 ^ 2) + ... + floor(n / 5 ^ k)
            //k = floor(log5(n))
            double n = number;
            int kMax = (int)Math.Floor(Math.Log(n, 5));
            int fivePower = 5;
            int z = 0;
            for (int k = 1; k <= kMax; k++)
            {
                z += (int)Math.Floor(n / fivePower);
                fivePower *= 5;
            }
            return z;
        }

    }
}
