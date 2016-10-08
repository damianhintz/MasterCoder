using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactorialTrailingZeros;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie4Test
    {
        [TestMethod]
        public void test_czy_zadanie4_przykład_1()
        {
            var f = Silnia.GetInstance();
            var z = f.CalculateCount(number: 11, b: 3);
            Assert.AreEqual("2210002222120000", Silnia.CalculateString(11, 3));
            Assert.AreEqual(expected: 4, actual: z);
        }
    }
}
