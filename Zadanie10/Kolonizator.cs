using System;
using System.Collections.Generic;
using System.Linq;

namespace FrequencyDistributor
{
    public class Kolonizator : IFrequencyDistributor
    {
        public new static IFrequencyDistributor GetInstance()
        {
            m_frequencyDistributorInstance = new Kolonizator();
            return m_frequencyDistributorInstance;
        }

        public override List<int> distribute(uint dimA, uint dimB, List<int> frequencies, uint minDiff)
        {
            var result = new List<int>();
            if (frequencies == null) return result;
            if (frequencies.Count == 0) return result; //brak częstotliwości
            var n = dimA * dimB;
            if (minDiff == 0)
            {
                var first = frequencies.First();
                for (int i = 0; i < n; i++) result.Add(first);
                return result;
            }
            if (n == 0) return result;
            var map = new long?[dimB + 2, dimA + 2];
            frequencies.Sort();
            var fMin = frequencies.First();
            var fMax = frequencies.Last();
            var fBorder = fMax + 1 + minDiff;
            var fMiddle = fMin - 1 - minDiff;
            //add borders
            var rows = dimB;
            var cols = dimA;
            var maxRows = rows + 2;
            var maxCols = cols + 2;
            for (int i = 0; i < maxCols; i++)
            {
                map[0, i] = fBorder;
                map[maxRows - 1, i] = fBorder;
            }
            for (int i = 0; i < maxRows; i++)
            {
                map[i, 0] = fBorder;
                map[i, maxCols - 1] = fBorder;
            }
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    //map[i, j] = fMiddle;
                }
            }
            var q = new Queue<int[]>();
            q.Enqueue(new[] { 1, 1 });
            while (q.Count > 0)
            {
                var ij = q.Dequeue();
                var i = ij[0];
                var j = ij[1];
                var f = map[i, j];
                if (!f.HasValue) //nie ustawiony
                {
                    //odwiedź sąsiadów
                    if (!setFreq(map, i, j, frequencies, minDiff)) return result;
                    for (int di = -1; di <= 1; di++)
                    {
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            q.Enqueue(new[] { i + di, j + dj });
                        }
                    }
                }
            }
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    result.Add((int)map[i, j]);
                }
            }
            return result;
        }

        bool setFreq(long?[,] map, int i, int j, List<int> frequencies, uint minDiff)
        {
            foreach (var f in frequencies)
            {
                if (checkFreq(map, i, j, f, minDiff))
                {
                    map[i, j] = f;
                    return true;
                }
            }
            return false;
        }

        bool checkFreq(long?[,] map, int i, int j, int f, uint minDiff)
        {
            for (int di = -1; di <= 1; di++)
            {
                for (int dj = -1; dj <= 1; dj++)
                {
                    var ff = map[i + di, j + dj];
                    if (!ff.HasValue) continue;
                    if (Math.Abs(f - ff.Value) < minDiff)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
