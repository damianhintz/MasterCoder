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
            solveHanoi(hanoi, hanoi.getNumberOfDisks(), 0, 1, 2);
        }

        /// <summary>
        /// Przekłada n krążków z a, korzystając z b, na c:
        /// przenieś n-1 górnych krążków z palika początkowego na palik pomocniczy,
        /// przenieś n-ty krążek na palik docelowy,
        /// przenieś n-1 górnych krążków z palika pomocniczego na docelowy.
        /// </summary>
        void solveHanoi(IHanoi h, int n, uint a, uint b, uint c)
        {
            //solve_odd_even(h, n);
            BicolorProblem(a, b, c, n, h);
        }

        void BicolorProblem(uint a, uint b, uint via, int n, IHanoi h)
        {
            if (n == 1)
            {
                h.moveDisk(a, via); //move from a to via
                h.moveDisk(b, a); //move from b to a
                h.moveDisk(via, b); //move from via to b
            }
            else
            {
                EasyBicolorProblem(a, b, via, n - 1, h);
                //SwapBaseDiskProblem(a, b, via, n, h);
            }
        }

        void EasyBicolorProblem(uint a, uint b, uint via, int n, IHanoi h)
        {
            if (n == 1) return;
            else BicolorProblem(a, b, via, n - 1, h);
        }

        void SwapBaseDiskProblem(uint a, uint b, uint via, int n, IHanoi h)
        {
            if (n == 1)
            {
                h.moveDisk(a, via); //print: Move from A to Via
                h.moveDisk(b, a); //print: Move from B to A
                h.moveDisk(via, b); //print: Move from Via to B
            }
            else
            {
                MergeProblem(a, b, via, n - 1, h);
                h.moveDisk(b, via); //print: Move from B to Via
                DoubleTowersOfHanoi(a, via, b, n - 1, h);
                h.moveDisk(a, b); //print: Move from A to B
                DoubleTowersOfHanoi(via, b, a, n - 1, h);
                h.moveDisk(via, a); //print: Move from Via to A
                EnhancedDoubleTowersOfHanoi(b, a, via, n - 1, h);
                SplitProblem(a, b, via, n - 1, h);
            }
        }

        void SplitProblem(uint a, uint b, uint via, int n, IHanoi h)
        {
            if (n == 1)
            {
                h.moveDisk(a, b); //print: Move from A to B
            }
            else
            {
                DoubleTowersOfHanoi(a, via, b, n - 1, h);
                h.moveDisk(a, b); //print: Move from A to B
                DoubleTowersOfHanoi(via, a, b, n - 1, h);
                SplitProblem(a, b, via, n - 1, h);
            }
        }

        void MergeProblem(uint a, uint b, uint via, int n, IHanoi h)
        {
            if (n == 1)
            {
                h.moveDisk(b, a); //print: Move from B to A
            }
            else
            {
                MergeProblem(a, b, via, n - 1, h);
                DoubleTowersOfHanoi(a, via, b, n - 1, h);
                h.moveDisk(b, a); //print: Move from B to A
                DoubleTowersOfHanoi(via, a, b, n - 1, h);
            }
        }

        void EnhancedDoubleTowersOfHanoi(uint a, uint b, uint via, int n, IHanoi h)
        {
            DoubleTowersOfHanoi(a, via, b, n, h);
            DoubleTowersOfHanoi(via, b, a, n, h);
        }

        void DoubleTowersOfHanoi(uint a, uint b, uint via, int n, IHanoi h)
        {
            if (n == 1)
            {
                h.moveDisk(a, b); //print: Move from A to B
                h.moveDisk(a, b); //print: Move from A to B
            }
            else
            {
                DoubleTowersOfHanoi(a, via, b, n - 1, h);
                h.moveDisk(a, b); //print: Move from A to B
                h.moveDisk(a, b); //print: Move from A to B
                DoubleTowersOfHanoi(via, b, a, n - 1, h);
            }
        }

        void solve_odd_even(IHanoi h, int n)
        {
            uint dst = 1;
            uint mid = 2;
            if (n % 2 == 0) swap(ref dst, ref mid);
            solveTowers(0, dst, mid, n, h);
            for (int i = n - 1; i > 0; --i)
            {
                uint src = 1;
                dst = 2;
                if (i % 2 == 0) swap(ref src, ref dst);
                solveTowers(src, dst, 0, i, h);
            }
        }

        void solveTowers(uint src, uint dst, uint mid, int n, IHanoi h)
        {
            if (n == 0) return;
            solveTowers(src, mid, dst, n - 1, h);
            h.moveDisk(src, dst);
            solveTowers(mid, dst, src, n - 1, h);
        }

        void swap(ref uint a, ref uint b)
        {
            uint c = a;
            a = b;
            b = c;
        }

    }
}
