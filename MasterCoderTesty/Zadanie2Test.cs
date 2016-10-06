using System;
using System.Linq;
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
            var stacja = StacjaKosmiczna.GetInstance();
            var liczbaKontenerów = stacja.countCombinations(
                fuelVolume: 40,
                containers: kontenery);
            Assert.AreEqual(expected: 3, actual: liczbaKontenerów);
        }

        [TestMethod]
        public void test_czy_przykład_1_nieposortowany()
        {
            var kontenery = new List<int>(new[] { 5, 8, 10, 15, 10, 20 });
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
        public void test_czy_przykład_2_nieposortowany()
        {
            var kontenery = new List<int>(new[] { 3, 4, 1, 1, 42, 41 });
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

        [TestMethod]
        public void test_czy_zadanie_2_brak_kontenerów()
        {
            var kontenery = new List<int>();
            var stacja = new StacjaKosmiczna();
            var liczbaKontenerów = stacja.countCombinations(
                fuelVolume: 10,
                containers: kontenery);
            Assert.AreEqual(expected: 0, actual: liczbaKontenerów);
        }

        [TestMethod]
        public void test_czy_zadanie_2_ujemne_paliwo()
        {
            var kontenery = new List<int>(new int[] { 1 });
            var stacja = new StacjaKosmiczna();
            var liczbaKontenerów = stacja.countCombinations(
                fuelVolume: -1,
                containers: kontenery);
            Assert.AreEqual(expected: 0, actual: liczbaKontenerów);
        }

        [TestMethod]
        public void test_czy_zadanie_2_wszystkie_kontenery()
        {
            var kontenery = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            var stacja = new StacjaKosmiczna();
            var liczbaKontenerów = stacja.countCombinations(
                fuelVolume: kontenery.Sum(),
                containers: kontenery);
            Assert.AreEqual(expected: kontenery.Count, actual: liczbaKontenerów);
        }

        [TestMethod]
        public void test_czy_zadanie_2_tylko_1_kontener()
        {
            var kontenery = new List<int>();
            for (int i = 1; i < 100; i++) kontenery.Add(i);
            var stacja = new StacjaKosmiczna();
            for (int i = 1; i < kontenery.Count; i++)
            {
                var liczbaKontenerów = stacja.countCombinations(
                    fuelVolume: i,
                    containers: kontenery);
                Assert.AreEqual(expected: 1, actual: liczbaKontenerów);
            }
        }
    }
}
