using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hanoi;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie8Test
    {
        [TestMethod]
        public void test_czy_zadanie8_przykład()
        {
            for (int i = 0; i <= 16; i++)
            {
                var hanoi = new HanoiTowers(n: i);
                var solve = new RekurencyjnyHanoiSolver();
                solve.solveHanoi(hanoi);
                //hanoi.Print();
            }
        }
    }
}
