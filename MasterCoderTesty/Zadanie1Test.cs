using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLConverter;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie1Test
    {
        [TestMethod]
        public void test_czy_konwerter_działa_dla_pustych_elementów()
        {
            var konwerter = new Konwerter();
            var queries = konwerter.ConvertToSqlInsert(
                tabName: "USERS",
                typesBuff: "STRING;STRING;STRING;INT;DATE",
                colNamBuff: "USER;DESCRIPTION;NOTE;NUMBER;LOGINDATE",
                dataBuff:
                    "MICHAEL;ADMIN;COMPANY;2051;2000-12-01 23:39\n" +
                    "MICHAL;USER;COMPANY;2052;2000-12-01 00:00");
            Assert.AreEqual(expected: 2, actual: queries.Count);
            var q1 = queries.First();
            Assert.AreEqual(
                expected: "INSERT INTO USERS (USER, DESCRIPTION, NOTE, NUMBER, LOGINDATE) " +
                "VALUES ('MICHAEL', 'ADMIN', 'COMPANY', 2051, '2000-12-01 23:39');",
                actual: q1.ToString());
            var q2 = queries.Last();
            Assert.AreEqual(
                expected: "INSERT INTO USERS (USER, DESCRIPTION, NOTE, NUMBER, LOGINDATE) " +
                "VALUES ('MICHAL' , 'USER' , 'COMPANY', 2052 , '2000-12-01 00:00');",
                actual: q2.ToString());
            //STRING;STRING;INT;INT;INT;DATE
            //Pesel;FirstName;LastName;City;Street;StreetNo;Email;Login
            //0000000000000;Ala;Kowalska;Lodz;Pilsudskiego;121;Ala1@wp.pl;Ala666
            //0000000000001;Adam;Kowalskai;Lodz;;;mojemial1@wp.pl;adam1
        }

        [TestMethod]
        public void test_czy_konwerter_działa()
        {
            var konwerter = new Konwerter();
            var queries = konwerter.ConvertToSqlInsert(
                tabName: "USERS",
                typesBuff: "STRING;STRING;STRING;INT;DATE",
                colNamBuff: "USER;DESCRIPTION;NOTE;NUMBER;LOGINDATE",
                dataBuff:
                    "MICHAEL;ADMIN;COMPANY;2051;2000-12-01 23:39\n" +
                    "MICHAL;USER;COMPANY;2052;2000-12-01 00:00");
            Assert.AreEqual(expected: 2, actual: queries.Count);
            var q1 = queries.First();
            Assert.AreEqual(
                expected: "INSERT INTO USERS ( USER , DESCRIPTION , NOTE , NUMBER , LOGINDATE ) " +
                "VALUES ( 'MICHAEL' , 'ADMIN' , 'COMPANY' , 2051 , '2000-12-01 23:39' ) ;",
                actual: q1.ToString());
            var q2 = queries.Last();
            Assert.AreEqual(
                expected: "INSERT INTO USERS ( USER , DESCRIPTION , NOTE , NUMBER , LOGINDATE) " +
                "VALUES ( 'MICHAL' , 'USER' , 'COMPANY' , 2052 , '2000-12-01 00:00' ) ;",
                actual: q2.ToString());
            //STRING;STRING;INT;INT;INT;DATE
            //Pesel;FirstName;LastName;City;Street;StreetNo;Email;Login
            //0000000000000;Ala;Kowalska;Lodz;Pilsudskiego;121;Ala1@wp.pl;Ala666
            //0000000000001;Adam;Kowalskai;Lodz;;;mojemial1@wp.pl;adam1
        }
    }
}
