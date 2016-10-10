using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorialTrailingZeros
{
    public class Base10SilniaZero : IFactorialTrailingZeros
    {
        public new static IFactorialTrailingZeros GetInstance()
        {
            factorialInstance = new Base10SilniaZero();
            return factorialInstance;
        }

        public override int CalculateCount(int number, int b)
        {
            if (b != 10) throw new ArgumentOutOfRangeException();
            return CalculateCount10(number, b);
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
