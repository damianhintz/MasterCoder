using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Party;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie7Test
    {
        [TestMethod]
        public void test_czy_zadanie7_przykład()
        {
            var z7 = PartyGuests.GetInstance();
            var g = new List<int>() { 22, 31, 25, 24, 30 };
            //Tablica gości: [22, 31, 25, 24, 30]
            //Liczba gości = 5
            //Liczba stolików = 3
            //Max.liczba gości przy stoliku = 4
            //Max.różnica wieku przy jednym stoliku = 8
            var a = new List<int>();
            z7.placeGuests(guestList: g,
                noOfGuests: 5, maxDifference: 8, noOfTables: 3, chairsPerTable: 4,
                answer: a);
            ValidateAnswer(a, 8, 3, 4);
        }

        [TestMethod]
        public void test_czy_zadanie7_6()
        {
            var z7 = PartyGuests.GetInstance();
            var g = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //Tablica gości: [1, 2, 3, 4, 5, 6]
            //Liczba gości = 6
            //Liczba stolików = 100
            //Max.liczba gości przy stoliku = 100
            //Max.różnica wieku przy jednym stoliku = 1
            var a = new List<int>();
            z7.placeGuests(guestList: g,
                noOfGuests: 6, maxDifference: 1, noOfTables: 100, chairsPerTable: 100,
                answer: a);
            ValidateAnswer(a, 1, 100, 100);
        }

        [TestMethod]
        public void test_czy_zadanie7_0()
        {
            var z7 = PartyGuests.GetInstance();
            var g = new List<int>() { 1, 1, 1, 1, 1, 1 };
            //Tablica gości: [1, 2, 3, 4, 5, 6]
            //Liczba gości = 6
            //Liczba stolików = 2
            //Max.liczba gości przy stoliku = 3
            //Max.różnica wieku przy jednym stoliku = 0
            var a = new List<int>();
            z7.placeGuests(guestList: g,
                noOfGuests: 6, maxDifference: 0, noOfTables: 2, chairsPerTable: 3,
                answer: a);
            ValidateAnswer(a, 0, 2, 3);
        }

        [TestMethod]
        public void test_czy_zadanie7_4()
        {
            var z7 = PartyGuests.GetInstance();
            var guests = new List<int>() {
                1, 2, 3, 5,
                5, 9,
                10, 14, 14, 14,
                14, 15, 16,
                16, 17,
                21, 25};
            var answer = new List<int>();
            z7.placeGuests(guestList: guests,
                noOfGuests: (uint)guests.Count, 
                maxDifference: 4, 
                noOfTables: 6, 
                chairsPerTable: 4,
                answer: answer);
            ValidateAnswer(answer, 4, 6, 4);
            var expected = new int[] {
                1, 2, 3, 5,
                5, 9, 0, 0,
                10, 14, 14, 14,
                14, 15, 16, 0,
                16, 17, 0, 0,
                21, 25, 0, 0
            };
            var s = string.Join(", ", answer);
            for(int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], answer[i], s);
            }
        }

        void ValidateAnswer(List<int> answer, int r, int s, int m)
        {
            Assert.AreEqual(expected: s * m, actual: answer.Count);
            for (int i = 0; i < answer.Count; i += m)
            {
                int min = answer[i], max = answer[i];
                for (int j = i + 1; j < m; j++)
                {
                    if (answer[j] == 0) continue;
                    if (answer[j] < min) min = answer[j];
                    if (answer[j] > max) max = answer[j];
                }
                Assert.IsTrue(max - min <= r,
                    string.Format("{0} {1} {2}", max, min, r));
            }
        }
    }
}
