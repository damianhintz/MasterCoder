using System;
using System.Collections.Generic;
using System.Linq;
using Party;
using Hanoi;

namespace MasterCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveZadanie8();
            Console.WriteLine("Koniec.");
            Console.Read();
        }

        static void SolveZadanie8()
        {
            for (int i = 0; i <= 16; i++)
            {
                var hanoi = new HanoiTowers(n: i, rods: 4);
                var solve = new RekurencyjnyHanoiSolver();
                solve.solveHanoi(hanoi);
                hanoi.Print();
            }
        }

        static void SolveZadanie7()
        {
            var z7 = PartyGuests.GetInstance();
            var guests = new List<int>() {
                //1, 2, 3, 5,
                //5, 9,
                //10, 14, 14, 14,
                14, 15, 16,
                16, 17,
                21, 25};
            var answer = new List<int>();
            z7.placeGuests(guestList: guests,
                noOfGuests: (uint)guests.Count,
                maxDifference: 4,
                noOfTables: 3,
                chairsPerTable: 4,
                answer: answer);
            Console.WriteLine(string.Join(", ", answer));
        }
    }
}
