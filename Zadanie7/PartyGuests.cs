using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Party
{
    public class PartyGuests : IParty
    {
        public new static IParty GetInstance()
        {
            m_partyInstance = new PartyGuests();
            return m_partyInstance;
        }

        public override void placeGuests(List<int> guestList,
            uint noOfGuests, uint maxDifference, uint noOfTables, uint chairsPerTable,
            List<int> answer)
        {
            var tables = new List<List<int>>();
            for (int i = 0; i < noOfTables; i++) tables.Add(new List<int>());
            guestList.Sort();
            var guests = new Stack<int>(guestList);
            int indexStolika = 0;
            while (guests.Count > 0)
            {
                var stolik = tables[indexStolika]; //następny stolik
                //dodaj ludzi do stolika
                var first = guests.Pop();
                stolik.Add(first); //dodaj pierwszą osobę
                var second = guests.Pop();
                stolik.Add(second); //dodaj drugą osobę, bo nie może być tylko jedna
                for (int i = 2; i < chairsPerTable; i++)
                {
                    if (guests.Count == 0) break; //brak gości
                    var age = guests.Peek();
                    var dif = Math.Abs(age - first);
                    if (dif > maxDifference) break; //nie dodawaj już więcej osób, bo jest za duża różnica
                    if (guests.Count == 2 && //zostały już tylko dwie osoby
                        i == chairsPerTable - 1 //zostało już tylko jedno miejsce
                        ) break; //zostaw te dwie osoby na ostatni stolik
                    stolik.Add(guests.Pop());
                }
                indexStolika++;
            }
            for (int i = 0; i < tables.Count; i++)
            {
                var table = tables[i];
                for (int j = 0; j < table.Count; j++)
                {
                    var age = table[j];
                    answer.Add(age);
                }
                for (int j = table.Count; j < chairsPerTable; j++)
                {
                    answer.Add(0);
                }
            }
        }
    }
}
