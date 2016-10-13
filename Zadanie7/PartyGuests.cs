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
            var guests = new Stack<int>(
                from g
                in guestList
                orderby g descending
                select g);
            int indexStolika = 0;
            var stoliki = new List<Stack<int>>();
            for (int i = 0; i < noOfTables; i++) stoliki.Add(new Stack<int>());
            while (guests.Count > 0)
            {
                var stolik = stoliki[indexStolika]; //następny stolik
                var wiekPierwszego = guests.Pop();
                stolik.Push(wiekPierwszego); //dodaj pierwszą osobę
                for (int i = 1; i < chairsPerTable; i++)
                {
                    if (guests.Count == 0)
                        break; //brak gości
                    if (Math.Abs(guests.Peek() - wiekPierwszego) > maxDifference)
                        break; //nie dodawaj już więcej osób, bo jest za duża różnica wieku
                    stolik.Push(guests.Pop()); //dodaj tą osobe do stolika
                }
                //podbierz osoby z poprzednich stolików jeżeli przy tym jest tylko jedna
                var indexPoprzedniego = indexStolika - 1;
                while (stolik.Count == 1)
                {
                    var poprzedniStolik = stoliki[indexPoprzedniego];
                    stolik.Push(poprzedniStolik.Pop()); //zabierz z poprzdniego
                    stolik = poprzedniStolik; //sprawdź czy w poprzednim nie została też jedna osoba
                    indexPoprzedniego--;
                }
                indexStolika++;
            }
            //przygotuj odpowiedź
            for (int i = 0; i < stoliki.Count; i++)
            {
                var stolik = stoliki[i].OrderBy(age => age);
                //dodawanie gości do stolika
                foreach (var age in stolik) answer.Add(age);
                //dodawanie pustych miejsc
                for (int j = stolik.Count(); j < chairsPerTable; j++) answer.Add(0);
            }
        }
    }
}
