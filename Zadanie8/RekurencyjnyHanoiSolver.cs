using System;
using System.Collections.Generic;
using System.Linq;

namespace Hanoi
{
    public class RekurencyjnyHanoiSolver : IHanoiSolver
    {
        public new static IHanoiSolver GetInstance()
        {
            m_hanoiSolverInstance = new RekurencyjnyHanoiSolver();
            return m_hanoiSolverInstance;
        }

        public override void solveHanoi(IHanoi hanoi)
        {
            int n = hanoi.getNumberOfDisks();
            uint i = 0, j = 1;
            while (n > 0)
            {
                solveHanoi(hanoi, n - 1, i, 2, j);
                var disk = hanoi.checkTopDisk(i);
                hanoi.moveDisk(i, disk % 2 == 0 ? (uint)2 : (uint)3);
                swap(ref i, ref j);
                n--;
            }
        }
        
        void solveHanoi(IHanoi h, int n, uint a, uint b, uint c)
        {
            if (n < 1) return;
            solveHanoi(h, n - 1, a, c, b);
            h.moveDisk(a, c);
            solveHanoi(h, n - 1, b, a, c);
        }

        void swap(ref uint a, ref uint b)
        {
            uint c = a;
            a = b;
            b = c;
        }

    }
}
