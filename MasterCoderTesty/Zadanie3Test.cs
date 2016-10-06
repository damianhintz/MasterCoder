using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightBulbs;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie3Test
    {
        [TestMethod]
        public void test_czy_zadanie3_przykład()
        {
            //.#.#..
            //...##.
            //#..#.#
            //..##..
            //#.#..#
            //.###..
            var sygnały = TajemniczeSygnaly.GetInstance();
            var board = new bool[6, 6] {
                { false, true, false, true, false, false },
                { false, false, false, true, true, false },
                { true, false, false, true, false, true },
                { false, false, true, true, false, false },
                { true, false, true, false, false, true },
                { false, true, true, true, false, false },
            };
            var on = sygnały.CountLightsOn(lightsBoard: board, s: 4);
            Assert.AreEqual(expected: 5, actual: on);
        }

        [TestMethod]
        public void test_czy_zadanie3_pusta_tablica()
        {
            var sygnały = TajemniczeSygnaly.GetInstance();
            var board = new bool[72, 72];
            var on = sygnały.CountLightsOn(lightsBoard: board, s: 1000);
            Assert.AreEqual(expected: 0, actual: on);
        }

        [TestMethod]
        public void test_czy_zadanie3_jedno_światło_po_1()
        {
            var sygnały = TajemniczeSygnaly.GetInstance();
            var board = new bool[72, 72];
            board[0, 1] = true;
            var on = sygnały.CountLightsOn(lightsBoard: board, s: 1);
            Assert.AreEqual(expected: 0, actual: on);
        }

        [TestMethod]
        public void test_czy_zadanie3_jedno_światło_po_2()
        {
            var sygnały = TajemniczeSygnaly.GetInstance();
            var board = new bool[72, 72];
            board[0, 1] = true;
            var on = sygnały.CountLightsOn(lightsBoard: board, s: 2);
            Assert.AreEqual(expected: 0, actual: on);
        }

        [TestMethod]
        public void test_czy_zadanie3_wszystkie_światła_po_jednej_iteracji_72x72()
        {
            var sygnały = TajemniczeSygnaly.GetInstance();
            var board = new bool[72, 72];
            for (int i = 0; i < 72; i++)
                for (int j = 0; j < 72; j++)
                    board[i, j] = true;
            board[0, 0] = board[0, 71] = board[71, 0] = board[71, 71] = false;
            var on = sygnały.CountLightsOn(lightsBoard: board, s: 1);
            Assert.AreEqual(expected: 0, actual: on);
        }

        [TestMethod]
        public void test_czy_zadanie3_wszystkie_światła_po_jednej_iteracji_3x3()
        {
            var sygnały = TajemniczeSygnaly.GetInstance();
            var board = new bool[3, 3] {
                { false, true, false },
                { true, true, true },
                { false, true, false } };
            var on = sygnały.CountLightsOn(lightsBoard: board, s: 1);
            Assert.AreEqual(expected: 4, actual: on);
        }

        [TestMethod]
        public void test_czy_zadanie3_wszystkie_światła_po_jednej_iteracji_4x4()
        {
            var sygnały = TajemniczeSygnaly.GetInstance();
            var board = new bool[4, 4] {
                { false, true, true, false },
                { true, true, true, true },
                { true, true, true, true },
                { false, true, true, false } };
            var on = sygnały.CountLightsOn(lightsBoard: board, s: 1);
            Assert.AreEqual(expected: 0, actual: on);
        }
    }
}
