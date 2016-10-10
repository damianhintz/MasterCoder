using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchangeProfit;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie5Test
    {
        [TestMethod]
        public void test_czy_zadanie5_przykład()
        {
            var z5 = KupnoAkcji.GetInstance();
            var values = new int[] { 5, 10, 2, 1, 3, 4, 9, 9, 8, 8 };
            var result = z5.FindMaxProfitRecursive(values.ToList());
            Assert.AreEqual(expected: 8, actual: result.Value);
            Assert.AreEqual(expected: 3, actual: result.LeftIndex);
            Assert.AreEqual(expected: 6, actual: result.RightIndex);
        }

        [TestMethod]
        public void test_czy_zadanie5_2()
        {
            var z5 = KupnoAkcji.GetInstance();
            var values = new int[] { 5, 10 };
            var result = z5.FindMaxProfitRecursive(values.ToList());
            Assert.AreEqual(expected: 5, actual: result.Value);
            Assert.AreEqual(expected: 0, actual: result.LeftIndex);
            Assert.AreEqual(expected: 1, actual: result.RightIndex);
        }

        [TestMethod]
        public void test_czy_zadanie5_1000000()
        {
            var z5 = KupnoAkcji.GetInstance();
            var values = new List<int>(new int[1000000]);
            values[0] = 1;
            values[values.Count - 1] = 2;
            var result = z5.FindMaxProfitRecursive(values);
            Assert.AreEqual(expected: 2, actual: result.Value);
            Assert.AreEqual(expected: 1, actual: result.LeftIndex);
            Assert.AreEqual(expected: 999999, actual: result.RightIndex);
        }

        [TestMethod]
        public void test_czy_zadanie5_4()
        {
            var z5 = KupnoAkcji.GetInstance();
            var values = new int[] { 2, 1, 1, 2, 1, 3, 2, 5 };
            var result = z5.FindMaxProfitRecursive(values.ToList());
            Assert.AreEqual(expected: 4, actual: result.Value);
            Assert.AreEqual(expected: 1, actual: result.LeftIndex);
            Assert.AreEqual(expected: 7, actual: result.RightIndex);
        }

        [TestMethod]
        public void test_czy_zadanie5_3()
        {
            var z5 = KupnoAkcji.GetInstance();
            var values = new int[] { 3, 1, 3 };
            var result = z5.FindMaxProfitRecursive(values.ToList());
            Assert.AreEqual(expected: 2, actual: result.Value);
            Assert.AreEqual(expected: 1, actual: result.LeftIndex);
            Assert.AreEqual(expected: 2, actual: result.RightIndex);
        }
    }
}
