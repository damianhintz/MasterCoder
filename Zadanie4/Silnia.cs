using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorialTrailingZeros
{
    public class Silnia : IFactorialTrailingZeros
    {
        public new static IFactorialTrailingZeros GetInstance()
        {
            factorialInstance = new Silnia();
            return factorialInstance;
        }

        public override int CalculateCount(int number, int b)
        {
            return NumberOfZeros(number, b);
        }

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

        int NumberOfZeros(int n, int b)
        {
            int numberOfZeros = n;
            int j = b;
            for (int i = 2; i <= b; i++)
            {
                if (j % i != 0) continue;
                int p = CalculateP(ref j, i);
                int c = CalculateC(n, i);
                numberOfZeros = Math.Min(numberOfZeros, c / p);
            }
            return numberOfZeros;
        }

        static int CalculateP(ref int j, int i)
        {
            int p = 0;
            while (j % i == 0)
            {
                p++;
                j /= i;
            }

            return p;
        }

        static int CalculateC(int n, int p)
        {
            int mu = 0;
            while (n / p > 0)
            {
                mu += n / p;
                n /= p;
            }
            return mu;
        }

    }
}
