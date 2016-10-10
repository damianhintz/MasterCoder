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

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void test_czy_zadanie4_tylko_base_10()
        {
            var f = Base10SilniaZero.GetInstance();
            f.CalculateCount(number: 30, b: 11);
            Assert.Fail();
        }

        [TestMethod]
        public void test_czy_zadanie4_base_10()
        {
            var f = Base10SilniaZero.GetInstance();
            var z = f.CalculateCount(number: 0, b: 10);
            Assert.AreEqual(expected: 0, actual: z);
        }

        [TestMethod]
        public void test_czy_zadanie4_vs_base_10()
        {
            for (int i = 0; i < 1000000; i++)
            {
                var f10 = Base10SilniaZero.GetInstance();
                var z10 = f10.CalculateCount(number: i, b: 10);
                var f = SilniaZero.GetInstance();
                var z = f.CalculateCount(number: i, b: 10);
                Assert.AreEqual(expected: z10, actual: z);
            }
        }
    }
}
