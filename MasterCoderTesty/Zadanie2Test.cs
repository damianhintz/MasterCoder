using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Containers;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie2Test
    {
        [TestMethod]
        public void test_czy_przykład_1()
        {
            var kontenery = new List<int>(new[] { 20, 15, 10, 10, 8, 5 });
            var stacja = new StacjaKosmiczna();
            var liczbaKontenerów = stacja.countCombinations(
                fuelVolume: 40,
                containers: kontenery);
            Assert.AreEqual(expected: 3, actual: liczbaKontenerów);
        }

        [TestMethod]
        public void test_czy_przykład_2()
        {
            var kontenery = new List<int>(new[] { 42, 41, 4, 3, 1, 1 });
            var stacja = new StacjaKosmiczna();
            var liczbaKontenerów = stacja.countCombinations(
                fuelVolume: 44,
                containers: kontenery);
            Assert.AreEqual(expected: 2, actual: liczbaKontenerów);
        }

        [TestMethod]
        public void test_czy_przykład_3()
        {
            var kontenery = new List<int>(new[] { 7, 4 });
            var stacja = new StacjaKosmiczna();
            var liczbaKontenerów = stacja.countCombinations(
                fuelVolume: 10,
                containers: kontenery);
            Assert.AreEqual(expected: 0, actual: liczbaKontenerów);
        }
    }
}
