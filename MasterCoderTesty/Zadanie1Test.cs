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
            var konwerter = Konwerter.GetInstance();
            var queries = konwerter.ConvertToSqlInsert(
                tabName: "USERS",
                typesBuff: "STRING;STRING;STRING;STRING;STRING;INT;STRING;STRING",
                colNamBuff: "Pesel;FirstName;LastName;City;Street;StreetNo;Email;Login",
                dataBuff:
                    "0000000000000;Ala;Kowalska;Lodz;Pilsudskiego;121;Ala1@wp.pl;Ala666\n" +
                    "0000000000001;Adam;Kowalskai;Lodz;;;mojemial1@wp.pl;adam1");
            Assert.AreEqual(expected: 2, actual: queries.Count);
            var q1 = queries.First();
            Assert.AreEqual(expected: 39, actual: q1.Components.Count);
            var q1Join = string.Join(" ", q1.Components);
            Assert.AreEqual(
                expected: "INSERT INTO USERS ( Pesel , FirstName , LastName , City , Street , StreetNo , Email , Login ) " +
                "VALUES ( '0000000000000' , 'Ala' , 'Kowalska' , 'Lodz' , 'Pilsudskiego' , 121 , 'Ala1@wp.pl' , 'Ala666' ) ;",
                actual: q1Join);
            var q2 = queries.Last();
            Assert.AreEqual(expected: 31, actual: q2.Components.Count);
            var q2Join = string.Join(" ", q2.Components);
            Assert.AreEqual(
                expected: "INSERT INTO USERS ( Pesel , FirstName , LastName , City , Email , Login ) " +
                "VALUES ( '0000000000001' , 'Adam' , 'Kowalskai' , 'Lodz' , 'mojemial1@wp.pl' , 'adam1' ) ;",
                actual: q2Join);
        }

        [TestMethod]
        public void test_czy_konwerter_działa()
        {
            var konwerter = Konwerter.GetInstance();
            var queries = konwerter.ConvertToSqlInsert(
                tabName: "USERS",
                typesBuff: "STRING;STRING;STRING;INT;DATE",
                colNamBuff: "USER;DESCRIPTION;NOTE;NUMBER;LOGINDATE",
                dataBuff:
                    "MICHAEL;ADMIN;COMPANY;2051;2000-12-01 23:39\n" +
                    "MICHAL;USER;COMPANY;2052;2000-12-01 00:00");
            Assert.AreEqual(expected: 2, actual: queries.Count);
            var q1 = queries.First();
            Assert.AreEqual(expected: 27, actual: q1.Components.Count);
            var q1Join = string.Join(" ", q1.Components);
            Assert.AreEqual(
                expected: "INSERT INTO USERS ( USER , DESCRIPTION , NOTE , NUMBER , LOGINDATE ) " +
                "VALUES ( 'MICHAEL' , 'ADMIN' , 'COMPANY' , 2051 , '2000-12-01 23:39' ) ;",
                actual: q1Join);
            var q2 = queries.Last();
            Assert.AreEqual(expected: 27, actual: q2.Components.Count);
            var q2Join = string.Join(" ", q2.Components);
            Assert.AreEqual(
                expected: "INSERT INTO USERS ( USER , DESCRIPTION , NOTE , NUMBER , LOGINDATE ) " +
                "VALUES ( 'MICHAL' , 'USER' , 'COMPANY' , 2052 , '2000-12-01 00:00' ) ;",
                actual: q2Join);
        }
    }
}
