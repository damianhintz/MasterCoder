using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

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
            var big = BigInteger.One;
            for (int i = 2; i <= number; i++)
            {
                var iBig = new BigInteger(i);
                big = BigInteger.Multiply(big, iBig);
            }
            var s = big.ToString("X" + b);
            int c = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != '0') break;
                c++;
            }
            return c;
        }

        public static string CalculateString(int number, int b)
        {
            var big = BigInteger.One;
            for (int i = 2; i <= number; i++)
            {
                var iBig = new BigInteger(i);
                big = BigInteger.Multiply(big, iBig);
            }
            var s = big.ToString("X" + b);
            return s;
        }
    }
}
