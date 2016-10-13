using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    public class HanoiTowers : IHanoi
    {
        int _numberOfDisks;
        Stack<int>[] _rods;

        public HanoiTowers(int n, int rods = 3)
        {
            _numberOfDisks = n;
            _rods = new Stack<int>[rods];
            for (int i = 0; i < _rods.Length; i++)
            {
                _rods[i] = new Stack<int>();
            }
            for (int i = n - 1; i >= 0; i--)
            {
                _rods[0].Push(i);
            }
        }

        public override int checkTopDisk(uint rod)
        {
            if (_rods[rod].Count == 0) return -1;
            else return _rods[rod].Peek();
        }

        public override int getNumberOfDisks()
        {
            return _numberOfDisks;
        }

        public override bool moveDisk(uint fromRod, uint toRod)
        {
            
            var disk = checkTopDisk(fromRod);
            var toDisk = checkTopDisk(toRod);
            if (toDisk >= 0 && disk > toDisk)
            {
                throw new InvalidOperationException(
                    "Nie można przenosić dużego na mały");
            }
            _rods[toRod].Push(_rods[fromRod].Pop());
            
            //Console.WriteLine(string.Join(", ", from r in _rods select r.Count));
            for(int rod = 0;rod < _rods.Length; rod++)
            {
                Console.WriteLine(string.Join(" ", from d in _rods[rod].Reverse() select d));
            }
            Console.WriteLine();
            Console.Read();
            return true;
        }
    }
}
