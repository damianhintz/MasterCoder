using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    public class HanoiSolver : IHanoiSolver
    {
        public new static IHanoiSolver GetInstance()
        {
            m_hanoiSolverInstance = new HanoiSolver();
            return m_hanoiSolverInstance;
        }

        public override void solveHanoi(IHanoi hanoi)
        {
            uint rods = 3;
            int n = hanoi.getNumberOfDisks();
            while (
                hanoi.checkTopDisk(0) >= 0 ||
                hanoi.checkTopDisk(1) >= 0)
            {
                int minDisk = n;
                uint minRod = 0;
                for (uint rod = 0; rod < rods; rod++)
                {
                    int disk = hanoi.checkTopDisk(rod);
                    if (disk < 0) continue; //brak talerzy na dysku
                    if (disk < minDisk)
                    {
                        minDisk = disk;
                        minRod = rod;
                    }
                }
                uint nextRod = minRod;
                if (n % 2 == 0)
                {
                    nextRod = (minRod + 1) % rods; //w prawo
                }
                else
                {
                    nextRod = minRod == 0 ? rods - 1 : minRod - 1; //w lewo
                }
                hanoi.moveDisk(fromRod: minRod, toRod: nextRod);
                //wykonaj jedyny możliwy ruch, nie ruszając najmniejszego
                int moveDisk = n, toDisk = -1;
                uint fromRod = 0, toRod = 0;
                for (uint rod = 0; rod < rods; rod++)
                {
                    if (rod == nextRod) continue; //nie ruszaj najmniejszego
                    int disk = hanoi.checkTopDisk(rod);
                    if (disk < 0)
                    {
                        toRod = rod;
                        break; //brak krążków, tutaj coś położymy
                    }
                    if (disk > toDisk)
                    {
                        toDisk = disk;
                        toRod = rod;
                    }
                }
                for (uint rod = 0; rod < rods; rod++)
                {
                    if (rod == nextRod) continue; //nie ruszaj najmniejszego
                    int disk = hanoi.checkTopDisk(rod);
                    if (disk < 0) continue; //brak krążków, pomiń puste
                    if (disk < moveDisk)
                    {
                        moveDisk = disk;
                        fromRod = rod;
                    }
                }
                if (hanoi.checkTopDisk(0) < 0 &&
                hanoi.checkTopDisk(1) < 0)
                    break;
                hanoi.moveDisk(fromRod, toRod);
            }
        }

        // przekłada n krążków z A, korzystając z B, na C
        void solve(IHanoi h, int n, int A, int B, int C)
        {
            if (n > 0)
            {
                solve(h, n - 1, A, C, B);
                Console.WriteLine("\t{0} -> {1}", A, C);
                solve(h, n - 1, B, A, C);
            }
        }
    }
}
