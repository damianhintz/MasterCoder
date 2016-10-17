using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrequencyDistributor;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie10Test
    {
        [TestMethod]
        public void test_czy_zadanie10_dim_0()
        {
            var z10 = Kolonizator.GetInstance();
            var f = new List<int>() { 1 };
            var result = z10.distribute(dimA: 3, dimB: 0, frequencies: f, minDiff: 1);
            Assert.AreEqual(expected: 0, actual: result.Count);
        }

        [TestMethod]
        public void test_czy_zadanie10_frequencies_0()
        {
            var z10 = Kolonizator.GetInstance();
            var f = new List<int>() { };
            var result = z10.distribute(dimA: 3, dimB: 3, frequencies: f, minDiff: 1);
            Assert.AreEqual(expected: 0, actual: result.Count);
        }

        [TestMethod]
        public void test_czy_zadanie10_mindiff_0()
        {
            var z10 = Kolonizator.GetInstance();
            var f = new List<int>() { 1, 2, 3, 4, 5 };
            var result = z10.distribute(dimA: 3, dimB: 3, frequencies: f, minDiff: 0);
            Assert.AreEqual(expected: 3 * 3, actual: result.Count);
            foreach (var ff in result) Assert.AreEqual(1, ff);
        }

        [TestMethod]
        public void test_czy_zadanie10_3x3_4()
        {
            var z10 = Kolonizator.GetInstance();
            var f = new List<int>() { 1, 2, 3, 4 };
            var result = z10.distribute(dimA: 3, dimB: 3, frequencies: f, minDiff: 1);
            Assert.AreEqual(expected: 3 * 3, actual: result.Count);
            var expected = new int[] { 1, 2, 1, 3, 4, 3, 1, 2, 1 };
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], result[i]);
        }

        [TestMethod]
        public void test_czy_zadanie10_3x3_3()
        {
            var z10 = Kolonizator.GetInstance();
            var f = new List<int>() { 1, 2, 3 };
            var result = z10.distribute(dimA: 3, dimB: 3, frequencies: f, minDiff: 1);
            Assert.AreEqual(expected: 0, actual: result.Count);
        }

        [TestMethod]
        public void test_czy_zadanie10_2x2()
        {
            var z10 = Kolonizator.GetInstance();
            var f = new List<int>() { 1, 2, 3 };
            var result = z10.distribute(dimA: 2, dimB: 2, frequencies: f, minDiff: 1);
            Assert.AreEqual(expected: 0, actual: result.Count);
        }

        [TestMethod]
        public void test_czy_zadanie10_5x1()
        {
            var z10 = Kolonizator.GetInstance();
            var f = new List<int>() { 1, 2 };
            var result = z10.distribute(dimA: 5, dimB: 1, frequencies: f, minDiff: 1);
            Assert.AreEqual(expected: 1 * 5, actual: result.Count);
            var expected = new int[] { 1, 2, 1, 2, 1 };
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], result[i]);
        }

        [TestMethod]
        public void test_czy_zadanie10_przykład()
        {
            var z10 = Kolonizator.GetInstance();
            var f = new List<int>();
            for (int i = 1; i <= 16; i++) f.Add(i);
            var result = z10.distribute(dimA: 7, dimB: 5, frequencies: f, minDiff: 3);
            Assert.AreEqual(expected: 7 * 5, actual: result.Count);
            foreach (var ff in result) Assert.IsTrue(ff >= 1 && ff <= 16);
            //AssertDist result, 3
        }
    }
}
