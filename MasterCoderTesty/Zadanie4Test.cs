using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactorialTrailingZeros;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie4Test
    {
        [TestMethod]
        public void test_czy_zadanie4_przykład_0()
        {
            var f = SilniaZero.GetInstance();
            var z = f.CalculateCount(number: 0, b: 10);
            Assert.AreEqual(expected: 0, actual: z);
        }

        [TestMethod]
        public void test_czy_zadanie4_przykład_1()
        {
            var f = SilniaZero.GetInstance();
            var z = f.CalculateCount(number: 11, b: 3);
            Assert.AreEqual(expected: 4, actual: z);
        }

        [TestMethod]
        public void test_czy_zadanie4_przykład_2()
        {
            var f = SilniaZero.GetInstance();
            var z = f.CalculateCount(number: 13, b: 7);
            Assert.AreEqual(expected: 1, actual: z);
        }

        [TestMethod]
        public void test_czy_zadanie4_przykład_3()
        {
            var f = SilniaZero.GetInstance();
            var z = f.CalculateCount(number: 15, b: 10);
            Assert.AreEqual(expected: 3, actual: z);
        }

        [TestMethod]
        public void test_czy_zadanie4_przykład_4()
        {
            var f = SilniaZero.GetInstance();
            var z = f.CalculateCount(number: 30, b: 16);
            Assert.AreEqual(expected: 6, actual: z);
        }
    }
}
